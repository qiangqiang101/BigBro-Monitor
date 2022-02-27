Imports MaterialSkin

Public Class frmActivateLicense

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SkinManager.AddFormToManage(Me)
        Text = ProgramLanguage.ActivationTitle
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        If txtEmail.Text = Nothing Then
            MsgBox("Please enter your email address.", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf Not txtEmail.Text.IsEmailValid() Then
            MsgBox("The email address you entered is invalid, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf txtKey.Text = Nothing Then
            MsgBox("The product key you entered is invalid or not exists, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf txtKey.Text.Length < 19 Then
            MsgBox("The product key you entered is invalid or not exists, please try again or contact our support team.", MsgBoxStyle.Exclamation, "Invalid")
        Else
            Dim success = ELSActivateLicense(txtKey.Text, HWID, txtEmail.Text)
            If success Then
                Dim newUserSettings As New UserSettingData(UserSettingFile)
                With newUserSettings
                    .CurrentTheme = UserSettings.CurrentTheme
                    .AutoStart = UserSettings.AutoStart
                    .Location = UserSettings.Location
                    .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
                    .EnableBroadcast = UserSettings.EnableBroadcast
                    .BroadcastPort = UserSettings.BroadcastPort
                    .State = UserSettings.State
                    .Town = UserSettings.Town
                    .TopMost = UserSettings.TopMost
                    .LicenseKey = txtKey.Text
                    .Email = txtEmail.Text
                    .HWID = HWID
                    .Language = UserSettings.Language
                    .AudioEffectHighQuality = UserSettings.AudioEffectHighQuality
                    .RgbEffectHighQuality = UserSettings.RgbEffectHighQuality
                    .SecondScreen = UserSettings.SecondScreen
                    .SecondScreenYT = UserSettings.SecondScreenYT
                    .SecondScreenLocation = UserSettings.SecondScreenLocation
                    .SecondScreenSize = UserSettings.SecondScreenSize
                    .SaveSilent()
                End With
                UserSettings = New UserSettingData(UserSettingFile).Instance
                If frmSetting.Visible Then frmSetting.ReloadInfo()
                IsActivated = True
                'MsgBox("Activation successful, thanks for your support.", MsgBoxStyle.Information, "Activation")
                Close()
            End If
        End If
    End Sub

    Private Sub frmActivateLicense_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = ProgramLanguage.ActivationTitle
        lblEnterLicense.Text = ProgramLanguage.lblEnterLicense
        btnActivate.Text = ProgramLanguage.btnActivate
        btnCancel.Text = ProgramLanguage.btnCancel
    End Sub
End Class