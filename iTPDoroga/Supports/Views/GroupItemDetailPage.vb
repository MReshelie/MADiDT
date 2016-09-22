Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraSplashScreen
Imports System.Threading

''' <summary>
''' A page that displays a grouped collection of items.
''' </summary>
Partial Public Class GroupItemDetailPage
    Inherits DevExpress.XtraEditors.XtraUserControl
    Private pageGroupCore As PageGroup
    Private indexCore As Integer

    Public Sub New(ByVal item As SampleDataItem, ByVal child As PageGroup, ByVal index As Integer)
        InitializeComponent()
        pageGroupCore = child
        indexCore = index
        labelTitle.Text = item.Title
        labelSubtitle.Text = item.Subtitle
        imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(item.ImagePath, GetType(ItemDetailPage).Assembly)
        labelDescription.Text = item.Description
    End Sub

    Private Sub imageControlClick(ByVal sender As Object, ByVal e As EventArgs) Handles imageControl.Click
        'Dim stopwatch As Stopwatch = Stopwatch.StartNew

        SplashScreenManager.ShowForm(GetType(WaitFormLoadRec))
        SplashScreenManager.Default.SetWaitFormCaption("Ожидайте...")
        SplashScreenManager.Default.SetWaitFormDescription("Идет загрузка данных из БД.")

        Dim documentContainer As BaseContentContainer = TryCast(pageGroupCore.Parent, BaseContentContainer)

        Console.WriteLine(String.Format("imageControlClick->labelTitle.Text = {0}", labelTitle.Text))

        'Thread.Sleep(5000)

        If documentContainer IsNot Nothing Then
            ActivateContainer(documentContainer.Manager)
        End If

        'stopwatch.Stop()
        SplashScreenManager.CloseForm(False)
    End Sub
    Private Sub ActivateContainer(ByVal manager As DocumentManager)
        Dim view As WindowsUIView = TryCast(manager.View, WindowsUIView)

        If view IsNot Nothing Then
            Console.WriteLine(String.Format("pageGroupCore.Caption = {0}, indexCore = {1}", pageGroupCore.Caption, indexCore))

            pageGroupCore.Parent = TryCast(Me.Tag, IContentContainer)
            pageGroupCore.SetSelected(pageGroupCore.Items(indexCore))
            view.ActivateContainer(pageGroupCore)
        End If
    End Sub
End Class
