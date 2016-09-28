Imports System.Data.Entity
Imports System.Data.Linq
Imports System.Data.SqlClient
Imports System.Reflection
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Tab
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class XtraUCPerson
    Dim db As New DataClassesDorogaDataContext

    Public Sub New()
        InitializeComponent()

        Call DataGrid()

        Me.GridViewСотрудник.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
    End Sub

    Private Sub GridViewСотрудник_MasterRowGetRelationDisplayCaption(sender As Object, e As MasterRowGetRelationNameEventArgs) Handles GridViewСотрудник.MasterRowGetRelationDisplayCaption
        '
    End Sub

    Private Sub GridViewСотрудник_EditFormShowing(sender As Object, e As EditFormShowingEventArgs) Handles GridViewСотрудник.EditFormShowing
        Dim view As GridView = TryCast(sender, GridView)

        If view Is Nothing Then
            Return
        End If

        Me.GridViewСотрудник.OptionsEditForm.CustomEditFormLayout = New XtraUCPersonInfo(view.GetRowCellValue(e.RowHandle, "код"))
    End Sub

#Region "Пользовательские функции и процедуры"
    Private Sub DataGrid()
        db = New DataClassesDorogaDataContext()

        Dim Persona = From tKS In db.GetTable(Of Кафедра_Сотрудник)()
                      Order By
                          tKS.Сотрудник.Фамилия,
                          tKS.Сотрудник.Имя,
                          tKS.Сотрудник.Отчество
                      Select
                          код = tKS.Сотрудник.КодСотрудник,
                          tKS.Сотрудник.Фамилия,
                          tKS.Сотрудник.Имя,
                          tKS.Сотрудник.Отчество,
                          Кафедра = tKS.Кафедра.Аббревиатура,
                          Факультет = tKS.Сотрудник.Факультет.Аббр_Факультет,
                          Степень = tKS.Сотрудник.Степень.Аббревиатура,
                          Должность = tKS.Сотрудник.Должность.Аббревиатура,
                          tKS.Сотрудник.Записал,
                          Дата_записи = CType(tKS.Сотрудник.датаЗаписал, DateTime?),
                          tKS.Сотрудник.Исправил,
                          Дата_исправления = CType(tKS.Сотрудник.датаИсправил, DateTime?)


        Me.сотрудникBindingSource.DataSource = Persona
    End Sub
#End Region
End Class
