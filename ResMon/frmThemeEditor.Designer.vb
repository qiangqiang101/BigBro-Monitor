<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmThemeEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThemeEditor))
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiTextLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCustomText = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDetailSensor = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiImageBox = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiVStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRoundSB = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiYoutube = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiVisualizer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiThemeProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBuild = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBuildTheme = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pWorkArea = New System.Windows.Forms.Panel()
        Me.cmsRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvControls = New System.Windows.Forms.TreeView()
        Me.pgProperties = New System.Windows.Forms.PropertyGrid()
        Me.tsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbText = New System.Windows.Forms.ToolStripButton()
        Me.tsbCusText = New System.Windows.Forms.ToolStripButton()
        Me.tsbCompleteText = New System.Windows.Forms.ToolStripButton()
        Me.tsbImage = New System.Windows.Forms.ToolStripButton()
        Me.tsbStatusBar = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsbVStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbHStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbRoundSB = New System.Windows.Forms.ToolStripButton()
        Me.tsbGraphDiagram = New System.Windows.Forms.ToolStripButton()
        Me.tsbYoutube = New System.Windows.Forms.ToolStripButton()
        Me.tsbVisualizer = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.msMenu.SuspendLayout()
        Me.cmsRightClick.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tsToolStrip.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMenu
        '
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile, Me.tsmiProject, Me.tsmiBuild, Me.HelpToolStripMenuItem})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(1008, 24)
        Me.msMenu.TabIndex = 0
        Me.msMenu.Text = "MenuStrip1"
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNew, Me.tsmiOpen, Me.ToolStripSeparator1, Me.tsmiSave, Me.tsmiSaveAs, Me.ToolStripSeparator2, Me.tsmiExit})
        Me.tsmiFile.Name = "tsmiFile"
        Me.tsmiFile.Size = New System.Drawing.Size(37, 20)
        Me.tsmiFile.Text = "File"
        '
        'tsmiNew
        '
        Me.tsmiNew.Name = "tsmiNew"
        Me.tsmiNew.Size = New System.Drawing.Size(152, 22)
        Me.tsmiNew.Text = "New"
        '
        'tsmiOpen
        '
        Me.tsmiOpen.Name = "tsmiOpen"
        Me.tsmiOpen.Size = New System.Drawing.Size(152, 22)
        Me.tsmiOpen.Text = "Open..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'tsmiSave
        '
        Me.tsmiSave.Name = "tsmiSave"
        Me.tsmiSave.Size = New System.Drawing.Size(152, 22)
        Me.tsmiSave.Text = "Save"
        '
        'tsmiSaveAs
        '
        Me.tsmiSaveAs.Name = "tsmiSaveAs"
        Me.tsmiSaveAs.Size = New System.Drawing.Size(152, 22)
        Me.tsmiSaveAs.Text = "Save As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.Size = New System.Drawing.Size(152, 22)
        Me.tsmiExit.Text = "Exit"
        '
        'tsmiProject
        '
        Me.tsmiProject.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiTextLabel, Me.tsmiCustomText, Me.tsmiDetailSensor, Me.tsmiImageBox, Me.tsmiStatusBar, Me.tsmiRoundSB, Me.tsmiPlot, Me.tsmiYoutube, Me.tsmiVisualizer, Me.ToolStripSeparator3, Me.tsmiThemeProperties})
        Me.tsmiProject.Name = "tsmiProject"
        Me.tsmiProject.Size = New System.Drawing.Size(56, 20)
        Me.tsmiProject.Text = "Project"
        '
        'tsmiTextLabel
        '
        Me.tsmiTextLabel.Name = "tsmiTextLabel"
        Me.tsmiTextLabel.Size = New System.Drawing.Size(170, 22)
        Me.tsmiTextLabel.Text = "Text Label"
        '
        'tsmiCustomText
        '
        Me.tsmiCustomText.Name = "tsmiCustomText"
        Me.tsmiCustomText.Size = New System.Drawing.Size(170, 22)
        Me.tsmiCustomText.Text = "Custom Text"
        '
        'tsmiDetailSensor
        '
        Me.tsmiDetailSensor.Name = "tsmiDetailSensor"
        Me.tsmiDetailSensor.Size = New System.Drawing.Size(170, 22)
        Me.tsmiDetailSensor.Text = "Detail Sensor"
        '
        'tsmiImageBox
        '
        Me.tsmiImageBox.Name = "tsmiImageBox"
        Me.tsmiImageBox.Size = New System.Drawing.Size(170, 22)
        Me.tsmiImageBox.Text = "Image"
        '
        'tsmiStatusBar
        '
        Me.tsmiStatusBar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiVStatusBar})
        Me.tsmiStatusBar.Name = "tsmiStatusBar"
        Me.tsmiStatusBar.Size = New System.Drawing.Size(170, 22)
        Me.tsmiStatusBar.Text = "Status Bar"
        '
        'tsmiVStatusBar
        '
        Me.tsmiVStatusBar.Name = "tsmiVStatusBar"
        Me.tsmiVStatusBar.Size = New System.Drawing.Size(167, 22)
        Me.tsmiVStatusBar.Text = "Vertical Status Bar"
        '
        'tsmiRoundSB
        '
        Me.tsmiRoundSB.Name = "tsmiRoundSB"
        Me.tsmiRoundSB.Size = New System.Drawing.Size(170, 22)
        Me.tsmiRoundSB.Text = "Circular Status Bar"
        '
        'tsmiPlot
        '
        Me.tsmiPlot.Name = "tsmiPlot"
        Me.tsmiPlot.Size = New System.Drawing.Size(170, 22)
        Me.tsmiPlot.Text = "Plot Chart"
        '
        'tsmiYoutube
        '
        Me.tsmiYoutube.Name = "tsmiYoutube"
        Me.tsmiYoutube.Size = New System.Drawing.Size(170, 22)
        Me.tsmiYoutube.Text = "Youtube"
        '
        'tsmiVisualizer
        '
        Me.tsmiVisualizer.Name = "tsmiVisualizer"
        Me.tsmiVisualizer.Size = New System.Drawing.Size(170, 22)
        Me.tsmiVisualizer.Text = "Audio Visualizer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(167, 6)
        '
        'tsmiThemeProperties
        '
        Me.tsmiThemeProperties.Name = "tsmiThemeProperties"
        Me.tsmiThemeProperties.Size = New System.Drawing.Size(170, 22)
        Me.tsmiThemeProperties.Text = "Theme Properties"
        '
        'tsmiBuild
        '
        Me.tsmiBuild.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBuildTheme})
        Me.tsmiBuild.Name = "tsmiBuild"
        Me.tsmiBuild.Size = New System.Drawing.Size(46, 20)
        Me.tsmiBuild.Text = "Build"
        '
        'tsmiBuildTheme
        '
        Me.tsmiBuildTheme.Name = "tsmiBuildTheme"
        Me.tsmiBuildTheme.Size = New System.Drawing.Size(152, 22)
        Me.tsmiBuildTheme.Text = "Build Theme"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToUseToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HowToUseToolStripMenuItem
        '
        Me.HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem"
        Me.HowToUseToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.HowToUseToolStripMenuItem.Text = "How to use"
        '
        'pWorkArea
        '
        Me.pWorkArea.AutoScroll = True
        Me.pWorkArea.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pWorkArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pWorkArea.Location = New System.Drawing.Point(0, 0)
        Me.pWorkArea.Name = "pWorkArea"
        Me.pWorkArea.Size = New System.Drawing.Size(729, 666)
        Me.pWorkArea.TabIndex = 1
        '
        'cmsRightClick
        '
        Me.cmsRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCopy, Me.ToolStripSeparator4, Me.tsmiDelete})
        Me.cmsRightClick.Name = "ContextMenuStrip1"
        Me.cmsRightClick.Size = New System.Drawing.Size(108, 54)
        '
        'tsmiCopy
        '
        Me.tsmiCopy.Name = "tsmiCopy"
        Me.tsmiCopy.Size = New System.Drawing.Size(107, 22)
        Me.tsmiCopy.Text = "Clone"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(104, 6)
        '
        'tsmiDelete
        '
        Me.tsmiDelete.Name = "tsmiDelete"
        Me.tsmiDelete.Size = New System.Drawing.Size(107, 22)
        Me.tsmiDelete.Text = "Delete"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvControls)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pgProperties)
        Me.SplitContainer1.Size = New System.Drawing.Size(275, 666)
        Me.SplitContainer1.SplitterDistance = 331
        Me.SplitContainer1.TabIndex = 3
        '
        'tvControls
        '
        Me.tvControls.ContextMenuStrip = Me.cmsRightClick
        Me.tvControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvControls.FullRowSelect = True
        Me.tvControls.HideSelection = False
        Me.tvControls.Location = New System.Drawing.Point(0, 0)
        Me.tvControls.Name = "tvControls"
        Me.tvControls.Size = New System.Drawing.Size(275, 331)
        Me.tvControls.TabIndex = 3
        '
        'pgProperties
        '
        Me.pgProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgProperties.Location = New System.Drawing.Point(0, 0)
        Me.pgProperties.Name = "pgProperties"
        Me.pgProperties.Size = New System.Drawing.Size(275, 331)
        Me.pgProperties.TabIndex = 0
        '
        'tsToolStrip
        '
        Me.tsToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbText, Me.tsbCusText, Me.tsbCompleteText, Me.tsbImage, Me.tsbStatusBar, Me.tsbRoundSB, Me.tsbGraphDiagram, Me.tsbYoutube, Me.tsbVisualizer})
        Me.tsToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.tsToolStrip.Name = "tsToolStrip"
        Me.tsToolStrip.Size = New System.Drawing.Size(1008, 39)
        Me.tsToolStrip.TabIndex = 4
        '
        'tsbText
        '
        Me.tsbText.Image = Global.ResMon.My.Resources.Resources.text
        Me.tsbText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbText.Name = "tsbText"
        Me.tsbText.Size = New System.Drawing.Size(95, 36)
        Me.tsbText.Text = "Text Label"
        Me.tsbText.ToolTipText = "Text"
        '
        'tsbCusText
        '
        Me.tsbCusText.Image = Global.ResMon.My.Resources.Resources.style
        Me.tsbCusText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCusText.Name = "tsbCusText"
        Me.tsbCusText.Size = New System.Drawing.Size(109, 36)
        Me.tsbCusText.Text = "Custom Text"
        Me.tsbCusText.ToolTipText = "Text"
        '
        'tsbCompleteText
        '
        Me.tsbCompleteText.Image = Global.ResMon.My.Resources.Resources.text_list_bullets
        Me.tsbCompleteText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCompleteText.Name = "tsbCompleteText"
        Me.tsbCompleteText.Size = New System.Drawing.Size(111, 36)
        Me.tsbCompleteText.Text = "Detail Sensor"
        Me.tsbCompleteText.ToolTipText = "Text"
        '
        'tsbImage
        '
        Me.tsbImage.Image = Global.ResMon.My.Resources.Resources.images_flickr
        Me.tsbImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImage.Name = "tsbImage"
        Me.tsbImage.Size = New System.Drawing.Size(76, 36)
        Me.tsbImage.Text = "Image"
        Me.tsbImage.ToolTipText = "Text"
        '
        'tsbStatusBar
        '
        Me.tsbStatusBar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbVStatusBar, Me.tsbHStatusBar})
        Me.tsbStatusBar.Image = Global.ResMon.My.Resources.Resources.progressbar
        Me.tsbStatusBar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbStatusBar.Name = "tsbStatusBar"
        Me.tsbStatusBar.Size = New System.Drawing.Size(107, 36)
        Me.tsbStatusBar.Text = "Status Bar"
        Me.tsbStatusBar.ToolTipText = "Text"
        '
        'tsbVStatusBar
        '
        Me.tsbVStatusBar.Name = "tsbVStatusBar"
        Me.tsbVStatusBar.Size = New System.Drawing.Size(184, 22)
        Me.tsbVStatusBar.Text = "Vertical Status Bar"
        '
        'tsbHStatusBar
        '
        Me.tsbHStatusBar.Name = "tsbHStatusBar"
        Me.tsbHStatusBar.Size = New System.Drawing.Size(184, 22)
        Me.tsbHStatusBar.Text = "Horizontal Status Bar"
        '
        'tsbRoundSB
        '
        Me.tsbRoundSB.Image = Global.ResMon.My.Resources.Resources.dashboard
        Me.tsbRoundSB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRoundSB.Name = "tsbRoundSB"
        Me.tsbRoundSB.Size = New System.Drawing.Size(139, 36)
        Me.tsbRoundSB.Text = "Circular Status Bar"
        Me.tsbRoundSB.ToolTipText = "Text"
        '
        'tsbGraphDiagram
        '
        Me.tsbGraphDiagram.Image = Global.ResMon.My.Resources.Resources.diagnostic_chart
        Me.tsbGraphDiagram.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGraphDiagram.Name = "tsbGraphDiagram"
        Me.tsbGraphDiagram.Size = New System.Drawing.Size(96, 36)
        Me.tsbGraphDiagram.Text = "Plot Chart"
        Me.tsbGraphDiagram.ToolTipText = "Text"
        '
        'tsbYoutube
        '
        Me.tsbYoutube.Image = Global.ResMon.My.Resources.Resources.youtube
        Me.tsbYoutube.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbYoutube.Name = "tsbYoutube"
        Me.tsbYoutube.Size = New System.Drawing.Size(87, 36)
        Me.tsbYoutube.Text = "Youtube"
        Me.tsbYoutube.ToolTipText = "Text"
        '
        'tsbVisualizer
        '
        Me.tsbVisualizer.Image = Global.ResMon.My.Resources.Resources.chart_column
        Me.tsbVisualizer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVisualizer.Name = "tsbVisualizer"
        Me.tsbVisualizer.Size = New System.Drawing.Size(127, 36)
        Me.tsbVisualizer.Text = "Audio Visualizer"
        Me.tsbVisualizer.ToolTipText = "Text"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 63)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.pWorkArea)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1008, 666)
        Me.SplitContainer2.SplitterDistance = 729
        Me.SplitContainer2.TabIndex = 5
        '
        'frmThemeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.tsToolStrip)
        Me.Controls.Add(Me.msMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msMenu
        Me.Name = "frmThemeEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Untitled - Theme Editor"
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        Me.cmsRightClick.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tsToolStrip.ResumeLayout(False)
        Me.tsToolStrip.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMenu As MenuStrip
    Friend WithEvents tsmiFile As ToolStripMenuItem
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiOpen As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiSave As ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiExit As ToolStripMenuItem
    Friend WithEvents pWorkArea As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pgProperties As PropertyGrid
    Friend WithEvents tsToolStrip As ToolStrip
    Friend WithEvents tsbImage As ToolStripButton
    Friend WithEvents cmsRightClick As ContextMenuStrip
    Friend WithEvents tsmiDelete As ToolStripMenuItem
    Friend WithEvents tvControls As TreeView
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HowToUseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents tsbGraphDiagram As ToolStripButton
    Friend WithEvents tsbText As ToolStripButton
    Friend WithEvents tsbCompleteText As ToolStripButton
    Friend WithEvents tsbYoutube As ToolStripButton
    Friend WithEvents tsmiProject As ToolStripMenuItem
    Friend WithEvents tsmiTextLabel As ToolStripMenuItem
    Friend WithEvents tsmiDetailSensor As ToolStripMenuItem
    Friend WithEvents tsmiImageBox As ToolStripMenuItem
    Friend WithEvents tsmiStatusBar As ToolStripMenuItem
    Friend WithEvents tsmiRoundSB As ToolStripMenuItem
    Friend WithEvents tsmiPlot As ToolStripMenuItem
    Friend WithEvents tsmiYoutube As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsmiThemeProperties As ToolStripMenuItem
    Friend WithEvents tsmiBuild As ToolStripMenuItem
    Friend WithEvents tsmiBuildTheme As ToolStripMenuItem
    Friend WithEvents tsmiCopy As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbRoundSB As ToolStripButton
    Friend WithEvents tsbVisualizer As ToolStripButton
    Friend WithEvents tsmiVisualizer As ToolStripMenuItem
    Friend WithEvents tsbCusText As ToolStripButton
    Friend WithEvents tsmiCustomText As ToolStripMenuItem
    Friend WithEvents tsbStatusBar As ToolStripSplitButton
    Friend WithEvents tsbVStatusBar As ToolStripMenuItem
    Friend WithEvents tsmiVStatusBar As ToolStripMenuItem
    Friend WithEvents tsbHStatusBar As ToolStripMenuItem
End Class
