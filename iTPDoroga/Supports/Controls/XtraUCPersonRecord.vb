Imports System.Data.Linq
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraNavBar

Public Class XtraUCPersonRecord
    Inherits EditFormUserControl

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        Me.NavBarControlPersona.Visible = False
    End Sub

    Private Sub NavBarControlPersona_ActiveGroupChanged(sender As Object, e As NavBarGroupEventArgs) Handles NavBarControlPersona.ActiveGroupChanged
        Me.NavigationFramePersona.SelectedPage = CType(Me.NavigationFramePersona.Pages.FindFirst(Function(x) CStr(x.Tag) = e.Group.Caption), NavigationPage)
    End Sub
End Class
