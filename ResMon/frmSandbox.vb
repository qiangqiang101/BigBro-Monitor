Public Class frmSandbox
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = $"{PerformanceCounter1.CounterName} {PerformanceCounter1.NextValue}"
        Label2.Text = $"{PerformanceCounter2.CounterName} {PerformanceCounter2.NextValue}"
        Label3.Text = $"{PerformanceCounter3.CounterName} {PerformanceCounter3.NextValue}"
    End Sub
End Class