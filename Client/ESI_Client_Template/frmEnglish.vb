Imports System.Drawing.Drawing2D

Public Class frmEnglish

    'drawing 
    Dim mainScreen As Screen
    Dim f16 As New Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold)
    Dim f12 As New Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
    Dim f8 As New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)
    Dim f6 As New Font("Microsoft Sans Serif", 6, System.Drawing.FontStyle.Bold)

    Dim pB3 As New Pen(Brushes.Black, 3)
    Dim pG5 As New Pen(Brushes.Green, 5)
    Dim pG4 As New Pen(Brushes.Green, 4)
    Dim pG3 As New Pen(Brushes.Green, 3)
    Dim pG2 As New Pen(Brushes.Green, 2)
    Dim pBl5 As New Pen(Brushes.Blue, 5)
    Dim pCf5 As New Pen(Brushes.CornflowerBlue, 5)
    Dim pGld3Dash As New Pen(Color.Gold, 3)

    Dim fmt As New StringFormat 'center alignment
    Dim fmt2 As New StringFormat 'right alignment

    Private Sub frmEnglish_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmEnglish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mainScreen = New Screen(pnlRange, New Rectangle(0, 0, pnlRange.Width, pnlRange.Height))

            fmt.Alignment = StringAlignment.Center
            fmt2.Alignment = StringAlignment.Far

            capPen(pB3)
            capPen(pG3)
            capPen(pG4)
            capPen(pG5)
            capPen(pBl5)
            capPen(pCf5)
            capPen(pGld3Dash)

            pGld3Dash.DashStyle = DashStyle.Dot

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub capPen(ByRef p As Pen)
        Try
            p.EndCap = LineCap.Triangle
            p.StartCap = LineCap.Triangle
            p.Alignment = PenAlignment.Center
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdMinus10Dollars_Click(sender As Object, e As EventArgs)


        Try


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdUpdateBid_Click(sender As Object, e As EventArgs) Handles cmdUpdateBid.Click
        Try
            If txtNewBid.Text = "" Then Exit Sub

            If englishPhase = "start" Then
                If Not frmClient.Timer1.Enabled Then
                    If MessageBox.Show("Are you sure you wish to Bid " & txtNewBid.Text & "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            If showInstructions And subPeriod = 1 Then
                With My.Forms.frmInstructions

                    If currentInstruction = My.Forms.frmInstructions.exp1 Then
                        If englishBid <> 66 Then Exit Sub

                        pnl1.Visible = False

                        txtInfo.Visible = True
                        txtInfo.Text = "Waiting for others."

                        .pagesDone(currentInstruction) = True
                        'ElseIf currentInstruction = My.Forms.frmInstructions.exp2 - 1 Then
                        '    If englishBid <> 110 Then Exit Sub

                        '    pnl1.Visible = False

                        '    txtInfo.Visible = True
                        '    txtInfo.Text = "Waiting for others."

                        '    .pagesDone(currentInstruction) = True
                        'ElseIf currentInstruction = My.Forms.frmInstructions.exp2 Then
                        ' If englishNewBid <> 107 Then Exit Sub

                    End If

                    englishBid = CDbl(txtNewBid.Text)
                End With
            Else

                If englishPhase = "start" Then

                    pnl1.Visible = False

                    txtInfo.Visible = True
                    txtInfo.Text = "Waiting for others."
                End If

                Dim str As String = ""

                str = txtNewBid.Text & ";"

                frmClient.AC.sendMessage("05", str)
            End If


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            If cmdReadyToGoOn.BackColor = Color.FromArgb(192, 255, 192) Then
                cmdReadyToGoOn.BackColor = SystemColors.Control
            Else
                cmdReadyToGoOn.BackColor = Color.FromArgb(192, 255, 192)
            End If

            'draw range
            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawRange(g)

            mainScreen.flip()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dg1_MouseClick(sender As Object, e As MouseEventArgs) Handles dg1.MouseClick, dg1.MouseDoubleClick
        Try
            If dg1.RowCount > 0 Then dg1.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdReadyToGoOn_Click(sender As Object, e As EventArgs) Handles cmdReadyToGoOn.Click
        Try
            If My.Forms.frmInstructions.Visible Then
                If (currentInstruction = 18 And englishBidMode = "full") Or
                  (currentInstruction = 20 And englishBidMode = "drop") Then

                    My.Forms.frmInstructions.pagesDone(currentInstruction) = True
                    cmdReadyToGoOn.Visible = False

                End If
            Else
                cmdReadyToGoOn.Visible = False

                txtInfo.Text = "Waiting for others."

                frmClient.AC.sendMessage("03", "")
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawRange(g As Graphics)
        Try
            'common points
            Dim tempY As Integer = pnlRange.Height / 2 - 20
            Dim xOffset As Integer = 30

            'signals
            Dim tempXC As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishSignal, englishStartScale, englishEndScale)
            Dim tempXL As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishSignal - englishRange, englishStartScale, englishEndScale)
            Dim tempXR As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishSignal + englishRange, englishStartScale, englishEndScale)

            'price
            Dim tempXP As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishPrice, englishStartScale, englishEndScale)

            'bid
            Dim tempXB As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishBid, englishStartScale, englishEndScale)
            '   Dim tempXnB As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishNewBid, englishStartScale, englishEndScale)

            'actual value
            Dim tempXV As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishValue, englishStartScale, englishEndScale)

            'scale
            Dim tempXSL As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishMinValue, englishStartScale, englishEndScale)
            Dim tempXSR As Double = convertX(pnlRange.Width - xOffset * 2, xOffset, 0, englishMaxValue, englishStartScale, englishEndScale)

            'draw scale
            g.DrawLine(pB3, New Point(xOffset, tempY), New Point(pnlRange.Width - xOffset, tempY))
            g.DrawLine(pB3, New Point(tempXSL, tempY - 5), New Point(tempXSL, tempY + 5))
            g.DrawLine(pB3, New Point(tempXSR, tempY - 5), New Point(tempXSR, tempY + 5))

            If englishObserver = -1 Then
                'left hash
                g.DrawLine(pCf5,
                         New Point(tempXL, tempY),
                         New Point(tempXL + 5, tempY - 10))

                g.DrawLine(pCf5,
                         New Point(tempXL, tempY),
                         New Point(tempXL + 5, tempY + 10))

                'right hash
                g.DrawLine(pCf5,
                         New Point(tempXR, tempY),
                         New Point(tempXR - 5, tempY - 10))

                g.DrawLine(pCf5,
                       New Point(tempXR, tempY),
                       New Point(tempXR - 5, tempY + 10))

                'range line
                g.DrawLine(pCf5,
                        New Point(tempXL, tempY),
                        New Point(tempXR, tempY))


                'signal line
                g.DrawLine(pBl5,
                       New Point(tempXC, tempY - 10),
                       New Point(tempXC, tempY + 10))
            End If

            'Price marker
            If (englishPhase = "result" And englishBidMode = "full") Or (englishBidMode = "drop") Then
                Dim pricePath As New GraphicsPath
                Dim pricePathPoints(3) As Point
                pricePathPoints(0) = New Point(tempXP, tempY)
                pricePathPoints(1) = New Point(tempXP - 10, tempY + 40)
                pricePathPoints(2) = New Point(tempXP + 10, tempY + 40)
                pricePathPoints(3) = New Point(tempXP, tempY)

                pricePath.AddLines(pricePathPoints)
                g.FillPath(Brushes.Crimson, pricePath)
                g.DrawPath(Pens.Black, pricePath)

                g.DrawString(Format(englishPrice, "0.00"), f12, Brushes.Crimson, New Point(tempXP, tempY + 42), fmt)
            End If

            'Bid Marker
            Dim bidPath As New GraphicsPath
            Dim bidPathPoints(3) As Point
            bidPathPoints(0) = New Point(tempXB, tempY)
            bidPathPoints(1) = New Point(tempXB - 10, tempY - 40)
            bidPathPoints(2) = New Point(tempXB + 10, tempY - 40)
            bidPathPoints(3) = New Point(tempXB, tempY)

            If englishObserver = -1 And englishBid < 10000 Then
                bidPath.AddLines(bidPathPoints)
                g.FillPath(Brushes.Teal, bidPath)
                g.DrawPath(Pens.Black, bidPath)
            End If

            'new bid marker
            'Dim newBidPath As New GraphicsPath
            'Dim newBidPathPoints(3) As Point
            'newBidPathPoints(0) = New Point(tempXnB, tempY)
            'newBidPathPoints(1) = New Point(tempXnB - 5, tempY - 30)
            'newBidPathPoints(2) = New Point(tempXnB + 5, tempY - 30)
            'newBidPathPoints(3) = New Point(tempXnB, tempY)

            'If englishObserver = -1 And englishBidMode = "full" Then
            '    newBidPath.AddLines(newBidPathPoints)
            '    g.FillPath(New SolidBrush(Color.FromArgb(128, 0, 128, 128)), newBidPath)
            '    g.DrawPath(Pens.Black, newBidPath)

            '    ' g.DrawString(Format(englishBid, "0.00"), f12, Brushes.Teal, New Point(tempXB, tempY - 60), fmt)
            'End If

            'actual value
            If englishPhase = "result" Then
                g.DrawLine(pGld3Dash, New Point(tempXV, tempY + 40), New Point(tempXV, tempY - 60))
                g.DrawString(Format(englishValue, "0.00"), f12, Brushes.Gold, New Point(tempXV, tempY - 77), fmt)
            End If

            'bid text
            If englishObserver = -1 And englishBidMode = "full" And englishBid < 10000 Then
                g.DrawString(Format(englishBid, "0.00"), f12, Brushes.Teal, New Point(tempXB, tempY - 60), fmt)
            End If

            'draw scale text
            g.DrawString(Format(englishMinValue, "0.00"), f12, Brushes.SaddleBrown, New Point(tempXSL, tempY + 10), fmt)
            g.DrawString(Format(englishMaxValue, "0.00"), f12, Brushes.SaddleBrown, New Point(tempXSR, tempY + 10), fmt)

            'signal Line text
            If englishObserver = -1 Then
                g.DrawString(Format(englishSignal - englishRange, "0.00") & " to " & Format(englishSignal + englishRange, "0.00"),
                         f12,
                         Brushes.CornflowerBlue,
                         New Point(tempXC, tempY - 32), fmt)
            End If

            'remaining bidders
            If currentPhase = "CV Full Info" Then
                Dim tempText As String = ""

                If englishBidMode = "drop" Then
                    tempText = "Remaining Buyers: "
                Else
                    tempText = "Remaining Bidders: "
                End If

                If englishBidderFlash Mod 2 = 1 Then
                    g.DrawString(tempText & englishBidderCount, f16, Brushes.Yellow, New Point(pnlRange.Width / 2, pnlRange.Height - 30), fmt)
                Else
                    g.DrawString(tempText & englishBidderCount, f16, Brushes.Black, New Point(pnlRange.Width / 2, pnlRange.Height - 30), fmt)
                End If

                If englishBidderFlash > 0 Then englishBidderFlash -= 1
            End If

            If englishObserver = -1 Then
                g.DrawString("Your Signal: " & Format(englishSignal, "0.00"), f16, Brushes.Blue, New Point(pnlRange.Width / 2, pnlRange.Height - 55), fmt)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawStrokeText(g As Graphics, text As String, fontSize As Integer, strokeSize As Integer, location As Point, fmt As StringFormat, fontBrush As Brush)
        Try
            Dim f As New Font("Microsoft Sans Serif", fontSize, System.Drawing.FontStyle.Bold)

            Dim p As New GraphicsPath

            p.AddString(text, New FontFamily("Microsoft Sans Serif"), FontStyle.Bold, fontSize, location, fmt)



            g.DrawPath(Pens.Black, p)
            g.FillPath(fontBrush, p)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function convertX(ByVal tempWidth As Integer,
                             ByVal xOffest As Integer,
                             ByVal markerWidth As Integer,
                             ByVal value As Double,
                             ByVal minValue As Double,
                             ByVal maxValue As Double) As Double
        Try

            If value < minValue Then value = minValue
            If value > maxValue Then value = maxValue

            Dim tempT As Double = tempWidth / (maxValue - minValue)
            Dim tempV As Double = value - minValue

            Return (tempT * tempV + xOffest - markerWidth / 2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Private Sub cmdDontBuy_Click(sender As Object, e As EventArgs) Handles cmdDontBuy.Click

        Try
            If showInstructions Then
                With frmInstructions

                    If Not .pagesDone(currentInstruction) And currentInstruction = .exp1 Then

                        If englishPrice <> 66 Then Exit Sub

                        englishBidderCount = 1
                        englishBidderFlash = 10

                        dg1.Columns.Add(dg1.Columns(6).Clone)
                        dg1.Columns(7).HeaderText = "Drop Price/Signal"
                        dg1.Rows.Insert(0, "1", "No", "71.00", "66.00", "5.00", "", "-/77.00", "66.00/66.00")
                        dg1(5, 0).Style.BackColor = Color.DimGray
                        dg1(7, 0).Style.ForeColor = Color.Green
                        dg1.CurrentCell.Selected = False

                        englishPhase = "result"
                        lblKeyValue.Visible = True
                        pnlKeyValue.Visible = True
                        'englishNewBid = 66
                        englishValue = 71
                        englishBid = 66

                        '.pagesDone(currentInstruction) = True

                        cmdDontBuy.Visible = False
                        cmdReadyToGoOn.Visible = True
                    End If
                End With
            Else
                Dim str As String = ""

                str = englishPrice & ";"

                cmdDontBuy.Visible = False

                frmClient.AC.sendMessage("05", str)
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtNewBid_TextChanged(sender As Object, e As EventArgs) Handles txtNewBid.TextChanged
        Try

            '  txtNewBid.Text = CDbl(txtNewBid.Text) + CDbl(sender.tag)

            'If Not validateInt(txtNewBid.Text, 6, True, False) Then Exit Sub

            'If CDbl(txtNewBid.Text) < englishPrice Then txtNewBid.Text = ""
            'If CDbl(txtNewBid.Text) > englishEndPrice Then txtNewBid.Text = ""

            'txtNewBid.Text = Format(CDbl(txtNewBid.Text), "0.00")

            'englishNewBid = CDbl(txtNewBid.Text)

            'If englishPhase = "start" Then
            '    englishBid = CDbl(txtNewBid.Text)
            'End If

            If Not validateInt(txtNewBid.Text, 6, True, False) Then
                'englishNewBid = CDbl(txtNewBid.Text)
                txtNewBid.Text = ""
                englishBid = 10000
                Exit Sub
            End If

            If CDbl(txtNewBid.Text) > englishSignal + englishRange Then
                txtNewBid.Text = ""
                Exit Sub
            End If

            englishBid = CDbl(txtNewBid.Text)
            Me.AcceptButton = cmdUpdateBid

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmEnglish_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not clientClosing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class