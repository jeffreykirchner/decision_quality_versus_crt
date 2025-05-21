


Module modMain
    Public frmClient As New frmMain
    Public sfile As String
    Public myIPAddress As String
    Public myPortNumber As Integer
    Public inumber As Integer
    Public clientClosing As Boolean = False

    Public messageCounter As Integer = 0
    Public playerMessageCounter(100) As Integer

    Public numberOfPlayers As Integer
    Public numberOfPeriods As Integer
    Public numberOfPeriodsSecondPrice As Integer
    Public portNumber As Integer
    Public instructionX As Integer
    Public instructionY As Integer
    Public windowX As Integer
    Public windowY As Integer
    Public showInstructions As Boolean
    Public currentInstruction As Integer
    Public testMode As Boolean

    Public currentPhase As String
    Public subPeriod As Integer
    Public currentPeriod As Integer
    Public quizQuestionValue As Double
    Public practicePeriods As Double
    Public enableChatBot As Boolean
    Public readyToGoOnTime As Integer                           'time to wait before automatically continuing to next period
    Public surveyLink As String                                 'link to post experiment survey 

    Public myGroup As Integer

    'azure openai
    Public azure_openai_key As String
    Public azure_openai_endpoint As String
    Public azure_openai_model As String

    'lotteries
    Public lotteryTicketCount As Integer
    Public lotteryChoiceCount As Integer = 0
    Public lotteryPeriodLength As Integer
    Public lotteryRedTicketValues(4) As Integer
    Public lotteryRedTicketCounts(4) As Integer
    Public lotteryBlueTicketValues(4) As Integer
    Public lotteryBlueTicketCounts(4) As Integer

    'second price
    Public secondPriceStartingCash As Integer
    Public secondPriceObserverLarge As Integer
    Public secondPriceobserverSmall As Integer
    Public secondPriceSmallGroup As Integer
    Public secondPriceNumberOfPlayersLarge As Integer
    Public secondPriceNumberOfPlayersSmall As Integer
    Public secondPriceMaxBid As Double
    Public secondPriceStartValue As Double
    Public secondPriceEndValue As Double
    Public secondPriceExampleCount As Integer
    Public secondPriceExamplesLarge(100) As String
    Public secondPriceExamplesSmall(100) As String

    'english private value
    Public englishTickRatePV As Double
    Public englishTickAmountPV As Double
    Public englishPVSecondPriceShowProfit As Boolean

    'english auction common value
    Public englishStartingCash As Integer
    Public englishTickRate As Integer
    Public englishTickAmount(7) As Double
    Public englishMinValue As Integer
    Public englishMaxValue As Integer
    Public englishStartPrice As Integer
    Public englishEndPrice As Integer
    Public englishPhase As String
    Public englishObserver As Integer
    Public englishValue As Double
    Public englishBidMode As String
    Public englishStartDelay As Integer
    Public englishPriceMode As String
    Public englishMaxGroupSize As Integer

    'english display
    Public englishSignal As Double
    Public englishRange As Double
    Public englishBid As Double

    'Public englishNewBid As Double
    Public englishBidderCount As Integer
    Public englishPrice As Double
    Public englishBidderFlash As Integer = 0
    Public englishStartScale As Integer
    Public englishEndScale As Integer

    Public Sub main()
        sfile = Application.StartupPath & "\client.ini"

        AppEventLog_Init()
        appEventLog_Write("Begin")

        Application.EnableVisualStyles()
        Application.Run(frmClient)

        appEventLog_Write("End")
        AppEventLog_Close()
    End Sub

    Public Sub takeMessage(str As String)
        Try

            Dim tempa() As String = {"<SEP>"}
            Dim msgtokens() As String = str.Split(tempa, StringSplitOptions.None)

            Dim id As String = msgtokens(0)
            Dim message As String = msgtokens(1)

            Select Case id
                Case "SHOW_NAME"
                    takeShowName(message)
                Case "RESET"
                    takeReset(message)
                Case "END_EARLY"
                    takeEndEarly(msgtokens(1))
                Case "FINISHED_INSTRUCTIONS"
                    takeFinishedInstructions(message)
                Case "INVALID_CONNECTION"
                    takeInvalidConnection(message)
                Case "01"
                    takeEnglishPVTick(message)
                Case "02"
                    takeLotteryResult(message)
                Case "03"
                    takeBegin(message)
                Case "04"
                    takeStartNextPeriod(message)
                Case "05"
                    takeStartSecondPriceResult(message)
                Case "06"
                    takeEnglishStartClock(message)
                Case "07"
                    takeEnglishUpdate(message)
                Case "08"
                    takeEnglishResult(message)
                Case "09"
                    takeEnglishDelay(message)
                Case "10"
                    takeEnglishPVStop(message)
                Case "11"
                    takeEnglishPVResult(message)

            End Select

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeInvalidConnection(str As String)
        Try
            With frmClient
                .AC_ConnectionError()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeBegin(str As String)
        Try
            With frmClient
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                numberOfPlayers = msgtokens(nextToken)
                nextToken += 1

                numberOfPeriods = msgtokens(nextToken)
                nextToken += 1

                portNumber = msgtokens(nextToken)
                nextToken += 1

                instructionX = msgtokens(nextToken)
                nextToken += 1

                instructionY = msgtokens(nextToken)
                nextToken += 1

                windowX = msgtokens(nextToken)
                nextToken += 1

                windowY = msgtokens(nextToken)
                nextToken += 1

                showInstructions = msgtokens(nextToken)
                nextToken += 1

                quizQuestionValue = msgtokens(nextToken)
                nextToken += 1

                practicePeriods = msgtokens(nextToken)
                nextToken += 1

                enableChatBot = msgtokens(nextToken)
                nextToken += 1

                readyToGoOnTime = msgtokens(nextToken)
                nextToken += 1

                surveyLink = msgtokens(nextToken)
                nextToken += 1

                'lotteries
                lotteryTicketCount = msgtokens(nextToken)
                nextToken += 1

                lotteryPeriodLength = msgtokens(nextToken)
                nextToken += 1

                'second price
                secondPriceStartingCash = msgtokens(nextToken)
                nextToken += 1

                secondPriceStartValue = msgtokens(nextToken)
                nextToken += 1

                secondPriceEndValue = msgtokens(nextToken)
                nextToken += 1

                secondPriceMaxBid = msgtokens(nextToken)
                nextToken += 1

                'english private value
                englishTickRatePV = msgtokens(nextToken)
                nextToken += 1

                englishTickAmountPV = msgtokens(nextToken)
                nextToken += 1

                englishPVSecondPriceShowProfit = msgtokens(nextToken)
                nextToken += 1

                numberOfPeriodsSecondPrice = msgtokens(nextToken)
                nextToken += 1

                If numberOfPeriodsSecondPrice > 0 Then
                    secondPriceExampleCount = msgtokens(nextToken)
                    nextToken += 1

                    For i As Integer = 1 To secondPriceExampleCount
                        secondPriceExamplesLarge(i) = msgtokens(nextToken)
                        nextToken += 1

                        secondPriceExamplesSmall(i) = msgtokens(nextToken)
                        nextToken += 1
                    Next
                End If

                currentPhase = msgtokens(nextToken)
                nextToken += 1

                inumber = msgtokens(nextToken)
                nextToken += 1

                testMode = msgtokens(nextToken)
                nextToken += 1

                'english auction
                englishStartingCash = msgtokens(nextToken)
                nextToken += 1

                englishTickRate = msgtokens(nextToken)
                nextToken += 1

                For i As Integer = 1 To 7
                    englishTickAmount(i) = msgtokens(nextToken)
                    nextToken += 1
                Next

                englishMinValue = msgtokens(nextToken)
                nextToken += 1

                englishMaxValue = msgtokens(nextToken)
                nextToken += 1

                englishStartPrice = msgtokens(nextToken)
                nextToken += 1

                englishEndPrice = msgtokens(nextToken)
                nextToken += 1

                englishStartScale = msgtokens(nextToken)
                nextToken += 1

                englishEndScale = msgtokens(nextToken)
                nextToken += 1

                englishBidMode = msgtokens(nextToken)
                nextToken += 1

                englishStartDelay = msgtokens(nextToken)
                nextToken += 1

                englishPriceMode = msgtokens(nextToken)
                nextToken += 1

                englishMaxGroupSize = msgtokens(nextToken)
                nextToken += 1

                setupScreen(msgtokens, nextToken)

                For i As Integer = 1 To numberOfPlayers
                    playerMessageCounter(i) = 0
                Next

                .Text = "Client " & inumber

                currentPeriod = 1

                If testMode Then
                    .Timer1.Enabled = True
                    frmTestMode.Show()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeReset(str As String)
        Try
            closeClient()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEndEarly(ByVal sinstr As String)
        Try
            'end experiment early
            Dim msgtokens() As String
            msgtokens = sinstr.Split(";")

            numberOfPeriods = msgtokens(0)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub closeClient()
        Try
            With frmClient
                .Timer1.Enabled = False
                clientClosing = True

                .bwSocket.CancelAsync()
                .AC.close()

                '.Close()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            frmClient.Close()
        End Try
    End Sub

    Public Sub takeLotteryStart(ByRef msgtokens() As String, ByRef nextToken As Integer)
        Try
            With frmLottery
                frmClient.Hide()
                frmLottery.Show()

                .rbRed.Checked = False
                .rbBlue.Checked = False

                .rbRed.Enabled = True
                .rbBlue.Enabled = True

                .cmdSubmit.Visible = True
                .pnlFraming.Visible = True

                .dgFraming.RowCount = 2
                .Text = "Client " & inumber
                .cmdSubmit.Text = "Submit"
                .cmdSubmit.BackColor = Color.FromArgb(192, 255, 192)

                'back colors
                For i As Integer = 1 To .dgFraming.ColumnCount
                    .dgFraming(i - 1, 0).Style.BackColor = Color.FromArgb(255, 187, 187)
                Next

                For i As Integer = 1 To .dgFraming.ColumnCount
                    .dgFraming(i - 1, 1).Style.BackColor = Color.FromArgb(168, 211, 255)
                Next

                subPeriod = msgtokens(nextToken)
                nextToken += 1

                'hide columns
                For i As Integer = 3 To 10
                    .dgFraming.Columns(i).Visible = False
                Next

                'red
                Dim tempC As Integer = 0
                Dim ticketCount As Integer = 1

                For i As Integer = 1 To 4
                    Dim ticketValue As Integer = msgtokens(nextToken)
                    lotteryRedTicketValues(i) = msgtokens(nextToken)
                    nextToken += 1

                    Dim ticketSize As Integer = msgtokens(nextToken)
                    lotteryRedTicketCounts(i) = msgtokens(nextToken)
                    nextToken += 1

                    If ticketSize > 0 Then
                        .dgFraming(tempC, 0).Value = ticketValue & "¢"
                    Else
                        .dgFraming(tempC, 0).Value = "-"
                    End If

                    If ticketSize > 0 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1

                    If ticketSize = 1 Then
                        .dgFraming(tempC, 0).Value = ticketCount
                    ElseIf ticketSize = 0 Then
                        .dgFraming(tempC, 0).Value = "-"
                    Else
                        .dgFraming(tempC, 0).Value = ticketCount & " to " & ticketCount + (ticketSize - 1)
                    End If

                    ticketCount += ticketSize

                    If ticketSize > 0 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1

                    If i <> 4 Then
                        .dgFraming(tempC, 0).Style.BackColor = Color.Black    'SystemColors.ControlDark
                    End If

                    If ticketSize > 0 And i <> 4 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1
                Next

                ''advance past winning draw
                'nextToken += 1

                'blue
                tempC = 0
                ticketCount = 1

                For i As Integer = 1 To 4
                    Dim ticketValue As Integer = msgtokens(nextToken)
                    lotteryBlueTicketValues(i) = msgtokens(nextToken)
                    nextToken += 1

                    Dim ticketSize As Integer = msgtokens(nextToken)
                    lotteryBlueTicketCounts(i) = msgtokens(nextToken)
                    nextToken += 1

                    If ticketSize > 0 Then
                        .dgFraming(tempC, 1).Value = ticketValue & "¢"
                        lotteryChoiceCount += 1
                    Else
                        .dgFraming(tempC, 1).Value = "-"
                    End If

                    If ticketSize > 0 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1

                    If ticketSize = 1 Then
                        .dgFraming(tempC, 1).Value = ticketCount
                    ElseIf ticketSize = 0 Then
                        .dgFraming(tempC, 1).Value = "-"
                    Else
                        .dgFraming(tempC, 1).Value = ticketCount & " to " & ticketCount + (ticketSize - 1)
                    End If

                    ticketCount += ticketSize

                    If ticketSize > 0 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1

                    If i <> 4 Then
                        .dgFraming(tempC, 1).Style.BackColor = Color.Black    'SystemColors.ControlDark
                    End If

                    If ticketSize > 0 And i <> 4 Then .dgFraming.Columns(tempC).Visible = True

                    tempC += 1
                Next

                .dgFraming.CurrentCell.Selected = False

                'reset for color
                For i As Integer = 1 To .dgFraming.RowCount
                    For j As Integer = 1 To .dgFraming.ColumnCount
                        .dgFraming(j - 1, i - 1).Style.ForeColor = Color.Black
                    Next
                Next

                .lbl1.Text = "Make your choice then press Submit."

                .Width = 1087
                .pnlMain.Visible = False
                .Timer1.Enabled = False

                .timeRemaining = lotteryPeriodLength
                .txtTimeRemaining.Text = timeConversion(lotteryPeriodLength)
                .txtTimeRemaining.Visible = True
                .lblTimeRemaining.Visible = True

                .Location = New Point(windowX, windowY)

                If Not showInstructions Then .Timer3.Enabled = True
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeSecondPriceStart(ByRef msgtokens() As String, ByRef nextToken As Integer)
        Try
            With frmSecondPrice
                frmClient.Hide()
                .Show()

                subPeriod = msgtokens(nextToken)
                nextToken += 1

                Dim tempCash As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempValue As Double = msgtokens(nextToken)
                nextToken += 1

                secondPriceNumberOfPlayersLarge = msgtokens(nextToken)
                nextToken += 1

                secondPriceNumberOfPlayersSmall = msgtokens(nextToken)
                nextToken += 1

                myGroup = msgtokens(nextToken)
                nextToken += 1

                secondPriceSmallGroup = msgtokens(nextToken)
                nextToken += 1

                secondPriceObserverLarge = msgtokens(nextToken)
                nextToken += 1

                secondPriceobserverSmall = msgtokens(nextToken)
                nextToken += 1

                Dim tempEnglishPVSide As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempEnglishPVLargePrice As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempEnglishPVSmallPrice As Double = msgtokens(nextToken)
                nextToken += 1

                .txtCashLeft.Text = Format(tempCash, "0.00")
                .txtCashRight.Text = Format(tempCash, "0.00")

                .txtValueLeft.Text = Format(tempValue, "0.00")
                .txtValueRight.Text = Format(tempValue, "0.00")

                .lblRangeLeft.Text = "All Values, including yours, are randomly drawn from " & FormatCurrency(secondPriceStartValue) & " to " & FormatCurrency(secondPriceEndValue) & "."
                .lblRangeRight.Text = "All Values, including yours, are randomly drawn from " & FormatCurrency(secondPriceStartValue) & " to " & FormatCurrency(secondPriceEndValue) & "."

                If currentPhase = "English Auction" Then
                    .lblLeft.Text = "Large Market (" & secondPriceNumberOfPlayersLarge & " players)"
                    .lblRight.Text = "Small Market (" & secondPriceNumberOfPlayersSmall & " players)"

                    .gbBidLeft.Text = "Market Dashboard"
                    .gbBidRight.Text = "Market Dashboard"
                Else
                    .lblLeft.Text = "Large Market (" & secondPriceNumberOfPlayersLarge & " bidders)"
                    .lblRight.Text = "Small Market (" & secondPriceNumberOfPlayersSmall & " bidders)"

                    .txtProfitLeft.Text = ""
                    .txtProfitRight.Text = ""
                End If

                If myGroup = -1 Then

                    If tempCash < 0 Then
                        .lblInfoLeft.Text = "Your cash balance is below zero."
                    Else
                        .lblInfoLeft.Text = "Observation only."
                    End If

                    .gbBidLeft.Visible = False
                    .gbBidRight.Visible = False

                    .cmdSubmit.Visible = False
                Else
                    .txtBidLeft.Text = ""
                    .txtBidRight.Text = ""

                    .txtBidLeft.ReadOnly = False
                    .txtBidRight.ReadOnly = False

                    .txtBidLeft.Focus()

                    .cmdSubmit.Visible = True
                    .cmdSubmit.Text = "Submit Bids"

                    .lblInfoLeft.Text = "Enter your bids then press Submit Bids."

                    .gbBidLeft.Visible = True
                    .gbBidRight.Visible = True

                    .cmdSubmit.Visible = True

                End If

                .Text = "Client " & inumber

                'english auction

                If currentPhase = "English Auction" Then

                    .lblInfoLeft.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                    .cmdSubmit.Visible = False

                    If myGroup <> -1 Then .lblInfoLeft.Text = "Once the Price is too high press Do Not Buy."
                    .currentSide = tempEnglishPVSide

                    .largeBid = tempEnglishPVLargePrice
                    .smallBid = tempEnglishPVSmallPrice

                    .setupEnglish()

                    .lblMyBidLeft.Text = "Price ($)"
                    .lblMyBidRight.Text = "Price ($)"

                    .gb2Left.Text = "Dropout Prices"
                    .gb2Right.Text = "Dropout Prices"

                    .dgMyBidsLeft.Columns(3).HeaderText = "Dropout Price"
                    .dgMyBidsRight.Columns(3).HeaderText = "Dropout Price"

                    .gbLeft.Text = "Results"
                    .gbRight.Text = "Results"

                    .lblLeft2.Text = "If your Cash Balance is less than zero you may not participate."
                    .lblRight2.Text = "If your Cash Balance is less than zero you may not participate."

                    .lblLeft3.Text = "Dropout Prices are listed by period from highest to lowest." & vbCrLf &
                                        "The person who does not drop out will buy at the clock price shown when the last person drops out." & vbCrLf &
                                        "Only one person buys per period."

                    .lblRight3.Text = "Dropout Prices are listed by period from highest to lowest." & vbCrLf &
                                        "The person who does not drop out will buy at the clock price shown when the last person drops out." & vbCrLf &
                                        "Only one person buys per period."

                    .lblLeft4.Text = "My Dropout" & vbCrLf & "Prices"
                    .lblRight4.Text = "My Dropout" & vbCrLf & "Prices"

                    .lblLeft4.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                    .lblRight4.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

                Else
                    .lblMyBidLeft.Text = "My Bid ($)"
                    .lblMyBidRight.Text = "Price ($)"
                End If


                'show profit
                If englishPVSecondPriceShowProfit Then
                    .lblProfitLeft.Visible = True
                    .lblProfitRight.Visible = True

                    .txtProfitLeft.Visible = True
                    .txtProfitRight.Visible = True

                    .pnlLeft.Visible = True
                    .pnlRight.Visible = True

                    .lblMyBidLeft.Text = "- " & .lblMyBidLeft.Text
                    .lblMyBidRight.Text = "- " & .lblMyBidRight.Text
                End If

                .Location = New Point(windowX, windowY)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub takeEnglishStart(ByRef msgtokens() As String, ByRef nextToken As Integer)
        Try
            With frmEnglish
                frmClient.Hide()
                .Show()

                subPeriod = msgtokens(nextToken)
                nextToken += 1

                Dim tempCash As Double = msgtokens(nextToken)
                nextToken += 1

                englishSignal = msgtokens(nextToken)
                nextToken += 1

                englishRange = msgtokens(nextToken)
                nextToken += 1

                englishBidderCount = msgtokens(nextToken)
                nextToken += 1

                myGroup = msgtokens(nextToken)
                nextToken += 1

                englishObserver = msgtokens(nextToken)
                nextToken += 1

                If myGroup = -1 Then
                    .pnl1.Visible = False
                    .txtInfo.Visible = True

                    If tempCash < 0 Then
                        .txtInfo.Text = "Your cash balance is below zero."
                    Else
                        .txtInfo.Text = "Observation only."
                    End If
                Else
                    If englishBidMode = "full" Then
                        .pnl1.Visible = True
                        .cmdDontBuy.Visible = False
                        .txtInfo.Visible = False
                    Else
                        .cmdDontBuy.Visible = False
                        .pnl1.Visible = False

                        .txtInfo.Visible = True
                        .txtInfo.Text = "The period will begin in " & englishStartDelay & " seconds."
                    End If
                End If

                .txtCash.Text = Format(tempCash, "0.00")
                nextToken += 1

                .txtNewBid.Text = Format(englishStartPrice, "0.00")

                .Text = "Client " & inumber
                .Timer1.Enabled = True

                englishPrice = englishStartPrice

                If englishBidMode = "full" Then
                    englishBid = englishStartPrice
                Else
                    englishBid = 10000
                End If

                .lbl1.Text = "Actual Value minus $" & englishRange & " to the Actual Value plus $" & englishRange
                .lblValueInterval.Text = "The Actual Value ($) is randomly drawn from $" & englishMinValue & " to $" & englishMaxValue & " each period. "

                englishPhase = "start"
                'englishNewBid = englishBid

                .lblKeyValue.Visible = False
                .pnlKeyValue.Visible = False
                .Location = New Point(windowX, windowY)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeLotteryResult(str As String)
        Try
            With frmLottery
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempChoice As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempPayoutTicket As Integer = msgtokens(nextToken)
                nextToken += 1

                Dim tempPayoutIndex As Integer = msgtokens(nextToken)
                nextToken += 1

                Dim tempLotteryEarnings As Integer = msgtokens(nextToken)
                nextToken += 1

                'pass results to lottery form to display after spin
                .tempChoice = tempChoice
                .tempPayoutTicket = tempPayoutTicket
                .tempPayoutIndex = tempPayoutIndex
                .tempLotteryEarnings = tempLotteryEarnings

                'takeLotteryStart(msgtokens, nextToken)

                .rbBlue.Enabled = False
                .rbRed.Enabled = False

                'If tempChoice = "Red" Then
                '    .rbRed.Checked = True
                'Else
                '    .rbBlue.Checked = True
                'End If

                'fill results table
                .dgResults.Rows.Insert(0)
                .dgResults.Rows.Insert(0)

                .dgResults(0, 0).Value = currentPeriod
                .dgResults(0, 1).Value = currentPeriod

                'first pay group
                .dgResults(1, 0).Value = .dgFraming(0, 0).Value & " for " & .dgFraming(1, 0).Value
                .dgResults(1, 1).Value = .dgFraming(0, 1).Value & " for " & .dgFraming(1, 1).Value

                'second pay group
                If .dgFraming.Columns(3).Visible Then
                    .dgResults.Columns(2).Visible = True

                    If .dgFraming(3, 0).Value = "-" Then
                        .dgResults(2, 0).Value = "-"
                    Else
                        .dgResults(2, 0).Value = .dgFraming(3, 0).Value & " for " & .dgFraming(4, 0).Value
                    End If

                    If .dgFraming(3, 1).Value = "-" Then
                        .dgResults(2, 1).Value = "-"
                    Else
                        .dgResults(2, 1).Value = .dgFraming(3, 1).Value & " for " & .dgFraming(4, 1).Value
                    End If
                End If

                'third pay group
                If .dgFraming.Columns(6).Visible Then
                    .dgResults.Columns(3).Visible = True

                    If .dgFraming(6, 0).Value = "-" Then
                        .dgResults(3, 0).Value = "-"
                    Else
                        .dgResults(3, 0).Value = .dgFraming(6, 0).Value & " for " & .dgFraming(7, 0).Value
                    End If

                    If .dgFraming(6, 1).Value = "-" Then
                        .dgResults(3, 1).Value = "-"
                    Else
                        .dgResults(3, 1).Value = .dgFraming(6, 1).Value & " for " & .dgFraming(7, 1).Value
                    End If


                End If


                'forth pay group
                If .dgFraming.Columns(9).Visible Then
                    .dgResults.Columns(4).Visible = True

                    .dgResults(4, 0).Value = .dgFraming(9, 0).Value & " for " & .dgFraming(10, 0).Value
                    .dgResults(4, 1).Value = .dgFraming(9, 1).Value & " for " & .dgFraming(10, 1).Value
                End If


                .dgResults.CurrentCell.Selected = False


                For i As Integer = 1 To .dgResults.ColumnCount
                    .dgResults(i - 1, 0).Style.BackColor = Color.FromArgb(255, 187, 187)
                    .dgResults(i - 1, 1).Style.BackColor = Color.FromArgb(168, 211, 255)
                Next

                'spacer
                .dgResults(5, 0).Style.BackColor = Color.Black
                .dgResults(5, 1).Style.BackColor = Color.Black

                'spinner
                .lbl1.Text = "Spinning for Winning # ... "
                .startSpinner(tempPayoutTicket)

                showLotterySpinner()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub showLotterySpinner()
        Try
            With frmLottery
                .Width = 1589
                .pnlMain.Visible = True
                .Timer1.Enabled = True
                .Location = New Point(windowX, .Location.Y)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeStartNextPeriod(str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            currentPeriod = msgtokens(nextToken)
            nextToken += 1

            currentPhase = msgtokens(nextToken)
            nextToken += 1

            setupScreen(msgtokens, nextToken)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeStartSecondPriceResult(str As String)
        Try
            With frmSecondPrice
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempCash As Double = msgtokens(nextToken)
                nextToken += 1

                .txtCashLeft.Text = Format(tempCash, "0.00")
                .txtCashRight.Text = Format(tempCash, "0.00")

                Dim tempPaidSide As String = msgtokens(nextToken)
                nextToken += 1

                'large market
                Dim tempN As Integer = msgtokens(nextToken)
                nextToken += 1

                takeStartSecondPriceResult2(.dgMainLeft, .dgMyBidsLeft, tempN, msgtokens, nextToken, secondPriceNumberOfPlayersLarge, subPeriod)

                tempN = msgtokens(nextToken)
                nextToken += 1

                takeStartSecondPriceResult2(.dgMainRight, .dgMyBidsRight, tempN, msgtokens, nextToken, secondPriceNumberOfPlayersSmall, subPeriod)

                'only pay one side
                If tempPaidSide = "large" Then
                    If .dgMyBidsLeft(2, 0).Value = "No" Then
                        .dgMyBidsLeft(9, 0).Value = "0.00"
                        .dgMyBidsLeft(9, 0).Style.ForeColor = Color.Black
                    End If

                    .dgMyBidsLeft(1, 0).Value = "Yes"

                    .dgMyBidsRight(1, 0).Value = "No"
                    .dgMyBidsRight(9, 0).Value = "0.00"
                    .dgMyBidsRight(9, 0).Style.ForeColor = Color.Black
                Else
                    If .dgMyBidsRight(2, 0).Value = "No" Then
                        .dgMyBidsRight(1, 0).Value = "No"
                        .dgMyBidsRight(9, 0).Value = "0.00"
                        .dgMyBidsRight(9, 0).Style.ForeColor = Color.Black
                    End If

                    .dgMyBidsRight(1, 0).Value = "Yes"

                    .dgMyBidsLeft(1, 0).Value = "No"
                    .dgMyBidsLeft(9, 0).Value = "0.00"
                    .dgMyBidsLeft(9, 0).Style.ForeColor = Color.Black
                End If

                If tempCash >= 0 Then
                    .lblInfoLeft.Text = "Press Ready to Go On"
                    .cmdSubmit.Text = "Ready to Go On"
                    .cmdSubmit.Visible = True
                    .Timer2.Interval = readyToGoOnTime * 1000
                    .Timer2.Enabled = True
                Else
                    .lblInfoLeft.Text = "Your cash balance is below zero."
                    .cmdSubmit.Visible = False
                    .gbBidLeft.Visible = False
                    .gbBidRight.Visible = False
                End If

                If currentPhase = "English Auction" Then
                    .lblInfoLeft.Location = New Point(709, 276)

                    .cmdSubmitLargeEnglish.Visible = False
                    .cmdSubmitSmallEnglish.Visible = False

                    .largeBid = msgtokens(nextToken)
                    nextToken += 1

                    .smallBid = msgtokens(nextToken)
                    nextToken += 1

                    .refreshLargeBid()
                    .refreshSmallBid()
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeStartSecondPriceResult2(ByRef dgMain As DataGridView,
                                           ByRef dgMybids As DataGridView,
                                           tempN As Integer,
                                           msgtokens() As String,
                                           ByRef nextToken As Integer,
                                           biddersInGroup As Integer,
                                           tempSubPeriod As Integer)
        Try
            With frmSecondPrice
                'add columns for group size
                Do While dgMain.ColumnCount < tempN + 1
                    dgMain.Columns.Add(dgMain.Columns(1).Clone)

                    'clear any values in columns after clone
                    For i As Integer = 1 To dgMain.RowCount
                        dgMain(dgMain.ColumnCount - 1, i - 1).Value = ""
                    Next

                    dgMain.Columns(dgMain.ColumnCount - 1).HeaderText = ""
                Loop

                'add columns headers
                If currentPhase = "2nd Price" And tempSubPeriod = 1 Then
                    dgMain.Columns(1).HeaderText = "Best Bid"

                    If tempN > 1 Then
                        dgMain.Columns(2).HeaderText = "Price Paid"
                    End If
                ElseIf currentPhase = "English Auction" And tempSubPeriod = 1 Then
                    If tempN > 1 Then
                        dgMain.Columns(2).HeaderText = "Price Paid"
                    End If
                End If

                dgMain.Rows.Insert(0, 1)
                dgMybids.Rows.Insert(0, 1)

                dgMain(0, 0).Value = tempSubPeriod
                dgMybids(0, 0).Value = tempSubPeriod

                'all bids
                For i As Integer = 1 To tempN

                    If i = 1 And currentPhase = "English Auction" Then
                        dgMain(i, 0).Value = "***"
                    Else
                        dgMain(i, 0).Value = Format(CDbl(msgtokens(nextToken)), "0.00")
                    End If


                    nextToken += 1
                    nextToken += 1

                    Dim tempOwner As Integer = msgtokens(nextToken)
                    nextToken += 1
                    nextToken += 1

                    'my bids
                    If tempOwner = inumber Then
                        dgMain(i, 0).Style.ForeColor = Color.Green

                        dgMybids(0, 0).Value = tempSubPeriod

                        If i = 1 Then
                            dgMybids(2, 0).Value = "Yes"
                        Else
                            dgMybids(2, 0).Value = "No"
                        End If

                        dgMybids(3, 0).Value = dgMain(i, 0).Value
                    End If
                Next

                If dgMybids(2, 0).Value = "Yes" Then
                    dgMybids(5, 0).Value = .txtValueLeft.Text

                    dgMybids(6, 0).Value = "-"

                    If biddersInGroup > 1 Then
                        dgMybids(7, 0).Value = dgMain(2, 0).Value
                    Else
                        dgMybids(7, 0).Value = dgMain(1, 0).Value
                    End If

                    dgMybids(8, 0).Value = "="
                    dgMybids(9, 0).Value = Format(CDbl(dgMybids(5, 0).Value) - CDbl(dgMybids(7, 0).Value), "0.00")

                    If CDbl(dgMybids(9, 0).Value) < 0 Then dgMybids(9, 0).Style.ForeColor = Color.Red
                Else
                    For i As Integer = 5 To 8
                        dgMybids(i, 0).Value = ""
                    Next

                    dgMybids(9, 0).Value = "0.00"
                End If

                'spacer 
                dgMybids(4, 0).Style.BackColor = Color.DimGray

                dgMain.CurrentCell.Selected = False
                dgMybids.CurrentCell.Selected = False
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeShowName(str As String)
        Try
            With frmNames
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                .Show()

                .lblEarnings.Text = "Your Earnings Are: " & FormatCurrency(msgtokens(nextToken), -1, TriState.UseDefault, TriState.False)
                nextToken += 1

                frmChatGPT.Hide()

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishStartClock(str As String)
        Try
            With frmEnglish
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                englishBid = msgtokens(nextToken)
                nextToken += 1

                If englishObserver = -1 Then
                    If englishBidMode = "full" Then
                        .pnl1.Visible = True
                    Else
                        .cmdDontBuy.Visible = True
                    End If

                    .txtInfo.Visible = False
                End If

                    englishPhase = "play"
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishUpdate(str As String)
        Try
            With frmEnglish
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                englishPrice = msgtokens(nextToken)
                nextToken += 1

                englishBid = msgtokens(nextToken)
                nextToken += 1

                Dim tempBidderCount As Integer = msgtokens(nextToken)
                nextToken += 1

                If englishBidderCount <> tempBidderCount Then
                    englishBidderFlash = 10
                End If

                englishBidderCount = tempBidderCount

                If englishObserver = -1 Then
                    If englishBid <= englishPrice Then
                        .pnl1.Visible = False
                        .txtInfo.Visible = True
                        .txtInfo.Text = "You are out."
                    End If

                    If .pnl1.Visible Then
                        If CDbl(.txtNewBid.Text) < englishPrice Then
                            .txtNewBid.Text = Format(englishPrice, "0.00")
                            'englishNewBid = englishPrice
                        End If
                    End If

                    If tempBidderCount <= 1 Then
                        .pnl1.Visible = False
                        .cmdDontBuy.Visible = False

                        If englishBid >= englishPrice Then
                            .txtInfo.Visible = True
                            .txtInfo.Text = "Waiting for others."
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishResult(str As String)
        Try
            With frmEnglish
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                .pnl1.Visible = False
                .cmdDontBuy.Visible = False

                .pnlMarketPrice.Visible = True
                .lblMarketPrice.Visible = True

                englishPrice = msgtokens(nextToken)
                nextToken += 1

                Dim tempWinner As Integer = msgtokens(nextToken)
                nextToken += 1

                englishValue = msgtokens(nextToken)
                nextToken += 1

                Dim tempProfit As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempEarnings As Double = msgtokens(nextToken)
                nextToken += 1

                englishBid = msgtokens(nextToken)
                nextToken += 1

                englishBidderCount = msgtokens(nextToken)
                nextToken += 1

                Dim tempCount As Integer = msgtokens(nextToken)
                nextToken += 1

                'update final price and bidders

                .dg1.Rows.Insert(0)

                Dim tempC As Integer = (7 + tempCount - 1) - .dg1.ColumnCount
                For i As Integer = 1 To tempC
                    .dg1.Columns.Add(.dg1.Columns(6).Clone)

                    If englishBidMode = "drop" Then
                        .dg1.Columns(.dg1.ColumnCount - 1).HeaderText = "Drop Price/Signal"
                    Else
                        .dg1.Columns(.dg1.ColumnCount - 1).HeaderText = "Bid/Signal"
                    End If
                Next

                .dg1(0, 0).Value = subPeriod

                If tempWinner = inumber Then
                    .dg1(1, 0).Value = "Yes"
                    .dg1(1, 0).Style.ForeColor = Color.Green

                    If tempProfit >= 0 Then
                        .dg1(4, 0).Style.ForeColor = Color.Green
                    Else
                        .dg1(4, 0).Style.ForeColor = Color.Red
                    End If
                Else
                    .dg1(1, 0).Value = "No"
                End If

                .dg1(2, 0).Value = englishValue
                .dg1(3, 0).Value = Format(englishPrice, "0.00")
                .dg1(4, 0).Value = Format(tempProfit, "0.00")
                .dg1(5, 0).Style.BackColor = Color.DimGray

                For i As Integer = 6 To 6 + tempCount - 1
                    Dim tempBid As Double = msgtokens(nextToken)
                    nextToken += 1

                    If tempBid = 10000.0 Then
                        .dg1(i, 0).Value = "--"
                    Else
                        .dg1(i, 0).Value = Format(tempBid, "0.00")
                    End If

                    .dg1(i, 0).Value &= " / " & Format(CDbl(msgtokens(nextToken)), "0.00")
                    nextToken += 1

                    Dim tempPerson As Integer = msgtokens(nextToken)
                    nextToken += 1

                    If tempPerson = inumber Then
                        .dg1(i, 0).Style.ForeColor = Color.Green
                    End If
                Next

                .txtCash.Text = Format(tempEarnings, "0.00")

                If tempEarnings >= 0 Then
                    .cmdReadyToGoOn.Visible = True

                    .txtInfo.Text = "Press the Ready to Go On button."
                Else
                    .txtInfo.Text = "Your cash balance is below zero."
                End If

                .txtInfo.Visible = True

                If .dg1.RowCount > 0 Then .dg1.CurrentCell.Selected = False

                .lblKeyValue.Visible = True
                .pnlKeyValue.Visible = True

                'englishNewBid = englishBid

                englishPhase = "result"
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeFinishedInstructions(str As String)
        Try

            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            frmInstructions.Close()
            showInstructions = False

            If currentPhase = "Lottery" Then
                With frmLottery
                    takeLotteryStart(msgtokens, nextToken)
                End With
            ElseIf currentPhase = "2nd Price" Or currentPhase = "English Auction" Then
                With My.Forms.frmSecondPrice
                    takeSecondPriceStart(msgtokens, nextToken)

                    .dgMainLeft.RowCount = 0
                    .dgMainRight.RowCount = 0
                    .dgMyBidsLeft.RowCount = 0
                    .dgMyBidsRight.RowCount = 0

                    .lblInfoLeft.Visible = True
                End With
            Else
                With My.Forms.frmEnglish
                    takeEnglishStart(msgtokens, nextToken)

                    .dg1.RowCount = 0
                End With
            End If

            If enableChatBot Then
                frmChatGPT.Show()
                frmChatGPT.Location = New Point(windowX, windowY)
            End If

        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub setupScreen(ByRef msgtokens() As String, ByRef nextToken As Integer)
        Try

            If currentPhase = "Lottery" Then

                takeLotteryStart(msgtokens, nextToken)

                My.Forms.frmSecondPrice.Hide()
                My.Forms.frmEnglish.Hide()

                If enableChatBot And Not showInstructions Then
                    frmChatGPT.Show()
                    frmChatGPT.Location = New Point(10, My.Forms.frmLottery.Height + 20)
                    frmChatGPT.Width = My.Forms.frmSecondPrice.Width
                    frmChatGPT.Height = My.Computer.Screen.Bounds.Height - 20 - My.Forms.frmLottery.Height
                End If
            ElseIf currentPhase = "2nd Price" Or currentPhase = "English Auction" Then
                takeSecondPriceStart(msgtokens, nextToken)

                My.Forms.frmLottery.Hide()
                My.Forms.frmEnglish.Hide()

                If enableChatBot And Not showInstructions Then
                    frmChatGPT.Show()
                    frmChatGPT.Location = New Point(10, My.Forms.frmSecondPrice.Height + 20)
                    frmChatGPT.Width = My.Forms.frmSecondPrice.Width
                    frmChatGPT.Height = My.Computer.Screen.Bounds.Height - 20 - My.Forms.frmSecondPrice.Height
                End If
            Else
                takeEnglishStart(msgtokens, nextToken)

                'move drop button
                If englishBidMode = "drop" Then
                    With My.Forms.frmEnglish
                        .cmdDontBuy.Location = New Point(.gb2.Width / 2 - .cmdDontBuy.Width / 2,
                                                         .txtInfo.Location.Y - .cmdDontBuy.Height / 2)

                        .gb2.Size = New Size(1216, 457)
                        .gb1.Location = New Point(10, 478)
                        .Size = New Size(1254, 792)

                        .lblBid.Text = "Your Dropout Price ($)"
                        .dg1.Columns(6).HeaderText = "Winning Drop Price/Signal"
                    End With
                Else
                    With My.Forms.frmEnglish
                        .pnlMarketPrice.Visible = False
                        .lblMarketPrice.Visible = False
                        .txtNewBid.Text = ""

                        .lblBid.Text = "Your Bid ($)"
                    End With
                End If

                My.Forms.frmSecondPrice.Hide()
                My.Forms.frmLottery.Hide()

                If enableChatBot And Not showInstructions Then
                    frmChatGPT.Show()
                    frmChatGPT.Width = My.Computer.Screen.Bounds.Width - My.Forms.frmEnglish.Width - 20

                    frmChatGPT.Location = New Point(My.Computer.Screen.Bounds.Width - frmChatGPT.Width - 10, 10)
                    frmChatGPT.Height = My.Forms.frmEnglish.Height

                End If
            End If

            If showInstructions Then

                If currentPhase = "Lottery" And subPeriod = 1 Then
                    My.Forms.frmLottery.Location = New Point(windowX, windowY)
                    frmLottery.Hide()
                ElseIf currentPhase = "2nd Price" And subPeriod = 1 Then
                    My.Forms.frmSecondPrice.Location = New Point(windowX, windowY)

                    My.Forms.frmSecondPrice.lblLeft.Text = "Large Market (" & "10" & " bidders)"
                    My.Forms.frmSecondPrice.lblRight.Text = "Small Market (" & "5" & " bidders)"
                ElseIf currentPhase = "English Auction" And subPeriod = 1 Then
                    My.Forms.frmSecondPrice.Location = New Point(windowX, windowY)

                    My.Forms.frmSecondPrice.lblLeft.Text = "Large Market (" & "10" & " players)"
                    My.Forms.frmSecondPrice.lblRight.Text = "Small Market (" & "5" & " players)"
                ElseIf currentPhase = "CV Full Info" Or currentPhase = "CV Limited Info" And subPeriod = 1 Then
                    With My.Forms.frmEnglish
                        englishObserver = -1
                        myGroup = 1

                        .Location = New Point(windowX, windowY)

                        If englishBidMode = "drop" Then
                            englishSignal = 96
                            englishBidderCount = 2
                            englishRange = 6
                            .lbl1.Text = "Actual Value minus $6 to the Actual Value plus $6"

                            My.Forms.frmInstructions.Timer1.Interval = englishTickRate

                            .cmdDontBuy.Visible = True
                        Else
                            .pnl1.Visible = True
                        End If


                        .txtInfo.Visible = False


                    End With
                End If

                currentInstruction = 1
                frmInstructions.Show()

                My.Forms.frmInstructions.Location = New Point(instructionX, instructionY)
            End If
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishDelay(str As String)
        Try
            With frmEnglish
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempD As Integer = msgtokens(nextToken)
                nextToken += 1

                If myGroup <> -1 Then
                    .txtInfo.Text = "The period will begin in " & tempD & " seconds."
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishPVTick(str As String)
        Try
            With frmSecondPrice
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                If .currentSide = "large" Then
                    .largeBid = msgtokens(nextToken)
                    nextToken += 1
                Else
                    .smallBid = msgtokens(nextToken)
                    nextToken += 1
                End If

                .doTimer2Tick()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishPVStop(str As String)
        Try
            With frmSecondPrice
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                .cmdSubmitLargeEnglish.Visible = False
                .cmdSubmitSmallEnglish.Visible = False

                takeEnglishPVTick(str)

                .lblInfoLeft.Text = "Waiting for others."
                nextToken += 1
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishPVResult(str As String)
        Try
            With frmSecondPrice
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                If myGroup = -1 Then Exit Sub

                .cmdSubmitLargeEnglish.Visible = False
                .cmdSubmitSmallEnglish.Visible = False

                .cmdSubmit.Text = "Ready to Go On"
                .cmdSubmit.Visible = True
                .Timer2.Interval = readyToGoOnTime * 1000
                .Timer2.Enabled = True

                .lblInfoLeft.Location = New Point(709, 276)

                If .currentSide = "large" Then
                    .lblInfoLeft.Text = "The Small Market will start when everyone is Ready."
                Else
                    .lblInfoLeft.Text = "The Large Market will start when everyone is Ready."
                End If

                takeEnglishPVTick(str)

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function timeConversion(ByVal sec As Integer) As String
        Try
            'appEventLog_Write("time conversion :" & sec)
            timeConversion = Format((sec \ 60), "00") & ":" & Format((sec Mod 60), "00")
        Catch ex As Exception
            appEventLog_Write("error timeConversion:", ex)
            timeConversion = ""
        End Try
    End Function
End Module
