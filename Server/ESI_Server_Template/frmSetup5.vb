Public Class frmSetup5

    Dim tempC As Integer = 0

    Private Sub frmSetup5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            For i As Integer = 1 To numberOfPeriods
                If getINI(sfile, "periodSetup", CStr(i)) = "CV Full Info" Or getINI(sfile, "periodSetup", CStr(i)) = "CV Limited Info" Then
                    tempC += 1
                End If
            Next

            dg1.RowCount = tempC
            dg2.RowCount = tempC

            For i As Integer = 1 To tempC
                dg1(0, i - 1).Value = i
                dg1(1, i - 1).Value = getINI(sfile, "englishValues", CStr(i))


                dg2(0, i - 1).Value = i
                Dim msgtokens() As String = getINI(sfile, "englishSignals", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                For j As Integer = 2 To dg2.ColumnCount
                    If msgtokens.Length > nextToken Then
                        dg2(j - 1, i - 1).Value = msgtokens(nextToken)
                    End If
                    nextToken += 1
                Next
            Next

            txtValueMin.Text = getINI(sfile, "gameSettings", "englishMinValue")
            txtValueMax.Text = getINI(sfile, "gameSettings", "englishMaxValue")

            dg3.RowCount = numberOfPlayers

            For i As Integer = 1 To dg3.RowCount
                dg3(0, i - 1).Value = i

                Dim msgtokens() As String = getINI(sfile, "englishGroups", CStr(i)).Split(";")
                Dim nextToken As Integer = 0

                For j As Integer = 2 To dg3.ColumnCount
                    dg3(j - 1, i - 1).Value = msgtokens(nextToken)
                    nextToken += 1
                Next
            Next

            dg4.RowCount = 6

            For i As Integer = 1 To dg4.RowCount
                dg4(0, i - 1).Value = i + 1

                dg4(1, i - 1).Value = getINI(sfile, "englishTiming", CStr(i + 1))
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomValues_Click(sender As Object, e As EventArgs) Handles cmdRandomValues.Click
        Try
            For i As Integer = 1 To tempC
                Dim tempD As Double = rand(CInt(txtValueMax.Text), CInt(txtValueMin.Text))

                If tempD < CInt(txtValueMax.Text) Then
                    tempD += (rand(99, 0) / 100)
                End If

                dg1(1, i - 1).Value = Format(tempD, "0.00")
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRandomSignals_Click(sender As Object, e As EventArgs) Handles cmdRandomSignals.Click
        Try

            Dim tempP As Integer = 1
            For i As Integer = 1 To tempC
                tempP = 1

                For j As Integer = 1 To 10

                    Dim tempV As Double = dg1(1, i - 1).Value

                    Dim tempR As Double = tempV + rand(CDbl(dg2(11, i - 1).Value), -CDbl(dg2(11, i - 1).Value))

                    Dim tempDecimalAdder As Double = (rand(99, -99) / 100)

                    Do While tempR + tempDecimalAdder > tempV + CDbl(dg2(11, i - 1).Value) Or tempR + tempDecimalAdder < tempV - CDbl(dg2(11, i - 1).Value)
                        tempDecimalAdder = (rand(99, -99) / 100)
                    Loop

                    tempR += tempDecimalAdder

                    dg2(tempP, i - 1).Value = Format(tempR, "0.00")
                    tempP += 1
                Next
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try

            writeINI(sfile, "gameSettings", "englishMinValue", txtValueMin.Text)
            writeINI(sfile, "gameSettings", "englishMaxValue", txtValueMax.Text)

            For i As Integer = 1 To tempC
                writeINI(sfile, "englishValues", CStr(i), dg1(1, i - 1).Value)

                Dim tempS As String = ""
                For j As Integer = 2 To dg2.ColumnCount
                    tempS &= dg2(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "englishSignals", CStr(i), tempS)
            Next

            For i As Integer = 1 To dg3.RowCount

                Dim tempS As String = ""

                For j As Integer = 2 To dg3.ColumnCount
                    tempS &= dg3(j - 1, i - 1).Value & ";"
                Next

                writeINI(sfile, "englishGroups", CStr(i), tempS)
            Next

            For i As Integer = 1 To dg4.RowCount
                writeINI(sfile, "englishTiming", CStr(i + 1), dg4(1, i - 1).Value)
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As Object, e As EventArgs) Handles cmdCopyDown.Click
        Try
            For i As Integer = dg3.CurrentCell.RowIndex + 1 To dg3.RowCount - 1
                dg3(dg3.CurrentCell.ColumnIndex, i).Value = dg3.CurrentCell.Value
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class