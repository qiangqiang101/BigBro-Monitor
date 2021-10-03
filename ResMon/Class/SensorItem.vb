Imports OpenHardwareMonitor.Hardware
Public Class SensorGroup

    Public Name As String
    Public Values As List(Of ISensor)
    Public Unit As String

    Public Sub New(name As String, Optional unit As String = Nothing)
        Me.Name = name
        Me.Unit = unit
        Values = New List(Of ISensor)
    End Sub

    Public Sub Add(item As ISensor)
        If Not Exists(item) Then Values.Add(item)
    End Sub

    Public Function Exists(item As ISensor) As Boolean
        Return Not Values.Where(Function(x) x.Name = item.Name).Count = 0
    End Function

    Public Overloads Function ToString() As String
        Dim sb As String = Nothing
        For Each value In Values
            sb &= $"{value.Name} {Math.Ceiling(value.Value.GetValueOrDefault)}{Unit}{vbNewLine}"
        Next
        Return sb
    End Function

    Public Function ToLeftRight() As Tuple(Of String, String)
        Dim left As String = Nothing
        Dim right As String = Nothing
        For Each value In Values
            left &= value.Name & vbNewLine
            right &= Math.Ceiling(value.Value.GetValueOrDefault) & Unit & vbNewLine
        Next

        If left <> Nothing Then If left.EndsWith(vbNewLine) Then left = left.Remove(left.LastIndexOf(vbNewLine))
        If right <> Nothing Then If right.EndsWith(vbNewLine) Then right = right.Remove(right.LastIndexOf(vbNewLine))
        Return New Tuple(Of String, String)(left, right)
    End Function

End Class