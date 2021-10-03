Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class FancyStringEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function

    Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        Dim svc = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

        If svc IsNot Nothing Then

            Using frm = New Form With {
            .Text = "Script"
        }

                Using txt = New RichTextBox With {
                .Text = CStr(value),
                .Dock = DockStyle.Fill,
                .Multiline = True
            }

                    Using ok = New Button With {
                    .Text = "OK",
                    .Dock = DockStyle.Bottom
                }
                        frm.Controls.Add(txt)
                        frm.Controls.Add(ok)
                        frm.AcceptButton = ok
                        ok.DialogResult = DialogResult.OK

                        If svc.ShowDialog(frm) = DialogResult.OK Then
                            value = txt.Text
                        End If
                    End Using
                End Using
            End Using
        End If

        Return value
    End Function

End Class
