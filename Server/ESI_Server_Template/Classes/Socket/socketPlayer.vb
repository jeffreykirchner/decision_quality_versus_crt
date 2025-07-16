Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class socketPlayer
    Public WithEvents socketHandler As Socket

    Public Event messageReceived(str() As String)

    Dim bytes() As Byte = New [Byte](1024) {}

    Public receiveThread As Thread
    Public stopping As Boolean = False
    Public inumber As Integer
    Public messageCounter As Integer = 0
    Public remoteComputerName As String

    Public Sub startReceive()
        Try
            receiveThread = New Thread(AddressOf receive)
            receiveThread.IsBackground = True
            receiveThread.Start()
        Catch

        End Try
    End Sub

    Dim data As String = String.Empty
    Public Sub receive()
        Try
            While Not stopping
                bytes = New Byte(1024) {}

                Dim bytesRec As Integer = socketHandler.Receive(bytes)

                'data &= Encoding.ASCII.GetString(bytes, 0, bytesRec)
                data &= Encoding.UTF8.GetString(bytes, 0, bytesRec)

                If data.IndexOf("<EOF>") > -1 Then

                    Dim tempa() As String = {"<EOF>"}
                    Dim msgtokens() As String = data.Split(tempa, StringSplitOptions.None)

                    For i As Integer = 1 To msgtokens.Length - 1
                        RaiseEvent messageReceived({inumber, data})
                    Next

                    data = msgtokens(msgtokens.Length - 1)

                End If
            End While
        Catch

        End Try
    End Sub

    Public Sub send(id As String, str As String)
        Try
            'Dim msg As Byte() = Encoding.ASCII.GetBytes(id & "<SEP>" & str & "<EOF>")
            Dim msg As Byte() = Encoding.UTF8.GetBytes(id & "<SEP>" & str & "<EOF>")

            'Dim msg As Byte() = Encoding.ASCII.GetBytes(id & "<SEP>" & str & "<EOF>" & id & "<SEP>" & str & "<EOF>" & id & "<SEP>" & str & "<EOF>")  'test code

            socketHandler.Send(msg)
        Catch

        End Try
    End Sub

    Public Sub socketClose()

    End Sub
End Class
