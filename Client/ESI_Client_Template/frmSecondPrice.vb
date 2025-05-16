Public Class frmSecondPrice

    'english auction

    Public currentSide As String  'small or large
    Public smallDone As Boolean   'small market has completed
    Public largeDone As Boolean   'large market has completed

    Public smallBid As Double     'current small market bid  
    Public largeBid As Double     'current large market bid

    Private Sub txtBid_TextChanged(sender As Object, e As EventArgs) Handles txtBidLeft.TextChanged
        Try
            Me.AcceptButton = cmdSubmit
            updateLeftProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try
            If cmdSubmit.Text = "Submit Bids" Then
                If Not validateInt(txtBidLeft.Text, 5, True, False) Then Exit Sub
                If Not validateInt(txtBidRight.Text, 5, True, False) Then Exit Sub

                If CDbl(txtBidLeft.Text) > secondPriceMaxBid Then
                    Exit Sub
                End If

                If CDbl(txtBidRight.Text) > secondPriceMaxBid Then
                    Exit Sub
                End If
            End If

            If showInstructions Then

                With My.Forms.frmInstructions
                    If Not .pagesDone(currentInstruction) Then
                        If currentInstruction = .exp1 Or
                           currentInstruction = .exp2 Or
                           currentInstruction = .exp3 Then

                            Dim tempExample As Integer

                            If currentInstruction = .exp1 Then
                                tempExample = 1
                            ElseIf currentInstruction = .exp2 Then
                                tempExample = 2
                            Else
                                tempExample = 3
                            End If

                            .pagesDone(currentInstruction) = True

                            Dim msgtokens() As String = secondPriceExamplesLarge(tempExample).Split(",")

                            Dim tempS As String = ""
                            Dim addMyBid As Boolean = False
                            Dim tempN As Integer = 1

                            For i As Integer = 1 To 9
                                msgtokens(i) = CDbl(msgtokens(i)) / 100

                                If CDbl(msgtokens(i)) > CDbl(txtBidLeft.Text) Or addMyBid Then
                                    tempS &= msgtokens(i) & "," & tempN & ",0,1,"
                                ElseIf Not addMyBid Then
                                    tempS &= txtBidLeft.Text & "," & tempN & "," & inumber & ",1,"
                                    tempN += 1
                                    tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                                    addMyBid = True
                                End If

                                tempN += 1
                            Next

                            If Not addMyBid Then tempS &= txtBidLeft.Text & "," & tempN & "," & inumber & ",1,"

                            takeStartSecondPriceResult2(dgMainLeft,
                                                        dgMyBidsLeft,
                                                        10,
                                                        tempS.Split(","),
                                                        0,
                                                        10,
                                                        tempExample)

                            'small example
                            msgtokens = secondPriceExamplesSmall(tempExample).Split(",")
                            tempS = ""
                            addMyBid = False
                            tempN = 1

                            For i As Integer = 1 To 4
                                msgtokens(i) = CDbl(msgtokens(i)) / 100

                                If CDbl(msgtokens(i)) > CDbl(txtBidRight.Text) Or addMyBid Then
                                    tempS &= msgtokens(i) & "," & tempN & ",0,1,"
                                ElseIf Not addMyBid Then
                                    tempS &= txtBidRight.Text & "," & tempN & "," & inumber & ",1,"
                                    tempN += 1

                                    tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                                    addMyBid = True
                                End If

                                tempN += 1
                            Next

                            If Not addMyBid Then tempS &= txtBidRight.Text & "," & tempN & "," & inumber & ",1,"

                            takeStartSecondPriceResult2(dgMainRight,
                                                       dgMyBidsRight,
                                                       5,
                                                       tempS.Split(","),
                                                       0,
                                                       5,
                                                       tempExample)

                            cmdSubmit.Visible = False

                            My.Forms.frmInstructions.nextInstruction()
                        End If
                    End If
                End With
            Else
                If cmdSubmit.Text = "Submit Bids" Then

                    submitAction()
                Else
                    cmdSubmit.Visible = False
                    lblInfoLeft.Text = "Waiting for others."

                    frmClient.AC.sendMessage("03", "")
                End If
            End If

        Catch ex As Exception
            appEventLog_Write("error : ", ex)
        End Try
    End Sub

    Public Sub submitAction()
        Try
            Dim str As String = ""
            str = txtBidLeft.Text & ";"
            str &= txtBidRight.Text & ";"

            cmdSubmit.Visible = False

            lblInfoLeft.Text = "Waiting for others."
            txtBidLeft.ReadOnly = True
            txtBidRight.ReadOnly = True

            frmClient.AC.sendMessage("04", str)
        Catch ex As Exception
            appEventLog_Write("error : ", ex)
        End Try
    End Sub

    Private Sub dgMain_MouseClick(sender As Object, e As MouseEventArgs) Handles dgMainLeft.MouseClick, dgMainLeft.MouseDoubleClick
        Try
            If dgMainLeft.RowCount > 0 Then dgMainLeft.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles dgMyBidsLeft.MouseClick, dgMyBidsLeft.MouseDoubleClick
        Try
            If dgMyBidsLeft.RowCount > 0 Then dgMyBidsLeft.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSecondPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub dgMyBidsRight_MouseClick(sender As Object, e As MouseEventArgs) Handles dgMyBidsRight.MouseClick, dgMyBidsRight.DoubleClick
        Try
            If dgMyBidsRight.RowCount > 0 Then dgMyBidsRight.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgMainRight_MouseClick(sender As Object, e As MouseEventArgs) Handles dgMainRight.MouseClick, dgMainRight.MouseDoubleClick
        Try
            If dgMainRight.RowCount > 0 Then dgMainRight.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupEnglish()
        Try
            If largeBid = 0 And smallBid = 0 Then
                largeDone = False
                smallDone = False

                txtProfitLeft.Text = ""
                txtProfitRight.Text = ""
            End If

            txtBidLeft.Enabled = False
            txtBidRight.Enabled = False

            txtBidLeft.Text = Format(largeBid, "0.00")
            txtBidRight.Text = Format(smallBid, "0.00")

            updateLeftProfit()
            updateRightProfit()

            setupEnglish2()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupEnglish2()
        Try
            If myGroup = -1 And Not showInstructions Then
                lblInfoLeft.Location = New Point(709, 276)
                Exit Sub
            End If

            If currentSide = "large" Then
                cmdSubmitLargeEnglish.Visible = True
                cmdSubmitSmallEnglish.Visible = False

                lblInfoLeft.Location = New Point(cmdSubmitLargeEnglish.Location.X, lblInfoLeft.Location.Y)

                lblInfoLeft.Text = "Once the Price is too high press Do Not Buy."
            Else
                cmdSubmitLargeEnglish.Visible = False
                cmdSubmitSmallEnglish.Visible = True

                lblInfoLeft.Location = New Point(cmdSubmitSmallEnglish.Location.X, lblInfoLeft.Location.Y)

                lblInfoLeft.Text = "Once the Price is too high press Do Not Buy."
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub doTimer2Tick()
        Try
            'english price timer

            If currentSide = "large" Then
                refreshLargeBid()
            Else
                refreshSmallBid()
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshLargeBid()
        Try
            largeBid = Math.Round(largeBid, 2)

            txtBidLeft.Text = Format(largeBid, "0.00")

            If largeBid >= secondPriceMaxBid Then
                largeBid = secondPriceMaxBid
                'Timer2.Enabled = False
                submitLargeEnglishAction()
            End If

            updateLeftProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub refreshSmallBid()
        Try
            smallBid = Math.Round(smallBid, 2)

            txtBidRight.Text = Format(smallBid, "0.00")

            If smallBid >= secondPriceMaxBid Then
                smallBid = secondPriceMaxBid
                submitSmallEnglishAction()
            End If

            updateRightProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmitLargeEnglish_Click(sender As Object, e As EventArgs) Handles cmdSubmitLargeEnglish.Click
        Try
            submitLargeEnglishAction()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub submitLargeEnglishAction()
        Try
            If not cmdSubmitLargeEnglish.Visible Then Exit Sub


            If showInstructions Then
                With frmInstructions
                    If currentInstruction = .exp1 Or
                       currentInstruction = .exp2 Or
                       currentInstruction = .exp3 Then

                        frmInstructions.englishPVBidLarge = CDbl(txtBidLeft.Text)
                        cmdSubmitLargeEnglish.Visible = False
                        lblInfoLeft.Text = "Waiting for others."

                    End If
                End With
            Else
                largeDone = True
                cmdSubmitLargeEnglish.Visible = False

                lblInfoLeft.Text = "Waiting for others."

                Dim str As String = ""

                str = txtBidLeft.Text & ";"

                frmClient.AC.sendMessage("06", str)
            End If


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmitSmallEnglish_Click(sender As Object, e As EventArgs) Handles cmdSubmitSmallEnglish.Click
        Try
            submitSmallEnglishAction()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub submitSmallEnglishAction()
        Try
            If Not cmdSubmitSmallEnglish.Visible Then Exit Sub

            ' Timer1.Enabled = False
            '  Timer2.Enabled = False

            If showInstructions Then
                With frmInstructions
                    If currentInstruction = .exp1 Or
                       currentInstruction = .exp2 Or
                       currentInstruction = .exp3 Then


                        frmInstructions.englishPVBidSmall = CDbl(txtBidRight.Text)
                        cmdSubmitSmallEnglish.Visible = False
                        lblInfoLeft.Text = "Waiting for others."

                    End If
                End With
            Else
                smallDone = True
                cmdSubmitSmallEnglish.Visible = False

                lblInfoLeft.Text = "Waiting for others."

                Dim str As String = ""

                str = txtBidRight.Text & ";"

                frmClient.AC.sendMessage("06", str)

            End If


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub periodResultsInstructions()
        Try
            With frmInstructions

                .Timer2.Enabled = False

                Dim tempExample As Integer

                If currentInstruction = .exp1 Then
                    tempExample = 1
                ElseIf currentInstruction = .exp2 Then
                    tempExample = 2
                Else
                    tempExample = 3
                End If

                .pagesDone(currentInstruction) = True

                Dim msgtokens() As String = secondPriceExamplesLarge(tempExample).Split(",")

                Dim tempS As String = ""
                Dim addMyBid As Boolean = False
                Dim tempN As Integer = 1

                Dim tempPrice As Double = -1

                For i As Integer = 1 To 9
                    msgtokens(i) = CDbl(msgtokens(i)) / 100

                    If CDbl(msgtokens(i)) > frmInstructions.englishPVBidLarge Or addMyBid Then
                        tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                        If i = 2 And tempPrice = -1 Then
                            tempPrice = msgtokens(i)
                        End If
                    ElseIf Not addMyBid Then
                        tempS &= frmInstructions.englishPVBidLarge & "," & tempN & "," & inumber & ",1,"
                        tempN += 1
                        tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                        addMyBid = True

                        If i = 2 And tempPrice = -1 Then
                            tempPrice = frmInstructions.englishPVBidLarge
                        ElseIf i = 1 Then
                            tempPrice = msgtokens(i)
                        End If
                    End If

                    tempN += 1
                Next

                txtBidLeft.Text = Format(tempPrice, "0.00")

                If Not addMyBid Then tempS &= frmInstructions.englishPVBidLarge & "," & tempN & "," & inumber & ",1,"


                takeStartSecondPriceResult2(dgMainLeft,
                                        dgMyBidsLeft,
                                        10,
                                        tempS.Split(","),
                                        0,
                                        10,
                                        tempExample)

                'small example
                msgtokens = secondPriceExamplesSmall(tempExample).Split(",")
                tempS = ""
                addMyBid = False
                tempN = 1
                tempPrice = -1

                For i As Integer = 1 To 4
                    msgtokens(i) = CDbl(msgtokens(i)) / 100

                    If CDbl(msgtokens(i)) > frmInstructions.englishPVBidSmall Or addMyBid Then
                        tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                        If i = 2 And tempPrice = -1 Then
                            tempPrice = msgtokens(i)
                        End If
                    ElseIf Not addMyBid Then
                        tempS &= frmInstructions.englishPVBidSmall & "," & tempN & "," & inumber & ",1,"
                        tempN += 1

                        tempS &= msgtokens(i) & "," & tempN & ",0,1,"

                        addMyBid = True

                        If i = 2 And tempPrice = -1 Then
                            tempPrice = frmInstructions.englishPVBidSmall
                        ElseIf i = 1 Then
                            tempPrice = msgtokens(i)
                        End If
                    End If

                    tempN += 1
                Next


                txtBidRight.Text = Format(tempPrice, "0.00")

                If Not addMyBid Then tempS &= frmInstructions.englishPVBidSmall & "," & tempN & "," & inumber & ",1,"

                takeStartSecondPriceResult2(dgMainRight,
                                       dgMyBidsRight,
                                       5,
                                       tempS.Split(","),
                                       0,
                                       5,
                                       tempExample)

                cmdSubmit.Visible = False

                lblInfoLeft.Visible = False
                .cmdBack.Visible = True
                .nextInstruction()
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtProfitLeft_TextChanged(sender As Object, e As EventArgs) Handles txtProfitLeft.TextChanged
        Try
            ' updateLeftProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub updateLeftProfit()
        Try
            If Not IsNumeric(txtBidLeft.Text) Or Not IsNumeric(txtValueLeft.Text) Then Exit Sub

            If currentPhase = "English Auction" Then
                If Not cmdSubmitLargeEnglish.Visible Then Exit Sub
            End If

            txtProfitLeft.Text = Format(CDbl(txtValueLeft.Text) - CDbl(txtBidLeft.Text), "0.00")

            If CDbl(txtProfitLeft.Text) < 0 Then
                txtProfitLeft.ForeColor = Color.Red
            Else
                txtProfitLeft.ForeColor = Color.Black
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtProfitRight_TextChanged(sender As Object, e As EventArgs) Handles txtProfitRight.TextChanged
        Try
            'updateRightProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub updateRightProfit()
        Try
            If Not IsNumeric(txtBidRight.Text) Or Not IsNumeric(txtValueRight.Text) Then Exit Sub

            If currentPhase = "English Auction" Then
                If Not cmdSubmitSmallEnglish.Visible Then Exit Sub
            End If

            txtProfitRight.Text = Format(CDbl(txtValueRight.Text) - CDbl(txtBidRight.Text), "0.00")

            If CDbl(txtProfitRight.Text) < 0 Then
                txtProfitRight.ForeColor = Color.Red
            Else
                txtProfitRight.ForeColor = Color.Black
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtBidRight_TextChanged(sender As Object, e As EventArgs) Handles txtBidRight.TextChanged
        Try
            Me.AcceptButton = cmdSubmit
            updateRightProfit()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSecondPrice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not clientClosing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
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
End Class