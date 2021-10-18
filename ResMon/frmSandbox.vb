Imports OpenHardwareMonitor.Hardware

Public Class frmSandbox

    Private ReadOnly computer As New Computer() With {.CPUEnabled = True, .FanControllerEnabled = True, .GPUEnabled = True, .HDDEnabled = True, .MainboardEnabled = True, .RAMEnabled = True}

    Private Sub frmSandbox_Load(sender As Object, e As EventArgs) Handles Me.Load
        computer.Open()

        For Each mother In computer.Hardware.Where(Function(x) x.HardwareType = HardwareType.GpuNvidia)
            mother.Update()

            For Each sensor In mother.Sensors
                ListView1.Items.Add(New ListViewItem({mother.Name, sensor.SensorType.ToString, sensor.Identifier.ToString, sensor.Name, sensor.Value}))
            Next

            'For Each subMother In mother.SubHardware
            '    subMother.Update()

            '    For Each sensor In subMother.Sensors
            '        ListView1.Items.Add(New ListViewItem({mother.Name, subMother.Name, sensor.SensorType.ToString, sensor.Identifier.ToString, sensor.Name, sensor.Value}))
            '    Next
            'Next
        Next
    End Sub

End Class