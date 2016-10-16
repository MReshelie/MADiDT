<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCParametr
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.GridControlSettings = New DevExpress.XtraGrid.GridControl()
        Me.контролерBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewMain = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colкодКонтролер = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colТаблица = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.riLookUpEditTable = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colПоле = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.riLookUpEditField = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colДата_записи = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colЗаписал = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colДата_исправления = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colИсправил = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colПримечание = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.riMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.GridControlSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.контролерBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riLookUpEditTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riLookUpEditField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlSettings
        '
        Me.GridControlSettings.DataSource = Me.контролерBindingSource
        Me.GridControlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Параметр"
        Me.GridControlSettings.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControlSettings.Location = New System.Drawing.Point(0, 0)
        Me.GridControlSettings.MainView = Me.GridViewMain
        Me.GridControlSettings.Name = "GridControlSettings"
        Me.GridControlSettings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.riLookUpEditTable, Me.riLookUpEditField, Me.riMemoEdit})
        Me.GridControlSettings.Size = New System.Drawing.Size(806, 394)
        Me.GridControlSettings.TabIndex = 0
        Me.GridControlSettings.UseEmbeddedNavigator = True
        Me.GridControlSettings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMain})
        '
        'контролерBindingSource
        '
        Me.контролерBindingSource.DataSource = GetType(iTPDoroga.Контролер)
        '
        'GridViewMain
        '
        Me.GridViewMain.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colкодКонтролер, Me.colТаблица, Me.colПоле, Me.colДата_записи, Me.colЗаписал, Me.colДата_исправления, Me.colИсправил, Me.colПримечание})
        Me.GridViewMain.GridControl = Me.GridControlSettings
        Me.GridViewMain.Name = "GridViewMain"
        Me.GridViewMain.OptionsDetail.AllowExpandEmptyDetails = True
        '
        'colкодКонтролер
        '
        Me.colкодКонтролер.FieldName = "кодКонтролер"
        Me.colкодКонтролер.Name = "colкодКонтролер"
        Me.colкодКонтролер.Visible = True
        Me.colкодКонтролер.VisibleIndex = 0
        '
        'colТаблица
        '
        Me.colТаблица.ColumnEdit = Me.riLookUpEditTable
        Me.colТаблица.FieldName = "Таблица"
        Me.colТаблица.Name = "colТаблица"
        Me.colТаблица.Visible = True
        Me.colТаблица.VisibleIndex = 1
        '
        'riLookUpEditTable
        '
        Me.riLookUpEditTable.AutoHeight = False
        Me.riLookUpEditTable.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.riLookUpEditTable.Name = "riLookUpEditTable"
        '
        'colПоле
        '
        Me.colПоле.ColumnEdit = Me.riLookUpEditField
        Me.colПоле.FieldName = "Поле"
        Me.colПоле.Name = "colПоле"
        Me.colПоле.Visible = True
        Me.colПоле.VisibleIndex = 2
        '
        'riLookUpEditField
        '
        Me.riLookUpEditField.AutoHeight = False
        Me.riLookUpEditField.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.riLookUpEditField.Name = "riLookUpEditField"
        '
        'colДата_записи
        '
        Me.colДата_записи.FieldName = "Дата_записи"
        Me.colДата_записи.Name = "colДата_записи"
        Me.colДата_записи.Visible = True
        Me.colДата_записи.VisibleIndex = 3
        '
        'colЗаписал
        '
        Me.colЗаписал.FieldName = "Записал"
        Me.colЗаписал.Name = "colЗаписал"
        Me.colЗаписал.Visible = True
        Me.colЗаписал.VisibleIndex = 4
        '
        'colДата_исправления
        '
        Me.colДата_исправления.FieldName = "Дата_исправления"
        Me.colДата_исправления.Name = "colДата_исправления"
        Me.colДата_исправления.Visible = True
        Me.colДата_исправления.VisibleIndex = 5
        '
        'colИсправил
        '
        Me.colИсправил.FieldName = "Исправил"
        Me.colИсправил.Name = "colИсправил"
        Me.colИсправил.Visible = True
        Me.colИсправил.VisibleIndex = 6
        '
        'colПримечание
        '
        Me.colПримечание.AppearanceCell.Options.UseTextOptions = True
        Me.colПримечание.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colПримечание.ColumnEdit = Me.riMemoEdit
        Me.colПримечание.FieldName = "Примечание"
        Me.colПримечание.Name = "colПримечание"
        Me.colПримечание.Visible = True
        Me.colПримечание.VisibleIndex = 7
        '
        'riMemoEdit
        '
        Me.riMemoEdit.Name = "riMemoEdit"
        '
        'XtraUCParametr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControlSettings)
        Me.Name = "XtraUCParametr"
        Me.Size = New System.Drawing.Size(806, 394)
        CType(Me.GridControlSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.контролерBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riLookUpEditTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riLookUpEditField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlSettings As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMain As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents контролерBindingSource As BindingSource
    Friend WithEvents colкодКонтролер As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colТаблица As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colДата_записи As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colЗаписал As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colДата_исправления As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colИсправил As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colПримечание As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents riLookUpEditTable As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents riLookUpEditField As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents riMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents colПоле As DevExpress.XtraGrid.Columns.GridColumn
End Class
