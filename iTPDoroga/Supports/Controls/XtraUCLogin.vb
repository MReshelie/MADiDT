Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class XtraUCLogin
    Dim iSlide As Integer = 0
    Dim nSlide As Integer = 0

    Private _flConnect As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub XtraUCLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Persons(gblConn)

        Me.TimerSlider.Enabled = True
    End Sub

    Private Sub XtraUCLogin_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Me.TimerSlider.Enabled = False
    End Sub

    Private Sub TimerSlider_Tick(sender As Object, e As EventArgs) Handles TimerSlider.Tick
        If iSlide > 30 Then
            If Me.ImageSliderPerson.GetCurrentImageIndex + 1 >= nSlide Then
                Me.ImageSliderPerson.SlideFirst()
                Me.ImageSliderPerson.SetCurrentImageIndex(0)
            Else
                Me.ImageSliderPerson.SlideNext()
            End If

            iSlide = 0
        Else
            iSlide += 1
        End If
    End Sub

    Private Sub ComboBoxEditPerson_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEditPerson.SelectedIndexChanged
        Me.ImageSliderPerson.SetCurrentImageIndex(Me.ComboBoxEditPerson.Properties.Items.IndexOf(Me.ComboBoxEditPerson.EditValue))
        iSlide = 0
    End Sub

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Процедура Получение данных о пользователях для заполнения combobox
    ''' </summary>
    ''' <param name="_flag">Флаг активации строки подключения</param>
    Private Sub Persons(ByVal _flag As Boolean)
        Dim cbPerson As ComboBoxEdit = Me.ComboBoxEditPerson
        Dim isPersona As ImageSlider = Me.ImageSliderPerson

        If isPersona.Images.Count > 0 Then
            isPersona.Images.Clear()
        End If

        If _flag Then
            Dim _dbDDC As New DataClassesDorogaDataContext()

            If _dbDDC.CountСписок_сотрудников() > 0 Then
                PersonsCB(cbPerson, isPersona, From dE In _dbDDC.p_SelectСотрудники_Login Select New With {dE.Фамилия, dE.Имя, dE.Отчество, dE.Степень, dE.Должность, dE.Фото})
            End If

            isPersona.Images.Add(Me.ImageCollectionSlider.Images.Item(0))
        Else
            For iIm As Integer = 0 To Me.ImageCollectionSlider.Images.Count - 1
                isPersona.Images.Add(Me.ImageCollectionSlider.Images.Item(iIm))
            Next
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
    Private Sub PersonsCB(ByVal cbPerson As ComboBoxEdit, ByVal isPersona As ImageSlider, ByVal qR As Object)
        Dim _str As String

        For Each rec In CType(qR, IEnumerable(Of Object))
            If IsNothing(rec.Степень) And IsNothing(rec.Должность) Then
                _str = Nothing
            ElseIf IsNothing(rec.Степень) And Not IsNothing(rec.Должность) Then
                _str = CType(String.Format("{0}", LCase(rec.Должность)), String)
            ElseIf Not IsNothing(rec.Степень) And IsNothing(rec.Должность) Then
                _str = CType(String.Format("{0}", LCase(rec.Степень)), String)
            Else
                _str = CType(String.Format("{0}, {1}", LCase(rec.Степень), LCase(rec.Должность)), String)
            End If

            If Not IsNothing(_str) Then
                cbPerson.Properties.Items.Add(New PersonInfo(rec.Фамилия, Mid(rec.Имя, 1, 1) & ".", CType(IIf(IsNothing(rec.Отчество), Nothing, Mid(rec.Отчество, 1, 1) & "."), String), _str))
            Else
                cbPerson.Properties.Items.Add(New PersonInfo(rec.Фамилия, Mid(rec.Имя, 1, 1) & ".", CType(IIf(IsNothing(rec.Отчество), Nothing, Mid(rec.Отчество, 1, 1) & "."), String)))
            End If

            If rec.Фото IsNot Nothing Then
                isPersona.Images.Add(ByteArrayToImage(CType(rec.Фото.ToArray(), Byte())))
            Else
                isPersona.Images.Add(My.Resources.Нет_фото)
            End If

            nSlide += 1
        Next
    End Sub
#End Region
End Class
