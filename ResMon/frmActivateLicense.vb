Imports MaterialSkin

Public Class frmActivateLicense

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim msm = MaterialSkinManager.Instance
        msm.AddFormToManage(Me)
        msm.Theme = MaterialSkinManager.Themes.DARK
        msm.ColorScheme = New ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Yellow200, TextShade.BLACK)
        Text = ProgramLanguage.ActivationTitle
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        Dim success = ELSActivateLicense(txtKey.Text, HWID, MachineName)
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
                .HWID = HWID
                .Language = UserSettings.Language
                .SaveSilent()
            End With
            UserSettings = New UserSettingData(UserSettingFile).Instance
            If frmSetting.Visible Then frmSetting.ReloadInfo()
            IsActivated = True
            'MsgBox("Activation successful, thanks for your support.", MsgBoxStyle.Information, "Activation")
            Close()
        End If
    End Sub

    Private Sub frmActivateLicense_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = ProgramLanguage.ActivationTitle
        lblEnterLicense.Text = ProgramLanguage.lblEnterLicense
        btnActivate.Text = ProgramLanguage.btnActivate
        btnCancel.Text = ProgramLanguage.btnCancel
    End Sub
End Class