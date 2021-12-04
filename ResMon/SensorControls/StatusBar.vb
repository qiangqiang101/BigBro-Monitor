Imports System.ComponentModel

<Serializable>
Public Class StatusBar
    Inherits Control

    Private dynaMax As Boolean = False
    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl
    Private tempTexture As Image = Nothing

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
                    Case eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF, eSensorType.GPUClockSpeed, eSensorType.GPULoadPercent, eSensorType.GPUMemoryPercent, eSensorType.GPUPowerWattage, eSensorType.GPUTemperatureC, eSensorType.GPUTemperatureF, eSensorType.GPUVRAMUsage
                        _sensorParam = 0
                    Case eSensorType.MoboFan
                        _sensorParam = 1
                End Select
            End If
        End Set
    End Property

    Private _backColor As Color = Color.FromArgb(96, 96, 96)
    <Category("Appearance")>
    Public Property BackgroundColor() As Color
        Get
            Return _backColor
        End Get
        Set(value As Color)
            _backColor = value
        End Set
    End Property

    Private _frontcolor As Color = Color.FromArgb(41, 128, 185)
    <Category("Appearance")>
    Public Property ForegroundColor() As Color
        Get
            Return _frontcolor
        End Get
        Set(value As Color)
            _frontcolor = value
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
        End Set
    End Property

    Private _texture As Image = Nothing
    <Category("Appearance")>
    Public Property Texture() As Image
        Get
            Return _texture
        End Get
        Set(value As Image)
            _texture = value
            tempTexture = value
        End Set
    End Property

    Private _useTexture As Boolean
    <Category("Appearance")>
    Public Property UseTexture() As Boolean
        Get
            Return _useTexture
        End Get
        Set(value As Boolean)
            _useTexture = value
        End Set
    End Property

    Private _textureSize As Size = New Size(20, 20)
    <Category("Appearance")>
    Public Property TextureSize() As Size
        Get
            Return _textureSize
        End Get
        Set(value As Size)
            _textureSize = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim formGraphics As Graphics = e.Graphics
        formGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim txtbrush As New SolidBrush(ForeColor)

        Dim textSize = formGraphics.MeasureString(Text, Font)
        Dim textPoint As New Point(CInt(ClientRectangle.Left + (ClientRectangle.Width / 2) - (textSize.Width / 2)), CInt(ClientRectangle.Top + (ClientRectangle.Height / 2) - (textSize.Height / 2)))

        If _useTexture Then
            Using tbrush As New TextureBrush(tempTexture, Drawing2D.WrapMode.Tile)
                If Not _val = 0 Then formGraphics.FillRectangle(tbrush, New RectangleF(0, 0, _val / _max * Width - 1, Height - 1))
                formGraphics.DrawString(Text, Font, txtbrush, textPoint)
            End Using
        Else
            Using sbrush As New SolidBrush(_frontcolor)
                If Not _val = 0 Then formGraphics.FillRectangle(sbrush, New RectangleF(0, 0, _val / _max * Width - 1, Height - 1))
                formGraphics.DrawString(Text, Font, txtbrush, textPoint)
            End Using
        End If

        txtbrush.Dispose()
    End Sub

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
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
        If _useTexture AndAlso tempTexture IsNot Nothing Then
            If tempTexture.Width > _textureSize.Width Then
                tempTexture = New Bitmap(tempTexture, _textureSize)
            End If
            If tempTexture.Height > _textureSize.Height Then
                tempTexture = New Bitmap(tempTexture, _textureSize)
            End If
        End If

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
                    _val = myParentForm.hddSensor.RawTemperatureC(CInt(_sensorParam))
                    _min = 0
                    _max = 120
                    dynaMax = False
                Else
                    _val = myParentForm.hddSensor.RawTemperatureC()
                    _min = 0
                    _max = 120
                    dynaMax = False
                End If
            Case eSensorType.HDDTemperatureF
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.hddSensor.RawTemperatureF(CInt(_sensorParam))
                    _min = 32
                    _max = 248
                    dynaMax = False
                Else
                    _val = myParentForm.hddSensor.RawTemperatureF()
                    _min = 32
                    _max = 248
                    dynaMax = False
                End If
            Case eSensorType.HDDLoadPercent
                If IsNumeric(_sensorParam) Then
                    _val = myParentForm.hddSensor.RawLoadPercent(CInt(_sensorParam))
                    _min = 0
                    _max = 100
                    dynaMax = False
                Else
                    _val = myParentForm.hddSensor.RawLoadPercent()
                    _min = 0
                    _max = 100
                    dynaMax = False
                End If
            Case eSensorType.HDDUsage
                If String.IsNullOrEmpty(_sensorParam) Then
                    _val = myParentForm.hddSensor.RawDiskUsage()
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize()
                    dynaMax = False
                Else
                    _val = myParentForm.hddSensor.RawDiskUsage(CStr(_sensorParam))
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))
                    dynaMax = False
                End If
            Case eSensorType.HDDTotalFreeSpace
                If String.IsNullOrEmpty(_sensorParam) Then
                    _val = myParentForm.hddSensor.RawDiskTotalFreeSpace()
                    _min = 0L
                    _max = myParentForm.hddSensor.RawDiskTotalSize()
                    dynaMax = False
                Else
                    _val = myParentForm.hddSensor.RawDiskTotalFreeSpace(CStr(_sensorParam))
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
