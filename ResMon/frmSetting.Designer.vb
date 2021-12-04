Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetting
    Inherits MaterialForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetting))
        Me.cbTopMost = New MaterialSkin.Controls.MaterialCheckbox()
        Me.cmbLanguage = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblLanguage = New MaterialSkin.Controls.MaterialLabel()
        Me.lblKey = New MaterialSkin.Controls.MaterialLabel()
        Me.btnActivate = New MaterialSkin.Controls.MaterialButton()
        Me.lblName = New MaterialSkin.Controls.MaterialLabel()
        Me.lblLicense = New MaterialSkin.Controls.MaterialLabel()
        Me.btnCredits = New MaterialSkin.Controls.MaterialButton()
        Me.lblTown = New MaterialSkin.Controls.MaterialLabel()
        Me.cmbTown = New MaterialSkin.Controls.MaterialComboBox()
        Me.cmbStates = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblState = New MaterialSkin.Controls.MaterialLabel()
        Me.btnSave = New MaterialSkin.Controls.MaterialButton()
        Me.lblBroadcastPort = New MaterialSkin.Controls.MaterialLabel()
        Me.cbBroadcast = New MaterialSkin.Controls.MaterialCheckbox()
        Me.txtPort = New MaterialSkin.Controls.MaterialTextBox()
        Me.cbAuto = New MaterialSkin.Controls.MaterialCheckbox()
        Me.cmbNetwork = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblNetworkAdapter = New MaterialSkin.Controls.MaterialLabel()
        Me.gbWeather = New System.Windows.Forms.GroupBox()
        Me.gbLicense = New System.Windows.Forms.GroupBox()
        Me.cmbCPUFan = New MaterialSkin.Controls.MaterialComboBox()
        Me.lblCPUFan = New MaterialSkin.Controls.MaterialLabel()
        Me.gbWeather.SuspendLayout()
        Me.gbLicense.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbTopMost
        '
        Me.cbTopMost.AutoSize = True
        Me.cbTopMost.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbTopMost.Depth = 0
        Me.cbTopMost.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbTopMost.ForeColor = System.Drawing.Color.White
        Me.cbTopMost.Location = New System.Drawing.Point(221, 408)
        Me.cbTopMost.Margin = New System.Windows.Forms.Padding(0)
        Me.cbTopMost.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbTopMost.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbTopMost.Name = "cbTopMost"
        Me.cbTopMost.Ripple = True
        Me.cbTopMost.Size = New System.Drawing.Size(175, 37)
        Me.cbTopMost.TabIndex = 6
        Me.cbTopMost.Text = "Monitor Stay on top"
        Me.cbTopMost.UseVisualStyleBackColor = False
        '
        'cmbLanguage
        '
        Me.cmbLanguage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLanguage.AutoResize = False
        Me.cmbLanguage.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbLanguage.Depth = 0
        Me.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbLanguage.DropDownHeight = 174
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.DropDownWidth = 121
        Me.cmbLanguage.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbLanguage.ForeColor = System.Drawing.Color.White
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.IntegralHeight = False
        Me.cmbLanguage.ItemHeight = 43
        Me.cmbLanguage.Location = New System.Drawing.Point(132, 448)
        Me.cmbLanguage.MaxDropDownItems = 4
        Me.cmbLanguage.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(345, 49)
        Me.cmbLanguage.StartIndex = 0
        Me.cmbLanguage.TabIndex = 7
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
        Me.lblLanguage.Depth = 0
        Me.lblLanguage.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblLanguage.ForeColor = System.Drawing.Color.White
        Me.lblLanguage.Location = New System.Drawing.Point(5, 450)
        Me.lblLanguage.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(72, 19)
        Me.lblLanguage.TabIndex = 15
        Me.lblLanguage.Text = "Language"
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.BackColor = System.Drawing.Color.Transparent
        Me.lblKey.Depth = 0
        Me.lblKey.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblKey.ForeColor = System.Drawing.Color.White
        Me.lblKey.Location = New System.Drawing.Point(6, 37)
        Me.lblKey.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(36, 19)
        Me.lblKey.TabIndex = 10
        Me.lblKey.Text = "_____"
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
        Me.btnActivate.Location = New System.Drawing.Point(345, 40)
        Me.btnActivate.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnActivate.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(120, 36)
        Me.btnActivate.TabIndex = 0
        Me.btnActivate.Text = "Activate"
        Me.btnActivate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnActivate.UseAccentColor = False
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Depth = 0
        Me.lblName.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(6, 56)
        Me.lblName.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(67, 19)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "PC Name"
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.BackColor = System.Drawing.Color.Transparent
        Me.lblLicense.Depth = 0
        Me.lblLicense.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblLicense.ForeColor = System.Drawing.Color.White
        Me.lblLicense.Location = New System.Drawing.Point(6, 18)
        Me.lblLicense.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(89, 19)
        Me.lblLicense.TabIndex = 2
        Me.lblLicense.Text = "Unregistered"
        '
        'btnCredits
        '
        Me.btnCredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCredits.AutoSize = False
        Me.btnCredits.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCredits.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCredits.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnCredits.Depth = 0
        Me.btnCredits.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCredits.ForeColor = System.Drawing.Color.White
        Me.btnCredits.HighEmphasis = True
        Me.btnCredits.Icon = Nothing
        Me.btnCredits.Location = New System.Drawing.Point(9, 594)
        Me.btnCredits.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnCredits.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(120, 36)
        Me.btnCredits.TabIndex = 9
        Me.btnCredits.Text = "About"
        Me.btnCredits.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnCredits.UseAccentColor = False
        Me.btnCredits.UseVisualStyleBackColor = False
        '
        'lblTown
        '
        Me.lblTown.AutoSize = True
        Me.lblTown.BackColor = System.Drawing.Color.Transparent
        Me.lblTown.Depth = 0
        Me.lblTown.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTown.ForeColor = System.Drawing.Color.White
        Me.lblTown.Location = New System.Drawing.Point(6, 78)
        Me.lblTown.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(41, 19)
        Me.lblTown.TabIndex = 18
        Me.lblTown.Text = "Town"
        '
        'cmbTown
        '
        Me.cmbTown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTown.AutoResize = False
        Me.cmbTown.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbTown.Depth = 0
        Me.cmbTown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbTown.DropDownHeight = 174
        Me.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTown.DropDownWidth = 121
        Me.cmbTown.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbTown.ForeColor = System.Drawing.Color.White
        Me.cmbTown.FormattingEnabled = True
        Me.cmbTown.IntegralHeight = False
        Me.cmbTown.ItemHeight = 43
        Me.cmbTown.Location = New System.Drawing.Point(121, 76)
        Me.cmbTown.MaxDropDownItems = 4
        Me.cmbTown.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbTown.Name = "cmbTown"
        Me.cmbTown.Size = New System.Drawing.Size(345, 49)
        Me.cmbTown.StartIndex = 0
        Me.cmbTown.TabIndex = 1
        '
        'cmbStates
        '
        Me.cmbStates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStates.AutoResize = False
        Me.cmbStates.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbStates.Depth = 0
        Me.cmbStates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbStates.DropDownHeight = 174
        Me.cmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStates.DropDownWidth = 121
        Me.cmbStates.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbStates.ForeColor = System.Drawing.Color.White
        Me.cmbStates.FormattingEnabled = True
        Me.cmbStates.IntegralHeight = False
        Me.cmbStates.ItemHeight = 43
        Me.cmbStates.Location = New System.Drawing.Point(121, 21)
        Me.cmbStates.MaxDropDownItems = 4
        Me.cmbStates.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbStates.Name = "cmbStates"
        Me.cmbStates.Size = New System.Drawing.Size(345, 49)
        Me.cmbStates.StartIndex = 0
        Me.cmbStates.TabIndex = 0
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.BackColor = System.Drawing.Color.Transparent
        Me.lblState.Depth = 0
        Me.lblState.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblState.ForeColor = System.Drawing.Color.White
        Me.lblState.Location = New System.Drawing.Point(6, 23)
        Me.lblState.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(46, 19)
        Me.lblState.TabIndex = 14
        Me.lblState.Text = "States"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = False
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnSave.Depth = 0
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.HighEmphasis = True
        Me.btnSave.Icon = Nothing
        Me.btnSave.Location = New System.Drawing.Point(357, 594)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnSave.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 36)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnSave.UseAccentColor = True
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblBroadcastPort
        '
        Me.lblBroadcastPort.AutoSize = True
        Me.lblBroadcastPort.BackColor = System.Drawing.Color.Transparent
        Me.lblBroadcastPort.Depth = 0
        Me.lblBroadcastPort.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblBroadcastPort.ForeColor = System.Drawing.Color.White
        Me.lblBroadcastPort.Location = New System.Drawing.Point(6, 179)
        Me.lblBroadcastPort.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblBroadcastPort.Name = "lblBroadcastPort"
        Me.lblBroadcastPort.Size = New System.Drawing.Size(106, 19)
        Me.lblBroadcastPort.TabIndex = 5
        Me.lblBroadcastPort.Text = "Broadcast Port"
        '
        'cbBroadcast
        '
        Me.cbBroadcast.AutoSize = True
        Me.cbBroadcast.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbBroadcast.Depth = 0
        Me.cbBroadcast.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbBroadcast.ForeColor = System.Drawing.Color.White
        Me.cbBroadcast.Location = New System.Drawing.Point(132, 230)
        Me.cbBroadcast.Margin = New System.Windows.Forms.Padding(0)
        Me.cbBroadcast.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbBroadcast.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbBroadcast.Name = "cbBroadcast"
        Me.cbBroadcast.Ripple = True
        Me.cbBroadcast.Size = New System.Drawing.Size(159, 37)
        Me.cbBroadcast.TabIndex = 3
        Me.cbBroadcast.Text = "Enable Broadcast"
        Me.cbBroadcast.UseVisualStyleBackColor = False
        '
        'txtPort
        '
        Me.txtPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPort.Depth = 0
        Me.txtPort.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtPort.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtPort.LeadingIcon = Nothing
        Me.txtPort.Location = New System.Drawing.Point(133, 177)
        Me.txtPort.MaxLength = 32767
        Me.txtPort.MouseState = MaterialSkin.MouseState.OUT
        Me.txtPort.Multiline = False
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(345, 50)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "8080"
        Me.txtPort.TrailingIcon = Nothing
        '
        'cbAuto
        '
        Me.cbAuto.AutoSize = True
        Me.cbAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbAuto.Depth = 0
        Me.cbAuto.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbAuto.ForeColor = System.Drawing.Color.White
        Me.cbAuto.Location = New System.Drawing.Point(3, 408)
        Me.cbAuto.Margin = New System.Windows.Forms.Padding(0)
        Me.cbAuto.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbAuto.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbAuto.Name = "cbAuto"
        Me.cbAuto.Ripple = True
        Me.cbAuto.Size = New System.Drawing.Size(172, 37)
        Me.cbAuto.TabIndex = 5
        Me.cbAuto.Text = "Start with Windows"
        Me.cbAuto.UseVisualStyleBackColor = False
        '
        'cmbNetwork
        '
        Me.cmbNetwork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbNetwork.AutoResize = False
        Me.cmbNetwork.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbNetwork.Depth = 0
        Me.cmbNetwork.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbNetwork.DropDownHeight = 174
        Me.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNetwork.DropDownWidth = 121
        Me.cmbNetwork.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbNetwork.ForeColor = System.Drawing.Color.White
        Me.cmbNetwork.FormattingEnabled = True
        Me.cmbNetwork.IntegralHeight = False
        Me.cmbNetwork.ItemHeight = 43
        Me.cmbNetwork.Location = New System.Drawing.Point(133, 67)
        Me.cmbNetwork.MaxDropDownItems = 4
        Me.cmbNetwork.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbNetwork.Name = "cmbNetwork"
        Me.cmbNetwork.Size = New System.Drawing.Size(345, 49)
        Me.cmbNetwork.StartIndex = 0
        Me.cmbNetwork.TabIndex = 0
        '
        'lblNetworkAdapter
        '
        Me.lblNetworkAdapter.AutoSize = True
        Me.lblNetworkAdapter.BackColor = System.Drawing.Color.Transparent
        Me.lblNetworkAdapter.Depth = 0
        Me.lblNetworkAdapter.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNetworkAdapter.ForeColor = System.Drawing.Color.White
        Me.lblNetworkAdapter.Location = New System.Drawing.Point(6, 76)
        Me.lblNetworkAdapter.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblNetworkAdapter.Name = "lblNetworkAdapter"
        Me.lblNetworkAdapter.Size = New System.Drawing.Size(118, 19)
        Me.lblNetworkAdapter.TabIndex = 1
        Me.lblNetworkAdapter.Text = "Network Adapter"
        '
        'gbWeather
        '
        Me.gbWeather.Controls.Add(Me.cmbStates)
        Me.gbWeather.Controls.Add(Me.lblState)
        Me.gbWeather.Controls.Add(Me.lblTown)
        Me.gbWeather.Controls.Add(Me.cmbTown)
        Me.gbWeather.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.gbWeather.Location = New System.Drawing.Point(6, 270)
        Me.gbWeather.Name = "gbWeather"
        Me.gbWeather.Size = New System.Drawing.Size(472, 135)
        Me.gbWeather.TabIndex = 4
        Me.gbWeather.TabStop = False
        Me.gbWeather.Text = "Weather Forecast Settings"
        '
        'gbLicense
        '
        Me.gbLicense.Controls.Add(Me.btnActivate)
        Me.gbLicense.Controls.Add(Me.lblLicense)
        Me.gbLicense.Controls.Add(Me.lblKey)
        Me.gbLicense.Controls.Add(Me.lblName)
        Me.gbLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.gbLicense.Location = New System.Drawing.Point(6, 503)
        Me.gbLicense.Name = "gbLicense"
        Me.gbLicense.Size = New System.Drawing.Size(472, 85)
        Me.gbLicense.TabIndex = 8
        Me.gbLicense.TabStop = False
        Me.gbLicense.Text = "License"
        '
        'cmbCPUFan
        '
        Me.cmbCPUFan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCPUFan.AutoResize = False
        Me.cmbCPUFan.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbCPUFan.Depth = 0
        Me.cmbCPUFan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbCPUFan.DropDownHeight = 174
        Me.cmbCPUFan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPUFan.DropDownWidth = 121
        Me.cmbCPUFan.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbCPUFan.ForeColor = System.Drawing.Color.White
        Me.cmbCPUFan.FormattingEnabled = True
        Me.cmbCPUFan.IntegralHeight = False
        Me.cmbCPUFan.ItemHeight = 43
        Me.cmbCPUFan.Location = New System.Drawing.Point(132, 122)
        Me.cmbCPUFan.MaxDropDownItems = 4
        Me.cmbCPUFan.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbCPUFan.Name = "cmbCPUFan"
        Me.cmbCPUFan.Size = New System.Drawing.Size(345, 49)
        Me.cmbCPUFan.StartIndex = 0
        Me.cmbCPUFan.TabIndex = 1
        '
        'lblCPUFan
        '
        Me.lblCPUFan.AutoSize = True
        Me.lblCPUFan.BackColor = System.Drawing.Color.Transparent
        Me.lblCPUFan.Depth = 0
        Me.lblCPUFan.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblCPUFan.ForeColor = System.Drawing.Color.White
        Me.lblCPUFan.Location = New System.Drawing.Point(5, 131)
        Me.lblCPUFan.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblCPUFan.Name = "lblCPUFan"
        Me.lblCPUFan.Size = New System.Drawing.Size(90, 19)
        Me.lblCPUFan.TabIndex = 17
        Me.lblCPUFan.Text = "CPU Fan No."
        '
        'frmSetting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(484, 639)
        Me.Controls.Add(Me.cmbCPUFan)
        Me.Controls.Add(Me.lblCPUFan)
        Me.Controls.Add(Me.gbLicense)
        Me.Controls.Add(Me.gbWeather)
        Me.Controls.Add(Me.lblBroadcastPort)
        Me.Controls.Add(Me.cbTopMost)
        Me.Controls.Add(Me.cbBroadcast)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.cmbLanguage)
        Me.Controls.Add(Me.cmbNetwork)
        Me.Controls.Add(Me.lblNetworkAdapter)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.btnCredits)
        Me.Controls.Add(Me.cbAuto)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetting"
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gbWeather.ResumeLayout(False)
        Me.gbWeather.PerformLayout()
        Me.gbLicense.ResumeLayout(False)
        Me.gbLicense.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbNetwork As MaterialComboBox
    Friend WithEvents lblNetworkAdapter As MaterialLabel
    Friend WithEvents cbAuto As MaterialCheckbox
    Friend WithEvents btnSave As MaterialButton
    Friend WithEvents cbBroadcast As MaterialCheckbox
    Friend WithEvents lblBroadcastPort As MaterialLabel
    Friend WithEvents txtPort As MaterialTextBox
    Friend WithEvents cmbStates As MaterialComboBox
    Friend WithEvents lblState As MaterialLabel
    Friend WithEvents lblTown As MaterialLabel
    Friend WithEvents cmbTown As MaterialComboBox
    Friend WithEvents cbTopMost As MaterialCheckbox
    Friend WithEvents btnCredits As MaterialButton
    Friend WithEvents lblName As MaterialLabel
    Friend WithEvents lblLicense As MaterialLabel
    Friend WithEvents btnActivate As MaterialButton
    Friend WithEvents lblKey As MaterialLabel
    Friend WithEvents cmbLanguage As MaterialComboBox
    Friend WithEvents lblLanguage As MaterialLabel
    Friend WithEvents gbWeather As GroupBox
    Friend WithEvents gbLicense As GroupBox
    Friend WithEvents cmbCPUFan As MaterialComboBox
    Friend WithEvents lblCPUFan As MaterialLabel
End Class
