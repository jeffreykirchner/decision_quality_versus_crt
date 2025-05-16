Public Class frmSetup4
    Private Sub frmSetup4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            doPeriodCount()

            dgMain.RowCount = numberOfPeriodsSecondPrice

            For i As Integer = 1 To 11
                dgMain.Columns.Add(dgMain.Columns(1).Clone)
            Next

            For i As Integer = 2 To dgMain.ColumnCount
                dgMain.Columns(i - 1).HeaderText = "Player " & i - 1 & " Value"
            Next

            'dgMain.RowCount = numberOfPlayers

            For i As Integer = 1 To dgMain.RowCount
                dgMain(0, i - 1).Value = i

                Dim msgtokens() As String = getINI(sfile, "secondPrice", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                If msgtokens.Length > 1 Then
                    For j As Integer = 2 To dgMain.ColumnCount

                        If nextToken <= msgtokens.Length - 1 Then
                            dgMain(j - 1, i - 1).Value = msgtokens(nextToken)
                        End If

                        nextToken += 1
                    Next
                End If
            Next

            'group setup
            dg2.RowCount = numberOfPlayers

            For i As Integer = 1 To dg2.RowCount
                dg2(0, i - 1).Value = i

                Dim msgtokens() As String = getINI(sfile, "2ndPriceGroupSetup", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                For j As Integer = 2 To dg2.ColumnCount
                    If nextToken <= msgtokens.Length - 1 Then
                        dg2(j - 1, i - 1).Value = msgtokens(nextToken)
                    End If

                    nextToken += 1
                Next
            Next

            txtUpper.Text = getINI(sfile, "gameSettings", "secondPriceEndValue")
            txtLower.Text = getINI(sfile, "gameSettings", "secondPriceStartValue")

            'instruction setup
            txtCount.Text = getINI(sfile, "gameSettings", "secondPriceExampleCount")

            If Not IsNumeric(txtCount.Text) Then txtCount.Text = "0"

            loadInstructionParameters()

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                Dim tempS As String = ""

                For j As Integer = 2 To dgMain.ColumnCount
                    tempS &= dgMain(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "secondPrice", CStr(i), tempS)
            Next

            For i As Integer = 1 To dg2.RowCount
                Dim tempS As String = ""

                For j As Integer = 2 To dg2.ColumnCount
                    tempS &= dg2(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "2ndPriceGroupSetup", CStr(i), tempS)
            Next

            writeINI(sfile, "gameSettings", "secondPriceStartValue", txtLower.Text)
            writeINI(sfile, "gameSettings", "secondPriceEndValue", txtUpper.Text)

            'instruction setup
            Dim tempC As Integer = 1
            For i As Integer = 1 To dg3.RowCount Step 2


                Dim str As String = ""

                For j As Integer = 1 To 10
                    str &= dg3(j + 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "2ndPriceInstructionSetup", tempC & "-" & "large", str)

                str = ""
                For j As Integer = 1 To 10
                    str &= dg3(j + 1, i).Value & ";"
                Next

                writeINI(sfile, "2ndPriceInstructionSetup", tempC & "-" & "small", str)

                tempC += 1
            Next

            writeINI(sfile, "gameSettings", "secondPriceExampleCount", txtCount.Text)

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub loadInstructionParameters()
        Try
            dg3.RowCount = CInt(txtCount.Text) * 2
            Dim tempC As Integer = 1

            For i As Integer = 1 To dg3.RowCount Step 2

                dg3(0, i - 1).Value = tempC
                dg3(0, i).Value = tempC

                dg3(1, i - 1).Value = "Large"
                dg3(1, i).Value = "Small"

                Dim msgtokens() As String = getINI(sfile, "2ndPriceInstructionSetup", tempC & "-" & "large").Split(";")

                If msgtokens.Length > 3 Then
                    For j As Integer = 1 To 10
                        dg3(j + 1, i - 1).Value = msgtokens(j - 1)
                    Next

                    msgtokens = getINI(sfile, "2ndPriceInstructionSetup", tempC & "-" & "small").Split(";")

                    For j As Integer = 1 To 10
                        dg3(j + 1, i).Value = msgtokens(j - 1)
                    Next
                End If
                tempC += 1
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtUpper_TextChanged(sender As Object, e As EventArgs) Handles txtUpper.TextChanged
        Try
            If txtUpper.Text = "" Then Exit Sub

            If Not validateInt(txtUpper.Text, 4, False, False) Then
                txtUpper.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtLower_TextChanged(sender As Object, e As EventArgs) Handles txtLower.TextChanged
        Try
            If txtLower.Text = "" Then Exit Sub

            If Not validateInt(txtLower.Text, 4, False, False) Then
                txtLower.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandom_Click(sender As Object, e As EventArgs) Handles cmdRandom.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                For j As Integer = 2 To dgMain.ColumnCount
                    dgMain(j - 1, i - 1).Value = rand(CInt(txtUpper.Text), CInt(txtLower.Text))
                Next
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyCellDown_Click(sender As Object, e As EventArgs) Handles cmdCopyCellDown.Click
        Try
            For i As Integer = dg2.CurrentRow.Index + 1 To dg2.RowCount - 1
                dg2(dg2.CurrentCell.ColumnIndex, i).Value = dg2(dg2.CurrentCell.ColumnIndex, dg2.CurrentCell.RowIndex).Value
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomInstructions_Click(sender As Object, e As EventArgs) Handles cmdRandomInstructions.Click
        Try



            For i As Integer = 1 To dg3.RowCount
                Dim sl As List(Of Integer) = New List(Of Integer)

                For j As Integer = 4 To dg3.ColumnCount
                    Dim tempV As Integer = rand(CInt(txtUpper.Text), CInt(txtLower.Text))

                    Dim tempR As Integer = englishTickAmountPV * 100

                    If phaseList(1) = "English Auction LS" Or phaseList(1) = "English Auction SL" Then
                        tempV = Math.Round(tempV / tempR) * tempR
                    End If

                    sl.Add(tempV)
                Next

                sl.Sort()

                'value
                If i Mod 2 = 1 Then
                    dg3(2, i - 1).Value = rand(CInt(txtUpper.Text), CInt(txtLower.Text))
                Else
                    dg3(2, i - 1).Value = dg3(2, i - 2).Value
                End If

                Dim tempN As Integer = sl.Count - 1
                For j As Integer = 4 To dg3.ColumnCount
                    dg3(j - 1, i - 1).Value = sl(tempN)
                    tempN -= 1
                Next
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdMinus_Click(sender As Object, e As EventArgs) Handles cmdMinus.Click
        Try
            If CInt(txtCount.Text) <> 0 Then
                txtCount.Text = CInt(txtCount.Text) - 1

                loadInstructionParameters()
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPlus_Click(sender As Object, e As EventArgs) Handles cmdPlus.Click
        Try
            txtCount.Text = CInt(txtCount.Text) + 1

            loadInstructionParameters()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class