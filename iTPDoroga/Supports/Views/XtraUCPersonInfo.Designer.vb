<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCPersonInfo
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
        Me.GridControlPersonRecord = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPersonInfo = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridControlPersonRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPersonInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlPersonRecord
        '
        'Me.SetBoundPropertyName(Me.GridControlPersonRecord, "")
        Me.GridControlPersonRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPersonRecord.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPersonRecord.MainView = Me.GridViewPersonInfo
        Me.GridControlPersonRecord.Name = "GridControlPersonRecord"
        Me.GridControlPersonRecord.Size = New System.Drawing.Size(997, 423)
        Me.GridControlPersonRecord.TabIndex = 0
        Me.GridControlPersonRecord.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPersonInfo})
        '
        'GridViewPersonInfo
        '
        Me.GridViewPersonInfo.GridControl = Me.GridControlPersonRecord
        Me.GridViewPersonInfo.Name = "GridViewPersonInfo"
        '
        'XtraUCPersonInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControlPersonRecord)
        Me.Name = "XtraUCPersonInfo"
        Me.Size = New System.Drawing.Size(997, 423)
        CType(Me.GridControlPersonRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPersonInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlPersonRecord As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPersonInfo As DevExpress.XtraGrid.Views.Grid.GridView
End Class
