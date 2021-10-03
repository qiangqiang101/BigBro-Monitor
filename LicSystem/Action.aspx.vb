
Partial Class Action
    Inherits System.Web.UI.Page

    Public mode As String = "cancel"
    Public redirect As String = "license"
    Public lid As String = "id"

    Private Sub Action_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        redirect = Request.QueryString("redirect")
        lid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "deleteuser"
                    Try
                        Using db As New DataClassesDataContext
                            Dim user = db.TblUsers.Single(Function(x) x.UserID = CInt(lid))
                            db.TblUsers.DeleteOnSubmit(user)
                            db.SubmitChanges()
                        End Using
                    Catch ex As Exception
                        swalBsRedirect(GetRedirect(Nothing), "Oops", "Something is wrong with this action.", "error")
                    End Try
                    swalBsRedirect(GetRedirect(Nothing), "Success", "This User is successfully delete.", "success")
                Case "deletekey"
                    Try
                        Using db As New DataClassesDataContext
                            Dim key = db.TblLicenses.Single(Function(x) x.LicenseID = CInt(lid))
                            db.TblLicenses.DeleteOnSubmit(key)
                            db.SubmitChanges()
                        End Using
                    Catch ex As Exception
                        swalBsRedirect(GetRedirect(Nothing), "Oops", "Something is wrong with this action.", "error")
                    End Try
                    swalBsRedirect(GetRedirect(Nothing), "Success", "This key is successfully delete.", "success")
                Case "revokekey"
                    Try
                        Using db As New DataClassesDataContext
                            Dim key = db.TblLicenses.Single(Function(x) x.LicenseID = CInt(lid))
                            With key
                                .ActivatedDate = Nothing
                                .DeviceName = Nothing
                                .HWID = Nothing
                                .Used = False
                            End With
                            db.SubmitChanges()
                        End Using
                    Catch ex As Exception
                        swalBsRedirect(GetRedirect(Nothing), "Oops", "Something is wrong with this action.", "error")
                    End Try
                    swalBsRedirect(GetRedirect(Nothing), "Success", "This key is successfully revoke.", "success")
            End Select
        End If
    End Sub

    Private Function GetRedirect(Optional param As String = Nothing) As String
        Select Case redirect
            Case "license"
                Return "License.aspx" & param
            Case "activated"
                Return "Activated.aspx" & param
            Case "user"
                Return "Users.aspx" & param
            Case Else
                Return "Default.aspx"
        End Select
    End Function

End Class
