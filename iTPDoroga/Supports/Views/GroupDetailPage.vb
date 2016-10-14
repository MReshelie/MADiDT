Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI

''' <summary>
''' A page that displays an overview of a single group, including a preview of the items
''' within the group.
''' </summary>
Partial Public Class GroupDetailPage
    Inherits XtraUserControl
    Private pageGroupCore As PageGroup

    Public ReadOnly Property PageGroup() As PageGroup
        Get
            Return pageGroupCore
        End Get
    End Property

    Public Sub New(ByVal dataGroup As SampleDataGroup, ByVal child As PageGroup)
        InitializeComponent()

        pageGroupCore = New PageGroup()
        pageGroupCore.Caption = dataGroup.Title
        imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(dataGroup.ImagePath, GetType(MainForm).Assembly)
        labelSubtitle.Text = dataGroup.Subtitle
        labelDescription.Text = dataGroup.Description

        Call CreateLayout(dataGroup, child)
    End Sub

#Region "Пользовательские процедуры и функции"
    Private Sub CreateLayout(ByVal dataGroup As SampleDataGroup, ByVal child As PageGroup)
        For i As Integer = 0 To dataGroup.Items.Count - 1
            CreateLayoutCore(dataGroup.Items(i), child, i)
        Next i
    End Sub

    Private Sub CreateLayoutCore(ByVal item As SampleDataItem, ByVal child As PageGroup, ByVal index As Integer)
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()

        Dim layoutTileItem As New DevExpress.XtraLayout.LayoutControlItem()
        Dim page As New GroupItemDetailPage(item, child, index)

        page.Tag = pageGroupCore
        layoutTileItem.Control = page
        layoutTileItem.Location = New Point(0, 0)
        layoutTileItem.MinSize = New Size(winLayoutControl1.Width, page.Height)
        layoutTileItem.MaxSize = New Size(0, page.Height)
        layoutTileItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        layoutTileItem.TextSize = New Size(0, 0)
        layoutTileItem.TextToControlDistance = 0
        layoutTileItem.TextVisible = False
        layoutControlGroup2.Add(layoutTileItem)
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
#End Region
End Class
