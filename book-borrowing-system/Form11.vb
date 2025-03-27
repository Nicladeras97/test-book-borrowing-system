Public Class Form11

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim logout As New Form1
        logout.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim shelves As New Form12
        shelves.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim records As New Form4
        records.Show()
        Hide()
    End Sub
End Class
