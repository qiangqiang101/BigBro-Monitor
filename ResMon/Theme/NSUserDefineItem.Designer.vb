Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NSUserDefineItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblLabel = New MaterialSkin.Controls.MaterialLabel()
        Me.btnBrowse = New MaterialSkin.Controls.MaterialButton()
        Me.txtBox = New MaterialSkin.Controls.MaterialTextBox()
        Me.SuspendLayout()
        '
        'lblLabel
        '
        Me.lblLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLabel.Depth = 0
        Me.lblLabel.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabel.Location = New System.Drawing.Point(0, 0)
        Me.lblLabel.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(107, 50)
        Me.lblLabel.TabIndex = 0
        Me.lblLabel.Text = "Label1"
        Me.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.AutoSize = False
        Me.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBrowse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnBrowse.Depth = 0
        Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBrowse.HighEmphasis = True
        Me.btnBrowse.Icon = Nothing
        Me.btnBrowse.Location = New System.Drawing.Point(252, 0)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(26, 50)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnBrowse.UseAccentColor = False
        '
        'txtBox
        '
        Me.txtBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBox.Depth = 0
        Me.txtBox.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtBox.LeadingIcon = Nothing
        Me.txtBox.Location = New System.Drawing.Point(113, 0)
        Me.txtBox.MaxLength = 32767
        Me.txtBox.MouseState = MaterialSkin.MouseState.OUT
        Me.txtBox.Multiline = False
        Me.txtBox.Name = "txtBox"
        Me.txtBox.Size = New System.Drawing.Size(165, 50)
        Me.txtBox.TabIndex = 1
        Me.txtBox.Text = ""
        Me.txtBox.TrailingIcon = Nothing
        '
        'NSUserDefineItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtBox)
        Me.Controls.Add(Me.lblLabel)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "NSUserDefineItem"
        Me.Size = New System.Drawing.Size(278, 50)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblLabel As MaterialLabel
    Friend WithEvents txtBox As MaterialTextBox
    Friend WithEvents btnBrowse As MaterialButton
End Class
