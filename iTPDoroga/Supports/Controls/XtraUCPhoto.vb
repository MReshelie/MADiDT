Imports System.ComponentModel
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class XtraUCPhoto
    Dim _dir As String

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

        'If e.Item.Name = "CheckContextButton" Then
        '    DirectCast(e.Item, CheckContextButton).Checked = DirectCast(Me.WinExplorerViewPhoto.GetRowCellValue(e.RowHandle, Me.WinExplorerViewPhoto.Columns("FileCheck")), Boolean)
        'End If
    End Sub

    Private Sub WinExplorerViewPhoto_ContextButtonClick(sender As Object, e As ContextItemClickEventArgs) Handles WinExplorerViewPhoto.ContextButtonClick
        Dim caption As String = e.Item.Name
        Select Case caption
            Case "ContextButton"
                Dim Description As String = Me.WinExplorerViewPhoto.GetRowCellValue(DirectCast(e.DataItem, Int32), Me.WinExplorerViewPhoto.Columns("FilePath")).ToString
                'Dim cilinders As String = WinExplorerViewФото.GetRowCellValue(DirectCast(e.DataItem, Int32), colCilinders).ToString
                'Dim doors As String = WinExplorerViewФото.GetRowCellValue(DirectCast(e.DataItem, Int32), colDoors).ToString
                'Dim mpgCity As String = WinExplorerViewФото.GetRowCellValue(DirectCast(e.DataItem, Int32), colMPGCity).ToString
                'Dim mpgHighway As String = WinExplorerViewФото.GetRowCellValue(DirectCast(e.DataItem, Int32), colMPGHighway).ToString
                'XtraMessageBox.Show(Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString("Horsepower: ") & horsepower) + vbLf & "Cilinders: ") & cilinders) + vbLf & "Doors: ") & doors) + vbLf & "MPG City: ") & mpgCity) + vbLf & "MPG Highway: ") & mpgHighway, "Additional Info")

                XtraMessageBox.Show("Description : " & Description)
        End Select
    End Sub
End Class
