﻿Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class TextLabel
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

    Private _userMode As Boolean
    <Category("Behavior")>
    Public Property AllowUserEdit() As Boolean
        Get
            Return _userMode
        End Get
        Set(value As Boolean)
            _userMode = value
        End Set
    End Property

    Private _b4Text As String
    <Category("Appearance")>
    Public Property BeforeText() As String
        Get
            Return _b4Text
        End Get
        Set(value As String)
            _b4Text = value
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        AutoSize = True
        TextAlign = ContentAlignment.MiddleCenter
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
                    Text = _b4Text & myParentForm.cpuSensor.CoreCount

                    'Modified 05/02/2022
                Case eSensorType.CPUClockSpeed
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.cpuSensor.ClockSpeed(_sensorParam)
                    Else
                        Text = _b4Text & myParentForm.cpuSensor.ClockSpeed
                    End If

                Case eSensorType.CPUTemperatureC
                    Text = _b4Text & myParentForm.cpuSensor.TemperatureC
                Case eSensorType.CPUTemperatureF
                    Text = _b4Text & myParentForm.cpuSensor.TemperatureF
                Case eSensorType.CPULoadPercent
                    Text = _b4Text & myParentForm.cpuSensor.LoadPercent
                Case eSensorType.CPUPowerWattage
                    Text = _b4Text & myParentForm.cpuSensor.PowerWattage

                Case eSensorType.GPUClockSpeed
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.ClockSpeed(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.ClockSpeed
                    End If
                Case eSensorType.GPUTemperatureC
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.TemperatureC(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.TemperatureC
                    End If
                Case eSensorType.GPUTemperatureF
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.TemperatureF(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.TemperatureF
                    End If
                Case eSensorType.GPULoadPercent
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.LoadPercent(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.LoadPercent
                    End If
                Case eSensorType.GPUMemoryPercent
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.MemoryPercent(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.MemoryPercent
                    End If
                Case eSensorType.GPUPowerWattage
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.PowerWattage(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.PowerWattage
                    End If
                Case eSensorType.GPUVRAMUsage
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.VRAMUsage(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.VRAMUsage
                    End If
                Case eSensorType.GPUFan
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.FanSpeed
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.FanSpeed(CInt(_sensorParam))
                    End If

                Case eSensorType.RAMLoadPercent
                    Text = _b4Text & myParentForm.ramSensor.LoadPercent
                Case eSensorType.RAMUsage
                    Text = _b4Text & myParentForm.ramSensor.RAMUsage
                Case eSensorType.RAMAvailable
                    Text = _b4Text & myParentForm.ramSensor.RAMAvailable
                Case eSensorType.RAMTotal
                    Text = _b4Text & myParentForm.ramSensor.RAMTotal

                Case eSensorType.HDDTemperatureC
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.TemperatureC(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.hddSensor.TemperatureC
                    End If
                Case eSensorType.HDDTemperatureF
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.TemperatureF(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.hddSensor.TemperatureF
                    End If
                Case eSensorType.HDDLoadPercent
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.LoadPercent(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.hddSensor.LoadPercent
                    End If
                Case eSensorType.HDDTotalSize
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.DiskTotalSize
                    Else
                        Text = _b4Text & myParentForm.hddSensor.DiskTotalSize(CStr(_sensorParam))
                    End If
                Case eSensorType.HDDTotalFreeSpace
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.DiskTotalFreeSpace
                    Else
                        Text = _b4Text & myParentForm.hddSensor.DiskTotalFreeSpace(CStr(_sensorParam))
                    End If
                Case eSensorType.HDDUsage
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.hddSensor.DiskUsage
                    Else
                        Text = _b4Text & myParentForm.hddSensor.DiskUsage(CStr(_sensorParam))
                    End If

                Case eSensorType.DownloadSpeed
                    Text = _b4Text & myParentForm.netSensor.DownloadSpeed
                Case eSensorType.UploadSpeed
                    Text = _b4Text & myParentForm.netSensor.UploadSpeed
                Case eSensorType.Ping
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.netSensor.Ping
                    Else
                        Text = _b4Text & myParentForm.netSensor.Ping(CStr(_sensorParam))
                    End If

                Case eSensorType.LongDate
                    Text = _b4Text & Now.ToLongDateString
                Case eSensorType.ShortDate
                    Text = _b4Text & Now.ToShortDateString
                Case eSensorType.LongTime
                    Text = _b4Text & Now.ToLongTimeString
                Case eSensorType.ShortTime
                    Text = _b4Text & Now.ToShortTimeString
                Case eSensorType.CustomDateTime
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & Now.ToString
                    Else
                        Text = _b4Text & Now.ToString(_sensorParam)
                    End If

                Case eSensorType.MoboTemperatureC
                    Text = _b4Text & myParentForm.moboSensor.TemperatureC
                Case eSensorType.MoboTemperatureF
                    Text = _b4Text & myParentForm.moboSensor.TemperatureF
                Case eSensorType.MoboFan
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & myParentForm.moboSensor.FanSpeed
                    Else
                        Text = _b4Text & myParentForm.moboSensor.FanSpeed(_sensorParam)
                    End If

                Case eSensorType.CPUFan
                    Text = _b4Text & myParentForm.moboSensor.FanSpeed(CInt(_sensorParam))

                    'Add 13/01/2022
                Case eSensorType.CPUCorePower
                    Text = _b4Text & myParentForm.cpuSensor.CorePower
                Case eSensorType.CPUGraphicPower
                    Text = _b4Text & myParentForm.cpuSensor.GraphicPower
                Case eSensorType.CPUDRAMPower
                    Text = _b4Text & myParentForm.cpuSensor.DRAMPower

                Case eSensorType.GPUMemoryClock
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.MemoryClock(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.MemoryClock
                    End If
                Case eSensorType.GPUShaderClock
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.ShaderClock(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.ShaderClock
                    End If
                Case eSensorType.GPUFrameBufferLoad
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.FrameBufferLoad(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.FrameBufferLoad
                    End If
                Case eSensorType.GPUVideoEngineLoad
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.VideoEngineLoad(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.VideoEngineLoad
                    End If
                Case eSensorType.GPUBusInterfaceLoad
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.BusInterfaceLoad(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.BusInterfaceLoad
                    End If
                Case eSensorType.GPUVRAMFree
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.VRAMFree(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.VRAMFree
                    End If
                Case eSensorType.GPUVRAMTotal
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.gpuSensor.VRAMTotal(CInt(_sensorParam))
                    Else
                        Text = _b4Text & myParentForm.gpuSensor.VRAMTotal
                    End If

                    'Added 15/01/2022
                Case eSensorType.DisplayScreenResolution
                    Text = _b4Text & myParentForm.displaySensor.ScreenResolution
                Case eSensorType.DisplayRefreshRate
                    Text = _b4Text & myParentForm.displaySensor.RefreshRate

                    'Added 04/02/2022
                Case eSensorType.RAMClockSpeed
                    Text = _b4Text & myParentForm.ramSensor.RamClockSpeed
                Case eSensorType.RAMVirtualUsage
                    Text = _b4Text & myParentForm.ramSensor.VirtualMemoryUsage
                Case eSensorType.RAMVirtualAvailable
                    Text = _b4Text & myParentForm.ramSensor.VirtualMemoryAvailable
                Case eSensorType.RAMVirtualTotal
                    Text = _b4Text & myParentForm.ramSensor.VirtualMemoryTotal
                Case eSensorType.SystemUptime
                    If String.IsNullOrEmpty(_sensorParam) Then
                        Text = _b4Text & GetSystemUpTime.ToString("d\.h\:mm\:ss")
                    Else
                        Text = _b4Text & GetSystemUpTime.ToString(_sensorParam)
                    End If

                    'Added 05/02/2022
                Case eSensorType.CPUBusSpeed
                    Text = _b4Text & myParentForm.cpuSensor.BusClockSpeed
                Case eSensorType.CPUCoreTemperatureC
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.cpuSensor.CoreTemperatureC(_sensorParam)
                    Else
                        Text = _b4Text & myParentForm.cpuSensor.CoreTemperatureC
                    End If
                Case eSensorType.CPUCoreTemperatureF
                    If IsNumeric(_sensorParam) Then
                        Text = _b4Text & myParentForm.cpuSensor.CoreTemperatureF(_sensorParam)
                    Else
                        Text = _b4Text & myParentForm.cpuSensor.CoreTemperatureF
                    End If

                    'Added 08/04/2022
                Case eSensorType.DisplayFramerate
                    Text = _b4Text & myParentForm.displaySensor.Framerate()
                Case eSensorType.DisplayFrametime
                    Text = _b4Text & myParentForm.displaySensor.Frametime()

                    'Added 26/02/2023
                Case eSensorType.WeatherTempC
                    Text = $"{Helper.openMeteo.Temperature} °C"
                Case eSensorType.WeatherTempF
                    Text = $"{((Helper.openMeteo.Temperature * 1.8) + 32)} °F"
                Case eSensorType.WeatherName
                    Text = Helper.openMeteo.WeatherName
                Case eSensorType.WeatherCode
                    Text = Helper.openMeteo.WeatherCode
                Case eSensorType.WeatherWindSpeedKmh
                    Text = $"{Helper.openMeteo.WindSpeed} Km/h"
                Case eSensorType.WeatherWindSpeedMph
                    Text = $"{Helper.openMeteo.WindSpeed / 1.609} Mph"
                Case eSensorType.WeatherWindDirection
                    Text = $"{Helper.openMeteo.WindDirection} °"
            End Select
        Catch ex As Exception
            Logger.Log(ex)
        End Try
    End Sub

End Class
