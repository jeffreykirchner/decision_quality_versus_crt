Public Class secondPriceBid
    'once second price bid, for one person, in one group, in one period.

    Public bid As Double
    Public index As Integer
    Public owner As Integer
    Public subPeriod As Integer
    Public value As Double

    Public Sub New()

    End Sub

    Public Function getString() As String
        Try
            Dim outstr As String = ""

            outstr = bid & ";"
            outstr &= index & ";"
            outstr &= owner & ";"
            outstr &= subPeriod & ";"

            Return outstr
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Public Sub New(bid As Double, index As Integer, owner As Integer, subperiod As Integer, value As Double)
        Try
            Me.bid = bid
            Me.index = index
            Me.owner = owner
            Me.subPeriod = subperiod
            Me.value = value
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Shared Operator <(ByVal b1 As secondPriceBid, ByVal b2 As secondPriceBid) As Boolean
        Try
            If b1.bid < b2.bid Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Operator

    Public Shared Operator >(ByVal b1 As secondPriceBid, ByVal b2 As secondPriceBid) As Boolean
        Try
            If b1.bid > b2.bid Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Operator

    Public Shared Operator =(ByVal b1 As secondPriceBid, ByVal b2 As secondPriceBid) As Boolean
        Try
            If b1.bid = b2.bid Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Operator

    Public Shared Operator <>(ByVal b1 As secondPriceBid, ByVal b2 As secondPriceBid) As Boolean
        Try
            If b1.bid <> b2.bid Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Operator
End Class
