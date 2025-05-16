<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNames
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNames))
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.lblEarnings = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.LightGray
        Me.txtName.Location = New System.Drawing.Point(51, 50)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(306, 29)
        Me.txtName.TabIndex = 1
        Me.txtName.TabStop = False
        Me.txtName.Text = "<Your Name Here>"
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdSubmit
        '
        Me.cmdSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(51, 133)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(306, 42)
        Me.cmdSubmit.TabIndex = 3
        Me.cmdSubmit.Text = "Submit Name"
        Me.cmdSubmit.UseVisualStyleBackColor = False
        '
        'lblEarnings
        '
        Me.lblEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEarnings.Location = New System.Drawing.Point(16, 9)
        Me.lblEarnings.Name = "lblEarnings"
        Me.lblEarnings.Size = New System.Drawing.Size(376, 33)
        Me.lblEarnings.TabIndex = 6
        Me.lblEarnings.Text = "Your Earnings Are: $000.00"
        Me.lblEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(12, 59)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(380, 33)
        Me.lbl1.TabIndex = 7
        Me.lbl1.Text = "Please remain in your seat quietly."
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl1.Visible = False
        '
        'txtIDNumber
        '
        Me.txtIDNumber.BackColor = System.Drawing.Color.White
        Me.txtIDNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.ForeColor = System.Drawing.Color.LightGray
        Me.txtIDNumber.Location = New System.Drawing.Point(51, 85)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(306, 29)
        Me.txtIDNumber.TabIndex = 2
        Me.txtIDNumber.TabStop = False
        Me.txtIDNumber.Text = "<Your Student ID Number>"
        Me.txtIDNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtIDNumber)
        Me.Controls.Add(Me.lblEarnings)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.lbl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNames"
        Me.Text = "Enter Your Name"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents cmdSubmit As Button
    Friend WithEvents lblEarnings As Label
    Friend WithEvents lbl1 As Label
    Friend WithEvents txtIDNumber As TextBox
End Class
