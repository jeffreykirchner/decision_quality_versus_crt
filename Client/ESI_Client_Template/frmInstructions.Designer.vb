<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstructions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstructions))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.gbQuiz = New System.Windows.Forms.GroupBox()
        Me.cmdSubmitQuiz = New System.Windows.Forms.Button()
        Me.txtQuiz = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.gbQuiz.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RichTextBox1.Size = New System.Drawing.Size(408, 581)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(333, 670)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(87, 35)
        Me.cmdNext.TabIndex = 1
        Me.cmdNext.Text = "Next >>"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(12, 670)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(87, 35)
        Me.cmdBack.TabIndex = 2
        Me.cmdBack.Text = "<< Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        Me.cmdBack.Visible = False
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.Location = New System.Drawing.Point(173, 670)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(87, 35)
        Me.cmdStart.TabIndex = 3
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = False
        Me.cmdStart.Visible = False
        '
        'gbQuiz
        '
        Me.gbQuiz.Controls.Add(Me.cmdSubmitQuiz)
        Me.gbQuiz.Controls.Add(Me.txtQuiz)
        Me.gbQuiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbQuiz.Location = New System.Drawing.Point(12, 599)
        Me.gbQuiz.Name = "gbQuiz"
        Me.gbQuiz.Size = New System.Drawing.Size(408, 65)
        Me.gbQuiz.TabIndex = 4
        Me.gbQuiz.TabStop = False
        Me.gbQuiz.Text = "Quiz Answer"
        Me.gbQuiz.Visible = False
        '
        'cmdSubmitQuiz
        '
        Me.cmdSubmitQuiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmitQuiz.Location = New System.Drawing.Point(321, 22)
        Me.cmdSubmitQuiz.Name = "cmdSubmitQuiz"
        Me.cmdSubmitQuiz.Size = New System.Drawing.Size(81, 29)
        Me.cmdSubmitQuiz.TabIndex = 6
        Me.cmdSubmitQuiz.Text = "Submit"
        Me.cmdSubmitQuiz.UseVisualStyleBackColor = True
        '
        'txtQuiz
        '
        Me.txtQuiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuiz.Location = New System.Drawing.Point(6, 22)
        Me.txtQuiz.Name = "txtQuiz"
        Me.txtQuiz.Size = New System.Drawing.Size(308, 29)
        Me.txtQuiz.TabIndex = 5
        Me.txtQuiz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'frmInstructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 716)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbQuiz)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInstructions"
        Me.Text = "Instructions"
        Me.TopMost = True
        Me.gbQuiz.ResumeLayout(False)
        Me.gbQuiz.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents cmdNext As Button
    Friend WithEvents cmdBack As Button
    Friend WithEvents cmdStart As Button
    Friend WithEvents gbQuiz As GroupBox
    Friend WithEvents txtQuiz As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmdSubmitQuiz As Button
    Friend WithEvents Timer2 As Timer
End Class
