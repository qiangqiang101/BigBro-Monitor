Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable>
Public Class CircularStatusBar
    Inherits Control

    Private dynaMax As Boolean = False
    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

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
    Public Overloads Property BackgroundImage() As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            MyBase.BackgroundImage = value
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

    Private _sensorParam As String
    <Category("Behavior"), Description("Used for a few Sensors like GPU, HDD, Ping && CustomDataTime.")>
    Public Property SensorParam() As String
        Get
            Return _sensorParam
        End Get
        Set(value As String)
            _sensorParam = value
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
            If String.IsNullOrEmpty(_sensorParam) Then
                Select Case value
                    Case eSensorType.CustomDateTime
                        _sensorParam = "dd/MM/yyyy hh:mm:ss tt"
                    Case eSensorType.Ping
                        _sensorParam = "www.google.com"
                    Case eSensorType.HDDUsage, eSensorType.HDDTotalFreeSpace, eSensorType.HDDTotalSize
                        _sensorParam = "C:\"
                    Case eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF, eSensorType.GPUClockSpeed, eSensorType.GPULoadPercent, eSensorType.GPUMemoryPercent, eSensorType.GPUPowerWattage,
                         eSensorType.GPUTemperatureC, eSensorType.GPUTemperatureF, eSensorType.GPUVRAMUsage
                        _sensorParam = 0
                    Case eSensorType.MoboFan
                        _sensorParam = 1
                End Select
            End If
        End Set
    End Property

    Private _csbstyle As csbStyle = csbStyle.Style1
    <Category("Appearance")>
    Public Property Style() As csbStyle
        Get
            Return _csbstyle
        End Get
        Set(value As csbStyle)
            _csbstyle = value
            Invalidate()
        End Set
    End Property

    Private _2ndText As String = Nothing
    <Category("Appearance")>
    Public Property SubText() As String
        Get
            Return _2ndText
        End Get
        Set(value As String)
            _2ndText = value
            Invalidate()
        End Set
    End Property

    Private _textMode As eTextMode = eTextMode.Value
    <Category("Appearance")>
    Public Property TextMode() As eTextMode
        Get
            Return _textMode
        End Get
        Set(value As eTextMode)
            _textMode = value
            Invalidate()
        End Set
    End Property

    Private _frontcolor As Color = Color.FromArgb(40, 40, 40)
    <Category("Appearance")>
    Public Property ForegroundColor() As Color
        Get
            Return _frontcolor
        End Get
        Set(value As Color)
            _frontcolor = value
            Invalidate()
        End Set
    End Property

    Private _progressColor As Color = Color.FromArgb(255, 0, 41)
    <Category("Appearance")>
    Public Property ProgressColor() As Color
        Get
            Return _progressColor
        End Get
        Set(value As Color)
            _progressColor = value
            Invalidate()
        End Set
    End Property

    Private _progressColor2 As Color = Color.FromArgb(0, 41, 255)
    <Category("Appearance")>
    Public Property ProgressColor2() As Color
        Get
            Return _progressColor2
        End Get
        Set(value As Color)
            _progressColor2 = value
            Invalidate()
        End Set
    End Property

    Private _barWidth As Integer = 360
    <Category("Appearance")>
    Public Property BarWidth() As Integer
        Get
            Return _barWidth
        End Get
        Set(value As Integer)
            If value > 360 Then value = 360
            If value < 0 Then value = 0
            _barWidth = value
            Invalidate()
        End Set
    End Property

    Private _thickness As Integer = 5
    <Category("Appearance")>
    Public Property Thickness() As Integer
        Get
            Return _thickness
        End Get
        Set(value As Integer)
            _thickness = value
            Invalidate()
        End Set
    End Property

    Private _gradientMode As LinearGradientMode = LinearGradientMode.ForwardDiagonal
    <Category("Appearance")>
    Public Property GradientMode() As LinearGradientMode
        Get
            Return _gradientMode
        End Get
        Set(value As LinearGradientMode)
            _gradientMode = value
            Invalidate()
        End Set
    End Property

    Private _progressShape As ProgressShape = ProgressShape.Flat
    <Category("Appearance")>
    Public Property ProgressShape() As ProgressShape
        Get
            Return _progressShape
        End Get
        Set(value As ProgressShape)
            _progressShape = value
            Invalidate()
        End Set
    End Property

    Private _startAngle As Integer = 90
    <Category("Appearance")>
    Public Property StartAngle() As Integer
        Get
            Return _startAngle
        End Get
        Set(value As Integer)
            _startAngle = value
            Invalidate()
        End Set
    End Property

    Private _unit As String = "%"
    <Category("Appearance")>
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(value As String)
            _unit = value
            Invalidate()
        End Set
    End Property

    Private _val As Integer = 0
    <Category("Behavior")>
    Public Property Value() As Integer
        Get
            Return _val
        End Get
        Set(value As Integer)
            _val = value
            If _val > _max Then _val = _max
            Invalidate()
        End Set
    End Property

    Private _min As Integer = 0
    <Category("Behavior")>
    Public Property Minimum() As Integer
        Get
            Return _min
        End Get
        Set(value As Integer)
            _min = value
            Invalidate()
        End Set
    End Property

    Private _max As Integer = 100
    <Category("Behavior")>
    Public Property Maximum() As Integer
        Get
            Return _max
        End Get
        Set(value As Integer)
            _max = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim formGraphics As Graphics = e.Graphics
        formGraphics.SmoothingMode = SmoothingMode.AntiAlias
        formGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear
        formGraphics.CompositingQuality = CompositingQuality.HighQuality
        formGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        Select Case _csbstyle
            Case csbStyle.Style1
                Using sbrush As New SolidBrush(ForeColor)
                    Dim progressAngle = CSng(360 / _max * _val)
                    Dim remainderAngle = 360 '- progressAngle

                    Dim rect As New Rectangle(ClientRectangle.X + _thickness, ClientRectangle.Y + _thickness, ClientRectangle.Width - (_thickness * 2), ClientRectangle.Height - (_thickness * 2))

                    Using gbrush As New LinearGradientBrush(ClientRectangle, _progressColor, _progressColor2, _gradientMode)
                        Using progressPen As New Pen(gbrush, _thickness), remainderPen As New Pen(_frontcolor, _thickness)
                            Select Case _progressShape
                                Case ProgressShape.Flat
                                    progressPen.StartCap = LineCap.Flat
                                    progressPen.EndCap = LineCap.Flat
                                    remainderPen.StartCap = LineCap.Flat
                                    remainderPen.EndCap = LineCap.Flat
                                Case ProgressShape.Round
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.Round
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.Arrow
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.Triangle
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                                Case ProgressShape.RoundAnchor
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.RoundAnchor
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.ArrowAnchor
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.ArrowAnchor
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                            End Select

                            'formGraphics.DrawArc(remainderPen, rect, progressAngle - _startAngle, remainderAngle)
                            formGraphics.DrawArc(remainderPen, rect, -_startAngle, remainderAngle)
                            formGraphics.DrawArc(progressPen, rect, -_startAngle, progressAngle)
                        End Using
                    End Using

                    Dim text As String = _val & _unit
                    Dim textSize = formGraphics.MeasureString(text, Font)
                    Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
                    Select Case _textMode
                        Case eTextMode.Value
                            formGraphics.DrawString(text, Font, sbrush, textPoint)
                        Case eTextMode.Text
                            formGraphics.DrawString(Me.Text, Font, sbrush, textPoint)
                    End Select
                End Using
            Case csbStyle.Style2
                Using sbrush As New SolidBrush(ForeColor)
                    Dim progressAngle = CSng(270 / _max * _val)
                    Dim remainderAngle = 270 '- progressAngle
                    Dim startAngle2 = -135

                    Dim rect As New Rectangle(ClientRectangle.X + _thickness, ClientRectangle.Y + _thickness, ClientRectangle.Width - (_thickness * 2), ClientRectangle.Height - (_thickness * 2))

                    Using gbrush As New LinearGradientBrush(ClientRectangle, _progressColor, _progressColor2, _gradientMode)
                        Using progressPen As New Pen(gbrush, _thickness), remainderPen As New Pen(_frontcolor, _thickness)
                            Select Case _progressShape
                                Case ProgressShape.Flat
                                    progressPen.StartCap = LineCap.Flat
                                    progressPen.EndCap = LineCap.Flat
                                    remainderPen.StartCap = LineCap.Flat
                                    remainderPen.EndCap = LineCap.Flat
                                Case ProgressShape.Round
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.Round
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.Arrow
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.Triangle
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                                Case ProgressShape.RoundAnchor
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.RoundAnchor
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.ArrowAnchor
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.ArrowAnchor
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                            End Select

                            'formGraphics.DrawArc(remainderPen, rect, progressAngle - startAngle2, remainderAngle)
                            formGraphics.DrawArc(remainderPen, rect, -startAngle2, remainderAngle)
                            formGraphics.DrawArc(progressPen, rect, -startAngle2, progressAngle)
                        End Using
                    End Using

                    Dim mtext As String = _val & _unit
                    Dim textSize = formGraphics.MeasureString(mtext, Font)
                    Dim newFont As New Font(Font.FontFamily, CSng(Font.Size / 2.0F), Font.Style)
                    Dim textSize2 = formGraphics.MeasureString(_2ndText, newFont)
                    Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
                    Dim textPoint2 As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize2.Width / 2)), (rect.Top + rect.Height) - textSize2.Height)
                    Select Case _textMode
                        Case eTextMode.Value
                            formGraphics.DrawString(mtext, Font, sbrush, textPoint)
                        Case eTextMode.Text
                            formGraphics.DrawString(Me.Text, Font, sbrush, textPoint)
                    End Select
                    formGraphics.DrawString(_2ndText, newFont, sbrush, textPoint2)
                    newFont.Dispose()
                End Using
            Case csbStyle.Style3
                Using sbrush As New SolidBrush(ForeColor)
                    Dim progressAngle = CSng(_barWidth / _max * _val)
                    Dim remainderAngle = _barWidth '- progressAngle

                    Dim rect As New Rectangle(ClientRectangle.X + _thickness, ClientRectangle.Y + _thickness, ClientRectangle.Width - (_thickness * 2), ClientRectangle.Height - (_thickness * 2))

                    Using gbrush As New LinearGradientBrush(ClientRectangle, _progressColor, _progressColor2, _gradientMode)
                        Using progressPen As New Pen(gbrush, _thickness), remainderPen As New Pen(_frontcolor, _thickness)
                            Select Case _progressShape
                                Case ProgressShape.Flat
                                    progressPen.StartCap = LineCap.Flat
                                    progressPen.EndCap = LineCap.Flat
                                    remainderPen.StartCap = LineCap.Flat
                                    remainderPen.EndCap = LineCap.Flat
                                Case ProgressShape.Round
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.Round
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.Arrow
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.Triangle
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                                Case ProgressShape.RoundAnchor
                                    progressPen.StartCap = LineCap.Round
                                    progressPen.EndCap = LineCap.RoundAnchor
                                    remainderPen.StartCap = LineCap.Round
                                    remainderPen.EndCap = LineCap.Round
                                Case ProgressShape.ArrowAnchor
                                    progressPen.StartCap = LineCap.Triangle
                                    progressPen.EndCap = LineCap.ArrowAnchor
                                    remainderPen.StartCap = LineCap.Triangle
                                    remainderPen.EndCap = LineCap.Triangle
                            End Select

                            'formGraphics.DrawArc(remainderPen, rect, progressAngle - _startAngle, remainderAngle)
                            formGraphics.DrawArc(remainderPen, rect, -_startAngle, remainderAngle)
                            formGraphics.DrawArc(progressPen, rect, -_startAngle, progressAngle)
                        End Using
                    End Using

                    Dim text As String = _val & _unit
                    Dim textSize = formGraphics.MeasureString(text, Font)
                    Dim newFont As New Font(Font.FontFamily, CSng(Font.Size / 2.0F), Font.Style)
                    Dim textSize2 = formGraphics.MeasureString(_2ndText, newFont)
                    Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
                    Dim textPoint2 As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize2.Width / 2)), (rect.Top + rect.Height) - textSize2.Height)
                    Select Case _textMode
                        Case eTextMode.Value
                            formGraphics.DrawString(text, Font, sbrush, textPoint)
                        Case eTextMode.Text
                            formGraphics.DrawString(Me.Text, Font, sbrush, textPoint)
                    End Select
                    formGraphics.DrawString(_2ndText, newFont, sbrush, textPoint2)
                    newFont.Dispose()
                End Using
        End Select
    End Sub

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
        'SetStyle(ControlStyles.Opaque, True)
        BackColor = Color.Transparent
        DoubleBuffered = True
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub Increment(value As Integer)
        _val += value
        Invalidate()
    End Sub

    Public Sub UpdateControl()
        Select Case _sensor
            Case eSensorType.CPUTemperatureC
                _val = myParentForm.cpuSensor.RawTemperatureC
                _min = 0
                _max = 120
                dynaMax = False
            Case eSensorType.CPUTemperatureF
                _val = myParentForm.cpuSensor.RawTemperatureF
                _min = 32
                _max = 248
                dynaMax = False
            Case eSensorType.CPULoadPercent
                _val = myParentForm.cpuSensor.RawLoadPercent
                _min = 0
                _max = 100
                dynaMax = False

            Case eSensorType.GPUTemperatureC
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.gpuSensor.RawTemperatureC(_sensorParam)
                    _min = 0
                    _max = 120
                    dynaMax = False
                Else
                    _val = myParentForm.gpuSensor.RawTemperatureC
                    _min = 0
                    _max = 120
                    dynaMax = False
                End If
            Case eSensorType.GPUTemperatureF
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.gpuSensor.RawTemperatureF(_sensorParam)
                    _min = 32
                    _max = 248
                    dynaMax = False
                Else
                    _val = myParentForm.gpuSensor.RawTemperatureF
                    _min = 32
                    _max = 248
                    dynaMax = False
                End If
            Case eSensorType.GPULoadPercent
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.gpuSensor.RawLoadPercent(_sensorParam)
                    _min = 0
                    _max = 100
                    dynaMax = False
                Else
                    _val = myParentForm.gpuSensor.RawLoadPercent
                    _min = 0
                    _max = 100
                    dynaMax = False
                End If
            Case eSensorType.GPUMemoryPercent
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.gpuSensor.RawMemoryPercent(_sensorParam)
                    _min = 0
                    _max = 100
                    dynaMax = False
                Else
                    _val = myParentForm.gpuSensor.RawMemoryPercent
                    _min = 0
                    _max = 100
                    dynaMax = False
                End If
            Case eSensorType.GPUVRAMUsage
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.gpuSensor.RawVRAMUsage(_sensorParam)
                    _min = 0
                    _max = myParentForm.gpuSensor.RawVRAMTotal(_sensorParam)
                    dynaMax = False
                Else
                    _val = myParentForm.gpuSensor.RawVRAMUsage
                    _min = 0
                    _max = myParentForm.gpuSensor.RawVRAMTotal
                    dynaMax = False
                End If

            Case eSensorType.RAMLoadPercent
                _val = myParentForm.ramSensor.RawLoadPercent
                _min = 0
                _max = 100
                dynaMax = False
            Case eSensorType.RAMUsage
                _val = myParentForm.ramSensor.RawRAMUsage
                _min = 0
                _max = myParentForm.ramSensor.RawRAMAvailable + myParentForm.ramSensor.RawRAMUsage
                dynaMax = False
            Case eSensorType.RAMAvailable
                _val = myParentForm.ramSensor.RawRAMAvailable
                _min = 0
                _max = myParentForm.ramSensor.RawRAMTotal
                dynaMax = False

            Case eSensorType.HDDTemperatureC
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.hddsensor.RawTemperatureC(CInt(_sensorParam))
                    _min = 0
                    _max = 120
                    dynaMax = False
                Else
                    _val = myParentForm.hddsensor.RawTemperatureC()
                    _min = 0
                    _max = 120
                    dynaMax = False
                End If
            Case eSensorType.HDDTemperatureF
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.hddsensor.RawTemperatureF(CInt(_sensorParam))
                    _min = 32
                    _max = 248
                    dynaMax = False
                Else
                    _val = myParentForm.hddsensor.RawTemperatureF()
                    _min = 32
                    _max = 248
                    dynaMax = False
                End If
            Case eSensorType.HDDLoadPercent
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.hddsensor.RawLoadPercent(CInt(_sensorParam))
                    _min = 0
                    _max = 100
                    dynaMax = False
                Else
                    _val = myParentForm.hddsensor.RawLoadPercent()
                    _min = 0
                    _max = 100
                    dynaMax = False
                End If
            Case eSensorType.HDDUsage
                If String.IsNullOrEmpty(_sensorParam) Then
                    _val = myParentForm.hddsensor.RawDiskUsage()
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize()
                    dynaMax = False
                Else
                    _val = myParentForm.hddsensor.RawDiskUsage(CStr(_sensorParam))
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))
                    dynaMax = False
                End If
            Case eSensorType.HDDTotalFreeSpace
                If String.IsNullOrEmpty(_sensorParam) Then
                    _val = myParentForm.hddsensor.RawDiskTotalFreeSpace()
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize()
                    dynaMax = False
                Else
                    _val = myParentForm.hddsensor.RawDiskTotalFreeSpace(CStr(_sensorParam))
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))
                    dynaMax = False
                End If

            Case eSensorType.MoboTemperatureC
                _val = myParentForm.moboSensor.RawTemperatureC()
                _min = 0
                _max = 120
                dynaMax = False
            Case eSensorType.MoboTemperatureF
                _val = myParentForm.moboSensor.RawTemperatureF()
                _min = 32
                _max = 248
                dynaMax = False

                'Added 25/10/2021 dynamic max
            Case eSensorType.CPUClockSpeed
                _val = CInt(myParentForm.cpuSensor.RawClockSpeed())
                _min = 0
                dynaMax = True
            Case eSensorType.CPUPowerWattage
                _val = CInt(myParentForm.cpuSensor.RawPowerWattage())
                _min = 0
                dynaMax = True

            Case eSensorType.GPUClockSpeed
                If IsNumeric(_sensorParam) Then
                    _val = CInt(myParentForm.gpuSensor.RawClockSpeed(CInt(_sensorParam)))
                    _min = 0
                    dynaMax = True
                Else
                    _val = CInt(myParentForm.gpuSensor.RawClockSpeed())
                    _min = 0
                    dynaMax = True
                End If
            Case eSensorType.GPUPowerWattage
                If IsNumeric(_sensorParam) Then
                    _val = CInt(myParentForm.gpuSensor.RawPowerWattage(CInt(_sensorParam)))
                    _min = 0
                    dynaMax = True
                Else
                    _val = CInt(myParentForm.gpuSensor.RawPowerWattage())
                    _min = 0
                    dynaMax = True
                End If
            Case eSensorType.GPUFan
                If IsNumeric(_sensorParam) Then
                    _val = CInt(myParentForm.gpuSensor.RawFanSpeed(CInt(_sensorParam)))
                    _min = 0
                    dynaMax = True
                Else
                    _val = CInt(myParentForm.gpuSensor.RawFanSpeed())
                    _min = 0
                    dynaMax = True
                End If

            Case eSensorType.DownloadSpeed
                _val = CInt(myParentForm.netSensor.RawDownloadSpeed())
                _min = 0
                dynaMax = True
            Case eSensorType.UploadSpeed
                _val = CInt(myParentForm.netSensor.RawUploadSpeed)
                _min = 0
                dynaMax = True
            Case eSensorType.Ping
                If String.IsNullOrEmpty(_sensorParam) Then
                    _val = CInt(myParentForm.netSensor.RawPing)
                    _min = 0
                    dynaMax = True
                Else
                    _val = CInt(myParentForm.netSensor.RawPing(_sensorParam))
                    _min = 0
                    dynaMax = True
                End If

            Case eSensorType.MoboFan
                If IsNumeric(_sensorParam) Then
                    _val = CInt(myParentForm.moboSensor.RawFanSpeed(CInt(_sensorParam)))
                    _min = 0
                    dynaMax = True
                Else
                    _val = CInt(myParentForm.moboSensor.RawFanSpeed())
                    _min = 0
                    dynaMax = True
                End If

            Case eSensorType.CPUFan
                _val = CInt(myParentForm.moboSensor.RawFanSpeed(UserSettings.CpuFan + 1))
                _min = 0
                dynaMax = True
        End Select

        If dynaMax Then
            If _val > _max Then _max = _val
        End If

        Invalidate()
    End Sub

End Class

Public Enum csbStyle
    Style1
    Style2
    Style3
End Enum

Public Enum ProgressShape
    Flat
    Round
    Arrow
    RoundAnchor
    ArrowAnchor
End Enum
