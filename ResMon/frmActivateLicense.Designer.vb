<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivateLicense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivateLicense))
        Me.NsTheme1 = New ResMon.NSTheme()
        Me.btnCancel = New ResMon.NSButton()
        Me.btnActivate = New ResMon.NSButton()
        Me.lblEnterLicense = New System.Windows.Forms.Label()
        Me.txtKey = New ResMon.NSTextBox()
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
        Me.NsTheme1.Controls.Add(Me.btnCancel)
        Me.NsTheme1.Controls.Add(Me.btnActivate)
        Me.NsTheme1.Controls.Add(Me.lblEnterLicense)
        Me.NsTheme1.Controls.Add(Me.txtKey)
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
        Me.NsTheme1.Size = New System.Drawing.Size(439, 188)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "License Activation"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(130, 121)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(82, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnActivate
        '
        Me.btnActivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnActivate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnActivate.ForeColor = System.Drawing.Color.White
        Me.btnActivate.Location = New System.Drawing.Point(218, 121)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(82, 23)
        Me.btnActivate.TabIndex = 2
        Me.btnActivate.Text = "Activate"
        '
        'lblEnterLicense
        '
        Me.lblEnterLicense.BackColor = System.Drawing.Color.Transparent
        Me.lblEnterLicense.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblEnterLicense.ForeColor = System.Drawing.Color.White
        Me.lblEnterLicense.Location = New System.Drawing.Point(12, 41)
        Me.lblEnterLicense.Name = "lblEnterLicense"
        Me.lblEnterLicense.Size = New System.Drawing.Size(415, 45)
        Me.lblEnterLicense.TabIndex = 15
        Me.lblEnterLicense.Text = "Please enter the License Key to activate this software."
        Me.lblEnterLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKey
        '
        Me.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKey.Location = New System.Drawing.Point(77, 89)
        Me.txtKey.MaxLength = 32767
        Me.txtKey.Multiline = False
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = False
        Me.txtKey.Size = New System.Drawing.Size(282, 26)
        Me.txtKey.TabIndex = 0
        Me.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtKey.UseSystemPasswordChar = False
        '
        'cbClose
        '
        Me.cbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbClose.ControlButton = ResMon.NSControlButton.Button.Close
        Me.cbClose.Location = New System.Drawing.Point(415, 3)
        Me.cbClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.Name = "cbClose"
        Me.cbClose.Size = New System.Drawing.Size(18, 20)
        Me.cbClose.TabIndex = 13
        Me.cbClose.Text = "NsControlButton1"
        '
        'frmActivateLicense
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(439, 188)
        Me.Controls.Add(Me.NsTheme1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmActivateLicense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License Activation"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents cbClose As NSControlButton
    Friend WithEvents txtKey As NSTextBox
    Friend WithEvents lblEnterLicense As Label
    Friend WithEvents btnCancel As NSButton
    Friend WithEvents btnActivate As NSButton
End Class
