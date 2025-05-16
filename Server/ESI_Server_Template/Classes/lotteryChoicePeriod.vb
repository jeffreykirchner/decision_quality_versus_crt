Public Class lotteryChoicePeriod
    Public redCount As Integer = 0
    Public blueCount As Integer = 0

    Public redChoices(10) As lotteryChoice
    Public blueChoices(10) As lotteryChoice

    Public winningNumber As Integer

    Public Sub New(redStr As String, blueStr As String)
        Try
            Dim msgtokens() As String = redStr.Split(";")
            Dim nextToken As Integer = 0

            'setup red choices
            For i As Integer = 1 To 4
                redChoices(i) = New lotteryChoice

                redChoices(i).payout = msgtokens(nextToken)
                nextToken += 1

                redChoices(i).ticketCount = msgtokens(nextToken)
                nextToken += 1

                If redChoices(i).ticketCount > 0 Then redCount += 1
            Next

            winningNumber = msgtokens(nextToken)
            nextToken += 1

            'setup blue choices
            msgtokens = blueStr.Split(";")
            nextToken = 0

            For i As Integer = 1 To 4
                blueChoices(i) = New lotteryChoice

                blueChoices(i).payout = msgtokens(nextToken)
                nextToken += 1

                blueChoices(i).ticketCount = msgtokens(nextToken)
                nextToken += 1

                If blueChoices(i).ticketCount > 0 Then blueCount += 1
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function getEarnings(side As String) As Integer()
        Try
            Dim tempC As Integer = 0
            Dim tempLotteryEarnings As Integer = redChoices(redCount).payout
            Dim payoutIndex As Integer = 0
            'check if lottery draw falls in one of the other buckets

            If side = "Red" Then
                payoutIndex = redCount

                For i As Integer = 1 To redCount

                    tempC += redChoices(i).ticketCount

                    If winningNumber <= tempC Then
                        payoutIndex = i
                        tempLotteryEarnings = redChoices(i).payout
                        Exit For
                    End If
                Next
            Else
                payoutIndex = blueCount

                For i As Integer = 1 To blueCount

                    tempC += blueChoices(i).ticketCount

                    If winningNumber <= tempC Then
                        payoutIndex = i
                        tempLotteryEarnings = blueChoices(i).payout
                        Exit For
                    End If
                Next
            End If

            Return {payoutIndex, tempLotteryEarnings}
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return {0, 0}
        End Try
    End Function

    Public Function getWinningIndex(ticketNumber) As Integer
        Try


            Return 0
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function getRedString(seperator As String) As String
        Try
            Dim tempS As String = ""

            For i As Integer = 1 To redCount
                tempS &= redChoices(i).payout & seperator
                tempS &= redChoices(i).ticketCount & seperator
            Next

            For i As Integer = redCount + 1 To 4
                tempS &= seperator
                tempS &= seperator
            Next

            Return tempS
        Catch ex As Exception
            appEventLog_Write("error :", ex)

            Return ""
        End Try
    End Function

    Public Function getBlueString(seperator As String) As String
        Try
            Dim tempS As String = ""

            For i As Integer = 1 To blueCount
                tempS &= blueChoices(i).payout & seperator
                tempS &= blueChoices(i).ticketCount & seperator
            Next

            For i As Integer = blueCount + 1 To 4
                tempS &= seperator
                tempS &= seperator
            Next

            Return tempS
        Catch ex As Exception
            appEventLog_Write("error :", ex)

            Return ""
        End Try
    End Function
End Class
