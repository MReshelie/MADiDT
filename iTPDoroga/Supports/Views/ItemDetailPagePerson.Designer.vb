﻿Partial Public Class ItemDetailPagePerson
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
        Me.XtraUCParametr1 = New iTPDoroga.XtraUCParametr()
        Me.XtraUCPerson1 = New iTPDoroga.XtraUCPerson()
        Me.imageControl = New DevExpress.XtraEditors.PictureEdit()
        Me.labelSubtitle = New DevExpress.XtraEditors.LabelControl()
        Me.labelTitle = New DevExpress.XtraEditors.LabelControl()
        Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.winLayoutControl1.SuspendLayout()
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'winLayoutControl1
        '
        Me.winLayoutControl1.Controls.Add(Me.XtraUCParametr1)
        Me.winLayoutControl1.Controls.Add(Me.XtraUCPerson1)
        Me.winLayoutControl1.Controls.Add(Me.imageControl)
        Me.winLayoutControl1.Controls.Add(Me.labelSubtitle)
        Me.winLayoutControl1.Controls.Add(Me.labelTitle)
        Me.winLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.winLayoutControl1.Location = New System.Drawing.Point(50, 0)
        Me.winLayoutControl1.Name = "winLayoutControl1"
        Me.winLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1972, 239, 450, 350)
        Me.winLayoutControl1.Root = Me.layoutControlGroup1
        Me.winLayoutControl1.Size = New System.Drawing.Size(1140, 781)
        Me.winLayoutControl1.TabIndex = 0
        Me.winLayoutControl1.Text = "winLayoutControl1"
        '
        'XtraUCParametr1
        '
        Me.XtraUCParametr1.Location = New System.Drawing.Point(376, 351)
        Me.XtraUCParametr1.Name = "XtraUCParametr1"
        Me.XtraUCParametr1.Size = New System.Drawing.Size(752, 418)
        Me.XtraUCParametr1.TabIndex = 9
        '
        'XtraUCPerson1
        '
        Me.XtraUCPerson1.Location = New System.Drawing.Point(376, 12)
        Me.XtraUCPerson1.Name = "XtraUCPerson1"
        Me.XtraUCPerson1.Size = New System.Drawing.Size(752, 335)
        Me.XtraUCPerson1.TabIndex = 8
        '
        'imageControl
        '
        Me.imageControl.Location = New System.Drawing.Point(12, 153)
        Me.imageControl.Name = "imageControl"
        Me.imageControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.imageControl.Size = New System.Drawing.Size(310, 255)
        Me.imageControl.StyleController = Me.winLayoutControl1
        Me.imageControl.TabIndex = 7
        '
        'labelSubtitle
        '
        Me.labelSubtitle.AllowHtmlString = True
        Me.labelSubtitle.Appearance.Font = New System.Drawing.Font("Segoe WP", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelSubtitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.labelSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.labelSubtitle.Location = New System.Drawing.Point(12, 46)
        Me.labelSubtitle.Name = "labelSubtitle"
        Me.labelSubtitle.Size = New System.Drawing.Size(310, 103)
        Me.labelSubtitle.StyleController = Me.winLayoutControl1
        Me.labelSubtitle.TabIndex = 5
        Me.labelSubtitle.Text = "labelControl2"
        '
        'labelTitle
        '
        Me.labelTitle.AllowHtmlString = True
        Me.labelTitle.Appearance.Font = New System.Drawing.Font("Segoe WP", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.labelTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.labelTitle.Location = New System.Drawing.Point(12, 12)
        Me.labelTitle.Name = "labelTitle"
        Me.labelTitle.Size = New System.Drawing.Size(310, 30)
        Me.labelTitle.StyleController = Me.winLayoutControl1
        Me.labelTitle.TabIndex = 4
        Me.labelTitle.Text = "labelControl1"
        '
        'layoutControlGroup1
        '
        Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
        Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutControlGroup1.GroupBordersVisible = False
        Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem2, Me.layoutControlItem1, Me.layoutControlItem4, Me.emptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlGroup1.Name = "Root"
        Me.layoutControlGroup1.Size = New System.Drawing.Size(1140, 781)
        Me.layoutControlGroup1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.labelSubtitle
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 34)
        Me.layoutControlItem2.MaxSize = New System.Drawing.Size(314, 107)
        Me.layoutControlItem2.MinSize = New System.Drawing.Size(314, 107)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(314, 107)
        Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.labelTitle
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Size = New System.Drawing.Size(314, 34)
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.imageControl
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(0, 141)
        Me.layoutControlItem4.MaxSize = New System.Drawing.Size(314, 259)
        Me.layoutControlItem4.MinSize = New System.Drawing.Size(314, 259)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(314, 620)
        Me.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(314, 0)
        Me.emptySpaceItem1.MaxSize = New System.Drawing.Size(50, 403)
        Me.emptySpaceItem1.MinSize = New System.Drawing.Size(50, 403)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(50, 761)
        Me.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.XtraUCPerson1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(364, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(756, 339)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.XtraUCParametr1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(364, 339)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(756, 422)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'ItemDetailPagePerson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.winLayoutControl1)
        Me.Name = "ItemDetailPagePerson"
        Me.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.Size = New System.Drawing.Size(1240, 781)
        CType(Me.winLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.winLayoutControl1.ResumeLayout(False)
        CType(Me.imageControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private winLayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Private imageControl As DevExpress.XtraEditors.PictureEdit
    Private labelSubtitle As DevExpress.XtraEditors.LabelControl
    Private labelTitle As DevExpress.XtraEditors.LabelControl
    Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Private emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents XtraUCPerson1 As XtraUCPerson
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraUCParametr1 As XtraUCParametr
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
