Imports System.IO
Imports MaterialSkin

Public Class frmMain

    Private silent As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        SkinManager.ColorScheme = New ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Yellow200, TextShade.BLACK)

        Text = $"BigBro Monitor v{Application.ProductVersion} Build {GetBuildDateTime.ToShortDateString} {If(IsAdministrator(), "(Administrator)", "")}"
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(UserSettingFile) Then
            If Not Directory.Exists($"{My.Computer.FileSystem.SpecialDirectories.MyDocuments}\BigBro Monitor") Then Directory.CreateDirectory($"{My.Computer.FileSystem.SpecialDirectories.MyDocuments}\BigBro Monitor")

            If File.Exists(OldUserSettingFile) Then
                File.Move(OldUserSettingFile, UserSettingFile)
                UserSettings = New UserSettingData(UserSettingFile).Instance
                ProgramLanguage = New LanguageData(Path.Combine(LangsDir, $"{UserSettings.Language}.xml")).Instance
            Else
                Dim tempUserSetting As New UserSettingData(UserSettingFile)
                With tempUserSetting
                    .AudioEffectHighQuality = False
                    .AutoStart = False
                    .BroadcastPort = 8080
                    .CurrentTheme = "Project Cyan 5inch.xml"
                    .Email = Nothing
                    .EnableBroadcast = False
                    .HWID = Nothing
                    .Language = "English"
                    .LicenseKey = Nothing
                    .Location = Point.Empty
                    .NetworkAdapterIndex = 0
                    .RgbEffectHighQuality = False
                    .State = "KUALA LUMPUR"
                    .Town = "KUALA LUMPUR"
                    .TopMost = True
                End With
                tempUserSetting.SaveSilent()
                UserSettings = tempUserSetting
                ProgramLanguage = New LanguageData(Path.Combine(LangsDir, $"{UserSettings.Language}.xml")).Instance
            End If
        End If

        Dim msm = MaterialSkinManager.Instance
        msm.AddFormToManage(Me)
        msm.Theme = MaterialSkinManager.Themes.DARK
        msm.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)

        Dim activationTuple = CheckActivation(HWID, UserSettings.Email)
        IsActivated = activationTuple.Item1
        RemainingDays = activationTuple.Item2

        If Not Directory.Exists(ThemesDir) Then Directory.CreateDirectory(ThemesDir)
        If Not Directory.Exists(PresetDataDir) Then Directory.CreateDirectory(PresetDataDir)
        If Not Directory.Exists(FontsDir) Then Directory.CreateDirectory(FontsDir)
        If Not Directory.Exists(LogsDir) Then Directory.CreateDirectory(LogsDir)
        If Not Directory.Exists(LangsDir) Then Directory.CreateDirectory(LangsDir)

        Dim args As String() = Environment.GetCommandLineArgs()
        For Each arg As String In args
            If arg.Contains("-auto") Then
                If Not IsAdministrator() Then
                    RestarAsAdministrator("-auto")
                    End
                End If

                If IsActivated Then
                    silent = True
                    frmMonitor.Show()
                    RefreshMonitor()
                    Me.WindowState = FormWindowState.Minimized
                    niTray.Visible = True
                    Me.Hide()
                End If
            Else
                If Not Debugger.IsAttached Then
                    If Not IsAdministrator() Then
                        RestarAsAdministrator(Nothing)
                        End
                    End If
                End If
            End If
        Next

        LoadPrivateFonts()
        PopulateFlp()
        Text = $"BigBro Monitor v{Application.ProductVersion} Build {GetBuildDateTime.ToShortDateString} {If(IsAdministrator(), "(Administrator)", "")}"

        'Translate
        btnResetFilter.Text = ProgramLanguage.btnResetFilter
        btnSearch.Text = ProgramLanguage.btnSearch
        gbSettings.Text = ProgramLanguage.gbSettings
        btnApply.Text = ProgramLanguage.btnApply
        btnDelete.Text = ProgramLanguage.btnDelete
        btnThemeEditor.Text = ProgramLanguage.btnThemeEditor
        btnSettings.Text = ProgramLanguage.btnSettings
        btnOK.Text = ProgramLanguage.btnOK
        btnCancel.Text = ProgramLanguage.btnCancel
        niTray.BalloonTipText = ProgramLanguage.niTray
        btnDownloadTheme.Text = ProgramLanguage.btnDownloadTheme
    End Sub

    Private Sub LoadPrivateFonts()
        For Each font As String In Directory.GetFiles(FontsDir, "*.*")
            PrivateFonts.AddFontFile(font)
        Next
    End Sub

    Private Sub PopulateFlp()
        For Each file As String In Directory.GetFiles(ThemesDir, "*.*").Where(Function(x) x.EndsWith(".xml") OrElse x.EndsWith(".theme"))
            Dim theme As ThemeData = New ThemeData().Instance

            Select Case Path.GetExtension(file)
                Case ".theme"
                    theme = New ThemeData(file).ThemeInstance
                Case ".xml"
                    theme = New ThemeData(file).Instance
                Case Else
                    Continue For
            End Select

            Dim item As New NSThemeItem(theme, Path.GetFileName(file))
            flpThemes.Controls.Add(item)

            If UserSettings.CurrentTheme = Path.GetFileName(file) Then
                Dim preset As UserPresetData = New UserPresetData(Path.Combine(PresetDataDir, UserSettings.CurrentTheme)).Instance

                If Not theme.CustomPreview = Nothing Then
                    pbThemeSnapshot.Image = theme.CustomPreview.Base64ToImage
                Else
                    pbThemeSnapshot.Image = theme.Snapshot.Base64ToImage
                End If
                lblThemeName.Text = $"{theme.Name} {theme.Version}"
                lblAuthor.Text = theme.Author
                'flpTags.Controls.Add(New Label() With {.Text = $"{theme.Size.Width}x{theme.Size.Height}", .AutoSize = True, .BackColor = Color.DarkGray, .ForeColor = Color.White})
                If theme.Tags IsNot Nothing Then
                    For Each tag As String In theme.Tags
                        Dim lbl As New TagsLabel() With {.Text = tag, .AutoSize = True, .LabelColor = Color.DarkGray, .ForeColor = Color.White, .BackColor = Color.Transparent}
                        flpTags.Controls.Add(lbl)
                    Next
                End If

                flpUserDefine.Tag = theme
                AddingUserDefineOptions(theme, preset)

                If flpUserDefine.Controls.Count >= 1 Then
                    btnApply.Enabled = True
                Else
                    btnApply.Enabled = False
                End If
            End If

            AddHandler item.MouseClick, AddressOf ThemeBrowserItem_MouseClick
        Next
    End Sub

    Private Sub AddingUserDefineOptions(theme As ThemeData, preset As UserPresetData)
        For Each label As MyTextLabel In theme.TextLabels.Where(Function(x) x.AllowUserEdit)
            Dim udItem As New NSUserDefineItem()
            With udItem
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = label.Name
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = label.Name).Value
                Catch ex As Exception
                    .txtBox.Text = label.Text
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem)
        Next
        For Each image As MyImageControl In theme.ImageBoxes.Where(Function(x) x.AllowUserEdit)
            Dim udItem As New NSUserDefineItem()
            With udItem
                .ControlType = eControlType.ImageControl
                .lblLabel.Text = image.Name
                Try
                    .fpbImage.Image = preset.ImageBoxes.SingleOrDefault(Function(x) x.Name = image.Name).Image.Base64ToImage
                Catch ex As Exception
                    .fpbImage.Image = image.Image.Base64ToImage
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem)
        Next
        For Each utube As MyYoutube In theme.YoutubeVideos
            Dim udItem As New NSUserDefineItem()
            With udItem
                .ControlType = eControlType.Youtube
                .lblLabel.Text = utube.Name
                Try
                    .txtBox.Text = preset.YoutubeVideos.SingleOrDefault(Function(x) x.Name = utube.Name).Value
                Catch ex As Exception
                    .txtBox.Text = utube.YoutubeID
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem)
        Next

        For Each label As MyTextLabel In theme.TextLabels.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = label.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = label.Name).Value
                Catch ex As Exception
                    .txtBox.Text = label.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each cText As MyCustomText In theme.CustomTexts.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = cText.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = cText.Name).Value
                Catch ex As Exception
                    .txtBox.Text = cText.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each image As MyImageControl In theme.ImageBoxes.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = image.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = image.Name).Value
                Catch ex As Exception
                    .txtBox.Text = image.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each csb As MyCircularStatusBar In theme.CircularSBs.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = csb.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = csb.Name).Value
                Catch ex As Exception
                    .txtBox.Text = csb.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each chart As MyPlotChart In theme.PlotCharts.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = chart.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = chart.Name).Value
                Catch ex As Exception
                    .txtBox.Text = chart.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each statusbar As MyStatusBar In theme.StatusBars.Where(Function(x) x.Sensor = eSensorType.CPUFan Or x.Sensor = eSensorType.MoboFan)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = statusbar.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = statusbar.Name).Value
                Catch ex As Exception
                    .txtBox.Text = statusbar.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next

        For Each label As MyTextLabel In theme.TextLabels.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = label.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = label.Name).Value
                Catch ex As Exception
                    .txtBox.Text = label.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each cText As MyCustomText In theme.CustomTexts.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = cText.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = cText.Name).Value
                Catch ex As Exception
                    .txtBox.Text = cText.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each image As MyImageControl In theme.ImageBoxes.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = image.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = image.Name).Value
                Catch ex As Exception
                    .txtBox.Text = image.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each csb As MyCircularStatusBar In theme.CircularSBs.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = csb.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = csb.Name).Value
                Catch ex As Exception
                    .txtBox.Text = csb.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each chart As MyPlotChart In theme.PlotCharts.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = chart.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = chart.Name).Value
                Catch ex As Exception
                    .txtBox.Text = chart.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
        For Each statusbar As MyStatusBar In theme.StatusBars.Where(Function(x) x.Sensor = eSensorType.HDDLoadPercent Or x.Sensor = eSensorType.HDDTemperatureC Or x.Sensor = eSensorType.HDDTemperatureF)
            Dim udItem2 As New NSUserDefineItem()
            With udItem2
                .ControlType = eControlType.TextLabel
                .lblLabel.Text = statusbar.Name
                .IsNumeric = True
                Try
                    .txtBox.Text = preset.TextLabels.SingleOrDefault(Function(x) x.Name = statusbar.Name).Value
                Catch ex As Exception
                    .txtBox.Text = statusbar.SensorParam
                End Try
                .Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
            End With
            flpUserDefine.Controls.Add(udItem2)
        Next
    End Sub

    Private Sub ClearSelection()
        flpUserDefine.ControlsClear()
        flpTags.Controls.Clear()

        Dim theme As ThemeData = New ThemeData().Instance
        Dim preset As UserPresetData = New UserPresetData().Instance

        pbThemeSnapshot.Image = My.Resources.Blank
        lblThemeName.Text = Nothing
        lblAuthor.Text = Nothing

        Dim newUserSettings As New UserSettingData(UserSettingFile)
        With newUserSettings
            .CurrentTheme = Nothing
            .AutoStart = UserSettings.AutoStart
            .Location = UserSettings.Location
            .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
            .EnableBroadcast = UserSettings.EnableBroadcast
            .BroadcastPort = UserSettings.BroadcastPort
            .State = UserSettings.State
            .Town = UserSettings.Town
            .TopMost = UserSettings.TopMost
            .LicenseKey = UserSettings.LicenseKey
            .Email = UserSettings.Email
            .HWID = UserSettings.HWID
            .Language = UserSettings.Language
            .AudioEffectHighQuality = UserSettings.AudioEffectHighQuality
            .RgbEffectHighQuality = UserSettings.RgbEffectHighQuality
            .SaveSilent()
        End With
        UserSettings = New UserSettingData(UserSettingFile).Instance
    End Sub

    Private Sub ThemeBrowserItem_MouseClick(sender As Object, e As MouseEventArgs)
        flpUserDefine.ControlsClear()
        flpTags.Controls.Clear()

        Dim selectedItem As NSThemeItem
        Select Case sender.GetType
            Case GetType(NSThemeItem)
                selectedItem = sender
            Case GetType(Label)
                selectedItem = CType(sender, Label).Parent.Parent
            Case GetType(FillPicturebox)
                selectedItem = CType(sender, FillPicturebox).Parent
            Case Else
                selectedItem = sender
        End Select

        Dim preset As UserPresetData = New UserPresetData(Path.Combine(PresetDataDir, selectedItem.ThemeFile)).Instance

        If Not selectedItem.ThemeData.CustomPreview = Nothing Then
            pbThemeSnapshot.Image = selectedItem.ThemeData.CustomPreview.Base64ToImage
        Else
            pbThemeSnapshot.Image = selectedItem.ThemeData.Snapshot.Base64ToImage
        End If
        lblThemeName.Text = $"{selectedItem.ThemeData.Name} {selectedItem.ThemeData.Version}"
        lblAuthor.Text = selectedItem.ThemeData.Author
        flpUserDefine.Tag = selectedItem.ThemeData
        'flpTags.Controls.Add(New Label() With {.Text = $"{selectedItem.ThemeData.Size.Width}x{selectedItem.ThemeData.Size.Height}", .AutoSize = True, .BackColor = Color.DarkGray, .ForeColor = Color.White})
        If selectedItem.ThemeData.Tags IsNot Nothing Then
            For Each tag As String In selectedItem.ThemeData.Tags
                Dim lbl As New TagsLabel() With {.Text = tag, .AutoSize = True, .LabelColor = Color.DarkGray, .ForeColor = Color.White, .BackColor = Color.Transparent}
                flpTags.Controls.Add(lbl)
            Next
        End If

        AddingUserDefineOptions(selectedItem.ThemeData, preset)

        If flpUserDefine.Controls.Count >= 1 Then
            btnApply.Enabled = True
        Else
            btnApply.Enabled = False
        End If

        Dim newUserSettings As New UserSettingData(UserSettingFile)
        With newUserSettings
            .CurrentTheme = selectedItem.ThemeFile
            .AutoStart = UserSettings.AutoStart
            .Location = UserSettings.Location
            .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
            .EnableBroadcast = UserSettings.EnableBroadcast
            .BroadcastPort = UserSettings.BroadcastPort
            .State = UserSettings.State
            .Town = UserSettings.Town
            .TopMost = UserSettings.TopMost
            .LicenseKey = UserSettings.LicenseKey
            .Email = UserSettings.Email
            .HWID = UserSettings.HWID
            .Language = UserSettings.Language
            .AudioEffectHighQuality = UserSettings.AudioEffectHighQuality
            .RgbEffectHighQuality = UserSettings.RgbEffectHighQuality
            .SaveSilent()
        End With
        UserSettings = New UserSettingData(UserSettingFile).Instance
    End Sub

    Private Sub btnThemeEditor_Click(sender As Object, e As EventArgs) Handles btnThemeEditor.Click
        frmThemeEditor.Show()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If IsActivated Then
            If Not lblThemeName.Text = Nothing Then
                If frmMonitor.Visible Then
                    For Each control As Control In frmMonitor.Controls
                        control.Dispose()
                    Next

                    frmMonitor.Close()
                    Threading.Thread.Sleep(500)
                    frmMonitor.Show()
                    RefreshMonitor()
                Else
                    frmMonitor.Show()
                    RefreshMonitor()
                End If
            End If
        Else
            frmActivateLicense.Show()
        End If
    End Sub

    Private Sub RefreshMonitor()
        Dim currentTheme As ThemeData = FindThemeByName(UserSettings.CurrentTheme)
        Dim currentPreset As UserPresetData = FindPresetByName(UserSettings.CurrentTheme)

        With frmMonitor
            .Editing = False
            .TopLevel = True
            .BackColor = currentTheme.BackgroundColor.ToColor
            .Size = currentTheme.Size
            .ForeColor = currentTheme.TextColor.ToColor
            .Updater.Interval = currentTheme.UpdateInterval
            .Opacity = currentTheme.Opacity
            .BackgroundImage = currentTheme.BackgroundImage.Base64ToImage
            '.TransparencyKey = currentTheme.TransparencyKey.ToColor
            .RGBBackground = currentTheme.RGBBackground
            .RGBPattern = currentTheme.RGBPattern
            .RGBTransform = currentTheme.RGBTransform
            .CurrentTheme = currentTheme
        End With

        For Each tl As MyTextLabel In currentTheme.TextLabels
            Dim txtLbl As New TextLabel(False)
            With txtLbl
                .myParentForm = frmMonitor
                .BackColor = tl.BackColor.ToColor
                .Font = tl.Font.ToFont
                .ForeColor = tl.ForeColor.ToColor
                .RightToLeft = tl.RightToLeft
                .AllowUserEdit = tl.AllowUserEdit
                .BeforeText = tl.BeforeText
                Try
                    If tl.AllowUserEdit AndAlso currentPreset.TextLabels.Where(Function(x) x.Name = tl.Name).Count = 1 Then
                        .Text = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = tl.Name).Value
                    Else
                        .Text = tl.Text
                    End If
                Catch ex As Exception
                    .Text = tl.Text
                End Try
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
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        Try
                            If currentPreset.TextLabels.Where(Function(x) x.Name = tl.Name).Count = 1 Then
                                .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = tl.Name).Value
                            Else
                                .SensorParam = tl.SensorParam
                            End If
                        Catch ex As Exception
                            .SensorParam = tl.SensorParam
                        End Try
                    Case Else
                        .SensorParam = tl.SensorParam
                End Select
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(txtLbl)
        Next

        For Each ct As MyCustomText In currentTheme.CustomTexts
            Dim cusTxt As New CustomText(False)
            With cusTxt
                .myParentForm = frmMonitor
                .BackColor = ct.BackColor.ToColor
                .Font = ct.Font.ToFont
                .RightToLeft = ct.RightToLeft
                .Enabled = ct.Enabled
                .Visible = ct.Visible
                .Tag = "ThemeControl"
                .Name = ct.Name
                .Anchor = ct.Anchor
                .Dock = ct.Dock
                .Location = ct.Location
                .Margin = ct.Margin
                .Padding = ct.Padding
                .Size = ct.Size
                .BorderStyle = ct.BorderStyle
                .FlatStyle = ct.FlatStyle
                .Image = ct.Image.Base64ToImage
                .ImageAlign = ct.ImageAlign
                .UseMnemonic = ct.UseMnemonic
                .AutoEllipsis = ct.AutoEllipsis
                .UseCompatibleTextRendering = ct.UseCompatibleTextRendering
                .AutoSize = False
                .Sensor = ct.Sensor
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        Try
                            If currentPreset.TextLabels.Where(Function(x) x.Name = ct.Name).Count = 1 Then
                                .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = ct.Name).Value
                            Else
                                .SensorParam = ct.SensorParam
                            End If
                        Catch ex As Exception
                            .SensorParam = ct.SensorParam
                        End Try
                    Case Else
                        .SensorParam = ct.SensorParam
                End Select
                .Title = ct.Title
                .Value = ct.Value
                .Unit = ct.Unit
                .TitleColor = ct.TitleColor.ToColor
                .ValueColor = ct.ValueColor.ToColor
                .UnitColor = ct.UnitColor.ToColor
                .TitleAlign = ct.TitleAlign
                .ValueAlign = ct.ValueAlign
                .UnitAlign = ct.UnitAlign
                .AutoWidth = ct.AutoWidth
                .TitleWidth = ct.TitleWidth
                .ValueWidth = ct.ValueWidth
                .UnitWidth = ct.UnitWidth
                .TitleFont = ct.TitleFont.ToFont
                .UnitFont = ct.UnitFont.ToFont
                .TitleTextAdjustment = ct.TitleTextAdjustment
                .ValueTextAdjustment = ct.ValueTextAdjustment
                .UnitTextAdjustment = ct.UnitTextAdjustment
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(cusTxt)
        Next

        For Each ic As MyImageControl In currentTheme.ImageBoxes
            Dim picBox As New ImageControl(False)
            With picBox
                Dim image As String = "None"
                .myParentForm = frmMonitor
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
                .EnableDynamicImages = ic.EnableDynamicImages
                .DynamicImages = ic.DynamicImages.ToDynamicImages
                .AllowUserEdit = ic.AllowUserEdit
                .SizeMode = ic.SizeMode
                If ic.AllowUserEdit Then
                    Try
                        If currentPreset.ImageBoxes.Where(Function(x) x.Name = ic.Name).Count = 1 AndAlso Not .EnableDynamicImages Then
                            image = currentPreset.ImageBoxes.SingleOrDefault(Function(x) x.Name = ic.Name).Image
                        End If
                    Catch ex As Exception
                        image = ic.Image
                    End Try
                Else
                    image = ic.Image
                End If
                .Image = image.Base64ToImage
                .Sensor = ic.Sensor
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        If currentPreset.TextLabels.Where(Function(x) x.Name = ic.Name).Count = 1 Then
                            .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = ic.Name).Value
                        Else
                            .SensorParam = ic.SensorParam
                        End If
                    Case Else
                        .SensorParam = ic.SensorParam
                End Select
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(picBox)
        Next

        For Each sb As MyStatusBar In currentTheme.StatusBars
            Dim sbProgress As New StatusBar(False)
            With sbProgress
                .myParentForm = frmMonitor
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
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        Try
                            If currentPreset.TextLabels.Where(Function(x) x.Name = sb.Name).Count = 1 Then
                                .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = sb.Name).Value
                            Else
                                .SensorParam = sb.SensorParam
                            End If
                        Catch ex As Exception
                            .SensorParam = sb.SensorParam
                        End Try
                    Case Else
                        .SensorParam = sb.SensorParam
                End Select
                .Texture = sb.Texture.Base64ToImage
                .TextureSize = sb.TextureSize
                .UseTexture = sb.UseTexture
                .FillDirection = sb.FillDirection
                .ShowValue = sb.ShowValue
                .Unit = sb.Unit
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(sbProgress)
        Next

        For Each csb As MyCircularStatusBar In currentTheme.CircularSBs
            Dim csbProgress As New CircularStatusBar(False)
            With csbProgress
                .myParentForm = frmMonitor
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
                .ProgressShape = csb.ProgressShape
                .Thickness = csb.Thickness
                .StartAngle = csb.StartAngle
                .Value = csb.Value
                .Unit = csb.Unit
                .Minimum = csb.Minimum
                .Maximum = csb.Maximum
                .TextMode = csb.TextMode
                .Sensor = csb.Sensor
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        Try
                            If currentPreset.TextLabels.Where(Function(x) x.Name = csb.Name).Count = 1 Then
                                .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = csb.Name).Value
                            Else
                                .SensorParam = csb.SensorParam
                            End If
                        Catch ex As Exception
                            .SensorParam = csb.SensorParam
                        End Try
                    Case Else
                        .SensorParam = csb.SensorParam
                End Select
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(csbProgress)
        Next

        For Each pc As MyPlotChart In currentTheme.PlotCharts
            Dim pcPlot As New PlotChart(False)
            With pcPlot
                .myParentForm = frmMonitor
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
                Select Case .Sensor
                    Case eSensorType.CPUFan, eSensorType.MoboFan, eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        Try
                            If currentPreset.TextLabels.Where(Function(x) x.Name = pc.Name).Count = 1 Then
                                .SensorParam = currentPreset.TextLabels.SingleOrDefault(Function(x) x.Name = pc.Name).Value
                            Else
                                .SensorParam = pc.SensorParam
                            End If
                        Catch ex As Exception
                            .SensorParam = pc.SensorParam
                        End Try
                    Case Else
                        .SensorParam = pc.SensorParam
                End Select
                .PlotChartStyle = pc.PlotChartStyle.ToPlotChartStyle
                .BorderStyle = pc.BorderStyle
                .ScaleMode = pc.ScaleMode
                .rzControl = Nothing
            End With
            frmMonitor.Controls.Add(pcPlot)
        Next

        For Each ds As MyDetailSensor In currentTheme.DetailSensors
            Dim dtSensor As New DetailSensor(False)
            With dtSensor
                .myParentForm = frmMonitor
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
            End With
            frmMonitor.Controls.Add(dtSensor)
        Next

        For Each yt As MyYoutube In currentTheme.YoutubeVideos
            Dim utube As New Youtube(False)
            With utube
                .myParentForm = frmMonitor
                .BackColor = yt.BackColor.ToColor
                .ForeColor = yt.ForeColor.ToColor
                .Enabled = yt.Enabled
                .Visible = yt.Visible
                .Tag = "ThemeControl"
                .YoutubeID = yt.YoutubeID
                Try
                    If currentPreset.YoutubeVideos.Where(Function(x) x.Name = yt.Name).Count = 1 Then
                        .YoutubeID = currentPreset.YoutubeVideos.SingleOrDefault(Function(x) x.Name = yt.Name).Value
                    Else
                        .YoutubeID = yt.YoutubeID
                    End If
                Catch ex As Exception
                    .YoutubeID = yt.YoutubeID
                End Try
                .Name = yt.Name
                .Anchor = yt.Anchor
                .Dock = yt.Dock
                .Location = yt.Location
                .Margin = yt.Margin
                .Padding = yt.Padding
                .Size = yt.Size
                .Sensor = yt.Sensor
                .Play = yt.Play
            End With
            frmMonitor.Controls.Add(utube)
        Next

        For Each ww As MyWeatherWidget In currentTheme.WeatherWidgets
            Dim weawid As New WeatherWidget(False)
            With weawid
                .myParentForm = frmMonitor
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
            End With
            frmMonitor.Controls.Add(weawid)
        Next

        For Each av As MyAudioVisualizer In currentTheme.AudioVisualizers
            Dim audio As New AudioVisualizer(False)
            With audio
                .myParentForm = frmMonitor
                .BackColor = av.BackColor.ToColor
                .Font = av.Font.ToFont
                .ForeColor = av.ForeColor.ToColor
                .RightToLeft = av.RightToLeft
                .Text = av.Text
                .Enabled = av.Enabled
                .Visible = av.Visible
                .Tag = "ThemeControl"
                .Name = av.Name
                .Anchor = av.Anchor
                .Dock = av.Dock
                .Location = av.Location
                .Margin = av.Margin
                .Padding = av.Padding
                .Size = av.Size
                .Sensor = av.Sensor
                .rzControl = Nothing
                .UseAverage = av.UseAverage
                .BarCount = av.BarCount
                .BarSpacing = av.BarSpacing
                .ScalingStrategy = av.ScalingStrategy
                .Direction = av.Direction
                .LineCap = av.LineCap
                .BarStyle = av.BarStyle
                .ColorStyle = av.ColorStyle
                .Speed = av.Speed
                .Color1 = av.Color1.ToColor
                .Color2 = av.Color2.ToColor
                .Color3 = av.Color3.ToColor
                .Color4 = av.Color4.ToColor
                .Color5 = av.Color5.ToColor
                .Color6 = av.Color6.ToColor
                .Color7 = av.Color7.ToColor
                .timer.Interval = 30
            End With
            frmMonitor.Controls.Add(audio)
        Next

        currentTheme.TextLabels.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.CustomTexts.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.ImageBoxes.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.StatusBars.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.CircularSBs.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.PlotCharts.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.DetailSensors.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.YoutubeVideos.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.WeatherWidgets.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
        currentTheme.AudioVisualizers.ForEach(Sub(x) SetParentName(x.Name, x.ParentName))
    End Sub

    Private Sub SetParentName(name As String, parentName As String)
        If parentName = Nothing Then Exit Sub
        Dim ctrl1 = frmMonitor.Controls.Find(name, False).FirstOrDefault
        Dim ctrl2 = frmMonitor.Controls.Find(parentName, False).FirstOrDefault
        If ctrl1 IsNot Nothing AndAlso ctrl2 IsNot Nothing Then
            ctrl1.Parent = ctrl2
            ctrl1.Location = New Point(ctrl1.Location.X - ctrl2.Location.X, ctrl1.Location.Y - ctrl2.Location.Y)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If frmMonitor.Visible Then
            For Each control As Control In frmMonitor.Controls
                control.Dispose()
            Next
            frmMonitor.Controls.Clear()
            frmMonitor.Close()
        End If
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case WindowState
            Case FormWindowState.Minimized
                Me.Visible = False
                niTray.Visible = True
                If Not silent Then
                    niTray.ShowBalloonTip(5000)
                End If
            Case Else
                Me.Visible = True
                niTray.Visible = False
        End Select
    End Sub

    Private Sub niTray_Click(sender As Object, e As EventArgs) Handles niTray.Click
        Me.Show()
        WindowState = FormWindowState.Normal
        niTray.Visible = False
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If frmMonitor.Visible Then frmMonitor.Close()
        Me.Hide()
        frmSetting.Show()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Dim preset As UserPresetData = New UserPresetData(Path.Combine(PresetDataDir, UserSettings.CurrentTheme)).Instance

        Dim newPreset As New UserPresetData(Path.Combine(PresetDataDir, UserSettings.CurrentTheme))
        With newPreset
            .Name = UserSettings.CurrentTheme
            Dim tlList As New List(Of PDItem)
            Dim ibList As New List(Of PDItem)
            Dim yvList As New List(Of PDItem)
            For Each ctrl As NSUserDefineItem In flpUserDefine.Controls
                Select Case ctrl.ControlType
                    Case eControlType.TextLabel
                        tlList.Add(New PDItem(ctrl.lblLabel.Text, ctrl.txtBox.Text))
                    Case eControlType.ImageControl
                        ibList.Add(New PDItem(ctrl.lblLabel.Text, ctrl.fpbImage.Image.ImageToBase64, True))
                    Case eControlType.Youtube
                        yvList.Add(New PDItem(ctrl.lblLabel.Text, ctrl.txtBox.Text))
                End Select
            Next
            .TextLabels = tlList
            .ImageBoxes = ibList
            .YoutubeVideos = yvList
            .Save()
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        flpThemes.Controls.Clear()

        For Each file As String In Directory.GetFiles(ThemesDir, "*.*")
            Dim theme As ThemeData = New ThemeData().Instance
            Select Case Path.GetExtension(file)
                Case ".theme"
                    theme = New ThemeData(file).ThemeInstance
                Case ".xml"
                    theme = New ThemeData(file).Instance
                Case Else
                    Continue For
            End Select

            If theme.Tags IsNot Nothing Then
                If theme.Tags.Where(Function(x) x Like $"*{txtSearch.Text}*").Count <> 0 Then
                    Dim item As New NSThemeItem(theme, Path.GetFileName(file))
                    flpThemes.Controls.Add(item)

                    AddHandler item.MouseClick, AddressOf ThemeBrowserItem_MouseClick
                End If
            End If
        Next
    End Sub

    Private Sub btnResetFilter_Click(sender As Object, e As EventArgs) Handles btnResetFilter.Click
        flpThemes.Controls.Clear()
        txtSearch.Text = Nothing

        For Each file As String In Directory.GetFiles(ThemesDir, "*.*")
            Dim theme As ThemeData = New ThemeData().Instance
            Select Case Path.GetExtension(file)
                Case ".theme"
                    theme = New ThemeData(file).ThemeInstance
                Case ".xml"
                    theme = New ThemeData(file).Instance
                Case Else
                    Continue For
            End Select

            Dim item As New NSThemeItem(theme, Path.GetFileName(file))
            flpThemes.Controls.Add(item)

            AddHandler item.MouseClick, AddressOf ThemeBrowserItem_MouseClick
        Next
    End Sub

    Public Function FindThemeByName(search As String) As ThemeData
        For Each file As String In Directory.GetFiles(ThemesDir, "*.*").Where(Function(x) Path.GetFileName(x) = search)
            Select Case Path.GetExtension(file)
                Case ".theme"
                    Return New ThemeData(file).ThemeInstance
                Case ".xml"
                    Return New ThemeData(file).Instance
            End Select
        Next
        Return New ThemeData().Instance
    End Function

    Public Function FindPresetByName(search As String) As UserPresetData
        For Each file As String In Directory.GetFiles(PresetDataDir, "*.xml").Where(Function(x) Path.GetFileName(x) = search)
            Return New UserPresetData(file).Instance
        Next
        Return New UserPresetData().Instance
    End Function

    Public Function CountThemes() As Integer
        Return Directory.GetFiles(ThemesDir, "*.*").Where(Function(x) Path.GetExtension(x) = ".xml" OrElse Path.GetExtension(x) = ".theme").Count
    End Function

    Public Function FindThemeFileByName(search As String) As String
        For Each file As String In Directory.GetFiles(ThemesDir, "*.*").Where(Function(x) Path.GetFileName(x) = search)
            Return file
        Next
        Return Nothing
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As MsgBoxResult = MessageBox.Show("Are you sure you want to delete this theme?", "Delete Theme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = MsgBoxResult.Yes Then
            Dim themeToDelete As String = FindThemeFileByName(UserSettings.CurrentTheme)
            If File.Exists(themeToDelete) Then
                File.Delete(themeToDelete)
                flpThemes.Controls.Clear()
                txtSearch.Text = Nothing
                ClearSelection()

                For Each file As String In Directory.GetFiles(ThemesDir, "*.*")
                    Dim theme As ThemeData = New ThemeData().Instance
                    Select Case Path.GetExtension(file)
                        Case ".theme"
                            theme = New ThemeData(file).ThemeInstance
                        Case ".xml"
                            theme = New ThemeData(file).Instance
                        Case Else
                            Continue For
                    End Select

                    Dim item As New NSThemeItem(theme, Path.GetFileName(file))
                    flpThemes.Controls.Add(item)

                    AddHandler item.MouseClick, AddressOf ThemeBrowserItem_MouseClick
                Next
            End If
        End If
    End Sub

    Private Sub flpUserDefine_Resize(sender As Object, e As EventArgs) Handles flpUserDefine.Resize
        For Each control As NSUserDefineItem In flpUserDefine.Controls
            control.Width = flpUserDefine.Width - SystemInformation.VerticalScrollBarWidth
        Next
        flpUserDefine.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
    End Sub

    Private Sub flpUserDefine_ControlAdded(sender As Object, e As ControlEventArgs) Handles flpUserDefine.ControlAdded, flpUserDefine.ControlRemoved
        flpUserDefine.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
    End Sub

    Private Sub btnDownloadTheme_Click(sender As Object, e As EventArgs) Handles btnDownloadTheme.Click
        Process.Start("https://www.bigbromonitor.com")
    End Sub
End Class