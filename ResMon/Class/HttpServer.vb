Imports System.IO
Imports System.Net
Imports System.Threading

Public Class HttpServer

    Private listener As HttpListener
    Private listenPort As Integer
    Private listenerThread As Thread



    Public Sub New(port As Integer)
        Initialize(port)
    End Sub

    Private Sub Initialize(port As Integer)
        listenPort = port
        listenerThread = New Thread(AddressOf Listen)
        listenerThread.Start()
    End Sub

    Private Sub Listen()
        listener = New HttpListener
        listener.Prefixes.Add("http://*:" & listenPort & "/")
        listener.Start()

        While True
            Try
                Dim context As HttpListenerContext = listener.GetContext
                Process(context)
            Catch ex As Exception

            End Try
        End While
    End Sub

    Public Sub [Stop]()
        listenerThread.Abort()
        listener.Stop()
    End Sub

    Private Sub Process(context As HttpListenerContext)
        Try
            Dim html As String = "
<!DOCTYPE html>
    <html>
    <head>
    <title>Resource Monitor</title>
    <meta http-equiv=""refresh"" content=""5"">
    <style>
    img {margin: 0; display:block;}
    </style>
    </head>
    <body>
        <div>
            <img src=""data:image/jpeg;base64," & snapshots & """>
        </div>
    </body>
    </html>"
            Dim buffer() As Byte = Text.Encoding.UTF8.GetBytes(html)
            context.Response.ContentLength64 = buffer.Length
            Dim output As Stream = context.Response.OutputStream
            output.Write(buffer, 0, buffer.Length)

            context.Response.StatusCode = CInt(HttpStatusCode.OK)
            context.Response.OutputStream.Flush()
        Catch ex As Exception
            context.Response.StatusCode = CInt(HttpStatusCode.InternalServerError)
        End Try

        context.Response.OutputStream.Close()
    End Sub

End Class
