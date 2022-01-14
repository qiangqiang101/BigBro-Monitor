Imports System.ComponentModel
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

    Public dateFormat As String = "dd/MMM/yyyy"
    'Public MachineName As String = Environment.MachineName
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
    Public HWID As String = New HardwareID().Generate
    Public IsActivated As Boolean = False
    Public RemainingDays As Integer = 0
    Public SkinManager As MaterialSkinManager = MaterialSkinManager.Instance

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

    Public Function CheckActivation(hwid As String, email As String, Optional retry As Integer = 0) As Tuple(Of Boolean, Integer)
        Dim result As Boolean = False
        Dim [date] As Date = Now
        Dim date2 As Date = Now
        Dim remainDays As Integer = 0
        Dim canLogin As Boolean = False

        Dim query As String = $"https://the.bigbromonitor.com/index.php?a=canuse&hwid={hwid}&product={email}"
        Dim query2 As String = $"https://the.bigbromonitor.com/index.php?a=checkdate&hwid={hwid}"

        If retry > 4 Then
            MsgBox("Unable to connect to License Server after 5 attempts.", MsgBoxStyle.Critical, "Error")
            result = True
        Else
            Try
                Dim wc As New WebClient
                Dim strSource As String = wc.DownloadString(query)
                If strSource.Contains("TRUE") Then
                    strSource = wc.DownloadString(query2)

                    If strSource.Contains(email) Then
                        ' Check the date
                        Dim start As Integer = strSource.IndexOf(email) + email.Length
                        Dim [end] As Integer = strSource.IndexOf(":" + email)
                        Dim datestring = strSource.Substring(start, [end] - start)
                        [date] = DateTime.ParseExact(datestring, "yyyy-MM-dd", Nothing)
                        strSource = wc.DownloadString("http://weltzeit4u.com/Datum/index.php")

                        Dim start2 As Integer = strSource.IndexOf("<span id='gross_fett_blau'>") + 27
                        Dim end2 As Integer = strSource.IndexOf("</span> (arabische")
                        Dim dateToday As String = strSource.Substring(start2, end2 - start2)
                        date2 = DateTime.ParseExact(dateToday, "dd.MM.yyyy", Nothing)
                        If [date] < date2 Then result = True Else canLogin = True
                        If canLogin Then result = True
                        remainDays = [date].Subtract(date2).Days
                    End If
                Else
                    result = False
                End If
            Catch ex As Exception
                Return CheckActivation(hwid, email, retry + 1)
                Logger.Log(ex)
            End Try
        End If

        Return New Tuple(Of Boolean, Integer)(result, remainDays)
    End Function

    Public Function ELSActivateLicense(key As String, hwid As String, email As String, Optional retry As Integer = 0) As Boolean
        Dim query As String = $"https://the.bigbromonitor.com/index.php?a=register&key={key}&hwid={hwid}&product={email}"

        If retry > 4 Then
            MsgBox("Unable to connect to License Server after 5 attempts.", MsgBoxStyle.Critical, "Error")
            Return False
        Else
            Try
                Dim wc As New WebClient
                Dim strSource As String = wc.DownloadString(query)
                If strSource.Contains("wrong key") Then
                    MsgBox("The product key you entered is invalid or not exists, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
                    Return False
                ElseIf strSource.Contains("wrong hwid") Then
                    MsgBox("Your HWID is invalid, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
                    Return False
                ElseIf strSource.Contains("key is already in use") Then
                    If KeyInUseButCanStillUse(hwid, email) Then
                        MsgBox("Product registration was successful!, Thank you for using our product, We will be happy if you spread the word and tell your friends about this product.", MsgBoxStyle.Information, "Successful")
                        Return True
                    Else
                        MsgBox("The product key you entered is already in use, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
                        Return False
                    End If
                Else
                    MsgBox("Product registration was successful!, Thank you for using our product, We will be happy if you spread the word and tell your friends about this product.", MsgBoxStyle.Information, "Successful")
                    Return True
                End If
            Catch ex As Exception
                Return ELSActivateLicense(key, hwid, email, retry + 1)
            End Try
        End If

        Return False
    End Function

    Public Function KeyInUseButCanStillUse(hwid As String, email As String, Optional retry As Integer = 0) As Boolean
        Dim query As String = $"https://the.bigbromonitor.com/index.php?a=checkdate&hwid={hwid}"

        Dim result As Boolean = False
        Dim [date] As Date = Now
        Dim date2 As Date = Now
        Dim canLogin As Boolean = False

        If retry > 4 Then
            MsgBox("Unable to connect to License Server after 5 attempts.", MsgBoxStyle.Critical, "Error")
            Return False
        Else
            Try
                Dim wc As New WebClient
                Dim strSource As String = wc.DownloadString(query)

                If strSource.Contains(email) Then
                    ' Check the date
                    Dim start As Integer = strSource.IndexOf(email) + email.Length
                    Dim [end] As Integer = strSource.IndexOf(":" + email)
                    Dim datestring = strSource.Substring(start, [end] - start)
                    [date] = DateTime.ParseExact(datestring, "yyyy-MM-dd", Nothing)
                    strSource = wc.DownloadString("http://weltzeit4u.com/Datum/index.php")

                    Dim start2 As Integer = strSource.IndexOf("<span id='gross_fett_blau'>") + 27
                    Dim end2 As Integer = strSource.IndexOf("</span> (arabische")
                    Dim dateToday As String = strSource.Substring(start2, end2 - start2)
                    date2 = DateTime.ParseExact(dateToday, "dd.MM.yyyy", Nothing)
                    If [date] < date2 Then result = True Else canLogin = True
                    If canLogin Then result = True
                End If
            Catch ex As Exception
                Return KeyInUseButCanStillUse(hwid, email, retry + 1)
                Logger.Log(ex)
            End Try
        End If

        Return result
    End Function

    <Extension>
    Public Function IsEmailValid(email As String) As Boolean
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As Match = Regex.Match(email, pattern, RegexOptions.IgnoreCase)
        Return match.Success
    End Function

End Module

'Public Enum eSensorType
'    None
'    CPUCoreCount
'    CPUClockSpeed
'    CPUTemperatureC
'    CPUTemperatureF
'    CPULoadPercent
'    CPUPowerWattage
'    GPUClockSpeed
'    GPUTemperatureC
'    GPUTemperatureF
'    GPULoadPercent
'    GPUMemoryPercent
'    GPUPowerWattage
'    GPUVRAMUsage
'    RAMLoadPercent
'    RAMUsage
'    HDDTemperatureC
'    HDDTemperatureF
'    HDDLoadPercent
'    DownloadSpeed
'    UploadSpeed
'    LongDate
'    ShortDate
'    LongTime
'    ShortTime

'    RAMAvailable
'    RAMTotal
'    HDDTotalSize
'    HDDTotalFreeSpace
'    HDDUsage
'    Ping
'    CustomDateTime

'    GPUFan
'    MoboTemperatureC
'    MoboTemperatureF
'    MoboFan

'    CPUFan
'End Enum

Public Enum eSensorType
    None
    CPUCoreCount
    CPUClockSpeed
    CPUTemperatureC
    CPUTemperatureF
    CPULoadPercent
    CPUPowerWattage
    CPUFan = 36
    CPUCorePower
    CPUGraphicPower
    CPUDRAMPower

    GPUClockSpeed = 7
    GPUTemperatureC
    GPUTemperatureF
    GPULoadPercent
    GPUMemoryPercent
    GPUPowerWattage
    GPUVRAMUsage
    GPUFan = 32
    GPUMemoryClock = 40
    GPUShaderClock
    GPUFrameBufferLoad
    GPUVideoEngineLoad
    GPUBusInterfaceLoad
    GPUVRAMFree
    GPUVRAMTotal

    RAMLoadPercent = 14
    RAMUsage
    RAMAvailable = 25
    RAMTotal

    HDDTemperatureC = 16
    HDDTemperatureF
    HDDLoadPercent
    HDDTotalSize = 25
    HDDTotalFreeSpace
    HDDUsage

    DownloadSpeed = 19
    UploadSpeed
    Ping = 25

    LongDate = 21
    ShortDate
    LongTime
    ShortTime
    CustomDateTime = 31

    MoboTemperatureC = 33
    MoboTemperatureF
    MoboFan

    DisplayScreenResolution = 47
    DisplayRefreshRate

    'Last Item DisplayRefreshRate = 48
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