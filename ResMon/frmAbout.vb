Imports MaterialSkin

Public Class frmAbout

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SkinManager.AddFormToManage(Me)
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = $" Version {Application.ProductVersion} Build {GetBuildDateTime.ToShortDateString}{vbNewLine} Developed by Zettabyte Technology"

        txtCredit.Text = My.Resources.ThirdParty '.Replace(vbCr, vbNewLine).Replace(vbLf, vbNewLine)

        Text = ProgramLanguage.AboutTitle
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class