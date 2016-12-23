<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUCLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraUCLogin))
        Me.StyleControllerLogin = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ImageSliderPerson = New DevExpress.XtraEditors.Controls.ImageSlider()
        Me.TextEditPassword = New DevExpress.XtraEditors.TextEdit()
        Me.ComboBoxEditPerson = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ImageCollectionSlider = New DevExpress.Utils.ImageCollection(Me.components)
        Me.TimerSlider = New System.Windows.Forms.Timer(Me.components)
        CType(Me.StyleControllerLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ImageSliderPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEditPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollectionSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleControllerLogin
        '
        Me.StyleControllerLogin.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.StyleControllerLogin.Appearance.Options.UseFont = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ImageSliderPerson)
        Me.LayoutControl1.Controls.Add(Me.TextEditPassword)
        Me.LayoutControl1.Controls.Add(Me.ComboBoxEditPerson)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(2265, 439, 716, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(941, 237)
        Me.LayoutControl1.StyleController = Me.StyleControllerLogin
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ImageSliderPerson
        '
        Me.ImageSliderPerson.CurrentImageIndex = -1
        Me.ImageSliderPerson.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch
        Me.ImageSliderPerson.Location = New System.Drawing.Point(12, 41)
        Me.ImageSliderPerson.Name = "ImageSliderPerson"
        Me.ImageSliderPerson.Size = New System.Drawing.Size(196, 184)
        Me.ImageSliderPerson.StyleController = Me.LayoutControl1
        Me.ImageSliderPerson.TabIndex = 7
        Me.ImageSliderPerson.Text = "ImageSliderPerson"
        Me.ImageSliderPerson.UseDisabledStatePainter = True
        '
        'TextEditPassword
        '
        Me.TextEditPassword.Location = New System.Drawing.Point(377, 141)
        Me.TextEditPassword.Name = "TextEditPassword"
        Me.TextEditPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextEditPassword.Size = New System.Drawing.Size(552, 32)
        Me.TextEditPassword.StyleController = Me.LayoutControl1
        Me.TextEditPassword.TabIndex = 6
        '
        'ComboBoxEditPerson
        '
        Me.ComboBoxEditPerson.Location = New System.Drawing.Point(377, 84)
        Me.ComboBoxEditPerson.Name = "ComboBoxEditPerson"
        Me.ComboBoxEditPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditPerson.Size = New System.Drawing.Size(552, 32)
        Me.ComboBoxEditPerson.StyleController = Me.LayoutControl1
        Me.ComboBoxEditPerson.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(917, 25)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Идентификация пользователя:"
        Me.LabelControl1.UseMnemonic = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(941, 237)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LabelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 29)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(306, 29)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(921, 29)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem2.Control = Me.ComboBoxEditPerson
        Me.LayoutControlItem2.Location = New System.Drawing.Point(200, 72)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(721, 36)
        Me.LayoutControlItem2.Text = "Пользователь:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(162, 25)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem3.Control = Me.TextEditPassword
        Me.LayoutControlItem3.Location = New System.Drawing.Point(200, 129)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(721, 36)
        Me.LayoutControlItem3.Text = "Пароль:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(162, 25)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ImageSliderPerson
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(54, 20)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(200, 188)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(200, 165)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(721, 52)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(200, 108)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(721, 21)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(200, 29)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(721, 43)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'ImageCollectionSlider
        '
        Me.ImageCollectionSlider.ImageSize = New System.Drawing.Size(500, 500)
        Me.ImageCollectionSlider.ImageStream = CType(resources.GetObject("ImageCollectionSlider.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollectionSlider.InsertImage(Global.iTPDoroga.My.Resources.Resources.sec00, "sec00", GetType(Global.iTPDoroga.My.Resources.Resources), 0)
        Me.ImageCollectionSlider.Images.SetKeyName(0, "sec00")
        Me.ImageCollectionSlider.InsertImage(Global.iTPDoroga.My.Resources.Resources.sec01, "sec01", GetType(Global.iTPDoroga.My.Resources.Resources), 1)
        Me.ImageCollectionSlider.Images.SetKeyName(1, "sec01")
        '
        'TimerSlider
        '
        Me.TimerSlider.Interval = 400
        '
        'XtraUCLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "XtraUCLogin"
        Me.Size = New System.Drawing.Size(941, 237)
        CType(Me.StyleControllerLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ImageSliderPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEditPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollectionSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StyleControllerLogin As DevExpress.XtraEditors.StyleController
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ImageSliderPerson As DevExpress.XtraEditors.Controls.ImageSlider
    Friend WithEvents TextEditPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ComboBoxEditPerson As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ImageCollectionSlider As DevExpress.Utils.ImageCollection
    Friend WithEvents TimerSlider As Timer
End Class
