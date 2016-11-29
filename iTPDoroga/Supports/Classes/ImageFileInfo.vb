Imports System.IO

Public Class ImageFileInfo
    Private _fileName As String
    Private _filePath As String
    Private _fileExt As String
    Private _fileCrTime As DateTime
    Private _fileImg As Image
    Private _fileChk As Boolean

    Public Sub New(ByVal fileName As String, ByVal filePath As String, ByVal fileExt As String, ByVal fileCrTime As DateTime, ByVal fileImg As Image, ByVal fieCheck As Boolean)
        _fileName = fileName
        _filePath = filePath
        _fileExt = fileExt
        _fileCrTime = fileCrTime
        _fileImg = fileImg
        _fileChk = fieCheck
    End Sub

    Public Property FileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            _fileName = value
        End Set
    End Property
    Public Property FilePath() As String
        Get
            Return _filePath
        End Get
        Set(ByVal value As String)
            _filePath = value
        End Set
    End Property
    Public Property FileExt() As String
        Get
            Return _fileExt
        End Get
        Set(ByVal value As String)
            _fileExt = value
        End Set
    End Property
    Public Property FileCrTime() As DateTime
        Get
            Return _fileCrTime
        End Get
        Set(ByVal value As DateTime)
            _fileCrTime = value
        End Set
    End Property
    Public Property FileImg() As Image
        Get
            Return _fileImg
        End Get
        Set(ByVal value As Image)
            _fileImg = value
        End Set
    End Property
    Public Property FileCheck() As Boolean
        Get
            Return _fileChk
        End Get
        Set(ByVal value As Boolean)
            _fileChk = value
        End Set
    End Property
End Class
