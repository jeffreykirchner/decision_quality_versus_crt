

Imports System.Net

Public Class player

    Public sp As New socketPlayer
    Public inumber As Integer
    Public name As String
    Public studentID As String

    Public myGroup(100) As Integer

    'lottery
    Public lotteryChoices(100) As String
    Public lotteryChoicesAuto(100) As Boolean
    Public lotteryChoicesFlipped(100) As Boolean

    Public lotteryEarnings As Double
    Public lotteryQuizEarnings As Double
    Public lotteryAnswers(100) As String
    Public lotteryAnswerResults(100) As String

    'second price
    Public secondPriceEarnings As Double
    Public secondPriceQuizEarnings As Double
    Public secondPriceValues(100) As Double
    Public secondPriceBidsLarge(100) As secondPriceBid
    Public secondPriceBidsSmall(100) As secondPriceBid
    Public secondPriceSmallGroup(100) As Integer
    Public secondPriceObserverLarge(100) As Integer
    Public secondPriceObserverSmall(100) As Integer
    Public secondPriceAnswers(100) As String
    Public secondPriceAnswerResults(100) As String

    'English Signals
    Public englishEarnings As Double
    Public englishQuizEarnings As Double
    Public englishSignals(100) As Double
    Public englishStatus As String
    Public englishBids(100) As Double
    Public doNotBuyPress(100) As Boolean
    Public englishID(100) As Integer
    Public englishObserver(100) As Integer
    Public englishAnswers(100) As String
    Public englishAnswerResults(100) As String

    Public Sub sendMessage(index As String, message As String)
        Try
            If sp Is Nothing Then Exit Sub

            sp.send(index, message)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendreset()
        Try
            Dim outstr As String = ""

            sendMessage("RESET", outstr)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendShowName()
        Try
            Dim str As String = ""

            str = Math.Round(lotteryEarnings / 100, 2) +
                  lotteryQuizEarnings +
                  Math.Max(0, secondPriceEarnings) +
                  secondPriceQuizEarnings +
                  Math.Max(0, englishEarnings) +
                  englishQuizEarnings & ";"

            sendMessage("SHOW_NAME", str)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SendEndEarly()
        Try
            'end experiment early

            With frmServer
                Dim outstr As String

                outstr = numberOfPeriods & ";"
                sendMessage("END_EARLY", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendInvalidConnection()
        Try
            sendMessage("INVALID_CONNECTION", "")
        Catch ex As Exception
            appEventLog_Write("error SendInvalidConnection:", ex)
        End Try
    End Sub

    Public Sub sendBegin(str As String)
        Try

            Dim outstr As String = str

            outstr &= numberOfPlayers & ";"
            outstr &= numberOfPeriods & ";"
            outstr &= portNumber & ";"
            outstr &= instructionX & ";"
            outstr &= instructionY & ";"
            outstr &= windowX & ";"
            outstr &= windowY & ";"
            outstr &= showInstructions & ";"
            outstr &= quizQuestionValue & ";"
            outstr &= practicePeriods & ";"
            outstr &= enableChatBot & ";"
            outstr &= readyToGoOnTime & ";"

            'lotteries
            outstr &= lotteryTicketCount & ";"
            outstr &= lotteryPeriodLength & ";"

            'second price
            outstr &= secondPriceStartingCash & ";"
            outstr &= secondPriceStartValue & ";"
            outstr &= secondPriceEndValue & ";"
            outstr &= secondPriceMaxBid & ";"

            'english private value
            outstr &= englishTickRatePV & ";"
            outstr &= englishTickAmountPV & ";"
            outstr &= englishPVSecondPriceShowProfit & ";"

            outstr &= numberOfPeriodsSecondPrice & ";"

            If numberOfPeriodsSecondPrice > 0 Then
                outstr &= secondPriceExampleCount & ";"

                For i As Integer = 1 To secondPriceExampleCount
                    outstr &= secondPriceExamplesLarge(i).Replace(";", ",") & ";"
                    outstr &= secondPriceExamplesSmall(i).Replace(";", ",") & ";"
                Next
            End If

            outstr &= phaseList(currentPeriod) & ";"
            outstr &= inumber & ";"
            outstr &= testMode & ";"

            'english auction common value
            outstr &= englishStartingCash & ";"
            outstr &= englishTickRate & ";"

            For i As Integer = 1 To 7
                outstr &= englishTickAmount(i) & ";"
            Next

            outstr &= englishMinValue & ";"
            outstr &= englishMaxValue & ";"
            outstr &= englishStartPrice & ";"
            outstr &= englishEndPrice & ";"
            outstr &= englishStartScale & ";"
            outstr &= englishEndScale & ";"
            outstr &= englishBidMode & ";"
            outstr &= englishStartDelay & ";"
            outstr &= englishPriceMode & ";"
            outstr &= englishGroups(1, numberOfPlayers) & ";"

            If phaseList(currentPeriod) = "Lottery" Then
                If showInstructions Then
                    outstr &= getLotteryStart(0)
                Else
                    outstr &= getLotteryStart(subLotteryPeriod)
                End If

            ElseIf phaseList(currentPeriod) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                outstr &= getSecondPriceStart(subSecondPricePeriod)
            Else
                outstr &= getEnglishStart(subEnglishPeriod)
            End If

            sendMessage("03", outstr)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendLotteryResult()
        Try

            'Dim msgtokens() As String = getINI(sfile, "lotteries", subLotteryPeriod & "-" & lotteryChoices(subLotteryPeriod)).Split(";")
            'Dim nextToken As Integer = 1

            'set lottery earnings to final bucket
            'Dim tempC As Integer = msgtokens(nextToken)
            'Dim tempLotteryEarnings As Integer = msgtokens(6)

            ''check if lottery draw falls in one of the other buckets
            'For i As Integer = 1 To 3
            '    If lotteryTicketNumber(subLotteryPeriod) <= tempC Then
            '        payoutIndex = i
            '        tempLotteryEarnings = msgtokens(nextToken - 1)
            '        Exit For
            '    Else
            '        nextToken += 2
            '        tempC += CInt(msgtokens(nextToken))
            '    End If
            'Next

            Dim tempChoice As String = lotteryChoices(subLotteryPeriod)

            If lotteryChoicesFlipped(subLotteryPeriod) Then
                If tempChoice = "Red" Then
                    tempChoice = "Blue"
                Else
                    tempChoice = "Red"
                End If
            End If

            Dim tempE() As Integer = lotteryChoicePeriods(subLotteryPeriod).getEarnings(tempChoice)

            Dim payoutIndex As Integer = tempE(0)
            Dim tempLotteryEarnings As Integer = tempE(1)

            If subLotteryPeriod > practicePeriods Then
                lotteryEarnings += tempLotteryEarnings
            End If

            Dim outstr As String = ""

            outstr = lotteryChoices(subLotteryPeriod) & ";"
            outstr &= lotteryChoicePeriods(subLotteryPeriod).winningNumber & ";"
            outstr &= payoutIndex & ";"
            outstr &= tempLotteryEarnings & ";"
            ' outstr &= getLotteryStart(subLotteryPeriod)


            sendMessage("02", outstr)

            updateEarningsDisplay()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub sendStartNextPeriod()
        Try
            Dim outstr As String = ""

            outstr = currentPeriod & ";"
            outstr &= phaseList(currentPeriod) & ";"

            If phaseList(currentPeriod) = "Lottery" Then
                outstr &= getLotteryStart(subLotteryPeriod)
            ElseIf phaseList(currentPeriod) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                outstr &= getSecondPriceStart(subSecondPricePeriod)
            Else
                outstr &= getEnglishStart(subEnglishPeriod)
            End If

            sendMessage("04", outstr)

            If phaseList(currentPeriod) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                'if out, fill in no bid
                If secondPriceEarnings < 0 Then secondPriceBidsLarge(subSecondPricePeriod) = New secondPriceBid(-1, -1, inumber, subSecondPricePeriod, secondPriceValues(subSecondPricePeriod))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getLotteryStart(tempPeriod As Integer) As String
        Try
            Dim str As String = ""

            str = subLotteryPeriod & ";"

            If lotteryChoicesFlipped(tempPeriod) Then
                str &= lotteryChoicePeriods(tempPeriod).getBlueString(";")
                str &= lotteryChoicePeriods(tempPeriod).getRedString(";")
            Else
                str &= lotteryChoicePeriods(tempPeriod).getRedString(";")
                str &= lotteryChoicePeriods(tempPeriod).getBlueString(";")
            End If

            'str &= getINI(sfile, "lotteries", tempPeriod & "-Red")
            'str &= getINI(sfile, "lotteries", tempPeriod & "-Blue")

            Return str

        Catch ex As Exception
            appEventLog_Write("error : ", ex)
            Return ""
        End Try
    End Function

    Public Function getSecondPriceStart(tempPeriod As Integer) As String
        Try
            With frmServer
                Dim str As String = ""

                Dim tempGroupLarge As Integer
                Dim tempGroupSmall As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempGroupLarge = secondPriceObserverLarge(tempPeriod)
                    tempGroupSmall = secondPriceObserverSmall(tempPeriod)
                Else
                    tempGroupLarge = myGroup(tempPeriod)
                    tempGroupSmall = secondPriceSmallGroup(tempPeriod)
                End If

                str = subSecondPricePeriod & ";"
                str &= secondPriceEarnings & ";"
                str &= secondPriceValues(tempPeriod) & ";"
                str &= .getNumberInMyGroup(tempGroupLarge, currentPeriod) & ";"
                str &= .getSecondPriceNumberInMyGroupSmall(tempGroupSmall, subSecondPricePeriod) & ";"

                str &= myGroup(currentPeriod) & ";"
                str &= secondPriceSmallGroup(tempPeriod) & ";"
                str &= secondPriceObserverLarge(tempPeriod) & ";"
                str &= secondPriceObserverSmall(tempPeriod) & ";"

                str &= englishSidePV(tempPeriod) & ";"

                str &= englishPriceLargePV(tempGroupLarge, tempPeriod) & ";"
                str &= englishPriceSmallPV(tempGroupSmall, tempPeriod) & ";"

                Return str
            End With

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Public Function getEnglishStart(tempPeriod As Integer) As String
        Try
            With frmServer
                Dim str As String = ""

                Dim tempGroup As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempGroup = englishObserver(tempPeriod)
                Else
                    tempGroup = myGroup(currentPeriod)
                End If

                str = subEnglishPeriod & ";"
                str &= englishEarnings & ";"
                str &= englishSignals(tempPeriod) & ";"
                str &= englishRanges(tempPeriod) & ";"
                str &= .getNumberInMyGroup(tempGroup, currentPeriod) & ";"
                str &= myGroup(currentPeriod) & ";"
                str &= englishObserver(tempPeriod) & ";"

                Return str
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Public Sub sendSecondPriceResults()
        Try
            With frmServer

                'check for winner
                If myGroup(currentPeriod) <> -1 Then

                    If subSecondPricePeriod > practicePeriods Then

                        If secondPriceMarketPayout(subSecondPricePeriod) = "large" Then
                            If secondPriceBidListLarge(myGroup(currentPeriod), subSecondPricePeriod, 1).owner = inumber Then
                                secondPriceEarnings += secondPriceValues(subSecondPricePeriod)

                                If secondPriceBidListLarge(myGroup(currentPeriod), subSecondPricePeriod, 2) IsNot Nothing Then
                                    secondPriceEarnings -= secondPriceBidListLarge(myGroup(currentPeriod), subSecondPricePeriod, 2).bid
                                Else
                                    secondPriceEarnings -= secondPriceBidListLarge(myGroup(currentPeriod), subSecondPricePeriod, 1).bid
                                End If
                            End If
                        Else
                            If secondPriceBidListSmall(secondPriceSmallGroup(currentPeriod), subSecondPricePeriod, 1).owner = inumber Then
                                secondPriceEarnings += secondPriceValues(subSecondPricePeriod)

                                If secondPriceBidListSmall(secondPriceSmallGroup(subSecondPricePeriod), subSecondPricePeriod, 2) IsNot Nothing Then
                                    secondPriceEarnings -= secondPriceBidListSmall(secondPriceSmallGroup(subSecondPricePeriod), subSecondPricePeriod, 2).bid
                                Else
                                    secondPriceEarnings -= secondPriceBidListSmall(secondPriceSmallGroup(subSecondPricePeriod), subSecondPricePeriod, 1).bid
                                End If
                            End If
                        End If
                    End If
                End If


                Dim outstr As String = ""

                outstr = secondPriceEarnings & ";"
                outstr &= secondPriceMarketPayout(subSecondPricePeriod) & ";"

                Dim tempS As String = ""
                Dim tempN As Integer = 0

                'find groups
                Dim tempLargeGroup As Integer
                Dim tempSmallGroup As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempLargeGroup = secondPriceObserverLarge(subSecondPricePeriod)
                    tempSmallGroup = secondPriceObserverSmall(subSecondPricePeriod)
                Else
                    tempLargeGroup = myGroup(currentPeriod)
                    tempSmallGroup = secondPriceSmallGroup(subSecondPricePeriod)
                End If

                'large group
                For i As Integer = 1 To .getNumberInMyGroup(tempLargeGroup, currentPeriod)
                    If secondPriceBidListLarge(tempLargeGroup, subSecondPricePeriod, i) IsNot Nothing Then
                        tempN += 1

                        tempS &= secondPriceBidListLarge(tempLargeGroup, subSecondPricePeriod, i).getString

                        If secondPriceBidListLarge(tempLargeGroup, subSecondPricePeriod, i).owner = inumber Then
                            'record position in queue
                            secondPriceBidsLarge(subSecondPricePeriod).index = i
                        End If
                    Else
                        Exit For
                    End If
                Next

                outstr &= tempN & ";"
                outstr &= tempS

                'small groups
                tempN = 0
                tempS = ""

                For i As Integer = 1 To .getSecondPriceNumberInMyGroupSmall(tempSmallGroup, subSecondPricePeriod)
                    If secondPriceBidListSmall(tempSmallGroup, subSecondPricePeriod, i) IsNot Nothing Then
                        tempN += 1

                        tempS &= secondPriceBidListSmall(tempSmallGroup, subSecondPricePeriod, i).getString

                        If secondPriceBidListSmall(tempSmallGroup, subSecondPricePeriod, i).owner = inumber Then
                            'record position in queue
                            secondPriceBidsSmall(subSecondPricePeriod).index = i
                        End If
                    Else
                        Exit For
                    End If
                Next

                outstr &= tempN & ";"
                outstr &= tempS

                If phaseList(currentPeriod) = "English Auction" Then

                    outstr &= englishPriceLargePV(tempLargeGroup, subSecondPricePeriod) & ";"
                    outstr &= englishPriceSmallPV(tempSmallGroup, subSecondPricePeriod) & ";"
                End If


                sendMessage("05", outstr)

                updateEarningsDisplay()

                'data
                writeSecondPriceData(secondPriceBidsLarge(subSecondPricePeriod),
                                     secondPriceBidListLarge,
                                     myGroup(subSecondPricePeriod),
                                     secondPriceObserverLarge(subSecondPricePeriod),
                                     "large")

                writeSecondPriceData(secondPriceBidsSmall(subSecondPricePeriod),
                                    secondPriceBidListSmall,
                                    secondPriceSmallGroup(subSecondPricePeriod),
                                    secondPriceObserverSmall(subSecondPricePeriod),
                                    "small")

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub writeSecondPriceData(mySecondPriceBid As secondPriceBid,
                                    secondPriceBidList(,,) As secondPriceBid,
                                    group As Integer,
                                    observerGroup As Integer,
                                    grouptype As String)
        Try

            Dim str As String = ""
            '  "Period,Player,Group,Observer,GroupType,MarketPaid,Bid,BidIndex,Won,Value,PricePaid,Profit,TotalCash"

            str = subSecondPricePeriod & ","
            str &= inumber & ","
            str &= group & ","
            str &= observerGroup & ","
            str &= grouptype & ","

            If secondPriceMarketPayout(subSecondPricePeriod) = grouptype Then
                str &= "True" & ","
            Else
                str &= "False" & ","
            End If

            If observerGroup = -1 Then
                str &= mySecondPriceBid.bid & ","
                str &= mySecondPriceBid.index & ","

                If secondPriceBidList(group, subSecondPricePeriod, 1).owner = inumber Then
                    str &= "Yes,"
                    str &= secondPriceValues(subSecondPricePeriod) & ","

                    If secondPriceBidList(group, subSecondPricePeriod, 2) IsNot Nothing Then
                        str &= secondPriceBidList(group, subSecondPricePeriod, 2).bid & ","
                        str &= secondPriceValues(subSecondPricePeriod) - secondPriceBidList(group, subSecondPricePeriod, 2).bid & ","
                    Else
                        str &= secondPriceBidList(group, subSecondPricePeriod, 1).bid & ","
                        str &= secondPriceValues(subSecondPricePeriod) - secondPriceBidList(group, subSecondPricePeriod, 1).bid & ","
                    End If
                Else
                    str &= "No,"
                    str &= secondPriceValues(subSecondPricePeriod) & ","
                    str &= ",0,"
                End If
            Else
                str &= ",,"
                str &= "No,"
                str &= secondPriceValues(subSecondPricePeriod) & ","
                str &= ",0,"
            End If

            str &= secondPriceEarnings & ","

            secondPriceDf.WriteLine(str)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendEnglishStart()
        Try
            With frmServer
                Dim outstr As String = ""

                outstr = englishBids(subEnglishPeriod) & ";"

                sendMessage("06", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendEnglishUpdate(biddersLeft() As Integer)
        Try
            With frmServer
                Dim outstr As String = ""

                Dim tempGroup As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempGroup = englishObserver(subEnglishPeriod)
                Else
                    tempGroup = myGroup(currentPeriod)
                End If

                outstr = englishPrice(tempGroup, subEnglishPeriod) & ";"
                outstr &= englishBids(subEnglishPeriod) & ";"
                outstr &= biddersLeft(tempGroup) & ";"

                sendMessage("07", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendEnglishResult(biddersLeft() As Integer)
        Try
            With frmServer
                Dim outstr As String = ""

                Dim tempGroup As Integer
                Dim winner As Boolean = False

                If myGroup(currentPeriod) = -1 Then
                    tempGroup = englishObserver(subEnglishPeriod)
                Else
                    tempGroup = myGroup(currentPeriod)
                End If

                Dim tempPrice As Double

                If .getNumberInMyGroup(tempGroup, currentPeriod) > 1 And
                   (englishBidMode = "drop" Or (englishBidMode = "full" And englishPriceMode = "second")) Then
                    tempPrice = englishBidsListFinal(tempGroup, subEnglishPeriod, 2).bid
                Else
                    tempPrice = englishBidsListFinal(tempGroup, subEnglishPeriod, 1).bid
                End If


                Dim tempProfit As Double = englishValues(subEnglishPeriod) - tempPrice
                Dim tempBidderCount As Integer = .getNumberInMyGroup(tempGroup, currentPeriod)

                'calc earnings
                If englishWinners(tempGroup, subEnglishPeriod) = inumber Then

                    If subEnglishPeriod > practicePeriods Then
                        englishEarnings += tempProfit
                    End If

                    winner = True
                End If

                outstr = tempPrice & ";"
                outstr &= englishWinners(tempGroup, subEnglishPeriod) & ";"
                outstr &= englishValues(subEnglishPeriod) & ";"
                outstr &= tempProfit & ";"
                outstr &= englishEarnings & ";"

                outstr &= englishBids(subEnglishPeriod) & ";"

                outstr &= biddersLeft(tempGroup) & ";"

                outstr &= tempBidderCount & ";"

                For i As Integer = 1 To tempBidderCount
                    outstr &= englishBidsListFinal(tempGroup, subEnglishPeriod, i).returnString
                Next

                sendMessage("08", outstr)

                updateEarningsDisplay()

                '"Period,Player,Group,Observer,FinalBid,Signal,Winner,Price,ActualValue,Profit"
                Dim str As String = ""

                str = currentPeriod & ","

                If phaseList(currentPeriod) = "CV Full Info" Then
                    str &= "Full Info" & ","
                Else
                    str &= "Limited Info" & ","
                End If

                str &= inumber & ","
                str &= myGroup(currentPeriod) & ","
                str &= englishObserver(subEnglishPeriod) & ","
                str &= englishBids(subEnglishPeriod) & ","
                str &= englishSignals(subEnglishPeriod) & ","
                str &= englishRanges(subEnglishPeriod) & ","
                str &= winner & ","
                str &= tempPrice & ","
                str &= englishValues(subEnglishPeriod) & ","

                If winner Then
                    str &= tempProfit & ","
                Else
                    str &= "0" & ","
                End If

                englishDf.WriteLine(str)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub updateEarningsDisplay()
        Try
            If frmServer.dgMain.RowCount > 0 Then
                frmServer.dgMain(3, inumber - 1).Value = FormatCurrency(Math.Round(lotteryEarnings / 100, 2) +
                                                                           lotteryQuizEarnings +
                                                                           Math.Max(0, secondPriceEarnings) +
                                                                           secondPriceQuizEarnings +
                                                                           Math.Max(0, englishEarnings) +
                                                                           englishQuizEarnings,
                                                                       -1, TriState.UseDefault, TriState.False)
            End If

        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendFinishedInstructions()
        Try
            With frmServer
                Dim outstr As String = ""

                If phaseList(1) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                    outstr = getSecondPriceStart(subSecondPricePeriod)
                ElseIf phaseList(1) = "Lottery" Then
                    outstr = getLotteryStart(subLotteryPeriod)
                Else
                    outstr = getEnglishStart(subEnglishPeriod)
                End If

                sendMessage("FINISHED_INSTRUCTIONS", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendEnglishDelay()
        Try
            With frmServer
                Dim outstr As String = ""

                outstr &= englishCurrentStartDelay & ";"

                sendMessage("09", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendStopEnglishPV()
        Try
            With frmServer
                Dim outstr As String = ""

                Dim tempGroupLarge As Integer
                Dim tempGroupSmall As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempGroupLarge = secondPriceObserverLarge(subSecondPricePeriod)
                    tempGroupSmall = secondPriceObserverSmall(subSecondPricePeriod)
                Else
                    tempGroupLarge = myGroup(subSecondPricePeriod)
                    tempGroupSmall = secondPriceSmallGroup(subSecondPricePeriod)
                End If

                If englishSidePV(subSecondPricePeriod) = "large" Then
                    outstr &= englishPriceLargePV(tempGroupLarge, subSecondPricePeriod) & ";"
                Else
                    outstr &= englishPriceSmallPV(tempGroupSmall, subSecondPricePeriod) & ";"
                End If

                sendMessage("10", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendUpdateEnglishPV()
        Try
            With frmServer
                Dim outstr As String = ""

                Dim tempGroupLarge As Integer
                Dim tempGroupSmall As Integer

                If myGroup(currentPeriod) = -1 Then
                    tempGroupLarge = secondPriceObserverLarge(subSecondPricePeriod)
                    tempGroupSmall = secondPriceObserverSmall(subSecondPricePeriod)
                Else
                    tempGroupLarge = myGroup(subSecondPricePeriod)
                    tempGroupSmall = secondPriceSmallGroup(subSecondPricePeriod)
                End If

                If englishSidePV(subSecondPricePeriod) = "large" Then
                    outstr &= englishPriceLargePV(tempGroupLarge, subSecondPricePeriod) & ";"
                Else
                    outstr &= englishPriceSmallPV(tempGroupSmall, subSecondPricePeriod) & ";"
                End If

                sendMessage("01", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub sendEnglishResultsPV()
        Try
            Dim outstr As String = ""

            Dim tempGroupLarge As Integer
            Dim tempGroupSmall As Integer

            If myGroup(currentPeriod) = -1 Then
                tempGroupLarge = secondPriceObserverLarge(subSecondPricePeriod)
                tempGroupSmall = secondPriceObserverSmall(subSecondPricePeriod)
            Else
                tempGroupLarge = myGroup(subSecondPricePeriod)
                tempGroupSmall = secondPriceSmallGroup(subSecondPricePeriod)
            End If

            If englishSidePV(subSecondPricePeriod) = "large" Then
                outstr &= englishPriceLargePV(tempGroupLarge, subSecondPricePeriod) & ";"
            Else
                outstr &= englishPriceSmallPV(tempGroupSmall, subSecondPricePeriod) & ";"
            End If

            sendMessage("11", outstr)

        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub takeChatBotMessage(str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split("|")
                Dim nextToken As Integer = 0

                'take prompt
                Dim display_prompt As String = msgtokens(nextToken)
                Dim prompt As String = """" & msgtokens(nextToken).Replace("""", "`") & """"
                nextToken += 1

                'take response
                Dim display_response As String = msgtokens(nextToken)
                Dim response As String = """" & msgtokens(nextToken).Replace("""", "`") & """"
                nextToken += 1

                Dim outstr As String = ""

                outstr = currentPeriod & ","
                outstr &= phaseList(currentPeriod) & ","
                outstr &= inumber & ","
                outstr &= myGroup(currentPeriod) & ","
                outstr &= prompt & ","
                outstr &= response & ","

                chatBotDf.WriteLine(outstr)

                'add prompt to chat bot box
                Dim display_player As String = "*** Player " & inumber & " ***"

                .rtbChatBot.AppendText(display_player)
                .rtbChatBot.SelectionStart = .rtbChatBot.Text.Length - display_player.Length
                .rtbChatBot.SelectionLength = display_player.Length
                .rtbChatBot.SelectionAlignment = HorizontalAlignment.Center
                Dim currentFont As Font = .rtbChatBot.SelectionFont
                If currentFont IsNot Nothing Then
                    .rtbChatBot.SelectionFont = New Font(currentFont, FontStyle.Italic)
                End If
                .rtbChatBot.AppendText(vbCrLf)

                .rtbChatBot.AppendText(display_prompt)
                .rtbChatBot.SelectionStart = .rtbChatBot.Text.Length - display_prompt.Length
                .rtbChatBot.SelectionLength = display_prompt.Length
                .rtbChatBot.SelectionAlignment = HorizontalAlignment.Right
                .rtbChatBot.AppendText(vbCrLf & vbCrLf)

                'add response to chat bot box
                .rtbChatBot.AppendText(display_response)
                .rtbChatBot.SelectionStart = .rtbChatBot.Text.Length - display_response.Length
                .rtbChatBot.SelectionLength = display_response.Length
                .rtbChatBot.SelectionAlignment = HorizontalAlignment.Left
                .rtbChatBot.ScrollToCaret()
                .rtbChatBot.AppendText(vbCrLf & vbCrLf)

            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub
End Class
