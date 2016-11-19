Imports System.Data.Linq
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraNavBar

Public Class XtraUCPersonRecord
    Inherits EditFormUserControl

    Dim db As New DataClassesDorogaDataContext
    Dim iСотрудник As Integer
    Dim riLookUpEditСтепень As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditСтепень"}
    Dim riLookUpEditДолжность As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditДолжность"}
    Dim riLookUpEditФакультет As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФакультет"}
    Dim riLookUpEditКонтакт As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditКонтакт"}
    Dim riMemoEditКонтакт As New RepositoryItemMemoEdit() With {.Name = "riMemoEditКонтакт", .WordWrap = True}
    Dim riTextEditКонтакт As New RepositoryItemTextEdit() With {.Name = "riTextEditКонтакт"}
    Dim riLookUpEditАдрес As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditАдрес"}
    Dim riMemoEditАдрес As New RepositoryItemMemoEdit() With {.Name = "riMemoEditАдрес", .WordWrap = True}
    Dim riLookUpEditEmail As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditEmail"}
    Dim riMemoEditEmail As New RepositoryItemMemoEdit() With {.Name = "riMemoEditEmail", .WordWrap = True}
    Dim riLookUpEditФото As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditФото"}
    Dim riLookUpEditПароль As New RepositoryItemLookUpEdit() With {.Name = "riLookUpEditПароль"}
    Dim riTextEditПаспорт As New RepositoryItemTextEdit() With {.Name = "riTextEditПаспорт"}
    Dim riMemoEditПаспорт As New RepositoryItemMemoEdit() With {.Name = "riMemoEditПаспорт", .WordWrap = True}

    Public Sub New()
        InitializeComponent()

        Me.NavBarControlPersona.Visible = False
    End Sub

    Private Sub XtraUCPersonRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iСотрудник = CType(Me.TextEditКодСотрудник.EditValue, Integer)
        Me.LayoutControlItem20.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        If (Not DBConnect()) Then Return
    End Sub

    Private Sub NavBarControlPersona_ActiveGroupChanged(sender As Object, e As NavBarGroupEventArgs) Handles NavBarControlPersona.ActiveGroupChanged
        Me.NavigationFramePersona.SelectedPage = CType(Me.NavigationFramePersona.Pages.FindFirst(Function(x) CStr(x.Tag) = e.Group.Caption), NavigationPage)
    End Sub

#Region "Пользовательские процедуры и функции"
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()

        Me.LookUpEditФакультет.Properties.DataSource = Nothing
        Me.LookUpEditФакультет.Properties.DataSource = db.p_GetListOfFullФакультет().ToList()
        Me.LookUpEditСтепень.Properties.DataSource = Nothing
        Me.LookUpEditСтепень.Properties.DataSource = db.p_GetListOfFullСтепень().ToList()
        Me.LookUpEditДолжность.Properties.DataSource = Nothing
        Me.LookUpEditДолжность.Properties.DataSource = db.p_GetListOfFullДолжность().ToList()

        Dim Kafedra = From tKS In db.p_GetКафедраФакультет(CType(Me.LookUpEditФакультет.EditValue, Integer))

        Me.LookUpEditКафедра.Properties.DataSource = Nothing
        Me.LookUpEditКафедра.Properties.DataSource = Kafedra

        Dim iKafedra = From tKS In db.p_GetКафедра_Сотрудник(iСотрудник) Take 1 Select tKS.кодКафедра

        For Each iK As Integer In iKafedra
            Me.LookUpEditКафедра.EditValue = iK
        Next

        Dim Kontakt = From p In db.p_GetКонтактСотрудник(iСотрудник)
        Dim Email = From p In db.p_GetEmailСотрудник(iСотрудник)
        Dim Address = From p In db.p_GetКонтактАдрес(iСотрудник)
        Dim Passport = From p In db.p_GetКонтактПаспорт(iСотрудник)

        Me.GridControlКонтакт.DataSource = Kontakt
        Me.GridControlEmail.DataSource = Email
        Me.GridControlАдрес.DataSource = Address
        Me.GridControlПаспорт.DataSource = Passport

        Call GVSetings(Me.GridViewКонтакт)
        Call GVSetings(Me.GridViewEmail)
        Call GVSetings(Me.GridViewАдрес)
        Call GVSetings(Me.GridViewПаспорт)
        Return True
    End Function

    Private Sub GVSetings(ByVal _gv As GridView)
        Select Case _gv.Name
            Case "GridViewКонтакт"
                Call InitRILookUpEdit(Me.riLookUpEditКонтакт)
                Call riLookUpEditData1(1, Me.riLookUpEditКонтакт)

                _gv.Columns("Тип_Контакт").ColumnEdit = Me.riLookUpEditКонтакт
                _gv.Columns("Тип_Контакт").Caption = "Тип контакта"
                Me.riTextEditКонтакт.Mask.MaskType = Mask.MaskType.RegEx
                Me.riTextEditКонтакт.Mask.EditMask = "((\+\d)?\(\d{3}\))?\d{3}-\d\d-\d\d"
                _gv.Columns("Контакт").ColumnEdit = Me.riTextEditКонтакт
                _gv.Columns("Контакт").Caption = "Номер контакта"
                _gv.Columns("датаЗаписал").Caption = "Дата записи"
                _gv.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                _gv.Columns("датаИсправил").Caption = "Дата исправления"
                _gv.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Записал").OptionsColumn.AllowEdit = False
                _gv.Columns("Исправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Примечание").ColumnEdit = Me.riMemoEditКонтакт
                _gv.Columns("кодКонтакт").Visible = False
                _gv.Columns("кодСотрудник").Visible = False
            Case "GridViewEmail"
                Call InitRILookUpEdit(Me.riLookUpEditEmail)
                Call riLookUpEditData1(3, Me.riLookUpEditEmail)

                _gv.Columns("Тип_email").ColumnEdit = Me.riLookUpEditEmail
                _gv.Columns("Тип_email").Caption = "Тип электронной почты"
                _gv.Columns("email").Caption = "Электронная почта"
                _gv.Columns("датаЗаписал").Caption = "Дата записи"
                _gv.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                _gv.Columns("датаИсправил").Caption = "Дата исправления"
                _gv.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Записал").OptionsColumn.AllowEdit = False
                _gv.Columns("Исправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Примечание").ColumnEdit = Me.riMemoEditEmail
                _gv.Columns("кодEmail").Visible = False
                _gv.Columns("кодСотрудник").Visible = False
            Case "GridViewАдрес"
                Call InitRILookUpEdit(Me.riLookUpEditАдрес)
                Call riLookUpEditData1(2, Me.riLookUpEditАдрес)

                _gv.Columns("типАдрес").ColumnEdit = Me.riLookUpEditАдрес
                _gv.Columns("типАдрес").Caption = "Тип адреса"
                _gv.Columns("Почтовый_индекс").Caption = "Почтовый индекс"
                _gv.Columns("Субъект_РФ__регион_").Caption = "Субъект РФ (регион)"
                _gv.Columns("Наименование_района").Caption = "Район"
                _gv.Columns("Наименование_города").Caption = "Город"
                _gv.Columns("Наименование_населенного_пункта").Caption = "Населенный пункт"
                _gv.Columns("Наименование_улицы").Caption = "Улица"
                _gv.Columns("Номер_дома__владение_").Caption = "Д (влд)"
                _gv.Columns("Корпус__строение_").Caption = "К (стр)"
                _gv.Columns("Квартира__офис_").Caption = "Кв (оф)"
                _gv.Columns("датаЗаписал").Caption = "Дата записи"
                _gv.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                _gv.Columns("датаИсправил").Caption = "Дата исправления"
                _gv.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Записал").OptionsColumn.AllowEdit = False
                _gv.Columns("Исправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Примечание").ColumnEdit = Me.riMemoEditEmail
                _gv.Columns("кодАдрес").Visible = False
                _gv.Columns("кодСотрудник").Visible = False
            Case "GridViewПаспорт"
                _gv.Columns("Код_подразделения").ColumnEdit = Me.riTextEditПаспорт
                _gv.Columns("Код_подразделения").Caption = "Код подразделения"
                Me.riTextEditПаспорт.Mask.MaskType = Mask.MaskType.RegEx
                Me.riTextEditПаспорт.Mask.EditMask = "\d{3}-\d{3}"
                _gv.Columns("датаЗаписал").Caption = "Дата записи"
                _gv.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаЗаписал").OptionsColumn.AllowEdit = False
                _gv.Columns("датаИсправил").Caption = "Дата исправления"
                _gv.Columns("датаИсправил").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                _gv.Columns("датаИсправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Записал").OptionsColumn.AllowEdit = False
                _gv.Columns("Исправил").OptionsColumn.AllowEdit = False
                _gv.Columns("Примечание").ColumnEdit = Me.riMemoEditПаспорт
                _gv.Columns("кодПаспорт").Visible = False
                _gv.Columns("кодСотрудник").Visible = False

        End Select

        For Each column As GridColumn In _gv.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        _gv.BestFitColumns()
        _gv.OptionsView.ColumnAutoWidth = True
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
                coll.Add(New LookUpColumnInfo("NAME", "Тип пользовательской фотографии", 0))
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
