Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security.Cryptography
Imports System.Xml.Serialization

Public Structure UserPresetData

    Public ReadOnly Property Instance As UserPresetData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public Name As String
    Public TextLabels As List(Of PDItem)
    Public ImageBoxes As List(Of PDItem)
    Public YoutubeVideos As List(Of PDItem)

    Public Sub New(filename As String)
        Me.FileName = filename
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(UserPresetData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()

        MsgBox($"Theme Preset file successfully saved.", MsgBoxStyle.Information, "Save")
    End Sub

    Public Function ReadFromFile() As UserPresetData
        If Not File.Exists(FileName) Then
            Return New UserPresetData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(UserPresetData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), UserPresetData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New UserPresetData(FileName)
        End Try
    End Function

End Structure

Public Structure PDItem

    Public Name As String
    Public Value As String

    Public Sub New(name As String, value As String)
        Me.Name = name
        Me.Value = value
    End Sub

End Structure
