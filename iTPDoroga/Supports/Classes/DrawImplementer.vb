Imports Microsoft.VisualBasic
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Text
Imports DevExpress.XtraSplashScreen

Friend Class SplashImagePainter
    Implements ICustomImagePainter

    Private Shared privatePainter As SplashImagePainter
    Private info As ViewInfo = Nothing

    Shared Sub New()
        Painter = New SplashImagePainter()
    End Sub

    Protected Sub New()
    End Sub

    Public Shared Property Painter() As SplashImagePainter
        Get
            Return privatePainter
        End Get

        Private Set(ByVal value As SplashImagePainter)
            privatePainter = value
        End Set
    End Property

    Public ReadOnly Property ViewInfo() As ViewInfo
        Get
            If Me.info Is Nothing Then
                Me.info = New ViewInfo()
            End If

            Return Me.info
        End Get
    End Property

#Region "Drawing"
    Public Sub Draw(ByVal cache As GraphicsCache, ByVal bounds As Rectangle) Implements ICustomImagePainter.Draw
        Dim pt As PointF = ViewInfo.CalcProgressLabelPoint(cache, bounds)

        cache.Graphics.DrawString(ViewInfo.Text, ViewInfo.ProgressLabelFont, ViewInfo.Brush, pt)
    End Sub
#End Region
End Class

Friend Class ViewInfo
    Private privateCounter As Integer
    Private privateStage As String
    Private progressFont As Font = Nothing
    Private brush_Renamed As Brush = Nothing
    Private str_Text As String = String.Empty

    Public Sub New()
        Counter = 1
        Stage = String.Empty
    End Sub

    Public Property Counter() As Integer
        Get
            Return privateCounter
        End Get

        Set(ByVal value As Integer)
            privateCounter = value
        End Set
    End Property

    Public Property Stage() As String
        Get
            Return privateStage
        End Get

        Set(ByVal value As String)
            privateStage = value
        End Set
    End Property

    Public Function CalcProgressLabelPoint(ByVal cache As GraphicsCache, ByVal bounds As Rectangle) As PointF
        Const yOffset As Integer = 40

        Dim size As Size = TextUtils.GetStringSize(cache.Graphics, Text, ProgressLabelFont)

        Return New Point(CType(bounds.Width / 2 - size.Width / 2, Integer), yOffset)
    End Function

    Public ReadOnly Property ProgressLabelFont() As Font
        Get
            If progressFont Is Nothing Then
                Me.progressFont = New Font("Consolas", 10)
            End If

            Return Me.progressFont
        End Get
    End Property

    Public ReadOnly Property Brush() As Brush
        Get
            If Me.brush_Renamed Is Nothing Then
                Me.brush_Renamed = New SolidBrush(Color.Black)
            End If

            Return Me.brush_Renamed
        End Get
    End Property

    Public ReadOnly Property Text() As String
        Get
            If Len(Trim(Stage)) > 0 Then
                If Left(Stage, 12) = "Соединение с" Or Left(Stage, 28) = "Устанавливается соединение с" Then
                    str_Text = String.Format("{0} ...", Stage)
                Else
                    str_Text = String.Format("{0} - ({1}%)", Stage, Counter.ToString("D2"))
                End If
            Else
                str_Text = String.Empty
            End If

            Return str_Text
        End Get
    End Property
End Class
