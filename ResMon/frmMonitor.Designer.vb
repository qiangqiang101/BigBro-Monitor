<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitor))
        Me.Updater = New System.Windows.Forms.Timer(Me.components)
        Me.RGBTicker = New System.Windows.Forms.Timer(Me.components)
        Me.bwUpdater = New System.ComponentModel.BackgroundWorker()
        Me.bwRGBTicker = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Updater
        '
        Me.Updater.Interval = 3000
        '
        'RGBTicker
        '
        Me.RGBTicker.Interval = 60
        '
        'bwUpdater
        '
        '
        'bwRGBTicker
        '
        '
        'frmMonitor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(480, 320)
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonitor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Resource Monitor"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Updater As Timer
    Friend WithEvents RGBTicker As Timer
    Friend WithEvents bwUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwRGBTicker As System.ComponentModel.BackgroundWorker
End Class
