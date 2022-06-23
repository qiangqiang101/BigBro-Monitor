<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitor3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitor3))
        Me.webView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.pMove = New System.Windows.Forms.Panel()
        Me.bwUpdater = New System.ComponentModel.BackgroundWorker()
        Me.Updater = New System.Windows.Forms.Timer(Me.components)
        CType(Me.webView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'webView
        '
        Me.webView.CreationProperties = Nothing
        Me.webView.DefaultBackgroundColor = System.Drawing.Color.White
        Me.webView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webView.Location = New System.Drawing.Point(0, 0)
        Me.webView.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webView.Name = "webView"
        Me.webView.Size = New System.Drawing.Size(480, 320)
        Me.webView.TabIndex = 1
        Me.webView.ZoomFactor = 1.0R
        '
        'pMove
        '
        Me.pMove.BackColor = System.Drawing.Color.Black
        Me.pMove.Location = New System.Drawing.Point(0, 0)
        Me.pMove.Name = "pMove"
        Me.pMove.Size = New System.Drawing.Size(10, 10)
        Me.pMove.TabIndex = 2
        '
        'Updater
        '
        Me.Updater.Interval = 3000
        '
        'frmMonitor3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(480, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.pMove)
        Me.Controls.Add(Me.webView)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonitor3"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Resource Monitor"
        Me.TopMost = True
        CType(Me.webView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents webView As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents pMove As Panel
    Friend WithEvents bwUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents Updater As Timer
End Class
