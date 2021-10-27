Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmActivateLicense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivateLicense))
        Me.btnCancel = New MaterialSkin.Controls.MaterialButton()
        Me.btnActivate = New MaterialSkin.Controls.MaterialButton()
        Me.lblEnterLicense = New MaterialSkin.Controls.MaterialLabel()
        Me.txtKey = New MaterialSkin.Controls.MaterialTextBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = False
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnCancel.Depth = 0
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.HighEmphasis = True
        Me.btnCancel.Icon = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(225, 226)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnCancel.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnCancel.UseAccentColor = False
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnActivate
        '
        Me.btnActivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivate.AutoSize = False
        Me.btnActivate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActivate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnActivate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnActivate.Depth = 0
        Me.btnActivate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnActivate.ForeColor = System.Drawing.Color.White
        Me.btnActivate.HighEmphasis = True
        Me.btnActivate.Icon = Nothing
        Me.btnActivate.Location = New System.Drawing.Point(353, 226)
        Me.btnActivate.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnActivate.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(120, 36)
        Me.btnActivate.TabIndex = 2
        Me.btnActivate.Text = "Activate"
        Me.btnActivate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnActivate.UseAccentColor = True
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'lblEnterLicense
        '
        Me.lblEnterLicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnterLicense.Depth = 0
        Me.lblEnterLicense.Font = New System.Drawing.Font("Roboto", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblEnterLicense.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        Me.lblEnterLicense.Location = New System.Drawing.Point(6, 94)
        Me.lblEnterLicense.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblEnterLicense.Name = "lblEnterLicense"
        Me.lblEnterLicense.Size = New System.Drawing.Size(684, 41)
        Me.lblEnterLicense.TabIndex = 16
        Me.lblEnterLicense.Text = "Please enter the License Key to activate this software."
        Me.lblEnterLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKey
        '
        Me.txtKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKey.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKey.Depth = 0
        Me.txtKey.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtKey.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtKey.LeadingIcon = Nothing
        Me.txtKey.Location = New System.Drawing.Point(178, 158)
        Me.txtKey.MaxLength = 32767
        Me.txtKey.MouseState = MaterialSkin.MouseState.OUT
        Me.txtKey.Multiline = False
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(345, 50)
        Me.txtKey.TabIndex = 0
        Me.txtKey.Text = ""
        Me.txtKey.TrailingIcon = Nothing
        '
        'frmActivateLicense
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(696, 292)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.lblEnterLicense)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnActivate)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActivateLicense"
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License Activation"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As MaterialButton
    Friend WithEvents btnActivate As MaterialButton
    Friend WithEvents lblEnterLicense As MaterialLabel
    Friend WithEvents txtKey As MaterialTextBox
End Class
