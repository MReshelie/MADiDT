Imports DevExpress.XtraEditors

''' <summary>
''' A page that displays details for a single item within a group while allowing gestures to
''' flip through other items belonging to the same group.
''' </summary>
Partial Public Class ItemDetailPagePerson
    Inherits XtraUserControl

    Public Sub New(ByVal item As SampleDataItem)
        InitializeComponent()
        labelTitle.Text = item.Title
        labelSubtitle.Text = item.Subtitle
        imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(item.ImagePath, GetType(ItemDetailPage).Assembly)
        'labelContent.Text = item.Content
    End Sub

    Private Sub ItemDetailPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Console.WriteLine(String.Format("sender = {0}, ItemDetailPage_Load->labelTitle.Text = {1}", sender.name, labelTitle.Text))
    End Sub
End Class
