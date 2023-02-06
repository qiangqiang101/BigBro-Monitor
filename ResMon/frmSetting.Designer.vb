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
        Me.cbResetSPanel = New MaterialSkin.Controls.MaterialCheckbox()
        Me.cbHQAE = New MaterialSkin.Controls.MaterialCheckbox()
        Me.cbHQRgb = New MaterialSkin.Controls.MaterialCheckbox()
        Me.gbSecondScreen = New System.Windows.Forms.GroupBox()
        Me.txtSSHeight = New MaterialSkin.Controls.MaterialTextBox()
        Me.lblSSSize = New MaterialSkin.Controls.MaterialLabel()
        Me.txtSSWidth = New MaterialSkin.Controls.MaterialTextBox()
        Me.cbSSPosReset = New MaterialSkin.Controls.MaterialCheckbox()
        Me.lblSSYTID = New MaterialSkin.Controls.MaterialLabel()
        Me.txtSSTYID = New MaterialSkin.Controls.MaterialTextBox()
        Me.cbSSEnable = New MaterialSkin.Controls.MaterialCheckbox()
        Me.gbWeather.SuspendLayout()
        Me.gbSecondScreen.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbTopMost
        '
        Me.cbTopMost.AutoSize = True
        Me.cbTopMost.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbTopMost.Depth = 0
        Me.cbTopMost.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbTopMost.ForeColor = System.Drawing.Color.White
        Me.cbTopMost.Location = New System.Drawing.Point(250, 332)
        Me.cbTopMost.Margin = New System.Windows.Forms.Padding(0)
        Me.cbTopMost.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbTopMost.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbTopMost.Name = "cbTopMost"
        Me.cbTopMost.Ripple = True
        Me.cbTopMost.Size = New System.Drawing.Size(175, 37)
        Me.cbTopMost.TabIndex = 8
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
        Me.cmbLanguage.DropDownHeight = 118
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.DropDownWidth = 121
        Me.cmbLanguage.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbLanguage.ForeColor = System.Drawing.Color.White
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.IntegralHeight = False
        Me.cmbLanguage.ItemHeight = 29
        Me.cmbLanguage.Location = New System.Drawing.Point(133, 409)
        Me.cmbLanguage.MaxDropDownItems = 4
        Me.cmbLanguage.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(345, 35)
        Me.cmbLanguage.StartIndex = 0
        Me.cmbLanguage.TabIndex = 10
        Me.cmbLanguage.UseTallSize = False
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
        Me.lblLanguage.Depth = 0
        Me.lblLanguage.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblLanguage.ForeColor = System.Drawing.Color.White
        Me.lblLanguage.Location = New System.Drawing.Point(6, 411)
        Me.lblLanguage.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(72, 19)
        Me.lblLanguage.TabIndex = 15
        Me.lblLanguage.Text = "Language"
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
        Me.btnCredits.Location = New System.Drawing.Point(9, 607)
        Me.btnCredits.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnCredits.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(120, 36)
        Me.btnCredits.TabIndex = 20
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
        Me.lblTown.Location = New System.Drawing.Point(6, 64)
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
        Me.cmbTown.DropDownHeight = 118
        Me.cmbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTown.DropDownWidth = 121
        Me.cmbTown.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbTown.ForeColor = System.Drawing.Color.White
        Me.cmbTown.FormattingEnabled = True
        Me.cmbTown.IntegralHeight = False
        Me.cmbTown.ItemHeight = 29
        Me.cmbTown.Location = New System.Drawing.Point(121, 62)
        Me.cmbTown.MaxDropDownItems = 4
        Me.cmbTown.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbTown.Name = "cmbTown"
        Me.cmbTown.Size = New System.Drawing.Size(345, 35)
        Me.cmbTown.StartIndex = 0
        Me.cmbTown.TabIndex = 1
        Me.cmbTown.UseTallSize = False
        '
        'cmbStates
        '
        Me.cmbStates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStates.AutoResize = False
        Me.cmbStates.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cmbStates.Depth = 0
        Me.cmbStates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbStates.DropDownHeight = 118
        Me.cmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStates.DropDownWidth = 121
        Me.cmbStates.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbStates.ForeColor = System.Drawing.Color.White
        Me.cmbStates.FormattingEnabled = True
        Me.cmbStates.IntegralHeight = False
        Me.cmbStates.ItemHeight = 29
        Me.cmbStates.Location = New System.Drawing.Point(121, 21)
        Me.cmbStates.MaxDropDownItems = 4
        Me.cmbStates.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbStates.Name = "cmbStates"
        Me.cmbStates.Size = New System.Drawing.Size(345, 35)
        Me.cmbStates.StartIndex = 0
        Me.cmbStates.TabIndex = 0
        Me.cmbStates.UseTallSize = False
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
        Me.btnSave.Location = New System.Drawing.Point(357, 607)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnSave.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 36)
        Me.btnSave.TabIndex = 21
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
        Me.lblBroadcastPort.Location = New System.Drawing.Point(6, 110)
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
        Me.cbBroadcast.Location = New System.Drawing.Point(3, 147)
        Me.cbBroadcast.Margin = New System.Windows.Forms.Padding(0)
        Me.cbBroadcast.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbBroadcast.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbBroadcast.Name = "cbBroadcast"
        Me.cbBroadcast.Ripple = True
        Me.cbBroadcast.Size = New System.Drawing.Size(159, 37)
        Me.cbBroadcast.TabIndex = 2
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
        Me.txtPort.Location = New System.Drawing.Point(133, 108)
        Me.txtPort.MaxLength = 32767
        Me.txtPort.MouseState = MaterialSkin.MouseState.OUT
        Me.txtPort.Multiline = False
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(345, 36)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "8080"
        Me.txtPort.TrailingIcon = Nothing
        Me.txtPort.UseTallSize = False
        '
        'cbAuto
        '
        Me.cbAuto.AutoSize = True
        Me.cbAuto.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbAuto.Depth = 0
        Me.cbAuto.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbAuto.ForeColor = System.Drawing.Color.White
        Me.cbAuto.Location = New System.Drawing.Point(3, 332)
        Me.cbAuto.Margin = New System.Windows.Forms.Padding(0)
        Me.cbAuto.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbAuto.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbAuto.Name = "cbAuto"
        Me.cbAuto.Ripple = True
        Me.cbAuto.Size = New System.Drawing.Size(172, 37)
        Me.cbAuto.TabIndex = 7
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
        Me.cmbNetwork.DropDownHeight = 118
        Me.cmbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNetwork.DropDownWidth = 121
        Me.cmbNetwork.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cmbNetwork.ForeColor = System.Drawing.Color.White
        Me.cmbNetwork.FormattingEnabled = True
        Me.cmbNetwork.IntegralHeight = False
        Me.cmbNetwork.ItemHeight = 29
        Me.cmbNetwork.Location = New System.Drawing.Point(133, 67)
        Me.cmbNetwork.MaxDropDownItems = 4
        Me.cmbNetwork.MouseState = MaterialSkin.MouseState.OUT
        Me.cmbNetwork.Name = "cmbNetwork"
        Me.cmbNetwork.Size = New System.Drawing.Size(345, 35)
        Me.cmbNetwork.StartIndex = 0
        Me.cmbNetwork.TabIndex = 0
        Me.cmbNetwork.UseTallSize = False
        '
        'lblNetworkAdapter
        '
        Me.lblNetworkAdapter.AutoSize = True
        Me.lblNetworkAdapter.BackColor = System.Drawing.Color.Transparent
        Me.lblNetworkAdapter.Depth = 0
        Me.lblNetworkAdapter.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNetworkAdapter.ForeColor = System.Drawing.Color.White
        Me.lblNetworkAdapter.Location = New System.Drawing.Point(6, 69)
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
        Me.gbWeather.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.gbWeather.Location = New System.Drawing.Point(6, 224)
        Me.gbWeather.Name = "gbWeather"
        Me.gbWeather.Size = New System.Drawing.Size(472, 105)
        Me.gbWeather.TabIndex = 6
        Me.gbWeather.TabStop = False
        Me.gbWeather.Text = "Weather Forecast Settings"
        '
        'cbResetSPanel
        '
        Me.cbResetSPanel.AutoSize = True
        Me.cbResetSPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbResetSPanel.Depth = 0
        Me.cbResetSPanel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbResetSPanel.ForeColor = System.Drawing.Color.White
        Me.cbResetSPanel.Location = New System.Drawing.Point(3, 369)
        Me.cbResetSPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.cbResetSPanel.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbResetSPanel.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbResetSPanel.Name = "cbResetSPanel"
        Me.cbResetSPanel.Ripple = True
        Me.cbResetSPanel.Size = New System.Drawing.Size(233, 37)
        Me.cbResetSPanel.TabIndex = 9
        Me.cbResetSPanel.Text = "Reset Sensor Panel Position"
        Me.cbResetSPanel.UseVisualStyleBackColor = False
        '
        'cbHQAE
        '
        Me.cbHQAE.AutoSize = True
        Me.cbHQAE.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbHQAE.Depth = 0
        Me.cbHQAE.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbHQAE.ForeColor = System.Drawing.Color.White
        Me.cbHQAE.Location = New System.Drawing.Point(250, 184)
        Me.cbHQAE.Margin = New System.Windows.Forms.Padding(0)
        Me.cbHQAE.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbHQAE.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbHQAE.Name = "cbHQAE"
        Me.cbHQAE.Ripple = True
        Me.cbHQAE.Size = New System.Drawing.Size(156, 37)
        Me.cbHQAE.TabIndex = 5
        Me.cbHQAE.Text = "HQ Audio Effects"
        Me.cbHQAE.UseVisualStyleBackColor = False
        '
        'cbHQRgb
        '
        Me.cbHQRgb.AutoSize = True
        Me.cbHQRgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbHQRgb.Depth = 0
        Me.cbHQRgb.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbHQRgb.ForeColor = System.Drawing.Color.White
        Me.cbHQRgb.Location = New System.Drawing.Point(3, 184)
        Me.cbHQRgb.Margin = New System.Windows.Forms.Padding(0)
        Me.cbHQRgb.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbHQRgb.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbHQRgb.Name = "cbHQRgb"
        Me.cbHQRgb.Ripple = True
        Me.cbHQRgb.Size = New System.Drawing.Size(146, 37)
        Me.cbHQRgb.TabIndex = 4
        Me.cbHQRgb.Text = "HQ RGB Effects"
        Me.cbHQRgb.UseVisualStyleBackColor = False
        '
        'gbSecondScreen
        '
        Me.gbSecondScreen.Controls.Add(Me.txtSSHeight)
        Me.gbSecondScreen.Controls.Add(Me.lblSSSize)
        Me.gbSecondScreen.Controls.Add(Me.txtSSWidth)
        Me.gbSecondScreen.Controls.Add(Me.cbSSPosReset)
        Me.gbSecondScreen.Controls.Add(Me.lblSSYTID)
        Me.gbSecondScreen.Controls.Add(Me.txtSSTYID)
        Me.gbSecondScreen.Controls.Add(Me.cbSSEnable)
        Me.gbSecondScreen.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.gbSecondScreen.Location = New System.Drawing.Point(6, 450)
        Me.gbSecondScreen.Name = "gbSecondScreen"
        Me.gbSecondScreen.Size = New System.Drawing.Size(472, 150)
        Me.gbSecondScreen.TabIndex = 11
        Me.gbSecondScreen.TabStop = False
        Me.gbSecondScreen.Text = "Second Screen"
        '
        'txtSSHeight
        '
        Me.txtSSHeight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSSHeight.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtSSHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSSHeight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSSHeight.Depth = 0
        Me.txtSSHeight.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtSSHeight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtSSHeight.LeadingIcon = Nothing
        Me.txtSSHeight.Location = New System.Drawing.Point(297, 100)
        Me.txtSSHeight.MaxLength = 32767
        Me.txtSSHeight.MouseState = MaterialSkin.MouseState.OUT
        Me.txtSSHeight.Multiline = False
        Me.txtSSHeight.Name = "txtSSHeight"
        Me.txtSSHeight.Size = New System.Drawing.Size(169, 36)
        Me.txtSSHeight.TabIndex = 4
        Me.txtSSHeight.Text = "600"
        Me.txtSSHeight.TrailingIcon = Nothing
        Me.txtSSHeight.UseTallSize = False
        '
        'lblSSSize
        '
        Me.lblSSSize.AutoSize = True
        Me.lblSSSize.BackColor = System.Drawing.Color.Transparent
        Me.lblSSSize.Depth = 0
        Me.lblSSSize.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSSSize.ForeColor = System.Drawing.Color.White
        Me.lblSSSize.Location = New System.Drawing.Point(6, 103)
        Me.lblSSSize.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblSSSize.Name = "lblSSSize"
        Me.lblSSSize.Size = New System.Drawing.Size(83, 19)
        Me.lblSSSize.TabIndex = 9
        Me.lblSSSize.Text = "Screen Size"
        '
        'txtSSWidth
        '
        Me.txtSSWidth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSSWidth.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtSSWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSSWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSSWidth.Depth = 0
        Me.txtSSWidth.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtSSWidth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtSSWidth.LeadingIcon = Nothing
        Me.txtSSWidth.Location = New System.Drawing.Point(121, 100)
        Me.txtSSWidth.MaxLength = 32767
        Me.txtSSWidth.MouseState = MaterialSkin.MouseState.OUT
        Me.txtSSWidth.Multiline = False
        Me.txtSSWidth.Name = "txtSSWidth"
        Me.txtSSWidth.Size = New System.Drawing.Size(169, 36)
        Me.txtSSWidth.TabIndex = 3
        Me.txtSSWidth.Text = "1024"
        Me.txtSSWidth.TrailingIcon = Nothing
        Me.txtSSWidth.UseTallSize = False
        '
        'cbSSPosReset
        '
        Me.cbSSPosReset.AutoSize = True
        Me.cbSSPosReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbSSPosReset.Depth = 0
        Me.cbSSPosReset.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbSSPosReset.ForeColor = System.Drawing.Color.White
        Me.cbSSPosReset.Location = New System.Drawing.Point(244, 18)
        Me.cbSSPosReset.Margin = New System.Windows.Forms.Padding(0)
        Me.cbSSPosReset.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbSSPosReset.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbSSPosReset.Name = "cbSSPosReset"
        Me.cbSSPosReset.Ripple = True
        Me.cbSSPosReset.Size = New System.Drawing.Size(219, 37)
        Me.cbSSPosReset.TabIndex = 1
        Me.cbSSPosReset.Text = "Reset 2nd Screen Position"
        Me.cbSSPosReset.UseVisualStyleBackColor = False
        '
        'lblSSYTID
        '
        Me.lblSSYTID.AutoSize = True
        Me.lblSSYTID.BackColor = System.Drawing.Color.Transparent
        Me.lblSSYTID.Depth = 0
        Me.lblSSYTID.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSSYTID.ForeColor = System.Drawing.Color.White
        Me.lblSSYTID.Location = New System.Drawing.Point(6, 61)
        Me.lblSSYTID.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblSSYTID.Name = "lblSSYTID"
        Me.lblSSYTID.Size = New System.Drawing.Size(106, 19)
        Me.lblSSYTID.TabIndex = 7
        Me.lblSSYTID.Text = "Youtube Vid ID"
        '
        'txtSSTYID
        '
        Me.txtSSTYID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSSTYID.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtSSTYID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSSTYID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSSTYID.Depth = 0
        Me.txtSSTYID.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtSSTYID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtSSTYID.LeadingIcon = Nothing
        Me.txtSSTYID.Location = New System.Drawing.Point(121, 58)
        Me.txtSSTYID.MaxLength = 32767
        Me.txtSSTYID.MouseState = MaterialSkin.MouseState.OUT
        Me.txtSSTYID.Multiline = False
        Me.txtSSTYID.Name = "txtSSTYID"
        Me.txtSSTYID.Size = New System.Drawing.Size(345, 36)
        Me.txtSSTYID.TabIndex = 2
        Me.txtSSTYID.Text = "VKNRNeRDs0Q"
        Me.txtSSTYID.TrailingIcon = Nothing
        Me.txtSSTYID.UseTallSize = False
        '
        'cbSSEnable
        '
        Me.cbSSEnable.AutoSize = True
        Me.cbSSEnable.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cbSSEnable.Depth = 0
        Me.cbSSEnable.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbSSEnable.ForeColor = System.Drawing.Color.White
        Me.cbSSEnable.Location = New System.Drawing.Point(3, 18)
        Me.cbSSEnable.Margin = New System.Windows.Forms.Padding(0)
        Me.cbSSEnable.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.cbSSEnable.MouseState = MaterialSkin.MouseState.HOVER
        Me.cbSSEnable.Name = "cbSSEnable"
        Me.cbSSEnable.Ripple = True
        Me.cbSSEnable.Size = New System.Drawing.Size(192, 37)
        Me.cbSSEnable.TabIndex = 0
        Me.cbSSEnable.Text = "Enable Second Screen"
        Me.cbSSEnable.UseVisualStyleBackColor = False
        '
        'frmSetting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(484, 652)
        Me.Controls.Add(Me.gbSecondScreen)
        Me.Controls.Add(Me.cbHQAE)
        Me.Controls.Add(Me.cbHQRgb)
        Me.Controls.Add(Me.cbResetSPanel)
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
        Me.gbSecondScreen.ResumeLayout(False)
        Me.gbSecondScreen.PerformLayout()
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
    Friend WithEvents cmbLanguage As MaterialComboBox
    Friend WithEvents lblLanguage As MaterialLabel
    Friend WithEvents gbWeather As GroupBox
    Friend WithEvents cbResetSPanel As MaterialCheckbox
    Friend WithEvents cbHQAE As MaterialCheckbox
    Friend WithEvents cbHQRgb As MaterialCheckbox
    Friend WithEvents gbSecondScreen As GroupBox
    Friend WithEvents lblSSYTID As MaterialLabel
    Friend WithEvents txtSSTYID As MaterialTextBox
    Friend WithEvents cbSSEnable As MaterialCheckbox
    Friend WithEvents cbSSPosReset As MaterialCheckbox
    Friend WithEvents txtSSHeight As MaterialTextBox
    Friend WithEvents lblSSSize As MaterialLabel
    Friend WithEvents txtSSWidth As MaterialTextBox
End Class
