
Partial Class Activated
    Inherits System.Web.UI.Page

    Private Sub Activated_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim licenses = db.TblLicenses.Where(Function(x) x.Used = True).OrderByDescending(Function(x) x.ActivatedDate)
            For Each lic In licenses
                dataTable.AddTableItem(lic.LicenseID.ToString("00000"), lic.ActivatedDate.Value.ToString(dateFormat), lic.LicenseKey.Trim, lic.HWID.Trim, lic.DeviceName.Trim,
                                       RB("Action.aspx?mode=deletekey&redirect=license&id=" & lic.LicenseID, "fas fa-trash", "btn-danger", "Remove") &
                                       RB("Action.aspx?mode=revokekey&redirect=license&id=" & lic.LicenseID, "fas fa-sync-alt", "btn-success", "Remove"))
            Next
        End Using
    End Sub
End Class
