Public Class ResizeableControl

    Private WithEvents mControl As Control
    Private mMouseDown As Boolean = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean = False

    Public Enum EdgeEnum
        None = 0
        Right = 1
        Left = 2
        Top = 4
        Bottom = 8
        TopLeft = 16
        'added
        All = TopLeft Or Left Or Right Or Top Or Bottom
        ResizeAnchorTopLeft = Right Or Bottom
        OnlyMove = TopLeft
        'end added
    End Enum

    Public Property AllowEdges() As EdgeEnum
        Get
            Return _AllowEdges
        End Get
        Set(ByVal value As EdgeEnum)
            _AllowEdges = value
        End Set
    End Property
    Friend _AllowEdges As EdgeEnum = EdgeEnum.All 'Default Behavior

    Public Property HighlightColor() As Drawing.Color
        Get
            Return _HighlightColor
        End Get
        Set(ByVal value As Drawing.Color)
            _HighlightColor = value
        End Set
    End Property
    Private _HighlightColor As Drawing.Color = Color.Fuchsia

    Public Sub New(ByVal Control As Control)
        mControl = Control
    End Sub
    'added
    Public Sub New(ByVal Control As Control, ByVal AllowedEdges As EdgeEnum)
        mControl = Control
        _AllowEdges = AllowedEdges
    End Sub
    'end added

    Private Sub mControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then mMouseDown = True
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
        mMouseDown = False
    End Sub
    'added
    Private mpLast_Location As Point = New Point(0, 0)
    'end added
    Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics

        Dim B As New System.Drawing.SolidBrush(_HighlightColor)
        'added 'Moved from Select Case mEdge : Case EdgeEnum.None
        If mOutlineDrawn Then
            c.Refresh()
            mOutlineDrawn = False
        End If
        'end added
        Select Case mEdge
            Case EdgeEnum.TopLeft
                g.FillRectangle(B, 0, 0, mWidth * 4, mWidth * 4)
                mOutlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(B, 0, 0, mWidth, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(B, c.Width - mWidth, 0, c.Width, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(B, 0, 0, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(B, 0, c.Height - mWidth, c.Width, mWidth)
                mOutlineDrawn = True
                'Case EdgeEnum.None 'Moved before Select Case
                '    If mOutlineDrawn Then
                '        c.Refresh()
                '        mOutlineDrawn = False
                '    End If
        End Select

        If mMouseDown And mEdge <> EdgeEnum.None Then
            c.SuspendLayout()
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    'added
                    Dim iX_Delta As Integer = e.X
                    Dim iY_Delta As Integer = e.Y
                    If Not (mpLast_Location = New Point(0, 0)) Then
                        iX_Delta -= mpLast_Location.X
                        iY_Delta -= mpLast_Location.Y
                    End If
                    c.SetBounds(c.Left + iX_Delta, c.Top + iY_Delta, c.Width, c.Height)
                    'end added
                    'c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height) 'Original
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Left
                    c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Right
                    c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                    RaiseEvent ResizeOccurred(c)
                    'added
                    mpLast_Location = e.Location
                    'end added
                Case EdgeEnum.Top
                    c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Bottom
                    c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
                    RaiseEvent ResizeOccurred(c)
            End Select
            c.ResumeLayout()
        Else
            Select Case True
                Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
                    c.Cursor = Cursors.SizeAll
                    mEdge = EdgeEnum.TopLeft
                Case e.X <= mWidth 'left edge
                    c.Cursor = Cursors.SizeWE
                    mEdge = EdgeEnum.Left
                Case e.X > c.Width - (mWidth + 1) 'right edge
                    c.Cursor = Cursors.SizeWE
                    mEdge = EdgeEnum.Right
                Case e.Y <= mWidth 'top edge
                    c.Cursor = Cursors.SizeNS
                    mEdge = EdgeEnum.Top
                Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                    c.Cursor = Cursors.SizeNS
                    mEdge = EdgeEnum.Bottom
                Case Else 'no edge
                    c.Cursor = Cursors.Default
                    mEdge = EdgeEnum.None
            End Select
            mEdge = mEdge And _AllowEdges
            If mEdge = EdgeEnum.None Then c.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mControl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mControl.MouseLeave
        Dim c As Control = CType(sender, Control)
        c.Cursor = Cursors.Default
        mEdge = EdgeEnum.None
        c.Refresh()
    End Sub

    Public Event ResizeOccurred(ByRef c As System.Windows.Forms.Control)

End Class