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

    Dim db As New DataClassesDorogaDataContext

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        Me.NavBarControlPersona.Visible = False
    End Sub

    Private Sub XtraUCPersonRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not DBConnect()) Then Return
    End Sub

    Private Sub NavBarControlPersona_ActiveGroupChanged(sender As Object, e As NavBarGroupEventArgs) Handles NavBarControlPersona.ActiveGroupChanged
        Me.NavigationFramePersona.SelectedPage = CType(Me.NavigationFramePersona.Pages.FindFirst(Function(x) CStr(x.Tag) = e.Group.Caption), NavigationPage)
    End Sub

#Region "Пользовательские процедуры и функции"
    Private Function DBConnect() As Boolean
        db = New DataClassesDorogaDataContext()

        Me.LookUpEditФакультет.Properties.DataSource = Nothing
        Me.LookUpEditФакультет.Properties.DataSource = db.p_GetListOfFullФакультет().ToList()
        Me.LookUpEditСтепень.Properties.DataSource = Nothing
        Me.LookUpEditСтепень.Properties.DataSource = db.p_GetListOfFullСтепень().ToList()
        Me.LookUpEditДолжность.Properties.DataSource = Nothing
        Me.LookUpEditДолжность.Properties.DataSource = db.p_GetListOfFullДолжность().ToList()

        Dim Kafedra = From tKS In db.p_GetКафедраФакультет(CType(Me.LookUpEditФакультет.EditValue, Integer))

        Me.LookUpEditКафедра.Properties.DataSource = Nothing
        Me.LookUpEditКафедра.Properties.DataSource = Kafedra

        Console.WriteLine(String.Format("Me.TextEditКодСотрудник.EditValue = {0}", Me.TextEditКодСотрудник.EditValue))


        Dim iKafedra = From tKS In db.p_GetКафедра_Сотрудник(CType(Me.TextEditКодСотрудник.EditValue, Integer)) Take 1 Select tKS.кодКафедра

        For Each iK As Integer In iKafedra
            Me.LookUpEditКафедра.EditValue = iK
            Console.WriteLine(String.Format("iK = {0}", iK))
        Next

        Return True
    End Function
#End Region
End Class
