Partial Public Class GroupItemDetailPage
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.winLayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.labelDescription = New DevExpress.XtraEditors.LabelControl()
        Me.labelSubtitle = New DevExpress.XtraEditors.LabelControl()
        Me.labelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.imageControl = New DevExpress.XtraEditors.PictureEdit()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.winLayoutControl1.SuspendLayout()
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'winLayoutControl1
        '
        Me.winLayoutControl1.Controls.Add(Me.labelDescription)
        Me.winLayoutControl1.Controls.Add(Me.labelSubtitle)
        Me.winLayoutControl1.Controls.Add(Me.labelTitle)
        Me.winLayoutControl1.Controls.Add(Me.imageControl)
        Me.winLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.winLayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.winLayoutControl1.Name = "winLayoutControl1"
        Me.winLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1004, 159, 450, 350)
        Me.winLayoutControl1.Root = Me.layoutControlGroup1
        Me.winLayoutControl1.Size = New System.Drawing.Size(716, 178)
        Me.winLayoutControl1.TabIndex = 0
        Me.winLayoutControl1.Text = "winLayoutControl1"
        '
        'labelDescription
        '
        Me.labelDescription.Appearance.Font = New System.Drawing.Font("Segoe WP", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.labelDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.labelDescription.Location = New System.Drawing.Point(168, 68)
        Me.labelDescription.Name = "labelDescription"
        Me.labelDescription.Size = New System.Drawing.Size(536, 98)
        Me.labelDescription.StyleController = Me.winLayoutControl1
        Me.labelDescription.TabIndex = 7
        Me.labelDescription.Text = "labelControl3"
        '
        'labelSubtitle
        '
        Me.labelSubtitle.Appearance.Font = New System.Drawing.Font("Segoe WP", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelSubtitle.Location = New System.Drawing.Point(168, 39)
        Me.labelSubtitle.Name = "labelSubtitle"
        Me.labelSubtitle.Size = New System.Drawing.Size(536, 25)
        Me.labelSubtitle.StyleController = Me.winLayoutControl1
        Me.labelSubtitle.TabIndex = 6
        Me.labelSubtitle.Text = "labelControl2"
        '
        'labelTitle
        '
        Me.labelTitle.Appearance.Font = New System.Drawing.Font("Segoe WP", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelTitle.Location = New System.Drawing.Point(168, 12)
        Me.labelTitle.Name = "labelTitle"
        Me.labelTitle.Size = New System.Drawing.Size(536, 23)
        Me.labelTitle.StyleController = Me.winLayoutControl1
        Me.labelTitle.TabIndex = 5
        Me.labelTitle.Text = "labelControl1"
        '
        'imageControl
        '
        Me.imageControl.Location = New System.Drawing.Point(12, 12)
        Me.imageControl.Name = "imageControl"
        Me.imageControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.imageControl.Size = New System.Drawing.Size(152, 122)
        Me.imageControl.StyleController = Me.winLayoutControl1
        Me.imageControl.TabIndex = 4
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.layoutControlItem4, Me.emptySpaceItem1})
        Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlGroup1.Name = "layoutControlGroup1"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(716, 178)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.imageControl
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem1.MaxSize = New System.Drawing.Size(156, 126)
        Me.layoutControlItem1.MinSize = New System.Drawing.Size(156, 126)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Size = New System.Drawing.Size(156, 126)
        Me.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.labelTitle
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(156, 0)
        Me.layoutControlItem2.MinSize = New System.Drawing.Size(98, 25)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(540, 27)
        Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.labelSubtitle
        Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem3.Location = New System.Drawing.Point(156, 27)
        Me.layoutControlItem3.MinSize = New System.Drawing.Size(82, 21)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Size = New System.Drawing.Size(540, 29)
        Me.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem3.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.labelDescription
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(156, 56)
        Me.layoutControlItem4.MinSize = New System.Drawing.Size(19, 25)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(540, 102)
        Me.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 126)
        Me.emptySpaceItem1.MinSize = New System.Drawing.Size(104, 24)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(156, 32)
        Me.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'GroupItemDetailPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.winLayoutControl1)
        Me.Name = "GroupItemDetailPage"
        Me.Size = New System.Drawing.Size(716, 178)
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.winLayoutControl1.ResumeLayout(False)
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private winLayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private labelDescription As DevExpress.XtraEditors.LabelControl
    Private labelSubtitle As DevExpress.XtraEditors.LabelControl
    Private labelTitle As DevExpress.XtraEditors.LabelControl
    Private WithEvents imageControl As DevExpress.XtraEditors.PictureEdit
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
