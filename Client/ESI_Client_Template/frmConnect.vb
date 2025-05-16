Public Class frmConnect

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        Me.Hide()
        myIPAddress = Me.txtIP.Text
        myPortNumber = txtPort.Text
        frmClient.AC.connect()

        writeINI(sfile, "Settings", "ip", myIPAddress)
        writeINI(sfile, "Settings", "port", txtPort.Text)
    End Sub

    Private Sub frmConnect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIP.Text = getINI(sfile, "Settings", "ip")
        txtPort.Text = getINI(sfile, "Settings", "port")
    End Sub
End Class