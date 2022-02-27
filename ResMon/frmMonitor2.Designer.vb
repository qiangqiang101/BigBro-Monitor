Imports Microsoft.Web.WebView2.WinForms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMonitor2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonitor2))
        Me.ytWebView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.pMove = New System.Windows.Forms.Panel()
        CType(Me.ytWebView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ytWebView
        '
        Me.ytWebView.CreationProperties = Nothing
        Me.ytWebView.DefaultBackgroundColor = System.Drawing.Color.White
        Me.ytWebView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ytWebView.Location = New System.Drawing.Point(0, 0)
        Me.ytWebView.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ytWebView.Name = "ytWebView"
        Me.ytWebView.Size = New System.Drawing.Size(480, 320)
        Me.ytWebView.TabIndex = 0
        Me.ytWebView.ZoomFactor = 1.0R
        '
        'pMove
        '
        Me.pMove.BackColor = System.Drawing.Color.Black
        Me.pMove.Location = New System.Drawing.Point(0, 0)
        Me.pMove.Name = "pMove"
        Me.pMove.Size = New System.Drawing.Size(10, 10)
        Me.pMove.TabIndex = 1
        '
        'frmMonitor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(480, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.pMove)
        Me.Controls.Add(Me.ytWebView)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonitor2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Second Screen"
        Me.TopMost = True
        CType(Me.ytWebView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ytWebView As WebView2
    Friend WithEvents pMove As Panel
End Class
