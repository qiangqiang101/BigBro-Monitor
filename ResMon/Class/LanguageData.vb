Imports System.IO
Imports System.Xml.Serialization

Public Structure LanguageData

    Public ReadOnly Property Instance As LanguageData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public btnResetFilter As String
    Public gbSettings As String
    Public btnThemeEditor As String
    Public btnSettings As String
    Public niTray As String
    Public AboutTitle As String
    Public ActivationTitle As String
    Public lblEnterLicense As String
    Public SettingTitle As String
    Public lblNetworkAdapter As String
    Public lblBroadcastPort As String
    Public cbBroadcast As String
    Public gbWeather As String
    Public lblState As String
    Public lblTown As String
    Public cbAuto As String
    Public cbTopMost As String
    Public lblLanguage As String
    Public gbLicense As String
    Public Unregistered As String
    Public Registered As String
    Public DaysRemain As String
    Public DayRemain As String
    Public btnCredits As String
    Public PortInvalid As String
    Public btnSearch As String
    Public btnClose As String
    Public btnOK As String
    Public btnCancel As String
    Public btnApply As String
    Public btnDelete As String
    Public btnActivate As String
    Public btnSave As String
    Public lblCPUFan As String

    Public Sub New(filename As String)
        Me.FileName = filename
    End Sub

    Public Function ReadFromFile() As LanguageData
        If Not File.Exists(FileName) Then
            Return New LanguageData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(LanguageData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), LanguageData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New LanguageData(FileName)
        End Try
    End Function

End Structure
