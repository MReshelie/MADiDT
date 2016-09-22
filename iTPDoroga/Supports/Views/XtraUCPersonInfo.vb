Imports System.Data.Linq
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCPersonInfo
    'Inherits EditFormUserControl

    Dim db As New DataClassesDorogaDataContext

    Public Sub New()
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        Call DataGrid()
    End Sub

#Region "Пользовательские функции и процедуры"
    Private Sub DataGrid()
        Dim arRelationName(Me.GridControlPersonRecord.LevelTree.Nodes.Count) As String

        For i As Integer = 0 To Me.GridControlPersonRecord.LevelTree.Nodes.Count - 1
            arRelationName(i) = Me.GridControlPersonRecord.LevelTree.Nodes(i).RelationName

            Console.WriteLine(String.Format("arRelationName({0}) = {1}", i, arRelationName(i)))
        Next

        db = New DataClassesDorogaDataContext()
        'Dim Persona = From p In db.GetTable(Of Сотрудник)() Order By p.Фамилия, p.Имя, p.Отчество
        Dim Persona = From tKS In db.GetTable(Of Кафедра_Сотрудник)()
                      Order By
                          tKS.Сотрудник.Фамилия,
                          tKS.Сотрудник.Имя,
                          tKS.Сотрудник.Отчество
                      Select
                          код = tKS.Сотрудник.КодСотрудник,
                          tKS.Сотрудник.Фамилия,
                          tKS.Сотрудник.Имя,
                          tKS.Сотрудник.Отчество,
                          Кафедра = tKS.Кафедра.Аббревиатура,
                          Факультет = tKS.Сотрудник.Факультет.Аббр_Факультет,
                          Степень = tKS.Сотрудник.Степень.Аббревиатура,
                          Должность = tKS.Сотрудник.Должность.Аббревиатура,
                          tKS.Сотрудник.Записал,
                          Дата_записи = CType(tKS.Сотрудник.датаЗаписал, DateTime?),
                          tKS.Сотрудник.Исправил,
                          Дата_исправления = CType(tKS.Сотрудник.датаИсправил, DateTime?),
                          tKS.Сотрудник.Примечание

        Dim Email As Table(Of Email) = db.GetTable(Of Email)
        Dim Address As Table(Of Адрес) = db.GetTable(Of Адрес)
        Dim Passport As Table(Of Паспорт) = db.GetTable(Of Паспорт)
        Dim Photo As Table(Of Фото) = db.GetTable(Of Фото)
        Dim Contact As Table(Of Контакт) = db.GetTable(Of Контакт)

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet()
        'Dim sqlСотрудник As String = "SELECT tS.КодСотрудник as код, tS.Фамилия, tS.Имя, tS.Отчество, tK.Аббревиатура as Кафедра, tF.Аббр_Факультет as Факультет, tSt.Аббревиатура as Степень, " &
        '                                    "tD.Аббревиатура as Должность, tS.Записал, tS.датаЗаписал as Дата_записи, tS.Исправил, tS.датаИсправил as Дата_исправления, tS.Примечание " &
        '                             "FROM dbo.Сотрудник tS " &
        '                                    "join dbo.Кафедра_Сотрудник tKS on tS.КодСотрудник = tKS.кодСотрудник " &
        '                                    "join dbo.Кафедра tK on tKS.кодКафедра = tK.КодКафедра " &
        '                                    "join dbo.Факультет tF on tS.кодФакультет = tF.кодФакультет " &
        '                                    "join dbo.Степень tSt on tS.кодСтепень = tSt.кодСтепень " &
        '                                    "join dbo.Должность tD on tS.кодДолжность = tD.кодДолжность " &
        '                             "ORDER BY tS.Фамилия, ts.Имя, ts.Отчество;"

        'Dim sqlSelect As String = sqlСотрудник + "SELECT * FROM Контакт;" + "SELECT * FROM Адрес;"
        Dim sqlSelect As String = "SELECT * FROM Сотрудник;" + "SELECT * FROM Контакт;" + "SELECT * FROM Адрес;" + "SELECT * FROM Email;" + "SELECT * FROM Паспорт;" + "SELECT * FROM Фото;"

        Dim conString As String = My.Settings.DorogaConnectionString.ToString
        Dim sqlConn As SqlConnection = New SqlConnection(conString)

        sqlConn.Open()
        da.SelectCommand = New SqlCommand(sqlSelect, sqlConn)
        'da.TableMappings.Add("Persona", "Сотрудник")
        'da.TableMappings.Add("Contact", "Контакт")
        'da.TableMappings.Add("Address", "Адрес")
        'da.TableMappings.Add("Email", "Email")
        'da.TableMappings.Add("Passport", "Паспорт")
        'da.TableMappings.Add("Photo", "Фото")
        da.TableMappings.Add("Table", "Сотрудник")
        da.TableMappings.Add("Table1", "Контакт")
        da.TableMappings.Add("Table2", "Адрес")
        da.TableMappings.Add("Table3", "Email")
        da.TableMappings.Add("Table4", "Паспорт")
        da.TableMappings.Add("Table5", "Фото")

        da.Fill(ds)

        Dim relContact As DataRelation = ds.Relations.Add("Телефон, факс, контакты", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Контакт").Columns("КодСотрудник"))
        Dim relAddress As DataRelation = ds.Relations.Add("Почтовый адрес", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Адрес").Columns("КодСотрудник"))
        Dim relEmail As DataRelation = ds.Relations.Add("Электронная почта", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Email").Columns("КодСотрудник"))
        Dim relPassport As DataRelation = ds.Relations.Add("Паспортные данные", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Паспорт").Columns("КодСотрудник"))
        Dim relPhoto As DataRelation = ds.Relations.Add("Пользовательские фотографии", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Фото").Columns("КодСотрудник"))

        'Dim relAddress As DataRelation = ds.Relations.Add("Почтовый адрес", ds.Tables("Сотрудник").Columns("код"), ds.Tables("Адрес").Columns("КодСотрудник"))
        'Dim relContact As DataRelation = ds.Relations.Add("Телефон, факс, контакты", ds.Tables("Сотрудник").Columns("код"), ds.Tables("Контакт").Columns("КодСотрудник"))

        ds.Relations.Clear()
        ds.Relations.AddRange(New DataRelation() {relContact, relAddress, relEmail, relPassport, relPhoto})
        Me.GridControlPersonRecord.DataSource = ds.Tables("Сотрудник")
        Me.GridControlPersonRecord.ForceInitialize()

        sqlConn.Close()
        'сотрудникBindingSource.DataSource = Persona
        'emailBindingSource.DataSource = Email                                           ' New iTPDoroga.DataClassesDorogaDataContext().Email
        'адресBindingSource.DataSource = Address                                         ' New iTPDoroga.DataClassesDorogaDataContext().Адрес
        'паспортBindingSource.DataSource = Passport                                      ' New iTPDoroga.DataClassesDorogaDataContext().Паспорт
        'фотоBindingSource.DataSource = Photo                                            ' New iTPDoroga.DataClassesDorogaDataContext().Фото
        'контактBindingSource.DataSource = Contact                                       ' New iTPDoroga.DataClassesDorogaDataContext().Контакт
    End Sub

#End Region
End Class
