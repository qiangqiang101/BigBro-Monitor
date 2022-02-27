Imports System.ComponentModel

Public Class frmMonitor2

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private html As String = "<style>
@import url(""https://fonts.googleapis.com/css?family=Roboto:400,400i,700"");
body{
  overflow-x: hidden;
  font-family: Roboto, sans-serif;
}

h1{
  background: rgba(0,0,0,0.5);
  padding: 10px;
}

.video-container{
  width: 100vw;
  height: 100vh;
}

 iframe {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 100vw;
  height: 100vh;
  transform: translate(-50%, -50%);
}

@media (min-aspect-ratio: 16/9) {
  .video-container iframe {
    height: 56.25vw;
  }
}
@media (max-aspect-ratio: 16/9) {
  .video-container iframe {
    width: 177.78vh;
  }
}

body {
  overflow: hidden; /* Hide scrollbars */
}
</style>

<div class=""video-container"">
  <iframe src=""https://www.youtube.com/embed/%YTID%?controls=0&autoplay=1&mute=1&playlist=%YTID%&loop=1"" scrolling=""no""></iframe>
</div>"

    Private html2 As String = "<style>
@import url(""https://fonts.googleapis.com/css?family=Roboto:400,400i,700"");
body{
  overflow-x: hidden;
  font-family: Roboto, sans-serif;
}

h1{
  background: rgba(0,0,0,0.5);
  padding: 10px;
}

.video-container{
  width: 100vw;
  height: 100vh;
}

 iframe {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 100vw;
  height: 100vh;
  transform: translate(-50%, -50%);
}

@media (min-aspect-ratio: 16/9) {
  .video-container iframe {
    height: 56.25vw;
  }
}
@media (max-aspect-ratio: 16/9) {
  .video-container iframe {
    width: 177.78vh;
  }
}

body {
  overflow: hidden; /* Hide scrollbars */
}
</style>

<div class=""video-container"">
  <iframe src=""https://www.youtube.com/embed?listType=playlist&list=%YTID%&controls=0&autoplay=1&mute=1&loop=1"" scrolling=""no""></iframe>
</div>"

    Private Sub frmMonitor2_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Try
            Dim newUserSettings As New UserSettingData(UserSettingFile)
            With newUserSettings
                .CurrentTheme = UserSettings.CurrentTheme
                .AutoStart = UserSettings.AutoStart
                .Location = UserSettings.Location
                .NetworkAdapterIndex = UserSettings.NetworkAdapterIndex
                .EnableBroadcast = UserSettings.EnableBroadcast
                .BroadcastPort = UserSettings.BroadcastPort
                .State = UserSettings.State
                .Town = UserSettings.Town
                .TopMost = UserSettings.TopMost
                .LicenseKey = UserSettings.LicenseKey
                .Email = UserSettings.Email
                .HWID = UserSettings.HWID
                .Language = UserSettings.Language
                .AudioEffectHighQuality = UserSettings.AudioEffectHighQuality
                .RgbEffectHighQuality = UserSettings.RgbEffectHighQuality
                .SecondScreen = UserSettings.SecondScreen
                .SecondScreenYT = UserSettings.SecondScreenYT
                .SecondScreenLocation = Location
                .SecondScreenSize = UserSettings.SecondScreenSize
                .SaveSilent()
            End With
            UserSettings = New UserSettingData(UserSettingFile).Instance
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pMove_MouseDown(sender As Object, e As MouseEventArgs) Handles pMove.MouseDown
        If e.Button = MouseButtons.Right Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub pMove_MouseUp(sender As Object, e As MouseEventArgs) Handles pMove.MouseUp
        If e.Button = MouseButtons.Right Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub pMove_MouseMove(sender As Object, e As MouseEventArgs) Handles pMove.MouseMove
        If IsFormBeingDragged Then
            Dim temp As New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)

            Me.Location = temp
            temp = Nothing

            CorrectBounds(Me, Screen.FromControl(Me).Bounds)
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Left Then
            Location = New Point(Location.X - 1, Location.Y)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Up Then
            Location = New Point(Location.X, Location.Y - 1)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Right Then
            Location = New Point(Location.X + 1, Location.Y)
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.Down Then
            Location = New Point(Location.X, Location.Y + 1)
        End If
    End Sub

    Private Async Sub frmMonitor2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Location = UserSettings.SecondScreenLocation
        TopMost = UserSettings.TopMost
        Size = UserSettings.SecondScreenSize

        Await ytWebView.EnsureCoreWebView2Async()
        Dim ytid As String = UserSettings.SecondScreenYT
        If ytid.Length > 20 Then
            ytWebView.NavigateToString(html2.Replace("%YTID%", ytid))
        Else
            ytWebView.NavigateToString(html.Replace("%YTID%", ytid))
        End If

    End Sub

    Public Sub StopPlayer()
        Try
            ytWebView.Source = New Uri("about:blank")
            Controls.Remove(ytWebView)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Logger.Log(ex)
        End Try
    End Sub

    Private Sub frmMonitor2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        StopPlayer()
    End Sub

End Class