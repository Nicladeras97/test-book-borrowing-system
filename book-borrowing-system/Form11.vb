Imports MySql.Data.MySqlClient

Public Class Form11
    Private Sub Panel2_Click(sender As Object, e As EventArgs)
        Dim borrow As New Form2
        borrow.Show
        Hide
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs)
        Dim returned As New Form3
        returned.Show
        Hide
    End Sub
    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click, Label4.Click
        Dim records As New Form4
        records.Show
        Hide
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim logout As New Form1
        logout.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim shelves As New Form12
        shelves.Show()
        Me.Hide()
    End Sub
End Class
