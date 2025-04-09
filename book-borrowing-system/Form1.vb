Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
    Dim cmd As MySqlCommand

    Private Async Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try
            conn.Open()

            Dim query As String = "SELECT Password FROM librarians WHERE Username=@Username"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim storedHash As Object = cmd.ExecuteScalar()

            If storedHash IsNot Nothing Then

                Dim enteredHash As String = ComputeSHA256(PasswordTextBox.Text)

                If storedHash.ToString() = enteredHash Then
                    Me.Hide()
                    Await Task.Delay(100)

                    Dim login As New Form15()
                    login.LoggedInUsername = UsernameTextBox.Text
                    login.Show()
                Else
                    MsgBox("Invalid Username or Password!", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Invalid Username or Password!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Function ComputeSHA256(password As String) As String
        Dim hashBytes As Byte() = SHA256.HashData(Encoding.UTF8.GetBytes(password))
        Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim register As New Form14
        register.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox2.Image = My.Resources.Eye_closed
        PasswordTextBox.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If PasswordTextBox.UseSystemPasswordChar Then
            PasswordTextBox.UseSystemPasswordChar = False
            PictureBox2.Image = My.Resources.eye
        Else
            PasswordTextBox.UseSystemPasswordChar = True
            PictureBox2.Image = My.Resources.Eye_closed
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Panel2.BackColor = Color.FromArgb(100, 0, 0, 0)


    End Sub
End Class
