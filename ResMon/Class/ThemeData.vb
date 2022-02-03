Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security.Cryptography
Imports System.Xml.Serialization
Imports AudioSpectrum

<Serializable>
Public Structure ThemeData

    Public ReadOnly Property Instance As ThemeData
        Get
            Return ReadFromFile()
        End Get
    End Property

    Public ReadOnly Property ThemeInstance As ThemeData
        Get
            Return ReadFromBinFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public Name As String
    Public Tags As String()
    Public Author As String
    Public Version As String
    Public Size As Size
    Public BackgroundImage As String
    Public BackgroundColor As MyColor
    Public TextColor As MyColor
    'Public TransparencyKey As MyColor
    Public TextLabels As List(Of MyTextLabel)
    Public CustomTexts As List(Of MyCustomText)
    Public ImageBoxes As List(Of MyImageControl)
    Public StatusBars As List(Of MyStatusBar)
    Public CircularSBs As List(Of MyCircularStatusBar)
    Public PlotCharts As List(Of MyPlotChart)
    Public DetailSensors As List(Of MyDetailSensor)
    Public YoutubeVideos As List(Of MyYoutube)
    Public WeatherWidgets As List(Of MyWeatherWidget)
    Public AudioVisualizers As List(Of MyAudioVisualizer)
    Public Snapshot As String
    Public UpdateInterval As Integer
    Public CustomPreview As String
    Public Opacity As Double
    Public RGBBackground As Boolean
    Public RGBTransform As RGBTransform
    Public RGBPattern As RGBPattern

    Public Sub New(filename As String)
        Me.FileName = filename
    End Sub

    Public Sub Build()
        Using fs As FileStream = File.Create(FileName)
            Dim formatter As New BinaryFormatter()
            formatter.Serialize(fs, Me)
        End Using

        MsgBox($"Theme file successfully build.", MsgBoxStyle.Information, "Build")
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(ThemeData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()

        MsgBox($"Theme file successfully saved.", MsgBoxStyle.Information, "Save")
    End Sub

    Public Function ReadFromBinFile() As ThemeData
        If Not File.Exists(FileName) Then
            Return New ThemeData(FileName)
        End If

        Try
            Using fs As FileStream = File.OpenRead(FileName)
                Dim formatter As New BinaryFormatter
                Dim instance = CType(formatter.Deserialize(fs), ThemeData)
                Return instance
            End Using
        Catch ex As Exception
            Return New ThemeData(FileName)
        End Try
    End Function

    Public Function ReadFromFile() As ThemeData
        If Not File.Exists(FileName) Then
            Return New ThemeData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(ThemeData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), ThemeData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New ThemeData(FileName)
        End Try
    End Function

End Structure

<Serializable>
Public Structure MyTextLabel

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public BeforeText As String
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public BorderStyle As BorderStyle
    Public FlatStyle As FlatStyle
    Public Image As String
    Public ImageAlign As ContentAlignment
    Public TextAlign As ContentAlignment
    Public UseMnemonic As Boolean
    Public AutoEllipsis As Boolean
    Public UseCompatibleTextRendering As Boolean
    Public AutoSize As Boolean
    Public AllowUserEdit As Boolean
    Public Sensor As eSensorType
    Public SensorParam As String
    Public ParentName As String

    Public Sub New(control As TextLabel)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        BeforeText = control.BeforeText
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        BorderStyle = control.BorderStyle
        FlatStyle = control.FlatStyle
        Image = control.Image.ImageToBase64
        ImageAlign = control.ImageAlign
        TextAlign = control.TextAlign
        UseMnemonic = control.UseMnemonic
        AutoEllipsis = control.AutoEllipsis
        UseCompatibleTextRendering = control.UseCompatibleTextRendering
        AutoSize = control.AutoSize
        AllowUserEdit = control.AllowUserEdit
        Sensor = control.Sensor
        SensorParam = control.SensorParam
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyCustomText

    Public BackColor As MyColor
    Public Font As MyFont
    Public RightToLeft As Boolean
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public BorderStyle As BorderStyle
    Public FlatStyle As FlatStyle
    Public Image As String
    Public ImageAlign As ContentAlignment
    Public UseMnemonic As Boolean
    Public AutoEllipsis As Boolean
    Public UseCompatibleTextRendering As Boolean
    Public AutoSize As Boolean
    Public Sensor As eSensorType
    Public SensorParam As String
    Public ParentName As String

    Public Title As String
    Public Value As String
    Public Unit As String
    Public TitleColor As MyColor
    Public ValueColor As MyColor
    Public UnitColor As MyColor
    Public TitleAlign As ContentAlignment
    Public ValueAlign As ContentAlignment
    Public UnitAlign As ContentAlignment
    Public AutoWidth As Boolean
    Public TitleWidth As Single
    Public ValueWidth As Single
    Public UnitWidth As Single
    Public TitleFont As MyFont
    Public UnitFont As MyFont
    Public TitleTextAdjustment As Point
    Public ValueTextAdjustment As Point
    Public UnitTextAdjustment As Point

    Public Sub New(control As CustomText)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        RightToLeft = control.RightToLeft
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size
        BorderStyle = control.BorderStyle
        FlatStyle = control.FlatStyle
        Image = control.Image.ImageToBase64
        ImageAlign = control.ImageAlign
        UseMnemonic = control.UseMnemonic
        AutoEllipsis = control.AutoEllipsis
        UseCompatibleTextRendering = control.UseCompatibleTextRendering
        AutoSize = False
        Sensor = control.Sensor
        SensorParam = control.SensorParam
        ParentName = control.ParentName

        Title = control.Title
        Value = control.Value
        Unit = control.Unit
        TitleColor = New MyColor(control.TitleColor)
        ValueColor = New MyColor(control.ValueColor)
        UnitColor = New MyColor(control.UnitColor)
        TitleAlign = control.TitleAlign
        ValueAlign = control.ValueAlign
        UnitAlign = control.UnitAlign
        AutoWidth = control.AutoWidth
        TitleWidth = control.TitleWidth
        ValueWidth = control.ValueWidth
        UnitWidth = control.UnitWidth
        TitleFont = New MyFont(control.TitleFont)
        UnitFont = New MyFont(control.UnitFont)
        TitleTextAdjustment = control.TitleTextAdjustment
        ValueTextAdjustment = control.ValueTextAdjustment
        UnitTextAdjustment = control.UnitTextAdjustment
    End Sub

End Structure

<Serializable>
Public Structure MyImageControl

    Public BackColor As MyColor
    Public BackgroundImage As String
    Public BackgroundImageLayout As ImageLayout
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public BorderStyle As BorderStyle
    Public Image As String
    Public SizeMode As PictureBoxSizeMode
    Public Sensor As eSensorType
    Public SensorParam As String
    Public EnableDynamicImages As Boolean
    Public DynamicImages As MyDynamicImageCollection
    Public AllowUserEdit As Boolean
    Public ParentName As String

    Public Sub New(control As ImageControl)
        BackColor = New MyColor(control.BackColor)
        BackgroundImage = control.BackgroundImage.ImageToBase64
        BackgroundImageLayout = control.BackgroundImageLayout
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        BorderStyle = control.BorderStyle
        Image = control.Image.ImageToBase64
        SizeMode = control.SizeMode
        Sensor = control.Sensor
        SensorParam = control.SensorParam
        EnableDynamicImages = control.EnableDynamicImages
        DynamicImages = New MyDynamicImageCollection(control.DynamicImages)
        AllowUserEdit = control.AllowUserEdit
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyStatusBar

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public Texture As String
    Public TextureSize As Size
    Public UseTexture As Boolean
    Public BackgroundColor As MyColor
    Public ForegroundColor As MyColor
    Public Value As Integer
    Public Minimum As Integer
    Public Maximum As Integer
    Public Sensor As eSensorType
    Public SensorParam As String
    Public ParentName As String
    Public FillDirection As FillDirection
    Public ShowValue As Boolean
    Public Unit As String

    Public Sub New(control As StatusBar)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        Texture = control.Texture.ImageToBase64
        TextureSize = control.TextureSize
        UseTexture = control.UseTexture
        BackgroundColor = New MyColor(control.BackgroundColor)
        ForegroundColor = New MyColor(control.ForegroundColor)
        Value = control.Value
        Minimum = control.Minimum
        Maximum = control.Maximum
        Sensor = control.Sensor
        SensorParam = control.SensorParam
        ParentName = control.ParentName
        FillDirection = control.FillDirection
        ShowValue = control.ShowValue
        Unit = control.Unit
    End Sub

End Structure

<Serializable>
Public Structure MyCircularStatusBar

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public BackgroundColor As MyColor
    Public ForegroundColor As MyColor
    Public ProgressColor As MyColor
    Public ProgressColor2 As MyColor
    Public GradientMode As LinearGradientMode
    Public BarWidth As Integer
    Public Thickness As Integer
    Public StartAngle As Integer
    Public Value As Integer
    Public Unit As String
    Public Minimum As Integer
    Public Maximum As Integer
    Public TextMode As eTextMode
    Public Sensor As eSensorType
    Public SensorParam As String
    Public Style As csbStyle
    Public SubText As String
    Public ProgressShape As ProgressShape
    Public ParentName As String

    Public Sub New(control As CircularStatusBar)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        ForegroundColor = New MyColor(control.ForegroundColor)
        ProgressColor = New MyColor(control.ProgressColor)
        ProgressColor2 = New MyColor(control.ProgressColor2)
        GradientMode = control.GradientMode
        BarWidth = control.BarWidth
        Thickness = control.Thickness
        StartAngle = control.StartAngle
        Unit = control.Unit
        Value = control.Value
        Minimum = control.Minimum
        Maximum = control.Maximum
        TextMode = control.TextMode
        Sensor = control.Sensor
        SensorParam = control.SensorParam
        Style = control.Style
        SubText = control.SubText
        ProgressShape = control.ProgressShape
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyPlotChart

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public Sensor As eSensorType
    Public SensorParam As String
    Public PlotChartStyle As MyPlotChartStyle
    Public BorderStyle As Border3DStyle
    Public ScaleMode As ScaleMode
    Public ParentName As String

    Public Sub New(control As PlotChart)

        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        Sensor = control.Sensor
        SensorParam = control.SensorParam
        PlotChartStyle = New MyPlotChartStyle(control.PlotChartStyle)
        BorderStyle = control.BorderStyle
        ScaleMode = control.ScaleMode
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyDetailSensor

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public DetailedSensor As eCompleteSensor
    Public DrawBorder As Boolean
    Public ParentName As String

    Public Sub New(control As DetailSensor)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size
        DetailedSensor = control.DetailedSensor
        DrawBorder = control.DrawBorder
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyPlotChartStyle

    Public ShowVerticalGridLines As Boolean
    Public ShowHorizontalGridLines As Boolean
    Public ShowCurMax As Boolean
    Public ShowAverageLine As Boolean
    Public VerticalGridPen As MyChartPen
    Public HorizontalGridPen As MyChartPen
    Public AvgLinePen As MyChartPen
    Public ChartLinePen As MyChartPen
    Public AntiAliasing As Boolean
    Public BackgroundColorTop As MyColor
    Public BackgroundColorBottom As MyColor

    Public Sub New(plotChartStyle As PlotChartStyle)
        ShowVerticalGridLines = plotChartStyle.ShowVerticalGridLines
        ShowHorizontalGridLines = plotChartStyle.ShowHorizontalGridLines
        ShowCurMax = plotChartStyle.ShowCurMax
        ShowAverageLine = plotChartStyle.ShowAverageLine
        VerticalGridPen = New MyChartPen(plotChartStyle.VerticalGridPen)
        HorizontalGridPen = New MyChartPen(plotChartStyle.HorizontalGridPen)
        AvgLinePen = New MyChartPen(plotChartStyle.AvgLinePen)
        ChartLinePen = New MyChartPen(plotChartStyle.ChartLinePen)
        AntiAliasing = plotChartStyle.AntiAliasing
        BackgroundColorTop = New MyColor(plotChartStyle.BackgroundColorTop)
        BackgroundColorBottom = New MyColor(plotChartStyle.BackgroundColorBottom)
    End Sub

    Public Function ToPlotChartStyle() As PlotChartStyle
        Return New PlotChartStyle() With {.ShowVerticalGridLines = ShowVerticalGridLines, .ShowHorizontalGridLines = ShowHorizontalGridLines, .ShowAverageLine = ShowAverageLine, .ShowCurMax = ShowCurMax,
            .VerticalGridPen = New ChartPen() With {.Color = VerticalGridPen.Color.ToColor, .DashStyle = VerticalGridPen.DashStyle, .Width = VerticalGridPen.Width},
            .HorizontalGridPen = New ChartPen() With {.Color = HorizontalGridPen.Color.ToColor, .DashStyle = HorizontalGridPen.DashStyle, .Width = HorizontalGridPen.Width},
            .AvgLinePen = New ChartPen() With {.Color = AvgLinePen.Color.ToColor, .DashStyle = AvgLinePen.DashStyle, .Width = AvgLinePen.Width},
            .ChartLinePen = New ChartPen() With {.Color = ChartLinePen.Color.ToColor, .DashStyle = ChartLinePen.DashStyle, .Width = ChartLinePen.Width},
            .AntiAliasing = AntiAliasing, .BackgroundColorTop = BackgroundColorTop.ToColor, .BackgroundColorBottom = BackgroundColorBottom.ToColor}
    End Function

End Structure

<Serializable>
Public Structure MyChartPen

    Public Color As MyColor
    Public DashStyle As Drawing2D.DashStyle
    Public Width As Single

    Public Sub New(chartPen As ChartPen)
        Color = New MyColor(chartPen.Color)
        DashStyle = chartPen.DashStyle
        Width = chartPen.Width
    End Sub

End Structure

<Serializable>
Public Structure MyYoutube

    Public BackColor As MyColor
    Public ForeColor As MyColor
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public YoutubeID As String
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size
    Public Sensor As eSensorType
    Public Play As Boolean
    Public ParentName As String

    Public Sub New(control As Youtube)
        BackColor = New MyColor(control.BackColor)
        ForeColor = New MyColor(control.ForeColor)
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        YoutubeID = control.YoutubeID
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size
        Sensor = control.Sensor
        Play = control.Play
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyWeatherWidget

    Public BackColor As MyColor
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public Sensor As eSensorType
    Public WeatherStyle As WeatherStyle
    Public IconStyle As IconStyle
    Public ParentName As String

    Public Sub New(control As WeatherWidget)
        BackColor = New MyColor(control.BackColor)
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size
        Sensor = control.Sensor
        WeatherStyle = control.WeatherStyle
        IconStyle = control.IconStyle
        ParentName = control.ParentName
    End Sub

End Structure

<Serializable>
Public Structure MyFont

    Public Name As String
    Public Size As Single
    Public Unit As GraphicsUnit
    Public Bold As Boolean
    Public GdiCharSet As Byte
    Public GdiVerticalFont As Boolean
    Public Italic As Boolean
    Public Strikeout As Boolean
    Public Underline As Boolean

    Public Sub New(font As Font)
        Name = font.Name
        Size = font.Size
        Unit = font.Unit
        Bold = font.Bold
        GdiCharSet = font.GdiCharSet
        GdiVerticalFont = font.GdiVerticalFont
        Italic = font.Italic
        Strikeout = font.Strikeout
        Underline = font.Underline
    End Sub

    Public Function ToFont() As Font
        Dim style As FontStyle = If(Bold, FontStyle.Bold, FontStyle.Regular) Or If(Italic, FontStyle.Italic, Nothing) Or If(Strikeout, FontStyle.Strikeout, Nothing) Or If(Underline, FontStyle.Underline, Nothing)
        Try
            Return New Font(New FontFamily(Name), Size, style, Unit, GdiCharSet, GdiVerticalFont)
        Catch ex As Exception
            Try
                Dim _name As String = Name
                Return New Font(PrivateFonts.Families().SingleOrDefault(Function(x) x.Name = _name), Size, style, Unit, GdiCharSet, GdiVerticalFont)
            Catch exc As Exception
                Return New Font(New FontFamily("Verdana"), Size, style, Unit, GdiCharSet, GdiVerticalFont)
            End Try
        End Try
    End Function

End Structure

<Serializable>
Public Structure MyColor

    Public R As Byte
    Public G As Byte
    Public B As Byte
    Public A As Byte

    Public Sub New(color As Color)
        R = color.R
        G = color.G
        B = color.B
        A = color.A
    End Sub

    Public Function ToColor() As Color
        Return Color.FromArgb(A, R, G, B)
    End Function

End Structure

<Serializable>
Public Structure MySImage

    Public Image As String
    Public DisplayIndex As Integer
    Public Name As String

    Public Sub New(simage As SImage)
        Image = simage.Image.ImageToBase64
        DisplayIndex = simage.DisplayIndex
        Name = simage.Name
    End Sub

End Structure

<Serializable>
Public Structure MyDynamicImageCollection

    Public List As List(Of MySImage)

    Public Sub New(dynamic As DynamicImageCollection)
        Dim newList As New List(Of MySImage)
        For Each si As SImage In dynamic
            newList.Add(New MySImage(si))
        Next
        List = newList
    End Sub

    Public Function ToDynamicImages() As DynamicImageCollection
        Dim il As New DynamicImageCollection()

        If List IsNot Nothing Then
            For Each msi In List
                il.Add(New SImage() With {.DisplayIndex = msi.DisplayIndex, .Image = msi.Image.Base64ToImage, .Name = msi.Name})
            Next
        End If
        Return il
    End Function

End Structure

<Serializable>
Public Structure MyAudioVisualizer

    Public BackColor As MyColor
    Public BackgroundImage As String
    Public BackgroundImageLayout As ImageLayout
    Public Font As MyFont
    Public ForeColor As MyColor
    Public RightToLeft As Boolean
    Public Text As String
    Public Enabled As Boolean
    Public Visible As Boolean
    Public Tag As Object
    Public Name As String
    Public Anchor As AnchorStyles
    Public Dock As DockStyle
    Public Location As Point
    Public Margin As Padding
    Public Padding As Padding
    Public Size As Size

    Public Sensor As eSensorType
    Public ParentName As String
    Public UseAverage As Boolean
    Public BarCount As Integer
    Public BarSpacing As Integer
    Public ScalingStrategy As ScalingStrategy
    Public Direction As eDirection
    Public LineCap As LineCap
    Public BarStyle As eBarStyle
    Public ColorStyle As ARColorStyle
    Public Speed As Single
    Public Color1 As MyColor
    Public Color2 As MyColor
    Public Color3 As MyColor
    Public Color4 As MyColor
    Public Color5 As MyColor
    Public Color6 As MyColor
    Public Color7 As MyColor

    Public Sub New(control As AudioVisualizer)
        BackColor = New MyColor(control.BackColor)
        BackgroundImage = control.BackgroundImage.ImageToBase64
        BackgroundImageLayout = control.BackgroundImageLayout
        Font = New MyFont(control.Font)
        ForeColor = New MyColor(control.ForeColor)
        RightToLeft = control.RightToLeft
        Text = control.Text
        Enabled = control.Enabled
        Visible = control.Visible
        Tag = control.Tag
        Name = control.Name
        Anchor = control.Anchor
        Dock = control.Dock
        Location = control.Location
        Margin = control.Margin
        Padding = control.Padding
        Size = control.Size

        Sensor = control.Sensor
        ParentName = control.ParentName
        UseAverage = control.UseAverage
        BarCount = control.BarCount
        BarSpacing = control.BarSpacing
        ScalingStrategy = control.ScalingStrategy
        Direction = control.Direction
        LineCap = control.LineCap
        BarStyle = control.BarStyle
        ColorStyle = control.ColorStyle
        Speed = control.Speed
        Color1 = New MyColor(control.Color1)
        Color2 = New MyColor(control.Color2)
        Color3 = New MyColor(control.Color3)
        Color4 = New MyColor(control.Color4)
        Color5 = New MyColor(control.Color5)
        Color6 = New MyColor(control.Color6)
        Color7 = New MyColor(control.Color7)
    End Sub

End Structure