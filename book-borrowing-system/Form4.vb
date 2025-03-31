Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim back As New Form11
        back.Show()
        Hide()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim manageBooks As New Form5
        manageBooks.Show()
        Hide()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form11
        back.Show()
        Me.Hide()
    End Sub

End Class