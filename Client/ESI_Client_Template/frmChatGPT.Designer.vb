<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChatGPT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChatGPT))
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.textResponse = New System.Windows.Forms.TextBox()
        Me.textPrompt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(300, 352)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(191, 76)
        Me.cmdSend.TabIndex = 0
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'textResponse
        '
        Me.textResponse.Location = New System.Drawing.Point(12, 12)
        Me.textResponse.Multiline = True
        Me.textResponse.Name = "textResponse"
        Me.textResponse.Size = New System.Drawing.Size(736, 257)
        Me.textResponse.TabIndex = 1
        '
        'textPrompt
        '
        Me.textPrompt.Location = New System.Drawing.Point(12, 314)
        Me.textPrompt.Name = "textPrompt"
        Me.textPrompt.Size = New System.Drawing.Size(736, 20)
        Me.textPrompt.TabIndex = 2
        Me.textPrompt.Text = "why did the chicken cross the road?"
        '
        'frmChatGPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 461)
        Me.Controls.Add(Me.textPrompt)
        Me.Controls.Add(Me.textResponse)
        Me.Controls.Add(Me.cmdSend)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChatGPT"
        Me.Text = "frmChatGPT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSend As Button
    Friend WithEvents textResponse As TextBox
    Friend WithEvents textPrompt As TextBox
End Class
