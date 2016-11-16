Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCPerson
    Dim db As New DataClassesDorogaDataContext
    Dim facLookUpEdit As LookUpEdit
    Dim depLookUpEdit As LookUpEdit

    Public Sub New()
        InitializeComponent()

        If (Not DBConnect()) Then Return

        Me.GridViewСотрудник.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplaceHideCurrentRow
    End Sub

    Private Sub GridViewСотрудник_MasterRowGetRelationDisplayCaption(sender As Object, e As MasterRowGetRelationNameEventArgs) Handles GridViewСотрудник.MasterRowGetRelationDisplayCaption
        '
    End Sub

    'Private Sub GridViewСотрудник_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridViewСотрудник.EditFormPrepared
    '    If e.BindableControls(Me.GridViewСотрудник.FocusedColumn) IsNot Nothing Then
    '        e.FocusField(Me.GridViewСотрудник.FocusedColumn)
    '        facLookUpEdit = TryCast(e.BindableControls(""))
    '    End If
    'End Sub

    Private Sub GridViewСотрудник_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles GridViewСотрудник.EditFormShowing
        Dim view As GridView = TryCast(sender, GridView)

        If view Is Nothing Then
            Return
        End If

        'Me.GridViewСотрудник.OptionsEditForm.CustomEditFormLayout = New XtraUCPersonInfo(CType(view.GetRowCellValue(e.RowHandle, "код"), Integer))
        Me.GridViewСотрудник.OptionsEditForm.CustomEditFormLayout = New XtraUCPersonRecord()
    End Sub

#Region "Пользовательские функции и процедуры"
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()

        'Dim Persona = From tKS In db.GetTable(Of Кафедра_Сотрудник)()
        '              Order By
        '                  tKS.Сотрудник.Фамилия,
        '                  tKS.Сотрудник.Имя,
        '                  tKS.Сотрудник.Отчество
        '              Select
        '                  код = tKS.Сотрудник.КодСотрудник,
        '                  tKS.Сотрудник.Фамилия,
        '                  tKS.Сотрудник.Имя,
        '                  tKS.Сотрудник.Отчество,
        '                  Кафедра = tKS.Кафедра.Аббревиатура,
        '                  Факультет = tKS.Сотрудник.Факультет.Аббр_Факультет,
        '                  Степень = tKS.Сотрудник.Степень.Аббревиатура,
        '                  Должность = tKS.Сотрудник.Должность.Аббревиатура,
        '                  tKS.Сотрудник.Записал,
        '                  Дата_записи = CType(tKS.Сотрудник.датаЗаписал, DateTime?),
        '                  tKS.Сотрудник.Исправил,
        '                  Дата_исправления = CType(tKS.Сотрудник.датаИсправил, DateTime?),
        '                  tKS.Примечание

        Dim Persona = From tKS In db.p_GetListOfFullСотрудник() Order By tKS.Фамилия, tKS.Имя, tKS.Отчество

        Me.сотрудникBindingSource.DataSource = Persona

        Call GVSettings(Me.GridViewСотрудник)
        Return True
    End Function

    Private Sub GVSettings(ByVal view As GridView, Optional ByVal датаИсправил As String = "датаИсправил")
        view.BestFitColumns()
        view.OptionsView.ColumnAutoWidth = True
        'view.Columns("Дата_записи").Caption = "Дата записи"
        'view.Columns("Дата_записи").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        'view.Columns("Дата_исправления").Caption = "Дата исправления"
        'view.Columns("Дата_исправления").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        'view.Columns("код").Visible = False
        view.Columns("датаЗаписал").Caption = "Дата записи"
        view.Columns("датаЗаписал").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        view.Columns("датаИсправил").Caption = "Дата исправления"
        view.Columns(датаИсправил).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        view.Columns("КодСотрудник").Visible = False

        For Each column As GridColumn In view.Columns
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        view.OptionsView.RowAutoHeight = True
    End Sub
#End Region
End Class
