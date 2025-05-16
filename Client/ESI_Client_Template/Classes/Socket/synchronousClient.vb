Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Public Class synchronousClient

    ' ManualResetEvent instances signal completion.
    Private Shared connectDone As New ManualResetEvent(False)
    Private Shared sendDone As New ManualResetEvent(False)
    Private Shared receiveDone As New ManualResetEvent(False)

    'public events
    Public Event connected()
    Public Event connectionError()
    Public Event messageReceived(e As String)

    ' The response from the remote device.


    ' Establish the remote endpoint for the socket.
    ' For this example use local machine.
    Dim ipHostInfo As IPHostEntry
    Dim ipAddress As IPAddress
    Dim remoteEP As IPEndPoint

    ' Create a TCP/IP socket.
    Public client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

    Public Sub connect()
        Try

            Dim resolved As IPHostEntry = Dns.GetHostEntry(myIPAddress)

            For i As Integer = 1 To resolved.AddressList.Count
                If resolved.AddressList(i - 1).ToString.IndexOf(".") > -1 Then
                    ipAddress = resolved.AddressList(i - 1)

                    Exit For
                End If
            Next

            Dim remoteEP As New IPEndPoint(ipAddress, myPortNumber)

            ' Connect to the remote endpoint.
            client.Connect(remoteEP)

            RaiseEvent connected()
        Catch
            RaiseEvent connectionError()
        End Try
    End Sub

    Public Sub close()
        ' Release the socket.
        'If Not client.Connected Then Exit Sub

        client.Shutdown(SocketShutdown.Both)
        client.Close()
    End Sub

    Public Sub sendMessage(id As String, message As String)
        ' Send  data to the remote device.

        Send(id, message)
    End Sub

    Dim data As String = String.Empty
    Public Sub Receive()
        Try

            ' Create the state object.
            Dim bytes(1024) As Byte

            ' Begin receiving the data from the remote device.
            Dim bytesRec As Integer = client.Receive(bytes)

            data &= Encoding.ASCII.GetString(bytes, 0, bytesRec)

            If data.IndexOf("<EOF>") > -1 Then

                Dim tempa() As String = {"<EOF>"}
                Dim msgtokens() As String = data.Split(tempa, StringSplitOptions.None)

                For i As Integer = 1 To msgtokens.Length - 1
                    RaiseEvent messageReceived(msgtokens(i - 1))
                Next

                data = msgtokens(msgtokens.Length - 1)
            Else
                Receive()
            End If
        Catch
            RaiseEvent connectionError()
        End Try
    End Sub 'Receive


    Private Sub Send(id As String, ByVal str As String)
        Try
            ' Convert the string data to byte data using ASCII encoding.
            Dim msg As Byte() = Encoding.ASCII.GetBytes(id & "<SEP>" & str & "<EOF>")

            ' Begin sending the data to the remote device.
            client.Send(msg)
        Catch
            RaiseEvent connectionError()
        End Try

    End Sub 'Send

    'Private Shared Sub SendCallback(ByVal ar As IAsyncResult)
    '    ' Retrieve the socket from the state object.
    '    Dim client As Socket = CType(ar.AsyncState, Socket)

    '    ' Complete sending the data to the remote device.
    '    Dim bytesSent As Integer = client.EndSend(ar)
    '    Console.WriteLine("Sent {0} bytes to server.", bytesSent)

    '    ' Signal that all bytes have been sent.
    '    sendDone.Set()
    'End Sub 'SendCallback
End Class
