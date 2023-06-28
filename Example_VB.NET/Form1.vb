Imports TGMT

Public Class Form1

    Dim reader As New CitizenIDReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = reader.Read("cccd.jpg")
    End Sub
End Class
