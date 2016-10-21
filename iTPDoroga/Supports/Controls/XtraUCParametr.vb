Imports System.Data.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCParametr
    Private newRow As Boolean = False

    Dim db As New DataClassesDorogaDataContext

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub XtraUCParametr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not DBConnect()) Then Return
    End Sub

    Private Sub GridViewMain_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridViewMain.CustomRowCellEdit
        If e.Column.FieldName = "Поле" Then
            Dim gv As GridView = CType(sender, GridView)
            Dim fieldName As String = gv.GetRowCellValue(e.RowHandle, gv.Columns("Поле")).ToString()

            Select Case (fieldName)
                Case "Поле"
                    e.RepositoryItem = Me.riLookUpEditField
            End Select

        End If
    End Sub

    'Private Sub GridViewMain_ColumnChanged(sender As Object, e As EventArgs) Handles GridViewMain.ColumnChanged
    '    Dim view As GridView = CType(sender, GridView)
    '    Dim fieldName As String = view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Поле")).ToString()

    '    Select Case (fieldName)
    '        Case "Поле"
    '            e.RepositoryItem = Me.riLookUpEditField
    '    End Select
    'End Sub

    'Private Sub GridViewMain_ShownEditor(sender As Object, e As EventArgs) Handles GridViewMain.ShownEditor
    '    Dim view As ColumnView = DirectCast(sender, ColumnView)

    '    If view.FocusedColumn.FieldName = "Поле" AndAlso TypeOf view.ActiveEditor Is LookUpEdit Then
    '        Dim edit As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
    '        Dim nameTab As String = CStr(view.GetFocusedRowCellValue("Таблица"))

    '        edit.Properties.DataSource = db.GetListFieldTable(nameTab).ToList()
    '        'CType(Me.GridViewMain, GridView).SetFocusedRowCellValue(CType(Me.GridViewMain, GridView).Columns("Поле"), Trim(CType(edit.EditValue, String)))
    '    End If
    'End Sub

    Private Sub riLookUpEditTable_EditValueChanged(sender As Object, e As EventArgs) Handles riLookUpEditTable.EditValueChanged
        CType(Me.GridViewMain, GridView).SetFocusedRowCellValue(CType(Me.GridViewMain, GridView).Columns("Таблица"), Trim(CType(CType(sender, LookUpEdit).EditValue, String)))

        Console.WriteLine(String.Format("riLookUpEditTable_EditValueChanged -> Trim(CType(CType(sender, LookUpEdit).EditValue, String)) = {0}", Trim(CType(CType(sender, LookUpEdit).EditValue, String))))

        Call riLookUpEditData(1, Trim(CType(CType(sender, LookUpEdit).EditValue, String)))
    End Sub

    Private Sub riLookUpEditField_EditValueChanged(sender As Object, e As EventArgs) Handles riLookUpEditField.EditValueChanged
        'CType(Me.GridViewMain, GridView).SetFocusedRowCellValue(CType(Me.GridViewMain, GridView).Columns("Поле"), Trim(CType(CType(sender, LookUpEdit).EditValue, String)))
    End Sub

    Private Sub riLookUpEditField_Closed(sender As Object, e As ClosedEventArgs) Handles riLookUpEditField.Closed
        'CType(Me.GridViewMain, GridView).SetFocusedRowCellValue(CType(Me.GridViewMain, GridView).Columns("Поле"), Trim(CType(CType(sender, LookUpEdit).EditValue, String)))
    End Sub

    Private Sub riTextEditName_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles riTextEditName.EditValueChanging
        CType(Me.GridViewParametr, GridView).SetFocusedRowCellValue(CType(Me.GridViewParametr, GridView).Columns("Наименование"), Trim(CType(CType(sender, TextEdit).EditValue, String)))
    End Sub

    Private Sub GridViewMain_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewMain.InitNewRow
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
        view.FocusedColumn = view.Columns("Таблица")
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

    Private Sub GridControlSettings_EmbeddedNavigator_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs) Handles GridControlSettings.EmbeddedNavigator.ButtonClick
        Dim view As ColumnView = CType(Me.GridControlSettings.FocusedView, ColumnView)

        'Console.WriteLine(String.Format("{0}", view.Name))
        Select Case e.Button.ButtonType
            Case NavigatorButtonType.EndEdit
                If view.UpdateCurrentRow() Then
                    Try
                        If newRow = False Then
                            'Select Case view.Name
                            '    Case "GridViewMain"
                            '    Case "GridViewParametr"
                            'End Select
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
                        XtraMessageBox.Show(String.Format("Ошибка при записи в БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex.Message),
                                       "Система: запись в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        For Each occ As ObjectChangeConflict In db.ChangeConflicts
                            occ.Resolve(RefreshMode.OverwriteCurrentValues)
                        Next
                    Catch ex As Exception
                        XtraMessageBox.Show(String.Format("Ошибка при записи в БД:{0}{0}{1}.",
                                         Global.Microsoft.VisualBasic.ChrW(10), ex.Message),
                                       "Система: запись в БД.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        If (Not DBConnect()) Then Return
                    End Try
                End If

                e.Handled = True
        End Select

    End Sub

#Region "Пользовательскте процедуры и функции"
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()
        ' This line of code is generated by Data Source Configuration Wizard
        'контролерBindingSource.DataSource = New iTPDoroga.DataClassesDorogaDataContext().Контролер

        Dim tbControler = From qTb In db.GetTable(Of Контролер)()

        Me.контролерBindingSource.DataSource = tbControler

        Call GVSettings(Me.GridViewMain)
        Call GVSettings(Me.GridViewParametr)

        Return True
    End Function

    Private Sub GVSettings(ByVal view As GridView)
        Select Case view.Name
            Case "GridViewMain"
                Call InitRILookUpEdit(Me.riLookUpEditTable)
                Call InitRILookUpEdit(Me.riLookUpEditField)
                Call riLookUpEditData(0)

                Console.WriteLine(String.Format("Trim(CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns(""Таблица"")), String)) = {0}", Trim(CType(view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Таблица")), String))))

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
                riLookUpEditTable.DataSource = Nothing
                riLookUpEditTable.DataSource = db.ListOfTables().ToList()
            Case 1
                ' Получение списка полей
                riLookUpEditField.DataSource = Nothing
                riLookUpEditField.DataSource = db.GetListFieldTable(nameTab).ToList()
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
#End Region
End Class
