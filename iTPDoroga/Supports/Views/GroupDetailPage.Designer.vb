Partial Public Class GroupDetailPage
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
        Me.imageControl = New DevExpress.XtraEditors.PictureEdit()
        Me.labelSubtitle = New DevExpress.XtraEditors.LabelControl()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.winLayoutControl1.SuspendLayout()
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'winLayoutControl1
        '
        Me.winLayoutControl1.Controls.Add(Me.labelDescription)
        Me.winLayoutControl1.Controls.Add(Me.imageControl)
        Me.winLayoutControl1.Controls.Add(Me.labelSubtitle)
        Me.winLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.winLayoutControl1.Location = New System.Drawing.Point(50, 0)
        Me.winLayoutControl1.Name = "winLayoutControl1"
        Me.winLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(704, 250, 803, 350)
        Me.winLayoutControl1.Root = Me.layoutControlGroup1
        Me.winLayoutControl1.Size = New System.Drawing.Size(727, 552)
        Me.winLayoutControl1.TabIndex = 0
        Me.winLayoutControl1.Text = "winLayoutControl1"
        '
        'labelDescription
        '
        Me.labelDescription.Appearance.Font = New System.Drawing.Font("Segoe WP", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.labelDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.labelDescription.Location = New System.Drawing.Point(12, 365)
        Me.labelDescription.Name = "labelDescription"
        Me.labelDescription.Size = New System.Drawing.Size(413, 146)
        Me.labelDescription.TabIndex = 6
        Me.labelDescription.Text = "labelControl2"
        '
        'imageControl
        '
        Me.imageControl.Location = New System.Drawing.Point(12, 57)
        Me.imageControl.Name = "imageControl"
        Me.imageControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.imageControl.Size = New System.Drawing.Size(413, 304)
        Me.imageControl.StyleController = Me.winLayoutControl1
        Me.imageControl.TabIndex = 5
        '
        'labelSubtitle
        '
        Me.labelSubtitle.Appearance.Font = New System.Drawing.Font("Segoe WP", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.labelSubtitle.Location = New System.Drawing.Point(12, 12)
        Me.labelSubtitle.Name = "labelSubtitle"
        Me.labelSubtitle.Size = New System.Drawing.Size(413, 41)
        Me.labelSubtitle.TabIndex = 4
        Me.labelSubtitle.Text = "labelControl1"
        Me.labelSubtitle.UseMnemonic = False
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.layoutControlGroup2, Me.emptySpaceItem1, Me.emptySpaceItem2})
        Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(727, 552)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.labelSubtitle
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem1.MaxSize = New System.Drawing.Size(417, 45)
        Me.layoutControlItem1.MinSize = New System.Drawing.Size(417, 45)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Size = New System.Drawing.Size(417, 45)
        Me.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.imageControl
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 45)
        Me.layoutControlItem2.MaxSize = New System.Drawing.Size(417, 308)
        Me.layoutControlItem2.MinSize = New System.Drawing.Size(417, 308)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(417, 308)
        Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.labelDescription
        Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem3.Location = New System.Drawing.Point(0, 353)
        Me.layoutControlItem3.MaxSize = New System.Drawing.Size(417, 150)
        Me.layoutControlItem3.MinSize = New System.Drawing.Size(417, 150)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Size = New System.Drawing.Size(417, 150)
        Me.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem3.TextVisible = False
        '
        'layoutControlGroup2
        '
        Me.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2"
        Me.layoutControlGroup2.Location = New System.Drawing.Point(467, 0)
        Me.layoutControlGroup2.Name = "layoutControlGroup2"
        Me.layoutControlGroup2.Size = New System.Drawing.Size(240, 532)
        Me.layoutControlGroup2.TextVisible = False
        '
        'emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(0, 503)
        Me.emptySpaceItem1.MinSize = New System.Drawing.Size(104, 24)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(417, 29)
        Me.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem2.Location = New System.Drawing.Point(417, 0)
        Me.emptySpaceItem2.MaxSize = New System.Drawing.Size(50, 532)
        Me.emptySpaceItem2.MinSize = New System.Drawing.Size(50, 532)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(50, 532)
        Me.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'GroupDetailPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.winLayoutControl1)
        Me.Name = "GroupDetailPage"
        Me.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.Size = New System.Drawing.Size(827, 552)
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.winLayoutControl1.ResumeLayout(False)
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private winLayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private labelDescription As DevExpress.XtraEditors.LabelControl
    Private imageControl As DevExpress.XtraEditors.PictureEdit
    Private labelSubtitle As DevExpress.XtraEditors.LabelControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Private emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
