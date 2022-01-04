Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.niTray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.scContainer = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.flpThemes = New System.Windows.Forms.FlowLayoutPanel()
        Me.pToolbox = New System.Windows.Forms.Panel()
        Me.btnDownloadTheme = New MaterialSkin.Controls.MaterialButton()
        Me.txtSearch = New MaterialSkin.Controls.MaterialTextBox()
        Me.btnSearch = New MaterialSkin.Controls.MaterialButton()
        Me.btnResetFilter = New MaterialSkin.Controls.MaterialButton()
        Me.scContainerRight = New System.Windows.Forms.SplitContainer()
        Me.scButtons = New System.Windows.Forms.SplitContainer()
        Me.btnApply = New MaterialSkin.Controls.MaterialButton()
        Me.btnDelete = New MaterialSkin.Controls.MaterialButton()
        Me.flpTags = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblAuthor = New MaterialSkin.Controls.MaterialLabel()
        Me.gbSettings = New System.Windows.Forms.GroupBox()
        Me.lblThemeName = New MaterialSkin.Controls.MaterialLabel()
        Me.btnOK = New MaterialSkin.Controls.MaterialButton()
        Me.btnCancel = New MaterialSkin.Controls.MaterialButton()
        Me.btnSettings = New MaterialSkin.Controls.MaterialButton()
        Me.btnThemeEditor = New MaterialSkin.Controls.MaterialButton()
        Me.pbThemeSnapshot = New ResMon.FillPicturebox()
        Me.flpUserDefine = New ResMon.DBFlowLayoutPanel()
        CType(Me.scContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scContainer.Panel1.SuspendLayout()
        Me.scContainer.Panel2.SuspendLayout()
        Me.scContainer.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pToolbox.SuspendLayout()
        CType(Me.scContainerRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scContainerRight.Panel1.SuspendLayout()
        Me.scContainerRight.Panel2.SuspendLayout()
        Me.scContainerRight.SuspendLayout()
        CType(Me.scButtons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scButtons.Panel1.SuspendLayout()
        Me.scButtons.Panel2.SuspendLayout()
        Me.scButtons.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'niTray
        '
        Me.niTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niTray.BalloonTipText = "BigBro Monitor will be keep running in the background. Click the tray icon to res" &
    "tore."
        Me.niTray.BalloonTipTitle = "BigBro Monitor"
        Me.niTray.Icon = CType(resources.GetObject("niTray.Icon"), System.Drawing.Icon)
        Me.niTray.Text = "BigBro Monitor"
        Me.niTray.Visible = True
        '
        'scContainer
        '
        Me.scContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scContainer.BackColor = System.Drawing.Color.Transparent
        Me.scContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.scContainer.Location = New System.Drawing.Point(6, 67)
        Me.scContainer.Name = "scContainer"
        '
        'scContainer.Panel1
        '
        Me.scContainer.Panel1.Controls.Add(Me.GroupBox1)
        Me.scContainer.Panel1.Controls.Add(Me.pToolbox)
        Me.scContainer.Panel1.Font = New System.Drawing.Font("Verdana", 9.0!)
        '
        'scContainer.Panel2
        '
        Me.scContainer.Panel2.Controls.Add(Me.scContainerRight)
        Me.scContainer.Size = New System.Drawing.Size(1247, 599)
        Me.scContainer.SplitterDistance = 850
        Me.scContainer.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.flpThemes)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(850, 549)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'flpThemes
        '
        Me.flpThemes.AutoScroll = True
        Me.flpThemes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpThemes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flpThemes.Location = New System.Drawing.Point(3, 18)
        Me.flpThemes.Name = "flpThemes"
        Me.flpThemes.Size = New System.Drawing.Size(844, 528)
        Me.flpThemes.TabIndex = 3
        '
        'pToolbox
        '
        Me.pToolbox.Controls.Add(Me.btnDownloadTheme)
        Me.pToolbox.Controls.Add(Me.txtSearch)
        Me.pToolbox.Controls.Add(Me.btnSearch)
        Me.pToolbox.Controls.Add(Me.btnResetFilter)
        Me.pToolbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.pToolbox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pToolbox.Location = New System.Drawing.Point(0, 0)
        Me.pToolbox.Name = "pToolbox"
        Me.pToolbox.Size = New System.Drawing.Size(850, 50)
        Me.pToolbox.TabIndex = 4
        '
        'btnDownloadTheme
        '
        Me.btnDownloadTheme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownloadTheme.AutoSize = False
        Me.btnDownloadTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDownloadTheme.BackColor = System.Drawing.SystemColors.Control
        Me.btnDownloadTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnDownloadTheme.Depth = 0
        Me.btnDownloadTheme.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDownloadTheme.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDownloadTheme.HighEmphasis = True
        Me.btnDownloadTheme.Icon = Nothing
        Me.btnDownloadTheme.Location = New System.Drawing.Point(668, 3)
        Me.btnDownloadTheme.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnDownloadTheme.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnDownloadTheme.Name = "btnDownloadTheme"
        Me.btnDownloadTheme.Size = New System.Drawing.Size(178, 36)
        Me.btnDownloadTheme.TabIndex = 3
        Me.btnDownloadTheme.Text = "Download theme"
        Me.btnDownloadTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnDownloadTheme.UseAccentColor = False
        Me.btnDownloadTheme.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.Depth = 0
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSearch.LeadingIcon = Nothing
        Me.txtSearch.Location = New System.Drawing.Point(3, 3)
        Me.txtSearch.MaxLength = 50
        Me.txtSearch.MouseState = MaterialSkin.MouseState.OUT
        Me.txtSearch.Multiline = False
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(259, 36)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.Text = ""
        Me.txtSearch.TrailingIcon = Nothing
        Me.txtSearch.UseTallSize = False
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = False
        Me.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnSearch.Depth = 0
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.HighEmphasis = True
        Me.btnSearch.Icon = Nothing
        Me.btnSearch.Location = New System.Drawing.Point(268, 3)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnSearch.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 36)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnSearch.UseAccentColor = False
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnResetFilter
        '
        Me.btnResetFilter.AutoSize = False
        Me.btnResetFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnResetFilter.BackColor = System.Drawing.SystemColors.Control
        Me.btnResetFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnResetFilter.Depth = 0
        Me.btnResetFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnResetFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnResetFilter.HighEmphasis = True
        Me.btnResetFilter.Icon = Nothing
        Me.btnResetFilter.Location = New System.Drawing.Point(396, 3)
        Me.btnResetFilter.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnResetFilter.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnResetFilter.Name = "btnResetFilter"
        Me.btnResetFilter.Size = New System.Drawing.Size(150, 36)
        Me.btnResetFilter.TabIndex = 2
        Me.btnResetFilter.Text = "Reset Filter"
        Me.btnResetFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnResetFilter.UseAccentColor = False
        Me.btnResetFilter.UseVisualStyleBackColor = False
        '
        'scContainerRight
        '
        Me.scContainerRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scContainerRight.Location = New System.Drawing.Point(0, 0)
        Me.scContainerRight.Name = "scContainerRight"
        Me.scContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scContainerRight.Panel1
        '
        Me.scContainerRight.Panel1.Controls.Add(Me.pbThemeSnapshot)
        '
        'scContainerRight.Panel2
        '
        Me.scContainerRight.Panel2.Controls.Add(Me.scButtons)
        Me.scContainerRight.Panel2.Controls.Add(Me.flpTags)
        Me.scContainerRight.Panel2.Controls.Add(Me.lblAuthor)
        Me.scContainerRight.Panel2.Controls.Add(Me.gbSettings)
        Me.scContainerRight.Panel2.Controls.Add(Me.lblThemeName)
        Me.scContainerRight.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.scContainerRight.Size = New System.Drawing.Size(393, 599)
        Me.scContainerRight.SplitterDistance = 256
        Me.scContainerRight.TabIndex = 0
        '
        'scButtons
        '
        Me.scButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scButtons.IsSplitterFixed = True
        Me.scButtons.Location = New System.Drawing.Point(8, 304)
        Me.scButtons.Name = "scButtons"
        '
        'scButtons.Panel1
        '
        Me.scButtons.Panel1.Controls.Add(Me.btnApply)
        '
        'scButtons.Panel2
        '
        Me.scButtons.Panel2.Controls.Add(Me.btnDelete)
        Me.scButtons.Size = New System.Drawing.Size(377, 27)
        Me.scButtons.SplitterDistance = 183
        Me.scButtons.TabIndex = 4
        '
        'btnApply
        '
        Me.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnApply.BackColor = System.Drawing.SystemColors.Control
        Me.btnApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnApply.Depth = 0
        Me.btnApply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnApply.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnApply.HighEmphasis = True
        Me.btnApply.Icon = Nothing
        Me.btnApply.Location = New System.Drawing.Point(0, 0)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnApply.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(183, 27)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnApply.UseAccentColor = False
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnDelete.Depth = 0
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.HighEmphasis = True
        Me.btnDelete.Icon = Nothing
        Me.btnDelete.Location = New System.Drawing.Point(0, 0)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnDelete.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(190, 27)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnDelete.UseAccentColor = False
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'flpTags
        '
        Me.flpTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTags.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flpTags.Location = New System.Drawing.Point(8, 64)
        Me.flpTags.Name = "flpTags"
        Me.flpTags.Size = New System.Drawing.Size(377, 41)
        Me.flpTags.TabIndex = 10
        '
        'lblAuthor
        '
        Me.lblAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAuthor.Depth = 0
        Me.lblAuthor.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblAuthor.ForeColor = System.Drawing.Color.White
        Me.lblAuthor.Location = New System.Drawing.Point(8, 35)
        Me.lblAuthor.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(377, 26)
        Me.lblAuthor.TabIndex = 9
        Me.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSettings
        '
        Me.gbSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSettings.BackColor = System.Drawing.Color.Transparent
        Me.gbSettings.Controls.Add(Me.flpUserDefine)
        Me.gbSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSettings.Location = New System.Drawing.Point(8, 111)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Padding = New System.Windows.Forms.Padding(5)
        Me.gbSettings.Size = New System.Drawing.Size(377, 187)
        Me.gbSettings.TabIndex = 0
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "User Define Options"
        '
        'lblThemeName
        '
        Me.lblThemeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblThemeName.Depth = 0
        Me.lblThemeName.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblThemeName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblThemeName.Location = New System.Drawing.Point(8, 5)
        Me.lblThemeName.MouseState = MaterialSkin.MouseState.HOVER
        Me.lblThemeName.Name = "lblThemeName"
        Me.lblThemeName.Size = New System.Drawing.Size(377, 30)
        Me.lblThemeName.TabIndex = 3
        Me.lblThemeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.AutoSize = False
        Me.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnOK.Depth = 0
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.HighEmphasis = True
        Me.btnOK.Icon = Nothing
        Me.btnOK.Location = New System.Drawing.Point(1005, 675)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnOK.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 36)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnOK.UseAccentColor = True
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = False
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnCancel.Depth = 0
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.HighEmphasis = True
        Me.btnCancel.Icon = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(1133, 675)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnCancel.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 36)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnCancel.UseAccentColor = False
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.AutoSize = False
        Me.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSettings.BackColor = System.Drawing.SystemColors.Control
        Me.btnSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnSettings.Depth = 0
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSettings.HighEmphasis = True
        Me.btnSettings.Icon = Nothing
        Me.btnSettings.Location = New System.Drawing.Point(164, 675)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnSettings.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(120, 36)
        Me.btnSettings.TabIndex = 2
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnSettings.UseAccentColor = False
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnThemeEditor
        '
        Me.btnThemeEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnThemeEditor.AutoSize = False
        Me.btnThemeEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnThemeEditor.BackColor = System.Drawing.SystemColors.Control
        Me.btnThemeEditor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.btnThemeEditor.Depth = 0
        Me.btnThemeEditor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnThemeEditor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnThemeEditor.HighEmphasis = True
        Me.btnThemeEditor.Icon = Nothing
        Me.btnThemeEditor.Location = New System.Drawing.Point(6, 675)
        Me.btnThemeEditor.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnThemeEditor.MouseState = MaterialSkin.MouseState.HOVER
        Me.btnThemeEditor.Name = "btnThemeEditor"
        Me.btnThemeEditor.Size = New System.Drawing.Size(150, 36)
        Me.btnThemeEditor.TabIndex = 1
        Me.btnThemeEditor.Text = "Theme Editor"
        Me.btnThemeEditor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.btnThemeEditor.UseAccentColor = False
        Me.btnThemeEditor.UseVisualStyleBackColor = False
        '
        'pbThemeSnapshot
        '
        Me.pbThemeSnapshot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbThemeSnapshot.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pbThemeSnapshot.Image = Global.ResMon.My.Resources.Resources.Blank
        Me.pbThemeSnapshot.ImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbThemeSnapshot.Location = New System.Drawing.Point(0, 0)
        Me.pbThemeSnapshot.Name = "pbThemeSnapshot"
        Me.pbThemeSnapshot.Size = New System.Drawing.Size(393, 256)
        Me.pbThemeSnapshot.TabIndex = 3
        Me.pbThemeSnapshot.Text = "FillPicturebox1"
        '
        'flpUserDefine
        '
        Me.flpUserDefine.AutoScroll = True
        Me.flpUserDefine.BackColor = System.Drawing.Color.Transparent
        Me.flpUserDefine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.flpUserDefine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpUserDefine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flpUserDefine.Location = New System.Drawing.Point(5, 21)
        Me.flpUserDefine.Margin = New System.Windows.Forms.Padding(0)
        Me.flpUserDefine.Name = "flpUserDefine"
        Me.flpUserDefine.Size = New System.Drawing.Size(367, 161)
        Me.flpUserDefine.TabIndex = 11
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1260, 720)
        Me.Controls.Add(Me.scContainer)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnThemeEditor)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1260, 720)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BigBro Monitor"
        Me.scContainer.Panel1.ResumeLayout(False)
        Me.scContainer.Panel2.ResumeLayout(False)
        CType(Me.scContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scContainer.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pToolbox.ResumeLayout(False)
        Me.scContainerRight.Panel1.ResumeLayout(False)
        Me.scContainerRight.Panel2.ResumeLayout(False)
        CType(Me.scContainerRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scContainerRight.ResumeLayout(False)
        Me.scButtons.Panel1.ResumeLayout(False)
        Me.scButtons.Panel1.PerformLayout()
        Me.scButtons.Panel2.ResumeLayout(False)
        Me.scButtons.Panel2.PerformLayout()
        CType(Me.scButtons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scButtons.ResumeLayout(False)
        Me.gbSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents niTray As NotifyIcon
    Friend WithEvents btnThemeEditor As MaterialButton
    Friend WithEvents btnSettings As MaterialButton
    Friend WithEvents btnCancel As MaterialButton
    Friend WithEvents btnOK As MaterialButton
    Friend WithEvents scContainer As SplitContainer
    Friend WithEvents flpThemes As FlowLayoutPanel
    Friend WithEvents pToolbox As Panel
    Friend WithEvents txtSearch As MaterialTextBox
    Friend WithEvents btnSearch As MaterialButton
    Friend WithEvents btnResetFilter As MaterialButton
    Friend WithEvents scContainerRight As SplitContainer
    Friend WithEvents pbThemeSnapshot As FillPicturebox
    Friend WithEvents scButtons As SplitContainer
    Friend WithEvents btnApply As MaterialButton
    Friend WithEvents btnDelete As MaterialButton
    Friend WithEvents flpTags As FlowLayoutPanel
    Friend WithEvents lblAuthor As MaterialLabel
    Friend WithEvents gbSettings As GroupBox
    Friend WithEvents flpUserDefine As DBFlowLayoutPanel
    Friend WithEvents lblThemeName As MaterialLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDownloadTheme As MaterialButton
End Class
