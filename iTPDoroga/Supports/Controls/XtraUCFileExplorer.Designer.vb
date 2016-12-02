<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCFileExplorer
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
        Dim ContextButton1 As DevExpress.Utils.ContextButton = New DevExpress.Utils.ContextButton()
        Dim ContextButton2 As DevExpress.Utils.ContextButton = New DevExpress.Utils.ContextButton()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraUCFileExplorer))
        Dim CheckContextButton1 As DevExpress.Utils.CheckContextButton = New DevExpress.Utils.CheckContextButton()
        Dim RatingContextButton1 As DevExpress.Utils.RatingContextButton = New DevExpress.Utils.RatingContextButton()
        Dim BreadCrumbNode1 As DevExpress.XtraEditors.BreadCrumbNode = New DevExpress.XtraEditors.BreadCrumbNode()
        Dim BreadCrumbNode2 As DevExpress.XtraEditors.BreadCrumbNode = New DevExpress.XtraEditors.BreadCrumbNode()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControlФото = New DevExpress.XtraGrid.GridControl()
        Me.WinExplorerViewФото = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView()
        Me.breadCrumbEdit = New DevExpress.XtraEditors.BreadCrumbEdit()
        Me.sharedImageCollection = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControlФото, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinExplorerViewФото, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.breadCrumbEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sharedImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sharedImageCollection.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControlФото)
        Me.LayoutControl1.Controls.Add(Me.breadCrumbEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(650, 314)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControlФото
        '
        Me.GridControlФото.Location = New System.Drawing.Point(12, 38)
        Me.GridControlФото.MainView = Me.WinExplorerViewФото
        Me.GridControlФото.Name = "GridControlФото"
        Me.GridControlФото.Size = New System.Drawing.Size(626, 264)
        Me.GridControlФото.TabIndex = 5
        Me.GridControlФото.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.WinExplorerViewФото})
        '
        'WinExplorerViewФото
        '
        Me.WinExplorerViewФото.ContextButtonOptions.BottomPanelColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WinExplorerViewФото.ContextButtonOptions.BottomPanelPadding = New System.Windows.Forms.Padding(3)
        Me.WinExplorerViewФото.ContextButtonOptions.TopPanelColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.WinExplorerViewФото.ContextButtonOptions.TopPanelPadding = New System.Windows.Forms.Padding(3)
        ContextButton1.Alignment = DevExpress.Utils.ContextItemAlignment.MiddleTop
        ContextButton1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[True]
        ContextButton1.AppearanceNormal.ForeColor = System.Drawing.Color.Gainsboro
        ContextButton1.AppearanceNormal.Options.UseForeColor = True
        ContextButton1.Caption = "Персональное фото"
        ContextButton1.Id = New System.Guid("e6731505-a36d-4467-8c6b-13f1cff45c55")
        ContextButton1.Name = "ContextTileButton"
        ContextButton2.Alignment = DevExpress.Utils.ContextItemAlignment.TopFar
        ContextButton2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        ContextButton2.AppearanceNormal.ForeColor = System.Drawing.Color.Gainsboro
        ContextButton2.AppearanceNormal.Options.UseForeColor = True
        ContextButton2.Glyph = CType(resources.GetObject("ContextButton2.Glyph"), System.Drawing.Image)
        ContextButton2.Id = New System.Guid("afcc1d3b-cb9e-471f-9cf2-17a8f94bbf60")
        ContextButton2.Name = "ContextButton"
        CheckContextButton1.AppearanceNormal.ForeColor = System.Drawing.Color.Gainsboro
        CheckContextButton1.AppearanceNormal.Options.UseForeColor = True
        CheckContextButton1.HoverCheckedGlyph = CType(resources.GetObject("CheckContextButton1.HoverCheckedGlyph"), System.Drawing.Image)
        CheckContextButton1.Id = New System.Guid("3fb7b23e-c837-4571-bd66-5e0daaa592a6")
        CheckContextButton1.Name = "CheckContextButton"
        RatingContextButton1.Alignment = DevExpress.Utils.ContextItemAlignment.MiddleBottom
        RatingContextButton1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[True]
        RatingContextButton1.Id = New System.Guid("9a53d9a1-007e-4cfa-9d69-7f09efcc5fb2")
        RatingContextButton1.ItemCount = 1
        RatingContextButton1.Name = "RatingContextButton"
        RatingContextButton1.Rating = New Decimal(New Integer() {0, 0, 0, 0})
        RatingContextButton1.Visibility = DevExpress.Utils.ContextItemVisibility.Hidden
        Me.WinExplorerViewФото.ContextButtons.Add(ContextButton1)
        Me.WinExplorerViewФото.ContextButtons.Add(ContextButton2)
        Me.WinExplorerViewФото.ContextButtons.Add(CheckContextButton1)
        Me.WinExplorerViewФото.ContextButtons.Add(RatingContextButton1)
        Me.WinExplorerViewФото.GridControl = Me.GridControlФото
        Me.WinExplorerViewФото.Name = "WinExplorerViewФото"
        '
        'breadCrumbEdit
        '
        Me.breadCrumbEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.breadCrumbEdit.Location = New System.Drawing.Point(88, 12)
        Me.breadCrumbEdit.Name = "breadCrumbEdit"
        Me.breadCrumbEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.breadCrumbEdit.Properties.ImageIndex = 1
        Me.breadCrumbEdit.Properties.Images = Me.sharedImageCollection
        BreadCrumbNode1.Caption = "Root"
        BreadCrumbNode1.Persistent = True
        BreadCrumbNode1.PopulateOnDemand = True
        BreadCrumbNode1.ShowCaption = False
        BreadCrumbNode1.Value = "Root"
        BreadCrumbNode2.Caption = "Мой компьютер"
        BreadCrumbNode2.Persistent = True
        BreadCrumbNode2.PopulateOnDemand = True
        BreadCrumbNode2.Value = "Мой компьютер"
        Me.breadCrumbEdit.Properties.Nodes.AddRange(New DevExpress.XtraEditors.BreadCrumbNode() {BreadCrumbNode1, BreadCrumbNode2})
        Me.breadCrumbEdit.Properties.RootImageIndex = 1
        Me.breadCrumbEdit.Properties.SelectedNode = BreadCrumbNode2
        Me.breadCrumbEdit.Size = New System.Drawing.Size(550, 22)
        Me.breadCrumbEdit.StyleController = Me.LayoutControl1
        Me.breadCrumbEdit.TabIndex = 4
        '
        'sharedImageCollection
        '
        '
        '
        '
        Me.sharedImageCollection.ImageSource.ImageStream = CType(resources.GetObject("sharedImageCollection.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.sharedImageCollection.ImageSource.Images.SetKeyName(0, "loadfrom_16x16.png")
        Me.sharedImageCollection.ImageSource.Images.SetKeyName(1, "open_16x16.png")
        Me.sharedImageCollection.ParentControl = Me
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(650, 314)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.breadCrumbEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(630, 26)
        Me.LayoutControlItem1.Text = "Путь к файлу:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControlФото
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(630, 268)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'XtraUCFileExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "XtraUCFileExplorer"
        Me.Size = New System.Drawing.Size(650, 314)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControlФото, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinExplorerViewФото, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.breadCrumbEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sharedImageCollection.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sharedImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents breadCrumbEdit As DevExpress.XtraEditors.BreadCrumbEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private WithEvents sharedImageCollection As DevExpress.Utils.SharedImageCollection
    Friend WithEvents GridControlФото As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents WinExplorerViewФото As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
End Class
