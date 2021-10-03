Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing.Design

Public Class ThemeConfig

    <Category("Theme Config")>
    Public Property Name As String = "Untitled Theme"
    <Category("Theme Config")>
    Public Property Tags As String()
    <Category("Theme Config")>
    Public Property Author As String = GetUserName()
    <Category("Theme Config")>
    Public Property Version As String = "1.0"
    <Category("Theme Config")>
    Public Property CustomPreview As Image
    <Category("Layout")>
    Public Property Size As Size = New Size(480, 320)
    <Category("Appearance")>
    Public Property BackgroundImage As Image = Nothing
    <Category("Appearance")>
    Public Property BackgroundColor As Color = Color.White
    <Category("Appearance")>
    Public Property TextColor As Color = Color.Red
    '<Category("Appearance")>
    'Public Property TransparencyKey As Color = Color.Fuchsia
    <Category("Behavior")>
    Public Property UpdateInterval As Integer = 3000

    Private _opa As Double = 1.0R
    <Category("Appearance"), Description("Range from 0.0 to 1.0.")>
    Public Property Opacity As Double
        Get
            Return _opa
        End Get
        Set(value As Double)
            If value > 1.0R Then value = 1.0R
            If value < 0R Then value = 0R
            _opa = value
        End Set
    End Property

End Class
