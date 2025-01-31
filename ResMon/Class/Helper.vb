﻿Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Net.Cache
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports MaterialSkin
Imports Newtonsoft.Json.Linq

Module Helper

    Public test As Boolean = False
    Public dateFormat As String = "dd/MMM/yyyy"
    Public ThemesDir As String = $"{My.Application.Info.DirectoryPath}\Themes"
    Public PresetDataDir As String = $"{My.Application.Info.DirectoryPath}\Presets"
    Public FontsDir As String = $"{My.Application.Info.DirectoryPath}\Fonts"
    Public LogsDir As String = $"{My.Application.Info.DirectoryPath}\Logs"
    Public LangsDir As String = $"{My.Application.Info.DirectoryPath}\Languages"
    Public UserSettingFile As String = $"{My.Computer.FileSystem.SpecialDirectories.MyDocuments}\BigBro Monitor\UserSettings.bin"
    Public OldUserSettingFile As String = $"{My.Application.Info.DirectoryPath}\UserSettings.bin"
    Public UserSettings As UserSettingData = New UserSettingData(UserSettingFile).Instance
    Public ProgramLanguage As LanguageData = New LanguageData(Path.Combine(LangsDir, $"{UserSettings.Language}.xml")).Instance
    Public key As New DESCryptoServiceProvider()
    Public PrivateFonts As New PrivateFontCollection()
    Public SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
    Public openMeteo As OpenMeteo

    Public snapshots As String

    Public Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            Return My.User.Name
        End If
    End Function

    Public Function GetSpeedUnit(bite As ULong) As String
        Try
            Select Case bite
                Case Is >= 1099511627776
                    Return "TB/s"
                Case 1073741824 To 1099511627775
                    Return "GB/s"
                Case 1048576 To 1073741823
                    Return "MB/s"
                Case 0 To 1048575
                    Return "KB/s"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Public Function GetSpeed(bite As ULong) As String
        Dim DoubleBytes As Double

        Try
            Select Case bite
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(bite / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB/s"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(bite / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB/s"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(bite / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB/s"
                Case 0 To 1048575
                    DoubleBytes = CDbl(bite / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB/s"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Public Function GetDiskSizeUnit(bite As ULong) As String
        Try
            Select Case bite
                Case Is >= 1099511627776
                    Return "TB"
                Case 1073741824 To 1099511627775
                    Return "GB"
                Case 1048576 To 1073741823
                    Return "MB"
                Case 1024 To 1048575
                    Return "KB"
                Case 0 To 1023
                    Return "bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Public Function GetDiskSize(bite As ULong) As String
        Dim DoubleBytes As Double

        Try
            Select Case bite
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(bite / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(bite / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(bite / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(bite / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = bite ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Public Function ByteToGiga(bite As ULong) As Integer
        Dim DoubleBytes As Double

        Try
            DoubleBytes = CDbl(bite / 1073741824) 'GB
            Return CInt(DoubleBytes)
        Catch
            Return 0
        End Try
    End Function

    <Extension>
    Public Function Base64ToImage(Image As String) As Image
        Try
            If Image = Nothing Then
                Return Nothing
            Else
                Dim b64 As String = Image.Replace(" ", "+")
                Dim bite() As Byte = Convert.FromBase64String(b64)
                Dim stream As New MemoryStream(bite)
                Return Drawing.Image.FromStream(stream)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ImageToBase64(img As Image, Optional forceFormat As ImageFormat = Nothing, Optional formatting As Base64FormattingOptions = Base64FormattingOptions.InsertLineBreaks) As String
        Try
            If forceFormat Is Nothing Then forceFormat = img.RawFormat
            Dim stream As New MemoryStream
            img.Save(stream, forceFormat)
            Return Convert.ToBase64String(stream.ToArray, formatting)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ToBase64(text As String) As String
        If text = Nothing Then Return text

        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text)
        Return Convert.ToBase64String(plainTextBytes)
    End Function

    <Extension>
    Public Function Base64ToString(base64 As String) As String
        If base64 = Nothing Then Return base64

        Try
            Dim base64Bytes = Convert.FromBase64String(base64)
            Return Text.Encoding.UTF8.GetString(base64Bytes)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    <Extension>
    Public Function TakeScreenShot(ByVal form As Form) As Bitmap
        Dim Screenshot As New Bitmap(form.Width, form.Height)
        form.DrawToBitmap(Screenshot, New Rectangle(0, 0, form.Width, form.Height))
        Return Screenshot
    End Function

    Public Function IsAdministrator() As Boolean
        Return (New WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Sub RestarAsAdministrator(arg As String)
        Dim psi As New ProcessStartInfo(Path.Combine(Application.StartupPath, $"{Application.ExecutablePath}"), arg) With {.WorkingDirectory = Application.StartupPath, .Verb = "runas"}
        Process.Start(psi)
    End Sub

    Public Function CalculateCenter(formSize As Size, controlSize As Size) As Point
        Dim result As New Point((formSize.Width / 2) - (controlSize.Width / 2), (formSize.Height / 2) - (controlSize.Height / 2))
        If result.X < 0 Then result.X = 0
        If result.Y < 0 Then result.Y = 0
        Return result
    End Function

    Public Function ControlsCanFit(controlSize As Size, panelSize As Size) As Integer
        Dim x As Integer = Math.Floor(panelSize.Width / controlSize.Width)
        Dim y As Integer = Math.Floor(panelSize.Height / controlSize.Height)
        Return x * y
    End Function

    Public Sub CorrectBounds(ByVal parent As Form, ByVal bounds As Rectangle)
        Dim X As Integer = parent.Location.X
        Dim Y As Integer = parent.Location.Y

        If X < bounds.X Then
            X = bounds.X
        End If
        If Y < bounds.Y Then
            Y = bounds.Y
        End If

        Dim Width As Integer = bounds.X + bounds.Width
        Dim Height As Integer = bounds.Y + bounds.Height

        If X + parent.Width > Width Then
            X = Width - parent.Width
        End If
        If Y + parent.Height > Height Then
            Y = Height - parent.Height
        End If

        parent.Location = New Point(X, Y)
    End Sub

    Public Function GetBuildDateTime() As Date
        Return File.GetLastWriteTime(Path.Combine(Application.StartupPath, Application.ExecutablePath))
    End Function

    <Extension>
    Public Sub DrawRoundedRectangle(ByVal g As Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal p As Pen)
        Dim mode As SmoothingMode = g.SmoothingMode
        Dim iMode As InterpolationMode = g.InterpolationMode
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.High
        g.DrawArc(p, r.X, r.Y, d, d, 180, 90)
        g.DrawLine(p, CInt(r.X + d / 2), r.Y, CInt(r.X + r.Width - d / 2), r.Y)
        g.DrawArc(p, r.X + r.Width - d, r.Y, d, d, 270, 90)
        g.DrawLine(p, r.X, CInt(r.Y + d / 2), r.X, CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + r.Width), CInt(r.Y + d / 2), CInt(r.X + r.Width), CInt(r.Y + r.Height - d / 2))
        g.DrawLine(p, CInt(r.X + d / 2), CInt(r.Y + r.Height), CInt(r.X + r.Width - d / 2), CInt(r.Y + r.Height))
        g.DrawArc(p, r.X, r.Y + r.Height - d, d, d, 90, 90)
        g.DrawArc(p, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        g.SmoothingMode = mode
        g.InterpolationMode = iMode
    End Sub

    <Extension>
    Public Sub FillRoundedRectangle(ByVal g As Graphics, ByVal r As Rectangle, ByVal d As Integer, ByVal b As Brush, corner As RoundedRectCorners)
        Dim mode As SmoothingMode = g.SmoothingMode
        Dim iMode As InterpolationMode = g.InterpolationMode
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.High
        If corner.TopLeft Then g.FillPie(b, r.X, r.Y, d, d, 180, 90)
        If corner.TopRight Then g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90)
        If corner.BottomLeft Then g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90)
        If corner.BottomRight Then g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
        If Not corner.TopLeft Then g.FillRectangle(b, r.X, r.Y, d, d)
        If Not corner.TopRight Then g.FillRectangle(b, r.X + r.Width - d, r.Y, d, d)
        If Not corner.BottomLeft Then g.FillRectangle(b, r.X, r.Y + r.Height - d, d, d)
        If Not corner.BottomRight Then g.FillRectangle(b, r.X + r.Width - d, r.Y + r.Height - d, d, d)
        g.FillRectangle(b, CInt(r.X - 1 + d / 2), r.Y, r.Width + 2 - d, CInt(d / 2))
        g.FillRectangle(b, r.X, CInt(r.Y - 1 + d / 2), r.Width, CInt(r.Height + 2 - d))
        g.FillRectangle(b, CInt(r.X - 1 + d / 2), CInt(r.Y + r.Height - d / 2), CInt(r.Width + 2 - d), CInt(d / 2))
        g.SmoothingMode = mode
        g.InterpolationMode = iMode
    End Sub

    Public Function GetSystemUpTime() As TimeSpan
        Try
            Dim uptime = New PerformanceCounter("System", "System Up Time")
            uptime.NextValue()
            Return TimeSpan.FromSeconds(uptime.NextValue)
        Catch ex As Exception
            'handle the exception your way
            Return New TimeSpan(0, 0, 0, 0)
        End Try
    End Function

End Module

'Public Enum eSensorType
'0     None
'1     CPUCoreCount
'2     CPUClockSpeed
'3     CPUTemperatureC
'4     CPUTemperatureF
'5     CPULoadPercent
'6     CPUPowerWattage
'7     GPUClockSpeed
'8     GPUTemperatureC
'9     GPUTemperatureF
'10    GPULoadPercent
'11    GPUMemoryPercent
'12    GPUPowerWattage
'13    GPUVRAMUsage
'14    RAMLoadPercent
'15    RAMUsage
'16    HDDTemperatureC
'17    HDDTemperatureF
'18    HDDLoadPercent
'19    DownloadSpeed
'20    UploadSpeed
'21    LongDate
'22    ShortDate
'23    LongTime
'24    ShortTime

'25    RAMAvailable
'26    RAMTotal
'27    HDDTotalSize
'28    HDDTotalFreeSpace
'29    HDDUsage
'30    Ping
'31    CustomDateTime

'32    GPUFan
'33    MoboTemperatureC
'34    MoboTemperatureF
'35    MoboFan

'36    CPUFan
'End Enum

Public Enum eSensorType
    None = 0
    CPUCoreCount = 1
    CPUClockSpeed = 2
    CPUTemperatureC = 3
    CPUTemperatureF = 4
    CPULoadPercent = 5
    CPUPowerWattage = 6
    CPUFan = 36
    CPUCorePower = 37
    CPUGraphicPower = 38
    CPUDRAMPower = 39
    CPUBusSpeed = 54
    CPUCoreTemperatureC = 55
    CPUCoreTemperatureF = 56

    GPUClockSpeed = 7
    GPUTemperatureC = 8
    GPUTemperatureF = 9
    GPULoadPercent = 10
    GPUMemoryPercent = 11
    GPUPowerWattage = 12
    GPUVRAMUsage = 13
    GPUFan = 32
    GPUMemoryClock = 40
    GPUShaderClock = 41
    GPUFrameBufferLoad = 42
    GPUVideoEngineLoad = 43
    GPUBusInterfaceLoad = 44
    GPUVRAMFree = 45
    GPUVRAMTotal = 46

    RAMLoadPercent = 14
    RAMUsage = 15
    RAMAvailable = 25
    RAMTotal = 26
    RAMClockSpeed = 49
    RAMVirtualUsage = 50
    RAMVirtualAvailable = 51
    RAMVirtualTotal = 52

    HDDTemperatureC = 16
    HDDTemperatureF = 17
    HDDLoadPercent = 18
    HDDTotalSize = 27
    HDDTotalFreeSpace = 28
    HDDUsage = 29

    DownloadSpeed = 19
    UploadSpeed = 20
    Ping = 30

    LongDate = 21
    ShortDate = 22
    LongTime = 23
    ShortTime = 24
    CustomDateTime = 31
    SystemUptime = 53

    MoboTemperatureC = 33
    MoboTemperatureF = 34
    MoboFan = 35

    DisplayScreenResolution = 47
    DisplayRefreshRate = 48
    DisplayFramerate = 57
    DisplayFrametime

    WeatherTempC
    WeatherTempF
    WeatherName
    WeatherCode
    WeatherWindSpeedKmh
    WeatherWindSpeedMph
    WeatherWindDirection

    'Last Item WeatherWindDirection = 64
End Enum

Public Enum eCompleteSensor
    None
    CPUClockSpeed
    CPUTemperature
    CPULoad
    CPUPowerWattage
    GPUClockSpeed
    GPUTemperature
    GPULoadPercent

    MoboTemperature
    MoboFan
End Enum

Public Enum eTextMode
    None
    Value
    Text
End Enum