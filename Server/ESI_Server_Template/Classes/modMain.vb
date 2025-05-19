Imports System.IO

Module modMain
    Public frmServer As New frmMain
    Public sfile As String

    Public clientCount As Integer = 0        'number of connected clients

    Public tempTime As String                'time stamp at start of experiment

    Public playerlist(1000) As player

    Public numberOfPlayers As Integer
    Public numberOfPeriods As Integer
    Public portNumber As Integer
    Public instructionX As Integer
    Public instructionY As Integer
    Public windowX As Integer
    Public windowY As Integer
    Public showInstructions As Boolean
    Public testMode As Boolean
    Public filename As String                        'location of data file
    Public enableChatBot As Boolean

    Public currentPeriod As Integer
    Public subLotteryPeriod As Integer
    Public subSecondPricePeriod As Integer
    Public subEnglishPeriod As Integer
    Public phaseList(1000) As String
    Public quizQuestionValue As Double
    Public practicePeriods As Double

    Public numberOfPeriodsLottery As Integer
    Public numberOfPeriodsSecondPrice As Integer
    Public numberOfPeriodsEnglish As Integer

    'second price
    Public secondPriceBidListLarge(10, 100, 100) As secondPriceBid   'group, sub period, bid
    Public secondPriceBidListSmall(10, 100, 100) As secondPriceBid   'group, sub period, bid
    Public secondPriceStartingCash As Integer
    Public secondPriceGroups(7, 100) As Integer                      'group, number of players
    Public secondPriceNumberOfGroupsLarge(100) As Integer
    Public secondPriceNumberOfGroupsSmall(100) As Integer
    Public secondPriceValues(12, 100) As Double                      'player,period
    Public secondPriceStartValue As Double
    Public secondPriceEndValue As Double
    Public secondPriceMarketPayout(100) As String                    'large or small payout 
    Public secondPriceMaxBid As Double
    Public secondPriceExampleCount As Integer
    Public secondPriceExamplesLarge(100) As String
    Public secondPriceExamplesSmall(100) As String

    'english private value
    Public englishTickRatePV As Double
    Public englishTickAmountPV As Double
    Public englishPVSecondPriceShowProfit As Boolean
    Public englishPriceSmallPV(10, 100) As Double         'group, period
    Public englishPriceLargePV(10, 100) As Double         'group, period
    Public englishSmallDonePV(100) As Boolean    'group, period
    Public englishLargeDonePV(100) As Boolean    'group, period
    Public englishSidePV(100) As String             'period 

    'lotteries
    Public lotteryTicketCount As Integer
    Public lotteryChoicePeriods(100) As lotteryChoicePeriod
    Public lotteryPeriodLength As Integer

    'english common value
    Public englishSignals(10, 100) As Double      'person, period
    Public englishGroups(7, 100) As Integer        'group, number of players 
    Public englishRanges(100) As Integer
    Public englishStartingCash As Integer
    Public englishTickRate As Integer
    Public englishTickAmount(7) As Double
    Public englishMinValue As Integer
    Public englishMaxValue As Integer
    Public englishPrice(6, 100) As Double                     'group, period
    Public englishStartPrice As Integer
    Public englishEndPrice As Integer
    Public englishNumberOfGroups(100) As Integer
    Public englishPhase As String
    Public englishWinners(6, 100) As Integer                  'group,period
    Public englishBidsListFinal(6, 100, 100) As englishBid    'group,sub period, bid 
    Public englishValues(100) As Double                      'group,period
    Public englishStartScale As Integer
    Public englishEndScale As Integer
    Public englishLastDropPrice(7) As Double
    Public englishBidMode As String
    Public englishStartDelay As Integer
    Public englishCurrentStartDelay As Integer
    Public englishPriceMode As String

    'data files
    Public secondPriceDf As StreamWriter             'second price data file
    Public lotteryDf As StreamWriter                 'lottery data file
    Public englishDf As StreamWriter                 'lottery data file
    Public english2Df As StreamWriter                'lottery data file
    Public chatBotDf As StreamWriter                 'chat bot data file

    Public checkin As Integer = 0

    Public Sub main()
        Try
            sfile = Application.StartupPath & "\server.ini"

            AppEventLog_Init()
            appEventLog_Write("Load")

            loadParameters()

            Application.EnableVisualStyles()
            Application.Run(frmServer)

            appEventLog_Write("Exit")
            AppEventLog_Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadParameters()
        Try

            numberOfPlayers = getINI(sfile, "gameSettings", "numberOfPlayers")
            numberOfPeriods = getINI(sfile, "gameSettings", "numberOfPeriods")
            portNumber = getINI(sfile, "gameSettings", "port")
            instructionX = getINI(sfile, "gameSettings", "instructionX")
            instructionY = getINI(sfile, "gameSettings", "instructionY")
            windowX = getINI(sfile, "gameSettings", "windowX")
            windowY = getINI(sfile, "gameSettings", "windowY")
            showInstructions = getINI(sfile, "gameSettings", "showInstructions")
            testMode = getINI(sfile, "gameSettings", "testMode")
            quizQuestionValue = getINI(sfile, "gameSettings", "quizQuestionValue")
            practicePeriods = getINI(sfile, "gameSettings", "practicePeriods")
            enableChatBot = getINI(sfile, "gameSettings", "enableChatBot")

            lotteryTicketCount = getINI(sfile, "gameSettings", "lotteryTicketCount")
            lotteryPeriodLength = getINI(sfile, "gameSettings", "lotteryPeriodLength")

            englishStartingCash = getINI(sfile, "gameSettings", "englishStartingCash")
            englishTickRate = getINI(sfile, "gameSettings", "englishTickRate")
            englishMinValue = getINI(sfile, "gameSettings", "englishMinValue")
            englishMaxValue = getINI(sfile, "gameSettings", "englishMaxValue")
            englishStartPrice = getINI(sfile, "gameSettings", "englishStartPrice")
            englishEndPrice = getINI(sfile, "gameSettings", "englishEndPrice")
            englishStartScale = getINI(sfile, "gameSettings", "englishStartScale")
            englishEndScale = getINI(sfile, "gameSettings", "englishEndScale")
            englishBidMode = getINI(sfile, "gameSettings", "englishBidMode")
            englishStartDelay = getINI(sfile, "gameSettings", "englishStartDelay")
            englishPriceMode = getINI(sfile, "gameSettings", "englishPriceMode")

            secondPriceStartingCash = getINI(sfile, "gameSettings", "secondPriceStartingCash")
            secondPriceStartValue = CDbl(getINI(sfile, "gameSettings", "secondPriceStartValue")) / 100
            secondPriceEndValue = CDbl(getINI(sfile, "gameSettings", "secondPriceEndValue")) / 100
            secondPriceMaxBid = getINI(sfile, "gameSettings", "secondPriceMaxBid")

            englishTickRatePV = getINI(sfile, "gameSettings", "englishTickRatePV")
            englishTickAmountPV = getINI(sfile, "gameSettings", "englishTickAmountPV")
            englishPVSecondPriceShowProfit = getINI(sfile, "gameSettings", "englishPVSecondPriceShowProfit")

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeMessage(sinstr() As String)
        Try
            With frmServer
                Dim index As Integer = sinstr(0)
                Dim str As String = sinstr(1)

                Dim tempa(2) As String
                tempa(1) = "<SEP>"
                tempa(2) = "<EOF>"
                Dim msgtokens() As String = str.Split(tempa, 3, StringSplitOptions.None)

                Dim id As String = msgtokens(0)
                Dim message As String = msgtokens(1)

                Select Case id
                    Case "COMPUTER_NAME"
                        takeRemoteComputerName(index, message)
                    Case "SUBJECT_NAME"
                        takeName(index, message)
                    Case "FINSHED_INSTRUCTIONS"
                        takeFinishedInstructions(index, message)
                    Case "INSTRUCTION_PAGE"
                        takeInstructionPage(index, message)
                    Case "01"
                        takeLottery(index, message)
                    Case "02"
                        takeError(index, message)
                    Case "03"
                        takeReadyToGoOn(index, message)
                    Case "04"
                        takeSecondPriceBid(index, message)
                    Case "05"
                        takeEnglishBid(index, message)
                    Case "06"
                        takeEnglishPVBid(index, message)
                    Case "07"
                        takeChatBotMessage(index, message)
                    Case "08"
                    Case "09"
                    Case "10"

                End Select
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeRemoteComputerName(index As Integer, str As String)
        Try
            Dim msgtokens() As String = str.Split(";")
            Dim nextToken As Integer = 0

            playerlist(index).sp.remoteComputerName = msgtokens(nextToken)
            nextToken += 1
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub takeError(index As Integer, str As String)
        Try
            With frmServer
                .txtError.AppendText(index & ": " & str & vbCrLf)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeLottery(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempC As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempAuto As String = msgtokens(nextToken)
                nextToken += 1

                playerlist(index).lotteryChoices(subLotteryPeriod) = tempC
                playerlist(index).lotteryChoicesAuto(subLotteryPeriod) = tempAuto

                .dgMain(2, index - 1).Value = "Waiting"

                checkin += 1

                If checkin = numberOfPlayers Then
                    checkin = 0

                    Dim tempRedCount As Integer = 0
                    Dim tempBlueCount As Integer = 0

                    'write data
                    'Dim tempS1 As String = getINI(sfile, "lotteries", subLotteryPeriod & "-Red").Replace(";", ",")
                    'Dim tempS2 As String = getINI(sfile, "lotteries", subLotteryPeriod & "-Blue").Replace(";", ",")

                    For i As Integer = 1 To numberOfPlayers

                        If playerlist(i).lotteryChoices(subLotteryPeriod) = "Red" Then
                            If playerlist(i).lotteryChoicesFlipped(subLotteryPeriod) Then
                                tempBlueCount += 1
                            Else
                                tempRedCount += 1
                            End If

                        Else
                            If playerlist(i).lotteryChoicesFlipped(subLotteryPeriod) Then
                                tempRedCount += 1
                            Else
                                tempBlueCount += 1
                            End If
                        End If

                        Dim outstr As String = ""

                        outstr = subLotteryPeriod & ","
                        outstr &= i & ","
                        outstr &= subLotteryPeriod & ","
                        outstr &= playerlist(i).lotteryChoices(subLotteryPeriod) & ","
                        outstr &= playerlist(i).lotteryChoicesAuto(subLotteryPeriod) & ","

                        If playerlist(i).lotteryChoicesFlipped(subLotteryPeriod) Then
                            outstr &= lotteryChoicePeriods(subLotteryPeriod).getBlueString(",")
                            outstr &= lotteryChoicePeriods(subLotteryPeriod).getRedString(",")
                        Else
                            outstr &= lotteryChoicePeriods(subLotteryPeriod).getRedString(",")
                            outstr &= lotteryChoicePeriods(subLotteryPeriod).getBlueString(",")
                        End If

                        outstr &= lotteryChoicePeriods(subLotteryPeriod).winningNumber & ","
                        outstr &= playerlist(i).lotteryChoicesFlipped(subLotteryPeriod) & ","

                        lotteryDf.WriteLine(outstr)
                    Next

                    'update display
                    .dgLottery(1, subLotteryPeriod * 2 - 2).Value = tempRedCount
                    .dgLottery(1, subLotteryPeriod * 2 - 1).Value = tempBlueCount

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendLotteryResult()
                    Next

                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub doLotteryPayout(payoutPeriod As Integer, payoutTicket As Integer)
        Try
            With frmServer
                'lotteryDf.WriteLine(",")
                'lotteryDf.WriteLine("Payout Period," & payoutPeriod)
                'lotteryDf.WriteLine("Payout Ticket," & payoutTicket)
                'lotteryDf.WriteLine(",")

                'lotteryDf.WriteLine("ID,Name,Student ID,Lottery Earnings")

                'For i As Integer = 1 To numberOfPlayers
                '    playerlist(i).sendLotteryResult(payoutPeriod, payoutTicket)
                '    .dgMain(2, i - 1).Value = "Reviewing Results"
                'Next
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeLotteryFinished(index As Integer, str As String)
        Try
            If checkin = numberOfPlayers Then
                checkin = 0

                startNextPeriod()
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub startNextPeriod()
        Try
            With frmServer
                If currentPeriod = numberOfPeriods And
                    ((phaseList(currentPeriod) = "English Auction" And englishLargeDonePV(subSecondPricePeriod) And englishSmallDonePV(subSecondPricePeriod)) _
                    Or phaseList(currentPeriod) <> "English Auction") Then
                    'end game

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendShowName()
                    Next
                Else

                    If phaseList(currentPeriod + 1) = "Lottery" Then
                        currentPeriod += 1
                        subLotteryPeriod += 1
                    ElseIf phaseList(currentPeriod + 1) = "2nd Price" Or
                    (phaseList(currentPeriod + 1) = "English Auction" And englishLargeDonePV(subSecondPricePeriod) And englishSmallDonePV(subSecondPricePeriod)) Then
                        subSecondPricePeriod += 1
                        currentPeriod += 1

                        'if all bankrupt then exit.
                        If Not setupGroupsSecondPrice() Then Exit Sub

                        For i As Integer = 1 To numberOfPlayers
                            If playerlist(i).myGroup(currentPeriod) = -1 Then checkin += 1
                        Next

                        'start english clock
                        If phaseList(currentPeriod) = "English Auction" Then
                            .Timer4.Enabled = True
                        End If
                    ElseIf phaseList(currentPeriod) = "English Auction" Then

                        'do english auction sub period
                        If englishSidePV(subSecondPricePeriod) = "large" Then
                            englishSidePV(subSecondPricePeriod) = "small"
                        Else
                            englishSidePV(subSecondPricePeriod) = "large"
                        End If
                    Else
                        currentPeriod += 1
                        subEnglishPeriod += 1
                        englishPhase = "start"

                        setupGroupsEnglish()

                        For i As Integer = 1 To numberOfPlayers
                            If playerlist(i).myGroup(currentPeriod) = -1 Then
                                checkin += 1
                            End If
                        Next
                    End If

                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendStartNextPeriod()

                        refreshDisplayStatus(i)
                    Next

                    'start delay for enlglish drop mode
                    If (phaseList(1) = "CV Full Info" Or phaseList(1) = "CV Limited Info") And englishBidMode = "drop" Then
                        englishCurrentStartDelay = englishStartDelay
                        .Timer3.Enabled = True
                    End If

                End If

                .updatePeriodDisplay()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshDisplayStatus(index As Integer)
        Try
            With frmServer
                If phaseList(currentPeriod) = "Lottery" Then
                    .dgMain(2, index - 1).Value = "Playing"
                ElseIf phaseList(currentPeriod) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                    If playerlist(index).secondPriceEarnings < 0 Then
                        .dgMain(2, index - 1).Value = "Out"
                    ElseIf playerlist(index).myGroup(currentPeriod) = -1 Then
                        .dgMain(2, index - 1).Value = "Observing"
                    Else
                        .dgMain(2, index - 1).Value = "Playing"
                    End If
                Else
                    If playerlist(index).englishEarnings < 0 Then
                        .dgMain(2, index - 1).Value = "Out"
                    ElseIf playerlist(index).myGroup(currentPeriod) = -1 Then
                        .dgMain(2, index - 1).Value = "Observing"
                    Else
                        .dgMain(2, index - 1).Value = "Playing"
                    End If
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeName(index As Integer, str As String)
        Try
            With frmServer

                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                playerlist(index).name = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                playerlist(index).studentID = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                .dgMain(1, index - 1).Value = playerlist(index).name

                checkin += 1

                If checkin = numberOfPlayers Then
                    checkin = 0

                    'lottery data
                    If numberOfPeriodsLottery > 0 Then
                        lotteryDf.WriteLine(",")
                        lotteryDf.Write("Number,Name,Student ID,Lottery Earnings,Quiz Earnings,")

                        For i As Integer = 1 To 4
                            lotteryDf.Write("Quiz Answer " & i & "," & "Quiz Result " & i & ",")
                        Next
                        lotteryDf.WriteLine("")

                        For i As Integer = 1 To numberOfPlayers
                            Dim outstr As String = ""

                            outstr = playerlist(i).inumber & ","
                            outstr &= playerlist(i).name & ","
                            outstr &= playerlist(i).studentID & ","
                            outstr &= FormatCurrency(Math.Round(playerlist(i).lotteryEarnings / 100D, 2)) & ","
                            outstr &= FormatCurrency(playerlist(i).lotteryQuizEarnings) & ","

                            For j As Integer = 1 To 4
                                outstr &= playerlist(i).lotteryAnswers(j) & ","
                                outstr &= playerlist(i).lotteryAnswerResults(j) & ","
                            Next

                            lotteryDf.WriteLine(outstr)
                        Next

                        lotteryDf.Close()
                    End If

                    'second price data
                    If numberOfPeriodsSecondPrice > 0 Then
                        secondPriceDf.WriteLine(",")
                        secondPriceDf.Write("Number,Name,Student ID,Experiment Earnings,Quiz Earnings,")

                        For i As Integer = 1 To 5
                            secondPriceDf.Write("Quiz Answer " & i & "," & "Quiz Result " & i & ",")
                        Next
                        secondPriceDf.WriteLine("")

                        For i As Integer = 1 To numberOfPlayers
                            Dim outstr As String = ""

                            outstr = playerlist(i).inumber & ","
                            outstr &= playerlist(i).name & ","
                            outstr &= playerlist(i).studentID & ","
                            outstr &= FormatCurrency(playerlist(i).secondPriceEarnings) & ","
                            outstr &= FormatCurrency(playerlist(i).secondPriceQuizEarnings) & ","

                            For j As Integer = 1 To 6
                                outstr &= playerlist(i).secondPriceAnswers(j) & ","
                                outstr &= playerlist(i).secondPriceAnswerResults(j) & ","
                            Next

                            secondPriceDf.WriteLine(outstr)
                        Next

                        secondPriceDf.Close()
                    End If

                    'english data
                    If numberOfPeriodsEnglish > 0 Then
                        englishDf.WriteLine(",")
                        englishDf.Write("Number,Name,Student ID,English Earnings,English Quiz Earnings,")

                        For i As Integer = 1 To 6
                            englishDf.Write("Quiz Answer " & i & "," & "Quiz Result " & i & ",")
                        Next
                        englishDf.WriteLine("")

                        For i As Integer = 1 To numberOfPlayers
                            Dim outstr As String = ""

                            outstr = playerlist(i).inumber & ","
                            outstr &= playerlist(i).name & ","
                            outstr &= playerlist(i).studentID & ","
                            outstr &= FormatCurrency(playerlist(i).englishEarnings) & ","
                            outstr &= FormatCurrency(playerlist(i).englishQuizEarnings) & ","

                            For j As Integer = 1 To 6
                                outstr &= playerlist(i).englishAnswers(j) & ","
                                outstr &= playerlist(i).englishAnswerResults(j) & ","
                            Next

                            englishDf.WriteLine(outstr)
                        Next

                        englishDf.Close()
                    End If

                    If english2Df IsNot Nothing Then english2Df.Close()
                    If chatBotDf IsNot Nothing Then chatBotDf.Close()

                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    'Public Function checkForLastSubperiod()
    '    Try
    '        For i As Integer = currentPeriod + 1 To numberOfPeriods
    '            For i As Integer = currentPeriod + 1 To numberOfPeriods
    '                If phaseList(i) = phaseList(currentPeriod) Then Return False
    '            Next

    '            Return True
    '        Next
    '    Catch ex As Exception
    '        appEventLog_Write("error :", ex)
    '        Return False
    '    End Try
    'End Function

    Public Sub takeReadyToGoOn(index As Integer, str As String)
        Try
            With frmServer
                checkin += 1

                .dgMain(2, index - 1).Value = "Waiting"

                If checkin = numberOfPlayers Then
                    checkin = 0

                    startNextPeriod()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function setupGroupsSecondPrice() As Boolean
        Try
            With frmServer
                Dim tempEligible As Integer = 0

                'find number of eligble players

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).secondPriceEarnings >= 0 Then
                        tempEligible += 1
                    End If
                Next

                'if all bankrupt skip period
                If (phaseList(currentPeriod) = "2nd Price" And tempEligible = 0) Or
                   (phaseList(currentPeriod) = "English Auction" And tempEligible = 1) Then

                    checkin = 0
                    numberOfPeriods = currentPeriod

                    If phaseList(currentPeriod) = "English Auction" Then
                        englishLargeDonePV(subSecondPricePeriod) = True
                        englishSmallDonePV(subSecondPricePeriod) = True

                        .Timer4.Enabled = False
                    End If

                    startNextPeriod()

                    Return False
                End If

                Dim tempLargeGroup As Integer = 1
                Dim tempSmallGroup As Integer = 1
                secondPriceNumberOfGroupsLarge(subSecondPricePeriod) = 1
                secondPriceNumberOfGroupsSmall(subSecondPricePeriod) = 1

                Dim tempSpotsLeftLarge As Integer = secondPriceGroups(1, tempEligible)
                Dim tempSpotsLeftSmall As Integer = secondPriceGroups(2, tempEligible)

                Dim go As Boolean = True

                While go
                    Dim tempPerson As Integer = rand(numberOfPlayers, 1)

                    If playerlist(tempPerson).secondPriceEarnings >= 0 And
                playerlist(tempPerson).myGroup(currentPeriod) = -1 Then

                        playerlist(tempPerson).myGroup(currentPeriod) = tempLargeGroup
                        playerlist(tempPerson).secondPriceSmallGroup(currentPeriod) = tempSmallGroup

                        playerlist(tempPerson).secondPriceValues(subSecondPricePeriod) = secondPriceValues(tempSpotsLeftLarge, subSecondPricePeriod)

                        tempSpotsLeftLarge -= 1
                        tempSpotsLeftSmall -= 1

                        If tempSpotsLeftLarge = 0 Then
                            If tempLargeGroup = 2 Then
                                go = False
                            ElseIf secondPriceGroups(4, tempEligible) = 0 Then
                                go = False
                            Else
                                tempLargeGroup = 2
                                tempSmallGroup = 3
                                tempSpotsLeftLarge = secondPriceGroups(4, tempEligible)
                                tempSpotsLeftSmall = secondPriceGroups(5, tempEligible)

                                secondPriceNumberOfGroupsLarge(subSecondPricePeriod) = 2
                                secondPriceNumberOfGroupsSmall(subSecondPricePeriod) = 3
                            End If
                        ElseIf tempSpotsLeftSmall = 0 Then
                            If tempSmallGroup = 1 Then
                                tempSmallGroup = 2
                                tempSpotsLeftSmall = secondPriceGroups(3, tempEligible)
                                secondPriceNumberOfGroupsSmall(subSecondPricePeriod) = 2
                            Else
                                tempSmallGroup = 4
                                tempSpotsLeftSmall = secondPriceGroups(6, tempEligible)
                                secondPriceNumberOfGroupsSmall(subSecondPricePeriod) = 4
                            End If
                        End If

                    End If

                End While

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).myGroup(currentPeriod) = -1 Then
                        playerlist(i).secondPriceObserverLarge(subSecondPricePeriod) = rand(1, secondPriceNumberOfGroupsLarge(subSecondPricePeriod))
                        playerlist(i).secondPriceObserverSmall(subSecondPricePeriod) = rand(1, secondPriceNumberOfGroupsSmall(subSecondPricePeriod))

                        .dgMain(4, i - 1).Value = "-"
                    Else
                        .dgMain(4, i - 1).Value = "B:" & playerlist(i).myGroup(currentPeriod) & " S:" & playerlist(i).secondPriceSmallGroup(currentPeriod)
                    End If
                Next

                Return True
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Function

    Public Sub takeSecondPriceBid(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempBidLarge As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempBidSmall As Double = msgtokens(nextToken)
                nextToken += 1

                playerlist(index).secondPriceBidsLarge(subSecondPricePeriod) = New secondPriceBid(tempBidLarge, -1, index, subSecondPricePeriod, playerlist(index).secondPriceValues(subSecondPricePeriod))
                playerlist(index).secondPriceBidsSmall(subSecondPricePeriod) = New secondPriceBid(tempBidSmall, -1, index, subSecondPricePeriod, playerlist(index).secondPriceValues(subSecondPricePeriod))

                .dgMain(2, index - 1).Value = "Waiting"

                checkin += 1

                If checkin = numberOfPlayers Then
                    checkin = 0

                    calcSecondPriceEnglishPVWinner()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub calcSecondPriceEnglishPVWinner()
        Try
            With frmServer
                'winning market type
                If rand(2, 1) = 1 Then
                    secondPriceMarketPayout(subSecondPricePeriod) = "large"
                Else
                    secondPriceMarketPayout(subSecondPricePeriod) = "small"
                End If

                'sort bids
                For i As Integer = 1 To numberOfPlayers

                    If playerlist(i).myGroup(currentPeriod) <> -1 Then     'if out of cash, no bid

                        secondPriceInsertBid(playerlist(i).myGroup(currentPeriod),
                                        secondPriceBidListLarge,
                                        playerlist(i).secondPriceBidsLarge(subSecondPricePeriod),
                                        i)

                        secondPriceInsertBid(playerlist(i).secondPriceSmallGroup(currentPeriod),
                                    secondPriceBidListSmall,
                                    playerlist(i).secondPriceBidsSmall(subSecondPricePeriod),
                                    i)
                    End If
                Next

                For i As Integer = 1 To numberOfPlayers
                    playerlist(i).sendSecondPriceResults()

                    If playerlist(i).secondPriceEarnings < 0 Then
                        .dgMain(2, i - 1).Value = "Out"
                    Else
                        .dgMain(2, i - 1).Value = "Reviewing Results"
                    End If

                Next

                'anyone who is already below zero cash
                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).secondPriceEarnings < 0 Then checkin += 1
                Next

                'all bankrupt
                If checkin = numberOfPlayers Then
                    checkin = 0
                    startNextPeriod()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub secondPriceInsertBid(tempGroup As Integer, ByRef bidlist(,,) As secondPriceBid, newBid As secondPriceBid, playerIndex As Integer)
        Try
            'group,period,bid
            Dim tempSpot As Integer = -1
            For j As Integer = 1 To numberOfPlayers
                If bidlist(tempGroup, subSecondPricePeriod, j) IsNot Nothing Then

                    If bidlist(tempGroup, subSecondPricePeriod, j) < newBid Then
                        tempSpot = j
                        Exit For
                    ElseIf bidlist(tempGroup, subSecondPricePeriod, j) = newBid Then
                        If rand(2, 1) = 1 Then
                            tempSpot = j
                            Exit For
                        End If
                    End If
                Else
                    tempSpot = j
                    Exit For
                End If
            Next

            If bidlist(tempGroup, subSecondPricePeriod, tempSpot) IsNot Nothing Then
                For j As Integer = numberOfPlayers To tempSpot + 1 Step -1
                    If bidlist(tempGroup, subSecondPricePeriod, j - 1) IsNot Nothing Then
                        bidlist(tempGroup, subSecondPricePeriod, j) = New secondPriceBid(bidlist(tempGroup, subSecondPricePeriod, j - 1).bid,
                                                                                            playerIndex,
                                                                                            bidlist(tempGroup, subSecondPricePeriod, j - 1).owner,
                                                                                            bidlist(tempGroup, subSecondPricePeriod, j - 1).subPeriod,
                                                                                            bidlist(tempGroup, subSecondPricePeriod, j - 1).value)

                    End If
                Next
            End If

            bidlist(tempGroup, subSecondPricePeriod, tempSpot) = New secondPriceBid(newBid.bid,
                                                                                        tempSpot,
                                                                                        newBid.owner,
                                                                                        newBid.subPeriod,
                                                                                        newBid.value)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub doPeriodCount()
        Try
            numberOfPeriodsLottery = 0
            numberOfPeriodsSecondPrice = 0
            numberOfPeriodsEnglish = 0

            For i As Integer = 1 To numberOfPeriods
                phaseList(i) = getINI(sfile, "periodSetup", CStr(i))

                If phaseList(i) = "Lottery" Then
                    numberOfPeriodsLottery += 1
                ElseIf phaseList(i) = "2nd Price" Or phaseList(i) = "English Auction SL" Or phaseList(i) = "English Auction LS" Then
                    numberOfPeriodsSecondPrice += 1
                Else
                    numberOfPeriodsEnglish += 1
                End If
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupGroupsEnglish()
        Try
            With frmServer

                'find number of eligible people
                Dim tempEligible As Integer = 0
                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).englishEarnings >= 0 Then tempEligible += 1
                Next

                'all bankrupt
                If tempEligible = 0 Then
                    checkin = 0
                    startNextPeriod()
                    Exit Sub
                End If

                Dim tempGroup As Integer = 1
                Dim tempSpotsLeft As Integer = englishGroups(tempGroup, tempEligible)

                englishNumberOfGroups(subEnglishPeriod) = 1

                Dim go As Boolean = True

                While go

                    Dim tempPerson As Integer = rand(numberOfPlayers, 1)

                    If playerlist(tempPerson).englishEarnings >= 0 And
                playerlist(tempPerson).myGroup(currentPeriod) = -1 Then

                        playerlist(tempPerson).myGroup(currentPeriod) = tempGroup
                        playerlist(tempPerson).englishID(subEnglishPeriod) = tempSpotsLeft
                        playerlist(tempPerson).englishSignals(subEnglishPeriod) = englishSignals(tempSpotsLeft, subEnglishPeriod)

                        tempSpotsLeft -= 1
                    End If

                    If tempSpotsLeft = 0 Then
                        tempGroup += 1

                        If tempGroup = 7 Then
                            go = False
                        ElseIf englishGroups(tempGroup, tempEligible) = 0 Then
                            go = False
                        Else
                            tempSpotsLeft = englishGroups(tempGroup, tempEligible)
                        End If

                        'If tempE < tempSpotsLeft Then
                        '    go = False
                        'End If

                        If go Then
                            englishNumberOfGroups(subEnglishPeriod) += 1
                        End If
                    End If
                End While

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).myGroup(currentPeriod) = -1 Then
                        playerlist(i).englishObserver(subEnglishPeriod) = rand(1, englishNumberOfGroups(subEnglishPeriod))

                        .dgMain(4, i - 1).Value = "-"
                    Else
                        .dgMain(4, i - 1).Value = playerlist(i).myGroup(currentPeriod)
                    End If

                    If englishBidMode = "drop" Then
                        playerlist(i).englishBids(subEnglishPeriod) = 10000
                    End If
                Next

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishBid(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                playerlist(index).englishBids(subEnglishPeriod) = msgtokens(nextToken)
                nextToken += 1

                .dgMain(2, index - 1).Value = "Waiting"

                If englishPhase = "start" Then

                    Dim tempStart As Boolean = True

                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).myGroup(currentPeriod) <> -1 And playerlist(i).englishBids(subEnglishPeriod) = -1 Then
                            tempStart = False
                        End If
                    Next

                    If tempStart Then
                        checkin = 0

                        If englishBidMode = "drop" Then
                            startEnglishClock()
                        Else
                            .englishDoResults({0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
                        End If
                    End If
                Else
                    .englishCheckForStopage(index)
                End If

                'data
                Dim biddersLeft(10) As Integer
                .englishCalcBiddersLeft(biddersLeft)

                ' str = "Period,Player,Group,Bid,Signal,ActualValue,CurrentPrice,BidderRemaining"
                Dim str2 As String = ""

                str2 = currentPeriod & ","

                If phaseList(currentPeriod) = "CV Full Info" Then
                    str2 &= "Full Info" & ","
                Else
                    str2 &= "Limited Info" & ","
                End If

                str2 &= index & ","
                str2 &= playerlist(index).myGroup(currentPeriod) & ","
                str2 &= playerlist(index).englishBids(subEnglishPeriod) & ","
                str2 &= playerlist(index).englishSignals(subEnglishPeriod) & ","
                str2 &= englishRanges(subEnglishPeriod) & ","
                str2 &= englishValues(subEnglishPeriod) & ","

                If playerlist(index).myGroup(currentPeriod) <> -1 And englishBidMode = "drop" Then
                    str2 &= englishPrice(playerlist(index).myGroup(currentPeriod), subEnglishPeriod) & ","
                    str2 &= biddersLeft(playerlist(index).myGroup(currentPeriod)) & ","
                    str2 &= englishLastDropPrice(playerlist(index).myGroup(currentPeriod)) & ","
                Else
                    str2 &= ",,,"
                End If

                english2Df.WriteLine(str2)
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub startEnglishClock()
        Try
            With frmServer
                englishPhase = "play"
                checkin = 0
                For i As Integer = 1 To numberOfPlayers
                    playerlist(i).sendEnglishStart()

                    If playerlist(i).myGroup(currentPeriod) <> -1 Then
                        .dgMain(2, i - 1).Value = "Playing"
                    End If
                Next

                .Timer2.Interval = englishTickRate
                .Timer2.Enabled = True
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeFinishedInstructions(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempCount As Integer = msgtokens(nextToken)
                nextToken += 1

                If phaseList(currentPeriod) = "CV Full Info" Or
                    phaseList(currentPeriod) = "CV Limited Info" Then

                    playerlist(index).englishQuizEarnings = 0

                    For i As Integer = 1 To tempCount
                        playerlist(index).englishAnswerResults(i) = msgtokens(nextToken)
                        nextToken += 1

                        playerlist(index).englishAnswers(i) = msgtokens(nextToken)
                        nextToken += 1

                        If playerlist(index).englishAnswerResults(i) = "Correct" Then
                            playerlist(index).englishQuizEarnings += quizQuestionValue
                        End If
                    Next
                ElseIf phaseList(currentPeriod) = "2nd Price" Or phaseList(currentPeriod) = "English Auction" Then
                    playerlist(index).secondPriceQuizEarnings = 0

                    For i As Integer = 1 To tempCount
                        playerlist(index).secondPriceAnswerResults(i) = msgtokens(nextToken)
                        nextToken += 1

                        playerlist(index).secondPriceAnswers(i) = msgtokens(nextToken)
                        nextToken += 1

                        If playerlist(index).secondPriceAnswerResults(i) = "Correct" Then
                            playerlist(index).secondPriceQuizEarnings += quizQuestionValue
                        End If
                    Next
                ElseIf phaseList(currentPeriod) = "Lottery" Then
                    playerlist(index).lotteryQuizEarnings = 0

                    For i As Integer = 1 To tempCount
                        playerlist(index).lotteryAnswerResults(i) = msgtokens(nextToken)
                        nextToken += 1

                        playerlist(index).lotteryAnswers(i) = msgtokens(nextToken)
                        nextToken += 1

                        If playerlist(index).lotteryAnswerResults(i) = "Correct" Then
                            playerlist(index).lotteryQuizEarnings += quizQuestionValue
                        End If
                    Next
                End If

                checkin += 1

                .dgMain(2, index - 1).Value = "Waiting"

                If checkin = numberOfPlayers Then

                    MessageBox.Show("Start Experiment?", "Start", MessageBoxButtons.OK, MessageBoxIcon.Question)

                    checkin = 0

                    'if not not playing don't wait for users response
                    If phaseList(currentPeriod) <> "Lottery" Then
                        For i As Integer = 1 To numberOfPlayers
                            If playerlist(i).myGroup(currentPeriod) = -1 Then checkin += 1
                        Next
                    End If

                    For i As Integer = 1 To numberOfPlayers
                            playerlist(i).sendFinishedInstructions()

                            refreshDisplayStatus(i)
                        Next

                        If (phaseList(1) = "CV Full Info" Or phaseList(1) = "CV Limited Info") And englishBidMode = "drop" Then
                            englishCurrentStartDelay = englishStartDelay
                            .Timer3.Enabled = True
                        End If

                        If phaseList(1) = "English Auction" Then
                            If phaseList(currentPeriod) = "English Auction" Then .Timer4.Enabled = True
                        End If
                    End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeInstructionPage(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                Dim tempPage As Integer = msgtokens(nextToken)
                nextToken += 1

                .dgMain(2, index - 1).Value = "Page " & tempPage
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub takeEnglishPVBid(index As Integer, str As String)
        Try
            With frmServer
                Dim msgtokens() As String = str.Split(";")
                Dim nextToken As Integer = 0

                'take bid
                Dim tempBid As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempGroup As Integer

                If englishSidePV(currentPeriod) = "large" Then
                    tempGroup = playerlist(index).myGroup(currentPeriod)
                Else
                    tempGroup = playerlist(index).secondPriceSmallGroup(currentPeriod)
                End If

                'check if this group done
                If getEnglishPVPlayers(tempGroup) = 1 Then Exit Sub

                .dgMain(2, index - 1).Value = "Waiting"

                If englishSidePV(currentPeriod) = "large" Then

                    'ignore incoming bid if one is already there (likely last bidder that was also similtanous bidder)
                    If playerlist(index).secondPriceBidsLarge(subSecondPricePeriod) IsNot Nothing Then Exit Sub

                    'store bid
                    playerlist(index).secondPriceBidsLarge(subSecondPricePeriod) = New secondPriceBid(tempBid, -1, index, subSecondPricePeriod, playerlist(index).secondPriceValues(subSecondPricePeriod))

                    'check that all groups are done
                    Dim done As Boolean = True

                    For i As Integer = 1 To secondPriceNumberOfGroupsLarge(subSecondPricePeriod)
                        If getEnglishPVPlayers(i) > 1 Then done = False
                    Next

                    If done Then
                        'all bids in
                        'store final price
                        englishPriceLargePV(tempGroup, subSecondPricePeriod) = tempBid

                        englishLargeDonePV(subSecondPricePeriod) = True

                        If englishSmallDonePV(subSecondPricePeriod) Then
                            'period done
                            calcEnglishResultPV()
                        Else
                            'do other side
                            For i As Integer = 1 To numberOfPlayers
                                playerlist(i).sendEnglishResultsPV()

                                If playerlist(i).myGroup(subSecondPricePeriod) <> -1 Then .dgMain(2, i - 1).Value = "Reviewing Results"
                            Next
                        End If
                    Else

                        'check if this group done
                        If getEnglishPVPlayers(tempGroup) = 1 Then
                            'store final price
                            englishPriceLargePV(tempGroup, subSecondPricePeriod) = tempBid

                            'send stop
                            For i As Integer = 1 To numberOfPlayers
                                If playerlist(i).myGroup(subSecondPricePeriod) = tempGroup Then
                                    playerlist(i).sendStopEnglishPV()
                                End If
                            Next
                        End If
                    End If
                Else

                    'ignore incoming bid if one is already there (likely last bidder that was also similtanous bidder)
                    If playerlist(index).secondPriceBidsSmall(subSecondPricePeriod) IsNot Nothing Then Exit Sub

                    'store bid
                    playerlist(index).secondPriceBidsSmall(subSecondPricePeriod) = New secondPriceBid(tempBid, -1, index, subSecondPricePeriod, playerlist(index).secondPriceValues(subSecondPricePeriod))

                    'check that all groups are done
                    Dim done As Boolean = True

                    For i As Integer = 1 To secondPriceNumberOfGroupsSmall(subSecondPricePeriod)
                        If getEnglishPVPlayers(i) > 1 Then done = False
                    Next

                    If done Then
                        'all bids in
                        'store final price
                        englishPriceSmallPV(tempGroup, subSecondPricePeriod) = tempBid

                        englishSmallDonePV(subSecondPricePeriod) = True

                        If englishLargeDonePV(subSecondPricePeriod) Then
                            'period done
                            calcEnglishResultPV()
                        Else
                            'do other side
                            For i As Integer = 1 To numberOfPlayers
                                playerlist(i).sendEnglishResultsPV()

                                If playerlist(i).myGroup(subSecondPricePeriod) <> -1 Then .dgMain(2, i - 1).Value = "Reviewing Results"
                            Next
                        End If
                    Else

                        'check if this group done
                        If getEnglishPVPlayers(tempGroup) = 1 Then
                            'store final price
                            englishPriceSmallPV(tempGroup, subSecondPricePeriod) = tempBid

                            'send stop
                            For i As Integer = 1 To numberOfPlayers
                                If playerlist(i).secondPriceSmallGroup(subSecondPricePeriod) = tempGroup Then
                                    playerlist(i).sendStopEnglishPV()
                                End If
                            Next
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Sub calcEnglishResultPV()
        Try
            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).myGroup(subSecondPricePeriod) <> -1 Then
                    If playerlist(i).secondPriceBidsSmall(subSecondPricePeriod) Is Nothing Then
                        playerlist(i).secondPriceBidsSmall(subSecondPricePeriod) = New secondPriceBid(secondPriceMaxBid, -1, i, subSecondPricePeriod, playerlist(i).secondPriceValues(subSecondPricePeriod))
                    End If

                    If playerlist(i).secondPriceBidsLarge(subSecondPricePeriod) Is Nothing Then
                        playerlist(i).secondPriceBidsLarge(subSecondPricePeriod) = New secondPriceBid(secondPriceMaxBid, -1, i, subSecondPricePeriod, playerlist(i).secondPriceValues(subSecondPricePeriod))
                    End If
                End If
            Next

            calcSecondPriceEnglishPVWinner()
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub

    Public Function getEnglishPVPlayers(group As Integer) As Integer
        Try
            Dim tempC As Integer = 0

            If englishSidePV(currentPeriod) = "large" Then

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).myGroup(currentPeriod) = group Then

                        If playerlist(i).secondPriceBidsLarge(subSecondPricePeriod) Is Nothing Then tempC += 1
                    End If
                Next
            Else

                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).secondPriceSmallGroup(currentPeriod) = group Then

                        If playerlist(i).secondPriceBidsSmall(subSecondPricePeriod) Is Nothing Then tempC += 1
                    End If
                Next
            End If

            Return tempC
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
            Return 0
        End Try
    End Function

    Public Sub takeChatBotMessage(index As Integer, str As String)
        Try
            With frmServer
                playerlist(index).takeChatBotMessage(str)
            End With
        Catch ex As Exception
            appEventLog_Write("Error :", ex)
        End Try
    End Sub
End Module
