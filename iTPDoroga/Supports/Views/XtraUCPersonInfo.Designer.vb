<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraUCPersonInfo
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.GridControlPersonRecord = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPersonInfo = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridControlPersonRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPersonInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlPersonRecord
        '
        Me.GridControlPersonRecord.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GridControlPersonRecord.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControlPersonRecord.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPersonRecord.MainView = Me.GridViewPersonInfo
        Me.GridControlPersonRecord.Name = "GridControlPersonRecord"
        Me.GridControlPersonRecord.Size = New System.Drawing.Size(689, 236)
        Me.GridControlPersonRecord.TabIndex = 0
        Me.GridControlPersonRecord.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPersonInfo})
        '
        'GridViewPersonInfo
        '
        Me.GridViewPersonInfo.GridControl = Me.GridControlPersonRecord
        Me.GridViewPersonInfo.Name = "GridViewPersonInfo"
        Me.GridViewPersonInfo.OptionsDetail.AllowExpandEmptyDetails = True
        '
        'XtraUCPersonInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControlPersonRecord)
        Me.Name = "XtraUCPersonInfo"
        Me.Size = New System.Drawing.Size(689, 236)
        CType(Me.GridControlPersonRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPersonInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlPersonRecord As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPersonInfo As DevExpress.XtraGrid.Views.Grid.GridView
End Class
