Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Echevil
Imports MSIAfterburnerNET.HM
Imports MSIAfterburnerNET.HM.Interop
Imports OpenHardwareMonitor.Hardware
Imports sm = System.Management

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
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CoreCount() As Integer
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name.Contains("Core")).Count
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ClockSpeed(Optional core As Integer = 1) As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name = $"CPU Core #{core}").FirstOrDefault.Value.GetValueOrDefault)} MHz"
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function BusClockSpeed() As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*Bus Speed*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function TemperatureLevel() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name Like "*CPU Package*").FirstOrDefault.Value.GetValueOrDefault
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

    Public Function CoreTemperature(Optional core As Integer = 1) As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Temperature And x.Name = $"CPU Core #{core}").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function CoreTemperatureC(Optional core As Integer = 1) As String
        Try
            Return $"{CoreTemperature(core)} °C"
        Catch ex As Exception
            Return "0 °C"
        End Try
    End Function

    Public Function CoreTemperatureF(Optional core As Integer = 1) As String
        Try
            Return $"{(CoreTemperature(core) * 1.8) + 32} °F"
        Catch ex As Exception
            Return "0 °F"
        End Try
    End Function

    Public Function LoadPercent() As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*CPU Total*").FirstOrDefault.Value.GetValueOrDefault)} %"
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function PowerWattage() As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Package*").FirstOrDefault.Value.GetValueOrDefault.ToString("N")} W"
        Catch ex As Exception
            Return "0 W"
        End Try
    End Function

    Public Function CorePower() As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Cores*").FirstOrDefault.Value.GetValueOrDefault.ToString("N")} W"
        Catch ex As Exception
            Return "0 W"
        End Try
    End Function

    Public Function GraphicPower() As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Graphics*").FirstOrDefault.Value.GetValueOrDefault.ToString("N")} W"
        Catch ex As Exception
            Return "0 W"
        End Try
    End Function

    Public Function DRAMPower() As String
        Try
            Return $"{Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU DRAM*").FirstOrDefault.Value.GetValueOrDefault.ToString("N")} W"
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

    Public Function RawCoreTemperatureC(Optional core As Integer = 1) As Integer
        Try
            Return CInt(CoreTemperature(core))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawCoreTemperatureF(Optional core As Integer = 1) As Integer
        Try
            Return CInt((CoreTemperature(core) * 1.8) + 32)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawLoadPercent() As Integer
        Try
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*CPU Total*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawClockSpeed(Optional core As Integer = 1) As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name = $"CPU Core #{core}").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawBusClockSpeed() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*Bus Speed*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawPowerWattage() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Package*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawCorePower() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Cores*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawGraphicPower() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU Graphics*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawDRAMPower() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.CPU).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*CPU DRAM*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Return 0F
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
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            End Try
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function MemoryClock(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            End Try
        Catch ex As Exception
            Return "0 MHz"
        End Try
    End Function

    Public Function ShaderClock(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Shader*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Shader*").FirstOrDefault.Value.GetValueOrDefault)} MHz"
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
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function FrameBufferLoad(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Frame Buffer*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Frame Buffer*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function VideoEngineLoad(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Video Engine*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Video Engine*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function BusInterfaceLoad(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Bus Interface*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Bus Interface*").FirstOrDefault.Value.GetValueOrDefault)} %"
            End Try
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function MemoryPercent(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
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

    Public Function VRAMFree(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Free*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Free*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            End Try
        Catch ex As Exception
            Return "0 MB"
        End Try
    End Function

    Public Function VRAMUsage(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            End Try
        Catch ex As Exception
            Return "0 MB"
        End Try
    End Function

    Public Function VRAMTotal(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault)} MB"
            End Try
        Catch ex As Exception
            Return "0 MB"
        End Try
    End Function

    Public Function FanSpeed(Optional GPUNo As Integer = 0) As String
        Try
            Try
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Fan And x.Name Like "*GPU*").FirstOrDefault.Value.GetValueOrDefault)} RPM"
            Catch ex As Exception
                Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Fan And x.Name Like "*GPU*").FirstOrDefault.Value.GetValueOrDefault)} RPM"
            End Try
        Catch ex As Exception
            Return "0 RPM"
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
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawFrameBufferLoad(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Frame Buffer*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Frame Buffer*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVideoEngineLoad(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Video Engine*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Video Engine*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawBusInterfaceLoad(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Bus Interface*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Bus Interface*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawMemoryPercent(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVRAMFree(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Free*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Free*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVRAMUsage(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Used*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawVRAMTotal(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.SmallData And x.Name Like "*GPU Memory Total*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawFanSpeed(Optional GPUNo As Integer = 0) As Integer
        Try
            Try
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Fan And x.Name Like "*GPU*").FirstOrDefault.Value.GetValueOrDefault))
            Catch ex As Exception
                Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Fan And x.Name Like "*GPU*").FirstOrDefault.Value.GetValueOrDefault))
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawClockSpeed(Optional GPUNo As Integer = 0) As Single
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault
            Catch ex As Exception
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Core*").FirstOrDefault.Value.GetValueOrDefault
            End Try
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawMemoryClock(Optional GPUNo As Integer = 0) As Single
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault
            Catch ex As Exception
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Memory*").FirstOrDefault.Value.GetValueOrDefault
            End Try
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawShaderClock(Optional GPUNo As Integer = 0) As Single
        Try
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Shader*").FirstOrDefault.Value.GetValueOrDefault
            Catch ex As Exception
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Clock And x.Name Like "*GPU Shader*").FirstOrDefault.Value.GetValueOrDefault
            End Try
        Catch ex As Exception
            Return 0F
        End Try
    End Function

    Public Function RawPowerWattage(Optional GPUNo As Integer = 0) As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*GPU Power*").FirstOrDefault.Value.GetValueOrDefault
        Catch ex As Exception
            Try
                Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuAti)(GPUNo).Sensors.Where(Function(x) x.SensorType = SensorType.Power And x.Name Like "*GPU Power*").FirstOrDefault.Value.GetValueOrDefault
            Catch exc As Exception
                Return 0F
            End Try
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
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function LoadPercent() As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Memory*").FirstOrDefault.Value.GetValueOrDefault)} %"
        Catch ex As Exception
            Return "0 %"
        End Try
    End Function

    Public Function RAMUsage() As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Used Memory*").FirstOrDefault.Value.GetValueOrDefault)} GB"
        Catch ex As Exception
            Return "0 GB"
        End Try
    End Function

    Public Function RAMAvailable() As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Available Memory*").FirstOrDefault.Value.GetValueOrDefault)} GB"
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
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Memory*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function RawRAMUsage() As Integer
        Try
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Used Memory*").FirstOrDefault.Value.GetValueOrDefault))
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
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.RAM).FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Data And x.Name Like "*Available Memory*").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function VirtualMemoryTotal() As String
        Return $"{ByteToGiga(New Devices.ComputerInfo().TotalVirtualMemory)} GB"
    End Function

    Public Function VirtualMemoryAvailable() As String
        Return $"{ByteToGiga(New Devices.ComputerInfo().AvailableVirtualMemory)} GB"
    End Function

    Public Function VirtualMemoryUsage() As String
        Return $"{RawVirtualMemoryTotal() - RawVirtualMemoryAvailable()} GB"
    End Function

    Public Function RawVirtualMemoryTotal() As Integer
        Return ByteToGiga(New Devices.ComputerInfo().TotalVirtualMemory)
    End Function

    Public Function RawVirtualMemoryAvailable() As Integer
        Return ByteToGiga(New Devices.ComputerInfo().AvailableVirtualMemory)
    End Function

    Public Function RawVirtualMemoryUsage() As Integer
        Return RawVirtualMemoryTotal() - RawVirtualMemoryAvailable()
    End Function

    Public Function RamClockSpeed() As String
        Return $"{RawRamClockSpeed()} MHz"
    End Function

    Public Function RawRamClockSpeed() As Integer
        Dim query As New Management.SelectQuery("Win32_PhysicalMemory")
        Dim clock As Integer = 0

        Try
            For Each mo As Management.ManagementObject In New Management.ManagementObjectSearcher(query).Get
                clock = If(mo("Speed") IsNot Nothing, CInt(mo("Speed").ToString), 0)
            Next

            Return clock
        Catch ex As Exception
            Return clock
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
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Used Space*").FirstOrDefault.Value.GetValueOrDefault)} %"
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
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.HDD)(DiskNo).Sensors.Where(Function(x) x.SensorType = SensorType.Load And x.Name Like "*Used Space*").FirstOrDefault.Value.GetValueOrDefault))
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

Public Class MainboardSensor
    Public Temperature As SensorGroup
    Public Fans As SensorGroup

    Public Computer As Computer

    Public Sub New(computer As Computer)
        Temperature = New SensorGroup("Temperatures", " °C")
        Fans = New SensorGroup("Fan", "  RPM")

        Me.Computer = computer
    End Sub

    Public Function Name() As String
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.Mainboard).FirstOrDefault.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Name2() As String
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.Mainboard).FirstOrDefault.SubHardware.FirstOrDefault.Name
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function TemperatureLevel() As Single
        Try
            Return Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.Mainboard).FirstOrDefault.SubHardware.FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Temperature AndAlso x.Name Like "*CPU Core*").FirstOrDefault.Value.GetValueOrDefault
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

    Public Function FanSpeed(Optional fan As Integer = 1) As String
        Try
            Return $"{Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.Mainboard).FirstOrDefault.SubHardware.FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Fan AndAlso x.Name = $"Fan #{fan}").FirstOrDefault.Value.GetValueOrDefault)} RPM"
        Catch ex As Exception
            Return "0 RPM"
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

    Public Function RawFanSpeed(Optional fan As Integer = 1) As Integer
        Try
            Return CInt(Math.Ceiling(Computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.Mainboard).FirstOrDefault.SubHardware.FirstOrDefault.Sensors.Where(Function(x) x.SensorType = SensorType.Fan AndAlso x.Name = $"Fan #{fan}").FirstOrDefault.Value.GetValueOrDefault))
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class DisplaySensor

    Public Function RefreshRate() As String
        Dim query As New sm.SelectQuery("Win32_VideoController")
        Dim refresh As String = "0 Hz"

        Try
            For Each mo As sm.ManagementObject In New sm.ManagementObjectSearcher(query).Get
                Dim CurrentRefreshRate As Object = mo("CurrentRefreshRate")
                If CurrentRefreshRate IsNot Nothing Then refresh = $"{CurrentRefreshRate.ToString} Hz"
            Next

            Return refresh
        Catch ex As Exception
            Return refresh
        End Try
    End Function

    Public Function ScreenResolution() As String
        Dim scr = Screen.PrimaryScreen.Bounds
        Return $"{scr.Width}x{scr.Height}"
    End Function

    Public Function Framerate() As String
        Dim returnFps As String = "0 FPS"
        Try
            Using mahm = New HardwareMonitor()
                Dim fps As HardwareMonitorEntry = mahm.GetEntry(MONITORING_SOURCE_ID.FRAMERATE, HardwareMonitor.GLOBAL_INDEX)
                If fps IsNot Nothing Then
                    For i As Integer = 0 To 10
                        returnFps = $"{CInt(fps.Data)} FPS"
                        mahm.RefreshEntry(fps)
                    Next
                End If
            End Using
        Catch ex As Exception
            returnFps = "0 FPS"
        End Try
        Return returnFps
    End Function

    Public Function Frametime() As String
        Dim returnFt As String = "0 ms"
        Try
            Using mahm = New HardwareMonitor()
                Dim ft As HardwareMonitorEntry = mahm.GetEntry(MONITORING_SOURCE_ID.FRAMETIME, HardwareMonitor.GLOBAL_INDEX)
                If ft IsNot Nothing Then
                    For i As Integer = 0 To 10
                        returnFt = $"{CInt(ft.Data)} ms"
                        mahm.RefreshEntry(ft)
                    Next
                End If
            End Using
        Catch ex As Exception
            returnFt = "0 ms"
        End Try
        Return returnFt
    End Function

    Public Function RawRefreshRate() As Integer
        Dim query As New sm.SelectQuery("Win32_VideoController")
        Dim refresh As Integer = 0

        Try
            For Each mo As sm.ManagementObject In New sm.ManagementObjectSearcher(query).Get
                Dim CurrentRefreshRate As Object = mo("CurrentRefreshRate")
                If CurrentRefreshRate IsNot Nothing Then refresh = CInt(CurrentRefreshRate.ToString)
            Next

            Return refresh
        Catch ex As Exception
            Return refresh
        End Try
    End Function

    Public Function RawScreenResolution() As String
        Return ScreenResolution()
    End Function

    Public Function RawFramerate() As Integer
        Dim returnFps As Integer = 0
        Try
            Using mahm = New HardwareMonitor()
                Dim fps As HardwareMonitorEntry = mahm.GetEntry(MONITORING_SOURCE_ID.FRAMERATE, HardwareMonitor.GLOBAL_INDEX)
                If fps IsNot Nothing Then
                    For i As Integer = 0 To 10
                        returnFps = CInt(fps.Data)
                        mahm.RefreshEntry(fps)
                    Next
                End If
            End Using
        Catch ex As Exception
            returnFps = 0
        End Try
        Return returnFps
    End Function

    Public Function RawFrametime() As Integer
        Dim returnFt As Integer = 0
        Try
            Using mahm = New HardwareMonitor()
                Dim ft As HardwareMonitorEntry = mahm.GetEntry(MONITORING_SOURCE_ID.FRAMETIME, HardwareMonitor.GLOBAL_INDEX)
                If ft IsNot Nothing Then
                    For i As Integer = 0 To 10
                        returnFt = CInt(ft.Data)
                        mahm.RefreshEntry(ft)
                    Next
                End If
            End Using
        Catch ex As Exception
            returnFt = 0
        End Try
        Return returnFt
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
            Dim result As PingReply = sendPing.Send(url, 1000)
            If result.Status = IPStatus.Success Then Return $"{result.RoundtripTime} ms"
        Catch ex As Exception
            Return "Requested Timed Out"
        End Try
        Return "Requested Timed Out"
    End Function

    Public Function RawPing(Optional url As String = "8.8.8.8") As Long
        Dim sendPing As New Ping()

        Try
            Dim result As PingReply = sendPing.Send(url, 1000)
            If result.Status = IPStatus.Success Then Return result.RoundtripTime
        Catch ex As Exception
            Return 0L
        End Try
        Return 0L
    End Function

End Class