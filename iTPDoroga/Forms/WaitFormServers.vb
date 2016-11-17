Public Class WaitFormServers
    Sub New()
        InitializeComponent()

        Me.progressPanel1.AutoHeight = True
    End Sub

    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel1.Caption = caption
    End Sub

    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel1.Description = description

        Call SetImage(description)
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum WaitFormCommand
        SomeCommandId
    End Enum

#Region "Пользовательские процедуры и функции"
    ''' <summary>
    ''' Установка картинки на форме ожидания
    ''' </summary>
    ''' <param name="description">Текст сообщения</param>
    Private Sub SetImage(ByVal description As String)
        Select Case description
            Case "Получение списка серверов."
                Me.PictureBox1.Image = My.Resources.nastroika_servera
            Case "Получение списка баз данных."
                Me.PictureBox1.Image = My.Resources.db
        End Select

        Me.PictureBox1.BackColor = Color.Transparent
    End Sub
#End Region
End Class
