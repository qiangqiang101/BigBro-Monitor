
Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable>
Public Structure WebThemeData

    Public ReadOnly Property Instance As WebThemeData
        Get
            Return ReadFromFile()
        End Get
    End Property

    Public ReadOnly Property ThemeInstance As WebThemeData
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
    Public Html As String
    Public Sensors As List(Of WebSensors)
    Public Snapshot As String
    Public UpdateInterval As Integer
    Public CustomPreview As String

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
        Dim ser = New XmlSerializer(GetType(WebThemeData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()

        MsgBox($"Theme file successfully saved.", MsgBoxStyle.Information, "Save")
    End Sub

    Public Function ReadFromBinFile() As WebThemeData
        If Not File.Exists(FileName) Then
            Return New WebThemeData(FileName)
        End If

        Try
            Using fs As FileStream = File.OpenRead(FileName)
                Dim formatter As New BinaryFormatter
                Dim instance = CType(formatter.Deserialize(fs), WebThemeData)
                Return instance
            End Using
        Catch ex As Exception
            Return New WebThemeData(FileName)
        End Try
    End Function

    Public Function ReadFromFile() As WebThemeData
        If Not File.Exists(FileName) Then
            Return New WebThemeData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(WebThemeData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), WebThemeData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New WebThemeData(FileName)
        End Try
    End Function

End Structure

Public Class WebSensors

    Public ID As String
    Public Name As String
    Public Value As String
    Public Param As String
    Public Unit As String

    Public Sub New()
    End Sub

End Class