Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports AudioSpectrum
Imports CSCore.DSP

Public Class Spectrum
    Inherits SpectrumBase

    Private _barCount As Integer
    Public Property BarCount() As Integer
        Get
            Return _barCount
        End Get
        Set(value As Integer)
            If value <= 0 Then Throw New ArgumentOutOfRangeException("value")
            _barCount = value
            SpectrumResolution = value
            UpdateFrequencyMapping()

            RaisePropertyChanged("BarCount")
            RaisePropertyChanged("BarWidth")
        End Set
    End Property

    Private _barSpacing As Double
    Public Property BarSpacing() As Double
        Get
            Return _barSpacing
        End Get
        Set(value As Double)
            If value < 0 Then Throw New ArgumentOutOfRangeException("value")
            _barSpacing = value
            UpdateFrequencyMapping()

            RaisePropertyChanged("BarSpacing")
            RaisePropertyChanged("BarWidth")
        End Set
    End Property

    Private _barWidth As Double
    <Browsable(False)>
    Public ReadOnly Property BarWidth() As Double
        Get
            Return _barWidth
        End Get
    End Property

    Private _currentSize As Size
    <BrowsableAttribute(False)>
    Public Property CurrentSize() As Size
        Get
            Return _currentSize
        End Get
        Protected Set(value As Size)
            _currentSize = value
            RaisePropertyChanged("CurrentSize")
        End Set
    End Property

    Private _direction As eDirection = eDirection.Bottom
    Public Property Direction() As eDirection
        Get
            Return _direction
        End Get
        Set(value As eDirection)
            _direction = value
        End Set
    End Property

    Private _lineCap As LineCap = LineCap.Round
    Public Property LineCap() As LineCap
        Get
            Return _lineCap
        End Get
        Set(value As LineCap)
            _lineCap = value
        End Set
    End Property

    Private _barStyle As eBarStyle = eBarStyle.Bar
    Public Property BarStyle() As eBarStyle
        Get
            Return _barStyle
        End Get
        Set(value As eBarStyle)
            _barStyle = value
        End Set
    End Property

    Public Sub New(fftSize As FftSize)
        Me.FftSize = fftSize
    End Sub

    Public Function CreateSpectrumLine(size As Size, brush As Brush, background As Color, highQuality As Boolean) As Bitmap
        If Not UpdateFrequencyMappingIfNessesary(size) Then Return Nothing

        Dim fftBuffer = New Single(CInt(FftSize) - 1) {}

        If SpectrumProvider.GetFftData(fftBuffer, Me) Then
            Using pen As New Pen(brush, CSng(_barWidth))
                Dim bitmap As New Bitmap(size.Width, size.Height)

                Using g As Graphics = Graphics.FromImage(bitmap)
                    PrepareGraphics(g, highQuality)
                    g.Clear(background)

                    CreateSpectrumLineInternal(g, pen, fftBuffer, size)
                End Using

                Return bitmap
            End Using
        End If

        Return Nothing
    End Function

    Public Function CreateSpectrumLine(size As Size, color1 As Color, color2 As Color, background As Color, highQuality As Boolean) As Bitmap
        If Not UpdateFrequencyMappingIfNessesary(size) Then Return Nothing

        Using brush As New LinearGradientBrush(New RectangleF(0, 0, CSng(_barWidth), size.Height), color2, color1, LinearGradientMode.Vertical)
            Return CreateSpectrumLine(size, brush, background, highQuality)
        End Using
    End Function

    Private Sub CreateSpectrumLineInternal(graphics As Graphics, pen As Pen, fftBuffer As Single(), size As Size)
        Dim height As Integer = size.Height
        Dim spectrumPoints As SpectrumPointData() = CalculateSpectrumPoints(height, fftBuffer)
        Dim cOldPoint As New PointF(0, height / 2)
        Dim cOldPoint2 As New PointF(0, height / 2)
        Dim tOldPoint As New PointF(0, 0)
        Dim bOldPoint As New PointF(0, height)

        For i As Integer = 0 To spectrumPoints.Length - 1
            Dim p As SpectrumPointData = spectrumPoints(i)
            Dim barIndex As Integer = p.SpectrumPointIndex
            Dim xCoord As Double = BarSpacing * (barIndex + 1) + (_barWidth * barIndex) + _barWidth / 2
            pen.EndCap = LineCap

            Select Case Direction
                Case eDirection.Bottom
                    Dim p1 = New PointF(CSng(xCoord), height)
                    Dim p2 = New PointF(CSng(xCoord), height - CSng(p.Value) - 1)
                    Select Case BarStyle
                        Case eBarStyle.Bar
                            graphics.DrawLine(pen, p1, p2)
                        Case eBarStyle.Line
                            graphics.DrawLine(pen, bOldPoint, p2)
                            bOldPoint = p2
                    End Select
                Case eDirection.Top
                    Dim p1 = New PointF(CSng(xCoord), 0)
                    Dim p2 = New PointF(CSng(xCoord), CSng(p.Value) - 1)
                    Select Case BarStyle
                        Case eBarStyle.Bar
                            graphics.DrawLine(pen, p1, p2)
                        Case eBarStyle.Line
                            graphics.DrawLine(pen, tOldPoint, p2)
                            tOldPoint = p2
                    End Select
                Case eDirection.Center
                    Dim p1 = New PointF(CSng(xCoord), height / 2)
                    Dim p2 = New PointF(CSng(xCoord), (height / 2) - CSng(p.Value))
                    Dim p3 = New PointF(CSng(xCoord), height / 2)
                    Dim p4 = New PointF(CSng(xCoord), CSng(p.Value) + (height / 2))

                    Select Case BarStyle
                        Case eBarStyle.Bar
                            graphics.DrawLine(pen, p1, p2)
                            graphics.DrawLine(pen, p3, p4)
                        Case eBarStyle.Line
                            graphics.DrawLine(pen, cOldPoint, p2)
                            graphics.DrawLine(pen, cOldPoint2, p4)
                            cOldPoint = p2
                            cOldPoint2 = p4
                    End Select
            End Select
        Next
    End Sub

    Private Sub DrawCircle(graphics As Graphics, pen As Pen, center As PointF, radius As Single)
        graphics.DrawEllipse(pen, center.X - radius, center.Y - radius, radius + radius, radius + radius)
    End Sub

    Protected Overrides Sub UpdateFrequencyMapping()
        _barWidth = Math.Max(((_currentSize.Width - (BarSpacing * (BarCount + 1))) / BarCount), 0.00001)

        MyBase.UpdateFrequencyMapping()
    End Sub

    Public Function UpdateFrequencyMappingIfNessesary(newSize As Size) As Boolean
        If Not newSize = CurrentSize Then
            CurrentSize = newSize
            UpdateFrequencyMapping()
        End If

        Return newSize.Width > 0 AndAlso newSize.Height > 0
    End Function

    Private Sub PrepareGraphics(graphics As Graphics, highQuality As Boolean)
        If highQuality Then
            graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            graphics.CompositingQuality = Drawing2D.CompositingQuality.AssumeLinear
            graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Default
            graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Else
            graphics.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            graphics.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None
            graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        End If
    End Sub

End Class

Public Enum eDirection
    Top
    Bottom
    Center
End Enum

Public Enum eBarStyle
    Bar
    Line
End Enum