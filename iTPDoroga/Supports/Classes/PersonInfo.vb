Public Class PersonInfo
    Private _firstName As String
    Private _lastName As String
    Private _secondName As String
    Private _personInfo As String

    Public Sub New(ByVal firstName As String, ByVal lastName As String, Optional ByVal secondName As String = Nothing, Optional ByVal personInfo As String = Nothing)
        _firstName = firstName
        _lastName = lastName
        _secondName = secondName
        _personInfo = personInfo
    End Sub

    Public Overrides Function ToString() As String
        If IsNothing(_secondName) And IsNothing(_personInfo) Then
            Return String.Format("{0} {1} [{2}]", _firstName, _lastName, "нет данных")
        ElseIf IsNothing(_secondName) And Not IsNothing(_personInfo) Then
            Return String.Format("{0} {1} [{2}]", _firstName, _lastName, _personInfo)
        ElseIf Not IsNothing(_secondName) And IsNothing(_personInfo) Then
            Return String.Format("{0} {1} {2} [{3}]", _firstName, _lastName, _secondName, "нет данных")
        Else
            Return String.Format("{0} {1} {2} [{3}]", _firstName, _lastName, _secondName, _personInfo)
        End If
    End Function
End Class
