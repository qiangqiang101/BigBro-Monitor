Public Class NSUserDefineItem

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private _ControlType As eControlType = eControlType.TextLabel
    Public Property ControlType As eControlType
        Get
            Return _ControlType
        End Get
        Set(value As eControlType)
            _ControlType = value
            Select Case _ControlType
                Case eControlType.ImageControl
                    btnBrowse.Visible = True
                    txtBox.Width -= 32
                Case Else
                    btnBrowse.Visible = False
            End Select
        End Set
    End Property

    Private _numeric As Boolean = False
    Public Property IsNumeric() As Boolean
        Get
            Return _numeric
        End Get
        Set(value As Boolean)
            _numeric = value
        End Set
    End Property

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If _ControlType = eControlType.ImageControl Then
            Dim ofd As New OpenFileDialog With {.Filter = "JPG File|*.jpg|JPEG File|*.jpeg|PNG File|*.png|BMP File|*.bmp|GIF File|*.gif", .Multiselect = False, .Title = "Select image file..."}
            Dim result As DialogResult = ofd.ShowDialog()
            If result = DialogResult.OK Then
                Using bitmap As Image = Image.FromFile(ofd.FileName)
                    txtBox.Text = bitmap.ImageToBase64
                End Using
            End If
        End If
    End Sub

    Private Sub txtBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBox.KeyPress
        If _numeric Then
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

End Class

Public Enum eControlType
    TextLabel
    ImageControl
    Youtube
End Enum
