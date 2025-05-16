Public Class frmNames
    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try
            If txtName.Text = "<Your Name Here>" Then Exit Sub
            If txtName.Text.Trim = "" Then Exit Sub

            Dim str As String = ""

            str = txtName.Text & ";"
            str &= txtIDNumber.Text & ";"

            frmClient.AC.sendMessage("SUBJECT_NAME", str)

            cmdSubmit.Visible = False
            txtName.Visible = False
            txtIDNumber.Visible = False

            lbl1.Visible = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtName_MouseClick(sender As Object, e As MouseEventArgs) Handles txtName.MouseClick
        Try
            If txtName.Text = "<Your Name Here>" Then
                txtName.Text = ""
                txtName.ForeColor = Color.Black
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmdSubmit.Focus()
            Me.AcceptButton = cmdSubmit
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtIDNumber_MouseClick(sender As Object, e As MouseEventArgs) Handles txtIDNumber.MouseClick
        Try
            If txtIDNumber.Text = "<Your Student ID Number>" Then
                txtIDNumber.Text = ""
                txtIDNumber.ForeColor = Color.Black
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class