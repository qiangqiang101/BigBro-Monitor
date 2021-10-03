
Partial Class Users
    Inherits System.Web.UI.Page

    Dim uid As String = Nothing

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles Me.Load
        uid = Request.QueryString("id")

        If Not IsPostBack Then
            Using db As New DataClassesDataContext
                Dim users = db.TblUsers.OrderByDescending(Function(x) x.UserID)
                For Each u As TblUser In users
                    dataTable.AddTableItem(u.UserID.ToString("00000"), u.UserName.Trim, u.FullName.Trim, u.CreatedDate.ToString(dateFormat), "Administrator", BoolToString(u.Status),
                                           RB("Users.aspx?id=" & u.UserID, "fas fa-edit", tooltip:="Edit") & RB("Action.aspx?mode=deleteuser&redirect=user&id=" & u.UserID, "fas fa-trash", "btn-danger", "Delete"))
                Next
            End Using

            If Not uid = Nothing Then
                Using db As New DataClassesDataContext
                    Dim user = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                    txtUserNameE.Text = user.UserName.Trim
                    txtPasswordE.Text = user.Password.Trim
                    txtEmailE.Text = user.Email.Trim
                    txtFullNameE.Text = user.FullName.Trim
                    cmbEnableE.SelectedValue = user.Status
                    ClientScript.RegisterStartupScript(Me.GetType, "Pop", "openModal()", True)
                End Using
            End If
        End If
    End Sub

    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        Try
            Using db As New DataClassesDataContext
                Dim user As New TblUser
                With user
                    .UserName = txtUserName.Text.Trim
                    .Password = txtPassword.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .Status = CBool(cmbEnable.SelectedValue)
                    .CreatedDate = Now
                    .Email = txtEmail.Text.Trim
                End With
                db.TblUsers.InsertOnSubmit(user)
                db.SubmitChanges()
            End Using
            swalBsRedirect("Users.aspx", "Success", "New User added successfully.", "success")
        Catch ex As Exception
            swalBsRedirect("Users.aspx", "Error", "Unable to add new user.", "error")
        End Try
    End Sub

    Private Sub btnSubmitE_ServerClick(sender As Object, e As EventArgs) Handles btnSubmitE.ServerClick
        Try
            Using db As New DataClassesDataContext
                Dim user = db.TblUsers.Single(Function(x) x.UserID = CInt(uid))
                With user
                    .UserName = txtUserNameE.Text.Trim
                    .Password = txtPasswordE.Text.Trim
                    .FullName = txtFullNameE.Text.Trim
                    .Status = CBool(cmbEnableE.SelectedValue)
                    .Email = txtEmailE.Text.Trim
                End With
                db.SubmitChanges()
            End Using
            swalBsRedirect("Users.aspx", "Success", "User successfully update.", "success")
        Catch ex As Exception
            swalBsRedirect("Users.aspx", "Error", "Unable to edit user.", "error")
        End Try
    End Sub
End Class
