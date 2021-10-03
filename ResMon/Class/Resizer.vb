'-------------------------------------------------------------------------------
' Resizer
' This class is used to dynamically resize and reposition all controls on a form.
' Container controls are processed recursively so that all controls on the form
' are handled.
'
' Usage:
'  Resizing functionality requires only three lines of code on a form:
'
'  1. Create a form-level reference to the Resize class:
'     Dim myResizer as Resizer
'
'  2. In the Form_Load event, call the  Resizer class FIndAllControls method:
'     myResizer.FindAllControls(Me)
'
'  3. In the Form_Resize event, call the  Resizer class ResizeAllControls method:
'     myResizer.ResizeAllControls(Me)
'
'-------------------------------------------------------------------------------
Public Class Resizer

    '----------------------------------------------------------
    ' ControlInfo
    ' Structure of original state of all processed controls
    '----------------------------------------------------------
    Private Structure ControlInfo
        Public name As String
        Public left As Integer
        Public top As Integer
        Public originalHeight As Integer
        Public originalWidth As Integer
        Public originalFontSize As Single
    End Structure

    Public originalHeight As Integer = -1
    Public originalWidth As Integer = -1
    '-------------------------------------------------------------------------
    ' ctrlDict
    ' Dictionary of (control name, control info) for all processed controls
    '-------------------------------------------------------------------------
    Private ctrlDict As Dictionary(Of String, ControlInfo) = New Dictionary(Of String, ControlInfo)

    '----------------------------------------------------------------------------------------
    ' FindAllControls
    ' Recursive function to process all controls contained in the initially passed
    ' control container and store it in the Control dictionary
    '----------------------------------------------------------------------------------------
    Public Sub FindAllControls(thisCtrl As Control)
        If originalHeight = -1 Then
            originalHeight = thisCtrl.Height
        End If
        If originalWidth = -1 Then
            originalWidth = thisCtrl.Width
        End If
        For Each ctl As Control In thisCtrl.Controls
            If Not ctrlDict.ContainsKey(ctl.Name) Then
                Try
                    Dim c As New ControlInfo
                    c.name = ctl.Name
                    c.top = ctl.Top
                    c.left = ctl.Left
                    c.originalFontSize = ctl.Font.Size
                    c.originalHeight = ctl.Height
                    c.originalWidth = ctl.Width
                    ctrlDict.Add(c.name, c)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                    MsgBox(ex.Message)
                    Logger.Log(ex)
                End Try
            End If
            If ctl.Controls.Count > 0 Then
                FindAllControls(ctl)
            End If
        Next
    End Sub

    '----------------------------------------------------------------------------------------
    ' ResizeAllControls
    ' Recursive function to resize and reposition all controls contained in the Control
    ' dictionary
    '----------------------------------------------------------------------------------------
    Public Sub ResizeAllControls(thisCtrl As Control, FormWidth As Integer, FormHeight As Integer)
        If originalHeight = -1 Or originalWidth = -1 Then
            Exit Sub
        End If
        Dim currentHeightFactor As Double = FormHeight / originalHeight
        Dim currentWidthFactor As Double = FormWidth / originalWidth
        For Each ctl As Control In thisCtrl.Controls
            Try
                Dim c As New ControlInfo
                Dim ret As Boolean = False
                Try
                    ret = ctrlDict.TryGetValue(ctl.Name, c)
                    If (ret) Then
                        '-- Position
                        ctl.Top = Int(c.top * currentHeightFactor)
                        ctl.Left = Int(c.left * currentWidthFactor)
                        ctl.Width = Int(c.originalWidth * currentWidthFactor)
                        ctl.Height = Int(c.originalHeight * currentHeightFactor)
                        '-- Font
                        Dim f As Font = ctl.Font
                        Dim fratio As Single = (currentHeightFactor + currentWidthFactor) / 2
                        ctl.Font = New Font(f.FontFamily, c.originalFontSize * fratio, f.Style)
                    End If
                Catch
                End Try
            Catch ex As Exception
            End Try
            If ctl.Controls.Count > 0 Then
                ResizeAllControls(ctl, FormWidth, FormHeight)
            End If
        Next
    End Sub


End Class