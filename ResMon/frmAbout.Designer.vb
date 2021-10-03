<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.NsTheme1 = New ResMon.NSTheme()
        Me.txtCredit = New ResMon.NSTextBox()
        Me.btnClose = New ResMon.NSButton()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.NsLabel1 = New ResMon.NSLabel()
        Me.cbClose = New ResMon.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New ResMon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.txtCredit)
        Me.NsTheme1.Controls.Add(Me.btnClose)
        Me.NsTheme1.Controls.Add(Me.lblVersion)
        Me.NsTheme1.Controls.Add(Me.NsLabel1)
        Me.NsTheme1.Controls.Add(Me.cbClose)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(432, 544)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "About Resource Monitor"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'txtCredit
        '
        Me.txtCredit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCredit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCredit.Location = New System.Drawing.Point(12, 100)
        Me.txtCredit.MaxLength = 32767
        Me.txtCredit.Multiline = True
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.ReadOnly = True
        Me.txtCredit.Size = New System.Drawing.Size(408, 403)
        Me.txtCredit.TabIndex = 17
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCredit.UseSystemPasswordChar = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(320, 509)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 27)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(12, 68)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(77, 14)
        Me.lblVersion.TabIndex = 15
        Me.lblVersion.Text = "Version 1.0"
        '
        'NsLabel1
        '
        Me.NsLabel1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel1.Location = New System.Drawing.Point(12, 42)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(261, 23)
        Me.NsLabel1.TabIndex = 14
        Me.NsLabel1.Text = "NsLabel1"
        Me.NsLabel1.Value1 = "BigBro"
        Me.NsLabel1.Value2 = "Monitor"
        '
        'cbClose
        '
        Me.cbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbClose.ControlButton = ResMon.NSControlButton.Button.Close
        Me.cbClose.Location = New System.Drawing.Point(408, 4)
        Me.cbClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.Name = "cbClose"
        Me.cbClose.Size = New System.Drawing.Size(18, 20)
        Me.cbClose.TabIndex = 13
        Me.cbClose.Text = "NsControlButton1"
        '
        'frmAbout
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(432, 544)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Resource Monitor"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents cbClose As NSControlButton
    Friend WithEvents NsLabel1 As NSLabel
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnClose As NSButton
    Friend WithEvents txtCredit As NSTextBox
End Class
