Public Class frmTestMode
    Private Sub cmd1_Click(sender As Object, e As EventArgs) Handles cmd1.Click
        Try
            If cmd1.Text = "Take Control" Then
                cmd1.Text = "Return Control"

                frmClient.Timer1.Enabled = False
            Else
                cmd1.Text = "Take Control"

                frmClient.Timer1.Enabled = True
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class