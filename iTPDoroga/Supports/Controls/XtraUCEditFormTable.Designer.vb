<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCEditFormTable
    'Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.LookUpEditField = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit4 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LookUpEditTable = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.LookUpEditField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LookUpEditField
        '
        Me.SetBoundFieldName(Me.LookUpEditField, "Поле")
        Me.SetBoundPropertyName(Me.LookUpEditField, "EditValue")
        Me.LookUpEditField.Location = New System.Drawing.Point(296, 25)
        Me.LookUpEditField.Name = "LookUpEditField"
        Me.LookUpEditField.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditField.Size = New System.Drawing.Size(245, 20)
        Me.LookUpEditField.TabIndex = 2
        '
        'TextEdit1
        '
        Me.SetBoundFieldName(Me.TextEdit1, "Записал")
        Me.SetBoundPropertyName(Me.TextEdit1, "EditValue")
        Me.TextEdit1.Location = New System.Drawing.Point(567, 25)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(286, 20)
        Me.TextEdit1.TabIndex = 3
        '
        'TextEdit3
        '
        Me.SetBoundFieldName(Me.TextEdit3, "Исправил")
        Me.SetBoundPropertyName(Me.TextEdit3, "EditValue")
        Me.TextEdit3.Location = New System.Drawing.Point(567, 51)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Size = New System.Drawing.Size(286, 20)
        Me.TextEdit3.TabIndex = 5
        '
        'TextEdit4
        '
        Me.SetBoundFieldName(Me.TextEdit4, "Дата_исправления")
        Me.SetBoundPropertyName(Me.TextEdit4, "EditValue")
        Me.TextEdit4.EditValue = Nothing
        Me.TextEdit4.Location = New System.Drawing.Point(860, 51)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit4.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit4.Properties.DisplayFormat.FormatString = ""
        Me.TextEdit4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TextEdit4.Properties.EditFormat.FormatString = ""
        Me.TextEdit4.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TextEdit4.Properties.Mask.EditMask = ""
        Me.TextEdit4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TextEdit4.Size = New System.Drawing.Size(170, 20)
        Me.TextEdit4.TabIndex = 6
        '
        'TextEdit2
        '
        Me.SetBoundFieldName(Me.TextEdit2, "Дата_записи")
        Me.SetBoundPropertyName(Me.TextEdit2, "EditValue")
        Me.TextEdit2.EditValue = Nothing
        Me.TextEdit2.Location = New System.Drawing.Point(859, 25)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit2.Properties.DisplayFormat.FormatString = ""
        Me.TextEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TextEdit2.Properties.EditFormat.FormatString = ""
        Me.TextEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TextEdit2.Properties.Mask.EditMask = ""
        Me.TextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TextEdit2.Size = New System.Drawing.Size(171, 20)
        Me.TextEdit2.TabIndex = 4
        '
        'LabelControl1
        '
        Me.SetBoundPropertyName(Me.LabelControl1, "")
        Me.LabelControl1.Location = New System.Drawing.Point(25, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(92, 13)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Имя таблицы в БД"
        '
        'LabelControl2
        '
        Me.SetBoundPropertyName(Me.LabelControl2, "")
        Me.LabelControl2.Location = New System.Drawing.Point(296, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(123, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Список полей в таблице"
        '
        'LookUpEditTable
        '
        Me.SetBoundFieldName(Me.LookUpEditTable, "Таблица")
        Me.SetBoundPropertyName(Me.LookUpEditTable, "EditValue")
        Me.LookUpEditTable.Location = New System.Drawing.Point(25, 25)
        Me.LookUpEditTable.Name = "LookUpEditTable"
        Me.LookUpEditTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditTable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditTable.Size = New System.Drawing.Size(245, 20)
        Me.LookUpEditTable.TabIndex = 1
        '
        'XtraUCEditFormTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TextEdit3)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.LookUpEditField)
        Me.Controls.Add(Me.LookUpEditTable)
        Me.Controls.Add(Me.TextEdit4)
        Me.Controls.Add(Me.TextEdit2)
        Me.Name = "XtraUCEditFormTable"
        Me.Size = New System.Drawing.Size(1053, 79)
        CType(Me.LookUpEditField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LookUpEditField As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LookUpEditTable As DevExpress.XtraEditors.LookUpEdit
End Class
