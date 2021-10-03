Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class PlotChart
    Inherits Control

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

    Private Const MAX_VALUE_COUNT As Integer = 512
    Private Const GRID_SPACING As Integer = 20
    Private visibleValues As Integer = 0
    Private valueSpacing As Integer = 1
    Private currentMaxValue As Decimal = 0
    Private currentValue As Decimal = 0
    Private gridScrollOffset As Integer = 0
    Private averageValue As Decimal = 0
    Private measureUnit As String = Nothing

    Private drawValues As List(Of Decimal) = New List(Of Decimal)(MAX_VALUE_COUNT)
    Private waitingValues As Queue(Of Decimal) = New Queue(Of Decimal)()


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

    Private _plotChartStyle As PlotChartStyle
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance"), Description("Appearance and Style")>
    Public Property PlotChartStyle() As PlotChartStyle
        Get
            Return _plotChartStyle
        End Get
        Set(ByVal value As PlotChartStyle)
            _plotChartStyle = value
        End Set
    End Property

    Private b3dstyle As Border3DStyle = Border3DStyle.Adjust
    <DefaultValue(GetType(Border3DStyle), "Adjust"), Description("BorderStyle"), Category("Appearance")>
    Public Overloads Property BorderStyle() As Border3DStyle
        Get
            Return b3dstyle
        End Get
        Set(ByVal value As Border3DStyle)
            b3dstyle = value
            Invalidate()
        End Set
    End Property

    Private _scaleMode As ScaleMode = ScaleMode.Relative
    <Category("Behavior")>
    Public Property ScaleMode() As ScaleMode
        Get
            Return _scaleMode
        End Get
        Set(ByVal value As ScaleMode)
            _scaleMode = value
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        _plotChartStyle = New PlotChartStyle()
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub Clear()
        drawValues.Clear()
        Invalidate()
    End Sub

    Public Sub AddValue(ByVal value As Decimal, ByVal unit As String)
        If ScaleMode = ScaleMode.Absolute AndAlso value > 100D Then Throw New Exception(String.Format("Values greater then 100 not allowed in ScaleMode: Absolute ({0})", value))

        ChartAppend(value)
        Invalidate()

        currentValue = value
        measureUnit = unit
    End Sub

    Private Sub AddValueToQueue(ByVal value As Decimal)
        waitingValues.Enqueue(value)
    End Sub

    Private Sub ChartAppend(ByVal value As Decimal)
        drawValues.Insert(0, Math.Max(value, 0))
        If drawValues.Count > MAX_VALUE_COUNT Then drawValues.RemoveAt(MAX_VALUE_COUNT)
        gridScrollOffset += valueSpacing
        If gridScrollOffset > GRID_SPACING Then gridScrollOffset = gridScrollOffset Mod GRID_SPACING
    End Sub

    Private Function CalcVerticalPosition(ByVal value As Decimal) As Integer
        Dim result As Decimal = Decimal.Zero

        If _scaleMode = ScaleMode.Absolute Then
            result = value * Me.Height / 100
        ElseIf _scaleMode = ScaleMode.Relative Then
            result = If((currentMaxValue > 0), (value * Me.Height / currentMaxValue), 0)
        End If

        result = Me.Height - result
        Return Convert.ToInt32(Math.Round(result))
    End Function

    Private Function GetHighestValueForRelativeMode() As Decimal
        Dim maxValue As Decimal = 0

        For i As Integer = 0 To visibleValues - 1
            If drawValues(i) > maxValue Then maxValue = drawValues(i)
        Next

        Return maxValue
    End Function

    Private Sub DrawChart(ByVal g As Graphics)
        visibleValues = Math.Min(Me.Width / valueSpacing, drawValues.Count)
        If _scaleMode = ScaleMode.Relative Then currentMaxValue = GetHighestValueForRelativeMode()
        Dim previousPoint As Point = New Point(Width + valueSpacing, Height)
        Dim currentPoint As Point = New Point()

        If visibleValues > 0 AndAlso _plotChartStyle.ShowAverageLine Then
            averageValue = 0
            DrawAverageLine(g)
        End If

        For i As Integer = 0 To visibleValues - 1
            currentPoint.X = previousPoint.X - valueSpacing
            currentPoint.Y = CalcVerticalPosition(drawValues(i))
            g.DrawLine(_plotChartStyle.ChartLinePen.Pen, previousPoint, currentPoint)
            Using gPath As New GraphicsPath
                Using brush As New SolidBrush(Color.FromArgb(100, _plotChartStyle.ChartLinePen.Color))
                    gPath.AddRectangle(New Rectangle(currentPoint, New Size(1, ClientRectangle.Height - currentPoint.Y)))
                    g.FillPath(brush, gPath)
                End Using
            End Using

            previousPoint = currentPoint
        Next

        If _scaleMode = ScaleMode.Relative Then
            Dim sb As SolidBrush = New SolidBrush(_plotChartStyle.ChartLinePen.Color)
            If _plotChartStyle.ShowCurMax Then
                g.DrawString($"{Text} CUR: {currentValue.ToString}{measureUnit} MAX: {currentMaxValue.ToString()}{measureUnit}", Font, sb, 4.0F, 2.0F)
            Else
                g.DrawString(Text, Font, sb, 4.0F, 2.0F)
            End If
        End If

        ControlPaint.DrawBorder3D(g, 0, 0, Width, Height, b3dstyle)
    End Sub

    Private Sub DrawAverageLine(ByVal g As Graphics)
        For i As Integer = 0 To visibleValues - 1
            averageValue += drawValues(i)
        Next

        averageValue = averageValue / visibleValues
        Dim verticalPosition As Integer = CalcVerticalPosition(averageValue)
        g.DrawLine(_plotChartStyle.AvgLinePen.Pen, 0, verticalPosition, Width, verticalPosition)
    End Sub

    Private Sub DrawBackgroundAndGrid(ByVal g As Graphics)
        Dim baseRectangle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)

        Using gradientBrush As Brush = New LinearGradientBrush(baseRectangle, _plotChartStyle.BackgroundColorTop, _plotChartStyle.BackgroundColorBottom, LinearGradientMode.Vertical)
            g.FillRectangle(gradientBrush, baseRectangle)
        End Using

        If _plotChartStyle.ShowVerticalGridLines Then
            Dim i As Integer = Width - gridScrollOffset

            While i >= 0
                g.DrawLine(_plotChartStyle.VerticalGridPen.Pen, i, 0, i, Height)
                i -= GRID_SPACING
            End While
        End If

        If _plotChartStyle.ShowHorizontalGridLines Then
            Dim i As Integer = 0

            While i < Height
                g.DrawLine(_plotChartStyle.HorizontalGridPen.Pen, 0, i, Width, i)
                i += GRID_SPACING
            End While
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        If _plotChartStyle.AntiAliasing Then e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        DrawBackgroundAndGrid(e.Graphics)
        DrawChart(e.Graphics)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub

    Private Sub colorSet_ColorSetChanged(ByVal sender As Object, ByVal e As EventArgs)
        Invalidate()
    End Sub

    Public Sub UpdateControl()
        Select Case _sensor
            Case eSensorType.CPUTemperatureC
                AddValue(myParentForm.cpuSensor.RawTemperatureC, "°C")
            Case eSensorType.CPUTemperatureF
                AddValue(myParentForm.cpuSensor.RawTemperatureF, "°F")
            Case eSensorType.CPULoadPercent
                AddValue(myParentForm.cpuSensor.RawLoadPercent, "%")

            Case eSensorType.GPUTemperatureC
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.gpuSensor.RawTemperatureC(CInt(_sensorParam)), "°C")
                Else
                    AddValue(myParentForm.gpuSensor.RawTemperatureC, "°C")
                End If
            Case eSensorType.GPUTemperatureF
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.gpuSensor.RawTemperatureF(CInt(_sensorParam)), "°F")
                Else
                    AddValue(myParentForm.gpuSensor.RawTemperatureF, "°F")
                End If
            Case eSensorType.GPULoadPercent
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.gpuSensor.RawLoadPercent(CInt(_sensorParam)), "%")
                Else
                    AddValue(myParentForm.gpuSensor.RawLoadPercent, "%")
                End If
            Case eSensorType.GPUMemoryPercent
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.gpuSensor.RawMemoryPercent(CInt(_sensorParam)), "%")
                Else
                    AddValue(myParentForm.gpuSensor.RawMemoryPercent, "%")
                End If
            Case eSensorType.GPUVRAMUsage
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.gpuSensor.RawVRAMUsage(CInt(_sensorParam)), " MB")
                Else
                    AddValue(myParentForm.gpuSensor.RawVRAMUsage, " MB")
                End If

            Case eSensorType.RAMLoadPercent
                AddValue(myParentForm.ramSensor.RawLoadPercent, "%")
            Case eSensorType.RAMUsage
                AddValue(myParentForm.ramSensor.RawRAMUsage, " GB")
            Case eSensorType.RAMAvailable
                AddValue(myParentForm.ramSensor.RawRAMAvailable, " GB")

            Case eSensorType.HDDTemperatureC
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.hddsensor.RawTemperatureC(CInt(_sensorParam)), "°C")
                Else
                    AddValue(myParentForm.hddsensor.RawTemperatureC, "°C")
                End If
            Case eSensorType.HDDTemperatureF
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.hddsensor.RawTemperatureF(CInt(_sensorParam)), "°C")
                Else
                    AddValue(myParentForm.hddsensor.RawTemperatureF, "°C")
                End If
            Case eSensorType.HDDLoadPercent
                If IsNumeric(_sensorParam) Then
                    AddValue(myParentForm.hddsensor.RawLoadPercent(CInt(_sensorParam)), "%")
                Else
                    AddValue(myParentForm.hddsensor.RawLoadPercent, "%")
                End If
            Case eSensorType.HDDUsage
                If String.IsNullOrEmpty(_sensorParam) Then
                    AddValue(myParentForm.hddsensor.RawDiskTotalFreeSpace, " GB")
                Else
                    AddValue(myParentForm.hddsensor.RawDiskTotalFreeSpace(CStr(_sensorParam)), " GB")
                End If

            Case eSensorType.DownloadSpeed
                AddValue(myParentForm.netSensor.RawDownloadSpeed, " KB/s")
            Case eSensorType.UploadSpeed
                AddValue(myParentForm.netSensor.RawUploadSpeed, " KB/s")
            Case eSensorType.Ping
                If String.IsNullOrEmpty(_sensorParam) Then
                    AddValue(myParentForm.netSensor.RawPing, " ms")
                Else
                    AddValue(myParentForm.netSensor.RawPing(CStr(_sensorParam)), " ms")
                End If
        End Select
    End Sub

End Class

Public Enum ScaleMode
    Absolute
    Relative
End Enum