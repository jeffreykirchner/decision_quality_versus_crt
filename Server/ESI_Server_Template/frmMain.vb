
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMain
    ' Dim socketList(100) As synchronousSocketListener

    Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
    Dim ipAddress As IPAddress
    Dim localEndPoint As IPEndPoint

    ' Create a TCP/IP socket.
    Dim listener As New Socket(AddressFamily.InterNetwork,
                                   SocketType.Stream,
                                   ProtocolType.Tcp)

    'graph
    Public mainScreen As Screen
    Public mainScreen2 As Screen
    Dim yScaleMax As Integer

    Dim f16 As New Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold)
    Dim f12 As New Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
    Dim f8 As New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)
    Dim f6 As New Font("Microsoft Sans Serif", 6, System.Drawing.FontStyle.Bold)

    Dim pB3 As New Pen(Brushes.Black, 3)
    Dim pG3 As New Pen(Brushes.Green, 3)
    Dim pG2 As New Pen(Brushes.Green, 2)
    Dim pR3Dash As New Pen(Color.Red, 3)
    Dim pG3Dash As New Pen(Color.Green, 3)

    Dim fmt As New StringFormat 'center alignment
    Dim fmt2 As New StringFormat 'right alignment



    Public resetPressed As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i As Integer = 1 To ipHostInfo.AddressList.Count
            If ipHostInfo.AddressList(i - 1).ToString.IndexOf(".") > -1 Then
                ipAddress = ipHostInfo.AddressList(i - 1)

                Exit For
            End If
        Next

        localEndPoint = New IPEndPoint(IPAddress.Any, portNumber)

        listener.Bind(localEndPoint)
        listener.Listen(10)

        bwTakeSocketConnections.RunWorkerAsync()

        lblIpAddress.Text = ipAddress.ToString
        lblLocalHost.Text = SystemInformation.ComputerName
        lblConnectionCount.Text = "0"

        'setup graph
        mainScreen = New Screen(pnlBackGround, New Rectangle(0, 0, pnlBackGround.Width, pnlBackGround.Height))
        mainScreen2 = New Screen(pnlBackGround2, New Rectangle(0, 0, pnlBackGround2.Width, pnlBackGround2.Height))

        fmt.Alignment = StringAlignment.Center
        fmt2.Alignment = StringAlignment.Far


        pR3Dash.DashStyle = DashStyle.Dot
        capPen(pR3Dash)


        pG3Dash.DashStyle = DashStyle.Dot
        capPen(pG3Dash)

        capPen(pB3)
        capPen(pG3)

    End Sub

    Private Sub bwTakeSocketConnections_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwTakeSocketConnections.DoWork
        Try
            Dim go As Boolean = True

            Do While go
                Dim tempSocket As Socket = listener.Accept

                clientCount += 1
                playerlist(clientCount) = New player

                playerlist(clientCount).sp.socketHandler = tempSocket

                playerlist(clientCount).sp.startReceive()

                AddHandler playerlist(clientCount).sp.messageReceived, AddressOf setTakeMessage

                playerlist(clientCount).inumber = clientCount
                playerlist(clientCount).sp.inumber = clientCount

                If cmdBegin.Enabled = False Then
                    playerlist(clientCount).sendInvalidConnection()
                    clientCount -= 1
                End If

                refreshConnectionsLabel()

                If resetPressed Then go = False
            Loop
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Private Sub bwTakeSocketConnections_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTakeSocketConnections.RunWorkerCompleted
        Try
            txtMain.Text = ""
            txtError.Text = ""

            resetPressed = False

            For i As Integer = 1 To clientCount
                playerlist(i).sp.stopping = True
                playerlist(i).sp = Nothing
            Next

            clientCount = 0

            listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            listener.Bind(localEndPoint)
            listener.Listen(10)

            bwTakeSocketConnections.RunWorkerAsync()
            refreshConnectionsLabel()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Delegate Sub setTakeMessageCallback(text() As String)

    Public Sub setTakeMessage(ByVal text() As String)

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

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        Try
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False

            resetPressed = True

            For i As Integer = 1 To clientCount
                playerlist(i).sendreset()
            Next

            bwTakeSocketConnections.CancelAsync()

            listener.Close()

            If lotteryDf IsNot Nothing Then lotteryDf.Close()
            If secondPriceDf IsNot Nothing Then secondPriceDf.Close()
            If englishDf IsNot Nothing Then englishDf.Close()
            If english2Df IsNot Nothing Then english2Df.Close()
            If chatBotDf IsNot Nothing Then chatBotDf.Close()

            cmdBegin.Enabled = True
            cmdLoad.Enabled = True
            cmdExit.Enabled = True
            cmdExchange.Enabled = True

            cmdSetup1.Enabled = True
            cmdSetup2.Enabled = True
            cmdSetup3.Enabled = True
            cmdSetup4.Enabled = True
            cmdSetup5.Enabled = True

            cmdEndEarly.Enabled = False

            dgMain.RowCount = 0
            dgLottery.RowCount = 0

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdBegin_Click(sender As Object, e As EventArgs) Handles cmdBegin.Click
        Try
            loadParameters()

            doPeriodCount()

            'define timestamp for recording data
            tempTime = DateTime.Now.Month & "-" & DateTime.Now.Day & "-" & DateTime.Now.Year & "_" & DateTime.Now.Hour &
                         "_" & DateTime.Now.Minute & "_" & DateTime.Now.Second

            'save parameters
            filename = "Parameters_" & tempTime & ".csv"
            filename = Application.StartupPath & "\datafiles\" & filename
            writeINI(sfile, "GameSettings", "gameName", "ESI Software2")
            writeINI(sfile, "GameSettings", "gameName", "ESI Software")
            FileCopy(sfile, filename)

            Dim str As String

            If numberOfPeriodsLottery > 0 Then
                'create unique file name for storing data, CSVs are excel readable, Comma Separted Value files.
                filename = "Lottery_Data_" & tempTime & ".csv"
                filename = Application.StartupPath & "\datafiles\" & filename

                lotteryDf = File.CreateText(filename)
                str = "Period,Player,LotteryIndex,Choice,TimeExpired,"

                For i As Integer = 1 To 4
                    str &= "Red-" & i & "-$,"
                    str &= "Red-" & i & "-Ticket,"
                Next

                For i As Integer = 1 To 4
                    str &= "Blue-" & i & "-$,"
                    str &= "Blue-" & i & "-Ticket,"
                Next

                str &= "Winning#,"
                str &= "Flipped#,"

                lotteryDf.WriteLine(str)
                lotteryDf.AutoFlush = True
            End If

            If numberOfPeriodsSecondPrice > 0 Then

                If phaseList(1) = "2nd Price" Then
                    filename = "SecondPrice_Data_" & tempTime & ".csv"
                Else
                    filename = "English_Data_" & tempTime & ".csv"
                End If

                filename = Application.StartupPath & "\datafiles\" & filename

                secondPriceDf = File.CreateText(filename)
                str = "Period,Player,Group,Observer,GroupType,MarketPaid,Bid,BidIndex,Won,Value,PricePaid,Profit,TotalCash"

                secondPriceDf.WriteLine(str)
                secondPriceDf.AutoFlush = True
            End If

            If numberOfPeriodsEnglish > 0 Then
                filename = "CommonValue_Summary_Data_" & tempTime & ".csv"
                filename = Application.StartupPath & "\datafiles\" & filename

                englishDf = File.CreateText(filename)
                str = "Period,Treatment,Player,Group,Observer,FinalBid,Signal,Epsilon,Winner,Price,ActualValue,Profit"

                englishDf.WriteLine(str)
                englishDf.AutoFlush = True

                filename = "CommonValue_Bid_Data_" & tempTime & ".csv"
                filename = Application.StartupPath & "\datafiles\" & filename

                english2Df = File.CreateText(filename)
                If englishBidMode = "drop" Then
                    str = "Period,Treatment,Player,Group,Bid,Signal,Epsilon,ActualValue,CurrentPrice,BiddersRemaining,LastDropoutPrice,"
                Else
                    str = "Period,Treatment,Player,Group,Bid,Signal,Epsilon,ActualValue,"
                End If

                english2Df.WriteLine(str)
                english2Df.AutoFlush = True
            End If

            If enableChatBot Then
                filename = "ChatBot_Data_" & tempTime & ".csv"
                filename = Application.StartupPath & "\datafiles\" & filename
                chatBotDf = File.CreateText(filename)
                str = "Period,Treatment,Player,Group,Prompt,Response"
                chatBotDf.WriteLine(str)
                chatBotDf.AutoFlush = True
            End If

            'intialize parameters

            If numberOfPlayers <> clientCount Then
                Exit Sub
            End If

            currentPeriod = 1
            subLotteryPeriod = 0
            subSecondPricePeriod = 0
            subEnglishPeriod = 0

            dgMain.RowCount = numberOfPlayers

            For i As Integer = 1 To numberOfPlayers
                For k As Integer = 1 To numberOfPeriods
                    playerlist(i).myGroup(k) = -1
                    playerlist(i).secondPriceSmallGroup(k) = -1
                Next

                dgMain(0, i - 1).Value = i
                dgMain(1, i - 1).Value = playerlist(i).sp.remoteComputerName
                dgMain(3, i - 1).Value = FormatCurrency(0)
            Next

            dgMain.CurrentCell.Selected = False

            'lottery setup
            If numberOfPeriodsLottery > 0 Then

                For i As Integer = 1 To numberOfPeriodsLottery

                    lotteryChoicePeriods(i) = New lotteryChoicePeriod(
                           getINI(sfile, "lotteries", i & "-Red"),
                           getINI(sfile, "lotteries", i & "-Blue"))


                    For j As Integer = 1 To numberOfPlayers
                        If rand(2, 1) = 1 Then
                            playerlist(j).lotteryChoicesFlipped(i) = True
                        Else
                            playerlist(j).lotteryChoicesFlipped(i) = False
                        End If
                    Next


                Next

                lotteryChoicePeriods(0) = New lotteryChoicePeriod(
                           getINI(sfile, "lotteries", "Instructions-Red"),
                           getINI(sfile, "lotteries", "Instructions-Blue"))
            End If

            'english setup
            If numberOfPeriodsEnglish > 0 Then
                'groups
                For i As Integer = 1 To numberOfPlayers
                    Dim msgtokens() As String = getINI(sfile, "englishGroups", CStr(i)).Split(";")
                    Dim nextToken As Integer = 0

                    For j As Integer = 1 To 6
                        englishGroups(j, i) = msgtokens(nextToken)
                        nextToken += 1
                    Next

                    For j As Integer = 1 To numberOfPeriodsEnglish
                        playerlist(i).doNotBuyPress(j) = False
                        playerlist(i).englishBids(j) = -1
                        playerlist(i).englishObserver(j) = -1
                    Next

                    playerlist(i).englishEarnings = englishStartingCash
                Next

                'signals
                For i As Integer = 1 To numberOfPeriodsEnglish
                    Dim msgtokens() As String = getINI(sfile, "englishSignals", CStr(i)).Split(";")
                    Dim nextToken As Integer = 0

                    For j As Integer = 1 To 10
                        englishSignals(j, i) = msgtokens(nextToken)
                        nextToken += 1
                    Next

                    For j As Integer = 1 To 6
                        englishPrice(j, i) = englishStartPrice
                        englishWinners(j, i) = -1
                    Next

                    englishValues(i) = getINI(sfile, "englishValues", CStr(i))

                    englishRanges(i) = msgtokens(nextToken)
                    nextToken += 1

                    englishNumberOfGroups(i) = 0
                Next

                'timing
                englishTickAmount(1) = 0
                For i As Integer = 2 To 7
                    englishTickAmount(i) = getINI(sfile, "englishTiming", CStr(i))
                Next
            End If

            'load second price values
            If numberOfPeriodsSecondPrice > 0 Then
                'load groups for second price sizes
                For i As Integer = 1 To numberOfPlayers
                    Dim msgtokens() As String = getINI(sfile, "2ndPriceGroupSetup", CStr(i)).Split(";")

                    For j As Integer = 1 To 7
                        secondPriceGroups(j, i) = msgtokens(j - 1)
                    Next
                Next

                'reset seond price bid orders
                For i As Integer = 1 To 10
                    For j As Integer = 1 To 100
                        For k As Integer = 1 To 100
                            secondPriceBidListLarge(i, j, k) = Nothing
                            secondPriceBidListSmall(i, j, k) = Nothing
                        Next

                        'english bids
                        englishPriceSmallPV(i, j) = 0
                        englishPriceLargePV(i, j) = 0

                        englishSmallDonePV(j) = False
                        englishLargeDonePV(j) = False
                    Next
                Next

                'setup english PV first side
                Dim tempC As Integer = 1
                For i As Integer = 1 To numberOfPeriods
                    If phaseList(tempC) = "English Auction SL" Then

                        phaseList(tempC) = "English Auction"
                        englishSidePV(tempC) = "small"
                        tempC += 1

                    ElseIf phaseList(tempC) = "English Auction LS" Then

                        phaseList(tempC) = "English Auction"
                        englishSidePV(tempC) = "large"
                        tempC += 1

                    End If
                Next

                For i As Integer = 1 To numberOfPlayers

                    For j As Integer = 1 To numberOfPeriodsSecondPrice
                        playerlist(i).secondPriceBidsLarge(j) = Nothing
                        playerlist(i).secondPriceBidsLarge(j) = Nothing

                        playerlist(i).secondPriceObserverLarge(j) = -1
                        playerlist(i).secondPriceObserverSmall(j) = -1
                    Next

                    playerlist(i).secondPriceEarnings = secondPriceStartingCash
                Next

                For i As Integer = 1 To numberOfPeriodsSecondPrice
                    Dim msgtokens() As String = getINI(sfile, "secondPrice", CStr(i)).Split(";")
                    Dim nextToken As Integer = 0

                    For j As Integer = 1 To 12
                        secondPriceValues(j, i) = CDbl(msgtokens(nextToken)) / 100
                        nextToken += 1
                    Next
                Next

                'second price instructions
                secondPriceExampleCount = getINI(sfile, "gameSettings", "secondPriceExampleCount")

                For i As Integer = 1 To secondPriceExampleCount
                    secondPriceExamplesLarge(i) = getINI(sfile, "2ndPriceInstructionSetup", i & "-large")
                    secondPriceExamplesSmall(i) = getINI(sfile, "2ndPriceInstructionSetup", i & "-small")
                Next
            End If

            checkin = 0

            Dim outstr As String = ""

            If phaseList(1) = "2nd Price" Or phaseList(1) = "English Auction" Then
                subSecondPricePeriod = 1
                setupGroupsSecondPrice()

                If Not showInstructions Then
                    For i As Integer = 1 To numberOfPlayers
                        If playerlist(i).myGroup(currentPeriod) = -1 Then checkin += 1
                    Next
                End If

                Timer4.Interval = englishTickRatePV

                If phaseList(1) = "English Auction" And Not showInstructions Then
                    Timer4.Enabled = True
                End If

            ElseIf phaseList(1) = "Lottery" Then
                subLotteryPeriod = 1
            Else
                subEnglishPeriod = 1
                englishPhase = "start"
                setupGroupsEnglish()
            End If

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).sendBegin(outstr)

                refreshDisplayStatus(i)
            Next

            'start delay for enlglish drop mode
            If Not showInstructions Then
                If (phaseList(1) = "CV Full Info" Or phaseList(1) = "CV Limited Info") And englishBidMode = "drop" Then
                    englishCurrentStartDelay = englishStartDelay
                    Timer3.Enabled = True
                End If
            End If

            cmdBegin.Enabled = False
            cmdLoad.Enabled = False
            cmdExit.Enabled = False
            cmdExchange.Enabled = False

            cmdSetup1.Enabled = False
            cmdSetup2.Enabled = False
            cmdSetup3.Enabled = False
            cmdSetup4.Enabled = False
            cmdSetup5.Enabled = False

            cmdEndEarly.Enabled = True

            calcGridCords()

            yScaleMax = secondPriceEndValue * 1.1
            Timer1.Enabled = True

            setupLotteryDisplay()
            updatePeriodDisplay()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupLotteryDisplay()
        Try
            'setup display table for lottery results

            Dim tempC As Integer = 0
            For i As Integer = 1 To numberOfPeriods
                If phaseList(i) = "Lottery" Then
                    tempC += 1

                    dgLottery.RowCount += 2

                    dgLottery(0, dgLottery.RowCount - 2).Value = tempC
                    dgLottery(0, dgLottery.RowCount - 1).Value = tempC

                    dgLottery(1, dgLottery.RowCount - 2).Value = "0"
                    dgLottery(1, dgLottery.RowCount - 1).Value = "0"

                    dgLottery(2, dgLottery.RowCount - 2).Value = "Red"
                    dgLottery(2, dgLottery.RowCount - 1).Value = "Blue"

                    Dim msgtokens() As String = getINI(sfile, "lotteries", tempC & "-Red").Split(";")
                    Dim nextToken As Integer = 0

                    For j As Integer = 1 To 8
                        dgLottery(j + 2, dgLottery.RowCount - 2).Value = msgtokens(nextToken)
                        nextToken += 1

                        If j Mod 2 = 1 Then
                            dgLottery(j + 2, dgLottery.RowCount - 2).Value = "$" & dgLottery(j + 2, dgLottery.RowCount - 2).Value
                        End If
                    Next

                    msgtokens = getINI(sfile, "lotteries", tempC & "-Blue").Split(";")
                    nextToken = 0

                    For j As Integer = 1 To 8
                        dgLottery(j + 2, dgLottery.RowCount - 1).Value = msgtokens(nextToken)
                        nextToken += 1

                        If j Mod 2 = 1 Then
                            dgLottery(j + 2, dgLottery.RowCount - 1).Value = "$" & dgLottery(j + 2, dgLottery.RowCount - 1).Value
                        End If
                    Next

                    'back color
                    If tempC Mod 2 = 0 Then
                        For j As Integer = 1 To dgLottery.ColumnCount
                            dgLottery(j - 1, dgLottery.RowCount - 2).Style.BackColor = Color.FromArgb(192, 192, 255)
                            dgLottery(j - 1, dgLottery.RowCount - 1).Style.BackColor = Color.FromArgb(192, 192, 255)
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Delegate Sub setConnectionsLabelCallback(text As String)

    Public Sub setConnectionsLabel(ByVal text As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If lblConnectionCount.InvokeRequired Then
            Dim d As New setConnectionsLabelCallback(AddressOf setConnectionsLabel)
            Me.Invoke(d, New Object() {text})
        Else
            lblConnectionCount.Text = text
        End If
    End Sub

    Public Sub refreshConnectionsLabel()
        Try
            setConnectionsLabel(clientCount)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            'save current parameters to a text file so they can be loaded at a later time

            SaveFileDialog1.FileName = ""
            SaveFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            FileCopy(sfile, SaveFileDialog1.FileName)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Try
            Dim tempS As String
            Dim sinstr As String

            'dispaly open file dialog to select file
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath

            OpenFileDialog1.ShowDialog()

            'if filename is not empty then continue with load
            If OpenFileDialog1.FileName = "" Then
                Exit Sub
            End If

            tempS = OpenFileDialog1.FileName

            sinstr = getINI(tempS, "gameSettings", "gameName")

            'check that this is correct type of file to load
            If sinstr <> "ESI Software" Then
                MsgBox("Invalid file", vbExclamation)
                Exit Sub
            End If

            'copy file to be loaded into server.ini
            FileCopy(OpenFileDialog1.FileName, sfile)

            'load new parameters into server
            loadParameters()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup1_Click(sender As Object, e As EventArgs) Handles cmdSetup1.Click
        Try
            frmSetup1.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdExchange_Click(sender As Object, e As EventArgs) Handles cmdExchange.Click
        Try

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdEndEarly_Click(sender As Object, e As EventArgs) Handles cmdEndEarly.Click
        Try
            cmdEndEarly.Enabled = False

            numberOfPeriods = currentPeriod

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).SendEndEarly()
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup2_Click(sender As Object, e As EventArgs) Handles cmdSetup2.Click
        Try
            frmSetup2.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup3_Click(sender As Object, e As EventArgs) Handles cmdSetup3.Click
        Try
            frmSetup3.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSetup4_Click(sender As Object, e As EventArgs) Handles cmdSetup4.Click
        Try
            frmSetup4.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub dgMain_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgMain.CellMouseClick, dgMain.CellMouseDoubleClick
        Try
            If dgMain.RowCount > 0 Then dgMain.CurrentCell.Selected = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Try
            If PrintDialog1.ShowDialog = DialogResult.OK Then
                PrintDocument1.Print()
            End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim i As Integer
            Dim f As New Font("Arial", 8, FontStyle.Bold)
            Dim tempN As Integer

            ' e.Graphics.DrawString(filename, f, Brushes.Black, 10, 10)

            f = New Font("Arial", 15, FontStyle.Bold)

            e.Graphics.DrawString("Name", f, Brushes.Black, 10, 30)
            e.Graphics.DrawString("Earnings", f, Brushes.Black, 400, 30)

            f = New Font("Arial", 12, FontStyle.Bold)

            tempN = 55

            For i = 1 To dgMain.RowCount
                If i Mod 2 = 0 Then
                    e.Graphics.FillRectangle(Brushes.Aqua, 0, tempN, 500, 19)
                End If
                e.Graphics.DrawString(dgMain.Rows(i - 1).Cells(1).Value, f, Brushes.Black, 10, tempN)
                e.Graphics.DrawString(dgMain.Rows(i - 1).Cells(3).Value, f, Brushes.Black, 400, tempN)

                tempN += 20
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    'Second Price graph
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'second price
            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawAxis(g)
            drawBids(g)

            mainScreen.flip()

            'english
            mainScreen2.erase1()
            Dim g2 As Graphics = mainScreen2.GetGraphics

            g2.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            drawEnglish(g2)

            mainScreen2.flip()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawEnglish(g As Graphics)
        Try
            Dim tempYIncrement As Double = (pnlBackGround2.Height - 40) / 3
            Dim tempY = 10

            Dim biddersLeft(10) As Integer
            englishCalcBiddersLeft(biddersLeft)

            If rbGroup13.Checked Then
                For i As Integer = 1 To 3
                    drawEnglishGroup(g, i, tempY, tempYIncrement, biddersLeft)

                    tempY += 10 + tempYIncrement
                Next
            Else
                For i As Integer = 4 To 6
                    drawEnglishGroup(g, i, tempY, tempYIncrement, biddersLeft)

                    tempY += 10 + tempYIncrement
                Next
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawEnglishGroup(g As Graphics, index As Integer, startY As Double, height As Double, biddersLeft() As Integer)
        Try
            g.TranslateTransform(10, startY)

            Dim width As Double = pnlBackGround2.Width - 20
            Dim xOffset As Integer = 30

            'price
            Dim tempXP As Double = englishConvertX(width - xOffset * 2, xOffset, 0, englishPrice(index, subEnglishPeriod), englishStartScale, englishEndScale)

            'actual value
            Dim tempXV As Double = englishConvertX(width - xOffset * 2, xOffset, 0, englishValues(subEnglishPeriod), englishStartScale, englishEndScale)

            'bottom scale
            Dim tempXSL As Double = englishConvertX(width - xOffset * 2, xOffset, 0, englishMinValue, englishStartScale, englishEndScale)
            Dim tempXSR As Double = englishConvertX(width - xOffset * 2, xOffset, 0, englishMaxValue, englishStartScale, englishEndScale)

            'move to global

            g.DrawRectangle(Pens.Black, New Rectangle(0, 0, width, height))

            g.DrawString("Group: " & index, f12, Brushes.DimGray, New Point(width - 5, 2), fmt2)
            g.DrawString("Bidders: " & biddersLeft(index), f12, Brushes.DimGray, New Point(width - 5, 20), fmt2)
            g.DrawString("Price: " & Format(englishPrice(index, subEnglishPeriod), "0.00"), f12, Brushes.DimGray, New Point(width - 5, 38), fmt2)
            g.DrawString("Value: " & englishValues(subEnglishPeriod), f12, Brushes.DimGray, New Point(width - 5, 56), fmt2)

            If phaseList(currentPeriod) = "CV Full Info" Or
                phaseList(currentPeriod) = "CV Limited Info" Then

                'price line
                g.DrawLine(pR3Dash, New Point(tempXP, 5), New Point(tempXP, height - 30))

                'actual value line
                g.DrawLine(pG3Dash, New Point(tempXV, 5), New Point(tempXV, height - 30))
            End If

            'bottom scale
            g.DrawLine(pB3, New Point(xOffset, height - 30), New Point(width - xOffset, height - 30))
            g.DrawLine(pB3, New Point(tempXSL, height - 30 - 5), New Point(tempXSL, height - 30 + 5))
            g.DrawLine(pB3, New Point(tempXSR, height - 30 - 5), New Point(tempXSR, height - 30 + 5))

            g.DrawString(Format(englishMinValue, "0.00"), f12, Brushes.SaddleBrown, New Point(tempXSL, height - 30 + 5), fmt)
            g.DrawString(Format(englishMaxValue, "0.00"), f12, Brushes.SaddleBrown, New Point(tempXSR, height - 30 + 5), fmt)

            If phaseList(currentPeriod) = "CV Full Info" Or
                   phaseList(currentPeriod) = "CV Limited Info" Then
                Dim startRangeY As Double = height - 45
                For i As Integer = 1 To numberOfPlayers
                    If playerlist(i).myGroup(currentPeriod) = index Then
                        drawEnglishRange(g, i, startRangeY, width, xOffset)
                        startRangeY -= 30
                    End If
                Next
            End If

            g.ResetTransform()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawEnglishRange(g As Graphics, index As Integer, startY As Double, width As Double, xOffset As Integer)
        Try
            Dim tempXC As Double = englishConvertX(width - xOffset * 2, xOffset, 0, playerlist(index).englishSignals(subEnglishPeriod), englishStartScale, englishEndScale)
            Dim tempXL As Double = englishConvertX(width - xOffset * 2, xOffset, 0, playerlist(index).englishSignals(subEnglishPeriod) - englishRanges(subEnglishPeriod), englishStartScale, englishEndScale)
            Dim tempXR As Double = englishConvertX(width - xOffset * 2, xOffset, 0, playerlist(index).englishSignals(subEnglishPeriod) + englishRanges(subEnglishPeriod), englishStartScale, englishEndScale)
            Dim tempXB As Double = englishConvertX(width - xOffset * 2, xOffset, 0, playerlist(index).englishBids(subEnglishPeriod), englishStartScale, englishEndScale)

            Dim pBl4 As New Pen(Brushes.Blue, 4)
            Dim pCf4 As New Pen(Brushes.CornflowerBlue, 4)
            Dim pPur3 As New Pen(Brushes.Purple, 3)
            Dim pMedPur3 As New Pen(Brushes.MediumPurple, 3)

            capPen(pBl4)
            capPen(pCf4)
            capPen(pPur3)
            capPen(pMedPur3)

            'left hash
            g.DrawLine(pCf4,
                         New Point(tempXL, startY),
                         New Point(tempXL + 4, startY - 8))

            g.DrawLine(pCf4,
                         New Point(tempXL, startY),
                         New Point(tempXL + 4, startY + 8))

            'right hash
            g.DrawLine(pCf4,
                         New Point(tempXR, startY),
                         New Point(tempXR - 4, startY - 8))

            g.DrawLine(pCf4,
                       New Point(tempXR, startY),
                       New Point(tempXR - 4, startY + 8))

            'range line
            g.DrawLine(pCf4,
                        New Point(tempXL, startY),
                        New Point(tempXR, startY))


            'signal line
            g.DrawLine(pBl4,
                       New Point(tempXC, startY - 8),
                       New Point(tempXC, startY + 8))

            'bid
            If playerlist(index).englishBids(subEnglishPeriod) <= englishPrice(playerlist(index).myGroup(currentPeriod), subEnglishPeriod) Then
                g.DrawLine(pMedPur3, New Point(tempXB - 5, startY - 5), New Point(tempXB + 5, startY + 5))
                g.DrawLine(pMedPur3, New Point(tempXB - 5, startY + 5), New Point(tempXB + 5, startY - 5))
            Else
                g.DrawLine(pPur3, New Point(tempXB - 5, startY - 5), New Point(tempXB + 5, startY + 5))
                g.DrawLine(pPur3, New Point(tempXB - 5, startY + 5), New Point(tempXB + 5, startY - 5))
            End If

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

    Public Function englishConvertX(ByVal tempWidth As Integer,
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

    Public Sub drawBids(ByVal g As Graphics)
        Try
            Dim tempAdder As Double
            Dim tempAdderRunning As Double
            Dim tempG As Integer = 1
            Dim tempC As Integer = 0
            Dim tempSubPeriod As Integer = 1

            tempX = 50

            If rbLG1.Checked Then
                tempG = 1
            ElseIf rbLG2.Checked Then
                tempG = 2
            ElseIf rbSG1a.Checked Then
                tempG = 1
            ElseIf rbSG1b.Checked Then
                tempG = 2
            ElseIf rbSG2a.Checked Then
                tempG = 3
            ElseIf rbSG2b.Checked Then
                tempG = 4
            End If

            For i As Integer = 1 To numberOfPeriods

                If phaseList(i) = "2nd Price" Or
                    phaseList(currentPeriod) = "English Auction" Then

                    'find number of people in group
                    tempC = 0

                    'start at beging of period and show bids/values 


                    If rbLG1.Checked Or rbLG2.Checked Then
                        tempC = getNumberInMyGroup(tempG, i)

                        tempAdder = tempXIncrement / (tempC + 1)
                        tempAdderRunning = tempX

                        drawBids2(g, secondPriceBidListLarge, tempC, tempG, tempSubPeriod, tempAdder)
                    Else
                        tempC = getSecondPriceNumberInMyGroupSmall(tempG, i)

                        tempAdder = tempXIncrement / (tempC + 1)
                        tempAdderRunning = tempX

                        drawBids2(g, secondPriceBidListSmall, tempC, tempG, tempSubPeriod, tempAdder)
                    End If

                    tempX += tempXIncrement
                    tempSubPeriod += 1
                End If
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawBids2(g As Graphics, secondPriceBidList(,,) As secondPriceBid, tempC As Integer, tempG As Integer, tempSubPeriod As Integer, tempAdder As Integer)
        Try
            Dim tempX2 As Double
            Dim tempY2 As Double
            Dim tempY3 As Double

            'draw demand
            For j As Integer = 1 To tempC
                With secondPriceBidList(tempG, tempSubPeriod, j)
                    If secondPriceBidList(tempG, tempSubPeriod, j) IsNot Nothing Then

                        tempX2 = convertX(tempXIncrement, tempX, 8, j, tempC)
                        tempY3 = convertY(.value, 0, yScaleMax, pnlBackGround.Height - 30 - 5, 8, 5)

                        g.DrawLine(pG2, CInt(tempX + (j - 1) * tempAdder + tempAdder / 2), CInt(tempY3), CInt(tempX + j * tempAdder + tempAdder / 2), CInt(tempY3))

                        If j > 1 Then
                            tempY2 = convertY(secondPriceBidList(tempG, tempSubPeriod, j - 1).value, 0, yScaleMax, pnlBackGround.Height - 30 - 5, 8, 5)

                            g.DrawLine(pG2, CInt(tempX + (j - 1) * tempAdder + tempAdder / 2), CInt(tempY2), CInt(tempX + (j - 1) * tempAdder + tempAdder / 2), CInt(tempY3))
                        End If
                    End If
                End With
            Next

            'draw bids
            For j As Integer = 1 To tempC
                With secondPriceBidList(tempG, tempSubPeriod, j)
                    If secondPriceBidList(tempG, tempSubPeriod, j) IsNot Nothing Then

                        If phaseList(tempSubPeriod) <> "English Auction" Or
                           (phaseList(tempSubPeriod) = "English Auction" And j <> 1) Then

                            tempX2 = convertX(tempXIncrement, tempX, 8, j, tempC)
                            tempY2 = convertY(.bid, 0, yScaleMax, pnlBackGround.Height - 30 - 5, 6, 5)

                            If .value >= .bid Then
                                g.FillEllipse(Brushes.CornflowerBlue, New Rectangle(tempX2, tempY2, 6, 6))
                            Else
                                g.FillEllipse(Brushes.Crimson, New Rectangle(tempX2, tempY2, 6, 6))
                            End If

                            g.DrawEllipse(Pens.Black, New Rectangle(tempX2, tempY2, 6, 6))

                            If .bid > yScaleMax Then
                                yScaleMax = Math.Ceiling(.bid / 10) * 10
                                calcGridCords()
                            End If
                        End If
                    End If
                End With
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawAxis(ByVal g As Graphics)
        Try

            'grid
            For i As Integer = 1 To gridCount
                g.DrawLine(Pens.LightGray, 50, yGrid(i), pnlBackGround.Width - 10, yGrid(i))
            Next

            'For i As Integer = 1 To numberOfPeriods
            '    g.DrawLine(Pens.LightGray, xGrid(i), 5, xGrid(i), pnlBackGround.Height - 30)
            'Next

            'axis
            g.DrawLine(pB3, 50, 5, 50, pnlBackGround.Height - 30)
            g.DrawLine(pB3, 50, pnlBackGround.Height - 30, pnlBackGround.Width - 10, pnlBackGround.Height - 30)

            'draw price ticks
            tempY = 5
            tempYIncrement = (pnlBackGround.Height - 30 - 5) / gridCount

            tempP = yScaleMax
            tempPIncrement = yScaleMax / gridCount

            For i As Integer = 1 To gridCount + 1
                'price ticks
                g.DrawLine(pB3, 45, CInt(tempY), 50, CInt(tempY))
                g.DrawString(Math.Round(tempP), f12, Brushes.Black, 45, tempY - 7, fmt2)

                tempY += tempYIncrement
                tempP -= tempPIncrement
            Next

            'period ticks
            tempX = 50 + tempXIncrement / 2
            For i As Integer = 1 To numberOfPeriodsSecondPrice
                g.DrawLine(pB3, CInt(tempX - tempXIncrement / 2), pnlBackGround.Height - 30, CInt(tempX - tempXIncrement / 2), pnlBackGround.Height - 25)
                g.DrawString(CStr(i), f12, Brushes.Black, tempX, pnlBackGround.Height - 25, fmt)
                tempX += tempXIncrement
            Next

            g.TranslateTransform(0, pnlBackGround.Height / 2)
            g.RotateTransform(-90)
            g.DrawString("Bid", f8, Brushes.DarkGray, 0, 0)
            g.ResetTransform()

            'g.TranslateTransform(pnlBackGround.Width / 2, pnlBackGround.Height - 15)
            'g.DrawString("Period", f3, Brushes.DarkGray, 0, 0)
            'g.ResetTransform()

        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub

    Dim gridCount As Integer
    Dim xGrid(100) As Integer
    Dim yGrid(100) As Integer
    Dim tempY As Double
    Dim tempYIncrement As Double
    Dim tempX As Double
    Dim tempXIncrement As Double
    Dim tempP As Double
    Dim tempPIncrement As Double

    Public Sub calcGridCords()
        Try
            gridCount = 10

            tempY = 5
            tempYIncrement = (pnlBackGround.Height - 30 - 5) / gridCount

            For i As Integer = 1 To gridCount
                yGrid(i) = Math.Round(tempY)
                tempY += tempYIncrement
            Next

            tempXIncrement = (pnlBackGround.Width - 50 - 10) / numberOfPeriodsSecondPrice
            tempX = 50 + tempXIncrement

            For i As Integer = 1 To numberOfPeriodsSecondPrice
                xGrid(i) = Math.Round(tempX)
                tempX += tempXIncrement
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function convertX(ByVal tempWidth As Integer, ByVal xOffest As Integer, ByVal markerWidth As Integer, tempTime As Integer, periodLength As Double) As Double
        Try
            periodLength += 1

            Dim tempT As Double = tempWidth / periodLength
            Dim tempV As Double = tempTime

            Return (tempT * tempV + xOffest - markerWidth / 2)

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function convertY(ByVal p As Double, ByVal graphMin As Integer, ByVal graphMax As Integer,
                             ByVal tempHeight As Integer, ByVal markerWidth As Integer, ByVal yOffset As Integer) As Double
        Try

            Dim tempD As Double

            If p > graphMax Then p = graphMax 'check off scale high

            tempD = p - graphMin

            tempD = tempD / (graphMax - graphMin)
            tempD = tempHeight * (1 - tempD) + yOffset

            convertY = tempD - markerWidth / 2  'adjust for width of marker

        Catch ex As Exception
            appEventLog_Write("error convertY:", ex)
            Return 0
        End Try
    End Function

    Private Sub cmdSetup5_Click(sender As Object, e As EventArgs) Handles cmdSetup5.Click
        Try
            frmSetup5.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            'english clock

            'check for groups that are done.

            Dim biddersLeft(10) As Integer 'number of vaild bidders left

            englishCalcBiddersLeft(biddersLeft)

            'if group has 2 or more bidders raise price
            For i As Integer = 1 To englishNumberOfGroups(subEnglishPeriod)
                If biddersLeft(i) > 1 Then
                    englishPrice(i, subEnglishPeriod) += englishTickAmount(biddersLeft(i))
                End If
            Next

            'check for stopage
            englishCheckForStopage(-1)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub englishDoResults(biddersLeft() As Integer)
        Try
            englishPhase = "result"

            Timer2.Enabled = False

            'find winner for each group
            For i As Integer = 1 To englishNumberOfGroups(subEnglishPeriod)
                calcEnglishWinner(i)
            Next

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).sendEnglishResult(biddersLeft)

                If playerlist(i).englishEarnings < 0 Then
                    dgMain(2, i - 1).Value = "Out"
                Else
                    dgMain(2, i - 1).Value = "Reviewing Results"
                End If
            Next

            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).englishEarnings < 0 Then
                    checkin += 1
                End If
            Next

            'all bankrupt
            If checkin = numberOfPlayers Then
                checkin = 0
                startNextPeriod()
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub englishCheckForStopage(index As Integer)
        Try
            If englishPhase = "result" Then Exit Sub

            Dim biddersLeft(10) As Integer 'number of vaild bidders left

            englishCalcBiddersLeft(biddersLeft)

            Dim go As Boolean = False
            For i As Integer = 1 To englishNumberOfGroups(subEnglishPeriod)
                If biddersLeft(i) > 1 Then
                    go = True
                End If
            Next

            If Not go Then
                englishDoResults(biddersLeft)
            Else
                'update new prices
                If index = -1 Then
                    For i As Integer = 1 To numberOfPlayers
                        playerlist(i).sendEnglishUpdate(biddersLeft)
                    Next
                Else
                    playerlist(index).sendEnglishUpdate(biddersLeft)
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub calcEnglishWinner(index As Integer)
        Try
            Dim tempCount As Integer = 0
            Dim tempList(100) As Integer
            Dim tempBid As Double = 0

            'find winner
            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).myGroup(currentPeriod) = index Then
                    If tempCount = 0 Then
                        tempCount += 1
                        tempList(tempCount) = i
                        tempBid = playerlist(i).englishBids(subEnglishPeriod)
                    ElseIf playerlist(i).englishBids(subEnglishPeriod) = tempBid Then
                        tempCount += 1
                        tempList(tempCount) = i
                    ElseIf playerlist(i).englishBids(subEnglishPeriod) > tempBid Then
                        tempCount = 1
                        tempList(tempCount) = i
                        tempBid = playerlist(i).englishBids(subEnglishPeriod)
                    End If
                End If
            Next

            Dim tempWinner As Integer = tempList(rand(tempCount, 1))

            englishWinners(index, subEnglishPeriod) = tempWinner

            'put winning bid at head of list
            englishBidsListFinal(index, subEnglishPeriod, 1) = New englishBid(playerlist(tempWinner).englishBids(subEnglishPeriod),
                                                                                  tempWinner,
                                                                                  playerlist(tempWinner).englishSignals(subEnglishPeriod))
            Dim tempCount2 As Integer = 1
            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).myGroup(currentPeriod) = index And i <> tempWinner Then

                    'find spot
                    Dim tempSpot As Integer = -1
                    For j As Integer = 2 To tempCount2
                        If playerlist(i).englishBids(subEnglishPeriod) > englishBidsListFinal(index, subEnglishPeriod, j).bid Then
                            tempSpot = j
                            Exit For
                        End If
                    Next

                    tempCount2 += 1

                    If tempSpot = -1 Then
                        tempSpot = tempCount2
                    Else
                        For j As Integer = tempCount2 To tempSpot + 1 Step -1
                            englishBidsListFinal(index, subEnglishPeriod, j) = New englishBid(englishBidsListFinal(index, subEnglishPeriod, j - 1).bid,
                                                                                                  englishBidsListFinal(index, subEnglishPeriod, j - 1).owner,
                                                                                                   englishBidsListFinal(index, subEnglishPeriod, j - 1).signal)
                        Next
                    End If

                    englishBidsListFinal(index, subEnglishPeriod, tempSpot) = New englishBid(playerlist(i).englishBids(subEnglishPeriod),
                                                                                                 i,
                                                                                                 playerlist(i).englishSignals(subEnglishPeriod))

                End If
            Next

            If englishBidMode = "full" Then
                If englishPriceMode = "first" Then
                    englishPrice(index, subEnglishPeriod) = englishBidsListFinal(index, subEnglishPeriod, 1).bid
                Else
                    englishPrice(index, subEnglishPeriod) = englishBidsListFinal(index, subEnglishPeriod, 2).bid
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub englishCalcBiddersLeft(ByRef biddersLeft() As Integer)
        Try
            For i As Integer = 1 To 10
                biddersLeft(i) = 0
            Next

            'reset drop prices
            For i As Integer = 1 To 7
                englishLastDropPrice(i) = -1
            Next

            'find number of remaining bidders
            For i As Integer = 1 To englishNumberOfGroups(subEnglishPeriod)
                For j As Integer = 1 To numberOfPlayers

                    If englishPhase = "start" Then
                        If playerlist(j).myGroup(currentPeriod) = i Then
                            biddersLeft(i) += 1
                        End If
                    Else
                        If playerlist(j).myGroup(currentPeriod) = i Then
                            If playerlist(j).englishBids(subEnglishPeriod) > englishPrice(i, subEnglishPeriod) Then
                                biddersLeft(i) += 1
                            Else
                                'record highest dropout price
                                If englishLastDropPrice(i) < playerlist(j).englishBids(subEnglishPeriod) Then englishLastDropPrice(i) = playerlist(j).englishBids(subEnglishPeriod)
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function getNumberInMyGroup(tempGroup As Integer, tempPeriod As Integer) As Integer
        Try
            Dim tempN As Integer = 0

            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).myGroup(tempPeriod) = tempGroup Then
                    tempN += 1
                End If
            Next

            Return tempN
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function getSecondPriceNumberInMyGroupSmall(tempGroup As Integer, tempPeriod As Integer) As Integer
        Try
            Dim tempN As Integer = 0

            For i As Integer = 1 To numberOfPlayers
                If playerlist(i).secondPriceSmallGroup(tempPeriod) = tempGroup Then
                    tempN += 1
                End If
            Next

            Return tempN
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Sub updatePeriodDisplay()
        Try
            txtPeriod1.Text = currentPeriod
            txtPeriod2.Text = currentPeriod
            txtPeriod3.Text = currentPeriod

            txtPhase1.Text = phaseList(currentPeriod)
            txtPhase2.Text = phaseList(currentPeriod)
            txtPhase3.Text = phaseList(currentPeriod)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            If englishCurrentStartDelay = 0 Then
                startEnglishClock()
                Timer3.Enabled = False
            Else
                englishCurrentStartDelay -= 1

                For i As Integer = 1 To numberOfPlayers
                    playerlist(i).sendEnglishDelay()
                Next
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Try

            'tick prices up
            If englishSidePV(subSecondPricePeriod) = "large" Then

                For i As Integer = 1 To secondPriceNumberOfGroupsLarge(subSecondPricePeriod)

                    If englishPriceLargePV(i, subSecondPricePeriod) = secondPriceMaxBid Then Exit Sub

                    If getEnglishPVPlayers(i) > 1 Then

                        englishPriceLargePV(i, subSecondPricePeriod) += englishTickAmountPV

                        If englishPriceLargePV(i, subSecondPricePeriod) > secondPriceMaxBid Then englishPriceLargePV(i, subSecondPricePeriod) = secondPriceMaxBid

                    End If
                Next
            Else

                For i As Integer = 1 To secondPriceNumberOfGroupsSmall(subSecondPricePeriod)

                    If englishPriceSmallPV(i, subSecondPricePeriod) > secondPriceMaxBid = secondPriceMaxBid Then Exit Sub

                    If getEnglishPVPlayers(i) > 1 Then

                        englishPriceSmallPV(i, subSecondPricePeriod) += englishTickAmountPV

                        If englishPriceSmallPV(i, subSecondPricePeriod) > secondPriceMaxBid Then englishPriceSmallPV(i, subSecondPricePeriod) = secondPriceMaxBid
                    End If
                Next
            End If

            For i As Integer = 1 To numberOfPlayers
                playerlist(i).sendUpdateEnglishPV()
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        Try
            'copy student id and earnings to clip board
            Dim tempString As String = ""

            For i As Integer = 1 To numberOfPlayers

                tempString += playerlist(i).studentID & vbTab
                tempString += dgMain(3, i - 1).Value & vbCrLf
            Next

            Clipboard.SetText(tempString)

        Catch ex As Exception

        End Try
    End Sub

End Class
