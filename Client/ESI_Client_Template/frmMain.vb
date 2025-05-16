Public Class frmMain
    Public WithEvents AC As synchronousClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim commandLine As String = Command()

            If commandLine <> "" Then
                writeINI(sfile, "Settings", "ip", commandLine)
            End If

            'connect
            myIPAddress = getINI(sfile, "Settings", "ip")
            myPortNumber = getINI(sfile, "Settings", "port")

            'azure open ai
            Dim azure_settings_file_name As String = Application.StartupPath & "\azure.ini"
            azure_openai_key = getINI(azure_settings_file_name, "Settings", "azure_openai_key")
            azure_openai_endpoint = getINI(azure_settings_file_name, "Settings", "azure_openai_endpoint")
            azure_openai_model = getINI(azure_settings_file_name, "Settings", "azure_openai_model")

            AC = New synchronousClient

            AC.connect()

            AC.sendMessage("COMPUTER_NAME", My.Computer.Name)

            'frmChatGPT.Show()

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_connected() Handles AC.connected
        Try
            bwSocket.RunWorkerAsync()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_ConnectionError() Handles AC.connectionError
        Try

            If bwSocket.IsBusy Then
                bwSocket.CancelAsync()
            Else
                showConnectionBox()
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub showConnectionBox()
        Try
            If AC.client.Connected Then
                AC.close()
            End If

            AC = New synchronousClient

            frmConnect.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub AC_messageReceived(ByVal e As String) Handles AC.messageReceived
        Try
            setTakeMessage(e)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    'receive socket messages
    Private Sub bwSocket_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSocket.DoWork
        Try
            Dim go As Boolean = True

            Do While go
                If bwSocket.CancellationPending Then go = False
                If go Then AC.Receive()
            Loop

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub bwSocket_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSocket.RunWorkerCompleted
        If Not clientClosing Then
            showConnectionBox()
        Else
            Close()
        End If
    End Sub

    Delegate Sub setTakeMessageCallback(text As String)

    Public Sub setTakeMessage(ByVal text As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtMain.InvokeRequired Then
            Dim d As New setTakeMessageCallback(AddressOf setTakeMessage)
            Me.Invoke(d, New Object() {text})
        Else
            takeMessage(text)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            If showInstructions Then
                With My.Forms.frmInstructions

                    If .cmdStart.Visible Then .cmdStart.PerformClick()

                    If .startPressed Then Exit Sub

                    If frmLottery.Visible Then
                        Select Case currentInstruction
                            Case 1 To 5, 10 To 12

                            Case 6
                                .txtQuiz.Text = lotteryRedTicketValues(1)
                            Case 7
                                .txtQuiz.Text = lotteryBlueTicketValues(1)
                            Case 8
                                .txtQuiz.Text = lotteryRedTicketValues(2)
                            Case 9
                                .txtQuiz.Text = lotteryBlueTicketValues(2)
                        End Select
                    ElseIf My.Forms.frmEnglish.Visible Then

                        If englishBidMode = "full" Then
                            Select Case currentInstruction
                                Case 1 To 9

                                Case 10
                                    .txtQuiz.Text = "5"
                                Case 11
                                    .txtQuiz.Text = "y"
                                Case 12
                                    .txtQuiz.Text = "n"
                                Case 13
                                    .txtQuiz.Text = englishMaxValue
                                Case 14
                                    .txtQuiz.Text = englishMinValue
                                Case 17

                                    My.Forms.frmEnglish.txtNewBid.Text = "66"
                                    My.Forms.frmEnglish.cmdUpdateBid.PerformClick()

                                Case 18 To 19

                            End Select
                        Else
                            Select Case currentInstruction
                                Case 1 To 10, 17

                                Case 11
                                    If englishBidMode = "full" Then
                                        .txtQuiz.Text = "5"
                                    Else
                                        .txtQuiz.Text = "15"
                                    End If
                                Case 12
                                    .txtQuiz.Text = "0"
                                Case 13
                                    .txtQuiz.Text = "y"
                                Case 14
                                    .txtQuiz.Text = "n"
                                Case 15
                                    .txtQuiz.Text = englishMaxValue
                                Case 16
                                    .txtQuiz.Text = englishMinValue
                                Case 19


                                Case 20
                                    If englishBidMode = "drop" And englishPrice = 66 Then
                                        If My.Forms.frmEnglish.cmdDontBuy.Visible Then
                                            My.Forms.frmEnglish.cmdDontBuy.PerformClick()
                                        ElseIf My.Forms.frmEnglish.cmdReadyToGoOn.Visible Then
                                            My.Forms.frmEnglish.cmdReadyToGoOn.PerformClick()
                                        End If
                                    End If


                            End Select
                        End If



                    ElseIf My.Forms.frmSecondPrice.Visible Then
                        Select Case currentInstruction
                            Case .exp1
                                If currentPhase = "English Auction" Then
                                    If rand(5, 1) = 1 Then
                                        If frmSecondPrice.cmdSubmitSmallEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitSmallEnglish.PerformClick()
                                        ElseIf My.Forms.frmSecondPrice.cmdSubmitLargeEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitLargeEnglish.PerformClick()
                                        End If
                                    End If
                                Else
                                    My.Forms.frmSecondPrice.txtBidLeft.Text = "21"
                                    My.Forms.frmSecondPrice.txtBidRight.Text = "22"
                                    My.Forms.frmSecondPrice.cmdSubmit.PerformClick()
                                End If

                            Case .exp2
                                If currentPhase = "English Auction" Then
                                    If rand(5, 1) = 1 Then
                                        If frmSecondPrice.cmdSubmitSmallEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitSmallEnglish.PerformClick()
                                        ElseIf My.Forms.frmSecondPrice.cmdSubmitLargeEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitLargeEnglish.PerformClick()
                                        End If
                                    End If
                                Else
                                    My.Forms.frmSecondPrice.txtBidLeft.Text = "23"
                                    My.Forms.frmSecondPrice.txtBidRight.Text = "24"
                                    My.Forms.frmSecondPrice.cmdSubmit.PerformClick()
                                End If

                            Case .exp3
                                If currentPhase = "English Auction" Then
                                    If rand(5, 1) = 1 Then
                                        If frmSecondPrice.cmdSubmitSmallEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitSmallEnglish.PerformClick()
                                        ElseIf My.Forms.frmSecondPrice.cmdSubmitLargeEnglish.Visible Then
                                            frmSecondPrice.cmdSubmitLargeEnglish.PerformClick()
                                        End If
                                    End If
                                Else
                                    My.Forms.frmSecondPrice.txtBidLeft.Text = "25"
                                    My.Forms.frmSecondPrice.txtBidRight.Text = "26"
                                    My.Forms.frmSecondPrice.cmdSubmit.PerformClick()
                                End If

                            Case .eqp1
                                .txtQuiz.Text = "4"
                            Case .eqp2
                                .txtQuiz.Text = "0"
                            Case .eqp3
                                .txtQuiz.Text = "y"
                            Case .eqp4
                                .txtQuiz.Text = "n"
                            Case .eqp5
                                .txtQuiz.Text = secondPriceEndValue
                            Case Else
                                'no action
                        End Select



                    End If

                    If My.Forms.frmEnglish.cmdReadyToGoOn.Visible Then
                        My.Forms.frmEnglish.cmdReadyToGoOn.PerformClick()
                    ElseIf .gbQuiz.Visible Then
                        .cmdSubmitQuiz.PerformClick()
                    ElseIf .cmdNext.Visible Then
                        .cmdNext.PerformClick()
                    End If

                End With

            ElseIf My.Forms.frmNames.Visible Then
                With frmNames
                    .txtName.Text = "Instruction Robot " & inumber
                    .txtIDNumber.Text = rand(100000, 1)
                    .cmdSubmit.PerformClick()

                    Timer1.Enabled = False
                End With
            ElseIf My.Forms.frmLottery.Visible Then
                With frmLottery
                    If .cmdSubmit.Visible Then

                        If .rbBlue.Enabled Then
                            If rand(2, 1) = 1 Then
                                .rbBlue.Checked = True
                            Else
                                .rbRed.Checked = True
                            End If
                        End If

                        .cmdSubmit.PerformClick()
                    End If
                End With
            ElseIf My.Forms.frmSecondPrice.Visible Then
                With frmSecondPrice
                    If currentPhase = "2nd Price" Then
                        If .cmdSubmit.Visible Then

                            If .cmdSubmit.Text = "Submit Bids" Then
                                .txtBidLeft.Text = CDbl(.txtValueLeft.Text) + rand(Math.Ceiling(CDbl(.txtValueLeft.Text) * 0.2), Math.Floor(-CDbl(.txtValueLeft.Text) * 0.1))
                                .txtBidRight.Text = CDbl(.txtValueRight.Text) + rand(Math.Ceiling(CDbl(.txtValueRight.Text) * 0.2), Math.Floor(-CDbl(.txtValueRight.Text) * 0.1))
                            End If

                            .cmdSubmit.PerformClick()
                        End If
                    Else
                        If .cmdSubmit.Visible Then
                            'ready to go on
                            .cmdSubmit.PerformClick()
                        Else
                            'submit bid

                            If .cmdSubmitLargeEnglish.Visible Then

                                If Not IsNumeric(.txtProfitLeft.Text) Then Exit Sub

                                If CDbl(.txtProfitLeft.Text) <= 3 Then

                                    If rand(5, 1) = 1 Then
                                        .cmdSubmitLargeEnglish.PerformClick()
                                    End If
                                ElseIf CDbl(.txtProfitLeft.Text) <= -3 Then
                                    .cmdSubmitLargeEnglish.PerformClick()
                                End If

                            ElseIf .cmdSubmitSmallEnglish.Visible Then
                                If Not IsNumeric(.txtProfitRight.Text) Then Exit Sub

                                If CDbl(.txtProfitRight.Text) <= 3 Then
                                    If rand(5, 1) = 1 Then
                                        .cmdSubmitSmallEnglish.PerformClick()
                                    End If
                                ElseIf CDbl(.txtProfitRight.Text) <= -3 Then
                                    .cmdSubmitSmallEnglish.PerformClick()
                                End If

                            End If
                        End If

                    End If


                End With

            ElseIf My.Forms.frmEnglish.Visible Then
                With frmEnglish
                    If .cmdReadyToGoOn.Visible Then
                        .cmdReadyToGoOn.PerformClick()
                    ElseIf .pnl1.Visible Then
                        If englishPhase = "start" Then
                            Dim go As Boolean = True


                            .txtNewBid.Text = rand(englishSignal + englishRange, englishSignal - englishRange)
                            .cmdUpdateBid.PerformClick()

                            'Do While go
                            '    Select Case rand(4, 1)
                            '        Case 1
                            '            .cmdPlus1Cent.PerformClick()
                            '        Case 2
                            '            .cmdPlus10Cents.PerformClick()
                            '        Case 3
                            '            .cmdPlus1Dollar.PerformClick()
                            '        Case 4
                            '            .cmdPlus10Dollars.PerformClick()
                            '    End Select

                            '    If englishBid > englishSignal - englishRange Then
                            '        go = False
                            '    End If
                            'Loop

                            .cmdUpdateBid.PerformClick()
                        Else
                            If rand(5, 1) Then
                                'Select Case rand(8, 1)
                                '    Case 1
                                '        .cmdPlus1Cent.PerformClick()
                                '    Case 2
                                '        .cmdPlus10Cents.PerformClick()
                                '    Case 3
                                '        .cmdPlus1Dollar.PerformClick()
                                '    Case 4
                                '        .cmdPlus10Dollars.PerformClick()
                                '    Case 5
                                '        .cmdMinus1Cent.PerformClick()
                                '    Case 6
                                '        .cmdMinus10Cents.PerformClick()
                                '    Case 7
                                '        .cmdMinus1Dollar.PerformClick()
                                '    Case 8
                                '        .cmdMinus10Dollars.PerformClick()
                                'End Select

                                .cmdUpdateBid.PerformClick()
                            End If
                        End If
                    ElseIf .cmdDontBuy.Visible Then
                        If rand(10, 1) = 1 Then
                            If englishPrice >= englishSignal - englishRange Then
                                .cmdDontBuy.PerformClick()
                            End If
                        End If
                    End If

                End With

            End If

            Timer1.Interval = rand(1500, 500)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not clientClosing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class
