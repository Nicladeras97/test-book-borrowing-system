Imports MySql.Data.MySqlClient

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

    Private Sub DisplayNotifStatus()
        Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

        Try
            conn.Open()

            Dim query As String = "SELECT COUNT(*) FROM notification WHERE NotifDate >= DATE_SUB(NOW(), INTERVAL 1 MONTH)"
            Dim cmd As New MySqlCommand(query, conn)

            Dim notifCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If notifCount > 0 Then
                Label5.BackColor = Color.Red
                Label5.Visible = True
            Else
                Label5.BackColor = Color.Gray
                Label5.Visible = True
            End If

            Dim path As New Drawing.Drawing2D.GraphicsPath()
            path.AddEllipse(0, 0, Label5.Width, Label5.Height)
            Label5.Region = New Region(path)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayNotifStatus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim notifForm As New Form7()
        notifForm.ShowDialog()

        DisplayNotifStatus()
    End Sub

End Class
