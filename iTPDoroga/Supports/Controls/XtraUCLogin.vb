Imports DevExpress.XtraEditors

Public Class XtraUCLogin
    Public iSlide As Integer = 1

    Private _flConnect As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub XtraUCLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TimerSlider.Enabled = True

        Call Persons(gblConn)
    End Sub

    Private Sub XtraUCLogin_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Me.TimerSlider.Enabled = False
    End Sub

    Private Sub TimerSlider_Tick(sender As Object, e As EventArgs) Handles TimerSlider.Tick
        If iSlide = Me.ImageCollectionSlider.Images.Count Then
            Me.ImageSliderPerson.SlideFirst()
            iSlide = 1
        Else
            Me.ImageSliderPerson.SlideNext()
            iSlide += 1
        End If
    End Sub

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Процедура Получение данных о пользователях для заполнения combobox
    ''' </summary>
    ''' <param name="_flag">Флаг активации строки подключения</param>
    Private Sub Persons(ByVal _flag As Boolean)
        Dim cbPerson As ComboBoxEdit = Me.ComboBoxEditPerson

        If _flag Then
            Dim _dbDDC As New DataClassesDorogaDataContext()

            If _dbDDC.CountСписок_сотрудников() > 0 Then
                PersonsCB(cbPerson, From dE In _dbDDC.Сотрудник Order By dE.Фамилия, dE.Имя, dE.Отчество
                                    Select New With {dE.Фамилия, dE.Имя, dE.Отчество, dE.Степень.Аббревиатура, dE.Должность.Наименование})
            End If
        End If

        cbPerson.Properties.Items.BeginUpdate()
        cbPerson.Properties.Items.Add(New PersonInfo("Администратор", "системы", , "Полный доступ"))
        cbPerson.SelectedIndex = 0
        cbPerson.Properties.Items.EndUpdate()
    End Sub

    ''' <summary>
    ''' Процедура Заполнение combobox данными о пользователях
    ''' </summary>
    ''' <param name="cbPerson">Заполняемый ComboBox</param>
    ''' <param name="qR">Запос из которого берутся данные заполнения</param>
    Private Shared Sub PersonsCB(ByVal cbPerson As ComboBoxEdit, ByVal qR As Object)
        Dim _str As String

        For Each rec In qR
            If IsNothing(rec.Аббревиатура) And IsNothing(rec.Наименование) Then
                _str = Nothing
            ElseIf IsNothing(rec.Аббревиатура) And Not IsNothing(rec.Наименование) Then
                _str = CType(String.Format("{0}", LCase(rec.Наименование)), String)
            ElseIf Not IsNothing(rec.Аббревиатура) And IsNothing(rec.Наименование) Then
                _str = CType(String.Format("{0}", LCase(rec.Аббревиатура)), String)
            Else
                _str = CType(String.Format("{0}, {1}", LCase(rec.Аббревиатура), LCase(rec.Наименование)), String)
            End If

            If Not IsNothing(_str) Then
                cbPerson.Properties.Items.Add(New PersonInfo(rec.Фамилия, Mid(rec.Имя, 1, 1) & ".", CType(IIf(IsNothing(rec.Отчество), Nothing, Mid(rec.Отчество, 1, 1) & "."), String), _str))
            Else
                cbPerson.Properties.Items.Add(New PersonInfo(rec.Фамилия, Mid(rec.Имя, 1, 1) & ".", CType(IIf(IsNothing(rec.Отчество), Nothing, Mid(rec.Отчество, 1, 1) & "."), String)))
            End If
        Next
    End Sub
#End Region
End Class
