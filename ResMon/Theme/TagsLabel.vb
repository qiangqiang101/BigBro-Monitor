Public Class TagsLabel
    Inherits Label

    Private _color As Color = Color.DimGray
    Public Property LabelColor() As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        MyBase.OnPaintBackground(pevent)

        Dim g As Graphics = pevent.Graphics

        Using brush As New SolidBrush(_color)
            Dim newRect As New Rectangle(1, 1, ClientRectangle.Width - 1, ClientRectangle.Height - 1)
            g.FillRoundedRectangle(newRect, 5, brush, New RoundedRectCorners(True))
        End Using
    End Sub

End Class
