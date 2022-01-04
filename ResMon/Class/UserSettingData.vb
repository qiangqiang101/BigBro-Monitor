Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

<Serializable>
Public Structure UserSettingData

    Public ReadOnly Property Instance As UserSettingData
        Get
            Return ReadFromBinFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public CurrentTheme As String
    Public NetworkAdapterIndex As Integer
    Public AutoStart As Boolean
    Public Location As Point
    Public EnableBroadcast As Boolean
    Public BroadcastPort As Integer
    Public State As String
    Public Town As String
    Public TopMost As Boolean
    Public LicenseKey As String
    Public Email As String
    Public HWID As String
    Public Language As String

    Public Sub New(filename As String)
        Me.FileName = filename
    End Sub

    Public Sub Save1()
        Using fs As FileStream = File.Create(FileName)
            Dim formatter As New BinaryFormatter()
            formatter.Serialize(fs, Me)
        End Using

        MsgBox($"Settings successfully saved.", MsgBoxStyle.Information, "Build")
    End Sub

    Public Sub SaveSilent()
        Using fs As FileStream = File.Create(FileName)
            Dim formatter As New BinaryFormatter()
            formatter.Serialize(fs, Me)
        End Using
    End Sub

    Public Function ReadFromFile() As UserSettingData
        If Not File.Exists(FileName) Then
            Return New UserSettingData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(UserSettingData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), UserSettingData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New UserSettingData(FileName)
        End Try
    End Function

    Public Function ReadFromBinFile() As UserSettingData
        If Not File.Exists(FileName) Then
            Return New UserSettingData(FileName)
        End If

        Try
            Using fs As FileStream = File.OpenRead(FileName)
                Dim formatter As New BinaryFormatter
                Dim instance = CType(formatter.Deserialize(fs), UserSettingData)
                Return instance
            End Using
        Catch ex As Exception
            Return New UserSettingData(FileName)
        End Try
    End Function

End Structure