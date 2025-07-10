Public Class frmSetup1
    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            writeINI(sfile, "gameSettings", "numberOfPlayers", txtNumberOfPlayers.Text)
            writeINI(sfile, "gameSettings", "numberOfPeriods", txtNumberOfPeriods.Text)
            writeINI(sfile, "gameSettings", "port", txtPortNumber.Text)
            writeINI(sfile, "gameSettings", "instructionX", txtInstructionX.Text)
            writeINI(sfile, "gameSettings", "instructionY", txtInstructionY.Text)
            writeINI(sfile, "gameSettings", "windowX", txtWindowX.Text)
            writeINI(sfile, "gameSettings", "windowY", txtWindowY.Text)

            writeINI(sfile, "gameSettings", "secondPriceStartingCash", txtSecondPriceStartingCash.Text)
            writeINI(sfile, "gameSettings", "secondPriceMaxBid", txtSecondPriceMaxBid.Text)
            writeINI(sfile, "gameSettings", "englishTickRatePV", txtEnglishTickRatePV.Text)
            writeINI(sfile, "gameSettings", "englishTickAmountPV", txtEnglishTickAmountPV.Text)

            writeINI(sfile, "gameSettings", "lotteryTicketCount", txtLotteryTicketCount.Text)
            writeINI(sfile, "gameSettings", "lotteryPeriodLength", txtLotteryPeriodLength.Text)

            writeINI(sfile, "gameSettings", "englishStartingCash", txtEnglishStartingCash.Text)
            writeINI(sfile, "gameSettings", "englishTickRate", txtEnglishTickRate.Text)
            writeINI(sfile, "gameSettings", "englishStartPrice", txtEnglishStartPrice.Text)
            writeINI(sfile, "gameSettings", "englishEndPrice", txtEnglishEndPrice.Text)
            writeINI(sfile, "gameSettings", "englishStartScale", txtEnglishStartScale.Text)
            writeINI(sfile, "gameSettings", "englishEndScale", txtEnglishEndScale.Text)
            writeINI(sfile, "gameSettings", "englishStartDelay", txtEnglishStartDelay.Text)
            writeINI(sfile, "gameSettings", "readyToGoOnTime", txtReadyToGoOnTime.Text)
            writeINI(sfile, "gameSettings", "surveyLink", txtSurveyLink.Text)
            writeINI(sfile, "gameSettings", "chatBotTime", txtChatBotTime.Text)

            writeINI(sfile, "gameSettings", "showInstructions", cbShowInstructions.Checked)
            writeINI(sfile, "gameSettings", "testMode", cbTestMode.Checked)
            writeINI(sfile, "gameSettings", "englishPVSecondPriceShowProfit", cbShowEnglishPVSecondPriceProfit.Checked)
            writeINI(sfile, "gameSettings", "enableChatBot", cbEnableChatBot.Checked)

            writeINI(sfile, "gameSettings", "quizQuestionValue", txtQuizQuestionValue.Text)
            writeINI(sfile, "gameSettings", "practicePeriods", txtPracticePeriods.Text)

            If rbFull.Checked Then
                writeINI(sfile, "gameSettings", "englishBidMode", "full")
            Else
                writeINI(sfile, "gameSettings", "englishBidMode", "drop")
            End If

            If rbFirst.Checked Then
                writeINI(sfile, "gameSettings", "englishPriceMode", "first")
            Else
                writeINI(sfile, "gameSettings", "englishPriceMode", "second")
            End If

            loadParameters()

            Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSetup1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtNumberOfPlayers.Text = getINI(sfile, "gameSettings", "numberOfPlayers")
            txtNumberOfPeriods.Text = getINI(sfile, "gameSettings", "numberOfPeriods")
            txtPortNumber.Text = getINI(sfile, "gameSettings", "port")
            txtInstructionX.Text = getINI(sfile, "gameSettings", "instructionX")
            txtInstructionY.Text = getINI(sfile, "gameSettings", "instructionY")
            txtWindowX.Text = getINI(sfile, "gameSettings", "windowX")
            txtWindowY.Text = getINI(sfile, "gameSettings", "windowY")

            txtSecondPriceStartingCash.Text = getINI(sfile, "gameSettings", "secondPriceStartingCash")
            txtSecondPriceMaxBid.Text = getINI(sfile, "gameSettings", "secondPriceMaxBid")
            txtEnglishTickRatePV.Text = getINI(sfile, "gameSettings", "englishTickRatePV")
            txtEnglishTickAmountPV.Text = getINI(sfile, "gameSettings", "englishTickAmountPV")

            txtLotteryTicketCount.Text = getINI(sfile, "gameSettings", "lotteryTicketCount")
            txtLotteryPeriodLength.Text = getINI(sfile, "gameSettings", "lotteryPeriodLength")

            txtEnglishStartingCash.Text = getINI(sfile, "gameSettings", "englishStartingCash")
            txtEnglishTickRate.Text = getINI(sfile, "gameSettings", "englishTickRate")
            txtEnglishStartPrice.Text = getINI(sfile, "gameSettings", "englishStartPrice")
            txtEnglishEndPrice.Text = getINI(sfile, "gameSettings", "englishEndPrice")
            txtEnglishStartScale.Text = getINI(sfile, "gameSettings", "englishStartScale")
            txtEnglishEndScale.Text = getINI(sfile, "gameSettings", "englishEndScale")
            txtEnglishStartDelay.Text = getINI(sfile, "gameSettings", "englishStartDelay")

            txtReadyToGoOnTime.Text = getINI(sfile, "gameSettings", "readyToGoOnTime")
            txtSurveyLink.Text = getINI(sfile, "gameSettings", "surveyLink")
            txtChatBotTime.Text = getINI(sfile, "gameSettings", "chatBotTime")

            If getINI(sfile, "gameSettings", "englishBidMode") = "full" Then
                rbFull.Checked = True
            Else
                rbDropout.Checked = True
            End If

            If getINI(sfile, "gameSettings", "englishPriceMode") = "first" Then
                rbFirst.Checked = True
            Else
                rbSecond.Checked = True
            End If

            cbShowInstructions.Checked = getINI(sfile, "gameSettings", "showInstructions")
            cbTestMode.Checked = getINI(sfile, "gameSettings", "testMode")
            cbShowEnglishPVSecondPriceProfit.Checked = getINI(sfile, "gameSettings", "englishPVSecondPriceShowProfit")
            cbEnableChatBot.Checked = getINI(sfile, "gameSettings", "enableChatBot")

            txtQuizQuestionValue.Text = getINI(sfile, "gameSettings", "quizQuestionValue")
            txtPracticePeriods.Text = getINI(sfile, "gameSettings", "practicePeriods")
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class