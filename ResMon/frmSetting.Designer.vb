<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetting))
        Me.nsTheme = New ResMon.NSTheme()
        Me.cbTopMost = New ResMon.NSCheckBox()
        Me.cmbLanguage = New ResMon.NSComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.gbLicense = New ResMon.NSGroupBox()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.btnActivate = New ResMon.NSButton()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.btnCredits = New ResMon.NSButton()
        Me.gbWeather = New ResMon.NSGroupBox()
        Me.lblTown = New System.Windows.Forms.Label()
        Me.cmbTown = New ResMon.NSComboBox()
        Me.cmbStates = New ResMon.NSComboBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.cbClose = New ResMon.NSControlButton()
        Me.btnSave = New ResMon.NSButton()
        Me.lblBroadcastPort = New System.Windows.Forms.Label()
        Me.cbBroadcast = New ResMon.NSCheckBox()
        Me.txtPort = New ResMon.NSTextBox()
        Me.cbAuto = New ResMon.NSCheckBox()
        Me.cmbNetwork = New ResMon.NSComboBox()
        Me.lblNetworkAdapter = New System.Windows.Forms.Label()
        Me.nsTheme.SuspendLayout()
        Me.gbLicense.SuspendLayout()
        Me.gbWeather.SuspendLayout()
        Me.SuspendLayout()
        '
        'nsTheme
        '
        Me.nsTheme.AccentOffset = 42
        Me.nsTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.nsTheme.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.nsTheme.Colors = New ResMon.Bloom(-1) {}
        Me.nsTheme.Controls.Add(Me.cbTopMost)
        Me.nsTheme.Controls.Add(Me.cmbLanguage)
        Me.nsTheme.Controls.Add(Me.lblLanguage)
        Me.nsTheme.Controls.Add(Me.gbLicense)
        Me.nsTheme.Controls.Add(Me.btnCredits)
        Me.nsTheme.Controls.Add(Me.gbWeather)
        Me.nsTheme.Controls.Add(Me.cbClose)
        Me.nsTheme.Controls.Add(Me.btnSave)
        Me.nsTheme.Controls.Add(Me.lblBroadcastPort)
        Me.nsTheme.Controls.Add(Me.cbBroadcast)
        Me.nsTheme.Controls.Add(Me.txtPort)
        Me.nsTheme.Controls.Add(Me.cbAuto)
        Me.nsTheme.Controls.Add(Me.cmbNetwork)
        Me.nsTheme.Controls.Add(Me.lblNetworkAdapter)
        Me.nsTheme.Customization = ""
        Me.nsTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nsTheme.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.nsTheme.Image = Nothing
        Me.nsTheme.Location = New System.Drawing.Point(0, 0)
        Me.nsTheme.Movable = True
        Me.nsTheme.Name = "nsTheme"
        Me.nsTheme.NoRounding = False
        Me.nsTheme.Sizable = False
        Me.nsTheme.Size = New System.Drawing.Size(421, 430)
        Me.nsTheme.SmartBounds = True
        Me.nsTheme.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.nsTheme.TabIndex = 5
        Me.nsTheme.Text = "Settings"
        Me.nsTheme.TransparencyKey = System.Drawing.Color.Empty
        Me.nsTheme.Transparent = False
        '
        'cbTopMost
        '
        Me.cbTopMost.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbTopMost.Checked = False
        Me.cbTopMost.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbTopMost.ForeColor = System.Drawing.Color.White
        Me.cbTopMost.Location = New System.Drawing.Point(184, 238)
        Me.cbTopMost.Name = "cbTopMost"
        Me.cbTopMost.Size = New System.Drawing.Size(226, 20)
        Me.cbTopMost.TabIndex = 5
        Me.cbTopMost.Text = "Monitor Stay on top"
        '
        'cmbLanguage
        '
        Me.cmbLanguage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLanguage.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbLanguage.ForeColor = System.Drawing.Color.White
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.ItemHeight = 20
        Me.cmbLanguage.Location = New System.Drawing.Point(129, 264)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(282, 26)
        Me.cmbLanguage.TabIndex = 6
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
        Me.lblLanguage.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblLanguage.ForeColor = System.Drawing.Color.White
        Me.lblLanguage.Location = New System.Drawing.Point(9, 267)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(70, 14)
        Me.lblLanguage.TabIndex = 15
        Me.lblLanguage.Text = "Language"
        '
        'gbLicense
        '
        Me.gbLicense.Controls.Add(Me.lblKey)
        Me.gbLicense.Controls.Add(Me.btnActivate)
        Me.gbLicense.Controls.Add(Me.lblName)
        Me.gbLicense.Controls.Add(Me.lblLicense)
        Me.gbLicense.DrawSeperator = True
        Me.gbLicense.Location = New System.Drawing.Point(12, 296)
        Me.gbLicense.Name = "gbLicense"
        Me.gbLicense.Size = New System.Drawing.Size(397, 94)
        Me.gbLicense.SubTitle = ""
        Me.gbLicense.TabIndex = 7
        Me.gbLicense.Text = "NsGroupBox2"
        Me.gbLicense.Title = "License"
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.BackColor = System.Drawing.Color.Transparent
        Me.lblKey.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblKey.ForeColor = System.Drawing.Color.White
        Me.lblKey.Location = New System.Drawing.Point(8, 54)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(47, 14)
        Me.lblKey.TabIndex = 10
        Me.lblKey.Text = "_____"
        '
        'btnActivate
        '
        Me.btnActivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnActivate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnActivate.ForeColor = System.Drawing.Color.White
        Me.btnActivate.Location = New System.Drawing.Point(294, 64)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(100, 27)
        Me.btnActivate.TabIndex = 0
        Me.btnActivate.Text = "Activate"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(8, 73)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(64, 14)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "PC Name"
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.BackColor = System.Drawing.Color.Transparent
        Me.lblLicense.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblLicense.ForeColor = System.Drawing.Color.White
        Me.lblLicense.Location = New System.Drawing.Point(8, 35)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(89, 14)
        Me.lblLicense.TabIndex = 2
        Me.lblLicense.Text = "Unregistered"
        '
        'btnCredits
        '
        Me.btnCredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCredits.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCredits.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCredits.ForeColor = System.Drawing.Color.White
        Me.btnCredits.Location = New System.Drawing.Point(12, 395)
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(100, 27)
        Me.btnCredits.TabIndex = 8
        Me.btnCredits.Text = "About"
        '
        'gbWeather
        '
        Me.gbWeather.Controls.Add(Me.lblTown)
        Me.gbWeather.Controls.Add(Me.cmbTown)
        Me.gbWeather.Controls.Add(Me.cmbStates)
        Me.gbWeather.Controls.Add(Me.lblState)
        Me.gbWeather.DrawSeperator = True
        Me.gbWeather.Location = New System.Drawing.Point(12, 128)
        Me.gbWeather.Name = "gbWeather"
        Me.gbWeather.Padding = New System.Windows.Forms.Padding(5)
        Me.gbWeather.Size = New System.Drawing.Size(397, 104)
        Me.gbWeather.SubTitle = ""
        Me.gbWeather.TabIndex = 3
        Me.gbWeather.Text = "NsGroupBox1"
        Me.gbWeather.Title = "Weather Forecast Settings"
        '
        'lblTown
        '
        Me.lblTown.AutoSize = True
        Me.lblTown.BackColor = System.Drawing.Color.Transparent
        Me.lblTown.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblTown.ForeColor = System.Drawing.Color.White
        Me.lblTown.Location = New System.Drawing.Point(8, 72)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(40, 14)
        Me.lblTown.TabIndex = 18
        Me.lblTown.Text = "Town"
        '
        'cmbTown
        '
        Me.cmbTown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTown.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbTown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTown.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbTown.ForeColor = System.Drawing.Color.White
        Me.cmbTown.FormattingEnabled = True
        Me.cmbTown.ItemHeight = 20
        Me.cmbTown.Location = New System.Drawing.Point(117, 69)
        Me.cmbTown.Name = "cmbTown"
        Me.cmbTown.Size = New System.Drawing.Size(272, 26)
        Me.cmbTown.TabIndex = 1
        '
        'cmbStates
        '
        Me.cmbStates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStates.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbStates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStates.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbStates.ForeColor = System.Drawing.Color.White
        Me.cmbStates.FormattingEnabled = True
        Me.cmbStates.ItemHeight = 20
        Me.cmbStates.Location = New System.Drawing.Point(117, 37)
        Me.cmbStates.Name = "cmbStates"
        Me.cmbStates.Size = New System.Drawing.Size(272, 26)
        Me.cmbStates.TabIndex = 0
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.BackColor = System.Drawing.Color.Transparent
        Me.lblState.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblState.ForeColor = System.Drawing.Color.White
        Me.lblState.Location = New System.Drawing.Point(8, 40)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(48, 14)
        Me.lblState.TabIndex = 14
        Me.lblState.Text = "States"
        '
        'cbClose
        '
        Me.cbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbClose.ControlButton = ResMon.NSControlButton.Button.Close
        Me.cbClose.Location = New System.Drawing.Point(397, 4)
        Me.cbClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.Name = "cbClose"
        Me.cbClose.Size = New System.Drawing.Size(18, 20)
        Me.cbClose.TabIndex = 12
        Me.cbClose.Text = "NsControlButton1"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(309, 395)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 27)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        '
        'lblBroadcastPort
        '
        Me.lblBroadcastPort.AutoSize = True
        Me.lblBroadcastPort.BackColor = System.Drawing.Color.Transparent
        Me.lblBroadcastPort.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblBroadcastPort.ForeColor = System.Drawing.Color.White
        Me.lblBroadcastPort.Location = New System.Drawing.Point(8, 75)
        Me.lblBroadcastPort.Name = "lblBroadcastPort"
        Me.lblBroadcastPort.Size = New System.Drawing.Size(100, 14)
        Me.lblBroadcastPort.TabIndex = 5
        Me.lblBroadcastPort.Text = "Broadcast Port"
        '
        'cbBroadcast
        '
        Me.cbBroadcast.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbBroadcast.Checked = False
        Me.cbBroadcast.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbBroadcast.ForeColor = System.Drawing.Color.White
        Me.cbBroadcast.Location = New System.Drawing.Point(12, 102)
        Me.cbBroadcast.Name = "cbBroadcast"
        Me.cbBroadcast.Size = New System.Drawing.Size(144, 20)
        Me.cbBroadcast.TabIndex = 2
        Me.cbBroadcast.Text = "Enable Broadcast"
        '
        'txtPort
        '
        Me.txtPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPort.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtPort.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtPort.Location = New System.Drawing.Point(128, 70)
        Me.txtPort.MaxLength = 32767
        Me.txtPort.Multiline = False
        Me.txtPort.Name = "txtPort"
        Me.txtPort.ReadOnly = False
        Me.txtPort.Size = New System.Drawing.Size(282, 26)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "8080"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPort.UseSystemPasswordChar = False
        '
        'cbAuto
        '
        Me.cbAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbAuto.Checked = False
        Me.cbAuto.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbAuto.ForeColor = System.Drawing.Color.White
        Me.cbAuto.Location = New System.Drawing.Point(12, 238)
        Me.cbAuto.Name = "cbAuto"
        Me.cbAuto.Size = New System.Drawing.Size(166, 20)
        Me.cbAuto.TabIndex = 4
        Me.cbAuto.Text = "Start with Windows"
        '
        'cmbNetwork
        '
        Me.cmbNetwork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbNetwork.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbNetwork.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNetwork.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbNetwork.ForeColor = System.Drawing.Color.White
        Me.cmbNetwork.FormattingEnabled = True
        Me.cmbNetwork.ItemHeight = 20
        Me.cmbNetwork.Location = New System.Drawing.Point(128, 38)
        Me.cmbNetwork.Name = "cmbNetwork"
        Me.cmbNetwork.Size = New System.Drawing.Size(282, 26)
        Me.cmbNetwork.TabIndex = 0
        '
        'lblNetworkAdapter
        '
        Me.lblNetworkAdapter.AutoSize = True
        Me.lblNetworkAdapter.BackColor = System.Drawing.Color.Transparent
        Me.lblNetworkAdapter.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblNetworkAdapter.ForeColor = System.Drawing.Color.White
        Me.lblNetworkAdapter.Location = New System.Drawing.Point(8, 41)
        Me.lblNetworkAdapter.Name = "lblNetworkAdapter"
        Me.lblNetworkAdapter.Size = New System.Drawing.Size(114, 14)
        Me.lblNetworkAdapter.TabIndex = 1
        Me.lblNetworkAdapter.Text = "Network Adapter"
        '
        'frmSetting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(421, 430)
        Me.Controls.Add(Me.nsTheme)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.nsTheme.ResumeLayout(False)
        Me.nsTheme.PerformLayout()
        Me.gbLicense.ResumeLayout(False)
        Me.gbLicense.PerformLayout()
        Me.gbWeather.ResumeLayout(False)
        Me.gbWeather.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbNetwork As NSComboBox
    Friend WithEvents lblNetworkAdapter As Label
    Friend WithEvents cbAuto As NSCheckBox
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbBroadcast As NSCheckBox
    Friend WithEvents lblBroadcastPort As Label
    Friend WithEvents txtPort As NSTextBox
    Friend WithEvents nsTheme As NSTheme
    Friend WithEvents cbClose As NSControlButton
    Friend WithEvents gbWeather As NSGroupBox
    Friend WithEvents cmbStates As NSComboBox
    Friend WithEvents lblState As Label
    Friend WithEvents lblTown As Label
    Friend WithEvents cmbTown As NSComboBox
    Friend WithEvents cbTopMost As NSCheckBox
    Friend WithEvents btnCredits As NSButton
    Friend WithEvents gbLicense As NSGroupBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblLicense As Label
    Friend WithEvents btnActivate As NSButton
    Friend WithEvents lblKey As Label
    Friend WithEvents cmbLanguage As NSComboBox
    Friend WithEvents lblLanguage As Label
End Class
