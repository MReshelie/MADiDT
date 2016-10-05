Imports System.Data.Linq
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCPersonInfo
    Dim db As New DataClassesDorogaDataContext
    Dim _nUser As Integer
    Dim ds As DataSet = New DataSet()
    Dim da As SqlDataAdapter

    Dim WithEvents GridControlPersonRecord As GridControl = New GridControl() With {.Dock = DockStyle.Fill, .Name = "GridControlPersonInfo", .UseEmbeddedNavigator = True}
    Dim WithEvents GridViewСотрудник As New GridView(GridControlPersonRecord) With {.Name = "GridViewСотрудник"}
    Dim WithEvents GridViewКонтакт As New GridView(GridControlPersonRecord) With {.Name = "GridViewКонтакт"}
    Dim WithEvents GridViewАдрес As New GridView(GridControlPersonRecord) With {.Name = "GridViewАдрес"}
    Dim WithEvents GridViewEmail As New GridView(GridControlPersonRecord) With {.Name = "GridViewEmail"}
    Dim WithEvents GridViewПаспорт As New GridView(GridControlPersonRecord) With {.Name = "GridViewПаспорт"}
    Dim WithEvents GridViewФото As New GridView(GridControlPersonRecord) With {.Name = "GridViewФото"}
    Dim WithEvents GridViewПароль As New GridView(GridControlPersonRecord) With {.Name = "GridViewПароль"}

    'Private Delegate Sub ExpandNewRowDelagate(ByVal view As GridView)

    Public Sub New(ByRef nUser As Integer)
        InitializeComponent()

        _nUser = nUser
        Me.GridControlPersonRecord.MainView = Me.GridViewСотрудник
        Me.Controls.Add(Me.GridControlPersonRecord)
    End Sub

    Private Sub XtraUCPersonInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not DBConnect()) Then Return
    End Sub

    Private Sub GridViewPersonInfo_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs)
        'For i As Integer = 0 To ds.Relations.Count - 1
        '    'detail =
        '    'Console.WriteLine(String.Format("Me.GridViewPersonInfo.GetDetailView({0}, {1}) = {2}", e.RowHandle, i, Me.GridViewPersonInfo.GetDetailView(e.RowHandle, i).Name))
        '    Console.WriteLine(String.Format(ds.Relations(i).RelationName))
        'Next
    End Sub

    Private Sub GridControlPersonRecord_FocusedViewChanged(sender As Object, e As ViewFocusEventArgs)
        'Console.WriteLine(String.Format("e.View.Name = {0}", e.View.SourceView.Name))
    End Sub

#Region "Пользовательские функции и процедуры"
    Private Function DBConnect() As Boolean
        ds = New DataSet()
        db = New DataClassesDorogaDataContext()

        Dim Persona = From p In db.GetTable(Of Сотрудник)() Order By p.Фамилия, p.Имя, p.Отчество
        Dim Email As Table(Of Email) = db.GetTable(Of Email)
        Dim Address As Table(Of Адрес) = db.GetTable(Of Адрес)
        Dim Passport As Table(Of Паспорт) = db.GetTable(Of Паспорт)
        Dim Photo As Table(Of Фото) = db.GetTable(Of Фото)
        Dim Contact As Table(Of Контакт) = db.GetTable(Of Контакт)
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DorogaConnectionString.ToString)

        sqlConn.Open()
        da = New SqlDataAdapter("SELECT * FROM Сотрудник WHERE КодСотрудник = " + Str(_nUser), sqlConn)
        da.Fill(ds, "Сотрудник")
        da = New SqlDataAdapter("SELECT * FROM Контакт", sqlConn)
        da.Fill(ds, "Контакт")
        da = New SqlDataAdapter("SELECT * FROM Адрес", sqlConn)
        da.Fill(ds, "Адрес")
        da = New SqlDataAdapter("SELECT * FROM Email", sqlConn)
        da.Fill(ds, "Email")
        da = New SqlDataAdapter("SELECT * FROM Паспорт", sqlConn)
        da.Fill(ds, "Паспорт")
        da = New SqlDataAdapter("SELECT * FROM Фото", sqlConn)
        da.Fill(ds, "Фото")
        da = New SqlDataAdapter("SELECT * FROM Пароль", sqlConn)
        da.Fill(ds, "Пароль")
        sqlConn.Close()

        Dim relContact As DataRelation = ds.Relations.Add("Телефон, факс, контакты", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Контакт").Columns("КодСотрудник"))
        Dim relEmail As DataRelation = ds.Relations.Add("Электронная почта", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Email").Columns("КодСотрудник"))
        Dim relAddress As DataRelation = ds.Relations.Add("Почтовый адрес", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Адрес").Columns("КодСотрудник"))
        Dim relPassport As DataRelation = ds.Relations.Add("Паспортные данные", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Паспорт").Columns("КодСотрудник"))
        Dim relPhoto As DataRelation = ds.Relations.Add("Пользовательские фотографии", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Фото").Columns("КодСотрудник"))
        Dim relPassword As DataRelation = ds.Relations.Add("Безопасность", ds.Tables("Сотрудник").Columns("КодСотрудник"), ds.Tables("Пароль").Columns("IDUser"))

        ds.Relations.Clear()
        ds.Relations.AddRange(New DataRelation() {relContact, relEmail, relAddress, relPassport, relPhoto, relPassword})
        Me.GridControlPersonRecord.DataSource = ds.Tables("Сотрудник")
        Me.GridControlPersonRecord.ForceInitialize()

        Call GVSettings(Me.GridControlPersonRecord, ds)
        Return True
    End Function

    Private Sub GVSettings(ByVal _gc As GridControl, ByVal _ds As DataSet)
        Dim gvNode As GridLevelNode

        gvNode = _gc.LevelTree.Nodes.Add("Телефон, факс, контакты", Me.GridViewКонтакт)
        Me.GridViewКонтакт.PopulateColumns(_ds.Tables("Контакт"))
        gvNode = _gc.LevelTree.Nodes.Add("Электронная почта", Me.GridViewEmail)
        Me.GridViewEmail.PopulateColumns(_ds.Tables("Email"))
        gvNode = _gc.LevelTree.Nodes.Add("Почтовый адрес", Me.GridViewАдрес)
        Me.GridViewАдрес.PopulateColumns(_ds.Tables("Адрес"))
        gvNode = _gc.LevelTree.Nodes.Add("Паспортные данные", Me.GridViewПаспорт)
        Me.GridViewПаспорт.PopulateColumns(_ds.Tables("Паспорт"))
        gvNode = _gc.LevelTree.Nodes.Add("Пользовательские фотографии", Me.GridViewФото)
        Me.GridViewФото.PopulateColumns(_ds.Tables("Фото"))
        gvNode = _gc.LevelTree.Nodes.Add("Безопасность", Me.GridViewПароль)
        Me.GridViewПароль.PopulateColumns(_ds.Tables("Пароль"))

        ' GridViewСотрудник
        Me.GridViewСотрудник.BestFitColumns()
        Me.GridViewСотрудник.OptionsView.ColumnAutoWidth = True
        Me.GridViewСотрудник.Columns("кодСтепень").Caption = "Степень"
        Me.GridViewСотрудник.Columns("кодДолжность").Caption = "Должность"
        Me.GridViewСотрудник.Columns("кодФакультет").Caption = "Факультет"
        Me.GridViewСотрудник.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewСотрудник.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewСотрудник.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewСотрудник.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewСотрудник.Columns("КодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewСотрудник.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Me.GridViewСотрудник.OptionsDetail.AllowExpandEmptyDetails = True

        ' GridViewКонтакт
        Me.GridViewКонтакт.BestFitColumns()
        Me.GridViewКонтакт.OptionsView.ColumnAutoWidth = True
        Me.GridViewКонтакт.Columns("Тип Контакт").Caption = "Тип контакта"
        Me.GridViewКонтакт.Columns("Контакт").Caption = "Номер контакта"
        Me.GridViewКонтакт.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewКонтакт.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewКонтакт.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewКонтакт.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewКонтакт.Columns("кодКонтакт").Visible = False
        Me.GridViewКонтакт.Columns("кодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewКонтакт.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ' GridViewEmail
        Me.GridViewEmail.BestFitColumns()
        Me.GridViewEmail.OptionsView.ColumnAutoWidth = True
        Me.GridViewEmail.Columns("Тип email").Caption = "Тип электронной почты"
        Me.GridViewEmail.Columns("email").Caption = "Электронная почта"
        Me.GridViewEmail.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewEmail.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewEmail.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewEmail.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewEmail.Columns("кодEmail").Visible = False
        Me.GridViewEmail.Columns("кодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewEmail.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ' GridViewАдрес
        Me.GridViewАдрес.BestFitColumns()
        Me.GridViewАдрес.OptionsView.ColumnAutoWidth = True
        Me.GridViewАдрес.Columns("типАдрес").Caption = "Тип адреса"
        Me.GridViewАдрес.Columns("Почтовый индекс").Caption = "Почтовый индекс"
        Me.GridViewАдрес.Columns("Субъект РФ (регион)").Caption = "Субъект РФ (регион)"
        Me.GridViewАдрес.Columns("Наименование района").Caption = "Район"
        Me.GridViewАдрес.Columns("Наименование города").Caption = "Город"
        Me.GridViewАдрес.Columns("Наименование населенного пункта").Caption = "Населенный пункт"
        Me.GridViewАдрес.Columns("Наименование улицы").Caption = "Улица"
        Me.GridViewАдрес.Columns("Номер дома (владение)").Caption = "Д (влд)"
        Me.GridViewАдрес.Columns("Корпус (строение)").Caption = "К (стр)"
        Me.GridViewАдрес.Columns("Квартира (офис)").Caption = "Кв (оф)"
        Me.GridViewАдрес.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewАдрес.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewАдрес.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewАдрес.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewАдрес.Columns("кодАдрес").Visible = False
        Me.GridViewАдрес.Columns("кодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewАдрес.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ' GridViewПаспорт
        Me.GridViewПаспорт.BestFitColumns()
        Me.GridViewПаспорт.OptionsView.ColumnAutoWidth = True
        Me.GridViewПаспорт.Columns("Код подразделения").Caption = "Код подразделения"
        Me.GridViewПаспорт.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewПаспорт.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewПаспорт.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewПаспорт.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewПаспорт.Columns("кодПаспорт").Visible = False
        Me.GridViewПаспорт.Columns("кодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewПаспорт.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ' GridViewФото
        Me.GridViewФото.BestFitColumns()
        Me.GridViewФото.OptionsView.ColumnAutoWidth = True
        Me.GridViewФото.Columns("Тип фото").Caption = "Тип фотографии"
        Me.GridViewФото.Columns("датаЗаписал").Caption = "Дата записи"
        Me.GridViewФото.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewФото.Columns("датаИсправил").Caption = "Дата исправления"
        Me.GridViewФото.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewФото.Columns("кодФото").Visible = False
        Me.GridViewФото.Columns("кодСотрудник").Visible = False

        For Each column As GridColumn In Me.GridViewФото.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ' GridViewПароль
        Me.GridViewПароль.BestFitColumns()
        Me.GridViewПароль.OptionsView.ColumnAutoWidth = True
        Me.GridViewПароль.Columns("IDAuthor").Caption = "Руководитель"
        Me.GridViewПароль.Columns("IDAuthor").VisibleIndex = 1
        Me.GridViewПароль.Columns("IDLevel").Caption = "Статус пользователя"
        Me.GridViewПароль.Columns("IDLevel").VisibleIndex = 2
        Me.GridViewПароль.Columns("Passport1").Caption = "Пароль"
        Me.GridViewПароль.Columns("Passport2").Caption = "Пароль (повтор)"
        Me.GridViewПароль.Columns("Дата записи").Caption = "Дата записи"
        Me.GridViewПароль.Columns("Дата записи").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewПароль.Columns("Дата исправления").Caption = "Дата исправления"
        Me.GridViewПароль.Columns("Дата исправления").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewПароль.Columns("IDPassport").Visible = False
        Me.GridViewПароль.Columns("IDUser").Visible = False

        For Each column As GridColumn In Me.GridViewПароль.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next


        'For i As Integer = 0 To Me.GridViewФото.Columns.Count - 1
        '    Console.WriteLine(String.Format("Me.GridViewФото.Columns({0}).Name = {1}", i, Me.GridViewФото.Columns(i).Name))
        'Next

    End Sub
#End Region
End Class
