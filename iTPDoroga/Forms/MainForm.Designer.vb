
Partial Public Class MainForm
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

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.documentManagerMain = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.windowsUIViewMain = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(Me.components)
        Me.mainTileContainer = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(Me.components)
        Me.ucLoginFlyout = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(Me.components)
        Me.addLoginDocument = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(Me.components)
        Me.closeAppFlyout = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(Me.components)
        Me.ucServersFlyout = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(Me.components)
        Me.openServersDocument = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(Me.components)
        Me.TimerServers = New System.Windows.Forms.Timer(Me.components)
        CType(Me.documentManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.windowsUIViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mainTileContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucLoginFlyout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addLoginDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.closeAppFlyout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucServersFlyout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.openServersDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'documentManagerMain
        '
        Me.documentManagerMain.ContainerControl = Me
        Me.documentManagerMain.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.[False]
        Me.documentManagerMain.View = Me.windowsUIViewMain
        Me.documentManagerMain.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.windowsUIViewMain})
        '
        'windowsUIViewMain
        '
        Me.windowsUIViewMain.Caption = "МАД и ДТ"
        Me.windowsUIViewMain.ContentContainers.AddRange(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer() {Me.mainTileContainer, Me.ucLoginFlyout, Me.closeAppFlyout, Me.ucServersFlyout})
        Me.windowsUIViewMain.Documents.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseDocument() {Me.addLoginDocument, Me.openServersDocument})
        Me.windowsUIViewMain.SplashScreenProperties.Image = Global.iTPDoroga.My.Resources.Resources.construccio
        '
        'mainTileContainer
        '
        Me.mainTileContainer.Caption = "МАД и ДТ"
        Me.mainTileContainer.Name = "mainTileContainer"
        '
        'ucLoginFlyout
        '
        Me.ucLoginFlyout.Document = Me.addLoginDocument
        Me.ucLoginFlyout.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OKCancel
        Me.ucLoginFlyout.Name = "ucLoginFlyout"
        '
        'addLoginDocument
        '
        Me.addLoginDocument.Caption = "XtraUCLogin"
        Me.addLoginDocument.ControlName = "XtraUCLogin"
        Me.addLoginDocument.ControlTypeName = "iTPDoroga.XtraUCLogin"
        '
        'closeAppFlyout
        '
        Me.closeAppFlyout.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OK
        Me.closeAppFlyout.Name = "closeAppFlyout"
        '
        'ucServersFlyout
        '
        Me.ucServersFlyout.Document = Me.openServersDocument
        Me.ucServersFlyout.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OKCancel
        Me.ucServersFlyout.Name = "ucServersFlyout"
        '
        'openServersDocument
        '
        Me.openServersDocument.Caption = "XtraUCServers"
        Me.openServersDocument.ControlName = "XtraUCServers"
        Me.openServersDocument.ControlTypeName = "iTPDoroga.XtraUCServers"
        '
        'TimerServers
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 423)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.documentManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.windowsUIViewMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mainTileContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucLoginFlyout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addLoginDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.closeAppFlyout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucServersFlyout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.openServersDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents documentManagerMain As DevExpress.XtraBars.Docking2010.DocumentManager
    Private WithEvents windowsUIViewMain As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView
    Private WithEvents mainTileContainer As DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer
    Friend WithEvents ucLoginFlyout As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout
    Friend WithEvents addLoginDocument As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document
    Friend WithEvents closeAppFlyout As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout
    Friend WithEvents ucServersFlyout As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout
    Friend WithEvents addServersDocument As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document
    Friend WithEvents openServersDocument As DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document
    Friend WithEvents TimerServers As Timer
End Class
