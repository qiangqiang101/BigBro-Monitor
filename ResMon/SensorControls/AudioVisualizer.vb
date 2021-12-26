Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.ComponentModel.Design
Imports CSCore.SoundIn
Imports CSCore.SoundOut
Imports CSCore
Imports CSCore.Streams.Effects
Imports AudioSpectrum
Imports CSCore.DSP
Imports CSCore.Streams
Imports System.Drawing.Drawing2D

<Serializable>
Public Class AudioVisualizer
    Inherits PictureBox

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

    <Browsable(False)>
    Public WithEvents timer As Timer

    Private _soundIn As WasapiCapture
    Private _soundOut As ISoundOut
    Private _source As IWaveSource
    Private _pitchShifter As PitchShifter
    Private _lineSpectrum As Spectrum
    Private _angle As Single = 0F

    Private ReadOnly _bitmap As Bitmap = New Bitmap(2000, 600)
    Private _xpos As Integer

#Region "Overrides"

    <Browsable(False)>
    Public Overloads Property AccessibleDescription() As String
        Get
            Return MyBase.AccessibleDescription
        End Get
        Set(value As String)
            MyBase.AccessibleDescription = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleName() As String
        Get
            Return MyBase.AccessibleName
        End Get
        Set(value As String)
            MyBase.AccessibleName = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleRole() As AccessibleRole
        Get
            Return MyBase.AccessibleRole
        End Get
        Set(value As AccessibleRole)
            MyBase.AccessibleRole = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ErrorImage() As Image
        Get
            Return MyBase.ErrorImage
        End Get
        Set(value As Image)
            MyBase.ErrorImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImage() As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            MyBase.BackgroundImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Image() As Image
        Get
            Return MyBase.Image
        End Get
        Set(value As Image)
            MyBase.Image = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImageLayout() As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(value As ImageLayout)
            MyBase.BackgroundImageLayout = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property SizeMode() As PictureBoxSizeMode
        Get
            Return MyBase.SizeMode
        End Get
        Set(value As PictureBoxSizeMode)
            MyBase.SizeMode = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImageLocation() As String
        Get
            Return MyBase.ImageLocation
        End Get
        Set(value As String)
            MyBase.ImageLocation = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property InitialImage() As Image
        Get
            Return MyBase.InitialImage
        End Get
        Set(value As Image)
            MyBase.InitialImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property WaitOnLoad() As Boolean
        Get
            Return MyBase.WaitOnLoad
        End Get
        Set(value As Boolean)
            MyBase.WaitOnLoad = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AllowDrop() As Boolean
        Get
            Return MyBase.AllowDrop
        End Get
        Set(value As Boolean)
            MyBase.AllowDrop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return MyBase.ContextMenuStrip
        End Get
        Set(value As ContextMenuStrip)
            MyBase.ContextMenuStrip = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImeMode() As ImeMode
        Get
            Return MyBase.ImeMode
        End Get
        Set(value As ImeMode)
            MyBase.ImeMode = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabStop() As Boolean
        Get
            Return MyBase.TabStop
        End Get
        Set(value As Boolean)
            MyBase.TabStop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Tag() As Object
        Get
            Return MyBase.Tag
        End Get
        Set(value As Object)
            MyBase.Tag = value
        End Set
    End Property

    <Browsable(True)>
    <Category("Design")>
    Public Overloads Property Name() As String
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
            MyBase.Name = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property CausesValidation() As Boolean
        Get
            Return MyBase.CausesValidation
        End Get
        Set(value As Boolean)
            MyBase.CausesValidation = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabIndex() As Integer
        Get
            Return MyBase.TabIndex
        End Get
        Set(value As Integer)
            MyBase.TabIndex = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Cursor() As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            MyBase.Cursor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property UseWaitCursor() As Boolean
        Get
            Return MyBase.UseWaitCursor
        End Get
        Set(value As Boolean)
            MyBase.UseWaitCursor = value
        End Set
    End Property

#End Region

    Private _parentName As String
    <Category("Behavior")>
    Public Property ParentName() As String
        Get
            Return _parentName
        End Get
        Set(value As String)
            If value = Nothing Then Exit Property
            Dim ctrl = myParentForm.Controls.Find(value, False).FirstOrDefault
            If ctrl IsNot Nothing Then
                _parentName = value
            End If
        End Set
    End Property

    Private _sensor As eSensorType = eSensorType.None
    <Category("Behavior")>
    Public Property Sensor() As eSensorType
        Get
            Return _sensor
        End Get
        Set(value As eSensorType)
            _sensor = value
        End Set
    End Property

    Private _useAverage As Boolean = True
    <Category("Style")>
    Public Property UseAverage() As Boolean
        Get
            Return _useAverage
        End Get
        Set(value As Boolean)
            _useAverage = value
            Start()
        End Set
    End Property

    Private _barCount As Integer = 50
    <Category("Style")>
    Public Property BarCount() As Integer
        Get
            Return _barCount
        End Get
        Set(value As Integer)
            _barCount = value
            Start()
        End Set
    End Property

    Private _barSpacing As Integer = 2
    <Category("Style")>
    Public Property BarSpacing() As Integer
        Get
            Return _barSpacing
        End Get
        Set(value As Integer)
            _barSpacing = value
            Start()
        End Set
    End Property

    Private _scalingStrategy As ScalingStrategy = ScalingStrategy.Decibel
    <Category("Style")>
    Public Property ScalingStrategy() As ScalingStrategy
        Get
            Return _scalingStrategy
        End Get
        Set(value As ScalingStrategy)
            _scalingStrategy = value
            Start()
        End Set
    End Property

    Private _direction As eDirection = eDirection.Bottom
    <Category("Style")>
    Public Property Direction() As eDirection
        Get
            Return _direction
        End Get
        Set(value As eDirection)
            _direction = value
            Start()
        End Set
    End Property

    Private _lineCap As LineCap = LineCap.Round
    <Category("Style")>
    Public Property LineCap() As LineCap
        Get
            Return _lineCap
        End Get
        Set(value As LineCap)
            _lineCap = value
            Start()
        End Set
    End Property

    Private _barStyle As eBarStyle = eBarStyle.Bar
    <Category("Style")>
    Public Property BarStyle() As eBarStyle
        Get
            Return _barStyle
        End Get
        Set(value As eBarStyle)
            _barStyle = value
            Start()
        End Set
    End Property

    Private _colorStyle As ARColorStyle = ARColorStyle.Rainbow
    <Category("Style")>
    Public Property ColorStyle() As ARColorStyle
        Get
            Return _colorStyle
        End Get
        Set(value As ARColorStyle)
            _colorStyle = value
        End Set
    End Property

    Private _speed As Single = 0.02F
    <Category("Style")>
    Public Property Speed() As Single
        Get
            Return _speed
        End Get
        Set(value As Single)
            _speed = value
        End Set
    End Property

    Private _color1 As Color = Color.Purple
    <Category("Style")>
    Public Property Color1() As Color
        Get
            Return _color1
        End Get
        Set(value As Color)
            _color1 = value
        End Set
    End Property

    Private _color2 As Color = Color.Red
    <Category("Style")>
    Public Property Color2() As Color
        Get
            Return _color2
        End Get
        Set(value As Color)
            _color2 = value
        End Set
    End Property

    Private _color3 As Color = Color.Yellow
    <Category("Style")>
    Public Property Color3() As Color
        Get
            Return _color3
        End Get
        Set(value As Color)
            _color3 = value
        End Set
    End Property

    Private _color4 As Color = Color.Lime
    <Category("Style")>
    Public Property Color4() As Color
        Get
            Return _color4
        End Get
        Set(value As Color)
            _color4 = value
        End Set
    End Property

    Private _color5 As Color = Color.Cyan
    <Category("Style")>
    Public Property Color5() As Color
        Get
            Return _color5
        End Get
        Set(value As Color)
            _color5 = value
        End Set
    End Property

    Private _color6 As Color = Color.Blue
    <Category("Style")>
    Public Property Color6() As Color
        Get
            Return _color6
        End Get
        Set(value As Color)
            _color6 = value
        End Set
    End Property

    Private _color7 As Color = Color.Purple
    <Category("Style")>
    Public Property Color7() As Color
        Get
            Return _color7
        End Get
        Set(value As Color)
            _color7 = value
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If

        timer = New Timer() With {.Interval = 2000}

        Start()
    End Sub

    Public Sub UpdateControl()
    End Sub

    Private Sub Start()
        [Stop]()

        _soundIn = New WasapiLoopbackCapture(100, New WaveFormat(48000, 24, 2))
        _soundIn.Initialize()

        Dim soundInSource As New SoundInSource(_soundIn)
        Dim source As ISampleSource = soundInSource.ToSampleSource.AppendSource(Function(x) New PitchShifter(x), _pitchShifter)

        SetupSampleSource(source)

        Dim buffer As Byte() = New Byte(_source.WaveFormat.BytesPerSecond / 2 - 1) {}
        AddHandler soundInSource.DataAvailable, Sub(s, a)
                                                    Dim read As Integer
                                                    While ((read = _source.Read(buffer, 0, buffer.Length)) > 0)
                                                    End While
                                                End Sub

        _soundIn.Start()
        timer.Start()
    End Sub

    Private Sub [Stop]()
        timer.Stop()

        If _soundOut IsNot Nothing Then
            _soundOut.Stop()
            _soundOut.Dispose()
            _soundOut = Nothing
        End If
        If _soundIn IsNot Nothing Then
            _soundIn.Stop()
            _soundIn.Dispose()
            _soundIn = Nothing
        End If
        If _source IsNot Nothing Then
            _source.Dispose()
            _source = Nothing
        End If
    End Sub

    Private Sub SetupSampleSource(aSampleSource As ISampleSource)
        Const fftSize As FftSize = FftSize.Fft8192 'FftSize.Fft4096

        Dim spectrumProvider As New BasicSpectrumProvider(aSampleSource.WaveFormat.Channels, aSampleSource.WaveFormat.SampleRate, fftSize)

        _lineSpectrum = New Spectrum(fftSize)
        With _lineSpectrum
            .SpectrumProvider = spectrumProvider
            .UseAverage = _useAverage
            .BarCount = _barCount
            .BarSpacing = _barSpacing
            .IsXLogScale = True
            .ScalingStrategy = _scalingStrategy
            .Direction = _direction
            .LineCap = _lineCap
            .BarStyle = _barStyle
        End With

        Dim notificationSource As New SingleBlockNotificationStream(aSampleSource)
        AddHandler notificationSource.SingleBlockRead, Sub(s, a)
                                                           spectrumProvider.Add(a.Left, a.Right)
                                                       End Sub

        _source = notificationSource.ToWaveSource(16)
    End Sub

    Private Sub GenerateLineSpectrum()
        Using theBrush As New LinearGradientBrush(Point.Empty, New Point(Me.Width, Me.Height), _color1, _color2)
            theBrush.RotateTransform(_angle)

            Select Case _colorStyle
                Case ARColorStyle.Rainbow
                    Dim colorBlend As New ColorBlend()
                    colorBlend.Colors = New Color() {_color1, _color2, _color3, _color4, _color5, _color6, _color7}
                    colorBlend.Positions = New Single() {0F, 0.1666F, 0.3333F, 0.5F, 0.6666F, 0.8333F, 1.0F}
                    theBrush.InterpolationColors = colorBlend

                    Dim image As Image = Me.Image
                    Dim newImage = _lineSpectrum.CreateSpectrumLine(Me.Size, theBrush, BackColor, False)
                    If newImage IsNot Nothing Then
                        Me.Image = newImage
                        If image IsNot Nothing Then
                            image.Dispose()
                        End If
                    End If
                Case ARColorStyle.Gradient
                    Dim image As Image = Me.Image
                    Dim newImage = _lineSpectrum.CreateSpectrumLine(Me.Size, _color1, _color2, BackColor, False)
                    If newImage IsNot Nothing Then
                        Me.Image = newImage
                        If image IsNot Nothing Then
                            image.Dispose()
                        End If
                    End If
                Case ARColorStyle.Solid
                    Dim image As Image = Me.Image
                    Dim newImage = _lineSpectrum.CreateSpectrumLine(Me.Size, _color1, _color1, BackColor, False)
                    If newImage IsNot Nothing Then
                        Me.Image = newImage
                        If image IsNot Nothing Then
                            image.Dispose()
                        End If
                    End If
            End Select
        End Using
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        GenerateLineSpectrum()

        _angle += _speed
        If _angle >= Single.MaxValue - 1.0F Then _angle = 0F
    End Sub

    Private Sub AudioResponsive_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        [Stop]()
    End Sub
End Class

Public Enum ARColorStyle
    Solid
    Rainbow
    Gradient
End Enum