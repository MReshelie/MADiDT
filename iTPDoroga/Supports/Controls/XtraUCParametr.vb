Imports System.Data.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCParametr
    Private newRow As Boolean = False
    Private tabLookUpEdit As LookUpEdit
    Private fldLookUpEdit As LookUpEdit

    Dim db As New DataClassesDorogaDataContext

    Public Sub New()
        InitializeComponent()

        Me.GridViewSettings.OptionsEditForm.CustomEditFormLayout = New XtraUCEditFormTable()
    End Sub

    Private Sub XtraUCParametr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not DBConnect()) Then Return
    End Sub

    Private Sub GridViewSettings_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridViewSettings.CustomRowCellEdit
        If e.Column.FieldName = "Поле" Then
            Dim gv As GridView = CType(sender, GridView)
            Dim fieldName As String = gv.GetRowCellValue(e.RowHandle, gv.Columns("Поле")).ToString()

            Select Case (fieldName)
                Case "Поле"
                    e.RepositoryItem = Me.riLookUpEditField
            End Select

        End If
    End Sub

    Private Sub GridViewSettings_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewSettings.InitNewRow
        '
    End Sub

    Private Sub GridViewSettings_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridViewSettings.EditFormPrepared
        If e.BindableControls(Me.GridViewSettings.FocusedColumn) IsNot Nothing Then
            e.FocusField(Me.GridViewSettings.FocusedColumn)
            tabLookUpEdit = TryCast(e.BindableControls("Таблица"), LookUpEdit)
            fldLookUpEdit = TryCast(e.BindableControls("Поле"), LookUpEdit)

            If tabLookUpEdit IsNot Nothing Then
                fldLookUpEdit.Properties.DataSource = Nothing
                fldLookUpEdit.Properties.DataSource = db.GetListFieldTable(Trim(tabLookUpEdit.Text)).ToList()
            End If
        End If
    End Sub

    Private Sub GridControlSettings_EmbeddedNavigator_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs) Handles GridControlSettings.EmbeddedNavigator.ButtonClick
        Dim view As ColumnView = CType(Me.GridControlSettings.FocusedView, ColumnView)

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

                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Дата_исправления"), Date.Today)
                        End If

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
            Case NavigatorButtonType.Remove
                If XtraMessageBox.Show(String.Format("Таблица: [{0}]{1}{1}Удалить текущую запись ?", SourceName(view.Name), Global.Microsoft.VisualBasic.ChrW(10)),
                                           "Система: запись данных в БД.", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Select Case view.Name
                        Case "GridViewSettings"
                            If DeleteRec(view.Name, view.GetRowCellValue(view.FocusedRowHandle, view.Columns.ColumnByFieldName("кодКонтролер"))) Then
                                Me.GridControlSettings.RefreshDataSource()
                            End If
                        Case "GridViewParametr"
                            If DeleteRec(view.Name, view.GetRowCellValue(view.FocusedRowHandle, view.Columns.ColumnByFieldName("кодПараметра"))) Then
                                Me.GridControlSettings.RefreshDataSource()
                            End If
                    End Select
                    e.Handled = True
                Else
                    e.Handled = True
                End If
        End Select

    End Sub

    Private Sub GridViewParametr_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewParametr.InitNewRow
        Dim view As GridView = CType(sender, GridView)

        ' Начальные значения Новая запись
        newRow = True
        view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Дата_записи"), Date.Today)

        If pUserF = "Администратор системы" Then
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0}, [{1}]", Trim(pUserF), Trim(pUserS)))
        Else
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns("Записал"), String.Format("{0} {1}.", Trim(pUserF), Mid(Trim(pUserS), 1, 1)))
        End If

        view.Columns("Записал").OptionsColumn.ReadOnly = True
        view.Columns("Дата_записи").OptionsColumn.ReadOnly = True
        view.Columns("Исправил").OptionsColumn.ReadOnly = True
        view.Columns("Дата_исправления").OptionsColumn.ReadOnly = True
        view.FocusedColumn = view.Columns("Наименование")
    End Sub

    Private Sub riLookUpEditTable_EditValueChanged(sender As Object, e As EventArgs) Handles riLookUpEditTable.EditValueChanged
        CType(Me.GridViewSettings, GridView).SetFocusedRowCellValue(CType(Me.GridViewSettings, GridView).Columns("Таблица"), Trim(CType(CType(sender, LookUpEdit).EditValue, String)))

        Call riLookUpEditData(1, Trim(CType(CType(sender, LookUpEdit).EditValue, String)))
    End Sub

    Private Sub riTextEditName_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles riTextEditName.EditValueChanging
        CType(Me.GridViewParametr, GridView).SetFocusedRowCellValue(CType(Me.GridViewParametr, GridView).Columns("Наименование"), Trim(CType(CType(sender, TextEdit).EditValue, String)))
    End Sub

#Region "Пользовательскте процедуры и функции"
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()
        ' This line of code is generated by Data Source Configuration Wizard
        'контролерBindingSource.DataSource = New iTPDoroga.DataClassesDorogaDataContext().Контролер

        Dim tbControler = From qTb In db.GetTable(Of Контролер)()

        Me.контролерBindingSource.DataSource = tbControler

        Call GVSettings(Me.GridViewSettings)
        Call GVSettings(Me.GridViewParametr)

        Return True
    End Function

    Private Sub GVSettings(ByVal view As GridView)
        Select Case view.Name
            Case "GridViewSettings"
                Call InitRILookUpEdit(Me.riLookUpEditTable)
                Call InitRILookUpEdit(Me.riLookUpEditField)
                Call riLookUpEditData(0)

                If Not IsNothing(Trim(CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Таблица")), String))) Then
                    Call riLookUpEditData(1, Trim(CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Таблица")), String)))
                End If

                view.Columns("Поле").Caption = "Список полей"
                view.Columns("Дата_записи").Caption = "Дата записи"
                view.Columns("Дата_записи").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("Дата_исправления").Caption = "Дата исправления"
                view.Columns("Дата_исправления").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                riMemoEdit.WordWrap = True
                view.Columns("кодКонтролер").Visible = False

                For Each column As GridColumn In view.Columns
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Next

                view.BestFitColumns()
                view.OptionsView.ColumnAutoWidth = True
                view.OptionsView.RowAutoHeight = True
            Case "GridViewParametr"
                view.Columns("Наименование").Caption = "Наименование параметра"
                view.Columns("Дата_записи").Caption = "Дата записи"
                view.Columns("Дата_записи").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                view.Columns("Дата_исправления").Caption = "Дата исправления"
                view.Columns("Дата_исправления").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                riMemoEdit.WordWrap = True
                view.Columns("кодПараметра").Visible = False
                view.Columns("кодКонтролер").Visible = False

                For Each column As GridColumn In view.Columns
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Next

                view.BestFitColumns()
                view.OptionsView.ColumnAutoWidth = True
                view.OptionsView.RowAutoHeight = True
        End Select
    End Sub

    Private Sub riLookUpEditData(ByVal i As Integer, Optional ByVal nameTab As String = Nothing)
        Select Case i
            Case 0
                ' Получение списка таблиц
                Me.riLookUpEditTable.DataSource = Nothing
                Me.riLookUpEditTable.DataSource = db.ListOfTables().ToList()
            Case 1
                ' Получение списка полей
                Me.riLookUpEditField.DataSource = Nothing
                Me.riLookUpEditField.DataSource = db.GetListFieldTable(nameTab).ToList()
        End Select
    End Sub

    Private Sub InitRILookUpEdit(ByVal riLUEF As RepositoryItemLookUpEdit)
        Dim coll As LookUpColumnInfoCollection = riLUEF.Columns

        Select Case riLUEF.Name
            Case "riLookUpEditTable"
                ' Поле Таблица
                coll.Add(New LookUpColumnInfo("row", "Номер в списке", 0))
                coll.Add(New LookUpColumnInfo("name", "Таблица в БД", 0))
            Case "riLookUpEditField"
                ' Поле Поле
                coll.Add(New LookUpColumnInfo("row", "Позиция в таблице", 0))
                coll.Add(New LookUpColumnInfo("name", "Имя поля", 0))
        End Select

        riLUEF.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        riLUEF.BestFitMode = BestFitMode.BestFitResizePopup
        riLUEF.SearchMode = SearchMode.AutoComplete
        riLUEF.AutoSearchColumnIndex = 1
        riLUEF.ValueMember = "name"
        riLUEF.DisplayMember = "name"
    End Sub

    Private Function DeleteRec(ByVal _viewName As String, _intRec As Integer) As Boolean
        Select Case _viewName
            Case "GridViewSettings"
                Dim delRec As Контролер = (From p In db.Контролер Where p.кодКонтролер = _intRec Select p).FirstOrDefault()

                Try
                    If delRec IsNot Nothing Then
                        db.Контролер.DeleteOnSubmit(delRec)
                    End If

                    db.SubmitChanges()
                    Return True
                Catch ex As Exception
                    XtraMessageBox.Show(String.Format("Таблица: {0}{1}Попытка удаления записи из БД:{1}Ошибка: {2}{0}Повторить попытку - [ОК].", SourceName(_viewName),
                                                          Global.Microsoft.VisualBasic.ChrW(10), ex.Message), "Система: запись данных в БД.",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Return False
                End Try
            Case "GridViewParametr"
                Dim delRec As Параметр = (From p In db.Параметр Where p.кодПараметра = _intRec Select p).FirstOrDefault()

                Try
                    If delRec IsNot Nothing Then
                        db.Параметр.DeleteOnSubmit(delRec)
                    End If

                    db.SubmitChanges()
                    Return True
                Catch ex As Exception
                    XtraMessageBox.Show(String.Format("Таблица: {0}{1}Попытка удаления записи из БД:{1}Ошибка: {2}{0}Повторить попытку - [ОК].", SourceName(_viewName),
                                                          Global.Microsoft.VisualBasic.ChrW(10), ex.Message), "Система: запись данных в БД.",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Return False
                End Try

        End Select
    End Function
#End Region
End Class
