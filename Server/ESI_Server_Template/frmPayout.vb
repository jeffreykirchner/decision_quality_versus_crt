Public Class frmPayout
    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try
            If Not validateInt(txtPayPeriod.Text, 2, False, False) Then Exit Sub
            If Not validateInt(txtPayTicket.Text, 2, False, False) Then Exit Sub

            If phaseList(currentPeriod) = "Lottery" Then

                If CInt(txtPayPeriod.Text) > numberOfPeriodsLottery Then Exit Sub
                If CInt(txtPayTicket.Text) > lotteryTicketCount Then Exit Sub

                doLotteryPayout(CInt(txtPayPeriod.Text), CInt(txtPayTicket.Text))
            Else

            End If

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtPayTicket_TextChanged(sender As Object, e As EventArgs) Handles txtPayTicket.TextChanged
        Try
            AcceptButton = cmdSubmit
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class