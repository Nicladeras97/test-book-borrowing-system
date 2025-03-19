Public Class Form11
    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click, Label2.Click, PictureBox4.Click
        Dim borrow As New Form2
        borrow.Show()
        Me.Hide()
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click, Label3.Click, PictureBox5.Click
        Dim returned As New Form3
        returned.Show()
        Me.Hide()
    End Sub
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click, Label4.Click, PictureBox6.Click
        Dim records As New Form4
        records.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim logout As New Form1
        logout.Show()
        Me.Hide()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class
