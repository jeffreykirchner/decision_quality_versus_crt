<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnglish
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnglish))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdReadyToGoOn = New System.Windows.Forms.Button()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gb2 = New System.Windows.Forms.GroupBox()
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.cmdUpdateBid = New System.Windows.Forms.Button()
        Me.txtNewBid = New System.Windows.Forms.TextBox()
        Me.cmdDontBuy = New System.Windows.Forms.Button()
        Me.pnlKeyValue = New System.Windows.Forms.Panel()
        Me.lblKeyValue = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBid = New System.Windows.Forms.Label()
        Me.pnlMarketPrice = New System.Windows.Forms.Panel()
        Me.lblMarketPrice = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblValueInterval = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlRange = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.gb1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb2.SuspendLayout()
        Me.pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.Label11)
        Me.gb1.Controls.Add(Me.Panel2)
        Me.gb1.Controls.Add(Me.cmdReadyToGoOn)
        Me.gb1.Controls.Add(Me.dg1)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.txtCash)
        Me.gb1.Controls.Add(Me.Label10)
        Me.gb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.Location = New System.Drawing.Point(10, 540)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(1216, 267)
        Me.gb1.TabIndex = 59
        Me.gb1.TabStop = False
        Me.gb1.Text = "Results"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1115, 219)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 21)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "My Bids"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Green
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(1086, 215)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(23, 25)
        Me.Panel2.TabIndex = 49
        '
        'cmdReadyToGoOn
        '
        Me.cmdReadyToGoOn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdReadyToGoOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReadyToGoOn.Location = New System.Drawing.Point(22, 205)
        Me.cmdReadyToGoOn.Name = "cmdReadyToGoOn"
        Me.cmdReadyToGoOn.Size = New System.Drawing.Size(192, 48)
        Me.cmdReadyToGoOn.TabIndex = 48
        Me.cmdReadyToGoOn.Text = "Ready to Go On"
        Me.cmdReadyToGoOn.UseVisualStyleBackColor = False
        Me.cmdReadyToGoOn.Visible = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeColumns = False
        Me.dg1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dg1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.ColumnHeadersHeight = 40
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column3, Me.Column6, Me.Column4, Me.Column7, Me.Column2})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg1.Location = New System.Drawing.Point(16, 25)
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersVisible = False
        Me.dg1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg1.Size = New System.Drawing.Size(1194, 174)
        Me.dg1.TabIndex = 47
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Period"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 59
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Winner?"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 69
        '
        'Column3
        '
        Me.Column3.FillWeight = 70.0!
        Me.Column3.HeaderText = "Actual Value"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 60
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Price"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 49
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Profit"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 49
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 10
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Winning Bid/Signal"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 125
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(482, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 26)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Cash Balance ($)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCash
        '
        Me.txtCash.BackColor = System.Drawing.Color.White
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.Location = New System.Drawing.Point(654, 205)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.ReadOnly = True
        Me.txtCash.Size = New System.Drawing.Size(83, 29)
        Me.txtCash.TabIndex = 44
        Me.txtCash.TabStop = False
        Me.txtCash.Text = "888.00"
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(411, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(404, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "If your Cash Balance is less than zero you may not bid." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gb2
        '
        Me.gb2.Controls.Add(Me.pnl1)
        Me.gb2.Controls.Add(Me.cmdDontBuy)
        Me.gb2.Controls.Add(Me.pnlKeyValue)
        Me.gb2.Controls.Add(Me.lblKeyValue)
        Me.gb2.Controls.Add(Me.Panel5)
        Me.gb2.Controls.Add(Me.lblBid)
        Me.gb2.Controls.Add(Me.pnlMarketPrice)
        Me.gb2.Controls.Add(Me.lblMarketPrice)
        Me.gb2.Controls.Add(Me.Panel3)
        Me.gb2.Controls.Add(Me.lblValueInterval)
        Me.gb2.Controls.Add(Me.Panel1)
        Me.gb2.Controls.Add(Me.pnlRange)
        Me.gb2.Controls.Add(Me.Label8)
        Me.gb2.Controls.Add(Me.Label6)
        Me.gb2.Controls.Add(Me.lbl1)
        Me.gb2.Controls.Add(Me.txtInfo)
        Me.gb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb2.Location = New System.Drawing.Point(10, 12)
        Me.gb2.Name = "gb2"
        Me.gb2.Size = New System.Drawing.Size(1216, 522)
        Me.gb2.TabIndex = 60
        Me.gb2.TabStop = False
        Me.gb2.Text = "Market Dashboard"
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.cmdUpdateBid)
        Me.pnl1.Controls.Add(Me.txtNewBid)
        Me.pnl1.Location = New System.Drawing.Point(285, 329)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(646, 186)
        Me.pnl1.TabIndex = 62
        '
        'cmdUpdateBid
        '
        Me.cmdUpdateBid.BackColor = System.Drawing.Color.Teal
        Me.cmdUpdateBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateBid.ForeColor = System.Drawing.Color.White
        Me.cmdUpdateBid.Location = New System.Drawing.Point(189, 78)
        Me.cmdUpdateBid.Name = "cmdUpdateBid"
        Me.cmdUpdateBid.Size = New System.Drawing.Size(252, 55)
        Me.cmdUpdateBid.TabIndex = 40
        Me.cmdUpdateBid.Text = "Submit Bid"
        Me.cmdUpdateBid.UseVisualStyleBackColor = False
        '
        'txtNewBid
        '
        Me.txtNewBid.BackColor = System.Drawing.Color.White
        Me.txtNewBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewBid.Location = New System.Drawing.Point(252, 34)
        Me.txtNewBid.Name = "txtNewBid"
        Me.txtNewBid.Size = New System.Drawing.Size(136, 35)
        Me.txtNewBid.TabIndex = 31
        Me.txtNewBid.TabStop = False
        Me.txtNewBid.Text = "888.00"
        Me.txtNewBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdDontBuy
        '
        Me.cmdDontBuy.BackColor = System.Drawing.Color.Teal
        Me.cmdDontBuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDontBuy.ForeColor = System.Drawing.Color.White
        Me.cmdDontBuy.Location = New System.Drawing.Point(16, 366)
        Me.cmdDontBuy.Name = "cmdDontBuy"
        Me.cmdDontBuy.Size = New System.Drawing.Size(341, 88)
        Me.cmdDontBuy.TabIndex = 74
        Me.cmdDontBuy.Text = "Do Not Buy"
        Me.cmdDontBuy.UseVisualStyleBackColor = False
        Me.cmdDontBuy.Visible = False
        '
        'pnlKeyValue
        '
        Me.pnlKeyValue.BackColor = System.Drawing.Color.Gold
        Me.pnlKeyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKeyValue.Location = New System.Drawing.Point(527, 296)
        Me.pnlKeyValue.Name = "pnlKeyValue"
        Me.pnlKeyValue.Size = New System.Drawing.Size(26, 25)
        Me.pnlKeyValue.TabIndex = 73
        Me.pnlKeyValue.Visible = False
        '
        'lblKeyValue
        '
        Me.lblKeyValue.BackColor = System.Drawing.Color.Transparent
        Me.lblKeyValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyValue.Location = New System.Drawing.Point(556, 296)
        Me.lblKeyValue.Name = "lblKeyValue"
        Me.lblKeyValue.Size = New System.Drawing.Size(221, 25)
        Me.lblKeyValue.TabIndex = 72
        Me.lblKeyValue.Text = "Actual Value ($)"
        Me.lblKeyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblKeyValue.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Teal
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(527, 268)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(26, 25)
        Me.Panel5.TabIndex = 70
        '
        'lblBid
        '
        Me.lblBid.BackColor = System.Drawing.Color.Transparent
        Me.lblBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBid.Location = New System.Drawing.Point(556, 268)
        Me.lblBid.Name = "lblBid"
        Me.lblBid.Size = New System.Drawing.Size(221, 25)
        Me.lblBid.TabIndex = 69
        Me.lblBid.Text = "Your Max Bid ($)"
        Me.lblBid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMarketPrice
        '
        Me.pnlMarketPrice.BackColor = System.Drawing.Color.Crimson
        Me.pnlMarketPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMarketPrice.Location = New System.Drawing.Point(99, 299)
        Me.pnlMarketPrice.Name = "pnlMarketPrice"
        Me.pnlMarketPrice.Size = New System.Drawing.Size(26, 25)
        Me.pnlMarketPrice.TabIndex = 68
        '
        'lblMarketPrice
        '
        Me.lblMarketPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblMarketPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarketPrice.Location = New System.Drawing.Point(135, 299)
        Me.lblMarketPrice.Name = "lblMarketPrice"
        Me.lblMarketPrice.Size = New System.Drawing.Size(300, 25)
        Me.lblMarketPrice.TabIndex = 67
        Me.lblMarketPrice.Text = "The current Market Price ($)"
        Me.lblMarketPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(844, 280)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(26, 25)
        Me.Panel3.TabIndex = 66
        '
        'lblValueInterval
        '
        Me.lblValueInterval.BackColor = System.Drawing.Color.Transparent
        Me.lblValueInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValueInterval.Location = New System.Drawing.Point(872, 273)
        Me.lblValueInterval.Name = "lblValueInterval"
        Me.lblValueInterval.Size = New System.Drawing.Size(262, 38)
        Me.lblValueInterval.TabIndex = 65
        Me.lblValueInterval.Text = "The Actual Value ($) is randomly drawn from this interval each period. "
        Me.lblValueInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(99, 268)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(26, 25)
        Me.Panel1.TabIndex = 64
        '
        'pnlRange
        '
        Me.pnlRange.BackColor = System.Drawing.Color.White
        Me.pnlRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRange.Location = New System.Drawing.Point(6, 71)
        Me.pnlRange.Name = "pnlRange"
        Me.pnlRange.Size = New System.Drawing.Size(1204, 190)
        Me.pnlRange.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(135, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(300, 25)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "The Actual Value ($) is in this interval."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(295, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(627, 30)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "All Signals, including yours, are randomly drawn from the following range:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbl1.Location = New System.Drawing.Point(295, 36)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(627, 30)
        Me.lbl1.TabIndex = 60
        Me.lbl1.Text = "Actual Value minus E to Actual Value plus E"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.Color.White
        Me.txtInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfo.Location = New System.Drawing.Point(6, 390)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(1204, 35)
        Me.txtInfo.TabIndex = 71
        Me.txtInfo.TabStop = False
        Me.txtInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtInfo.Visible = False
        '
        'frmEnglish
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 810)
        Me.ControlBox = False
        Me.Controls.Add(Me.gb2)
        Me.Controls.Add(Me.gb1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmEnglish"
        Me.Text = "Client"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb2.ResumeLayout(False)
        Me.gb2.PerformLayout()
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmdReadyToGoOn As Button
    Friend WithEvents dg1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCash As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents gb2 As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblBid As Label
    Friend WithEvents pnlMarketPrice As Panel
    Friend WithEvents lblMarketPrice As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblValueInterval As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlRange As Panel
    Friend WithEvents pnl1 As Panel
    Friend WithEvents cmdUpdateBid As Button
    Friend WithEvents txtNewBid As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl1 As Label
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents pnlKeyValue As Panel
    Friend WithEvents lblKeyValue As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents cmdDontBuy As Button
End Class
