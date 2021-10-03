Imports System.ComponentModel
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Public Class Youtube
    Inherits Control
    'Inherits WebView2

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl
    Private WithEvents Webview2 As WebView2

#Region "Overrides"

    Private _parentName As String
    <Category("Behavior")>
    Public Property ParentName() As String
        Get
            Return _parentName
        End Get
        Set(value As String)
            If value = Nothing Then Exit Property
            Dim ctrl = myParentForm.Controls.Find(value, False).FirstOrDefault
            If ctrl IsNot Nothing Then
                _parentName = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleDescription() As String
        Get
            Return MyBase.AccessibleDescription
        End Get
        Set(value As String)
            MyBase.AccessibleDescription = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleName() As String
        Get
            Return MyBase.AccessibleName
        End Get
        Set(value As String)
            MyBase.AccessibleName = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleRole() As AccessibleRole
        Get
            Return MyBase.AccessibleRole
        End Get
        Set(value As AccessibleRole)
            MyBase.AccessibleRole = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImage() As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            MyBase.BackgroundImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImageLayout() As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(value As ImageLayout)
            MyBase.BackgroundImageLayout = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Cursor() As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            MyBase.Cursor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property UseWaitCursor() As Boolean
        Get
            Return MyBase.UseWaitCursor
        End Get
        Set(value As Boolean)
            MyBase.UseWaitCursor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property RightToLeft() As Boolean
        Get
            Return MyBase.RightToLeft
        End Get
        Set(value As Boolean)
            MyBase.RightToLeft = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImeMode() As ImeMode
        Get
            Return MyBase.ImeMode
        End Get
        Set(value As ImeMode)
            MyBase.ImeMode = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabStop() As Boolean
        Get
            Return MyBase.TabStop
        End Get
        Set(value As Boolean)
            MyBase.TabStop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Tag() As Object
        Get
            Return MyBase.Tag
        End Get
        Set(value As Object)
            MyBase.Tag = value
        End Set
    End Property

    <Browsable(True)>
    <Category("Design")>
    Public Overloads Property Name() As String
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
            MyBase.Name = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property CausesValidation() As Boolean
        Get
            Return MyBase.CausesValidation
        End Get
        Set(value As Boolean)
            MyBase.CausesValidation = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabIndex() As Integer
        Get
            Return MyBase.TabIndex
        End Get
        Set(value As Integer)
            MyBase.TabIndex = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads ReadOnly Property CoreWebView2() As CoreWebView2
        Get
            Return Webview2.CoreWebView2
        End Get
    End Property

    <Browsable(False)>
    Public Overloads Property DefaultBackgroundColor() As Color
        Get
            Return Webview2.DefaultBackgroundColor
        End Get
        Set(value As Color)
            Webview2.DefaultBackgroundColor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Source() As Uri
        Get
            Return Webview2.Source
        End Get
        Set(value As Uri)
            Webview2.Source = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ZoomFactor() As Double
        Get
            Return Webview2.ZoomFactor
        End Get
        Set(value As Double)
            Webview2.ZoomFactor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property MaximumSize() As Size
        Get
            Return MyBase.MaximumSize
        End Get
        Set(value As Size)
            MyBase.MaximumSize = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property MinimumSize() As Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(value As Size)
            MyBase.MinimumSize = value
        End Set
    End Property

    Public Overloads Property Enabled() As Boolean
        Get
            Return Webview2.Enabled
        End Get
        Set(value As Boolean)
            Webview2.Enabled = value
        End Set
    End Property

#End Region

    Private _sensor As eSensorType = eSensorType.None
    <Browsable(False)>
    Public Property Sensor() As eSensorType
        Get
            Return _sensor
        End Get
        Set(value As eSensorType)
            _sensor = value
        End Set
    End Property

    Private _youtubeId As String = "9TY_9BImp3Y"
    <Category("Behavior")>
    Public Property YoutubeID() As String
        Get
            Return _youtubeId
        End Get
        Set(value As String)
            _youtubeId = value
            If _play Then RunPage()
        End Set
    End Property

    Private _play As Boolean = False
    Public Property Play() As Boolean
        Get
            Return _play
        End Get
        Set(value As Boolean)
            _play = value
            If _play Then RunPage() Else StopPlayer()
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        BackColor = Color.Black
        Webview2 = New WebView2()
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub UpdateControl()
    End Sub

    Public Sub InitWebView()
        Controls.Add(Webview2)
        Webview2.Dock = DockStyle.Fill
    End Sub

    Public Sub RunPage()
        Try
            InitWebView()
            Source = New Uri($"https://www.youtube.com/embed/{_youtubeId}?rel=0&autoplay=1&mute=1&showinfo=0&controls=0&playlist={_youtubeId}&loop=1")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub

    Public Sub StopPlayer()
        Try
            Source = New Uri("about:blank")
            Controls.Remove(Webview2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub

    Private Sub Youtube_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles Webview2.NavigationCompleted
        Try
            CoreWebView2.ExecuteScriptAsync("javascript:(function() { document.getElementsByTagName('video')[0].play(); })()")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub
End Class
