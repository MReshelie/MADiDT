Imports System.Data.Linq
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCPersonInfo
    Dim db As New DataClassesDorogaDataContext
    Dim _nUser As Integer
    Dim ds As DataSet = New DataSet()
    Dim da As SqlDataAdapter
    Dim newRow As Boolean = False

    Dim WithEvents GridControlPersonRecord As GridControl = New GridControl() With {.Dock = DockStyle.Fill, .Name = "GridControlPersonInfo", .UseEmbeddedNavigator = True}
    Dim WithEvents GridViewСотрудник As New GridView(GridControlPersonRecord) With {.Name = "GridViewСотрудник"}
    Dim WithEvents GridViewКонтакт As New GridView(GridControlPersonRecord) With {.Name = "GridViewКонтакт"}
    Dim WithEvents GridViewАдрес As New GridView(GridControlPersonRecord) With {.Name = "GridViewАдрес"}
    Dim WithEvents GridViewEmail As New GridView(GridControlPersonRecord) With {.Name = "GridViewEmail"}
    Dim WithEvents GridViewПаспорт As New GridView(GridControlPersonRecord) With {.Name = "GridViewПаспорт"}
    Dim WithEvents GridViewФото As New GridView(GridControlPersonRecord) With {.Name = "GridViewФото"}
    Dim WithEvents GridViewПароль As New GridView(GridControlPersonRecord) With {.Name = "GridViewПароль"}

    Dim riLookUpEditСтепень As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditСтепень"}
    Dim riLookUpEditДолжность As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditДолжность"}
    Dim riLookUpEditФакультет As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФакультет"}
    Dim riLookUpEditКонтакт As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditКонтакт"}
    Dim riTextEditКонтакт As New RepositoryItemTextEdit() With {.Name = "riTextEditКонтакт"}
    Dim riLookUpEditАдрес As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditАдрес"}
    Dim riLookUpEditEmail As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditEmail"}
    Dim riLookUpEditФото As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФото"}
    Dim riLookUpEditПароль As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditПароль"}

    'Private Delegate Sub ExpandNewRowDelagate(ByVal view As GridView)
    Public Sub New(ByRef nUser As Integer)
        InitializeComponent()

        _nUser = nUser
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditФакультет)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditСтепень)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditДолжность)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditКонтакт)
        Me.GridControlPersonRecord.RepositoryItems.Add(riTextEditКонтакт)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditАдрес)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditEmail)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditФото)
        Me.GridControlPersonRecord.RepositoryItems.Add(riLookUpEditПароль)
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

    Private Sub GridControlPersonRecord_EmbeddedNavigator_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs) Handles GridControlPersonRecord.EmbeddedNavigator.ButtonClick
        Dim view As ColumnView = CType(Me.GridControlPersonRecord.FocusedView, ColumnView)

        Select Case e.Button.ButtonType
            Case NavigatorButtonType.EndEdit
                If view.UpdateCurrentRow() Then
                    Try
                        If newRow = False Then
                            If pUserF = "Администратор системы" Then
                                view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"), String.Format("{0}, [{1}]", Trim(pUserF), Trim(pUserS)))
                            Else
                                view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"), String.Format("{0} {1}.", Trim(pUserF), Mid(Trim(pUserS), 1, 1)))
                            End If

                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"), Date.Today)
                        End If

                        Try
                            Select Case view.Name
                                Case "GridViewСотрудник"
                                    db.p_SaveСотрудник(IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("КодСотрудник"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("КодСотрудник"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Фамилия"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Фамилия"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Имя"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Имя"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Отчество"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Отчество"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСтепень"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСтепень"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодДолжность"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодДолжность"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодФакультет"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодФакультет"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))))
                                Case "GridViewКонтакт"
                                    db.p_SaveКонтакт(IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодКонтакт"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодКонтакт"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСотрудник"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("кодСотрудник"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Тип Контакт"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Тип Контакт"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Контакт"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Контакт"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Исправил"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("датаИсправил"))),
                                             IIf(IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))), Nothing, view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Примечание"))))
                                Case "GridViewАдрес"
                                Case "GridViewEmail"
                                Case "GridViewПаспорт"
                                Case "GridViewФото"
                                Case "GridViewПароль"
                            End Select
                        Catch ex As Exception
                            'XtraMessageBox.Show(String.Format("ex.ToString = {0}", ex))
                            XtraMessageBox.Show(String.Format("Ошибка при записи в БД: таблица [{2}] БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex, SourceName(view.Name)),
                                       "Система: новая запись в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End Try

                        db.SubmitChanges(ConflictMode.FailOnFirstConflict)
                        newRow = False
                    Catch ex As ChangeConflictException
                        XtraMessageBox.Show(String.Format("Ошибка при записи в БД: таблица [{2}] БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex.Message, SourceName(view.Name)),
                                       "Система: запись данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        For Each occ As ObjectChangeConflict In db.ChangeConflicts
                            occ.Resolve(RefreshMode.OverwriteCurrentValues)
                        Next
                    Catch ex As Exception
                        XtraMessageBox.Show(String.Format("Ошибка при записи в БД: таблица [{2}]:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex.Message, SourceName(view.Name)),
                                       "Система: запись данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        If (Not DBConnect()) Then Return
                    End Try
                End If

                e.Handled = True
        End Select
    End Sub
    Private Sub GridViewКонтакт_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewКонтакт.InitNewRow
        Dim view As GridView = CType(sender, GridView)

        newRow = True
        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("датаЗаписал"), Date.Today)

        If pUserF = "Администратор системы" Then
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0}, [{1}]", Trim(pUserF), Trim(pUserS)))
        Else
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0} {1}.", Trim(pUserF), Mid(Trim(pUserS), 1, 1)))
        End If

        view.Columns("Записал").OptionsColumn.ReadOnly = True
        view.Columns("датаЗаписал").OptionsColumn.ReadOnly = True
        view.Columns("Исправил").OptionsColumn.ReadOnly = True
        view.Columns("датаИсправил").OptionsColumn.ReadOnly = True
        view.FocusedColumn = view.Columns("Тип Контакт")
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
        Call InitRILookUpEdit(Me.riLookUpEditДолжность)
        Call InitRILookUpEdit(Me.riLookUpEditСтепень)
        Call InitRILookUpEdit(Me.riLookUpEditФакультет)
        Call riLookUpEditData0(Me.riLookUpEditДолжность, Me.riLookUpEditСтепень, Me.riLookUpEditФакультет)

        Me.GridViewСотрудник.Columns("кодСтепень").ColumnEdit = Me.riLookUpEditСтепень
        Me.GridViewСотрудник.Columns("кодСтепень").Caption = "Степень"
        Me.GridViewСотрудник.Columns("кодДолжность").ColumnEdit = Me.riLookUpEditДолжность
        Me.GridViewСотрудник.Columns("кодДолжность").Caption = "Должность"
        Me.GridViewСотрудник.Columns("кодФакультет").ColumnEdit = Me.riLookUpEditФакультет
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
        Me.GridViewСотрудник.BestFitColumns()
        Me.GridViewСотрудник.OptionsView.ColumnAutoWidth = True

        ' GridViewКонтакт
        Call InitRILookUpEdit(Me.riLookUpEditКонтакт)
        Call riLookUpEditData1(1, Me.riLookUpEditКонтакт)

        Me.GridViewКонтакт.Columns("Тип Контакт").ColumnEdit = Me.riLookUpEditКонтакт
        Me.GridViewКонтакт.Columns("Тип Контакт").Caption = "Тип контакта"
        Me.riTextEditКонтакт.Mask.MaskType = Mask.MaskType.RegEx
        Me.riTextEditКонтакт.Mask.EditMask = "((\+\d)?\(\d{3}\))?\d{3}-\d\d-\d\d"
        Me.GridViewКонтакт.Columns("Контакт").ColumnEdit = Me.riTextEditКонтакт
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

        Me.GridViewКонтакт.BestFitColumns()
        Me.GridViewКонтакт.OptionsView.ColumnAutoWidth = True

        ' GridViewАдрес
        Call InitRILookUpEdit(Me.riLookUpEditАдрес)
        Call riLookUpEditData1(2, Me.riLookUpEditАдрес)

        Me.GridViewАдрес.Columns("типАдрес").ColumnEdit = Me.riLookUpEditАдрес
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

        Me.GridViewАдрес.BestFitColumns()
        Me.GridViewАдрес.OptionsView.ColumnAutoWidth = True

        ' GridViewEmail
        Call InitRILookUpEdit(Me.riLookUpEditEmail)
        Call riLookUpEditData1(3, Me.riLookUpEditEmail)

        Me.GridViewEmail.Columns("Тип email").ColumnEdit = Me.riLookUpEditEmail
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

        Me.GridViewEmail.BestFitColumns()
        Me.GridViewEmail.OptionsView.ColumnAutoWidth = True

        ' GridViewПаспорт
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

        Me.GridViewПаспорт.BestFitColumns()
        Me.GridViewПаспорт.OptionsView.ColumnAutoWidth = True

        ' GridViewПароль
        Call InitRILookUpEdit(Me.riLookUpEditПароль)
        Call riLookUpEditData1(4, Me.riLookUpEditПароль)

        Me.GridViewПароль.Columns("IDAuthor").Caption = "Руководитель"
        Me.GridViewПароль.Columns("IDAuthor").VisibleIndex = 1
        Me.GridViewПароль.Columns("IDLevel").ColumnEdit = Me.riLookUpEditПароль
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

        Me.GridViewПароль.BestFitColumns()
        Me.GridViewПароль.OptionsView.ColumnAutoWidth = True

        ' GridViewФото
        Call InitRILookUpEdit(Me.riLookUpEditФото)
        Call riLookUpEditData1(5, Me.riLookUpEditФото)

        Me.GridViewФото.Columns("Тип фото").ColumnEdit = Me.riLookUpEditФото
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

        Me.GridViewФото.BestFitColumns()
        Me.GridViewФото.OptionsView.ColumnAutoWidth = True


        'For i As Integer = 0 To Me.GridViewФото.Columns.Count - 1
        '    Console.WriteLine(String.Format("Me.GridViewФото.Columns({0}).Name = {1}", i, Me.GridViewФото.Columns(i).Name))
        'Next
    End Sub

    Private Sub InitRILookUpEdit(ByVal riLUEF As RepositoryItemLookUpEdit)
        Dim coll As LookUpColumnInfoCollection = riLUEF.Columns

        coll.Add(New LookUpColumnInfo("row", "Номер позиции", 0))

        Select Case riLUEF.Name
            Case "riLookUpEditФакультет"
                coll.Add(New LookUpColumnInfo("NAME", "Название факультета", 0))
            Case "riLookUpEditСтепень"
                coll.Add(New LookUpColumnInfo("NAME", "Научная степень", 0))
            Case "riLookUpEditДолжность"
                coll.Add(New LookUpColumnInfo("NAME", "Занимаемая должность", 0))
            Case "riLookUpEditКонтакт"
                coll.Add(New LookUpColumnInfo("NAME", "Тип контакта", 0))
            Case "riLookUpEditАдрес"
                coll.Add(New LookUpColumnInfo("NAME", "Тип адреса", 0))
            Case "riLookUpEditEmail"
                coll.Add(New LookUpColumnInfo("NAME", "Тип электронной почты", 0))
            Case "riLookUpEditПароль"
                coll.Add(New LookUpColumnInfo("NAME", "Уровень пользователя", 0))
            Case "riLookUpEditФото"
                coll.Add(New LookUpColumnInfo("NAME", "Тип пользовательсой фотографии", 0))
        End Select

        riLUEF.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        riLUEF.BestFitMode = BestFitMode.BestFitResizePopup
        riLUEF.SearchMode = SearchMode.AutoComplete
        riLUEF.AutoSearchColumnIndex = 1
        riLUEF.Columns("row").Visible = False
        riLUEF.ValueMember = "row"
        riLUEF.DisplayMember = "NAME"
    End Sub

    Private Sub riLookUpEditData0(ByVal riLookUpEditD As RepositoryItemLookUpEdit, ByVal riLookUpEditS As RepositoryItemLookUpEdit, ByVal riLookUpEditF As RepositoryItemLookUpEdit)
        riLookUpEditD.DataSource = Nothing
        riLookUpEditS.DataSource = Nothing
        riLookUpEditF.DataSource = Nothing
        riLookUpEditD.DataSource = db.p_GetListOfДолжность.ToList()
        riLookUpEditS.DataSource = db.p_GetListOfСтепень.ToList()
        riLookUpEditF.DataSource = db.p_GetListOfФакультет.ToList()
    End Sub
    Private Sub riLookUpEditData1(ByVal i As Integer, ByVal riLookUpEdit As RepositoryItemLookUpEdit)
        riLookUpEdit.DataSource = Nothing
        riLookUpEdit.DataSource = db.GetParameters(i).ToList()
    End Sub
#End Region
End Class
