Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAbout
    Inherits MaterialForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.btnClose = New MaterialSkin.Controls.MaterialButton()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.lblVersion = New MaterialSkin.Controls.MaterialLabel()
        Me.txtCredit = New MaterialSkin.Controls.MaterialMultiLineTextBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = False
        Me.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnClose.Depth = 0
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.HighEmphasis = True
        Me.btnClose.Icon = Nothing
        Me.btnClose.Location = New System.Drawing.Point(305, 499)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnClose.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 36)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnClose.UseAccentColor = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.MaterialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        Me.MaterialLabel1.Location = New System.Drawing.Point(6, 64)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(162, 29)
        Me.MaterialLabel1.TabIndex = 6
        Me.MaterialLabel1.Text = "BigBro Monitor"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Depth = 0
        Me.lblVersion.Font = New System.Drawing.Font("Roboto Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblVersion.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        Me.lblVersion.Location = New System.Drawing.Point(6, 93)
        Me.lblVersion.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(69, 24)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "Version"
        '
        'txtCredit
        '
        Me.txtCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCredit.Depth = 0
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.txtCredit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCredit.Location = New System.Drawing.Point(6, 120)
        Me.txtCredit.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.ReadOnly = True
        Me.txtCredit.Size = New System.Drawing.Size(420, 370)
        Me.txtCredit.TabIndex = 6
        Me.txtCredit.Text = ""
        '
        'frmAbout
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(432, 544)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtCredit)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About BigBro Monitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents lblVersion As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents txtCredit As MaterialSkin.Controls.MaterialMultiLineTextBox
End Class
