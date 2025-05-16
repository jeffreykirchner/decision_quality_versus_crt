<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayout))
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtPayPeriod = New System.Windows.Forms.TextBox()
        Me.txtPayTicket = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(73, 19)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(94, 20)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "Pay Period"
        '
        'txtPayPeriod
        '
        Me.txtPayPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayPeriod.Location = New System.Drawing.Point(173, 16)
        Me.txtPayPeriod.Name = "txtPayPeriod"
        Me.txtPayPeriod.Size = New System.Drawing.Size(100, 26)
        Me.txtPayPeriod.TabIndex = 1
        Me.txtPayPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPayTicket
        '
        Me.txtPayTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayTicket.Location = New System.Drawing.Point(173, 48)
        Me.txtPayTicket.Name = "txtPayTicket"
        Me.txtPayTicket.Size = New System.Drawing.Size(100, 26)
        Me.txtPayTicket.TabIndex = 3
        Me.txtPayTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(76, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Pay Ticket"
        '
        'cmdSubmit
        '
        Me.cmdSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(12, 86)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(383, 32)
        Me.cmdSubmit.TabIndex = 4
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = False
        '
        'lbl3
        '
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(279, 19)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(89, 23)
        Me.lbl3.TabIndex = 5
        Me.lbl3.Text = "(1 to N)"
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl4
        '
        Me.lbl4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4.Location = New System.Drawing.Point(279, 51)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(89, 23)
        Me.lbl4.TabIndex = 6
        Me.lbl4.Text = "(1 to N)"
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 130)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl4)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.txtPayTicket)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPayPeriod)
        Me.Controls.Add(Me.lbl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPayout"
        Me.Text = "Payout"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl1 As Label
    Friend WithEvents txtPayPeriod As TextBox
    Friend WithEvents txtPayTicket As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdSubmit As Button
    Friend WithEvents lbl3 As Label
    Friend WithEvents lbl4 As Label
End Class
