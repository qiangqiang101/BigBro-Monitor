<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

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
        Me.nsTheme = New ResMon.NSTheme()
        Me.cbMin = New ResMon.NSControlButton()
        Me.cbMax = New ResMon.NSControlButton()
        Me.cbClose = New ResMon.NSControlButton()
        Me.scContainer = New System.Windows.Forms.SplitContainer()
        Me.flpThemes = New System.Windows.Forms.FlowLayoutPanel()
        Me.pToolbox = New System.Windows.Forms.Panel()
        Me.txtSearch = New ResMon.NSTextBox()
        Me.btnSearch = New ResMon.NSButton()
        Me.btnResetFilter = New ResMon.NSButton()
        Me.scContainerRight = New System.Windows.Forms.SplitContainer()
        Me.pbThemeSnapshot = New ResMon.FillPicturebox()
        Me.scButtons = New System.Windows.Forms.SplitContainer()
        Me.btnApply = New ResMon.NSButton()
        Me.btnDelete = New ResMon.NSButton()
        Me.flpTags = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.gbSettings = New ResMon.NSGroupBox()
        Me.flpUserDefine = New ResMon.DBFlowLayoutPanel()
        Me.lblThemeName = New System.Windows.Forms.Label()
        Me.btnOK = New ResMon.NSButton()
        Me.btnCancel = New ResMon.NSButton()
        Me.btnSettings = New ResMon.NSButton()
        Me.btnThemeEditor = New ResMon.NSButton()
        Me.nsTheme.SuspendLayout()
        CType(Me.scContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scContainer.Panel1.SuspendLayout()
        Me.scContainer.Panel2.SuspendLayout()
        Me.scContainer.SuspendLayout()
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
        'nsTheme
        '
        Me.nsTheme.AccentOffset = 42
        Me.nsTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.nsTheme.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.nsTheme.Colors = New ResMon.Bloom(-1) {}
        Me.nsTheme.Controls.Add(Me.cbMin)
        Me.nsTheme.Controls.Add(Me.cbMax)
        Me.nsTheme.Controls.Add(Me.cbClose)
        Me.nsTheme.Controls.Add(Me.scContainer)
        Me.nsTheme.Controls.Add(Me.btnOK)
        Me.nsTheme.Controls.Add(Me.btnCancel)
        Me.nsTheme.Controls.Add(Me.btnSettings)
        Me.nsTheme.Controls.Add(Me.btnThemeEditor)
        Me.nsTheme.Customization = ""
        Me.nsTheme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nsTheme.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.nsTheme.Image = Nothing
        Me.nsTheme.Location = New System.Drawing.Point(0, 0)
        Me.nsTheme.Movable = True
        Me.nsTheme.Name = "nsTheme"
        Me.nsTheme.NoRounding = False
        Me.nsTheme.Sizable = True
        Me.nsTheme.Size = New System.Drawing.Size(1360, 768)
        Me.nsTheme.SmartBounds = True
        Me.nsTheme.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.nsTheme.TabIndex = 12
        Me.nsTheme.Text = "BigBro Monitor"
        Me.nsTheme.TransparencyKey = System.Drawing.Color.Empty
        Me.nsTheme.Transparent = True
        '
        'cbMin
        '
        Me.cbMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMin.ControlButton = ResMon.NSControlButton.Button.Minimize
        Me.cbMin.Location = New System.Drawing.Point(1298, 4)
        Me.cbMin.Margin = New System.Windows.Forms.Padding(0)
        Me.cbMin.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbMin.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbMin.Name = "cbMin"
        Me.cbMin.Size = New System.Drawing.Size(18, 20)
        Me.cbMin.TabIndex = 13
        Me.cbMin.Text = "NsControlButton1"
        '
        'cbMax
        '
        Me.cbMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMax.ControlButton = ResMon.NSControlButton.Button.MaximizeRestore
        Me.cbMax.Location = New System.Drawing.Point(1316, 4)
        Me.cbMax.Margin = New System.Windows.Forms.Padding(0)
        Me.cbMax.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbMax.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbMax.Name = "cbMax"
        Me.cbMax.Size = New System.Drawing.Size(18, 20)
        Me.cbMax.TabIndex = 12
        Me.cbMax.Text = "NsControlButton1"
        '
        'cbClose
        '
        Me.cbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbClose.ControlButton = ResMon.NSControlButton.Button.Close
        Me.cbClose.Location = New System.Drawing.Point(1335, 4)
        Me.cbClose.Margin = New System.Windows.Forms.Padding(0)
        Me.cbClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.cbClose.Name = "cbClose"
        Me.cbClose.Size = New System.Drawing.Size(18, 20)
        Me.cbClose.TabIndex = 11
        Me.cbClose.Text = "NsControlButton1"
        '
        'scContainer
        '
        Me.scContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scContainer.BackColor = System.Drawing.Color.Transparent
        Me.scContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.scContainer.Location = New System.Drawing.Point(12, 42)
        Me.scContainer.Name = "scContainer"
        '
        'scContainer.Panel1
        '
        Me.scContainer.Panel1.Controls.Add(Me.flpThemes)
        Me.scContainer.Panel1.Controls.Add(Me.pToolbox)
        Me.scContainer.Panel1.Font = New System.Drawing.Font("Verdana", 9.0!)
        '
        'scContainer.Panel2
        '
        Me.scContainer.Panel2.Controls.Add(Me.scContainerRight)
        Me.scContainer.Size = New System.Drawing.Size(1336, 681)
        Me.scContainer.SplitterDistance = 1051
        Me.scContainer.TabIndex = 10
        '
        'flpThemes
        '
        Me.flpThemes.AutoScroll = True
        Me.flpThemes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpThemes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpThemes.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.flpThemes.Location = New System.Drawing.Point(0, 34)
        Me.flpThemes.Name = "flpThemes"
        Me.flpThemes.Size = New System.Drawing.Size(1051, 647)
        Me.flpThemes.TabIndex = 3
        '
        'pToolbox
        '
        Me.pToolbox.Controls.Add(Me.txtSearch)
        Me.pToolbox.Controls.Add(Me.btnSearch)
        Me.pToolbox.Controls.Add(Me.btnResetFilter)
        Me.pToolbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.pToolbox.Location = New System.Drawing.Point(0, 0)
        Me.pToolbox.Name = "pToolbox"
        Me.pToolbox.Size = New System.Drawing.Size(1051, 34)
        Me.pToolbox.TabIndex = 4
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(3, 3)
        Me.txtSearch.MaxLength = 32767
        Me.txtSearch.Multiline = False
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ReadOnly = False
        Me.txtSearch.Size = New System.Drawing.Size(259, 27)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSearch.UseSystemPasswordChar = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(268, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 27)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        '
        'btnResetFilter
        '
        Me.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnResetFilter.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnResetFilter.ForeColor = System.Drawing.Color.White
        Me.btnResetFilter.Location = New System.Drawing.Point(374, 3)
        Me.btnResetFilter.Name = "btnResetFilter"
        Me.btnResetFilter.Size = New System.Drawing.Size(150, 27)
        Me.btnResetFilter.TabIndex = 2
        Me.btnResetFilter.Text = "Reset Filter"
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
        Me.scContainerRight.Size = New System.Drawing.Size(281, 681)
        Me.scContainerRight.SplitterDistance = 282
        Me.scContainerRight.TabIndex = 0
        '
        'pbThemeSnapshot
        '
        Me.pbThemeSnapshot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbThemeSnapshot.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.pbThemeSnapshot.Image = Global.ResMon.My.Resources.Resources.Blank
        Me.pbThemeSnapshot.ImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbThemeSnapshot.Location = New System.Drawing.Point(0, 0)
        Me.pbThemeSnapshot.Name = "pbThemeSnapshot"
        Me.pbThemeSnapshot.Size = New System.Drawing.Size(281, 282)
        Me.pbThemeSnapshot.TabIndex = 3
        Me.pbThemeSnapshot.Text = "FillPicturebox1"
        '
        'scButtons
        '
        Me.scButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scButtons.IsSplitterFixed = True
        Me.scButtons.Location = New System.Drawing.Point(8, 360)
        Me.scButtons.Name = "scButtons"
        '
        'scButtons.Panel1
        '
        Me.scButtons.Panel1.Controls.Add(Me.btnApply)
        '
        'scButtons.Panel2
        '
        Me.scButtons.Panel2.Controls.Add(Me.btnDelete)
        Me.scButtons.Size = New System.Drawing.Size(265, 27)
        Me.scButtons.SplitterDistance = 130
        Me.scButtons.TabIndex = 4
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnApply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnApply.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnApply.ForeColor = System.Drawing.Color.White
        Me.btnApply.Location = New System.Drawing.Point(0, 0)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(130, 27)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(0, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(131, 27)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        '
        'flpTags
        '
        Me.flpTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTags.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.flpTags.Location = New System.Drawing.Point(8, 64)
        Me.flpTags.Name = "flpTags"
        Me.flpTags.Size = New System.Drawing.Size(265, 41)
        Me.flpTags.TabIndex = 10
        '
        'lblAuthor
        '
        Me.lblAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAuthor.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblAuthor.ForeColor = System.Drawing.Color.White
        Me.lblAuthor.Location = New System.Drawing.Point(5, 35)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(265, 26)
        Me.lblAuthor.TabIndex = 9
        Me.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSettings
        '
        Me.gbSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.gbSettings.Controls.Add(Me.flpUserDefine)
        Me.gbSettings.DrawSeperator = True
        Me.gbSettings.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.gbSettings.ForeColor = System.Drawing.Color.White
        Me.gbSettings.Location = New System.Drawing.Point(8, 111)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Padding = New System.Windows.Forms.Padding(5)
        Me.gbSettings.Size = New System.Drawing.Size(265, 243)
        Me.gbSettings.SubTitle = ""
        Me.gbSettings.TabIndex = 0
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "User Define Options"
        Me.gbSettings.Title = "User Define Options"
        '
        'flpUserDefine
        '
        Me.flpUserDefine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpUserDefine.AutoScroll = True
        Me.flpUserDefine.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.flpUserDefine.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.flpUserDefine.Location = New System.Drawing.Point(5, 32)
        Me.flpUserDefine.Margin = New System.Windows.Forms.Padding(0)
        Me.flpUserDefine.Name = "flpUserDefine"
        Me.flpUserDefine.Size = New System.Drawing.Size(255, 206)
        Me.flpUserDefine.TabIndex = 11
        '
        'lblThemeName
        '
        Me.lblThemeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblThemeName.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblThemeName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblThemeName.Location = New System.Drawing.Point(8, 5)
        Me.lblThemeName.Name = "lblThemeName"
        Me.lblThemeName.Size = New System.Drawing.Size(265, 30)
        Me.lblThemeName.TabIndex = 3
        Me.lblThemeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(1142, 729)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 27)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(1248, 729)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 27)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSettings.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(171, 729)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(100, 27)
        Me.btnSettings.TabIndex = 2
        Me.btnSettings.Text = "Settings"
        '
        'btnThemeEditor
        '
        Me.btnThemeEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnThemeEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnThemeEditor.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.btnThemeEditor.ForeColor = System.Drawing.Color.White
        Me.btnThemeEditor.Location = New System.Drawing.Point(15, 729)
        Me.btnThemeEditor.Name = "btnThemeEditor"
        Me.btnThemeEditor.Size = New System.Drawing.Size(150, 27)
        Me.btnThemeEditor.TabIndex = 1
        Me.btnThemeEditor.Text = "Theme Editor"
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1360, 768)
        Me.Controls.Add(Me.nsTheme)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BigBro Monitor"
        Me.nsTheme.ResumeLayout(False)
        Me.scContainer.Panel1.ResumeLayout(False)
        Me.scContainer.Panel2.ResumeLayout(False)
        CType(Me.scContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scContainer.ResumeLayout(False)
        Me.pToolbox.ResumeLayout(False)
        Me.scContainerRight.Panel1.ResumeLayout(False)
        Me.scContainerRight.Panel2.ResumeLayout(False)
        CType(Me.scContainerRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scContainerRight.ResumeLayout(False)
        Me.scButtons.Panel1.ResumeLayout(False)
        Me.scButtons.Panel2.ResumeLayout(False)
        CType(Me.scButtons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scButtons.ResumeLayout(False)
        Me.gbSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents niTray As NotifyIcon
    Friend WithEvents btnThemeEditor As NSButton
    Friend WithEvents scContainer As SplitContainer
    Friend WithEvents btnResetFilter As NSButton
    Friend WithEvents btnSearch As NSButton
    Friend WithEvents txtSearch As NSTextBox
    Friend WithEvents flpThemes As FlowLayoutPanel
    Friend WithEvents scContainerRight As SplitContainer
    Friend WithEvents pbThemeSnapshot As FillPicturebox
    Friend WithEvents btnDelete As NSButton
    Friend WithEvents flpTags As FlowLayoutPanel
    Friend WithEvents lblAuthor As Label
    Friend WithEvents btnApply As NSButton
    Friend WithEvents gbSettings As NSGroupBox
    Friend WithEvents lblThemeName As Label
    Friend WithEvents btnCancel As NSButton
    Friend WithEvents btnSettings As NSButton
    Friend WithEvents btnOK As NSButton
    Friend WithEvents nsTheme As NSTheme
    Friend WithEvents cbMin As NSControlButton
    Friend WithEvents cbMax As NSControlButton
    Friend WithEvents cbClose As NSControlButton
    Friend WithEvents pToolbox As Panel
    Friend WithEvents flpUserDefine As DBFlowLayoutPanel
    Friend WithEvents scButtons As SplitContainer
End Class
