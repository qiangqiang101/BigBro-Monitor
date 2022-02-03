Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class CustomText
    Inherits Label

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

#Region "Overrides"

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
    Public Overloads Property ImageIndex() As Integer
        Get
            Return MyBase.ImageIndex
        End Get
        Set(value As Integer)
            MyBase.ImageIndex = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImageKey() As String
        Get
            Return MyBase.ImageKey
        End Get
        Set(value As String)
            MyBase.ImageKey = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImageList() As ImageList
        Get
            Return MyBase.ImageList
        End Get
        Set(value As ImageList)
            MyBase.ImageList = value
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

    <Browsable(True)>
    Public Overloads Property AutoSize() As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(value As Boolean)
            MyBase.AutoSize = False
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

    <Browsable(False)>
    Public Overloads Property Text() As String
        Get
            Return Nothing
        End Get
        Set(value As String)
            MyBase.Text = Nothing
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(value As Color)
            MyBase.ForeColor = value
        End Set
    End Property

#End Region

    Private _sensor As eSensorType = eSensorType.None
    <Category("Behavior")>
    Public Property Sensor() As eSensorType
        Get
            Return _sensor
        End Get
        Set(value As eSensorType)
            _sensor = value
            UpdateControl()
            If String.IsNullOrEmpty(_sensorParam) Then
                Select Case value
                    Case eSensorType.CustomDateTime
                        _sensorParam = "dd/MM/yyyy hh:mm:ss tt"
                    Case eSensorType.Ping
                        _sensorParam = "www.google.com"
                    Case eSensorType.HDDUsage, eSensorType.HDDTotalFreeSpace, eSensorType.HDDTotalSize
                        _sensorParam = "C:\"
                    Case eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF, eSensorType.GPUClockSpeed, eSensorType.GPULoadPercent, eSensorType.GPUMemoryPercent, eSensorType.GPUPowerWattage,
                         eSensorType.GPUTemperatureC, eSensorType.GPUTemperatureF, eSensorType.GPUVRAMUsage, eSensorType.GPUMemoryClock, eSensorType.GPUShaderClock, eSensorType.GPUFrameBufferLoad,
                         eSensorType.GPUVideoEngineLoad, eSensorType.GPUBusInterfaceLoad, eSensorType.GPUVRAMFree, eSensorType.GPUVRAMTotal
                        _sensorParam = 0
                    Case eSensorType.MoboFan
                        _sensorParam = 1
                End Select
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

    Private _title As String = "Custom"
    <Category("Appearance")>
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
            Invalidate()
        End Set
    End Property

    Private _value As String = "Text"
    <Category("Appearance")>
    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(vValue As String)
            _value = vValue
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

    Private _titleColor As Color = ForeColor
    <Category("Appearance")>
    Public Property TitleColor() As Color
        Get
            Return _titleColor
        End Get
        Set(value As Color)
            _titleColor = value
            Invalidate()
        End Set
    End Property

    Private _valueColor As Color = ForeColor
    <Category("Appearance")>
    Public Property ValueColor() As Color
        Get
            Return _valueColor
        End Get
        Set(value As Color)
            _valueColor = value
            Invalidate()
        End Set
    End Property

    Private _unitColor As Color = ForeColor
    <Category("Appearance")>
    Public Property UnitColor() As Color
        Get
            Return _unitColor
        End Get
        Set(value As Color)
            _unitColor = value
            Invalidate()
        End Set
    End Property

    Private _titleAlign As ContentAlignment = ContentAlignment.MiddleCenter
    <Category("Appearance")>
    Public Property TitleAlign() As ContentAlignment
        Get
            Return _titleAlign
        End Get
        Set(value As ContentAlignment)
            _titleAlign = value
            Invalidate()
        End Set
    End Property

    Private _valueAlign As ContentAlignment = ContentAlignment.MiddleCenter
    <Category("Appearance")>
    Public Property ValueAlign() As ContentAlignment
        Get
            Return _valueAlign
        End Get
        Set(value As ContentAlignment)
            _valueAlign = value
            Invalidate()
        End Set
    End Property

    Private _unitAlign As ContentAlignment = ContentAlignment.MiddleCenter
    <Category("Appearance")>
    Public Property UnitAlign() As ContentAlignment
        Get
            Return _unitAlign
        End Get
        Set(value As ContentAlignment)
            _unitAlign = value
            Invalidate()
        End Set
    End Property

    Private _autoWidth As Boolean = True
    <Category("Layout")>
    Public Property AutoWidth() As Boolean
        Get
            Return _autoWidth
        End Get
        Set(value As Boolean)
            _autoWidth = value
            Invalidate()
        End Set
    End Property

    Private _titleWidth As Single = 5.0F
    <Category("Layout")>
    Public Property TitleWidth() As Single
        Get
            Return _titleWidth
        End Get
        Set(value As Single)
            _titleWidth = value
            Invalidate()
        End Set
    End Property

    Private _valueWidth As Single = 5.0F
    <Category("Layout")>
    Public Property ValueWidth() As Single
        Get
            Return _valueWidth
        End Get
        Set(value As Single)
            _valueWidth = value
            Invalidate()
        End Set
    End Property

    Private _unitWidth As Single = 5.0F
    <Category("Layout")>
    Public Property UnitWidth() As Single
        Get
            Return _unitWidth
        End Get
        Set(value As Single)
            _unitWidth = value
            Invalidate()
        End Set
    End Property

    Private _titleFont As Font = MyBase.Font
    <Category("Appearance")>
    Public Property TitleFont() As Font
        Get
            Return _titleFont
        End Get
        Set(value As Font)
            _titleFont = value
            Invalidate()
        End Set
    End Property

    Private _unitFont As Font = MyBase.Font
    <Category("Appearance")>
    Public Property UnitFont() As Font
        Get
            Return _unitFont
        End Get
        Set(value As Font)
            _unitFont = value
            Invalidate()
        End Set
    End Property

    Private _titleTextAdjustment As Point = Point.Empty
    <Category("Layout")>
    Public Property TitleTextAdjustment() As Point
        Get
            Return _titleTextAdjustment
        End Get
        Set(value As Point)
            _titleTextAdjustment = value
            Invalidate()
        End Set
    End Property

    Private _valueTextAdjustment As Point = Point.Empty
    <Category("Layout")>
    Public Property ValueTextAdjustment() As Point
        Get
            Return _valueTextAdjustment
        End Get
        Set(value As Point)
            _valueTextAdjustment = value
            Invalidate()
        End Set
    End Property

    Private _unitTextAdjustment As Point = Point.Empty
    <Category("Layout")>
    Public Property UnitTextAdjustment() As Point
        Get
            Return _unitTextAdjustment
        End Get
        Set(value As Point)
            _unitTextAdjustment = value
            Invalidate()
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        BackColor = Color.Transparent
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub UpdateControl()
        Try
            Select Case _sensor
                Case eSensorType.CPUCoreCount
                    Value = myParentForm.cpuSensor.CoreCount
                Case eSensorType.CPUClockSpeed
                    Value = Math.Ceiling(myParentForm.cpuSensor.RawClockSpeed)
                Case eSensorType.CPUTemperatureC
                    Value = myParentForm.cpuSensor.RawTemperatureC
                Case eSensorType.CPUTemperatureF
                    Value = myParentForm.cpuSensor.RawTemperatureF
                Case eSensorType.CPULoadPercent
                    Value = myParentForm.cpuSensor.RawLoadPercent
                Case eSensorType.CPUPowerWattage
                    Value = Math.Round(myParentForm.cpuSensor.RawPowerWattage, 2)

                Case eSensorType.GPUClockSpeed
                    If IsNumeric(_sensorParam) Then
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawClockSpeed(CInt(_sensorParam)))
                    Else
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawClockSpeed)
                    End If
                Case eSensorType.GPUTemperatureC
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawTemperatureC(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawTemperatureC
                    End If
                Case eSensorType.GPUTemperatureF
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawTemperatureF(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawTemperatureF
                    End If
                Case eSensorType.GPULoadPercent
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawLoadPercent(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawLoadPercent
                    End If
                Case eSensorType.GPUMemoryPercent
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawMemoryPercent(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawMemoryPercent
                    End If
                Case eSensorType.GPUPowerWattage
                    If IsNumeric(_sensorParam) Then
                        Value = Math.Round(myParentForm.gpuSensor.RawPowerWattage(CInt(_sensorParam)), 2)
                    Else
                        Value = Math.Round(myParentForm.gpuSensor.RawPowerWattage, 2)
                    End If
                Case eSensorType.GPUVRAMUsage
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawVRAMUsage(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawVRAMUsage
                    End If
                Case eSensorType.GPUFan
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawFanSpeed
                    Else
                        Value = myParentForm.gpuSensor.RawFanSpeed(CInt(_sensorParam))
                    End If

                Case eSensorType.RAMLoadPercent
                    Value = myParentForm.ramSensor.RawLoadPercent

                Case eSensorType.RAMUsage
                    Value = myParentForm.ramSensor.RawRAMUsage

                Case eSensorType.RAMAvailable
                    Value = myParentForm.ramSensor.RawRAMAvailable

                Case eSensorType.RAMTotal
                    Value = myParentForm.ramSensor.RawRAMTotal

                Case eSensorType.HDDTemperatureC
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawTemperatureC(CInt(_sensorParam))
                    Else
                        Value = myParentForm.hddSensor.RawTemperatureC
                    End If
                Case eSensorType.HDDTemperatureF
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawTemperatureF(CInt(_sensorParam))
                    Else
                        Value = myParentForm.hddSensor.RawTemperatureF
                    End If

                Case eSensorType.HDDLoadPercent
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawLoadPercent(CInt(_sensorParam))
                    Else
                        Value = myParentForm.hddSensor.RawLoadPercent
                    End If
                Case eSensorType.HDDTotalSize
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawDiskTotalSize
                    Else
                        Value = myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))
                    End If
                Case eSensorType.HDDTotalFreeSpace
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawDiskTotalFreeSpace
                    Else
                        Value = myParentForm.hddSensor.RawDiskTotalFreeSpace(CStr(_sensorParam))
                    End If
                Case eSensorType.HDDUsage
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.hddSensor.RawDiskUsage
                    Else
                        Value = myParentForm.hddSensor.RawDiskUsage(CStr(_sensorParam))
                    End If
                Case eSensorType.DownloadSpeed
                    Value = Math.Round(myParentForm.netSensor.RawDownloadSpeed, 2)
                Case eSensorType.UploadSpeed
                    Value = Math.Round(myParentForm.netSensor.RawUploadSpeed, 2)
                Case eSensorType.Ping
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.netSensor.RawPing
                    Else
                        Value = myParentForm.netSensor.RawPing(CStr(_sensorParam))
                    End If

                Case eSensorType.LongDate
                    Value = Now.ToLongDateString
                Case eSensorType.ShortDate
                    Value = Now.ToShortDateString
                Case eSensorType.LongTime
                    Value = Now.ToLongTimeString
                Case eSensorType.ShortTime
                    Value = Now.ToShortTimeString
                Case eSensorType.CustomDateTime
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = Now.ToString
                    Else
                        Value = Now.ToString(_sensorParam)
                    End If

                Case eSensorType.MoboTemperatureC
                    Value = myParentForm.moboSensor.RawTemperatureC
                Case eSensorType.MoboTemperatureF
                    Value = myParentForm.moboSensor.RawTemperatureF
                Case eSensorType.MoboFan
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Value = myParentForm.moboSensor.RawFanSpeed
                    Else
                        Value = myParentForm.moboSensor.RawFanSpeed(_sensorParam)
                    End If
                Case eSensorType.CPUFan
                    Value = myParentForm.moboSensor.RawFanSpeed(CInt(_sensorParam))


                    'Added 13/01/2022
                Case eSensorType.CPUCorePower
                    Value = Math.Round(myParentForm.cpuSensor.RawCorePower, 2)
                Case eSensorType.CPUGraphicPower
                    Value = Math.Round(myParentForm.cpuSensor.RawGraphicPower, 2)
                Case eSensorType.CPUDRAMPower
                    Value = Math.Round(myParentForm.cpuSensor.RawDRAMPower, 2)
                Case eSensorType.GPUMemoryClock
                    If IsNumeric(_sensorParam) Then
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawMemoryClock(CInt(_sensorParam)))
                    Else
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawMemoryClock)
                    End If
                Case eSensorType.GPUShaderClock
                    If IsNumeric(_sensorParam) Then
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawShaderClock(CInt(_sensorParam)))
                    Else
                        Value = Math.Ceiling(myParentForm.gpuSensor.RawShaderClock)
                    End If
                Case eSensorType.GPUFrameBufferLoad
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawFrameBufferLoad(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawFrameBufferLoad
                    End If
                Case eSensorType.GPUVideoEngineLoad
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawVideoEngineLoad(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawVideoEngineLoad
                    End If
                Case eSensorType.GPUBusInterfaceLoad
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawBusInterfaceLoad(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawBusInterfaceLoad
                    End If
                Case eSensorType.GPUVRAMFree
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawVRAMFree(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawVRAMFree
                    End If
                Case eSensorType.GPUVRAMTotal
                    If IsNumeric(_sensorParam) Then
                        Value = myParentForm.gpuSensor.RawVRAMTotal(CInt(_sensorParam))
                    Else
                        Value = myParentForm.gpuSensor.RawVRAMTotal
                    End If

                    'Added 15/01/2022
                Case eSensorType.DisplayScreenResolution
                    Value = myParentForm.displaySensor.RawScreenResolution
                Case eSensorType.DisplayRefreshRate
                    Value = myParentForm.displaySensor.RawRefreshRate
            End Select
        Catch ex As Exception
            Logger.Log(ex)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality
        g.CompositingQuality = CompositingQuality.AssumeLinear
        g.PixelOffsetMode = PixelOffsetMode.Default
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Using titleFormat As New StringFormat(StringFormat.GenericTypographic)
            Dim gp As New GraphicsPath
            Dim pf As PointF
            Dim mt = TextRenderer.MeasureText(_title, _titleFont)

            Dim rfa As RectangleF 'String area rectangle.
            If _autoWidth Then
                rfa = New RectangleF(_titleTextAdjustment.X, _titleTextAdjustment.Y, Width / CalculateRfWidth(), mt.Height + 1)
            Else
                rfa = New RectangleF(_titleTextAdjustment.X, _titleTextAdjustment.Y, _titleWidth, mt.Height + 1)
            End If

            AlignmentConverter(titleFormat, TitleAlign)

            gp.AddString(Title, _titleFont.FontFamily, _titleFont.Style, CSng(g.DpiY * _titleFont.Size / 72), rfa, titleFormat)

            Select Case titleFormat.LineAlignment
                Case StringAlignment.Near : pf = New PointF(0, 0)
                Case StringAlignment.Center : pf = New PointF(0, CSng(Height / 2 - (gp.GetBounds.Height + 24) / 2))
                Case StringAlignment.Far : pf = New PointF(0, CSng(Height - (gp.GetBounds.Height + 24)))
            End Select

            Using base As New SolidBrush(TitleColor)
                g.FillPath(base, gp)
            End Using
        End Using

        Using valueFormat As New StringFormat(StringFormat.GenericTypographic)
            Dim gp As New GraphicsPath
            Dim pf As PointF
            Dim mt = TextRenderer.MeasureText(_value, Font)

            Dim rfa As RectangleF  'String area rectangle.
            If _autoWidth Then
                rfa = New RectangleF((Width / CalculateRfWidth()) + _titleTextAdjustment.X + _valueTextAdjustment.X, _valueTextAdjustment.Y, Width / CalculateRfWidth(), mt.Height + 1)
            Else
                rfa = New RectangleF(_titleWidth + _titleTextAdjustment.X + _valueTextAdjustment.X, _valueTextAdjustment.Y, _valueWidth, mt.Height + 1)
            End If

            AlignmentConverter(valueFormat, ValueAlign)

            gp.AddString(Value, Font.FontFamily, Font.Style, CSng(g.DpiY * Font.Size / 72), rfa, valueFormat)

            Select Case valueFormat.LineAlignment
                Case StringAlignment.Near : pf = New PointF(Width / CalculateRfWidth(), 0)
                Case StringAlignment.Center : pf = New PointF(Width / CalculateRfWidth(), CSng(Height / 2 - (gp.GetBounds.Height + 24) / 2))
                Case StringAlignment.Far : pf = New PointF(Width / CalculateRfWidth(), CSng(Height - (gp.GetBounds.Height + 24)))
            End Select

            Using base As New SolidBrush(ValueColor)
                g.FillPath(base, gp)
            End Using
        End Using

        Using unitFormat As New StringFormat(StringFormat.GenericTypographic)
            Dim gp As New GraphicsPath
            Dim pf As PointF
            Dim mt = TextRenderer.MeasureText(_unit, _unitFont)

            Dim rfa As RectangleF  'String area rectangle.
            If _autoWidth Then
                rfa = New RectangleF(((Width / CalculateRfWidth()) * 2) + _titleTextAdjustment.X + _valueTextAdjustment.X + _unitTextAdjustment.X, _unitTextAdjustment.Y, Width / CalculateRfWidth(), mt.Height + 1)
            Else
                rfa = New RectangleF((_titleWidth + _valueWidth) + _titleTextAdjustment.X + _valueTextAdjustment.X + _unitTextAdjustment.X, _unitTextAdjustment.Y, _unitWidth, mt.Height + 1)
            End If

            AlignmentConverter(unitFormat, UnitAlign)

            gp.AddString(Unit, _unitFont.FontFamily, _unitFont.Style, CSng(g.DpiY * _unitFont.Size / 72), rfa, unitFormat)

            Select Case unitFormat.LineAlignment
                Case StringAlignment.Near : pf = New PointF(Width / CalculateRfWidth(), 0)
                Case StringAlignment.Center : pf = New PointF(Width / CalculateRfWidth(), CSng(Height / 2 - (gp.GetBounds.Height + 24) / 2))
                Case StringAlignment.Far : pf = New PointF(Width / CalculateRfWidth(), CSng(Height - (gp.GetBounds.Height + 24)))
            End Select

            Using base As New SolidBrush(UnitColor)
                g.FillPath(base, gp)
            End Using
        End Using
    End Sub

    Private Sub AlignmentConverter(sf As StringFormat, ca As ContentAlignment)
        Select Case ca
            Case ContentAlignment.TopLeft
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Near
            Case ContentAlignment.TopCenter
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Center
            Case ContentAlignment.TopRight
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Far
            Case ContentAlignment.MiddleLeft
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Near
            Case ContentAlignment.MiddleCenter
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Center
            Case ContentAlignment.MiddleRight
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Far
            Case ContentAlignment.BottomLeft
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Near
            Case ContentAlignment.BottomCenter
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Center
            Case ContentAlignment.BottomRight
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Far
        End Select
    End Sub

    Private Function CalculateRfWidth() As Integer
        Dim num As Integer = 0
        If _title.Length <> 0 Then num += 1
        If _value.Length <> 0 Then num += 1
        If _unit.Length <> 0 Then num += 1
        Return num
    End Function

End Class
