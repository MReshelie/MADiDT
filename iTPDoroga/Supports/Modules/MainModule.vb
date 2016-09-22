Imports System.Data.SqlClient

Module MainModule
    ''' <summary>
    ''' Гловальные переменные
    ''' </summary>
    Friend pUserF As String = String.Empty
    Friend pUserS As String = String.Empty
    Friend pUserL As String = String.Empty
    Friend pPass As String = String.Empty
    Friend gConnMain As New SqlConnection
    Public gblConn As Boolean = False

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Функция Загрузка данных в объект DataTable
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
    ''' Процедура Задержка строки сообщения на экране заставки загрузки прграммы
    ''' </summary>
    ''' <param name="interval">Величина интервала задержки в милисекунлах</param>
    Public Sub ConnectDBExtracted(ByVal interval As Integer)
        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(interval)
        Next i
    End Sub
    'Private Sub SGetConnectionString(ByVal exeConfigName As String, ByVal _server As String, ByVal _user As String, ByVal _pass As String, ByVal _catalog As String)
    '    Dim entityBuilder As EntityConnectionStringBuilder = New EntityConnectionStringBuilder()

    '    Try
    '        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(exeConfigName)
    '        Dim section As ConnectionStringsSection = DirectCast(config.GetSection("connectionStrings"), ConnectionStringsSection)

    '        ' Удаление криптования секции файла конфигурации.
    '        If section.SectionInformation.IsProtected Then
    '            section.SectionInformation.UnprotectSection()
    '        End If

    '        entityBuilder.Provider = "System.Data.SqlClient"
    '        entityBuilder.ProviderConnectionString = "data source=" + _server + ";initial catalog=" + _catalog +
    '                                             ";persist security info=True;user id=" + _user + ";password=" + _pass +
    '                                             ";MultipleActiveResultSets=True;App=EntityFramework"
    '        entityBuilder.Metadata = "res://*/DataModel.DorogaModel.csdl|res://*/DataModel.DorogaModel.ssdl|res://*/DataModel.DorogaModel.msl"

    '        For i As Integer = 0 To section.ConnectionStrings.Count - 1
    '            If section.ConnectionStrings(i).Name = "DorogaEntities" Then
    '                section.ConnectionStrings(i).ConnectionString = Trim(entityBuilder.ToString)
    '                config.Save(ConfigurationSaveMode.Modified)
    '            End If
    '        Next

    '        'Криптование секции файла конфигурации.
    '        If section.SectionInformation.IsProtected = False Then
    '            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
    '        End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show(String.Format("Ошибка перезаписи строки подключения: {0}{1}{0}Лист методов, выполненые до ошибки:.{0}{2}{0}Система будет завершена.",
    '                                          Global.Microsoft.VisualBasic.ChrW(10), ex.Message, ex.StackTrace),
    '                                        "Система: строка подключения.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    Finally
    '        XtraMessageBox.Show(String.Format("Файл с конфигурацией с новой строкой подключения: {0}{0}{1}{0}{0}успешно сохранен и перезаписан.{0}{0}Система будет перезапущена.",
    '                                          Global.Microsoft.VisualBasic.ChrW(10), strPassword(Trim(entityBuilder.ToString))),
    '                                        "Система: строка подключения.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        blExit = True
    '        Application.Restart()
    '    End Try
    'End Sub

    ''' <summary>
    ''' Функция Скрытие пароля в строке connectionString
    ''' </summary>
    ''' <param name="_strConn">Исходная строка подключения</param>
    ''' <returns>Возвращается исходная строка подключения с символами * вместо символов пароля</returns>
    Private Function strPassword(ByVal _strConn As String) As String
        If InStrRev(_strConn, "password") > 0 Then
            For i As Integer = InStr(InStrRev(_strConn, "password"), _strConn, "=") + 1 To InStr(InStrRev(_strConn, "password"), _strConn, ";") - 1
                Mid(_strConn, i, 1) = "*"
            Next
        End If

        Return _strConn
    End Function
#End Region
End Module
