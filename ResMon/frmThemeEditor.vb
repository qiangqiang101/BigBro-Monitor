Imports System.ComponentModel
Imports System.Drawing.Imaging

Public Class frmThemeEditor

    Dim currentTheme As ThemeData
    Dim WithEvents monForm As frmMonitor
    Dim themeConfig As ThemeConfig
    Dim root As TreeNode
    Dim saveFile As String = Nothing
    Dim themeFile As String = Nothing

    Private Sub ThemeEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentTheme = New ThemeData().Instance

        themeConfig = New ThemeConfig
        monForm = New frmMonitor() With {.TopLevel = False, .Editing = True}
        pWorkArea.Controls.Add(monForm)
        monForm.Location = CalculateCenter(pWorkArea.Size, monForm.Size)
        monForm.Show()

        root = New TreeNode(themeConfig.Name) With {.Tag = themeConfig, .Name = "ThemeConfig"}
        tvControls.Nodes.Add(root)
    End Sub

    Private Sub WordArea_Resize(sender As Object, e As EventArgs) Handles monForm.Resize, pWorkArea.Resize
        Try
            monForm.Location = CalculateCenter(pWorkArea.Size, monForm.Size)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmiNew_Click(sender As Object, e As EventArgs) Handles tsmiNew.Click
        For Each control As Control In monForm.Controls
            If control.GetType = GetType(Youtube) Then
                Dim yt As Youtube = CType(control, Youtube)
                yt.StopPlayer()
            End If
        Next

        currentTheme = New ThemeData().Instance
        pWorkArea.Controls.Clear()
        tvControls.Nodes.Clear()
        pgProperties.SelectedObject = Nothing

        themeConfig = New ThemeConfig
        monForm = New frmMonitor() With {.TopLevel = False, .Editing = True}
        pWorkArea.Controls.Add(monForm)
        monForm.Location = CalculateCenter(pWorkArea.Size, monForm.Size)
        monForm.Show()

        root = New TreeNode(themeConfig.Name) With {.Tag = themeConfig, .Name = "ThemeConfig"}
        tvControls.Nodes.Add(root)
    End Sub

    Private Sub tsmiOpen_Click(sender As Object, e As EventArgs) Handles tsmiOpen.Click
        Dim ofd As New OpenFileDialog With {.Filter = "Xml File|*.xml", .Multiselect = False, .Title = "Select Theme file..."}
        Dim result As DialogResult = ofd.ShowDialog()
        If result = DialogResult.OK Then
            LoadThemeFile(ofd.FileName)
        End If
    End Sub

    Private Sub LoadThemeFile(filename As String)
        For Each control As Control In monForm.Controls
            If control.GetType = GetType(Youtube) Then
                Dim yt As Youtube = CType(control, Youtube)
                yt.StopPlayer()
            End If
        Next

        pWorkArea.Controls.Clear()
        tvControls.Nodes.Clear()
        pgProperties.SelectedObject = Nothing

        monForm = New frmMonitor() With {.TopLevel = False, .Editing = True}
        pWorkArea.Controls.Add(monForm)
        monForm.Location = CalculateCenter(pWorkArea.Size, monForm.Size)
        monForm.Show()

        Select Case IO.Path.GetExtension(filename)
            Case ".theme"
                currentTheme = New ThemeData(filename).ThemeInstance
            Case ".xml"
                currentTheme = New ThemeData(filename).Instance
        End Select

        themeConfig = New ThemeConfig() With {.Author = currentTheme.Author, .BackgroundColor = currentTheme.BackgroundColor.ToColor, .BackgroundImage = currentTheme.BackgroundImage.Base64ToImage, .Name = currentTheme.Name,
            .Size = currentTheme.Size, .TextColor = currentTheme.TextColor.ToColor, .Version = currentTheme.Version, .UpdateInterval = currentTheme.UpdateInterval, .Tags = currentTheme.Tags,
            .CustomPreview = currentTheme.CustomPreview.Base64ToImage, .Opacity = currentTheme.Opacity}
        saveFile = filename
        themeFile = filename.Replace(".xml", ".theme")

        root = New TreeNode(themeConfig.Name) With {.Tag = themeConfig, .Name = "ThemeConfig"}
        tvControls.Nodes.Add(root)

        With monForm
            .BackColor = themeConfig.BackgroundColor
            .BackgroundImage = themeConfig.BackgroundImage
            .Size = themeConfig.Size
            .ForeColor = themeConfig.TextColor
            .Updater.Interval = themeConfig.UpdateInterval
            .Opacity = themeConfig.Opacity
        End With

        For Each tl As MyTextLabel In currentTheme.TextLabels
            Dim txtLbl As New TextLabel(True)
            With txtLbl
                .myParentForm = monForm
                .BackColor = tl.BackColor.ToColor
                .Font = tl.Font.ToFont
                .ForeColor = tl.ForeColor.ToColor
                .RightToLeft = tl.RightToLeft
                .BeforeText = tl.BeforeText
                .Text = tl.Text
                .Enabled = tl.Enabled
                .Visible = tl.Visible
                .Tag = "ThemeControl"
                .Name = tl.Name
                .Anchor = tl.Anchor
                .Dock = tl.Dock
                .Location = tl.Location
                .Margin = tl.Margin
                .Padding = tl.Padding
                .Size = tl.Size
                .BorderStyle = tl.BorderStyle
                .FlatStyle = tl.FlatStyle
                .Image = tl.Image.Base64ToImage
                .ImageAlign = tl.ImageAlign
                .TextAlign = tl.TextAlign
                .UseMnemonic = tl.UseMnemonic
                .AutoEllipsis = tl.AutoEllipsis
                .UseCompatibleTextRendering = tl.UseCompatibleTextRendering
                .AutoSize = tl.AutoSize
                .Sensor = tl.Sensor
                .SensorParam = tl.SensorParam
                .AllowUserEdit = tl.AllowUserEdit
                '.ParentName = tl.ParentName
            End With
            monForm.Controls.Add(txtLbl)

            Dim node As New TreeNode($"{txtLbl.Name} ({txtLbl.Sensor.ToString})") With {.Tag = txtLbl, .Name = txtLbl.Name}
            root.Nodes.Add(node)

            AddHandler txtLbl.MouseClick, AddressOf Control_MouseClick
        Next

        For Each ic As MyImageControl In currentTheme.ImageBoxes
            Dim picBox As New ImageControl(True)
            With picBox
                .myParentForm = monForm
                .BackColor = ic.BackColor.ToColor
                .BackgroundImage = ic.BackgroundImage.Base64ToImage
                .BackgroundImageLayout = ic.BackgroundImageLayout
                .Font = ic.Font.ToFont
                .ForeColor = ic.ForeColor.ToColor
                .RightToLeft = ic.RightToLeft
                .Text = ic.Text
                .Enabled = ic.Enabled
                .Visible = ic.Visible
                .Tag = "ThemeControl"
                .Name = ic.Name
                .Anchor = ic.Anchor
                .Dock = ic.Dock
                .Location = ic.Location
                .Margin = ic.Margin
                .Padding = ic.Padding
                .Size = ic.Size
                .BorderStyle = ic.BorderStyle
                .Image = ic.Image.Base64ToImage
                .SizeMode = ic.SizeMode
                .Sensor = ic.Sensor
                .SensorParam = ic.SensorParam
                .EnableDynamicImages = ic.EnableDynamicImages
                .DynamicImages = ic.DynamicImages.ToDynamicImages
                .AllowUserEdit = ic.AllowUserEdit
                '.ParentName = ic.ParentName
            End With

            monForm.Controls.Add(picBox)

            Dim node As New TreeNode($"{picBox.Name} ({picBox.Sensor.ToString})") With {.Tag = picBox, .Name = picBox.Name}
            root.Nodes.Add(node)

            AddHandler picBox.MouseClick, AddressOf Control_MouseClick
        Next

        For Each sb As MyStatusBar In currentTheme.StatusBars
            Dim sbProgress As New StatusBar(True)
            With sbProgress
                .myParentForm = monForm
                .BackColor = sb.BackColor.ToColor
                .Font = sb.Font.ToFont
                .ForeColor = sb.ForeColor.ToColor
                .RightToLeft = sb.RightToLeft
                .Text = sb.Text
                .Enabled = sb.Enabled
                .Visible = sb.Visible
                .Tag = "ThemeControl"
                .Name = sb.Name
                .Anchor = sb.Anchor
                .Dock = sb.Dock
                .Location = sb.Location
                .Margin = sb.Margin
                .Padding = sb.Padding
                .Size = sb.Size
                .BackgroundColor = sb.BackgroundColor.ToColor
                .ForegroundColor = sb.ForegroundColor.ToColor
                .Value = sb.Value
                .Minimum = sb.Minimum
                .Maximum = sb.Maximum
                .Sensor = sb.Sensor
                .SensorParam = sb.SensorParam
                .Texture = sb.Texture.Base64ToImage
                .TextureSize = sb.TextureSize
                .UseTexture = sb.UseTexture
                '.ParentName = sb.ParentName
            End With

            monForm.Controls.Add(sbProgress)

            Dim node As New TreeNode($"{sbProgress.Name} ({sbProgress.Sensor.ToString})") With {.Tag = sbProgress, .Name = sbProgress.Name}
            root.Nodes.Add(node)

            AddHandler sbProgress.MouseClick, AddressOf Control_MouseClick
        Next

        For Each csb As MyCircularStatusBar In currentTheme.CircularSBs
            Dim csbProgress As New CircularStatusBar(True)
            With csbProgress
                .myParentForm = monForm
                .BackColor = csb.BackColor.ToColor
                .Font = csb.Font.ToFont
                .ForeColor = csb.ForeColor.ToColor
                .RightToLeft = csb.RightToLeft
                .Text = csb.Text
                .Enabled = csb.Enabled
                .Visible = csb.Visible
                .Tag = "ThemeControl"
                .Name = csb.Name
                .Anchor = csb.Anchor
                .Dock = csb.Dock
                .Location = csb.Location
                .Margin = csb.Margin
                .Padding = csb.Padding
                .Size = csb.Size
                .Style = csb.Style
                .SubText = csb.SubText
                .ProgressColor2 = csb.ProgressColor2.ToColor
                .BarWidth = csb.BarWidth
                .GradientMode = csb.GradientMode
                .ForegroundColor = csb.ForegroundColor.ToColor
                .ProgressColor = csb.ProgressColor.ToColor
                .Thickness = csb.Thickness
                .StartAngle = csb.StartAngle
                .ProgressShape = csb.ProgressShape
                .Value = csb.Value
                .Unit = csb.Unit
                .Minimum = csb.Minimum
                .Maximum = csb.Maximum
                .TextMode = csb.TextMode
                .Sensor = csb.Sensor
                .SensorParam = csb.SensorParam
                '.ParentName = csb.ParentName
            End With
            monForm.Controls.Add(csbProgress)

            Dim node As New TreeNode($"{csbProgress.Name} ({csbProgress.Sensor.ToString})") With {.Tag = csbProgress, .Name = csbProgress.Name}
            root.Nodes.Add(node)

            AddHandler csbProgress.MouseClick, AddressOf Control_MouseClick
        Next

        For Each pc As MyPlotChart In currentTheme.PlotCharts
            Dim pcPlot As New PlotChart(True)
            With pcPlot
                .myParentForm = monForm
                .BackColor = pc.BackColor.ToColor
                .Font = pc.Font.ToFont
                .ForeColor = pc.ForeColor.ToColor
                .RightToLeft = pc.RightToLeft
                .Text = pc.Text
                .Enabled = pc.Enabled
                .Visible = pc.Visible
                .Tag = "ThemeControl"
                .Name = pc.Name
                .Anchor = pc.Anchor
                .Dock = pc.Dock
                .Location = pc.Location
                .Margin = pc.Margin
                .Padding = pc.Padding
                .Size = pc.Size
                .Sensor = pc.Sensor
                .SensorParam = pc.SensorParam
                .PlotChartStyle = pc.PlotChartStyle.ToPlotChartStyle
                .BorderStyle = pc.BorderStyle
                .ScaleMode = pc.ScaleMode
                '.ParentName = pc.ParentName
            End With
            monForm.Controls.Add(pcPlot)

            Dim node As New TreeNode($"{pcPlot.Name} ({pcPlot.Sensor.ToString})") With {.Tag = pcPlot, .Name = pcPlot.Name}
            root.Nodes.Add(node)

            AddHandler pcPlot.MouseClick, AddressOf Control_MouseClick
        Next

        For Each ds As MyDetailSensor In currentTheme.DetailSensors
            Dim dtSensor As New DetailSensor(True)
            With dtSensor
                .myParentForm = monForm
                .BackColor = ds.BackColor.ToColor
                .Font = ds.Font.ToFont
                .ForeColor = ds.ForeColor.ToColor
                .RightToLeft = ds.RightToLeft
                .Text = ds.Text
                .Enabled = ds.Enabled
                .Visible = ds.Visible
                .Tag = "ThemeControl"
                .Name = ds.Name
                .Anchor = ds.Anchor
                .Dock = ds.Dock
                .Location = ds.Location
                .Margin = ds.Margin
                .Padding = ds.Padding
                .Size = ds.Size
                .DetailedSensor = ds.DetailedSensor
                .DrawBorder = ds.DrawBorder
                '.ParentName = ds.ParentName
            End With
            monForm.Controls.Add(dtSensor)

            Dim node As New TreeNode($"{dtSensor.Name} ({dtSensor.DetailedSensor.ToString})") With {.Tag = dtSensor, .Name = dtSensor.Name}
            root.Nodes.Add(node)

            AddHandler dtSensor.MouseClick, AddressOf Control_MouseClick
        Next

        For Each yt As MyYoutube In currentTheme.YoutubeVideos
            Dim utube As New Youtube(True)
            With utube
                .myParentForm = monForm
                .BackColor = yt.BackColor.ToColor
                .ForeColor = yt.ForeColor.ToColor
                .Enabled = yt.Enabled
                .Visible = yt.Visible
                .Tag = "ThemeControl"
                .YoutubeID = yt.YoutubeID
                .Name = yt.Name
                .Anchor = yt.Anchor
                .Dock = yt.Dock
                .Location = yt.Location
                .Margin = yt.Margin
                .Padding = yt.Padding
                .Size = yt.Size
                .Sensor = yt.Sensor
                .Play = yt.Play
                '.ParentName = yt.ParentName
            End With
            monForm.Controls.Add(utube)

            Dim node As New TreeNode($"{utube.Name} ({utube.Sensor.ToString})") With {.Tag = utube, .Name = utube.Name}
            root.Nodes.Add(node)

            AddHandler utube.MouseClick, AddressOf Control_MouseClick
        Next

        For Each ww As MyWeatherWidget In currentTheme.WeatherWidgets
            Dim wwidget As New WeatherWidget(True)
            With wwidget
                .myParentForm = monForm
                .BackColor = ww.BackColor.ToColor
                .Font = ww.Font.ToFont
                .ForeColor = ww.ForeColor.ToColor
                .RightToLeft = ww.RightToLeft
                .Text = ww.Text
                .Enabled = ww.Enabled
                .Visible = ww.Visible
                .Tag = "ThemeControl"
                .Name = ww.Name
                .Anchor = ww.Anchor
                .Dock = ww.Dock
                .Location = ww.Location
                .Margin = ww.Margin
                .Padding = ww.Padding
                .Size = ww.Size
                .Sensor = ww.Sensor
                .WeatherStyle = ww.WeatherStyle
                .IconStyle = ww.IconStyle
                '.ParentName = ww.ParentName
            End With
            monForm.Controls.Add(wwidget)

            Dim node As New TreeNode($"{wwidget.Name} ({wwidget.Sensor.ToString})") With {.Tag = wwidget, .Name = wwidget.Name}
            root.Nodes.Add(node)

            AddHandler wwidget.MouseClick, AddressOf Control_MouseClick
        Next

        Text = $"{themeConfig.Name} - Theme Editor"

        currentTheme.TextLabels.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, TextLabel).ParentName = x.ParentName)
        currentTheme.ImageBoxes.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, ImageControl).ParentName = x.ParentName)
        currentTheme.StatusBars.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, StatusBar).ParentName = x.ParentName)
        currentTheme.CircularSBs.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, CircularStatusBar).ParentName = x.ParentName)
        currentTheme.PlotCharts.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, PlotChart).ParentName = x.ParentName)
        currentTheme.DetailSensors.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, DetailSensor).ParentName = x.ParentName)
        currentTheme.YoutubeVideos.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, Youtube).ParentName = x.ParentName)
        currentTheme.WeatherWidgets.ForEach(Sub(x) CType(monForm.Controls.Find(x.Name, False).FirstOrDefault, WeatherWidget).ParentName = x.ParentName)
    End Sub

    Private Sub tsmiSaveAs_Click(sender As Object, e As EventArgs) Handles tsmiSaveAs.Click
        Dim sfd As New SaveFileDialog With {.Filter = "Xml File|*.xml", .Title = "Save As...", .FileName = themeConfig.Name}
        If sfd.ShowDialog = DialogResult.OK Then
            Dim theme As New ThemeData(sfd.FileName)
            With theme
                .Author = themeConfig.Author
                .BackgroundColor = New MyColor(themeConfig.BackgroundColor)
                .BackgroundImage = themeConfig.BackgroundImage.ImageToBase64
                .TextColor = New MyColor(themeConfig.TextColor)
                .Name = themeConfig.Name
                .Tags = themeConfig.Tags
                .Size = themeConfig.Size
                .Version = themeConfig.Version
                .UpdateInterval = themeConfig.UpdateInterval
                .Opacity = themeConfig.Opacity
                '.TransparencyKey = New MyColor(themeConfig.TransparencyKey)
                Dim tlList As New List(Of MyTextLabel)
                Dim icList As New List(Of MyImageControl)
                Dim sbList As New List(Of MyStatusBar)
                Dim csbList As New List(Of MyCircularStatusBar)
                Dim pcList As New List(Of MyPlotChart)
                Dim dsList As New List(Of MyDetailSensor)
                Dim ytList As New List(Of MyYoutube)
                Dim wwList As New List(Of MyWeatherWidget)
                For Each control As Control In monForm.Controls
                    Select Case control.GetType
                        Case GetType(TextLabel)
                            tlList.Add(New MyTextLabel(control))
                        Case GetType(ImageControl)
                            icList.Add(New MyImageControl(control))
                        Case GetType(StatusBar)
                            sbList.Add(New MyStatusBar(control))
                        Case GetType(CircularStatusBar)
                            csbList.Add(New MyCircularStatusBar(control))
                        Case GetType(PlotChart)
                            pcList.Add(New MyPlotChart(control))
                        Case GetType(DetailSensor)
                            dsList.Add(New MyDetailSensor(control))
                        Case GetType(Youtube)
                            ytList.Add(New MyYoutube(control))
                        Case GetType(WeatherWidget)
                            wwList.Add(New MyWeatherWidget(control))
                    End Select
                Next
                .TextLabels = tlList
                .ImageBoxes = icList
                .StatusBars = sbList
                .CircularSBs = csbList
                .PlotCharts = pcList
                .DetailSensors = dsList
                .YoutubeVideos = ytList
                .WeatherWidgets = wwList
                .Snapshot = monForm.TakeScreenShot.ImageToBase64(ImageFormat.Png)
                .CustomPreview = themeConfig.CustomPreview.ImageToBase64
                .Save()
                Text = $"{themeConfig.Name} - Theme Editor"
            End With
            saveFile = sfd.FileName
            themeFile = sfd.FileName.Replace(".xml", ".theme")
        End If
    End Sub

    Private Sub tsmiSave_Click(sender As Object, e As EventArgs) Handles tsmiSave.Click
        If Not saveFile = Nothing Then
            Dim theme As New ThemeData(saveFile)
            With theme
                .Author = themeConfig.Author
                .BackgroundColor = New MyColor(themeConfig.BackgroundColor)
                .BackgroundImage = themeConfig.BackgroundImage.ImageToBase64
                .TextColor = New MyColor(themeConfig.TextColor)
                .Name = themeConfig.Name
                .Tags = themeConfig.Tags
                .Size = themeConfig.Size
                .Version = themeConfig.Version
                .UpdateInterval = themeConfig.UpdateInterval
                .Opacity = themeConfig.Opacity
                '.TransparencyKey = New MyColor(themeConfig.TransparencyKey)
                Dim tlList As New List(Of MyTextLabel)
                Dim icList As New List(Of MyImageControl)
                Dim sbList As New List(Of MyStatusBar)
                Dim csbList As New List(Of MyCircularStatusBar)
                Dim pcList As New List(Of MyPlotChart)
                Dim dsList As New List(Of MyDetailSensor)
                Dim ytList As New List(Of MyYoutube)
                Dim wwList As New List(Of MyWeatherWidget)
                For Each control As Control In monForm.Controls
                    Select Case control.GetType
                        Case GetType(TextLabel)
                            tlList.Add(New MyTextLabel(control))
                        Case GetType(ImageControl)
                            icList.Add(New MyImageControl(control))
                        Case GetType(StatusBar)
                            sbList.Add(New MyStatusBar(control))
                        Case GetType(CircularStatusBar)
                            csbList.Add(New MyCircularStatusBar(control))
                        Case GetType(PlotChart)
                            pcList.Add(New MyPlotChart(control))
                        Case GetType(DetailSensor)
                            dsList.Add(New MyDetailSensor(control))
                        Case GetType(Youtube)
                            ytList.Add(New MyYoutube(control))
                        Case GetType(WeatherWidget)
                            wwList.Add(New MyWeatherWidget(control))
                    End Select
                Next
                .TextLabels = tlList
                .ImageBoxes = icList
                .StatusBars = sbList
                .CircularSBs = csbList
                .PlotCharts = pcList
                .DetailSensors = dsList
                .YoutubeVideos = ytList
                .WeatherWidgets = wwList
                .Snapshot = monForm.TakeScreenShot.ImageToBase64(ImageFormat.Png)
                .CustomPreview = themeConfig.CustomPreview.ImageToBase64
                .Save()
                themeFile = saveFile.Replace(".xml", ".theme")
                Text = $"{themeConfig.Name} - Theme Editor"
            End With
        Else
            tsmiSaveAs.PerformClick()
        End If
    End Sub

    Private Sub tsmiExit_Click(sender As Object, e As EventArgs) Handles tsmiExit.Click
        Close()
    End Sub

    Private Sub pgProperties_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles pgProperties.PropertyValueChanged
        Try
            If pgProperties.SelectedObject Is themeConfig Then
                Dim tc As ThemeConfig = pgProperties.SelectedObject
                Dim node As TreeNode = pgProperties.Tag
                node.Text = tc.Name

                monForm.BackColor = tc.BackgroundColor
                monForm.Size = tc.Size
                monForm.BackgroundImage = tc.BackgroundImage
                monForm.UpdateInterval = tc.UpdateInterval
                monForm.Opacity = tc.Opacity
            Else
                If pgProperties.SelectedObject.Tag = "ThemeControl" Then
                    Select Case e.ChangedItem.Label
                        Case "Name"
                            If Not ControlNameExist(pgProperties.SelectedObject.Name) Then
                                Dim node As TreeNode = pgProperties.Tag
                                Try
                                    node.Text = $"{pgProperties.SelectedObject.Name} ({pgProperties.SelectedObject.Sensor.ToString})"
                                Catch ex As Exception
                                    node.Text = $"{pgProperties.SelectedObject.Name} ({pgProperties.SelectedObject.DetailedSensor.ToString})"
                                End Try
                                node.Name = pgProperties.SelectedObject.Name
                            Else
                                MsgBox($"Control Name {pgProperties.SelectedObject.Name} already exist in Form!", MsgBoxStyle.Critical, "Error")
                            End If
                        Case "Sensor"
                            Dim node As TreeNode = pgProperties.Tag
                            node.Text = $"{pgProperties.SelectedObject.Name} ({pgProperties.SelectedObject.Sensor.ToString})"
                            node.Name = pgProperties.SelectedObject.Name
                        Case "DetailedSensor"
                            Dim node As TreeNode = pgProperties.Tag
                            node.Text = $"{pgProperties.SelectedObject.Name} ({pgProperties.SelectedObject.DetailedSensor.ToString})"
                            node.Name = pgProperties.SelectedObject.Name
                    End Select
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub

    Private Sub Control_MouseClick(sender As Object, e As MouseEventArgs)
        Dim control As Control = CType(sender, Control)
        control.BringToFront()

        For i As Integer = 0 To root.Nodes.Count - 1
            If root.Nodes(i).Name = sender.Name Then tvControls.SelectedNode = root.Nodes(i)
        Next
    End Sub

    Private Sub tvControls_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvControls.AfterSelect
        pgProperties.SelectedObject = tvControls.SelectedNode.Tag
        pgProperties.Tag = tvControls.SelectedNode

        If Not tvControls.SelectedNode.Tag Is themeConfig Then
            Dim ctrlToFocus As Control = tvControls.SelectedNode.Tag
            ctrlToFocus.BringToFront()
        End If
    End Sub

    Private Sub tsbText_Click(sender As Object, e As EventArgs) Handles tsbText.Click, tsmiTextLabel.Click
        Dim txtLbl As New TextLabel(True) With {.Text = "New Text Label", .Name = $"TextLabel{GetControlCount("TextLabel")}", .AutoSize = True, .Location = CalculateCenter(monForm.Size, New Size(300, 30)), .Size = New Size(200, 30),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(txtLbl)

        Dim node As New TreeNode($"{txtLbl.Name} ({txtLbl.Sensor.ToString})") With {.Tag = txtLbl, .Name = txtLbl.Name}
        root.Nodes.Add(node)

        AddHandler txtLbl.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbRoundSB_Click(sender As Object, e As EventArgs) Handles tsbRoundSB.Click, tsmiRoundSB.Click
        Dim csbProgress As New CircularStatusBar(True) With {.Text = "New Circular Status Bar", .Name = $"CircularStatusBar{GetControlCount("CircularStatusBar")}", .Location = CalculateCenter(monForm.Size, New Size(50, 50)), .Size = New Size(50, 50),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(csbProgress)

        Dim node As New TreeNode($"{csbProgress.Name} ({csbProgress.Sensor.ToString})") With {.Tag = csbProgress, .Name = csbProgress.Name}
        root.Nodes.Add(node)

        AddHandler csbProgress.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbStatusBar_Click(sender As Object, e As EventArgs) Handles tsbStatusBar.Click, tsmiStatusBar.Click
        Dim sbProgress As New StatusBar(True) With {.Text = "New Status Bar", .Name = $"StatusBar{GetControlCount("StatusBar")}", .Location = CalculateCenter(monForm.Size, New Size(100, 20)), .Size = New Size(100, 20),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(sbProgress)

        Dim node As New TreeNode($"{sbProgress.Name} ({sbProgress.Sensor.ToString})") With {.Tag = sbProgress, .Name = sbProgress.Name}
        root.Nodes.Add(node)

        AddHandler sbProgress.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbImage_Click(sender As Object, e As EventArgs) Handles tsbImage.Click, tsmiImageBox.Click
        Dim picBox As New ImageControl(True) With {.Text = "New Image", .Name = $"ImageControl{GetControlCount("ImageControl")}", .Location = CalculateCenter(monForm.Size, New Size(200, 200)), .Size = New Size(200, 200),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(picBox)

        Dim node As New TreeNode($"{picBox.Name} ({picBox.Sensor.ToString})") With {.Tag = picBox, .Name = picBox.Name}
        root.Nodes.Add(node)

        AddHandler picBox.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbGraphDiagram_Click(sender As Object, e As EventArgs) Handles tsbGraphDiagram.Click, tsmiPlot.Click
        Dim graph As New PlotChart(True) With {.Text = "New Plot", .Name = $"PlotChart{GetControlCount("PlotChart")}", .Location = CalculateCenter(monForm.Size, New Size(300, 200)), .Size = New Size(300, 200),
           .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(graph)

        Dim node As New TreeNode($"{graph.Name} ({graph.Sensor.ToString})") With {.Tag = graph, .Name = graph.Name}
        root.Nodes.Add(node)

        AddHandler graph.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbCompleteText_Click(sender As Object, e As EventArgs) Handles tsbCompleteText.Click, tsmiDetailSensor.Click
        Dim detail As New DetailSensor(True) With {.Text = "New Detail Sensor", .Name = $"DetailSensor{GetControlCount("DetailSensor")}", .Location = CalculateCenter(monForm.Size, New Size(200, 200)), .Size = New Size(200, 200),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(detail)

        Dim node As New TreeNode($"{detail.Name} ({detail.DetailedSensor.ToString})") With {.Tag = detail, .Name = detail.Name}
        root.Nodes.Add(node)

        AddHandler detail.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbYoutube_Click(sender As Object, e As EventArgs) Handles tsbYoutube.Click, tsmiYoutube.Click
        Dim utube As New Youtube(True) With {.Name = $"Youtube{GetControlCount("Youtube")}", .Location = CalculateCenter(monForm.Size, New Size(300, 170)), .Size = New Size(300, 170),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(utube)

        Dim node As New TreeNode($"{utube.Name} ({utube.Sensor.ToString})") With {.Tag = utube, .Name = utube.Name}
        root.Nodes.Add(node)

        AddHandler utube.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsbWeather_Click(sender As Object, e As EventArgs) Handles tsbWeather.Click, tsmiWeather.Click
        Dim wWidget As New WeatherWidget(True) With {.Name = $"WeatherWidget{GetControlCount("WeatherWidget")}", .Location = CalculateCenter(monForm.Size, New Size(150, 150)), .Size = New Size(150, 150),
            .myParentForm = monForm, .ForeColor = themeConfig.TextColor, .Tag = "ThemeControl"}
        monForm.Controls.Add(wWidget)

        Dim node As New TreeNode($"{wWidget.Name} ({wWidget.Sensor.ToString})") With {.Tag = wWidget, .Name = wWidget.Name}
        root.Nodes.Add(node)

        AddHandler wWidget.MouseClick, AddressOf Control_MouseClick
    End Sub

    Private Sub tsmiDelete_Click(sender As Object, e As EventArgs) Handles tsmiDelete.Click
        If Not tvControls.SelectedNode.Name = "ThemeConfig" Then
            If tvControls.SelectedNode.Tag.GetType = GetType(Youtube) Then
                CType(tvControls.SelectedNode.Tag, Youtube).StopPlayer()
            End If
            monForm.Controls.Remove(tvControls.SelectedNode.Tag)
            tvControls.Nodes.Remove(tvControls.SelectedNode)
        End If
    End Sub

    Private Function GetControlCount(search As String) As Integer
        Dim list As List(Of String) = monForm.Controls.Cast(Of Control)().Select(Function(x) x.Name).ToList
        Return list.Where(Function(x) x Like $"*{search}*").Count + 1
    End Function

    Private Function ControlNameExist(search As String) As Boolean
        Dim list As List(Of String) = monForm.Controls.Cast(Of Control)().Select(Function(x) x.Name).ToList
        Return list.Where(Function(x) x Like $"*{search}*").Count >= 2
    End Function

    Private Sub HowToUseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToUseToolStripMenuItem.Click
        Dim htu As String = $"Hover your mouse pointer to top left position on the controls to move.{vbNewLine}Hover your mouse pointer to the edges of the controls to resize."
        MsgBox(htu)
    End Sub

    Private Sub tsmiThemeProperties_Click(sender As Object, e As EventArgs) Handles tsmiThemeProperties.Click
        If Not root.IsSelected Then
            tvControls.SelectedNode = root
        End If
    End Sub

    Private Sub tsmiBuildTheme_Click(sender As Object, e As EventArgs) Handles tsmiBuildTheme.Click
        If Not themeFile = Nothing Then
            Dim theme As New ThemeData(themeFile)
            With theme
                .Author = themeConfig.Author
                .BackgroundColor = New MyColor(themeConfig.BackgroundColor)
                .BackgroundImage = themeConfig.BackgroundImage.ImageToBase64
                .TextColor = New MyColor(themeConfig.TextColor)
                .Name = themeConfig.Name
                .Tags = themeConfig.Tags
                .Size = themeConfig.Size
                .Version = themeConfig.Version
                .UpdateInterval = themeConfig.UpdateInterval
                .Opacity = themeConfig.Opacity
                '.TransparencyKey = New MyColor(themeConfig.TransparencyKey)
                Dim tlList As New List(Of MyTextLabel)
                Dim icList As New List(Of MyImageControl)
                Dim sbList As New List(Of MyStatusBar)
                Dim csbList As New List(Of MyCircularStatusBar)
                Dim pcList As New List(Of MyPlotChart)
                Dim dsList As New List(Of MyDetailSensor)
                Dim ytList As New List(Of MyYoutube)
                Dim wwList As New List(Of MyWeatherWidget)
                For Each control As Control In monForm.Controls
                    Select Case control.GetType
                        Case GetType(TextLabel)
                            tlList.Add(New MyTextLabel(control))
                        Case GetType(ImageControl)
                            icList.Add(New MyImageControl(control))
                        Case GetType(StatusBar)
                            sbList.Add(New MyStatusBar(control))
                        Case GetType(CircularStatusBar)
                            csbList.Add(New MyCircularStatusBar(control))
                        Case GetType(PlotChart)
                            pcList.Add(New MyPlotChart(control))
                        Case GetType(DetailSensor)
                            dsList.Add(New MyDetailSensor(control))
                        Case GetType(Youtube)
                            ytList.Add(New MyYoutube(control))
                        Case GetType(WeatherWidget)
                            wwList.Add(New MyWeatherWidget(control))
                    End Select
                Next
                .TextLabels = tlList
                .ImageBoxes = icList
                .StatusBars = sbList
                .CircularSBs = csbList
                .PlotCharts = pcList
                .DetailSensors = dsList
                .YoutubeVideos = ytList
                .WeatherWidgets = wwList
                .Snapshot = monForm.TakeScreenShot.ImageToBase64(ImageFormat.Png)
                .CustomPreview = themeConfig.CustomPreview.ImageToBase64
                .Build()
                Text = $"{themeConfig.Name} - Theme Editor"
            End With
        Else
            Dim sfd As New SaveFileDialog With {.Filter = "Theme File|*.theme", .Title = "Build As...", .FileName = themeConfig.Name}
            If sfd.ShowDialog = DialogResult.OK Then
                Dim theme As New ThemeData(sfd.FileName)
                With theme
                    .Author = themeConfig.Author
                    .BackgroundColor = New MyColor(themeConfig.BackgroundColor)
                    .BackgroundImage = themeConfig.BackgroundImage.ImageToBase64
                    .TextColor = New MyColor(themeConfig.TextColor)
                    .Name = themeConfig.Name
                    .Tags = themeConfig.Tags
                    .Size = themeConfig.Size
                    .Version = themeConfig.Version
                    .UpdateInterval = themeConfig.UpdateInterval
                    .Opacity = themeConfig.Opacity
                    '.TransparencyKey = New MyColor(themeConfig.TransparencyKey)
                    Dim tlList As New List(Of MyTextLabel)
                    Dim icList As New List(Of MyImageControl)
                    Dim sbList As New List(Of MyStatusBar)
                    Dim csbList As New List(Of MyCircularStatusBar)
                    Dim pcList As New List(Of MyPlotChart)
                    Dim dsList As New List(Of MyDetailSensor)
                    Dim ytList As New List(Of MyYoutube)
                    Dim wwList As New List(Of MyWeatherWidget)
                    For Each control As Control In monForm.Controls
                        Select Case control.GetType
                            Case GetType(TextLabel)
                                tlList.Add(New MyTextLabel(control))
                            Case GetType(ImageControl)
                                icList.Add(New MyImageControl(control))
                            Case GetType(StatusBar)
                                sbList.Add(New MyStatusBar(control))
                            Case GetType(CircularStatusBar)
                                csbList.Add(New MyCircularStatusBar(control))
                            Case GetType(PlotChart)
                                pcList.Add(New MyPlotChart(control))
                            Case GetType(DetailSensor)
                                dsList.Add(New MyDetailSensor(control))
                            Case GetType(Youtube)
                                ytList.Add(New MyYoutube(control))
                            Case GetType(WeatherWidget)
                                wwList.Add(New MyWeatherWidget(control))
                        End Select
                    Next
                    .TextLabels = tlList
                    .ImageBoxes = icList
                    .StatusBars = sbList
                    .CircularSBs = csbList
                    .PlotCharts = pcList
                    .DetailSensors = dsList
                    .YoutubeVideos = ytList
                    .WeatherWidgets = wwList
                    .Snapshot = monForm.TakeScreenShot.ImageToBase64(ImageFormat.Png)
                    .CustomPreview = themeConfig.CustomPreview.ImageToBase64
                    .Build()
                    Text = $"{themeConfig.Name} - Theme Editor"
                End With
            End If
        End If
    End Sub

    Private Sub tsmiCopy_Click(sender As Object, e As EventArgs) Handles tsmiCopy.Click
        If Not tvControls.SelectedNode.Name = "ThemeConfig" Then
            If tvControls.SelectedNode.Tag.GetType = GetType(Youtube) Then
                CType(tvControls.SelectedNode.Tag, Youtube).StopPlayer()
            End If

            CopyControl(CType(tvControls.SelectedNode.Tag, Control))
        End If
    End Sub

    Public Sub CopyControl(ctrl As Control)
        Select Case ctrl.GetType
            Case GetType(TextLabel)
                Dim source = CType(ctrl, TextLabel)
                Dim textLabel As New TextLabel(True)
                With textLabel
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .BeforeText = source.BeforeText
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"TextLabel{GetControlCount("TextLabel")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .BorderStyle = source.BorderStyle
                    .FlatStyle = source.FlatStyle
                    .Image = source.Image
                    .ImageAlign = source.ImageAlign
                    .TextAlign = source.TextAlign
                    .UseMnemonic = source.UseMnemonic
                    .AutoEllipsis = source.AutoEllipsis
                    .UseCompatibleTextRendering = source.UseCompatibleTextRendering
                    .AutoSize = source.AutoSize
                    .Sensor = source.Sensor
                    .SensorParam = source.SensorParam
                    .AllowUserEdit = source.AllowUserEdit
                End With
                monForm.Controls.Add(textLabel)

                Dim node As New TreeNode($"{textLabel.Name} ({textLabel.Sensor.ToString})") With {.Tag = textLabel, .Name = textLabel.Name}
                root.Nodes.Add(node)

                AddHandler textLabel.MouseClick, AddressOf Control_MouseClick
            Case GetType(ImageControl)
                Dim source = CType(ctrl, ImageControl)
                Dim imageControl As New ImageControl(True)
                With imageControl
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .BackgroundImage = source.BackgroundImage
                    .BackgroundImageLayout = source.BackgroundImageLayout
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"ImageControl{GetControlCount("ImageControl")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .BorderStyle = source.BorderStyle
                    .Image = source.Image
                    .SizeMode = source.SizeMode
                    .Sensor = source.Sensor
                    .SensorParam = source.SensorParam
                    .EnableDynamicImages = source.EnableDynamicImages
                    .DynamicImages = source.DynamicImages
                    .AllowUserEdit = source.AllowUserEdit
                End With
                monForm.Controls.Add(imageControl)

                Dim node As New TreeNode($"{imageControl.Name} ({imageControl.Sensor.ToString})") With {.Tag = imageControl, .Name = imageControl.Name}
                root.Nodes.Add(node)

                AddHandler imageControl.MouseClick, AddressOf Control_MouseClick
            Case GetType(StatusBar)
                Dim source = CType(ctrl, StatusBar)
                Dim statusBar As New StatusBar(True)
                With statusBar
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"StatusBar{GetControlCount("StatusBar")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .BackgroundColor = source.BackgroundColor
                    .ForegroundColor = source.ForegroundColor
                    .Value = source.Value
                    .Minimum = source.Minimum
                    .Maximum = source.Maximum
                    .Sensor = source.Sensor
                    .SensorParam = source.SensorParam
                    .Texture = source.Texture
                    .TextureSize = source.TextureSize
                    .UseTexture = source.UseTexture
                End With
                monForm.Controls.Add(statusBar)

                Dim node As New TreeNode($"{statusBar.Name} ({statusBar.Sensor.ToString})") With {.Tag = statusBar, .Name = statusBar.Name}
                root.Nodes.Add(node)

                AddHandler statusBar.MouseClick, AddressOf Control_MouseClick
            Case GetType(CircularStatusBar)
                Dim source = CType(ctrl, CircularStatusBar)
                Dim circularStatusBar As New CircularStatusBar(True)
                With circularStatusBar
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"CircularStatusBar{GetControlCount("CircularStatusBar")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .Style = source.Style
                    .SubText = source.SubText
                    .ProgressColor2 = source.ProgressColor2
                    .BarWidth = source.BarWidth
                    .GradientMode = source.GradientMode
                    .ForegroundColor = source.ForegroundColor
                    .ProgressColor = source.ProgressColor
                    .Thickness = source.Thickness
                    .StartAngle = source.StartAngle
                    .ProgressShape = source.ProgressShape
                    .Value = source.Value
                    .Unit = source.Unit
                    .Minimum = source.Minimum
                    .Maximum = source.Maximum
                    .TextMode = source.TextMode
                    .Sensor = source.Sensor
                    .SensorParam = source.SensorParam
                End With
                monForm.Controls.Add(circularStatusBar)

                Dim node As New TreeNode($"{circularStatusBar.Name} ({circularStatusBar.Sensor.ToString})") With {.Tag = circularStatusBar, .Name = circularStatusBar.Name}
                root.Nodes.Add(node)

                AddHandler circularStatusBar.MouseClick, AddressOf Control_MouseClick
            Case GetType(PlotChart)
                Dim source = CType(ctrl, PlotChart)
                Dim sourcePCS = CType(source.PlotChartStyle, PlotChartStyle)
                Dim newPCS As New PlotChartStyle()
                With newPCS
                    .AntiAliasing = sourcePCS.AntiAliasing
                    .AvgLinePen = sourcePCS.AvgLinePen
                    .BackgroundColorBottom = sourcePCS.BackgroundColorBottom
                    .BackgroundColorTop = sourcePCS.BackgroundColorTop
                    .ChartLinePen = sourcePCS.ChartLinePen
                    .HorizontalGridPen = sourcePCS.HorizontalGridPen
                    .ShowAverageLine = sourcePCS.ShowAverageLine
                    .ShowCurMax = sourcePCS.ShowCurMax
                    .ShowHorizontalGridLines = sourcePCS.ShowHorizontalGridLines
                    .ShowVerticalGridLines = sourcePCS.ShowVerticalGridLines
                    .VerticalGridPen = sourcePCS.VerticalGridPen
                End With
                Dim plotChart As New PlotChart(True)
                With plotChart
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"PlotChart{GetControlCount("PlotChart")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .Sensor = source.Sensor
                    .SensorParam = source.SensorParam
                    .PlotChartStyle = newPCS
                    .BorderStyle = source.BorderStyle
                    .ScaleMode = source.ScaleMode
                End With
                monForm.Controls.Add(plotChart)

                Dim node As New TreeNode($"{plotChart.Name} ({plotChart.Sensor.ToString})") With {.Tag = plotChart, .Name = plotChart.Name}
                root.Nodes.Add(node)

                AddHandler plotChart.MouseClick, AddressOf Control_MouseClick
            Case GetType(DetailSensor)
                Dim source = CType(ctrl, DetailSensor)
                Dim detailSensor As New DetailSensor(True)
                With detailSensor
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"DetailSensor{GetControlCount("DetailSensor")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .DetailedSensor = source.DetailedSensor
                    .DrawBorder = source.DrawBorder
                End With
                monForm.Controls.Add(detailSensor)

                Dim node As New TreeNode($"{detailSensor.Name} ({detailSensor.DetailedSensor.ToString})") With {.Tag = detailSensor, .Name = detailSensor.Name}
                root.Nodes.Add(node)

                AddHandler detailSensor.MouseClick, AddressOf Control_MouseClick
            Case GetType(Youtube)
                Dim source = CType(ctrl, Youtube)
                Dim youtube As New Youtube(True)
                With youtube
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .ForeColor = source.ForeColor
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .YoutubeID = source.YoutubeID
                    .Name = $"Youtube{GetControlCount("Youtube")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .Sensor = source.Sensor
                    .Play = source.Play
                End With
                monForm.Controls.Add(youtube)

                Dim node As New TreeNode($"{youtube.Name} ({youtube.Sensor.ToString})") With {.Tag = youtube, .Name = youtube.Name}
                root.Nodes.Add(node)

                AddHandler youtube.MouseClick, AddressOf Control_MouseClick
            Case GetType(WeatherWidget)
                Dim source = CType(ctrl, WeatherWidget)
                Dim weatherWidget As New WeatherWidget(True)
                With weatherWidget
                    .myParentForm = monForm
                    .BackColor = source.BackColor
                    .Font = source.Font
                    .ForeColor = source.ForeColor
                    .RightToLeft = source.RightToLeft
                    .Text = source.Text
                    .Enabled = source.Enabled
                    .Visible = source.Visible
                    .Tag = "ThemeControl"
                    .Name = $"WeatherWidget{GetControlCount("WeatherWidget")}"
                    .Anchor = source.Anchor
                    .Dock = source.Dock
                    .Location = source.Location
                    .Margin = source.Margin
                    .Padding = source.Padding
                    .Size = source.Size
                    .Sensor = source.Sensor
                    .WeatherStyle = source.WeatherStyle
                    .IconStyle = source.IconStyle
                End With
                monForm.Controls.Add(weatherWidget)

                Dim node As New TreeNode($"{weatherWidget.Name} ({weatherWidget.Sensor.ToString})") With {.Tag = weatherWidget, .Name = weatherWidget.Name}
                root.Nodes.Add(node)

                AddHandler weatherWidget.MouseClick, AddressOf Control_MouseClick
        End Select
    End Sub

    Private Sub frmThemeEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim result As MsgBoxResult = MessageBox.Show("All unsave changes will be lost! Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = MsgBoxResult.Yes Then
            For Each control As Control In monForm.Controls
                control.Dispose()
            Next
            monForm.Controls.Clear()
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub tvControls_DragDrop(sender As Object, e As DragEventArgs) Handles tvControls.DragDrop
        Dim targetPoint = tvControls.PointToClient(New Point(e.X, e.Y))
        Dim targetNode = tvControls.GetNodeAt(targetPoint)
        Dim draggedNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)

        If Not draggedNode.Equals(targetNode) AndAlso Not containsnode(draggedNode, targetNode) Then
            If e.Effect = DragDropEffects.Move Then
                draggedNode.Remove()
                targetNode.Nodes.Add(draggedNode)
            End If
            targetNode.Expand()
        End If


        If targetNode Is root Then
            Dim control As Control = draggedNode.Tag
            control.Parent = monForm
        Else
            Dim control As Control = draggedNode.Tag
            Dim parentCtrl As Control = targetNode.Tag
            control.Parent = parentCtrl
        End If
    End Sub

    Private Function ContainsNode(node1 As TreeNode, node2 As TreeNode) As Boolean
        If node2.Parent Is Nothing Then Return False
        If node2.Parent.Equals(node1) Then Return True

        Return ContainsNode(node1, node2.Parent)
    End Function

    Private Sub tvControls_DragOver(sender As Object, e As DragEventArgs) Handles tvControls.DragOver
        Dim targetPoint = tvControls.PointToClient(New Point(e.X, e.Y))
        tvControls.SelectedNode = tvControls.GetNodeAt(targetPoint)
    End Sub

    Private Sub tvControls_DragEnter(sender As Object, e As DragEventArgs) Handles tvControls.DragEnter
        e.Effect = e.AllowedEffect
    End Sub

    Private Sub tvControls_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles tvControls.ItemDrag
        If e.Button = MouseButtons.Left Then
            DoDragDrop(e.Item, DragDropEffects.Move)
        End If
    End Sub
End Class