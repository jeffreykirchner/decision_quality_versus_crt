Public Class frmInstructions
    Public startPressed As Boolean = False
    Dim numberOfPages As Integer = 26
    Public pagesDone(100) As Boolean

    ' example pages
    Public exp1 As Integer = 21
    Public exp2 As Integer = 24
    Public exp3 As Integer = 26

    ' quiz pages
    Public eqp1 As Integer = 12
    Public eqp2 As Integer = 13
    Public eqp3 As Integer = 14
    Public eqp4 As Integer = 15
    Public eqp5 As Integer = 16
    Public eqp6 As Integer = 17

    Public quizResult(100) As String
    Public quizAnswer(100) As String
    Public quizResultText(100) As String

    'english PV
    Public firstSide As String = ""
    Public englishPVBidLarge As Double = 500
    Public englishPVBidSmall As Double = 500

    Private Sub frmInstructions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For i As Integer = 1 To numberOfPages
                pagesDone(i) = False
            Next

            startPressed = False
            currentInstruction = 1


            If currentPhase = "Lottery" And subPeriod = 1 Then
                numberOfPages = 11

                eqp1 = 6
                eqp2 = 7
                eqp3 = 8
                eqp4 = 9

                quizResultText(eqp1) = "If you choose Red and the winning number is " & lotteryRedTicketCounts(1) & ", you will receive Payout A, which is " & lotteryRedTicketValues(1) & "¢."
                quizResultText(eqp2) = "If you choose Blue and the winning number is " & lotteryBlueTicketCounts(1) & ", you will receive Payout A, which is " & lotteryBlueTicketValues(1) & "¢."
                quizResultText(eqp3) = "If you choose Red and the winning number is " & lotteryRedTicketCounts(2) + lotteryRedTicketCounts(1) & ", you will receive Payout B, which is " & lotteryRedTicketValues(2) & "¢."
                quizResultText(eqp4) = "If you choose Blue and the winning number is " & lotteryBlueTicketCounts(2) + lotteryBlueTicketCounts(1) & ", you will receive Payout B, which is " & lotteryBlueTicketValues(2) & "¢."

            ElseIf currentPhase = "English Auction" And subPeriod = 1 Then
                exp1 = 4
                exp2 = 5
                exp3 = 6

                numberOfPages = 15

                eqp1 = 10
                eqp2 = 11
                eqp3 = 12
                eqp4 = 13
                eqp5 = 14

                quizResultText(eqp1) = "Profit = (Your Value) - (Last Dropout Price)" & vbCrLf & "$4 = $15 - $11"
                quizResultText(eqp2) = "Only the remaining participant earns profit, everyone that clicks ""Do Not Buy"" will earn zero for that period."
                quizResultText(eqp3) = "As long as your Cash Balance does not drop below zero you may continue."
                quizResultText(eqp4) = "If your Cash Balance drops below zero you may not continue."
                quizResultText(eqp5) = "The actual value of the item will not be greater than " & Format(secondPriceEndValue, "0.00") & "."

                If frmSecondPrice.currentSide = "small" Then
                    firstSide = "small"
                Else
                    firstSide = "large"
                End If
            ElseIf currentPhase = "2nd Price" And subPeriod = 1 Then
                exp1 = 4
                exp2 = 5
                exp3 = 6

                numberOfPages = 15

                eqp1 = 10
                eqp2 = 11
                eqp3 = 12
                eqp4 = 13
                eqp5 = 14

                quizResultText(eqp1) = "Profit = (Your Value) - (Second Highest Bid)" & vbCrLf & "$4 = $15 - $11"
                quizResultText(eqp2) = "Only the highest bidder earns profit, everyone else earns zero for that period."
                quizResultText(eqp3) = "As long As your Cash Balance does not drop below zero you may continue."
                quizResultText(eqp4) = "If your cash balance drops below zero you may not continue."
                quizResultText(eqp5) = "The actual value of the item will not be greater than " & Format(secondPriceEndValue, "0.00") & "."

            ElseIf currentPhase = "CV Full Info" Or currentPhase = "CV Limited Info" And subPeriod = 1 Then
                If englishBidMode = "full" Then
                    eqp1 = 10
                    eqp2 = 11
                    eqp3 = 12
                    eqp4 = 13
                    eqp5 = 14
                    eqp6 = 30

                    quizResultText(eqp1) = "Profit = (Actual Value) - (Highest Bid)" & vbCrLf & "$5 = $75 - $70"
                    'quizResultText(eqp2) = "Only the highest bidder earns profit, everyone Else earns zero For that period."
                    quizResultText(eqp2) = "As long as your Cash Balance does nNot drop below zero you may continue."
                    quizResultText(eqp3) = "If your Cash Balance drops below zero you may not Continue."
                    quizResultText(eqp4) = "The actual value of the item will not be greater than " & englishMaxValue & "."
                    quizResultText(eqp5) = "The actual value of the item will not be lower than " & englishMinValue & "."

                    numberOfPages = 19

                    exp1 = 17
                    exp2 = 24
                    exp3 = 26

                    englishSignal = 24.37
                Else
                    eqp1 = 11
                    eqp2 = 12
                    eqp3 = 13
                    eqp4 = 14
                    eqp5 = 15
                    eqp6 = 16

                    quizResultText(eqp1) = "Profit = (Actual Value) - (Second Highest Bid)" & vbCrLf & "$15 = $75 - $60"
                    quizResultText(eqp2) = "Only the highest buyer earns profit, everyone Else earns zero For that period."
                    quizResultText(eqp3) = "As Long As your Cash Balance does Not drop below zero you may Continue."
                    quizResultText(eqp4) = "If your cash balance drops below zero you may Not Continue."
                    quizResultText(eqp5) = "The Actual Value Of the item will Not be greater than " & englishMaxValue & "."
                    quizResultText(eqp6) = "The Actual Value Of the item will Not be lower than " & englishMinValue & "."

                    numberOfPages = 21

                    exp1 = 20
                End If

            End If

            nextInstruction()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub nextInstruction()
        Try

            Dim folder As String = ""

            If currentPhase = "Lottery" And subPeriod = 1 Then

                folder = "Lottery"
            ElseIf currentPhase = "English Auction" Then
                folder = "English_Private_Value"
            ElseIf currentPhase = "2nd Price" And subPeriod = 1 Then

                folder = "2ndPrice"
            ElseIf currentPhase = "CV Full Info" Or currentPhase = "CV Limited Info" And subPeriod = 1 Then

                If englishBidMode = "full" Then
                    folder = "CommonValue\1stPrice"
                Else
                    folder = "CommonValue\English"
                End If
            End If

            RichTextBox1.LoadFile(Application.StartupPath &
               "\instructions\" & folder & "\page" & currentInstruction & ".rtf")

            If Not startPressed Then
                frmClient.AC.sendMessage("INSTRUCTION_PAGE", currentInstruction & ";")
            End If

            Dim maxPages As Integer = 0

            If currentPhase = "Lottery" And subPeriod = 1 Then
                variablesLottery()
            ElseIf currentPhase = "English Auction" Then
                variablesEnglishPV()
            ElseIf currentPhase = "2nd Price" And subPeriod = 1 Then

                variablesSecondPrice()
            ElseIf currentPhase = "CV Full Info" Or currentPhase = "CV Limited Info" And subPeriod = 1 Then
                If englishBidMode = "full" Then
                    variablesCVFull()
                Else
                    variablesCVEnglish()
                End If

            End If

            Text = "Instructions, Page " & currentInstruction & "/" & numberOfPages

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Try

            If Not pagesDone(currentInstruction) Then Exit Sub

            cmdBack.Visible = True

            If currentInstruction = numberOfPages Then Exit Sub

            currentInstruction += 1

            If currentInstruction = numberOfPages And Not startPressed Then
                cmdStart.Visible = True
            End If

            If currentInstruction = numberOfPages Then
                cmdNext.Visible = False
            End If

            nextInstruction()

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Try
            cmdStart.Visible = False
            startPressed = True

            Dim outstr As String = ""
            Dim tempC As Integer = 0

            For i As Integer = 1 To numberOfPages
                If i = eqp1 Or i = eqp2 Or i = eqp3 Or i = eqp4 Or i = eqp5 Or i = eqp6 Then

                    tempC += 1

                    outstr &= quizResult(i) & ";"
                    outstr &= quizAnswer(i) & ";"
                End If
            Next

            outstr = tempC & ";" & outstr

            frmClient.AC.sendMessage("FINSHED_INSTRUCTIONS", outstr)
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Try
            If Timer1.Enabled Then Exit Sub

            cmdNext.Visible = True

            'previous page of instructions

            If currentInstruction = 1 Then Exit Sub

            currentInstruction -= 1

            If currentInstruction = 1 Then cmdBack.Visible = False

            nextInstruction()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variablesLottery()
        Try
            RepRTBfield2("numberOfColumns", lotteryChoiceCount)
            RepRTBfield2("numberOfPeriods", numberOfPeriods)
            RepRTBfield2("ticketCount", lotteryTicketCount)
            RepRTBfield2("quizQuestionValue", Format(quizQuestionValue, "0.00"))
            RepRTBfield2("periodLength", lotteryPeriodLength)

            RepRTBfield2("winningRed1", lotteryRedTicketCounts(1))
            RepRTBfield2("winningRed2", lotteryRedTicketCounts(2) + lotteryRedTicketCounts(1))
            RepRTBfield2("winningBlue1", lotteryBlueTicketCounts(1))
            RepRTBfield2("winningBlue2", lotteryBlueTicketCounts(2) + lotteryBlueTicketCounts(1))

            RepRTBfield2("RedWinNumA", frmLottery.dgFraming(1, 0).Value)
            RepRTBfield2("RedWinNumB", frmLottery.dgFraming(4, 0).Value)
            RepRTBfield2("RedWinNumC", frmLottery.dgFraming(7, 0).Value)
            RepRTBfield2("RedWinNumD", frmLottery.dgFraming(10, 0).Value)

            RepRTBfield2("RedPayoutA", frmLottery.dgFraming(0, 0).Value)
            RepRTBfield2("RedPayoutB", frmLottery.dgFraming(3, 0).Value)
            RepRTBfield2("RedPayoutC", frmLottery.dgFraming(6, 0).Value)
            RepRTBfield2("RedPayoutD", frmLottery.dgFraming(9, 0).Value)

            Select Case currentInstruction
                Case 1, 4, 5, 10, 11
                    If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                Case 2

                    If Not pagesDone(currentInstruction) Then
                        frmLottery.Show()
                        pagesDone(currentInstruction) = True
                    End If
                Case 3
                    If Not pagesDone(currentInstruction) Then
                        showLotterySpinner()
                        pagesDone(currentInstruction) = True
                    End If
                Case eqp1 To eqp4
                    If Not pagesDone(currentInstruction) Then
                        gbQuiz.Visible = True
                        txtQuiz.Text = ""
                        RepRTBfield2("result", "Type your answer below and press Submit")
                    Else
                        RepRTBfield2("result", "Your Answer: " & quizAnswer(currentInstruction) & vbCrLf &
                                     quizResult(currentInstruction) & "." & vbCrLf &
                                     quizResultText(currentInstruction))

                        gbQuiz.Visible = False
                    End If
            End Select
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variablesEnglishPV()
        Try
            With frmSecondPrice
                RepRTBfield2("StartValue", Format(secondPriceStartValue, "0.00"))
                RepRTBfield2("EndValue", Format(secondPriceEndValue, "0.00"))
                RepRTBfield2("englishPVTickAmount", Format(englishTickAmountPV, "0.00"))
                RepRTBfield2("englishPVTickRate", Format(englishTickRatePV / 1000, "0.00"))
                RepRTBfield2("MaxBid", Format(secondPriceMaxBid, "0.00"))
                RepRTBfield2("LargeGroupSize", secondPriceNumberOfPlayersLarge)
                RepRTBfield2("SmallGroupSize", secondPriceNumberOfPlayersSmall)
                RepRTBfield2("StartingCash", secondPriceStartingCash)
                RepRTBfield2("quizQuestionValue", Format(quizQuestionValue, "0.00"))

                If firstSide = "small" Then
                    RepRTBfield2("firstMarket", "small")
                    RepRTBfield2("secondMarket", "large")
                Else
                    RepRTBfield2("firstMarket", "large")
                    RepRTBfield2("secondMarket", "small")
                End If

                Select Case currentInstruction

                    Case 3, 7, 8, 9
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False

                    Case 1
                        .txtValueLeft.Text = "20.49"
                        .txtValueRight.Text = "20.49"
                        .cmdSubmitLargeEnglish.Visible = False
                        .cmdSubmitSmallEnglish.Visible = False
                        .lblInfoLeft.Visible = False
                        .txtBidRight.Text = "0.00"
                        .txtBidLeft.Text = "0.00"

                        .gbBidLeft.Visible = True
                        .gbBidRight.Visible = True

                        .lblInfoLeft.Text = "Once the Price is too high press Do Not Buy."

                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                    Case 2
                        If Not pagesDone(currentInstruction) Then

                            If firstSide = "small" Then
                                .cmdSubmitSmallEnglish.Visible = True
                            Else
                                .cmdSubmitLargeEnglish.Visible = True
                            End If

                            pagesDone(currentInstruction) = True

                        End If

                    Case 4, 5, 6

                        Dim tempExample As Integer

                        If currentInstruction = 4 Then
                            tempExample = 1
                        ElseIf currentInstruction = 5 Then
                            tempExample = 2
                        Else
                            tempExample = 3
                        End If

                        Dim tempV As Double
                        tempV = secondPriceExamplesLarge(tempExample).Split(",")(0)
                        tempV = tempV / 100

                        RepRTBfield2("myValue", Format(tempV, "0.00"))

                        If Not pagesDone(currentInstruction) Then

                            If firstSide = "small" Then
                                .cmdSubmitSmallEnglish.Visible = True
                            Else
                                .cmdSubmitLargeEnglish.Visible = True
                            End If

                            .currentSide = firstSide
                            .lblInfoLeft.Visible = True

                            englishPVBidLarge = 500
                            englishPVBidSmall = 500

                            .smallBid = 0
                            .largeBid = 0

                            .txtBidLeft.Text = "0.00"
                            .txtBidRight.Text = "0.00"

                            .txtValueLeft.Text = Format(tempV, "0.00")
                            .txtValueRight.Text = Format(tempV, "0.00")

                            .smallDone = False
                            .largeDone = False

                            .txtProfitLeft.Text = ""
                            .txtProfitRight.Text = ""

                            .setupEnglish2()

                            'dont show results yet
                            RichTextBox1.Select(RichTextBox1.Find("#result#"), RichTextBox1.TextLength - RichTextBox1.Find("#result#"))
                            RichTextBox1.SelectedText = " "

                            Timer2.Interval = englishTickRatePV
                            Timer2.Enabled = True
                            cmdBack.Visible = False
                        Else
                            Dim tempRow As Integer

                            For i As Integer = 1 To .dgMyBidsLeft.RowCount
                                If .dgMyBidsLeft(0, i - 1).Value = tempExample Then tempRow = i
                            Next

                            RepRTBfield2("result", vbCrLf & "Result:" & vbCrLf)

                            RepRTBfield2("secondHighestBidLarge", .dgMainLeft(2, tempRow - 1).Value)
                            RepRTBfield2("secondHighestBidSmall", .dgMainRight(2, tempRow - 1).Value)

                            Dim tempS As String = ""
                            If .dgMyBidsLeft(2, tempRow - 1).Value = "Yes" Then
                                tempS = "$" & .dgMyBidsLeft(5, tempRow - 1).Value & " (your value) minus $" & .dgMyBidsLeft(7, tempRow - 1).Value & " (the last dropout price) = " & FormatCurrency(.dgMyBidsLeft(9, tempRow - 1).Value,,, TriState.False)
                            Else
                                tempS = "Zero, you did not win the Large Market."
                            End If

                            RepRTBfield2("payoffLarge", tempS)

                            tempS = ""
                            If .dgMyBidsRight(2, tempRow - 1).Value = "Yes" Then
                                tempS = "$" & .dgMyBidsRight(5, tempRow - 1).Value & " (your value) minus $" & .dgMyBidsRight(7, tempRow - 1).Value & " (the last dropout price) = " & FormatCurrency(.dgMyBidsRight(9, tempRow - 1).Value,,, TriState.False)
                            Else
                                tempS = "Zero, you did not win the Small Market."
                            End If

                            RepRTBfield2("payoffSmall", tempS)
                        End If


                    Case eqp1 To eqp5
                        If Not pagesDone(currentInstruction) Then
                            gbQuiz.Visible = True
                            txtQuiz.Text = ""
                            RepRTBfield2("result", "Type your answer below and press Submit")
                        Else
                            RepRTBfield2("result", "Your Answer: " & quizAnswer(currentInstruction) & vbCrLf &
                                         quizResult(currentInstruction) & "." & vbCrLf &
                                         quizResultText(currentInstruction))

                            gbQuiz.Visible = False
                        End If
                End Select
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variablesSecondPrice()
        Try
            With My.Forms.frmSecondPrice
                RepRTBfield2("StartValue", Format(secondPriceStartValue, "0.00"))
                RepRTBfield2("EndValue", Format(secondPriceEndValue, "0.00"))
                RepRTBfield2("LargeGroupSize", secondPriceNumberOfPlayersLarge)
                RepRTBfield2("SmallGroupSize", secondPriceNumberOfPlayersSmall)
                RepRTBfield2("StartingCash", secondPriceStartingCash)
                RepRTBfield2("quizQuestionValue", Format(quizQuestionValue, "0.00"))
                RepRTBfield2("MaxBid", Format(secondPriceMaxBid, "0.00"))

                Select Case currentInstruction
                    Case 2, 3, 7, 8, 9
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False

                    Case 1
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                            .txtValueLeft.Text = "20.49"
                            .txtValueRight.Text = "20.49"

                            .cmdSubmit.Visible = True
                            .gbBidLeft.Visible = True
                            .gbBidRight.Visible = True

                            .lblInfoLeft.Visible = False

                        End If
                    Case 4, 5, 6

                        Dim tempExample As Integer

                        If currentInstruction = 4 Then
                            tempExample = 1
                        ElseIf currentInstruction = 5 Then
                            tempExample = 2
                        Else
                            tempExample = 3
                        End If

                        Dim tempV As Double
                        tempV = secondPriceExamplesLarge(tempExample).Split(",")(0)
                        tempV = tempV / 100
                        RepRTBfield2("myValue", Format(tempV, "0.00"))

                        If Not pagesDone(currentInstruction) Then
                            .txtValueLeft.Text = Format(tempV, "0.00")
                            .txtValueRight.Text = Format(tempV, "0.00")

                            'dont show results yet
                            RichTextBox1.Select(RichTextBox1.Find("#result#"), RichTextBox1.TextLength - RichTextBox1.Find("#result#"))
                            RichTextBox1.SelectedText = " "

                            .cmdSubmit.Visible = True
                            .txtBidLeft.Text = ""
                            .txtBidRight.Text = ""
                        Else

                            Dim tempRow As Integer

                            For i As Integer = 1 To .dgMyBidsLeft.RowCount
                                If .dgMyBidsLeft(0, i - 1).Value = tempExample Then tempRow = i
                            Next

                            RepRTBfield2("result", vbCrLf & "Result:" & vbCrLf)

                            RepRTBfield2("secondHighestBidLarge", .dgMainLeft(2, tempRow - 1).Value)
                            RepRTBfield2("secondHighestBidSmall", .dgMainRight(2, tempRow - 1).Value)

                            Dim tempS As String = ""
                            If .dgMyBidsLeft(2, tempRow - 1).Value = "Yes" Then
                                tempS = "$" & .dgMyBidsLeft(5, tempRow - 1).Value & "(your value) minus $" & .dgMyBidsLeft(7, tempRow - 1).Value & " (the second highest bid) = " & FormatCurrency(.dgMyBidsLeft(9, tempRow - 1).Value,,, TriState.False)
                            Else
                                tempS = "Zero, you did not win the Large Market."
                            End If

                            RepRTBfield2("payoffLarge", tempS)

                            tempS = ""
                            If .dgMyBidsRight(2, tempRow - 1).Value = "Yes" Then
                                tempS = "$" & .dgMyBidsRight(5, tempRow - 1).Value & "(your value) minus $" & .dgMyBidsRight(7, tempRow - 1).Value & " (the second highest bid) = " & FormatCurrency(.dgMyBidsRight(9, tempRow - 1).Value,,, TriState.False)
                            Else
                                tempS = "Zero, you did not win the Small Market."
                            End If

                            RepRTBfield2("payoffSmall", tempS)
                        End If


                    Case eqp1 To eqp5
                        If Not pagesDone(currentInstruction) Then
                            gbQuiz.Visible = True
                            txtQuiz.Text = ""
                            RepRTBfield2("result", "Type your answer below and press Submit")
                        Else
                            RepRTBfield2("result", "Your Answer: " & quizAnswer(currentInstruction) & vbCrLf &
                                         quizResult(currentInstruction) & "." & vbCrLf &
                                         quizResultText(currentInstruction))

                            gbQuiz.Visible = False
                        End If


                End Select
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variablesCVEnglish()
        Try
            With My.Forms.frmEnglish
                'globals
                RepRTBfield2("startingPrice", Format(englishStartPrice, "0.00"))
                RepRTBfield2("priceIncrement4", Format(englishTickAmount(4), "0.00"))
                RepRTBfield2("priceIncrement3", Format(englishTickAmount(3), "0.00"))
                RepRTBfield2("priceIncrement2", Format(englishTickAmount(2), "0.00"))
                RepRTBfield2("maxPrice", Format(englishEndPrice, "0.00"))
                RepRTBfield2("quizQuestionValue", FormatCurrency(quizQuestionValue))
                RepRTBfield2("englishStartingCash", FormatCurrency(englishStartingCash))
                RepRTBfield2("minValue", Format(englishMinValue, "0.00"))
                RepRTBfield2("maxValue", Format(englishMaxValue, "0.00"))

                Select Case currentInstruction
                    Case 1
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                            englishBidderCount = 4
                        End If
                    Case 2 To 7, 9, 17, 18
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False
                    Case 8
                        If Not pagesDone(currentInstruction) Then
                            englishValue = 128.16
                            englishSignal = 123.37
                            englishPhase = "result"
                            .pnlKeyValue.Visible = True
                            .lblKeyValue.Visible = True
                            englishBidderCount = 1

                            pagesDone(currentInstruction) = True
                        End If
                    Case 10
                        If Not pagesDone(currentInstruction) Then
                            englishPhase = "start"
                            englishSignal = 66
                            .pnlKeyValue.Visible = False
                            .lblKeyValue.Visible = False
                            pagesDone(currentInstruction) = True

                            englishBidderCount = 4
                        End If
                    Case 11 To 16
                        If Not pagesDone(currentInstruction) Then
                            gbQuiz.Visible = True
                            txtQuiz.Text = ""
                            RepRTBfield2("result", "Type your answer below and press Submit")
                        Else
                            RepRTBfield2("result", "Your Answer: " & quizAnswer(currentInstruction) & vbCrLf &
                                     quizResult(currentInstruction) & "." & vbCrLf &
                                     quizResultText(currentInstruction))

                            gbQuiz.Visible = False
                        End If

                    Case 19
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                            englishPhase = "start"
                        End If
                    Case 20
                        If Not pagesDone(currentInstruction) Then

                            If .cmdDontBuy.Visible Then
                                englishPrice = englishStartPrice
                                Timer1.Enabled = True
                                englishPhase = "play"
                                .cmdUpdateBid.Enabled = False
                                englishBidderCount = 4
                                '  .pnl1.Visible = True
                                .txtInfo.Visible = False
                            End If
                        End If
                    Case 21
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True

                            englishSignal = 73
                            englishBidderCount = 2
                            englishBid = 79
                            'englishNewBid = 79
                            englishValue = 70
                            englishPrice = 76

                            .txtCash.Text = "4.00"

                            .dg1.Rows.Insert(0, "2", "Yes", "70.00", "76.00", "-6.00", "", "-/73.00", "76.00/70.00")
                            .dg1(5, 0).Style.BackColor = Color.DimGray
                            .dg1(2, 0).Style.ForeColor = Color.Green
                            .dg1(4, 0).Style.ForeColor = Color.Red
                            .dg1(6, 0).Style.ForeColor = Color.Green
                            .dg1.CurrentCell.Selected = False
                        End If
                End Select

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub variablesCVFull()
        Try
            With My.Forms.frmEnglish
                'globals
                RepRTBfield2("startingPrice", Format(englishStartPrice, "0.00"))
                RepRTBfield2("priceIncrement", Format(englishTickAmount(7), "0.00"))
                RepRTBfield2("maxPrice", Format(englishEndPrice, "0.00"))
                RepRTBfield2("quizQuestionValue", FormatCurrency(quizQuestionValue))
                RepRTBfield2("FirstPriceStartingCash", FormatCurrency(englishStartingCash))
                RepRTBfield2("minValue", Format(englishMinValue, "0.00"))
                RepRTBfield2("maxValue", Format(englishMaxValue, "0.00"))

                RepRTBfield2("CVRange", Format(englishRange, "0.00"))
                RepRTBfield2("maxGroupSize", englishMaxGroupSize)

                Select Case currentInstruction
                    Case 1 To 5
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False
                    Case 6
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False

                        Dim v1 As Double = 50 + englishRange

                        RepRTBfield2("v1", Format(v1, "0.00"))
                    Case 7
                        If Not pagesDone(currentInstruction) Then pagesDone(currentInstruction) = True
                        gbQuiz.Visible = False

                        Dim v1 As Double = 28.16 - englishRange
                        Dim v2 As Double = 28.16 + englishRange

                        Dim v3 As Double = 24.37 - englishRange
                        Dim v4 As Double = 24.37 + englishRange

                        RepRTBfield2("v1", Format(v1, "0.00"))
                        RepRTBfield2("v2", Format(v2, "0.00"))

                        RepRTBfield2("v3", Format(v3, "0.00"))
                        RepRTBfield2("v4", Format(v4, "0.00"))
                    Case 8
                        Dim v1 As Double = 50 + englishRange
                        RepRTBfield2("v1", Format(v1, "0.00"))

                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                        End If
                    Case 9
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                        End If
                    Case 10 To 14
                        If Not pagesDone(currentInstruction) Then
                            gbQuiz.Visible = True
                            txtQuiz.Text = ""
                            RepRTBfield2("result", "Type your answer below and press Submit")
                        Else
                            RepRTBfield2("result", "Your Answer: " & quizAnswer(currentInstruction) & vbCrLf &
                                         quizResult(currentInstruction) & "." & vbCrLf &
                                         quizResultText(currentInstruction))

                            gbQuiz.Visible = False
                        End If
                    Case 15
                        If Not pagesDone(currentInstruction) Then
                            pagesDone(currentInstruction) = True
                        End If
                    Case 16
                        Dim v1 As Double = 66 - englishRange
                        Dim v2 As Double = 66 + englishRange

                        RepRTBfield2("v1", Format(v1, "0.00"))
                        RepRTBfield2("v2", Format(v2, "0.00"))

                        If Not pagesDone(currentInstruction) Then
                            englishSignal = 66
                            pagesDone(currentInstruction) = True
                        End If
                    Case 17

                    Case 18

                        If Not pagesDone(currentInstruction) Then

                            If .dg1.RowCount = 0 Then
                                englishPrice = 70

                                .dg1.Columns.Add(.dg1.Columns(6).Clone)
                                .dg1.Columns(7).HeaderText = "Bid/Signal"
                                .dg1.Rows.Insert(0, "1", "No", "71.00", "70.00", "1.00", "", "70.00/72.00", "66.00/66.00")
                                .dg1(5, 0).Style.BackColor = Color.DimGray
                                .dg1(7, 0).Style.ForeColor = Color.Green
                                .dg1.CurrentCell.Selected = False

                                englishPhase = "result"
                                .lblKeyValue.Visible = True
                                .pnlKeyValue.Visible = True

                                englishValue = 71

                                .cmdReadyToGoOn.Visible = True
                            End If
                        End If
                    Case 19
                        Dim tempS As String = ""
                        If practicePeriods > 0 Then
                            tempS = "We will begin with " & practicePeriods & " ‘practice period(s)’ so you can experience the market without affecting your earnings, followed by the periods that count for real money."
                        End If

                        RepRTBfield2("practicePeriods", tempS)

                        If Not pagesDone(currentInstruction) Then

                            englishPrice = 75
                            englishSignal = 73
                            englishValue = 70

                            .dg1.Rows.Insert(0, "2", "Yes", "70.00", "75.00", "-5.00", "", "75.00/73.00", "68.00/67.00")
                            .dg1(5, 0).Style.BackColor = Color.DimGray
                            .dg1(2, 0).Style.ForeColor = Color.Green
                            .dg1(4, 0).Style.ForeColor = Color.Red
                            .dg1(6, 0).Style.ForeColor = Color.Green
                            .dg1.CurrentCell.Selected = False

                            englishPhase = "result"
                            .lblKeyValue.Visible = True
                            .pnlKeyValue.Visible = True

                            .txtCash.Text = "5.00"

                            pagesDone(currentInstruction) = True
                        End If

                End Select

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function RepRTBfield(ByVal sField As String, ByVal sValue As String) As Boolean
        Try
            'when the instructions are loaded into the rich text box control this function will
            'replace the variable place holders with variables.

            If RichTextBox1.Find("#" & sField & "#") = -1 Then
                RichTextBox1.DeselectAll()
                Return False
            End If

            RichTextBox1.SelectedText = sValue

            Return True
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
            Return False
        End Try
    End Function

    Public Sub RepRTBfield2(ByVal sField As String, ByVal sValue As String)
        Try
            Do While (RepRTBfield(sField, sValue))

            Loop
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            With My.Forms.frmEnglish

                If englishBidMode = "full" Then

                    If currentInstruction = exp1 Then
                        If englishPrice >= 96 Then
                            Timer1.Enabled = False
                            englishPrice = 96
                            englishBidderCount = 1
                            englishBidderFlash = 10
                            .pnl1.Visible = False

                            .dg1.Columns.Add(.dg1.Columns(6).Clone)
                            .dg1.Columns(7).HeaderText = "Bid/Signal"
                            .dg1.Rows.Insert(0, "1", "No", "101.00", "96.00", "5.00", "", "107.00/107.00", "96.00/96.00")
                            .dg1(5, 0).Style.BackColor = Color.DimGray
                            .dg1(7, 0).Style.ForeColor = Color.Green
                            .dg1.CurrentCell.Selected = False

                            englishPhase = "result"
                            .lblKeyValue.Visible = True
                            .pnlKeyValue.Visible = True
                            'englishNewBid = 96
                            englishValue = 101

                            pagesDone(currentInstruction) = True

                        Else
                            englishPrice += englishTickAmount(englishBidderCount)
                        End If
                    ElseIf currentInstruction = exp2 Then

                        If englishPrice >= 96 And englishBid = 107 Then
                            Timer1.Enabled = False
                            englishPrice = 96
                            englishBidderCount = 1
                            englishBidderFlash = 10
                            .pnl1.Visible = False

                            .dg1.Rows.Insert(0, "2", "Yes", "101.00", "96.00", "5.00", "", "107.00/107.00", "96.00/96.00")
                            .dg1(5, 0).Style.BackColor = Color.DimGray
                            .dg1(2, 0).Style.ForeColor = Color.Green
                            .dg1(4, 0).Style.ForeColor = Color.Green
                            .dg1(6, 0).Style.ForeColor = Color.Green
                            .dg1.CurrentCell.Selected = False

                            englishPhase = "result"
                            .lblKeyValue.Visible = True
                            .pnlKeyValue.Visible = True
                            'englishNewBid = 107
                            englishValue = 101

                            .txtCash.Text = "15.00"

                            pagesDone(currentInstruction) = True
                        Else
                            If englishPrice < 96 Then englishPrice += englishTickAmount(englishBidderCount)
                        End If
                    ElseIf currentInstruction = exp3 Then

                    End If
                Else
                    If currentInstruction = exp1 Then
                        If englishPrice >= 66 Then

                            Timer1.Enabled = False
                            englishPrice = 66

                        ElseIf englishPrice >= 60 And englishBidderCount = 4 Then
                            englishBidderCount = 3
                            englishBidderFlash = 10
                        ElseIf englishPrice >= 64 And englishBidderCount = 3 Then
                            englishBidderCount = 2
                            englishBidderFlash = 10
                        Else
                            englishPrice += englishTickAmount(englishBidderCount)
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Sub checkQuizLottery(tempAnswer As String)
        Try
            If currentInstruction = eqp1 Then
                If tempAnswer = CStr(lotteryRedTicketValues(1)) Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If

            ElseIf currentInstruction = eqp2 Then
                If tempAnswer = CStr(lotteryBlueTicketValues(1)) Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp3 Then
                If tempAnswer = CStr(lotteryRedTicketValues(2)) Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp4 Then
                If tempAnswer = CStr(lotteryBlueTicketValues(2)) Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            End If

            pagesDone(currentInstruction) = True
            nextInstruction()
            gbQuiz.Visible = False
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Sub checkQuizSecondPrice(tempAnswer As String)
        Try
            If currentInstruction = eqp1 Then
                If tempAnswer = "4" Or
                   tempAnswer = "four" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If

            ElseIf currentInstruction = eqp2 Then
                If tempAnswer = "" Or
                  tempAnswer = "zero" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp3 Then
                If tempAnswer = "y" Or
                 tempAnswer = "yes" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp4 Then
                If tempAnswer = "n" Or
                tempAnswer = "no" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp5 Then
                If tempAnswer = secondPriceEndValue.ToString Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            End If

            pagesDone(currentInstruction) = True
            nextInstruction()
            gbQuiz.Visible = False
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Sub checkQuizEnglishDropout(tempAnswer As String)
        Try

            If currentInstruction = eqp1 Then
                If tempAnswer = "15" Or
                    tempAnswer = "fifteen" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If

            ElseIf currentInstruction = eqp2 Then
                If tempAnswer = "" Or
                  tempAnswer = "zero" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp3 Then
                If tempAnswer = "y" Or
                     tempAnswer = "yes" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp4 Then
                If tempAnswer = "n" Or
                    tempAnswer = "no" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp5 Then
                If tempAnswer = englishMaxValue.ToString Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp6 Then
                If tempAnswer = englishMinValue.ToString Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            End If

            pagesDone(currentInstruction) = True
            nextInstruction()
            gbQuiz.Visible = False
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Public Sub checkQuizEnglishFull(tempAnswer As String)
        Try

            If currentInstruction = eqp1 Then
                If tempAnswer = "5" Or
                   tempAnswer = "$5" Or
                   tempAnswer = "5.00" Or
                   tempAnswer = "$5.00" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If

                'ElseIf currentInstruction = eqp2 Then
                '    If tempAnswer = "0" Or
                '      tempAnswer = "$0" Or
                '      tempAnswer = "0.00" Or
                '      tempAnswer = "$0.00" Or
                '      tempAnswer = "zero" Then

                '        quizResult(currentInstruction) = "Correct"
                '    Else
                '        quizResult(currentInstruction) = "Incorrect"
                '    End If
            ElseIf currentInstruction = eqp2 Then
                If tempAnswer = "y" Or
                 tempAnswer = "yes" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp3 Then
                If tempAnswer = "n" Or
                tempAnswer = "no" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp4 Then
                If tempAnswer = englishMaxValue.ToString Or
                  tempAnswer = "$" & englishMaxValue Or
                  tempAnswer = englishMaxValue & ".00" Or
                  tempAnswer = "$" & englishMaxValue & ".00" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            ElseIf currentInstruction = eqp5 Then
                If tempAnswer = englishMinValue.ToString Or
                  tempAnswer = "$" & englishMinValue Or
                  tempAnswer = englishMinValue & ".00" Or
                  tempAnswer = "$" & englishMinValue & ".00" Then

                    quizResult(currentInstruction) = "Correct"
                Else
                    quizResult(currentInstruction) = "Incorrect"
                End If
            End If

            pagesDone(currentInstruction) = True
            nextInstruction()
            gbQuiz.Visible = False
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub txtQuiz_TextChanged(sender As Object, e As EventArgs) Handles txtQuiz.TextChanged
        Try
            AcceptButton = cmdSubmitQuiz
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub cmdSubmitQuiz_Click(sender As Object, e As EventArgs) Handles cmdSubmitQuiz.Click
        Try
            If txtQuiz.Text.Trim = "" Then Exit Sub

            quizAnswer(currentInstruction) = txtQuiz.Text.ToLower

            Dim tempAnswer As String = txtQuiz.Text.ToLower

            tempAnswer = tempAnswer.Trim
            tempAnswer = tempAnswer.TrimStart({"$"c, "0"c, " "c})
            tempAnswer = tempAnswer.TrimEnd({"¢"c})

            If InStr(tempAnswer, ".") Then
                tempAnswer = tempAnswer.TrimEnd({"0"c, " "c})
                tempAnswer = tempAnswer.TrimEnd("."c)
            End If

            If currentPhase = "Lottery" And subPeriod = 1 Then
                checkQuizLottery(tempAnswer)
            ElseIf (currentPhase = "2nd Price" Or currentPhase = "English Auction") And subPeriod = 1 Then
                checkQuizSecondPrice(tempAnswer)
            ElseIf currentPhase = "CV Full Info" Or currentPhase = "CV Limited Info" And subPeriod = 1 Then
                If englishBidMode = "full" Then
                    checkQuizEnglishFull(tempAnswer)
                Else
                    checkQuizEnglishDropout(tempAnswer)
                End If

            End If
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            'english pv timer
            With frmSecondPrice
                If .currentSide = "small" Then

                    .smallBid += englishTickAmountPV

                    If .smallBid > secondPriceMaxBid Then .smallBid = secondPriceMaxBid

                    .txtBidRight.Text = Format(Math.Round(.smallBid, 2), "0.00")

                    'if last remaining bidder then stop
                    Dim tempExample As Integer = 1

                    If currentInstruction = exp1 Then
                        tempExample = 1
                    ElseIf currentInstruction = exp2 Then
                        tempExample = 2
                    Else
                        tempExample = 3
                    End If

                    Dim msgtokens() As String = secondPriceExamplesSmall(tempExample).Split(",")

                    Dim tempLastBid As Double = 0

                    If .cmdSubmitSmallEnglish.Visible Then
                        tempLastBid = CDbl(msgtokens(1) / 100)
                    Else
                        tempLastBid = CDbl(msgtokens(2) / 100)
                    End If

                    If .smallBid >= tempLastBid Then
                            .smallDone = True
                            If .largeDone Then

                                .periodResultsInstructions()
                            Else
                                .currentSide = "large"
                                .setupEnglish2()
                            End If
                        End If

                    Else
                        .largeBid += englishTickAmountPV

                    If .largeBid > secondPriceMaxBid Then .smallBid = secondPriceMaxBid

                    .txtBidLeft.Text = Format(Math.Round(.largeBid, 2), "0.00")

                    'if last remaining bidder then stop
                    Dim tempExample As Integer = 1

                    If currentInstruction = exp1 Then
                        tempExample = 1
                    ElseIf currentInstruction = exp2 Then
                        tempExample = 2
                    Else
                        tempExample = 3
                    End If

                    Dim msgtokens() As String = secondPriceExamplesLarge(tempExample).Split(",")

                    Dim tempLastBid As Double = 0

                    If .cmdSubmitLargeEnglish.Visible Then
                        tempLastBid = CDbl(msgtokens(1) / 100)
                    Else
                        tempLastBid = CDbl(msgtokens(2) / 100)
                    End If

                    If .largeBid >= tempLastBid Then
                        .largeDone = True
                        If .smallDone Then

                            .periodResultsInstructions()
                        Else
                            .currentSide = "small"
                            .setupEnglish2()
                        End If
                    End If
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

End Class