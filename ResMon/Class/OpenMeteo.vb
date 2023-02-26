Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class OpenMeteo

    Public Temperature As Single
    Public WindSpeed As Single
    Public WindDirection As Single
    Public WeatherCode As Single
    Public WeatherName As String

    Public Sub New()
        Temperature = 0F
        WindSpeed = 0F
        WindDirection = 0F
        WeatherCode = 0F
        WeatherName = "N/A"
    End Sub

    Public Sub New(temp As Single, windspd As Single, winddir As Single, code As Single)
        Temperature = temp
        WindSpeed = windspd
        WindDirection = winddir
        WeatherCode = code
        WeatherName = GetWeather(code)
    End Sub

End Class

Public Module OpenMeteoData
    Public Function GetData(latitude As String, longitude As String, Optional currentWeather As Boolean = True, Optional timeout As Integer = 5000) As OpenMeteo
        Dim currDate As String = Now.ToString("yyyy-MM-dd")
        Dim json As String = ""

        Dim query As String = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true"

        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim req As HttpWebRequest = WebRequest.Create(query)
            With req
                .Timeout = timeout
                .Credentials = CredentialCache.DefaultCredentials
                .Accept = "*/*"
                .Method = "GET"
                .Host = "api.open-meteo.com"
                .ContentType = "application/json"
            End With
            Dim res As HttpWebResponse = req.GetResponse()
            Dim reader As New StreamReader(res.GetResponseStream)
            json = reader.ReadToEnd
            Dim obj As Object = JObject.Parse(json)

            Dim temperature As Single = obj("current_weather")("temperature")
            Dim windspeed As Single = obj("current_weather")("windspeed")
            Dim winddirection As Single = obj("current_weather")("winddirection")
            Dim weathercode As Single = obj("current_weather")("weathercode")

            Return New OpenMeteo(temperature, windspeed, winddirection, weathercode)
        Catch ex As Exception
            Logger.Log(json)
            Logger.Log(ex)
            Return GetData(latitude, longitude, currentWeather, timeout)
        End Try
    End Function

    Public Function GetWeather(weathercode As Single) As String
        Select Case CInt(weathercode)
            Case 0
                Return "Clear Sky"
            Case 1
                Return "Mainly Clear"
            Case 2
                Return "Partly Cloudy"
            Case 3
                Return "Cloudy"
            Case 45
                Return "Fog"
            Case 48
                Return "Depositing Rime Fog"
            Case 51
                Return "Light Drizzle"
            Case 53
                Return "Moderate Drizzle"
            Case 55
                Return "Dense Drizzle"
            Case 56
                Return "Light Freezing Drizzle"
            Case 57
                Return "Dense Freezing Drizzle"
            Case 61
                Return "Slight Rain"
            Case 63
                Return "Moderate Rain"
            Case 65
                Return "Heavy Rain"
            Case 66
                Return "Light Freezing Rain"
            Case 67
                Return "Heavy Freezing Rain"
            Case 71
                Return "Slight Snow fall"
            Case 73
                Return "Moderate Snow fall"
            Case 75
                Return "Heavy Snow fall"
            Case 77
                Return "Snow grains"
            Case 80
                Return "Slight Rain showers"
            Case 81
                Return "Moderate Rain showers"
            Case 82
                Return "Violent Rain showers"
            Case 85
                Return "Slight Snow showers"
            Case 86
                Return "Heavy Snow showers"
            Case 95
                Return "Slight Thunderstorm"
            Case 96
                Return "Slight Thunderstorm"
            Case 99
                Return "Thunderstorm with Heavy Hail"
            Case Else
                Return $"Unknown code {CInt(weathercode)}"
        End Select
    End Function

End Module