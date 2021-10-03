Public Class DBFlowLayoutPanel
    Inherits TableLayoutPanel

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint, True)
    End Sub

    Public Sub ControlsClear()
        For i As Integer = Controls.Count - 1 To 0 Step -1
            Controls.RemoveAt(i)
        Next
    End Sub

End Class
