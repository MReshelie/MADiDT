Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.IO
Imports System.Xml
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Module MainModule
    ''' <summary>
    ''' Глобальные переменные
    ''' </summary>
    Friend pUserF As String = String.Empty
    Friend pUserS As String = String.Empty
    Friend pUserL As String = String.Empty
    Friend pPass As String = String.Empty
    Friend gConnMain As New SqlConnection
    Public gblConn As Boolean = False
    Public gblExit As Boolean = False

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Процедура: Задержка строки сообщения на экране заставки загрузки прграммы
    ''' </summary>
    ''' <param name="interval">Величина интервала задержки в милисекунлах</param>
    Public Sub ConnectDBExtracted(ByVal interval As Integer)
        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(interval)
        Next i
    End Sub
    ''' <summary>
    ''' Процедура: Обновление строки подключения к БД в app.config
    ''' </summary>
    ''' <param name="exeConfigName">Имя выполняемого модуля</param>
    ''' <param name="sConnStr">Строка подключения</param>
    ''' <param name="strNameConnStr">Имя строки подключения</param>
    Public Sub ToggleConfigEncryption(ByVal exeConfigName As String, ByVal sConnStr As String, ByVal strNameConnStr As String)
        ' Передавать имя файла конфигурации для выполняемого модуля без расширения .config
        Try
            ' Открытие файла конфигурации и получение значений для секции connectionStrings.
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(exeConfigName)
            Dim section As ConnectionStringsSection = DirectCast(config.GetSection("connectionStrings"), ConnectionStringsSection)

            If section.SectionInformation.IsProtected Then
                ' Удаление криптования секции файла конфигурации.
                section.SectionInformation.UnprotectSection()
            End If

            For i As Integer = 0 To section.ConnectionStrings.Count - 1
                If section.ConnectionStrings(i).ToString = Settings.Default.Item(strNameConnStr).ToString Then
                    section.ConnectionStrings(i).ConnectionString = Trim(sConnStr)
                    config.Save(ConfigurationSaveMode.Modified)
                    Settings.Default.Item(strNameConnStr) = section.ConnectionStrings(i).ToString
                    Exit For
                End If
            Next

            'If section.SectionInformation.IsProtected = False Then
            '    ' Криптование секции файла конфигурации.
            '    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
            'End If

            ' Сохранение текущей конфигурации
            config.Save()
            XtraMessageBox.Show(String.Format("Файл с конфигурацией и новой строкой подключения: {0}{0}{1}{0}{0}успешно сохранен и перезаписан.{0}{0}Система будет перезапущена.",
                                              Global.Microsoft.VisualBasic.ChrW(10), strPassword(sConnStr)),
                                            "Система: перезапуск.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' Функция: Загрузка данных в объект DataTable
    ''' </summary>
    ''' <param name="parIList">Объект List, данные из которго перезаписываются в Datatable</param>
    ''' <returns>Возвращается сформированныей DataTable</returns>
    Public Function EQToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable
        Dim ret As New System.Data.DataTable()

        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing

            If parIList Is Nothing Then Return ret

            For Each itm In parIList
                If ppi Is Nothing Then
                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()

                    For Each pi As System.Reflection.PropertyInfo In ppi
                        Dim colType As System.Type = pi.PropertyType

                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                    Next
                End If

                Dim dr As System.Data.DataRow = ret.NewRow

                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next

                ret.Rows.Add(dr)
            Next

            For Each c As System.Data.DataColumn In ret.Columns
                c.ColumnName = c.ColumnName.Replace("_", " ")
            Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' Функция: Получение списка доступных БД с сервера (SQL server)
    ''' </summary>
    ''' <param name="_ServName">Имя сервера\Имя SQL server</param>
    ''' <param name="_UserID">Учетная запись</param>
    ''' <param name="_Password">Пароль учетной записи</param>
    ''' <returns>Список имен доступных БД</returns>
    Public Function GetDataBases(ByVal _ServName As String, ByVal _UserID As String, ByVal _Password As String) As List(Of String)
        Dim DBlist As New List(Of String)
        Dim reader As SqlDataReader
        Dim MyConn As New SqlClient.SqlConnection

        MyConn.ConnectionString = "Data Source=" & Trim(_ServName) & ";User ID=" & Trim(_UserID) & ";Password=" & Trim(_Password)

        Dim query As String = "sp_databases"
        Dim command As SqlCommand = New SqlCommand(query, MyConn)

        Try
            MyConn.Open()
            reader = command.ExecuteReader

            While reader.Read()
                DBlist.Add(CType(reader("DATABASE_NAME"), String))
            End While

            reader.Close()
            MyConn.Close()
        Catch ex As SqlException
            XtraMessageBox.Show(String.Format("Ошибка при подключении к SQL Server: {0}{0}{1}{0}{0}Для устранения в дальнейшем подобных ошибок, " &
                                              "обратитесь к администратору.{0}{0}Приложение будет остановлено.", Global.Microsoft.VisualBasic.ChrW(10), ex.Message),
                                              "Система: список доступных БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            DBlist.Add("Нет записей")
        End Try

        Return DBlist
    End Function
    ''' <summary>
    ''' Функция: Формирование строки подключения к серверу БД
    ''' </summary>
    ''' <param name="_ServName">Имя сервера</param>
    ''' <param name="_Catalog">Имя БД</param>
    ''' <param name="_UserID">Учетная запись</param>
    ''' <param name="_Password">Пароль учетной записи</param>
    ''' <returns>Строка подключения</returns>
    Public Function SetConnectionString(ByVal _ServName As String, ByVal _Catalog As String, ByVal _UserID As String, ByVal _Password As String) As String
        Dim sqlBuilder As New SqlConnectionStringBuilder

        If Not String.IsNullOrWhiteSpace(_ServName) Then
            sqlBuilder.DataSource = _ServName
        End If

        If Not String.IsNullOrWhiteSpace(_Catalog) Then
            sqlBuilder.InitialCatalog = _Catalog
        End If

        sqlBuilder.IntegratedSecurity = False
        sqlBuilder.Password = _Password
        sqlBuilder.UserID = _UserID

        Return sqlBuilder.ConnectionString
    End Function
    ''' <summary>
    ''' Функция: Скрытие пароля в строке connectionString
    ''' </summary>
    ''' <param name="_strConn">Исходная строка подключения</param>
    ''' <returns>Возвращается исходная строка подключения с символами * вместо символов пароля</returns>
    Private Function strPassword(ByVal _strConn As String) As String
        _strConn += ";"

        If InStrRev(LCase(_strConn), "password") > 0 Then
            For i As Integer = InStr(InStrRev(LCase(_strConn), "password"), _strConn, "=") + 1 To InStr(InStrRev(LCase(_strConn), "password"), _strConn, ";") - 1
                Mid(_strConn, i, 1) = "*"
            Next
        End If

        Return Mid(_strConn, 1, Len(_strConn) - 1)
    End Function
    ''' <summary>
    ''' Функция: Информация о назначении GridView
    ''' </summary>
    ''' <param name="_viewName">Имя GridView</param>
    ''' <returns>Информация о назначении</returns>
    Public Function SourceName(ByVal _viewName As String) As String
        Select Case _viewName
            Case "GridViewSettings"
                Return "Перечень таблиц БД [dbo.Контролер]"
            Case "GridViewParametr"
                Return "Список параметров [dbo.Параметр]"
            Case "GridViewКонтакт"
                Return "Контакты пользователя [dbo.Контакт]"
        End Select
    End Function

#Region "Работа с изображением"
    ''' <summary>
    ''' Функция: Преобразование изображения в массив байтов
    ''' </summary>
    ''' <param name="imageIn">файл с изображением</param>
    ''' <returns></returns>
    Public Function ImageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Using ms As MemoryStream = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Return ms.ToArray()
        End Using
    End Function
    ''' <summary>
    ''' Функция: Преобразование массива байтов в изображение
    ''' </summary>
    ''' <param name="byteArrayIn">массив байтов</param>
    ''' <returns>изображение</returns>
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using ms As MemoryStream = New MemoryStream(byteArrayIn)
            Dim returnImage As Image = Image.FromStream(ms)
            Return returnImage
        End Using
    End Function
    ''' <summary>
    ''' Функция: Определение расширения файла с изображением
    ''' </summary>
    ''' <param name="_image">файл с изображением</param>
    ''' <returns></returns>
    Public Function GetImageExt(ByVal _image As Image) As String
        If _image Is Nothing Then
            Return String.Empty
        End If

        If ImageFormat.Jpeg.Equals(_image.RawFormat) Then
            Return ".jpeg"
        ElseIf ImageFormat.Tiff.Equals(_image.RawFormat) Then
            Return ".tiff"
        ElseIf ImageFormat.Png.Equals(_image.RawFormat) Then
            Return ".png"
        ElseIf ImageFormat.Gif.Equals(_image.RawFormat) Then
            Return ".gif"
        ElseIf ImageFormat.Bmp.Equals(_image.RawFormat) Then
            Return ".bmp"
        End If

        Return String.Empty
    End Function
    ''' <summary>
    ''' Функция: перерисовка избражения по новым размерам
    ''' </summary>
    ''' <param name="image">изображение</param>
    ''' <param name="size">новые размеры</param>
    ''' <param name="preserveAspectRatio">[True - изменять размер, по умолчанию]</param>
    ''' <returns></returns>
    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer

        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)

            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If

        Dim newImage As Image = New Bitmap(newWidth, newHeight)

        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function
    ''' <summary>
    ''' Фукция: возвращает имя сервера из строки подключения
    ''' </summary>
    ''' <param name="_connstr">Строка подключения</param>
    ''' <returns></returns>
    Public Function DataSource(ByVal _connstr As String) As String
        Return New SqlConnectionStringBuilder(_connstr).DataSource
    End Function
#End Region
#End Region
End Module
