Public NotInheritable Class Logger

    Public Shared Sub Log(message As String)
        IO.File.AppendAllText(IO.Path.Combine(LogsDir, $"{Now.ToString("dd-MM-yyyy")}.log"), $"{Now.ToShortTimeString}: {message}{vbNewLine}")
    End Sub

    Public Shared Sub Log(ex As Exception)
        IO.File.AppendAllText(IO.Path.Combine(LogsDir, $"{Now.ToString("dd-MM-yyyy")}.log"), $"{Now.ToShortTimeString}: {ex.Message.Replace("the.bigbromonitor.com", "llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch.co.uk")}{ex.StackTrace}{vbNewLine}")
    End Sub

End Class