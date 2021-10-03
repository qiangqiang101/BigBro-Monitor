
Partial Class License
    Inherits System.Web.UI.Page

    Private Sub btnConfirmGen_ServerClick(sender As Object, e As EventArgs) Handles btnConfirmGen.ServerClick
        If txtNumbers.Text = Nothing Then
            swalBs("Oops!", "Numbers appears to be empty!", "error")
        Else
            Using db As New DataClassesDataContext
                For i As Integer = 0 To CInt(txtNumbers.Text) - 1
                    Dim key As String = Guid.NewGuid().ToString("N").ToUpper.Substring(0, 20)
                    Dim newLic As New TblLicense
                    With newLic
                        .LicenseKey = key
                        .CreatedDate = Now
                        .Used = False
                    End With
                    db.TblLicenses.InsertOnSubmit(newLic)
                Next
                db.SubmitChanges()

                swalBsRedirect("License.aspx", "Success", "License key successfully generate.", "success")
            End Using
        End If
    End Sub

    Private Sub License_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim role As String = HttpContext.Current.Session("role")

        If role = "Administrator" Then
            Using db As New DataClassesDataContext
                Dim licenses = db.TblLicenses.Where(Function(x) x.Used = False).OrderByDescending(Function(x) x.CreatedDate)
                For Each lic In licenses
                    dataTable.AddTableItem(lic.LicenseID.ToString("00000"), lic.CreatedDate.ToString(dateFormat), lic.LicenseKey.Trim, RB("Action.aspx?mode=deletekey&redirect=license&id=" & lic.LicenseID, "fas fa-trash", "btn-danger", "Remove"))
                Next
            End Using
        End If
    End Sub
End Class
