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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.контролерBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colкодКонтролер = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colТаблица = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colИндекс_контролера = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colИмя_контролера = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colДата_записи = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colЗаписал = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colДата_исправления = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colИсправил = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colПримечание = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.контролерBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.контролерBindingSource
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(806, 394)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'контролерBindingSource
        '
        Me.контролерBindingSource.DataSource = GetType(iTPDoroga.Контролер)
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colкодКонтролер, Me.colТаблица, Me.colИндекс_контролера, Me.colИмя_контролера, Me.colДата_записи, Me.colЗаписал, Me.colДата_исправления, Me.colИсправил, Me.colПримечание})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsDetail.AllowExpandEmptyDetails = True
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
        Me.colТаблица.FieldName = "Таблица"
        Me.colТаблица.Name = "colТаблица"
        Me.colТаблица.Visible = True
        Me.colТаблица.VisibleIndex = 1
        '
        'colИндекс_контролера
        '
        Me.colИндекс_контролера.FieldName = "Индекс_контролера"
        Me.colИндекс_контролера.Name = "colИндекс_контролера"
        Me.colИндекс_контролера.Visible = True
        Me.colИндекс_контролера.VisibleIndex = 2
        '
        'colИмя_контролера
        '
        Me.colИмя_контролера.FieldName = "Имя_контролера"
        Me.colИмя_контролера.Name = "colИмя_контролера"
        Me.colИмя_контролера.Visible = True
        Me.colИмя_контролера.VisibleIndex = 3
        '
        'colДата_записи
        '
        Me.colДата_записи.FieldName = "Дата_записи"
        Me.colДата_записи.Name = "colДата_записи"
        Me.colДата_записи.Visible = True
        Me.colДата_записи.VisibleIndex = 4
        '
        'colЗаписал
        '
        Me.colЗаписал.FieldName = "Записал"
        Me.colЗаписал.Name = "colЗаписал"
        Me.colЗаписал.Visible = True
        Me.colЗаписал.VisibleIndex = 5
        '
        'colДата_исправления
        '
        Me.colДата_исправления.FieldName = "Дата_исправления"
        Me.colДата_исправления.Name = "colДата_исправления"
        Me.colДата_исправления.Visible = True
        Me.colДата_исправления.VisibleIndex = 6
        '
        'colИсправил
        '
        Me.colИсправил.FieldName = "Исправил"
        Me.colИсправил.Name = "colИсправил"
        Me.colИсправил.Visible = True
        Me.colИсправил.VisibleIndex = 7
        '
        'colПримечание
        '
        Me.colПримечание.FieldName = "Примечание"
        Me.colПримечание.Name = "colПримечание"
        Me.colПримечание.Visible = True
        Me.colПримечание.VisibleIndex = 8
        '
        'XtraUCParametr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "XtraUCParametr"
        Me.Size = New System.Drawing.Size(806, 394)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.контролерBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents контролерBindingSource As BindingSource
    Friend WithEvents colкодКонтролер As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colТаблица As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colИндекс_контролера As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colИмя_контролера As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colДата_записи As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colЗаписал As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colДата_исправления As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colИсправил As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colПримечание As DevExpress.XtraGrid.Columns.GridColumn
End Class
