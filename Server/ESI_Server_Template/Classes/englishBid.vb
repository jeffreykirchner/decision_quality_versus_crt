Public Class englishBid
    Public bid As Double
    Public signal As Double
    Public owner As Integer

    Public Sub New(bid As Double, owner As Integer, signal As Double)
        Try
            Me.bid = bid
            Me.owner = owner
            Me.signal = signal
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function returnString() As String
        Try
            Dim str As String = ""

            str = bid & ";"
            str &= signal & ";"
            str &= owner & ";"

            Return str
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function
End Class
