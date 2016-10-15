Imports DevExpress.XtraEditors

''' <summary>
''' A page that displays details for a single item within a group while allowing gestures to
''' flip through other items belonging to the same group.
''' </summary>
Partial Public Class ItemDetailPagePerson
    Inherits XtraUserControl
    Dim _index As Integer

    Public Sub New(ByVal item As SampleDataItem)
        InitializeComponent()

        labelTitle.Text = item.Title
        labelSubtitle.Text = item.Subtitle
        imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(item.ImagePath, GetType(ItemDetailPage).Assembly)
        _index = item.IndexItem
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub ItemDetailPagePerson_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        'Console.WriteLine(String.Format("ItemDetailPagePerson_Enter = {0}", _index))

        Select Case _index
            Case 3
                Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 5
                Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Select
    End Sub
End Class
