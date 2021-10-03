Imports System.Drawing.Drawing2D

Public Class NSThemeItem
    Inherits Control

    Private _themeData As ThemeData = New ThemeData().Instance
    Public Property ThemeData() As ThemeData
        Get
            Return _themeData
        End Get
        Set(value As ThemeData)
            _themeData = value
            Invalidate()
        End Set
    End Property

    Private _themeFile As String
    Public Property ThemeFile() As String
        Get
            Return _themeFile
        End Get
        Set(value As String)
            _themeFile = value
        End Set
    End Property

    Private _image As Image = My.Resources.Blank
    Private _imgLayout As ImageLayout = ImageLayout.Center
    Private _themeName As String
    Private _themeResolution As String
    Private _mouseEnter As Boolean = False

    Public Sub New(themedata As ThemeData, themefile As String)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True

        Me.ThemeData = themedata
        Me.ThemeFile = themefile
        Size = New Size(200, 200)

        Load()
    End Sub

    Public Sub Load()
        If Not _themeData.CustomPreview = Nothing Then
            _image = _themeData.CustomPreview.Base64ToImage
        Else
            _image = _themeData.Snapshot.Base64ToImage
        End If
        _themeName = _themeData.Name
        _themeResolution = $"{_themeData.Size.Width}x{_themeData.Size.Height}"

        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim formGraphics As Graphics = e.Graphics
        formGraphics.InterpolationMode = InterpolationMode.NearestNeighbor
        formGraphics.PixelOffsetMode = PixelOffsetMode.Half
        formGraphics.SmoothingMode = SmoothingMode.AntiAlias

        If _image Is Nothing Then _image = My.Resources.Blank
        Using tbrush As New TextureBrush(_image)
            Select Case _imgLayout
                Case ImageLayout.Tile
                    tbrush.WrapMode = WrapMode.Tile
                    formGraphics.FillRectangle(tbrush, New RectangleF(0, 0, Width, Width))
                Case ImageLayout.Stretch
                    formGraphics.DrawImage(_image, New RectangleF(0, 0, Width, Width))
                Case ImageLayout.Center
                    tbrush.WrapMode = WrapMode.Clamp
                    Dim displayArea As New Rectangle(0, 0, Width, Width)
                    Dim xDisplayCenterRelative As New Point(displayArea.Width / 2, displayArea.Height / 2)
                    Dim xImageCenterRelative As New Point(_image.Width / 2, _image.Height / 2)
                    Dim xOffsetRelative As New Point(xDisplayCenterRelative.X - xImageCenterRelative.X, xDisplayCenterRelative.Y - xImageCenterRelative.Y)
                    Dim xAbsolutePixel As Point = xOffsetRelative + New Size(displayArea.Location)
                    tbrush.TranslateTransform(xAbsolutePixel.X, xAbsolutePixel.Y)
                    formGraphics.FillRectangle(tbrush, New RectangleF(0, 0, Width, Height))
                Case ImageLayout.None
                    formGraphics.DrawImage(_image, New RectangleF(0, 0, _image.Width, _image.Height))
                Case ImageLayout.Zoom
                    Dim aspectRatio As Double
                    Dim newHeight, newWidth As Integer
                    Dim maxWidth As Integer = Width
                    Dim maxHeight As Integer = Width

                    If _image.Width > maxWidth Or _image.Height > maxHeight Then
                        If _image.Width >= _image.Height Then ' image is wider than tall
                            newWidth = maxWidth
                            aspectRatio = _image.Width / maxWidth
                            newHeight = CInt(_image.Height / aspectRatio)
                        Else ' image is taller than wide
                            newHeight = maxHeight
                            aspectRatio = _image.Height / maxHeight
                            newWidth = CInt(_image.Width / aspectRatio)
                        End If
                    Else
                        If _image.Width > _image.Height Then
                            newWidth = maxWidth
                            aspectRatio = _image.Width / maxWidth
                            newHeight = CInt(_image.Height / aspectRatio)
                        Else
                            newHeight = maxHeight
                            aspectRatio = _image.Height / maxHeight
                            newWidth = CInt(_image.Width / aspectRatio)
                        End If
                    End If

                    Dim newX As Integer = (Width - newWidth) / 2
                    Dim newY As Integer = (Height - newHeight) / 2

                    formGraphics.DrawImage(_image, New RectangleF(newX, newY, newWidth, newHeight))
            End Select
        End Using

        Using sbrush As New SolidBrush(Color.White), bbrush As New SolidBrush(Color.FromArgb(200, Color.Black))
            Dim sf As New StringFormat
            sf.LineAlignment = StringAlignment.Center
            sf.Alignment = StringAlignment.Center

            Dim trSize = TextRenderer.MeasureText(_themeResolution, Font)
            Dim trRect As New RectangleF(0, 0, trSize.Width, trSize.Height * 2)
            formGraphics.FillRectangle(bbrush, trRect)
            formGraphics.DrawString(_themeResolution, Font, sbrush, trRect, sf)

            Dim tnSize = TextRenderer.MeasureText(_themeName, Font)
            Dim tnRect As New RectangleF(0, ClientRectangle.Height - (tnSize.Height * 2), ClientRectangle.Width, tnSize.Height * 2)
            formGraphics.FillRectangle(bbrush, tnRect)
            formGraphics.DrawString(_themeName, Font, sbrush, tnRect, sf)
        End Using

        If _mouseEnter Then
            Using sbrush As New SolidBrush(Color.FromArgb(205, 150, 0))
                Using p As New Pen(sbrush, 2.0F)
                    formGraphics.DrawRectangle(p, ClientRectangle)
                End Using
            End Using
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)

        _mouseEnter = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        _mouseEnter = True
        Invalidate()
    End Sub

End Class
