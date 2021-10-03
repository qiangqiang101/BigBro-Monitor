Imports System.ComponentModel
Imports System.Drawing.Imaging

<Serializable>
Public Class WeatherWidget
    Inherits Control

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

    Private WithEvents timer As Timers.Timer
    Private wi As WeatherInfo
    Private lastUpdate As Date

    Private Function avgtemp() As Integer
        Return (wi.MinTemperature + wi.MaxTemperature) / 2
    End Function

#Region "Overrides"

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
    Public Overloads Property AllowDrop() As Boolean
        Get
            Return MyBase.AllowDrop
        End Get
        Set(value As Boolean)
            MyBase.AllowDrop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return MyBase.ContextMenuStrip
        End Get
        Set(value As ContextMenuStrip)
            MyBase.ContextMenuStrip = value
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

#End Region

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

    Private _style As WeatherStyle = WeatherStyle.Minimum
    <Category("Appearance")>
    Public Property WeatherStyle() As WeatherStyle
        Get
            Return _style
        End Get
        Set(value As WeatherStyle)
            _style = value
            Invalidate()
        End Set
    End Property

    Private _icon As IconStyle = IconStyle.Style1
    <Category("Appearance")>
    Public Property IconStyle() As IconStyle
        Get
            Return _icon
        End Get
        Set(value As IconStyle)
            _icon = value
        End Set
    End Property

    Private Function GetWeatherImage(sign As String, time As String) As Image
        Select Case sign
            Case "No Rain"
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_sun
                            Case IconStyle.Style2
                                Return My.Resources.kk_sun_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon
                            Case IconStyle.Style2
                                Return My.Resources.kk_moon_512
                        End Select
                End Select
            Case "Thunderstorms"
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_NA_lighting
                            Case IconStyle.Style2
                                Return My.Resources.kk_thunderstorm_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon_lighting
                            Case IconStyle.Style2
                                Return My.Resources.kk_thunderstorm_512
                        End Select
                End Select
            Case "Rain", "Heavy Rain"
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_NA_rain
                            Case IconStyle.Style2
                                Return My.Resources.kk_thunderstorm_rain_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon_rain
                            Case IconStyle.Style2
                                Return My.Resources.kk_cloud_moon_rain_512
                        End Select
                End Select
            Case "Isolated thunderstorms"
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_sun_lighting
                            Case IconStyle.Style2
                                Return My.Resources.kk_thunder_wind_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon_lighting
                            Case IconStyle.Style2
                                Return My.Resources.kk_thunder_wind_512
                        End Select
                End Select
            Case "Isolated rain"
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_sun_rain
                            Case IconStyle.Style2
                                Return My.Resources.kk_wind_rain_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon_rain
                            Case IconStyle.Style2
                                Return My.Resources.kk_wind_rain_512
                        End Select
                End Select
            Case Else
                Select Case time
                    Case "Morning", "Afternoon"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_NA_clouds
                            Case IconStyle.Style2
                                Return My.Resources.kk_cloudy_512
                        End Select
                    Case "Night"
                        Select Case _icon
                            Case IconStyle.Style1
                                Return My.Resources.cc_moon_clouds
                            Case IconStyle.Style2
                                Return My.Resources.kk_cloud_moon_512
                        End Select
                End Select
        End Select
        Return My.Resources.Blank
    End Function

    Private Sub RemapImage(g As Graphics, image As Image, oldColor As Color, newColor As Color, rectangle As Rectangle)
        Dim attributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim colorMap As New ColorMap

        colorMap.OldColor = oldColor
        colorMap.NewColor = newColor
        Dim remapTable As ColorMap() = {colorMap}

        attributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap)

        g.DrawImage(image, rectangle, 0, 0, width, height, GraphicsUnit.Pixel, attributes)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim formGraphics As Graphics = e.Graphics
        formGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        formGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Dim cr = ClientRectangle
        Select Case _icon
            Case IconStyle.Style1
                Select Case _style
                    Case WeatherStyle.Wide
                        Dim leftRect As New Rectangle(0, 0, cr.Width / 2, cr.Width / 2)
                        Dim iconRect As New Rectangle(0, -15, leftRect.Width / 2, leftRect.Width / 2)
                        formGraphics.DrawImage(GetWeatherImage(wi.SignificantWeather, GetGreetings), iconRect)
                        Dim textSize As Size = TextRenderer.MeasureText($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font)
                        Dim sFormat As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        Dim sFormat2 As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                        Dim tempRect1h As New Rectangle(iconRect.Width, -15, leftRect.Width / 2, (leftRect.Width / 2) - textSize.Height)
                        Dim weatherRect As New Rectangle(0, iconRect.Height - textSize.Height - 15, leftRect.Width, textSize.Height)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, tempRect1h, sFormat)
                            formGraphics.DrawString($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font, sbrush, weatherRect, sFormat)
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, weatherRect)
                            formGraphics.DrawString($"{UserSettings.Town}, {UserSettings.State}", Font, sbrush, leftRect)
                        End Using
                        Dim oHeight As Integer = iconRect.Height + weatherRect.Height - 30
                        Dim rightRect As New Rectangle(leftRect.X + leftRect.Width, 0, cr.Width / 2, cr.Width / 2)
                        Dim morRect As New Rectangle(rightRect.X, 0, rightRect.Width / 3, oHeight)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim morTextSize As Size = TextRenderer.MeasureText("Morning", Font)
                            Dim morTextRect As New Rectangle(morRect.X, morRect.Y, morRect.Width, morTextSize.Height)
                            Dim morTextRect2 As New Rectangle(morRect.X, morRect.Height - morTextSize.Height, morRect.Width, morTextSize.Height)
                            formGraphics.DrawString("Morning", Font, sbrush, morTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.MorningWeather, "Morning"), New Rectangle(morRect.X, morRect.Y + (morRect.Width / 4), morRect.Width, morRect.Width))
                            formGraphics.DrawString(wi.MorningWeather, Font, sbrush, morTextRect2, sFormat2)
                        End Using
                        Dim aftRect As New Rectangle(rightRect.X + morRect.Width, 0, rightRect.Width / 3, oHeight)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim aftTextSize As Size = TextRenderer.MeasureText("Afternoon", Font)
                            Dim aftTextRect As New Rectangle(aftRect.X, aftRect.Y, aftRect.Width, aftTextSize.Height)
                            Dim aftTextRect2 As New Rectangle(aftRect.X, aftRect.Height - aftTextSize.Height, morRect.Width, aftTextSize.Height)
                            formGraphics.DrawString("Afternoon", Font, sbrush, aftTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.AfternoonWeather, "Afternoon"), New Rectangle(aftRect.X, aftRect.Y + (aftRect.Width / 4), aftRect.Width, aftRect.Width))
                            formGraphics.DrawString(wi.AfternoonWeather, Font, sbrush, aftTextRect2, sFormat2)
                        End Using
                        Dim nigRect As New Rectangle(rightRect.X + (morRect.Width * 2), 0, rightRect.Width / 3, oHeight)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim nigTextSize As Size = TextRenderer.MeasureText("Night", Font)
                            Dim nigTextRect As New Rectangle(nigRect.X, nigRect.Y, nigRect.Width, nigTextSize.Height)
                            Dim nigTextRect2 As New Rectangle(nigRect.X, nigRect.Height - nigTextSize.Height, morRect.Width, nigTextSize.Height)
                            formGraphics.DrawString("Night", Font, sbrush, nigTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.NightWeather, "Night"), New Rectangle(nigRect.X, nigRect.Y + (nigRect.Width / 4), nigRect.Width, nigRect.Width))
                            formGraphics.DrawString(wi.NightWeather, Font, sbrush, nigTextRect2, sFormat2)
                        End Using
                    Case WeatherStyle.Full
                        Dim iconRect As New Rectangle(0, 0, cr.Width / 2, cr.Width / 2)
                        formGraphics.DrawImage(GetWeatherImage(wi.SignificantWeather, GetGreetings), iconRect)
                        Dim textSize As Size = TextRenderer.MeasureText($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font)
                        Dim sFormat As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        Dim sFormat2 As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                        Dim tempRect1h As New Rectangle(iconRect.Width, 0, cr.Width / 2, (cr.Width / 2) - textSize.Height)
                        Dim weatherRect As New Rectangle(0, iconRect.Height - textSize.Height, cr.Width, textSize.Height)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, tempRect1h, sFormat)
                            formGraphics.DrawString($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font, sbrush, weatherRect, sFormat)
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, weatherRect)
                            formGraphics.DrawString($"{vbNewLine}{UserSettings.Town}, {UserSettings.State}", Font, sbrush, cr)
                        End Using
                        Dim morRect As New Rectangle(0, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim morTextSize As Size = TextRenderer.MeasureText("Morning", Font)
                            Dim morTextRect As New Rectangle(morRect.X, morRect.Y, morRect.Width, morTextSize.Height)
                            formGraphics.DrawString("Morning", Font, sbrush, morTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.MorningWeather, "Morning"), morRect)
                        End Using
                        Dim aftRect As New Rectangle(morRect.Width, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim aftTextSize As Size = TextRenderer.MeasureText("Afternoon", Font)
                            Dim aftTextRect As New Rectangle(aftRect.X, aftRect.Y, aftRect.Width, aftTextSize.Height)
                            formGraphics.DrawString("Afternoon", Font, sbrush, aftTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.AfternoonWeather, "Afternoon"), aftRect)
                        End Using
                        Dim nigRect As New Rectangle(morRect.Width * 2, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim nigTextSize As Size = TextRenderer.MeasureText("Night", Font)
                            Dim nigTextRect As New Rectangle(nigRect.X, nigRect.Y, nigRect.Width, nigTextSize.Height)
                            formGraphics.DrawString("Night", Font, sbrush, nigTextRect, sFormat2)
                            formGraphics.DrawImage(GetWeatherImage(wi.NightWeather, "Night"), nigRect)
                        End Using
                    Case WeatherStyle.Medium
                        Dim iconRect As New Rectangle(0, 0, cr.Width / 2, cr.Width / 2)
                        formGraphics.DrawImage(GetWeatherImage(wi.SignificantWeather, GetGreetings), iconRect)
                        Dim textSize As Size = TextRenderer.MeasureText($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font)
                        Dim sFormat As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        Dim sFormat2 As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                        Dim tempRect1h As New Rectangle(iconRect.Width, 0, cr.Width / 2, (cr.Width / 2) - textSize.Height)
                        Dim weatherRect As New Rectangle(0, iconRect.Height - textSize.Height, cr.Width, textSize.Height)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, tempRect1h, sFormat)
                            formGraphics.DrawString($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font, sbrush, weatherRect, sFormat)
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, weatherRect)
                            formGraphics.DrawString($"{vbNewLine}{UserSettings.Town}, {UserSettings.State}", Font, sbrush, cr)
                        End Using
                    Case WeatherStyle.Minimum
                        formGraphics.DrawImage(GetWeatherImage(wi.SignificantWeather, GetGreetings), cr)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            Dim townSize As Size = TextRenderer.MeasureText(UserSettings.Town, Font)
                            formGraphics.DrawString($"{UserSettings.Town}", Font, sbrush, New Point(0, 0))
                            Dim tempSize As Size = TextRenderer.MeasureText($"{avgtemp()}°", tempFont)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, New Point(0, townSize.Height))
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, New Point(0, Height - (townSize.Height * 2)))
                            formGraphics.DrawString($"L: {wi.MinTemperature}°C H: {wi.MaxTemperature}°C", Font, sbrush, New Point(0, Height - townSize.Height))
                        End Using
                    Case WeatherStyle.TextOnly
                        Using sbrush As New SolidBrush(ForeColor)
                            formGraphics.DrawString($"{wi.SignificantWeather} {avgtemp()}°", Font, sbrush, New Point(0F, 0F))
                        End Using
                End Select
            Case IconStyle.Style2
                Select Case _style
                    Case WeatherStyle.Full
                        Dim iconRect As New Rectangle(0, 0, cr.Width / 2, cr.Width / 2)
                        Dim smolIconRect As New Rectangle(iconRect.Width / 4, iconRect.Height / 4, iconRect.Width / 2, iconRect.Height / 2)
                        RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, GetGreetings), Color.Black, ForeColor, smolIconRect)
                        Dim textSize As Size = TextRenderer.MeasureText($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font)
                        Dim sFormat As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        Dim sFormat2 As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                        Dim tempRect1h As New Rectangle(iconRect.Width, 0, cr.Width / 2, (cr.Width / 2) - textSize.Height)
                        Dim weatherRect As New Rectangle(0, iconRect.Height - textSize.Height, cr.Width, textSize.Height)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, tempRect1h, sFormat)
                            formGraphics.DrawString($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font, sbrush, weatherRect, sFormat)
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, weatherRect)
                            formGraphics.DrawString($"{UserSettings.Town}, {UserSettings.State}", Font, sbrush, cr)
                        End Using
                        Dim morRect As New Rectangle(0, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim morTextSize As Size = TextRenderer.MeasureText("Morning", Font)
                            Dim morTextRect As New Rectangle(morRect.X, morRect.Y, morRect.Width, morTextSize.Height)
                            formGraphics.DrawString("Morning", Font, sbrush, morTextRect, sFormat2)
                            Dim sir As New Rectangle(morRect.X + (morRect.Width / 4), morRect.Y + (morRect.Height / 4), morRect.Width / 2, morRect.Height / 2)
                            RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, "Morning"), Color.Black, ForeColor, sir)
                        End Using
                        Dim aftRect As New Rectangle(morRect.Width, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim aftTextSize As Size = TextRenderer.MeasureText("Afternoon", Font)
                            Dim aftTextRect As New Rectangle(aftRect.X, aftRect.Y, aftRect.Width, aftTextSize.Height)
                            formGraphics.DrawString("Afternoon", Font, sbrush, aftTextRect, sFormat2)
                            Dim sir As New Rectangle(aftRect.X + (aftRect.Width / 4), aftRect.Y + (aftRect.Height / 4), aftRect.Width / 2, aftRect.Height / 2)
                            RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, "Afternoon"), Color.Black, ForeColor, sir)
                        End Using
                        Dim nigRect As New Rectangle(morRect.Width * 2, weatherRect.Y + weatherRect.Height, cr.Width / 3, cr.Width / 3)
                        Using sbrush As New SolidBrush(ForeColor)
                            Dim nigTextSize As Size = TextRenderer.MeasureText("Night", Font)
                            Dim nigTextRect As New Rectangle(nigRect.X, nigRect.Y, nigRect.Width, nigTextSize.Height)
                            formGraphics.DrawString("Night", Font, sbrush, nigTextRect, sFormat2)
                            Dim sir As New Rectangle(nigRect.X + (nigRect.Width / 4), nigRect.Y + (nigRect.Height / 4), nigRect.Width / 2, nigRect.Height / 2)
                            RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, "Night"), Color.Black, ForeColor, sir)
                        End Using
                    Case WeatherStyle.Medium
                        Dim iconRect As New Rectangle(0, 0, cr.Width / 2, cr.Width / 2)
                        Dim smolIconRect As New Rectangle(iconRect.Width / 4, iconRect.Height / 4, iconRect.Width / 2, iconRect.Height / 2)
                        RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, GetGreetings), Color.Black, ForeColor, smolIconRect)
                        Dim textSize As Size = TextRenderer.MeasureText($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font)
                        Dim sFormat As New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                        Dim sFormat2 As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                        Dim tempRect1h As New Rectangle(iconRect.Width, 0, cr.Width / 2, (cr.Width / 2) - textSize.Height)
                        Dim weatherRect As New Rectangle(0, iconRect.Height - textSize.Height, cr.Width, textSize.Height)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, tempRect1h, sFormat)
                            formGraphics.DrawString($"{wi.MinTemperature}°C - {wi.MaxTemperature}°C", Font, sbrush, weatherRect, sFormat)
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, weatherRect)
                            formGraphics.DrawString($"{UserSettings.Town}, {UserSettings.State}", Font, sbrush, cr)
                        End Using
                    Case WeatherStyle.Minimum
                        Dim smolIconRect As New Rectangle(cr.Width / 4, cr.Height / 4, cr.Width / 2, cr.Height / 2)
                        RemapImage(formGraphics, GetWeatherImage(wi.SignificantWeather, GetGreetings), Color.Black, ForeColor, smolIconRect)
                        Using sbrush As New SolidBrush(ForeColor), tempFont As New Font(Font.Name, Font.Size * 3, FontStyle.Bold)
                            Dim townSize As Size = TextRenderer.MeasureText(UserSettings.Town, Font)
                            formGraphics.DrawString($"{UserSettings.Town}", Font, sbrush, New Point(0, 0))
                            Dim tempSize As Size = TextRenderer.MeasureText($"{avgtemp()}°", tempFont)
                            formGraphics.DrawString($"{avgtemp()}°", tempFont, sbrush, New Point(0, townSize.Height))
                            formGraphics.DrawString(wi.SignificantWeather, Font, sbrush, New Point(0, Height - (townSize.Height * 2)))
                            formGraphics.DrawString($"L: {wi.MinTemperature}°C H: {wi.MaxTemperature}°C", Font, sbrush, New Point(0, Height - townSize.Height))
                        End Using
                    Case WeatherStyle.TextOnly
                        Using sbrush As New SolidBrush(ForeColor)
                            formGraphics.DrawString($"{wi.SignificantWeather} {avgtemp()}°", Font, sbrush, New Point(0F, 0F))
                        End Using
                End Select
        End Select



    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        Invalidate()
    End Sub

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
        DoubleBuffered = True
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
        wi = Weather(Towns.Find(Function(x) x.Name = UserSettings.Town).ID)
        timer = New Timers.Timer(600000)
        timer.Start()
        lastUpdate = Now
    End Sub

    Private Sub timer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles timer.Elapsed
        wi = Weather(Towns.Find(Function(x) x.Name = UserSettings.Town).ID)
        lastUpdate = Now
        Invalidate()
    End Sub

    Public Sub UpdateControl()

    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)

        timer.Stop()
    End Sub

End Class

Public Enum WeatherStyle
    TextOnly
    Minimum
    Medium
    Full
    Wide
End Enum

Public Enum IconStyle
    Style1
    Style2
End Enum
