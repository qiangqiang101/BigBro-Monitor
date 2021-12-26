Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Reflection
Imports Echevil
Imports OpenHardwareMonitor.Hardware

Public Class frmMonitor

    Private backgroundImageIsGif As Boolean = False, currentAnimating As Boolean = False, animatedGif As Image
    Private ReadOnly computer As New Computer() With {.CPUEnabled = True, .GPUEnabled = True, .HDDEnabled = True, .FanControllerEnabled = True, .MainboardEnabled = True, .RAMEnabled = True}
    Dim running As Boolean = False
    Public cpuSensor As New CPUSensors(computer), gpuSensor As New GPUSensors(computer), ramSensor As New RAMSensors(computer), hddSensor As New HDDSensors(computer), moboSensor As New MainboardSensor(computer)
    Private ReadOnly netMonitor As New NetworkMonitor
    Public netSensor As New NetworkSensor

    Public httpServer As HttpServer
    Public rs As New Resizer

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Public Editing As Boolean = False
    Public CurrentTheme As ThemeData

    Private Sub Updater_Tick(sender As Object, e As EventArgs) Handles Updater.Tick
        rs.FindAllControls(Me)

        Monitor()
        If UserSettings.EnableBroadcast Then snapshots = Me.TakeScreenShot.ImageToBase64(ImageFormat.Jpeg, Base64FormattingOptions.None)

        For Each control As Object In Controls
            If control.Tag = "ThemeControl" Then
                control.UpdateControl()
                If control.Controls.Count <> 0 Then UpdateChildControl(control)
            End If
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

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        netMonitor.StartMonitoring()
        Updater.Start()

        If Not Me.Editing Then
            Location = UserSettings.Location
            TopMost = UserSettings.TopMost

            If UserSettings.EnableBroadcast Then
                httpServer = New HttpServer(UserSettings.BroadcastPort)
            End If
        End If
    End Sub

    Private Sub frmMonitor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If running Then
            For Each control As Control In Controls
                If control.GetType = GetType(Youtube) Then
                    Dim yt As Youtube = CType(control, Youtube)
                    yt.StopPlayer()
                End If
            Next
            computer.Close()
            netMonitor.StopMonitoring()
            If UserSettings.EnableBroadcast Then httpServer.Stop()
            running = False
            Updater.Stop()
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If Not Me.Editing Then
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
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If Not Me.Editing Then
            If e.Button = MouseButtons.Right Then
                IsFormBeingDragged = True
                MouseDownX = e.X
                MouseDownY = e.Y
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If Not Me.Editing Then
            If e.Button = MouseButtons.Right Then
                IsFormBeingDragged = False
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If IsFormBeingDragged Then
            Dim temp As New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)

            Me.Location = temp
            temp = Nothing

            CorrectBounds(Me, Screen.FromControl(Me).Bounds)
        End If
    End Sub

    Private Sub AnimateImage()
        If Not currentAnimating Then
            animatedGif = BackgroundImage
            ImageAnimator.Animate(animatedGif, New EventHandler(AddressOf OnFrameChanged))
            currentAnimating = True
        End If
    End Sub

    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)
        Invalidate()
        Threading.Thread.Sleep(20)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If backgroundImageIsGif Then
            AnimateImage()
            ImageAnimator.UpdateFrames()

            e.Graphics.DrawImage(animatedGif, New Point(0, 0))

            MyBase.OnPaint(e)
        End If

        MyBase.OnPaintBackground(e)
    End Sub

    Private Sub frmMonitor_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        If Not Editing Then
            Dim newUserSettings As New UserSettingData(UserSettingFile)
            With newUserSettings
                .CurrentTheme = UserSettings.CurrentTheme
                .AutoStart = UserSettings.AutoStart
                .Location = Location
                .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
                .EnableBroadcast = UserSettings.EnableBroadcast
                .BroadcastPort = UserSettings.BroadcastPort
                .State = UserSettings.State
                .Town = UserSettings.Town
                .TopMost = UserSettings.TopMost
                .LicenseKey = UserSettings.LicenseKey
                .HWID = UserSettings.HWID
                .Language = UserSettings.Language
                .SaveSilent()
            End With
            UserSettings = New UserSettingData(UserSettingFile).Instance
        End If
    End Sub

    Private Sub frmMonitor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me, Width, Height)
    End Sub

    Private Sub frmMonitor_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged
        Try
            If BackgroundImage.RawFormat.Equals(ImageFormat.Gif) Then
                backgroundImageIsGif = True
            Else
                backgroundImageIsGif = False
            End If
        Catch ex As Exception
            backgroundImageIsGif = False
        End Try
    End Sub
End Class
