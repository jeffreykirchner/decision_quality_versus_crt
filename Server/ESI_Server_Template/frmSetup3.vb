Public Class frmSetup3
    Private Sub frmSetup3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim tempC As Integer = 0

            For i As Integer = 1 To numberOfPeriods + 1
                If getINI(sfile, "periodSetup", CStr(i)) = "Lottery" Then
                    tempC += 1
                End If
            Next

            dgMain.RowCount = tempC * 2

            tempC = 1
            For i As Integer = 1 To dgMain.RowCount Step 2

                If tempC > numberOfPeriods Then
                    dgMain(0, i - 1).Value = "Instructions"
                    dgMain(0, i).Value = "Instructions"
                Else
                    dgMain(0, i - 1).Value = CStr(tempC)
                    dgMain(0, i).Value = CStr(tempC)
                End If

                dgMain(1, i - 1).Value = "Red"
                dgMain(1, i).Value = "Blue"

                'red values
                Dim msgtokens() As String = getINI(sfile, "lotteries", dgMain(0, i - 1).Value & "-" & dgMain(1, i - 1).Value).Split(";")

                If msgtokens.Count > 3 Then
                    Dim nextToken As Integer = 0

                    For j As Integer = 3 To dgMain.ColumnCount
                        dgMain(j - 1, i - 1).Value = msgtokens(nextToken)
                        nextToken += 1
                    Next

                    'blue values
                    msgtokens = getINI(sfile, "lotteries", dgMain(0, i).Value & "-" & dgMain(1, i).Value).Split(";")
                    nextToken = 0

                    For j As Integer = 3 To dgMain.ColumnCount
                        dgMain(j - 1, i).Value = msgtokens(nextToken)
                        nextToken += 1
                    Next

                End If

                tempC += 1
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                Dim tempS As String = ""

                For j As Integer = 3 To dgMain.ColumnCount
                    tempS &= dgMain(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "lotteries", dgMain(0, i - 1).Value & "-" & dgMain(1, i - 1).Value, tempS)
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdGenerateWinningNumbers_Click(sender As Object, e As EventArgs) Handles cmdGenerateWinningNumbers.Click
        Try
            For i As Integer = 1 To dgMain.RowCount Step 2
                Dim tempR As Integer = rand(lotteryTicketCount, 1)

                dgMain(10, i - 1).Value = tempR
                dgMain(10, i).Value = tempR
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As Object, e As EventArgs) Handles cmdCopyDown.Click
        Try
            Dim topRow As Integer
            Dim bottomRow As Integer

            Dim tempN As Integer = dgMain(0, dgMain.CurrentCell.RowIndex).Value

            For i As Integer = 0 To dgMain.RowCount - 1
                If dgMain(0, i).Value = tempN Then
                    topRow = i
                    bottomRow = i + 1
                    Exit For
                End If
            Next

            For i As Integer = bottomRow + 1 To dgMain.RowCount - 1 Step 2

                For j As Integer = 2 To dgMain.ColumnCount - 1
                    dgMain(j, i).Value = dgMain(j, topRow).Value
                    dgMain(j, i + 1).Value = dgMain(j, bottomRow).Value
                Next
            Next

            'For i As Integer = dgMain.CurrentRow.Index + 1 To dgMain.RowCount - 1
            '    dgMain(dgMain.CurrentCell.ColumnIndex, i).Value = dgMain(dgMain.CurrentCell.ColumnIndex, dgMain.CurrentCell.RowIndex).Value
            'Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class