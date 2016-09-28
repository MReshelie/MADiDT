Imports System.Data.Linq
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCPersonInfo
    Dim db As New DataClassesDorogaDataContext
    Dim _nUser As Integer

    Public Sub New(ByRef nUser As Integer)
        InitializeComponent()

        _nUser = nUser
    End Sub

    Private Sub XtraUCPersonInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call DataGrid()
    End Sub

#Region "Пользовательские функции и процедуры"
    Private Sub DataGrid()
        Dim arRelationName(Me.GridControlPersonRecord.LevelTree.Nodes.Count) As String

        For i As Integer = 0 To Me.GridControlPersonRecord.LevelTree.Nodes.Count - 1
            arRelationName(i) = Me.GridControlPersonRecord.LevelTree.Nodes(i).RelationName

            'Console.WriteLine(String.Format("arRelationName({0}) = {1}", i, arRelationName(i)))
        Next

        db = New DataClassesDorogaDataContext()

        Dim Persona = From p In db.GetTable(Of Сотрудник)() Order By p.Фамилия, p.Имя, p.Отчество
        Dim Email As Table(Of Email) = db.GetTable(Of Email)
        Dim Address As Table(Of Адрес) = db.GetTable(Of Адрес)
        Dim Passport As Table(Of Паспорт) = db.GetTable(Of Паспорт)
        Dim Photo As Table(Of Фото) = db.GetTable(Of Фото)
        Dim Contact As Table(Of Контакт) = db.GetTable(Of Контакт)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet()
        Dim sqlSelect As String = "SELECT * FROM Сотрудник WHERE КодСотрудник = " + Str(_nUser) + ";" +
                                  "SELECT * FROM Контакт;" +
                                  "SELECT * FROM Адрес;" +
                                  "SELECT * FROM Email;" +
                                  "SELECT * FROM Паспорт;" +
                                  "SELECT * FROM Фото;"
        Dim conString As String = My.Settings.DorogaConnectionString.ToString
        Dim sqlConn As SqlConnection = New SqlConnection(conString)

        sqlConn.Open()
        da.SelectCommand = New SqlCommand(sqlSelect, sqlConn)
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

        ds.Relations.Clear()
        ds.Relations.AddRange(New DataRelation() {relContact, relAddress, relEmail, relPassport, relPhoto})
        Me.GridControlPersonRecord.DataSource = ds.Tables("Сотрудник")
        Me.GridControlPersonRecord.ForceInitialize()

        sqlConn.Close()
    End Sub
#End Region
End Class
