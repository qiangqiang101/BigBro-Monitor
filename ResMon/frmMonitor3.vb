Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports Echevil
Imports OpenHardwareMonitor.Hardware

Public Class frmMonitor3

    Private ReadOnly computer As New Computer() With {.CPUEnabled = True, .GPUEnabled = True, .HDDEnabled = True, .FanControllerEnabled = True, .MainboardEnabled = True, .RAMEnabled = True}
    Dim running As Boolean = False
    Public cpuSensor As New CPUSensors(computer), gpuSensor As New GPUSensors(computer), ramSensor As New RAMSensors(computer), hddSensor As New HDDSensors(computer), moboSensor As New MainboardSensor(computer)
    Private ReadOnly netMonitor As New NetworkMonitor
    Public netSensor As New NetworkSensor, displaySensor As New DisplaySensor
    Public httpServer As HttpServer
    Public rs As New Resizer

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Public Editing As Boolean = False
    Public CurrentTheme As WebThemeData

    Private _htmlsensors As List(Of WebSensors)
    Public Property HtmlWebSensors() As List(Of WebSensors)
        Get
            Return _htmlsensors
        End Get
        Set(value As List(Of WebSensors))
            _htmlsensors = value
        End Set
    End Property

    Private Sub frmMonitor3_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Try
            Dim newUserSettings As New UserSettingData(UserSettingFile)
            With newUserSettings
                .CurrentTheme = UserSettings.CurrentTheme
                .AutoStart = UserSettings.AutoStart
                .Location = UserSettings.Location
                .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
                .EnableBroadcast = UserSettings.EnableBroadcast
                .BroadcastPort = UserSettings.BroadcastPort
                .State = UserSettings.State
                .Town = UserSettings.Town
                .TopMost = UserSettings.TopMost
                .LicenseKey = UserSettings.LicenseKey
                .Email = UserSettings.Email
                .HWID = UserSettings.HWID
                .Language = UserSettings.Language
                .AudioEffectHighQuality = UserSettings.AudioEffectHighQuality
                .RgbEffectHighQuality = UserSettings.RgbEffectHighQuality
                .SecondScreen = UserSettings.SecondScreen
                .SecondScreenYT = UserSettings.SecondScreenYT
                .SecondScreenLocation = Location
                .SecondScreenSize = UserSettings.SecondScreenSize
                .SaveSilent()
            End With
            UserSettings = New UserSettingData(UserSettingFile).Instance
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pMove_MouseDown(sender As Object, e As MouseEventArgs) Handles pMove.MouseDown
        If e.Button = MouseButtons.Right Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pMove_MouseUp(sender As Object, e As MouseEventArgs) Handles pMove.MouseUp
        If e.Button = MouseButtons.Right Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub pMove_MouseMove(sender As Object, e As MouseEventArgs) Handles pMove.MouseMove
        If IsFormBeingDragged Then
            Dim temp As New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)

            Me.Location = temp
            temp = Nothing

            CorrectBounds(Me, Screen.FromControl(Me).Bounds)
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Left Then
            Location = New Point(Location.X - 1, Location.Y)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Up Then
            Location = New Point(Location.X, Location.Y - 1)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Right Then
            Location = New Point(Location.X + 1, Location.Y)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Down Then
            Location = New Point(Location.X, Location.Y + 1)
        End If
    End Sub

    Private Async Sub frmMonitor3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Location = UserSettings.SecondScreenLocation
        TopMost = UserSettings.TopMost
        Size = UserSettings.SecondScreenSize

        Await webView.EnsureCoreWebView2Async()
        Dim ytid As String = UserSettings.SecondScreenYT
        webView.NavigateToString(CurrentTheme.Html.Base64ToString)
    End Sub

    Public Sub StopPlayer()
        Try
            webView.Source = New Uri("about:blank")
            Controls.Remove(webView)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub

    Private Sub frmMonitor3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        StopPlayer()
    End Sub

    Private Sub Updater_Tick(sender As Object, e As EventArgs) Handles Updater.Tick
        If Not bwUpdater.IsBusy Then bwUpdater.RunWorkerAsync()
    End Sub

    Private Sub bwUpdater_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwUpdater.DoWork
        rs.FindAllControls(Me)

        Monitor()
        If UserSettings.EnableBroadcast Then snapshots = Me.TakeScreenShot.ImageToBase64(ImageFormat.Jpeg, Base64FormattingOptions.None)


        For Each webSensor As WebSensors In HtmlWebSensors
            Select Case webSensor.Name
                'CPU
                Case "CPUCoreCount"
                    webSensor.Value = cpuSensor.CoreCount
                Case "CPUClockSpeed"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = Math.Ceiling(cpuSensor.RawClockSpeed(webSensor.Param))
                    Else
                        webSensor.Value = Math.Ceiling(cpuSensor.RawClockSpeed)
                    End If
                    webSensor.Unit = "MHz"
                Case "CPUTemperature"
                    If webSensor.Param = "C" Then
                        webSensor.Value = cpuSensor.RawTemperatureC
                        webSensor.Unit = "°C"
                    Else
                        webSensor.Value = cpuSensor.RawTemperatureF
                        webSensor.Unit = "°F"
                    End If
                Case "CPULoadPercent"
                    webSensor.Value = cpuSensor.RawLoadPercent
                    webSensor.Unit = "%"
                Case "CPUPowerWattage"
                    webSensor.Value = Math.Round(cpuSensor.RawPowerWattage, 2)
                    webSensor.Unit = "W"
                Case "CPUCorePower"
                    webSensor.Value = Math.Round(cpuSensor.RawCorePower, 2)
                    webSensor.Unit = "W"
                Case "CPUGraphicPower"
                    webSensor.Value = Math.Round(cpuSensor.RawGraphicPower, 2)
                    webSensor.Unit = "W"
                Case "RawDRAMPower"
                    webSensor.Value = Math.Round(cpuSensor.RawDRAMPower, 2)
                    webSensor.Unit = "W"
                Case "CPUBusSpeed"
                    webSensor.Value = Math.Ceiling(cpuSensor.RawBusClockSpeed)
                    webSensor.Unit = "MHz"
                Case "CPUCoreTemperatureC"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = cpuSensor.RawCoreTemperatureC(webSensor.Param)
                    Else
                        webSensor.Value = cpuSensor.RawCoreTemperatureC()
                    End If
                    webSensor.Unit = "°C"
                Case "CPUCoreTemperatureF"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = cpuSensor.RawCoreTemperatureF(webSensor.Param)
                    Else
                        webSensor.Value = cpuSensor.RawCoreTemperatureF()
                    End If
                    webSensor.Unit = "°F"

                    'GPU
                Case "GPUClockSpeed"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = Math.Ceiling(gpuSensor.RawClockSpeed(webSensor.Param))
                    Else
                        webSensor.Value = Math.Ceiling(gpuSensor.RawClockSpeed)
                    End If
                    webSensor.Unit = "MHz"
                Case "GPUTemperatureC"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawTemperatureC(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawTemperatureC()
                    End If
                    webSensor.Unit = "°C"
                Case "GPUTemperatureF"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawTemperatureF(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawTemperatureF()
                    End If
                    webSensor.Unit = "°F"
                Case "GPULoadPercent"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawLoadPercent(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawLoadPercent
                    End If
                    webSensor.Unit = "%"
                Case "GPUMemoryPercent"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawMemoryPercent(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawMemoryPercent
                    End If
                    webSensor.Unit = "%"
                Case "GPUPowerWattage"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = Math.Round(gpuSensor.RawPowerWattage(webSensor.Param), 2)
                    Else
                        webSensor.Value = Math.Round(gpuSensor.RawPowerWattage, 2)
                    End If
                    webSensor.Unit = "W"
                Case "GPUVRAMUsage"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawVRAMUsage(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawVRAMUsage
                    End If
                    webSensor.Unit = "MB"
                Case "GPUFan"
                    If String.IsNullOrEmpty(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawFanSpeed
                    Else
                        webSensor.Value = gpuSensor.RawFanSpeed(webSensor.Param)
                    End If
                    webSensor.Unit = "RPM"
                Case "GPUMemoryClock"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = Math.Ceiling(gpuSensor.RawMemoryClock(webSensor.Param))
                    Else
                        webSensor.Value = Math.Ceiling(gpuSensor.RawMemoryClock)
                    End If
                    webSensor.Unit = "MHz"
                Case "GPUShaderClock"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawFrameBufferLoad(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawFrameBufferLoad
                    End If
                    webSensor.Unit = "MHz"
                Case "GPUFrameBufferLoad"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawFrameBufferLoad(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawFrameBufferLoad
                    End If
                    webSensor.Unit = "%"
                Case "GPUVideoEngineLoad"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawVideoEngineLoad(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawVideoEngineLoad
                    End If
                    webSensor.Unit = "%"
                Case "GPUBusInterfaceLoad"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawBusInterfaceLoad(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawBusInterfaceLoad
                    End If
                    webSensor.Unit = "%"
                Case "GPUVRAMFree"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawVRAMFree(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawVRAMFree
                    End If
                    webSensor.Unit = "MB"
                Case "GPUVRAMTotal"
                    If IsNumeric(webSensor.Param) Then
                        webSensor.Value = gpuSensor.RawVRAMTotal(webSensor.Param)
                    Else
                        webSensor.Value = gpuSensor.RawVRAMTotal
                    End If
                    webSensor.Unit = "MB"

                    'RAM
                Case ""
            End Select
        Next

        If Not Me.Editing Then
            If Me.Width <> CurrentTheme.Size.Width Then Me.Width = CurrentTheme.Size.Width
            If Me.Height <> CurrentTheme.Size.Height Then Me.Height = CurrentTheme.Size.Height
        End If
    End Sub

    Private Sub UpdateChildControl(child As Control)
        For Each control As Object In child.Controls
            If control.Tag = "ThemeControl" Then
                control.UpdateControl()
                If control.Controls.Count <> 0 Then UpdateChildControl(control)
            End If
        Next
    End Sub

    Public Property UpdateInterval() As Integer
        Get
            Return Updater.Interval
        End Get
        Set(value As Integer)
            Updater.Interval = value
        End Set
    End Property

    Private Sub Monitor()
        Try
            computer.Open()
            running = True

            netSensor.Adapter = netMonitor.Adapters(UserSettings.NetworkAdapterIndex)

            For Each hardware In computer.Hardware
                Select Case hardware.HardwareType
                    Case HardwareType.CPU
                        hardware.Update()
                        For Each sensor In hardware.Sensors
                            Select Case sensor.SensorType
                                Case SensorType.Clock
                                    cpuSensor.Clock.Add(sensor)
                                Case SensorType.Temperature
                                    cpuSensor.Temperature.Add(sensor)
                                Case SensorType.Load
                                    cpuSensor.Load.Add(sensor)
                                Case SensorType.Power
                                    cpuSensor.Power.Add(sensor)
                            End Select
                        Next

                    Case HardwareType.GpuNvidia, HardwareType.GpuAti
                        hardware.Update()
                        For Each sensor In hardware.Sensors
                            Select Case sensor.SensorType
                                Case SensorType.Clock
                                    gpuSensor.Clock.Add(sensor)
                                Case SensorType.Control
                                    gpuSensor.Control.Add(sensor)
                                Case SensorType.Data
                                    gpuSensor.Data.Add(sensor)
                                Case SensorType.Fan
                                    gpuSensor.Fan.Add(sensor)
                                Case SensorType.Load
                                    gpuSensor.Load.Add(sensor)
                                Case SensorType.Power
                                    gpuSensor.Power.Add(sensor)
                                Case SensorType.Temperature
                                    gpuSensor.Temperature.Add(sensor)
                                Case SensorType.Throughput
                                    gpuSensor.Throughput.Add(sensor)
                            End Select
                        Next
                    Case HardwareType.RAM
                        hardware.Update()
                        For Each sensor In hardware.Sensors
                            Select Case sensor.SensorType
                                Case SensorType.Data
                                    ramSensor.Data.Add(sensor)
                                Case SensorType.Load
                                    ramSensor.Load.Add(sensor)
                            End Select
                        Next
                    Case HardwareType.HDD
                        hardware.Update()
                        For Each sensor In hardware.Sensors
                            Select Case sensor.SensorType

                                Case SensorType.Data
                                    hddSensor.Data.Add(sensor)
                                Case SensorType.Load
                                    hddSensor.Load.Add(sensor)
                                Case SensorType.Temperature
                                    hddSensor.Temperature.Add(sensor)
                            End Select
                        Next

                    Case HardwareType.Mainboard
                        Try
                            hardware.Update()
                            If hardware.SubHardware.Count <> 0 Then
                                hardware.SubHardware.FirstOrDefault.Update()

                                For Each sensor In hardware.SubHardware.FirstOrDefault.Sensors
                                    Select Case sensor.SensorType
                                        Case SensorType.Temperature
                                            moboSensor.Temperature.Add(sensor)
                                        Case SensorType.Fan
                                            moboSensor.Fans.Add(sensor)
                                    End Select
                                Next
                            End If
                        Catch ex As Exception
                            'diam diam ya
                        End Try
                End Select
            Next

        Catch ex As Exception
            Logger.Log(ex)
            computer.Open()
        End Try
    End Sub

End Class