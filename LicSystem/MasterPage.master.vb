
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = "Zettabyte Technology License System Back Office"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim role As String = HttpContext.Current.Session("role")
        Dim userid As String = HttpContext.Current.Session("userid")

        If Not Page.IsPostBack Then
            Select Case role
                Case "Administrator"
                    navbaruser.InnerText = Session("fullname")
                Case Else
                    Page.swalBsRedirect("Default.aspx", "Hello", "Please Login to continue.", "warning")
            End Select
        End If
    End Sub
End Class

