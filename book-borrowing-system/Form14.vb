Public Class Form14
    Private Sub btnBack_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnBack.LinkClicked
        Dim login As New Form1
        login.Show()
        Me.Hide()
    End Sub
End Class