
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
        Me.documentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.windowsUIView1 = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(Me.components)
        Me.mainTileContainer = New DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(Me.components)
        CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.windowsUIView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mainTileContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' documentManager1
        '
        Me.documentManager1.ContainerControl = Me
        Me.documentManager1.View = Me.windowsUIView1
        Me.documentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.windowsUIView1})
        '
        ' windowsUIView1
        '
        Me.windowsUIView1.ContentContainers.AddRange(New DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer() {Me.mainTileContainer})
        '
        ' mainTileContainer
        '
        Me.mainTileContainer.Caption = "Header"
        Me.mainTileContainer.Name = "mainTileContainer"
        '
        ' MainForm
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 16.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1272, 521)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Margin = New Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.WindowState = FormWindowState.Maximized
        CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.windowsUIView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mainTileContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents documentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Private WithEvents windowsUIView1 As DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView
    Private WithEvents mainTileContainer As DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer
End Class
