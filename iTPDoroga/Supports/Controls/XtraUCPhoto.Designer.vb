<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCPhoto
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
        Dim ContextButton1 As DevExpress.Utils.ContextButton = New DevExpress.Utils.ContextButton()
        Dim ContextButton2 As DevExpress.Utils.ContextButton = New DevExpress.Utils.ContextButton()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraUCPhoto))
        Me.GridControlPhoto = New DevExpress.XtraGrid.GridControl()
        Me.WinExplorerViewPhoto = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        CType(Me.GridControlPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerViewPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlPhoto
        '
        Me.GridControlPhoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPhoto.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPhoto.MainView = Me.WinExplorerViewPhoto
        Me.GridControlPhoto.Name = "GridControlPhoto"
        Me.GridControlPhoto.Size = New System.Drawing.Size(685, 404)
        Me.GridControlPhoto.TabIndex = 0
        Me.GridControlPhoto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.WinExplorerViewPhoto})
        '
        'WinExplorerViewPhoto
        '
        Me.WinExplorerViewPhoto.ContextButtonOptions.BottomPanelColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WinExplorerViewPhoto.ContextButtonOptions.BottomPanelPadding = New System.Windows.Forms.Padding(3)
        Me.WinExplorerViewPhoto.ContextButtonOptions.TopPanelColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WinExplorerViewPhoto.ContextButtonOptions.TopPanelPadding = New System.Windows.Forms.Padding(3)
        ContextButton1.Alignment = DevExpress.Utils.ContextItemAlignment.MiddleTop
        ContextButton1.AnimationType = DevExpress.Utils.ContextAnimationType.OpacityAnimation
        ContextButton1.Caption = "Файл"
        ContextButton1.Id = New System.Guid("cdccc92c-502c-4635-bc9e-d6b6f91bd3e4")
        ContextButton1.Name = "contextTitleButton"
        ContextButton2.Alignment = DevExpress.Utils.ContextItemAlignment.TopFar
        ContextButton2.Glyph = CType(resources.GetObject("ContextButton2.Glyph"), System.Drawing.Image)
        ContextButton2.Id = New System.Guid("c959f404-6be9-4c91-a3c8-29efcf624e98")
        ContextButton2.Name = "ContextButton"
        Me.WinExplorerViewPhoto.ContextButtons.Add(ContextButton1)
        Me.WinExplorerViewPhoto.ContextButtons.Add(ContextButton2)
        Me.WinExplorerViewPhoto.GridControl = Me.GridControlPhoto
        Me.WinExplorerViewPhoto.Name = "WinExplorerViewPhoto"
        '
        'XtraUCPhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControlPhoto)
        Me.Name = "XtraUCPhoto"
        Me.Size = New System.Drawing.Size(685, 404)
        CType(Me.GridControlPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerViewPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlPhoto As DevExpress.XtraGrid.GridControl
    Friend WithEvents WinExplorerViewPhoto As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
End Class
