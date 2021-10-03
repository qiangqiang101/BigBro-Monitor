
Imports Newtonsoft.Json

Partial Class Api
    Inherits System.Web.UI.Page

    Public lic As String
    Public hwid As String
    Public name As String

    Private Sub Api_Load(sender As Object, e As EventArgs) Handles Me.Load
        lic = Request.QueryString("lic")
        hwid = Request.QueryString("hwid")
        name = Request.QueryString("name")

        Response.ContentType = "text/json"

        Try
            Using db As New DataClassesDataContext
                Dim licenses = db.TblLicenses.Where(Function(x) x.LicenseKey = lic)
                If licenses.Count = 0 Then
                    Response.Write(JsonConvert.SerializeObject(New ApiResp With {.Message = "License Key is not valid.", .Status = False}))
                Else
                    Dim license = licenses.Single(Function(x) x.LicenseKey = lic)
                    If license.Used Then
                        If license.HWID.Trim = hwid Then
                            Response.Write(JsonConvert.SerializeObject(New ApiResp With {.Message = "License Key check OK.", .Status = True}))
                        Else
                            Response.Write(JsonConvert.SerializeObject(New ApiResp With {.Message = "License Key is already in used.", .Status = False}))
                        End If
                    Else
                        With license
                            .ActivatedDate = Now
                            .DeviceName = name
                            .HWID = hwid
                            .LicenseKey = lic
                            .Used = True
                        End With
                        db.SubmitChanges()
                        Response.Write(JsonConvert.SerializeObject(New ApiResp With {.Message = "License Key has been successful activated.", .Status = True}))
                    End If
                End If
            End Using
        Catch ex As Exception
            Response.Write(JsonConvert.SerializeObject(New ApiResp With {.Message = "Something went wrong.", .Status = False}))
        End Try
    End Sub
End Class
