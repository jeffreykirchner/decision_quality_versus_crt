<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetup1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup1))
        Me.cmdSaveAndClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumberOfPlayers = New System.Windows.Forms.TextBox()
        Me.txtNumberOfPeriods = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPortNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInstructionY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInstructionX = New System.Windows.Forms.TextBox()
        Me.txtWindowX = New System.Windows.Forms.TextBox()
        Me.txtWindowY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbShowInstructions = New System.Windows.Forms.CheckBox()
        Me.txtSecondPriceStartingCash = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbTestMode = New System.Windows.Forms.CheckBox()
        Me.txtLotteryTicketCount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEnglishStartingCash = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEnglishTickRate = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEnglishStartPrice = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEnglishEndPrice = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEnglishEndScale = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEnglishStartScale = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSecondPriceMaxBid = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtQuizQuestionValue = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.rbFull = New System.Windows.Forms.RadioButton()
        Me.rbDropout = New System.Windows.Forms.RadioButton()
        Me.txtEnglishStartDelay = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPracticePeriods = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbFirst = New System.Windows.Forms.RadioButton()
        Me.rbSecond = New System.Windows.Forms.RadioButton()
        Me.txtEnglishTickRatePV = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEnglishTickAmountPV = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbShowEnglishPVSecondPriceProfit = New System.Windows.Forms.CheckBox()
        Me.txtLotteryPeriodLength = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbEnableChatBot = New System.Windows.Forms.CheckBox()
        Me.txtReadyToGoOnTime = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSaveAndClose
        '
        Me.cmdSaveAndClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveAndClose.Location = New System.Drawing.Point(635, 444)
        Me.cmdSaveAndClose.Name = "cmdSaveAndClose"
        Me.cmdSaveAndClose.Size = New System.Drawing.Size(276, 31)
        Me.cmdSaveAndClose.TabIndex = 0
        Me.cmdSaveAndClose.Text = "Save and Close"
        Me.cmdSaveAndClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(331, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of Players (30 Max)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNumberOfPlayers
        '
        Me.txtNumberOfPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfPlayers.Location = New System.Drawing.Point(349, 13)
        Me.txtNumberOfPlayers.Name = "txtNumberOfPlayers"
        Me.txtNumberOfPlayers.Size = New System.Drawing.Size(162, 26)
        Me.txtNumberOfPlayers.TabIndex = 2
        Me.txtNumberOfPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumberOfPeriods
        '
        Me.txtNumberOfPeriods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfPeriods.Location = New System.Drawing.Point(349, 45)
        Me.txtNumberOfPeriods.Name = "txtNumberOfPeriods"
        Me.txtNumberOfPeriods.Size = New System.Drawing.Size(162, 26)
        Me.txtNumberOfPeriods.TabIndex = 4
        Me.txtNumberOfPeriods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(331, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Number of Periods"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPortNumber
        '
        Me.txtPortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPortNumber.Location = New System.Drawing.Point(349, 77)
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(162, 26)
        Me.txtPortNumber.TabIndex = 6
        Me.txtPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(331, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Port # (Requires restart)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInstructionY
        '
        Me.txtInstructionY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionY.Location = New System.Drawing.Point(457, 109)
        Me.txtInstructionY.Name = "txtInstructionY"
        Me.txtInstructionY.Size = New System.Drawing.Size(54, 26)
        Me.txtInstructionY.TabIndex = 8
        Me.txtInstructionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(331, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Instruction Start Position"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(432, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Y"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "X"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInstructionX
        '
        Me.txtInstructionX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionX.Location = New System.Drawing.Point(367, 108)
        Me.txtInstructionX.Name = "txtInstructionX"
        Me.txtInstructionX.Size = New System.Drawing.Size(54, 26)
        Me.txtInstructionX.TabIndex = 10
        Me.txtInstructionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWindowX
        '
        Me.txtWindowX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowX.Location = New System.Drawing.Point(367, 140)
        Me.txtWindowX.Name = "txtWindowX"
        Me.txtWindowX.Size = New System.Drawing.Size(54, 26)
        Me.txtWindowX.TabIndex = 15
        Me.txtWindowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWindowY
        '
        Me.txtWindowY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowY.Location = New System.Drawing.Point(457, 141)
        Me.txtWindowY.Name = "txtWindowY"
        Me.txtWindowY.Size = New System.Drawing.Size(54, 26)
        Me.txtWindowY.TabIndex = 13
        Me.txtWindowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(342, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 23)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "X"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(432, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Y"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(331, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Main Window Start Position"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbShowInstructions
        '
        Me.cbShowInstructions.AutoSize = True
        Me.cbShowInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowInstructions.Location = New System.Drawing.Point(813, 413)
        Me.cbShowInstructions.Name = "cbShowInstructions"
        Me.cbShowInstructions.Size = New System.Drawing.Size(172, 24)
        Me.cbShowInstructions.TabIndex = 17
        Me.cbShowInstructions.Text = "Show Instructions"
        Me.cbShowInstructions.UseVisualStyleBackColor = True
        '
        'txtSecondPriceStartingCash
        '
        Me.txtSecondPriceStartingCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecondPriceStartingCash.Location = New System.Drawing.Point(349, 173)
        Me.txtSecondPriceStartingCash.Name = "txtSecondPriceStartingCash"
        Me.txtSecondPriceStartingCash.Size = New System.Drawing.Size(162, 26)
        Me.txtSecondPriceStartingCash.TabIndex = 19
        Me.txtSecondPriceStartingCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(331, 23)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Second Price, English Starting Cash ($)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbTestMode
        '
        Me.cbTestMode.AutoSize = True
        Me.cbTestMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTestMode.Location = New System.Drawing.Point(622, 413)
        Me.cbTestMode.Name = "cbTestMode"
        Me.cbTestMode.Size = New System.Drawing.Size(112, 24)
        Me.cbTestMode.TabIndex = 20
        Me.cbTestMode.Text = "Test Mode"
        Me.cbTestMode.UseVisualStyleBackColor = True
        '
        'txtLotteryTicketCount
        '
        Me.txtLotteryTicketCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotteryTicketCount.Location = New System.Drawing.Point(349, 301)
        Me.txtLotteryTicketCount.Name = "txtLotteryTicketCount"
        Me.txtLotteryTicketCount.Size = New System.Drawing.Size(162, 26)
        Me.txtLotteryTicketCount.TabIndex = 22
        Me.txtLotteryTicketCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 303)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(331, 23)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Lottery Ticket Count"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishStartingCash
        '
        Me.txtEnglishStartingCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishStartingCash.Location = New System.Drawing.Point(825, 12)
        Me.txtEnglishStartingCash.Name = "txtEnglishStartingCash"
        Me.txtEnglishStartingCash.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishStartingCash.TabIndex = 24
        Me.txtEnglishStartingCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(530, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(289, 23)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Common Value Starting Cash ($)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishTickRate
        '
        Me.txtEnglishTickRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishTickRate.Location = New System.Drawing.Point(825, 44)
        Me.txtEnglishTickRate.Name = "txtEnglishTickRate"
        Me.txtEnglishTickRate.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishTickRate.TabIndex = 26
        Me.txtEnglishTickRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(530, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(289, 23)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Common Value Tick Rate (ms)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishStartPrice
        '
        Me.txtEnglishStartPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishStartPrice.Location = New System.Drawing.Point(825, 76)
        Me.txtEnglishStartPrice.Name = "txtEnglishStartPrice"
        Me.txtEnglishStartPrice.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishStartPrice.TabIndex = 30
        Me.txtEnglishStartPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(530, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(289, 23)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Common Value Start Price ($)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishEndPrice
        '
        Me.txtEnglishEndPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishEndPrice.Location = New System.Drawing.Point(825, 108)
        Me.txtEnglishEndPrice.Name = "txtEnglishEndPrice"
        Me.txtEnglishEndPrice.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishEndPrice.TabIndex = 32
        Me.txtEnglishEndPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(530, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(289, 23)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Common Value End Price ($)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishEndScale
        '
        Me.txtEnglishEndScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishEndScale.Location = New System.Drawing.Point(825, 172)
        Me.txtEnglishEndScale.Name = "txtEnglishEndScale"
        Me.txtEnglishEndScale.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishEndScale.TabIndex = 36
        Me.txtEnglishEndScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(530, 174)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(289, 23)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Common Value Scale End ($)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishStartScale
        '
        Me.txtEnglishStartScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishStartScale.Location = New System.Drawing.Point(825, 140)
        Me.txtEnglishStartScale.Name = "txtEnglishStartScale"
        Me.txtEnglishStartScale.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishStartScale.TabIndex = 34
        Me.txtEnglishStartScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(530, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(289, 23)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Common Value Scale Start ($)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSecondPriceMaxBid
        '
        Me.txtSecondPriceMaxBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecondPriceMaxBid.Location = New System.Drawing.Point(349, 205)
        Me.txtSecondPriceMaxBid.Name = "txtSecondPriceMaxBid"
        Me.txtSecondPriceMaxBid.Size = New System.Drawing.Size(162, 26)
        Me.txtSecondPriceMaxBid.TabIndex = 38
        Me.txtSecondPriceMaxBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 207)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(331, 23)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Second Price, English Max Bid ($)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQuizQuestionValue
        '
        Me.txtQuizQuestionValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuizQuestionValue.Location = New System.Drawing.Point(349, 367)
        Me.txtQuizQuestionValue.Name = "txtQuizQuestionValue"
        Me.txtQuizQuestionValue.Size = New System.Drawing.Size(162, 26)
        Me.txtQuizQuestionValue.TabIndex = 40
        Me.txtQuizQuestionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 370)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(331, 23)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Quiz Question Value ($)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(530, 203)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(289, 23)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "Common Value Bid Mode"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbFull
        '
        Me.rbFull.AutoSize = True
        Me.rbFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFull.Location = New System.Drawing.Point(3, 1)
        Me.rbFull.Name = "rbFull"
        Me.rbFull.Size = New System.Drawing.Size(83, 24)
        Me.rbFull.TabIndex = 42
        Me.rbFull.TabStop = True
        Me.rbFull.Text = "Sealed"
        Me.rbFull.UseVisualStyleBackColor = True
        '
        'rbDropout
        '
        Me.rbDropout.AutoSize = True
        Me.rbDropout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDropout.Location = New System.Drawing.Point(89, 1)
        Me.rbDropout.Name = "rbDropout"
        Me.rbDropout.Size = New System.Drawing.Size(71, 24)
        Me.rbDropout.TabIndex = 43
        Me.rbDropout.TabStop = True
        Me.rbDropout.Text = "Clock"
        Me.rbDropout.UseVisualStyleBackColor = True
        '
        'txtEnglishStartDelay
        '
        Me.txtEnglishStartDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishStartDelay.Location = New System.Drawing.Point(825, 267)
        Me.txtEnglishStartDelay.Name = "txtEnglishStartDelay"
        Me.txtEnglishStartDelay.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishStartDelay.TabIndex = 45
        Me.txtEnglishStartDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(530, 269)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(289, 23)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Common Value Start Delay (sec)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPracticePeriods
        '
        Me.txtPracticePeriods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPracticePeriods.Location = New System.Drawing.Point(350, 399)
        Me.txtPracticePeriods.Name = "txtPracticePeriods"
        Me.txtPracticePeriods.Size = New System.Drawing.Size(162, 26)
        Me.txtPracticePeriods.TabIndex = 47
        Me.txtPracticePeriods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(331, 23)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Practice Periods"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(531, 236)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(289, 23)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "Common Value Sealed Price Mode"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbFull)
        Me.Panel1.Controls.Add(Me.rbDropout)
        Me.Panel1.Location = New System.Drawing.Point(825, 203)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(172, 26)
        Me.Panel1.TabIndex = 49
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbFirst)
        Me.Panel2.Controls.Add(Me.rbSecond)
        Me.Panel2.Location = New System.Drawing.Point(825, 235)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(172, 26)
        Me.Panel2.TabIndex = 50
        '
        'rbFirst
        '
        Me.rbFirst.AutoSize = True
        Me.rbFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFirst.Location = New System.Drawing.Point(3, 1)
        Me.rbFirst.Name = "rbFirst"
        Me.rbFirst.Size = New System.Drawing.Size(63, 24)
        Me.rbFirst.TabIndex = 42
        Me.rbFirst.TabStop = True
        Me.rbFirst.Text = "First"
        Me.rbFirst.UseVisualStyleBackColor = True
        '
        'rbSecond
        '
        Me.rbSecond.AutoSize = True
        Me.rbSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSecond.Location = New System.Drawing.Point(77, 1)
        Me.rbSecond.Name = "rbSecond"
        Me.rbSecond.Size = New System.Drawing.Size(88, 24)
        Me.rbSecond.TabIndex = 43
        Me.rbSecond.TabStop = True
        Me.rbSecond.Text = "Second"
        Me.rbSecond.UseVisualStyleBackColor = True
        '
        'txtEnglishTickRatePV
        '
        Me.txtEnglishTickRatePV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishTickRatePV.Location = New System.Drawing.Point(349, 237)
        Me.txtEnglishTickRatePV.Name = "txtEnglishTickRatePV"
        Me.txtEnglishTickRatePV.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishTickRatePV.TabIndex = 52
        Me.txtEnglishTickRatePV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 239)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(331, 23)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "English Tick Rate(ms)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnglishTickAmountPV
        '
        Me.txtEnglishTickAmountPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnglishTickAmountPV.Location = New System.Drawing.Point(349, 269)
        Me.txtEnglishTickAmountPV.Name = "txtEnglishTickAmountPV"
        Me.txtEnglishTickAmountPV.Size = New System.Drawing.Size(162, 26)
        Me.txtEnglishTickAmountPV.TabIndex = 54
        Me.txtEnglishTickAmountPV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 271)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(331, 23)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "English Tick Amount ($)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbShowEnglishPVSecondPriceProfit
        '
        Me.cbShowEnglishPVSecondPriceProfit.AutoSize = True
        Me.cbShowEnglishPVSecondPriceProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowEnglishPVSecondPriceProfit.Location = New System.Drawing.Point(622, 353)
        Me.cbShowEnglishPVSecondPriceProfit.Name = "cbShowEnglishPVSecondPriceProfit"
        Me.cbShowEnglishPVSecondPriceProfit.Size = New System.Drawing.Size(300, 24)
        Me.cbShowEnglishPVSecondPriceProfit.TabIndex = 55
        Me.cbShowEnglishPVSecondPriceProfit.Text = "Show Second Price, English Profit"
        Me.cbShowEnglishPVSecondPriceProfit.UseVisualStyleBackColor = True
        '
        'txtLotteryPeriodLength
        '
        Me.txtLotteryPeriodLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotteryPeriodLength.Location = New System.Drawing.Point(350, 333)
        Me.txtLotteryPeriodLength.Name = "txtLotteryPeriodLength"
        Me.txtLotteryPeriodLength.Size = New System.Drawing.Size(162, 26)
        Me.txtLotteryPeriodLength.TabIndex = 57
        Me.txtLotteryPeriodLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(13, 335)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(331, 23)
        Me.Label26.TabIndex = 56
        Me.Label26.Text = "Lottery Period Length"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbEnableChatBot
        '
        Me.cbEnableChatBot.AutoSize = True
        Me.cbEnableChatBot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnableChatBot.Location = New System.Drawing.Point(622, 383)
        Me.cbEnableChatBot.Name = "cbEnableChatBot"
        Me.cbEnableChatBot.Size = New System.Drawing.Size(160, 24)
        Me.cbEnableChatBot.TabIndex = 58
        Me.cbEnableChatBot.Text = "Enable Chat Bot"
        Me.cbEnableChatBot.UseVisualStyleBackColor = True
        '
        'txtReadyToGoOnTime
        '
        Me.txtReadyToGoOnTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReadyToGoOnTime.Location = New System.Drawing.Point(825, 299)
        Me.txtReadyToGoOnTime.Name = "txtReadyToGoOnTime"
        Me.txtReadyToGoOnTime.Size = New System.Drawing.Size(162, 26)
        Me.txtReadyToGoOnTime.TabIndex = 60
        Me.txtReadyToGoOnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(530, 301)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(289, 23)
        Me.Label27.TabIndex = 59
        Me.Label27.Text = "Ready to Go On Timer (sec)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSetup1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtReadyToGoOnTime)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cbEnableChatBot)
        Me.Controls.Add(Me.txtLotteryPeriodLength)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cbShowEnglishPVSecondPriceProfit)
        Me.Controls.Add(Me.txtEnglishTickAmountPV)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtEnglishTickRatePV)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtPracticePeriods)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtEnglishStartDelay)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtQuizQuestionValue)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtSecondPriceMaxBid)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtEnglishEndScale)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtEnglishStartScale)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtEnglishEndPrice)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtEnglishStartPrice)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtEnglishTickRate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtEnglishStartingCash)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLotteryTicketCount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbTestMode)
        Me.Controls.Add(Me.txtSecondPriceStartingCash)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbShowInstructions)
        Me.Controls.Add(Me.txtWindowX)
        Me.Controls.Add(Me.txtWindowY)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtInstructionX)
        Me.Controls.Add(Me.txtInstructionY)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPortNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumberOfPeriods)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumberOfPlayers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSaveAndClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSetup1"
        Me.Text = "Experiment Setup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSaveAndClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumberOfPlayers As TextBox
    Friend WithEvents txtNumberOfPeriods As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPortNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInstructionY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtInstructionX As TextBox
    Friend WithEvents txtWindowX As TextBox
    Friend WithEvents txtWindowY As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cbShowInstructions As CheckBox
    Friend WithEvents txtSecondPriceStartingCash As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbTestMode As CheckBox
    Friend WithEvents txtLotteryTicketCount As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEnglishStartingCash As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtEnglishTickRate As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEnglishStartPrice As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtEnglishEndPrice As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEnglishEndScale As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtEnglishStartScale As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtSecondPriceMaxBid As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtQuizQuestionValue As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents rbFull As RadioButton
    Friend WithEvents rbDropout As RadioButton
    Friend WithEvents txtEnglishStartDelay As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPracticePeriods As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbFirst As RadioButton
    Friend WithEvents rbSecond As RadioButton
    Friend WithEvents txtEnglishTickRatePV As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtEnglishTickAmountPV As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cbShowEnglishPVSecondPriceProfit As CheckBox
    Friend WithEvents txtLotteryPeriodLength As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cbEnableChatBot As CheckBox
    Friend WithEvents txtReadyToGoOnTime As TextBox
    Friend WithEvents Label27 As Label
End Class
