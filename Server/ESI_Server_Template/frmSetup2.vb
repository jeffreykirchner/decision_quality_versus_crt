Public Class frmSetup2
    Private Sub frmSetup2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgMain.RowCount = numberOfPeriods

            Dim dgcbc As New DataGridViewComboBoxCell
            dgcbc.Items.Add("Lottery")
            dgcbc.Items.Add("2nd Price")
            dgcbc.Items.Add("CV Full Info")
            dgcbc.Items.Add("CV Limited Info")
            dgcbc.Items.Add("English Auction SL")
            dgcbc.Items.Add("English Auction LS")

            For i As Integer = 1 To numberOfPeriods
                dgMain(0, i - 1).Value = i
                dgMain(1, i - 1) = dgcbc.Clone

                Dim tempV As String = getINI(sfile, "periodSetup", CStr(i))
                If tempV <> "?" Then dgMain(1, i - 1).Value = tempV
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSaveAndClose_Click(sender As Object, e As EventArgs) Handles cmdSaveAndClose.Click
        Try
            For i As Integer = 1 To dgMain.RowCount
                writeINI(sfile, "periodSetup", CStr(i), dgMain(1, i - 1).Value)
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As Object, e As EventArgs) Handles cmdCopyDown.Click
        Try
            For i As Integer = dgMain.CurrentCell.RowIndex + 1 To dgMain.RowCount
                dgMain(1, i - 1).Value = dgMain(1, dgMain.CurrentCell.RowIndex).Value
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class