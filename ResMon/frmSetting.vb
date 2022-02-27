﻿Imports System.IO
Imports Echevil
Imports MaterialSkin
Imports OpenHardwareMonitor.Hardware

Public Class frmSetting

    Private ReadOnly netMonitor As New NetworkMonitor
    Private ReadOnly startupFile As String = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName)}.lnk"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SkinManager.AddFormToManage(Me)
        Text = ProgramLanguage.SettingTitle
    End Sub

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each state In States
                cmbStates.Items.Add(state.Value)
            Next
            cmbStates.SelectedIndex = 0

            For Each adapter In netMonitor.Adapters
                If Not cmbNetwork.Items.Contains(adapter.Name) Then cmbNetwork.Items.Add(adapter.Name)
            Next

            For Each langFile As String In Directory.GetFiles(LangsDir, "*.xml")
                Dim fileName As String = Path.GetFileNameWithoutExtension(langFile)
                If Not cmbLanguage.Items.Contains(fileName) Then
                    cmbLanguage.Items.Add(fileName)
                End If
            Next

            cmbLanguage.SelectedItem = UserSettings.Language
            Try
                cmbNetwork.SelectedIndex = UserSettings.NetworkAdapterIndex
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                Logger.Log(ex)
            End Try
            cbAuto.Checked = UserSettings.AutoStart 'File.Exists(startupFile)
            cbBroadcast.Checked = UserSettings.EnableBroadcast
            txtPort.Text = UserSettings.BroadcastPort
            cmbStates.SelectedItem = UserSettings.State
            If cmbTown.Items.Count <> 0 Then
                cmbTown.SelectedItem = UserSettings.Town
            End If
            cbTopMost.Checked = UserSettings.TopMost
            cbHQRgb.Checked = UserSettings.RgbEffectHighQuality
            cbHQAE.Checked = UserSettings.AudioEffectHighQuality
            If IsActivated Then
                btnActivate.Hide()
                lblLicense.Text = $"{ProgramLanguage.Registered} ({If(RemainingDays = 1, ProgramLanguage.DayRemain.Replace("%dr%", RemainingDays), ProgramLanguage.DaysRemain.Replace("%dr%", RemainingDays))})"
                lblKey.Text = UserSettings.LicenseKey
            Else
                lblLicense.Text = ProgramLanguage.Unregistered
                lblKey.Text = Nothing
            End If
            lblName.Text = UserSettings.Email
            cbSSEnable.Checked = UserSettings.SecondScreen
            txtSSTYID.Text = UserSettings.SecondScreenYT
            txtSSWidth.Text = UserSettings.SecondScreenSize.Width
            txtSSHeight.Text = UserSettings.SecondScreenSize.Height
        Catch ex As Exception
            Logger.Log(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        'Translate
        Try
            Text = ProgramLanguage.SettingTitle
            lblNetworkAdapter.Text = ProgramLanguage.lblNetworkAdapter
            lblBroadcastPort.Text = ProgramLanguage.lblBroadcastPort
            cbBroadcast.Text = ProgramLanguage.cbBroadcast
            gbWeather.Text = ProgramLanguage.gbWeather
            lblState.Text = ProgramLanguage.lblState
            lblTown.Text = ProgramLanguage.lblTown
            cbAuto.Text = ProgramLanguage.cbAuto
            cbTopMost.Text = ProgramLanguage.cbTopMost
            lblLanguage.Text = ProgramLanguage.lblLanguage
            gbLicense.Text = ProgramLanguage.gbLicense
            btnActivate.Text = ProgramLanguage.btnActivate
            btnCredits.Text = ProgramLanguage.btnCredits
            btnSave.Text = ProgramLanguage.btnSave
            cbResetSPanel.Text = ProgramLanguage.cbResetSPanel
            cbHQRgb.Text = ProgramLanguage.cbHQRgb
            cbHQAE.Text = ProgramLanguage.cbHQAE
            gbSecondScreen.Text = ProgramLanguage.gbSecondScreen
            cbSSEnable.Text = ProgramLanguage.cbSSEnable
            cbSSPosReset.Text = ProgramLanguage.cbSSPosReset
            lblSSYTID.Text = ProgramLanguage.lblSSYTID
            lblSSSize.Text = ProgramLanguage.lblSSSize
        Catch ex As Exception
            Logger.Log(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ReloadInfo()
        cmbLanguage.SelectedItem = UserSettings.Language
        Try
            cmbNetwork.SelectedIndex = UserSettings.NetworkAdapterIndex
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
        cbAuto.Checked = UserSettings.AutoStart 'File.Exists(startupFile)
        cbBroadcast.Checked = UserSettings.EnableBroadcast
        txtPort.Text = UserSettings.BroadcastPort
        cbHQRgb.Checked = UserSettings.RgbEffectHighQuality
        cbHQAE.Checked = UserSettings.AudioEffectHighQuality
        cmbStates.SelectedItem = UserSettings.State
        If cmbTown.Items.Count <> 0 Then
            cmbTown.SelectedItem = UserSettings.Town
        End If
        cbTopMost.Checked = UserSettings.TopMost
        If UserSettings.LicenseKey = Nothing Then
            lblLicense.Text = ProgramLanguage.Unregistered
            lblKey.Text = Nothing
        Else
            btnActivate.Hide()
            lblLicense.Text = $"{ProgramLanguage.Registered} ({If(RemainingDays = 1, ProgramLanguage.DayRemain.Replace("%dr%", RemainingDays), ProgramLanguage.DaysRemain.Replace("%dr%", RemainingDays))})"
            lblKey.Text = UserSettings.LicenseKey
        End If
        lblName.Text = UserSettings.Email
        cbSSEnable.Checked = UserSettings.SecondScreen
        txtSSTYID.Text = UserSettings.SecondScreenYT
        txtSSWidth.Text = UserSettings.SecondScreenSize.Width
        txtSSHeight.Text = UserSettings.SecondScreenSize.Height
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not IsNumeric(txtPort.Text) Then
            MsgBox(ProgramLanguage.PortInvalid, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If cbAuto.Checked Then
            CreateShortcutInStartUp()
        Else
            DeleteShortcutInStartup()
        End If

        Try
            Dim newUserSettings As New UserSettingData(UserSettingFile)
            With newUserSettings
                .CurrentTheme = UserSettings.CurrentTheme
                .AutoStart = cbAuto.Checked
                If cbResetSPanel.Checked Then
                    .Location = Point.Empty
                Else
                    .Location = UserSettings.Location
                End If
                .NetworkAdapterIndex = cmbNetwork.SelectedIndex
                .EnableBroadcast = cbBroadcast.Checked
                .BroadcastPort = txtPort.Text
                .State = cmbStates.SelectedItem.ToString
                .Town = cmbTown.SelectedItem.ToString
                .TopMost = cbTopMost.Checked
                .LicenseKey = UserSettings.LicenseKey
                .Email = UserSettings.Email
                .HWID = UserSettings.HWID
                .Language = cmbLanguage.SelectedItem.ToString
                .RgbEffectHighQuality = cbHQRgb.Checked
                .AudioEffectHighQuality = cbHQAE.Checked
                .SecondScreen = cbSSEnable.Checked
                .SecondScreenYT = txtSSTYID.Text
                If cbSSPosReset.Checked Then
                    .SecondScreenLocation = Point.Empty
                Else
                    .SecondScreenLocation = UserSettings.SecondScreenLocation
                End If
                .SecondScreenSize = New Size(CInt(txtSSWidth.Text), CInt(txtSSHeight.Text))
                .Save()
            End With
            UserSettings = New UserSettingData(UserSettingFile).Instance
            ProgramLanguage = New LanguageData(Path.Combine(LangsDir, $"{UserSettings.Language}.xml")).Instance
        Catch ex As Exception
            Logger.Log(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CreateShortcutInStartUp()
        Try
            Dim regKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If test Then
                regKey.SetValue(Application.ProductName, $"{Application.ExecutablePath} -test -auto")
            Else
                regKey.SetValue(Application.ProductName, $"{Application.ExecutablePath} -auto")
            End If
            regKey.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DeleteShortcutInStartup()
        Try
            Dim regKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.DeleteValue(Application.ProductName)
            regKey.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmSetting_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmMain.Show()
    End Sub

    Private Sub cmbStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStates.SelectedIndexChanged
        Try
            If Not cmbStates.SelectedItem = Nothing Then
                cmbTown.Items.Clear()
                For Each town In GetTowns(GetStateID(cmbStates.SelectedItem.ToString))
                    cmbTown.Items.Add(town.Name)
                Next
                cmbTown.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click
        frmAbout.Show()
    End Sub

    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        frmActivateLicense.Show()
    End Sub
End Class