Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic

Public Module Helper

    Public dateFormat As String = "yyyy-MM-dd HH:mm:ss"
    Public logPath As String = HttpContext.Current.ApplicationInstance.Server.MapPath("~\App_Data\")

    '<Extension>
    'Public Sub JsMsgBox(page As Page, text As String)
    '    page.Response.Write("<script>alert('" & text & "');</script>")
    'End Sub

    ''' <summary>
    ''' And with a third argument, you can add an icon to your alert! There are 4 predefined ones: "warning", "error", "success" and "info".
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="texts"></param>
    <Extension>
    Public Sub swalBs(page As Page, ParamArray texts As String())
        Dim texts2 As New List(Of String)
        For Each txt In texts
            texts2.Add("'" & txt & "'")
        Next
        Dim result = String.Join(", ", texts2)
        page.ClientScript.RegisterStartupScript(page.GetType, "SweetAlert", "swal(" & result & ");", True)
    End Sub

    ''' <summary>
    ''' And with a third argument, you can add an icon to your alert! There are 4 predefined ones: "warning", "error", "success" and "info".
    ''' </summary>
    ''' <param name="page"></param>
    ''' <param name="redirect"></param>
    ''' <param name="title"></param>
    ''' <param name="text"></param>
    ''' <param name="type"></param>
    ''' <param name="showCancelButton"></param>
    ''' <param name="btnConfirmClass"></param>
    ''' <param name="btnConfirmText"></param>
    <Extension>
    Public Sub swalBsRedirect(page As Page, redirect As String, title As String, text As String, type As String, Optional showCancelButton As Boolean = False, Optional btnConfirmClass As String = "btn-primary", Optional btnConfirmText As String = "OK")
        Dim str = "swal({title: '" & title & "', text: '" & text & "', type: '" & type & "', showCancelButton: " & showCancelButton.ToString.ToLower & ", confirmButtonClass: '" & btnConfirmClass & "', confirmButtonText: '" & btnConfirmText & "'}, function() {window.location = '" & redirect & "';});"
        page.ClientScript.RegisterStartupScript(page.GetType, "SweetAlert", str, True)
    End Sub

    Public Function BoolToString(bool As Boolean) As String
        Return If(bool, "Enabled", "Disabled")
    End Function

    Public Function IsAdminLoginSuccess(username As String, password As String, page As Page) As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim user = db.TblUsers.Single(Function(x) x.UserName = username AndAlso x.Password = password)
                If user.Status Then
                    page.Session("userid") = user.UserID
                    page.Session("username") = user.UserName.Trim
                    page.Session("fullname") = user.FullName.Trim
                    page.Session("email") = user.Email.Trim
                    page.Session("role") = "Administrator"

                    Return True
                End If
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
        Return False
    End Function

    <Extension>
    Public Sub AddTableItem(table As Table, ParamArray items As Object())
        Dim row As New TableRow()
        For Each item In items
            If TypeOf item Is TableCell Then
                row.Cells.Add(item)
            Else
                row.Cells.Add(New TableCell() With {.Text = item})
            End If
        Next
        table.Rows.Add(row)
    End Sub

    Public Function RB(action As String, css As String, Optional button As String = "btn-primary", Optional tooltip As String = "") As String
        Return RoundButton(action, css, button, tooltip) & " "
    End Function

    Public Function RoundButton(action As String, css As String, Optional button As String = "btn-primary", Optional tooltip As String = "") As String
        Return String.Format("<a href={0}{1}{0} class={0}btn {2} btn-circle btn-sm{0} data-toggle={0}tooltip{0} title={0}{3}{0}><i class={0}{4}{0}></i></a>", """", action, button, tooltip, css)
    End Function

End Module

Public Module Logger

    Public Sub Log(ex As Exception)
        Log(ex.Message & ex.StackTrace)
    End Sub

    Public Sub Log(message As String)
        If Not Directory.Exists(logPath) Then Directory.CreateDirectory(logPath)
        File.AppendAllText(logPath & "\Log-" & Now.Month & "-" & Now.Day & "-" & Now.Year & ".log", Now.ToString(DateFormat) & ": " & message & vbNewLine)
    End Sub

End Module
