
Imports System.ComponentModel

<TypeConverterAttribute(GetType(ExpandableObjectConverter))>
Public Class PlotChartStyle

    Public Sub New()
        _verticalGridPen = New ChartPen()
        _horizontalGridPen = New ChartPen()
        _avgLinePen = New ChartPen()
        _chartLinePen = New ChartPen()
    End Sub

    Private _showCurMax As Boolean = True
    Public Property ShowCurMax() As Boolean
        Get
            Return _showCurMax
        End Get
        Set(value As Boolean)
            _showCurMax = value
        End Set
    End Property

    Private _showVerticalGridLines As Boolean = False
    Public Property ShowVerticalGridLines() As Boolean
        Get
            Return _showVerticalGridLines
        End Get
        Set(ByVal value As Boolean)
            _showVerticalGridLines = value
        End Set
    End Property

    Private _showHorizontalGridLines As Boolean = False
    Public Property ShowHorizontalGridLines() As Boolean
        Get
            Return _showHorizontalGridLines
        End Get
        Set(ByVal value As Boolean)
            _showHorizontalGridLines = value
        End Set
    End Property

    Private _showAverageLine As Boolean = True
    Public Property ShowAverageLine() As Boolean
        Get
            Return _showAverageLine
        End Get
        Set(ByVal value As Boolean)
            _showAverageLine = value
        End Set
    End Property

    Private _verticalGridPen As ChartPen
    Public Property VerticalGridPen() As ChartPen
        Get
            Return _verticalGridPen
        End Get
        Set(ByVal value As ChartPen)
            _verticalGridPen = value
        End Set
    End Property

    Private _horizontalGridPen As ChartPen
    Public Property HorizontalGridPen() As ChartPen
        Get
            Return _horizontalGridPen
        End Get
        Set(ByVal value As ChartPen)
            _horizontalGridPen = value
        End Set
    End Property

    Private _avgLinePen As ChartPen
    Public Property AvgLinePen() As ChartPen
        Get
            Return _avgLinePen
        End Get
        Set(ByVal value As ChartPen)
            _avgLinePen = value
        End Set
    End Property

    Private _chartLinePen As ChartPen
    Public Property ChartLinePen() As ChartPen
        Get
            Return _chartLinePen
        End Get
        Set(ByVal value As ChartPen)
            _chartLinePen = value
        End Set
    End Property

    Private _antiAliasing As Boolean = True
    Public Property AntiAliasing() As Boolean
        Get
            Return _antiAliasing
        End Get
        Set(ByVal value As Boolean)
            _antiAliasing = value
        End Set
    End Property

    Private _backgroundColorTop As Color = Color.YellowGreen
    Public Property BackgroundColorTop() As Color
        Get
            Return _backgroundColorTop
        End Get
        Set(ByVal value As Color)
            _backgroundColorTop = value
        End Set
    End Property

    Private _backgroundColorBottom As Color = Color.DarkOliveGreen
    Public Property BackgroundColorBottom() As Color
        Get
            Return _backgroundColorBottom
        End Get
        Set(ByVal value As Color)
            _backgroundColorBottom = value
        End Set
    End Property
End Class

<TypeConverterAttribute(GetType(ExpandableObjectConverter))>
Public Class ChartPen

    Public Sub New()
        _pen = New Pen(Color.Black, 1.0F)
    End Sub

    Public Property Color() As Color
        Get
            Return _pen.Color
        End Get
        Set(ByVal value As Color)
            _pen.Color = value
        End Set
    End Property

    Public Property DashStyle() As Drawing2D.DashStyle
        Get
            Return _pen.DashStyle
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.DashStyle)
            _pen.DashStyle = value
        End Set
    End Property

    Public Property Width() As Single
        Get
            Return _pen.Width
        End Get
        Set(ByVal value As Single)
            _pen.Width = value
        End Set
    End Property

    Private _pen As Pen
    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public ReadOnly Property Pen() As Pen
        Get
            Return _pen
        End Get
    End Property
End Class
