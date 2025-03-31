Public Class Form4
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim manageBooks As New Form5
        manageBooks.Show()
        Me.Hide()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form11
        back.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim manageUsers As New Form9
        manageUsers.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rep As New Form6
        rep.Show()
        Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim messages As New Report
        messages.Show()
        Me.Hide()
    End Sub
End Class