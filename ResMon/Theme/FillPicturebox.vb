Imports System.Drawing.Drawing2D

Public Class FillPicturebox
    Inherits Control

    Private _image As Image = My.Resources.Blank
    Public Property Image() As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            _image = value
            Invalidate()
        End Set
    End Property

    Private _imgLayout As ImageLayout = ImageLayout.Zoom
    Public Property ImageLayout() As ImageLayout
        Get
            Return _imgLayout
        End Get
        Set(value As ImageLayout)
            _imgLayout = value
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim control As Color = SystemColors.Control
        Dim window As Color = SystemColors.Window

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
                    'tbrush.WrapMode = WrapMode.Clamp
                    'Dim displayArea As New Rectangle(0, 0, Width, Width)
                    'Dim xDisplayCenterRelative As New Point(displayArea.Width / 2, displayArea.Height / 2)
                    'Dim xImageCenterRelative As New Point(_image.Width / 2, _image.Height / 2)
                    'Dim xOffsetRelative As New Point(xDisplayCenterRelative.X - xImageCenterRelative.X, xDisplayCenterRelative.Y - xImageCenterRelative.Y)
                    'Dim xAbsolutePixel As Point = xOffsetRelative + New Size(displayArea.Location)
                    'tbrush.TranslateTransform(xAbsolutePixel.X, xAbsolutePixel.Y)
                    'formGraphics.FillRectangle(tbrush, New RectangleF(0, 0, Width, Height))

                    tbrush.WrapMode = WrapMode.Clamp
                    Dim displayArea As New Rectangle(0, 0, Width, Height)
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
    End Sub

End Class
