
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsAdminLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
            Response.Redirect("License.aspx")
        Else
            swalBs("Oops!", "The User ID or Password you entered is incorrect.", "error")
        End If
    End Sub

End Class
