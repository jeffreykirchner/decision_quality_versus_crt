Public Class frmLottery
    'spinner stuff
    Public mainScreen As Screen

    Dim rect1 As New Rectangle(-95, -95, 190, 190)
    Dim f1 As New Font("Calibri", "10")
    Dim f14 As New Font("Calibri", "30")
    Dim fmt As New StringFormat
    Dim pArrow As New Pen(Brushes.Black, 1)

    Dim tempDStart As Double = -90
    Public tempDIncrement As Double = 360 / 100
    Public tempTickCount As Integer = 100
    Dim tempRadius As Double

    Dim randomArrowCount As Integer
    Dim randomArrowTarget As Integer

    Public spinCount As Integer = 0
    Public spinnerTargetNumber As Integer = 30

    'period results
    Public tempChoice As String
    Public tempPayoutTicket As Integer
    Public tempPayoutIndex As Integer
    Public tempLotteryEarnings As Integer

    Public timeRemaining As Integer = 0

    Private Sub frmLottery_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            'if ALT+K are pressed kill the client
            'if ALT+Q are pressed bring up connection box
            If e.Alt = True Then
                If CInt(e.KeyValue) = CInt(Keys.K) Then
                    If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    closeClient()
                ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                    frmConnect.Show()
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgFraming_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFraming.CellClick, dgFraming.CellDoubleClick
        Try
            dgFraming.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub rbRed_CheckedChanged(sender As Object, e As EventArgs) Handles rbRed.CheckedChanged
        Try
            For j As Integer = 1 To dgFraming.ColumnCount
                dgFraming(j - 1, 0).Style.ForeColor = Color.Yellow
            Next

            For j As Integer = 1 To dgFraming.ColumnCount
                dgFraming(j - 1, 1).Style.ForeColor = Color.Black
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub rbBlue_CheckedChanged(sender As Object, e As EventArgs) Handles rbBlue.CheckedChanged
        Try
            For j As Integer = 1 To dgFraming.ColumnCount
                dgFraming(j - 1, 0).Style.ForeColor = Color.Black
            Next

            For j As Integer = 1 To dgFraming.ColumnCount
                dgFraming(j - 1, 1).Style.ForeColor = Color.Yellow
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try

            cmdSubmitAction(False)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub cmdSubmitAction(autoClick As Boolean)
        Try

            If cmdSubmit.Text = "Submit" Then

                If showInstructions Then

                    Exit Sub
                Else
                    Dim str As String = ""

                    If rbRed.Checked Then
                        str = "Red;"
                    ElseIf rbBlue.Checked Then
                        str = "Blue;"
                    Else
                        Exit Sub
                    End If

                    ' pnlFraming.Visible = False

                    cmdSubmit.Visible = False
                    txtTimeRemaining.Visible = False
                    lblTimeRemaining.Visible = False

                    Timer3.Enabled = False
                    lbl1.Text = "Waiting for others."

                    rbBlue.Enabled = False
                    rbRed.Enabled = False

                    str &= autoClick & ";"

                    frmClient.AC.sendMessage("01", str)
                End If

            Else
                cmdSubmit.Visible = False
                lbl1.Text = "Waiting for others."

                frmClient.AC.sendMessage("03", "")
            End If



        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgResults_MouseClick(sender As Object, e As MouseEventArgs) Handles dgResults.MouseClick
        Try
            If dgResults.RowCount > 0 Then dgResults.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgResults_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgResults.MouseDoubleClick
        Try
            If dgResults.RowCount > 0 Then dgResults.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmLottery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If dgResults.RowCount > 0 Then dgResults.CurrentCell.Selected = False

            'spinner
            mainScreen = New Screen(pnlMain, New Rectangle(0, 0, pnlMain.Width, pnlMain.Height))
            pArrow.CustomEndCap = New Drawing2D.AdjustableArrowCap(8, 8, True)
            fmt.Alignment = StringAlignment.Center

            tempTickCount = 100

            rect1 = New Rectangle(-(pnlMain.Width - 20) / 2, -(pnlMain.Height - 20) / 2, pnlMain.Width - 20, pnlMain.Height - 20)
            tempRadius = rect1.Width / 2

            Timer1.Enabled = True

            randomArrowCount = -1

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            refreshScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshScreen()
        Try
            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.TranslateTransform(mainScreen.screenWidth / 2, mainScreen.screenHeight / 2)

            g.DrawEllipse(Pens.Black, rect1)

            'draw ticks
            tempDStart = -90
            For i As Integer = 1 To tempTickCount
                g.DrawLine(Pens.Black,
                           New Point(Math.Round((tempRadius - 10) * Math.Cos(tempDStart * (Math.PI / 180))),
                                     Math.Round((tempRadius - 10) * Math.Sin(tempDStart * (Math.PI / 180)))),
                           New Point(Math.Round(tempRadius * Math.Cos(tempDStart * (Math.PI / 180))),
                                     Math.Round(tempRadius * Math.Sin(tempDStart * (Math.PI / 180)))))

                If i Mod 2 = 1 And
                   Not randomArrowCount Mod tempTickCount = i And
                   ((randomArrowCount = 0 And spinnerTargetNumber <> i) Or randomArrowCount <> 0) Then
                    g.DrawString(CStr(i),
                                f1,
                                Brushes.Black,
                                New Point((tempRadius - 20) * Math.Cos(tempDStart * (Math.PI / 180)),
                                            (tempRadius - 20) * Math.Sin(tempDStart * (Math.PI / 180)) - 7),
                                fmt)
                End If


                tempDStart += tempDIncrement
            Next

            If randomArrowCount = -1 Then
                g.DrawLine(pArrow,
                          New Point(Math.Round(-tempRadius / 3 * Math.Cos(-90 * (Math.PI / 180))),
                                   Math.Round(-tempRadius / 3 * Math.Sin(-90 * (Math.PI / 180)))),
                          New Point(Math.Round(tempRadius * Math.Cos(-90 * (Math.PI / 180))),
                                    Math.Round(tempRadius * Math.Sin(-90 * (Math.PI / 180)))))

                g.FillEllipse(Brushes.Black,
                              CInt(Math.Round(-tempRadius / 3 * Math.Cos(-90 * (Math.PI / 180)))) - 15,
                              CInt(Math.Round(-tempRadius / 3 * Math.Sin(-90 * (Math.PI / 180)))) - 15,
                              30,
                              30)


            ElseIf randomArrowCount = 0 Then

                Dim p1 As Point = New Point(Math.Round(tempRadius * Math.Cos((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))),
                                     Math.Round(tempRadius * Math.Sin((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))))

                Dim p2 As Point = New Point(Math.Round(-tempRadius / 3 * Math.Cos((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))),
                                     Math.Round(-tempRadius / 3 * Math.Sin((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))))

                Dim p3 As Point = New Point(Math.Round((tempRadius - 40) * Math.Cos((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))),
                                     Math.Round((tempRadius - 40) * Math.Sin((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180))) - 25)

                g.DrawLine(pArrow, p2, p1)

                g.FillEllipse(Brushes.Black,
                             CInt(Math.Round(-tempRadius / 3 * Math.Cos((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180)))) - 15,
                             CInt(Math.Round(-tempRadius / 3 * Math.Sin((tempDIncrement * (spinnerTargetNumber - 1) - 90) * (Math.PI / 180)))) - 15,
                             30,
                             30)

                g.DrawString(spinnerTargetNumber, f14, Brushes.Black, p3.X + 1, p3.Y + 1, fmt)
                g.DrawString(spinnerTargetNumber, f14, Brushes.Yellow, p3, fmt)

            Else
                Dim p1 As Point = New Point(tempRadius * Math.Cos((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)),
                                tempRadius * Math.Sin((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)))

                Dim p2 As Point = New Point(-tempRadius / 3 * Math.Cos((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)),
                                -tempRadius / 3 * Math.Sin((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)))

                Dim p3 As Point = New Point((tempRadius - 40) * Math.Cos((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)),
                                (tempRadius - 40) * Math.Sin((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)) - 25)

                g.DrawLine(pArrow, p2, p1)

                g.FillEllipse(Brushes.Black,
                            CInt(Math.Round(-tempRadius / 3 * Math.Cos((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180)))) - 18,
                            CInt(-tempRadius / 3 * Math.Sin((tempDIncrement * (randomArrowCount - 1) - 90) * (Math.PI / 180))) - 15,
                            30,
                            30)

                Dim tempT As Integer = randomArrowCount Mod tempTickCount
                If tempT = 0 Then tempT = 100

                g.DrawString(tempT, f14, Brushes.Black, p3.X + 1, p3.Y + 1, fmt)
                g.DrawString(tempT, f14, Brushes.Yellow, p3, fmt)
            End If


            g.FillEllipse(Brushes.DimGray, -10, -10, 20, 20)
            g.FillEllipse(Brushes.Black, -3, -3, 6, 6)

            g.ResetTransform()
            mainScreen.flip()

            If cmdSubmit.Text = "Ready to Go On" Then

                If cmdSubmit.BackColor = Color.FromArgb(192, 255, 192) Then
                    cmdSubmit.BackColor = SystemColors.ButtonFace
                Else
                    cmdSubmit.BackColor = Color.FromArgb(192, 255, 192)
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Dim intervalAdjustment As Double = 10
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            randomArrowCount += 1
            If randomArrowCount = randomArrowTarget Then
                Timer2.Enabled = False
                randomArrowCount = 0

                showPostSpinResults()

                'If spinCount = 1 Then
                '    cmdSpin.Visible = True
                'Else
                '    Dim outstr As String = ""

                '    outstr &= randomChoice(1) & ";"
                '    outstr &= randomChoice(2) & ";"

                '    wskClient.Send("08", outstr)
                'End If
            End If

            intervalAdjustment = intervalAdjustment ^ (1.003 + ((tempTickCount - spinnerTargetNumber) / 18000))
            Timer2.Interval = Math.Round(intervalAdjustment)

            refreshScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub showPostSpinResults()
        Try
            cmdSubmit.Text = "Ready to Go On"
            cmdSubmit.Visible = True

            lbl1.Text = "Press Ready to Go On"

            'un highlight row
            For j As Integer = 1 To dgFraming.ColumnCount
                dgFraming(j - 1, 0).Style.ForeColor = Color.Black
                dgFraming(j - 1, 1).Style.ForeColor = Color.Black
            Next

            'highlight winner
            Dim tempI As Integer = (tempPayoutIndex - 1) * 3
            If tempChoice = "Red" Then
                dgFraming(tempI, 0).Style.ForeColor = Color.Yellow
                dgFraming(tempI + 1, 0).Style.ForeColor = Color.Yellow
            Else
                dgFraming(tempI, 1).Style.ForeColor = Color.Yellow
                dgFraming(tempI + 1, 1).Style.ForeColor = Color.Yellow
            End If

            'fill history table
            If tempChoice = "Red" Then
                'ticket number
                dgResults(6, 0).Value = tempPayoutTicket
                dgResults(6, 1).Value = "-"

                'select winning cell
                dgResults(tempPayoutIndex, 0).Style.ForeColor = Color.Yellow

                'earnings
                dgResults(7, 0).Value = tempLotteryEarnings & "¢"
                dgResults(7, 1).Value = "-"
            Else
                'ticket number
                dgResults(6, 0).Value = "-"
                dgResults(6, 1).Value = tempPayoutTicket

                'select winning cell
                dgResults(tempPayoutIndex, 1).Style.ForeColor = Color.Yellow

                'earnings
                dgResults(7, 0).Value = "-"
                dgResults(7, 1).Value = tempLotteryEarnings & "¢"
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub startSpinner(tempPayoutTicket As Integer)
        Try
            tempDStart = -90
            spinCount = 0
            Timer2.Interval = 10
            intervalAdjustment = 10
            randomArrowCount = 0

            spinnerTargetNumber = tempPayoutTicket

            tempTickCount = lotteryTicketCount
            tempDIncrement = 360 / tempTickCount

            randomArrowTarget = tempTickCount + spinnerTargetNumber

            Timer2.Enabled = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            If timeRemaining = 0 Then

                Timer3.Enabled = False

                If cmdSubmit.Visible Then
                    If Not rbBlue.Checked And Not rbRed.Checked Then
                        If rand(2, 1) = 1 Then
                            rbBlue.Checked = True
                        Else
                            rbRed.Checked = True
                        End If
                    End If

                    cmdSubmitAction(True)
                End If

            Else
                timeRemaining -= 1
                txtTimeRemaining.Text = timeConversion(timeRemaining)
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmLottery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not clientClosing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class