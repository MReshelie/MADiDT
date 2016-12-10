Imports System.ComponentModel
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class XtraUCPhoto
    Dim _dir As String
    Dim _description As String

    Public Property DescriptionPhoto As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Sub New(ByVal dir As String)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        _dir = dir
    End Sub

    Private Sub XtraUCPhoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager.ShowForm(GetType(WaitFormLoadRec))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Идет загрузка изображений.")

        Dim list As BindingList(Of ImageFileInfo) = New BindingList(Of ImageFileInfo)

        For Each fl As FileInfo In (New DirectoryInfo(_dir)).GetFiles()
            list.Add(New ImageFileInfo(fl.Name, fl.FullName, fl.Extension.Substring(1), fl.CreationTime, Image.FromFile(fl.FullName), False))
        Next

        Me.GridControlPhoto.DataSource = list
        Me.WinExplorerViewPhoto.RefreshData()
        Me.WinExplorerViewPhoto.ColumnSet.ExtraLargeImageColumn = Me.WinExplorerViewPhoto.Columns("FileImg")
        Me.WinExplorerViewPhoto.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.ExtraLarge
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub WinExplorerViewPhoto_ContextButtonCustomize(sender As Object, e As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewContextButtonCustomizeEventArgs) Handles WinExplorerViewPhoto.ContextButtonCustomize
        If e.Item.Name = "contextTitleButton" Then
            DirectCast(e.Item, ContextButton).Caption = DirectCast(Me.WinExplorerViewPhoto.GetRowCellValue(e.RowHandle, Me.WinExplorerViewPhoto.Columns("FileName")), String)
        End If
    End Sub

    Private Sub WinExplorerViewPhoto_ContextButtonClick(sender As Object, e As ContextItemClickEventArgs) Handles WinExplorerViewPhoto.ContextButtonClick
        If e.Item.Name = "ContextButton" Then
            _description = Me.WinExplorerViewPhoto.GetRowCellValue(DirectCast(e.DataItem, Int32), Me.WinExplorerViewPhoto.Columns("FilePath")).ToString
        End If
    End Sub
End Class
