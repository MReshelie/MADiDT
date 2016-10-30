Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraUCEditFormTable
    Inherits EditFormUserControl

    Dim db As New DataClassesDorogaDataContext

    Public Sub New()
        InitializeComponent()

        Call LookUpEditData(0)
        Call LookUpEditData(1, Trim(LookUpEditTable.Text))
    End Sub

    Private Sub LookUpEditTable_Closed(sender As Object, e As ClosedEventArgs) Handles LookUpEditTable.Closed
        Call LookUpEditData(1, Trim(LookUpEditTable.Text))
    End Sub

#Region "Пользовательские процедуры и функции"
    Private Sub LookUpEditData(ByVal i As Integer, Optional ByVal nameTab As String = Nothing)
        Select Case i
            Case 0
                ' Получение списка таблиц
                LookUpEditTable.Properties.DataSource = Nothing
                LookUpEditTable.Properties.DataSource = db.ListOfTables().ToList()
                LookUpEditTable.Properties.Columns.Add(New LookUpColumnInfo("row", "Номер в списке", 0))
                LookUpEditTable.Properties.Columns.Add(New LookUpColumnInfo("name", "Таблица в БД", 0))
                LookUpEditTable.Properties.DisplayMember = "name"
                LookUpEditTable.Properties.ValueMember = "name"
                LookUpEditTable.Properties.TextEditStyle = TextEditStyles.Standard
            Case 1
                ' Получение списка полей
                LookUpEditField.Properties.DataSource = Nothing
                LookUpEditField.Properties.DataSource = db.GetListFieldTable(nameTab).ToList()
                LookUpEditField.Properties.Columns.Add(New LookUpColumnInfo("row", "Позиция в таблице", 0))
                LookUpEditField.Properties.Columns.Add(New LookUpColumnInfo("name", "Имя поля", 0))
                LookUpEditField.Properties.DisplayMember = "name"
                LookUpEditField.Properties.ValueMember = "name"
                LookUpEditField.Properties.TextEditStyle = TextEditStyles.Standard
        End Select
    End Sub

    'Private Sub InitRILookUpEdit(ByVal riLUEF As LookUpEdit)
    '    Dim coll As LookUpColumnInfoCollection = riLUEF.Col

    '    Select Case riLUEF.Name
    '        Case "riLookUpEditTable"
    '            ' Поле Таблица
    '            coll.Add(New LookUpColumnInfo("row", "Номер в списке", 0))
    '            coll.Add(New LookUpColumnInfo("name", "Таблица в БД", 0))
    '        Case "riLookUpEditField"
    '            ' Поле Поле
    '            coll.Add(New LookUpColumnInfo("row", "Позиция в таблице", 0))
    '            coll.Add(New LookUpColumnInfo("name", "Имя поля", 0))
    '    End Select

    '    'riLUEF.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '    'riLUEF.BestFitMode = BestFitMode.BestFitResizePopup
    '    'riLUEF.SearchMode = SearchMode.AutoComplete
    '    'riLUEF.AutoSearchColumnIndex = 1
    '    riLUEF.ValueMembe = "name"
    '    riLUEF.DisplayMember = "name"
    'End Sub
#End Region
End Class
