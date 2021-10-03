<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.btnBrowse = New ResMon.NSButton()
        Me.txtBox = New ResMon.NSTextBox()
        Me.SuspendLayout()
        '
        'lblLabel
        '
        Me.lblLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLabel.ForeColor = System.Drawing.Color.White
        Me.lblLabel.Location = New System.Drawing.Point(0, 0)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(86, 23)
        Me.lblLabel.TabIndex = 0
        Me.lblLabel.Text = "Label1"
        Me.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(252, 0)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(26, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        '
        'txtBox
        '
        Me.txtBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBox.Location = New System.Drawing.Point(92, 0)
        Me.txtBox.MaxLength = 32767
        Me.txtBox.Multiline = False
        Me.txtBox.Name = "txtBox"
        Me.txtBox.ReadOnly = False
        Me.txtBox.Size = New System.Drawing.Size(186, 23)
        Me.txtBox.TabIndex = 1
        Me.txtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBox.UseSystemPasswordChar = False
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
        Me.Size = New System.Drawing.Size(278, 23)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblLabel As Label
    Friend WithEvents txtBox As NSTextBox
    Friend WithEvents btnBrowse As NSButton
End Class
