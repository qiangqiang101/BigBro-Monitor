Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions
Imports Echevil
Imports OpenHardwareMonitor.Hardware

Public Class CPUSensors

    Public Clock As SensorGroup
    Public Temperature As SensorGroup
    Public Load As SensorGroup
    Public Power As SensorGroup

    Public Computer As Computer

    Public Sub New(computer As Computer)
        Clock = New SensorGroup("Clocks", " MHz")
        Temperature = New SensorGroup("Temperatures", " °C")
        Load = New SensorGroup("Load", " %")
        Power = New SensorGroup("Powers", " W")

        Me.Computer = computer
    End Sub

    Public Function Name() As String
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CoreCount() As Integer
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name.Contains("Core")).Count
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ClockSpeed() As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*CPU Core*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function TemperatureLevel() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name Like "*CPU Package*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function TemperatureC() As String
        Try
            Return $"{TemperatureLevel()} °C"
        Catch ex As Exception
            Return "0 °C"
        End Try
    End Function

    Public Function TemperatureF() As String
        Try
            Return $"{(TemperatureLevel() * 1.8) + 32} °F"
        Catch ex As Exception
            Return "0 °F"
        End Try
    End Function

    Public Function LoadPercent() As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*CPU Total*").FirstOrDefault.Value.GetValueOrDefault)} %"
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function PowerWattage() As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Package*").FirstOrDefault.Value.GetValueOrDefault.ToString("N")} W"
        Catch ex As Exception
            Return "0 W"
        End Try
    End Function

    Public Function RawTemperatureC() As Integer
        Try
            Return CInt(TemperatureLevel())
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawTemperatureF() As Integer
        Try
            Return CInt((TemperatureLevel() * 1.8) + 32)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawLoadPercent() As Integer
        Try
            Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).First.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*CPU Total*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class GPUSensors

    Public Clock As SensorGroup
    Public Temperature As SensorGroup
    Public Load As SensorGroup
    Public Fan As SensorGroup
    Public Control As SensorGroup
    Public Power As SensorGroup
    Public Data As SensorGroup
    Public Throughput As SensorGroup

    Public Computer As Computer

    Public Sub New(computer As Computer)
        Clock = New SensorGroup("Clocks", " MHz")
        Temperature = New SensorGroup("Temperatures", " °C")
        Load = New SensorGroup("Load", " %")
        Fan = New SensorGroup("Fans", " RPM")
        Control = New SensorGroup("Controls", " %")
        Power = New SensorGroup("Powers", " W")
        Data = New SensorGroup("Data", " MB")
        Throughput = New SensorGroup("Throughput", " KB/s")

        Me.Computer = computer
    End Sub

    Public Function Name(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Name
            Catch ex As Exception
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Name
            End Try
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ClockSpeed(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            Catch ex As Exception
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            End Try
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function TemperatureLevel(Optional GPUNo As Integer = 0) As Single
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault
            Catch ex As Exception
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault
            End Try
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function TemperatureC(Optional GPUNo As Integer = 0) As String
        Try
            Return $"{TemperatureLevel(GPUNo)} °C"
        Catch ex As Exception
            Return "0 °C"
        End Try
    End Function

    Public Function TemperatureF(Optional GPUNo As Integer = 0) As String
        Try
            Return $"{(TemperatureLevel(GPUNo) * 1.8) + 32} °F"
        Catch ex As Exception
            Return "0 °F"
        End Try
    End Function

    Public Function LoadPercent(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function MemoryPercent(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function PowerWattage(Optional GPUNo As Integer = 0) As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*GPU Power*").FirstOrDefault.Value.GetValueOrDefault} W"
        Catch ex As Exception
            Try
                Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*GPU Power*").FirstOrDefault.Value.GetValueOrDefault} W"
            Catch exc As Exception
                Return "0 W"
            End Try
        End Try
    End Function

    Public Function VRAMUsage(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            Catch ex As Exception
                Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            End Try
        Catch ex As Exception
            Return "0 MB"
        End Try
    End Function

    Public Function RawTemperatureC(Optional GPUNo As Integer = 0) As Integer
        Try
            Return CInt(TemperatureLevel(GPUNo))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawTemperatureF(Optional GPUNo As Integer = 0) As Integer
        Try
            Return CInt((TemperatureLevel(GPUNo) * 1.8) + 32)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawLoadPercent(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawMemoryPercent(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVRAMUsage(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVRAMTotal(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class RAMSensors

    Public Load As SensorGroup
    Public Data As SensorGroup

    Public Computer As Computer

    Public Sub New(computer As Computer)
        Load = New SensorGroup("Load", " %")
        Data = New SensorGroup("Data", " GB")

        Me.Computer = computer
    End Sub

    Public Function Name() As String
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function LoadPercent() As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function RAMUsage() As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Used Memory*").FirstOrDefault.Value.GetValueOrDefault)} GB"
        Catch ex As Exception
            Return "0 GB"
        End Try
    End Function

    Public Function RAMAvailable() As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Available Memory*").FirstOrDefault.Value.GetValueOrDefault)} GB"
        Catch ex As Exception
            Return "0 GB"
        End Try
    End Function

    Public Function RAMTotal() As String
        Try
            Return $"{RawRAMTotal()} GB"
        Catch ex As Exception
            Return "0 GB"
        End Try
    End Function

    Public Function RawLoadPercent() As Integer
        Try
            Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Memory*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawRAMUsage() As Integer
        Try
            Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Used Memory*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawRAMTotal() As Integer
        Try
            Return RawRAMUsage() + RawRAMAvailable()
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawRAMAvailable() As Integer
        Try
            Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).First.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Available Memory*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class HDDSensors

    Public Temperature As SensorGroup
    Public Load As SensorGroup
    Public Data As SensorGroup

    Public Computer As Computer

    Public Sub New(computer As Computer)
        Temperature = New SensorGroup("Temperatures", " °C")
        Load = New SensorGroup("Load", " %")
        Data = New SensorGroup("Data", " GB")

        Me.Computer = computer
    End Sub

    Public Function Name(Optional DiskNo As Integer = 0) As String
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function TemperatureLevel(Optional DiskNo As Integer = 0) As Single
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name Like "*Temperature*").FirstOrDefault.Value.GetValueOrDefault
            Catch ex As Exception
                Return 0F
            End Try
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function TemperatureC(Optional DiskNo As Integer = 0) As String
        Try
            Return $"{TemperatureLevel(DiskNo)} °C"
        Catch ex As Exception
            Return "0 °C"
        End Try
    End Function

    Public Function TemperatureF(Optional DiskNo As Integer = 0) As String
        Try
            Return $"{(TemperatureLevel(DiskNo) * 1.8) + 32} °F"
        Catch ex As Exception
            Return "0 °F"
        End Try
    End Function

    Public Function LoadPercent(Optional DiskNo As Integer = 0) As String
        Try
            Return $"{Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Used Space*").FirstOrDefault.Value.GetValueOrDefault)} %"
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function RawTemperatureC(Optional DiskNo As Integer = 0) As Integer
        Try
            Return CInt(TemperatureLevel(DiskNo))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawTemperatureF(Optional DiskNo As Integer = 0) As Integer
        Try
            Return CInt((TemperatureLevel(DiskNo) * 1.8) + 32)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawLoadPercent(Optional DiskNo As Integer = 0) As Integer
        Try
            Return CInt(Math.Floor(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Used Space*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function DiskTotalSize(Optional driveLetter As String = "C:\") As String
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return GetDiskSize(drives.TotalSize)
        Catch ex As Exception
            Return "0 byte"
        End Try
    End Function

    Public Function DiskTotalFreeSpace(Optional driveLetter As String = "C:\") As String
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return GetDiskSize(drives.TotalFreeSpace)
        Catch ex As Exception
            Return "0 byte"
        End Try
    End Function

    Public Function DiskUsage(Optional driveLetter As String = "C:\") As String
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return GetDiskSize(drives.TotalSize - drives.TotalFreeSpace)
        Catch ex As Exception
            Return "0 byte"
        End Try
    End Function

    Public Function RawDiskTotalSize(Optional driveLetter As String = "C:\") As Integer
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return ByteToGiga(drives.TotalSize)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawDiskTotalFreeSpace(Optional driveLetter As String = "C:\") As Integer
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return ByteToGiga(drives.TotalFreeSpace)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawDiskUsage(Optional driveLetter As String = "C:\") As Integer
        Try
            Dim drives As DriveInfo = DriveInfo.GetDrives.SingleOrDefault(Function(x) x.DriveType = DriveType.Fixed AndAlso x.Name = driveLetter)
            Return ByteToGiga(drives.TotalSize - drives.TotalFreeSpace)
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class NetworkSensor

    Public Adapter As NetworkAdapter

    Public Function DownloadSpeed() As String
        Try
            Return GetSpeed(Adapter.DownloadSpeed)
        Catch ex As Exception
            Return GetSpeed(0)
        End Try
    End Function

    Public Function UploadSpeed() As String
        Try
            Return GetSpeed(Adapter.UploadSpeed)
        Catch ex As Exception
            Return GetSpeed(0)
        End Try
    End Function

    Public Function RawDownloadSpeed() As Decimal
        Try
            Return Decimal.Round(CDec(Adapter.DownloadSpeedKbps), 2)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawUploadSpeed() As Decimal
        Try
            Return Decimal.Round(CDec(Adapter.UploadSpeedKbps), 2)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Ping(Optional url As String = "8.8.8.8") As String
        Dim sendPing As New Ping()

        Try
            Dim result As PingReply = sendPing.Send(url)
            If result.Status = IPStatus.Success Then Return $"{result.RoundtripTime} ms"
        Catch ex As Exception
            Return "Requested Timed Out"
        End Try
        Return "Requested Timed Out"
    End Function

    Public Function RawPing(Optional url As String = "8.8.8.8") As Long
        Dim sendPing As New Ping()

        Try
            Dim result As PingReply = sendPing.Send(url)
            If result.Status = IPStatus.Success Then Return result.RoundtripTime
        Catch ex As Exception
            Return 0L
        End Try
        Return 0L
    End Function

End Class