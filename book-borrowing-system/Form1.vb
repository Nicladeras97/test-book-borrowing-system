Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        conn = New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()
            Dim query As String = "SELECT * FROM librarians WHERE Username=@Username AND Password=@Password"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)
            cmd.Parameters.AddWithValue("@Password", PasswordTextBox.Text)

            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                'MsgBox("Login Successful!", MsgBoxStyle.Information)

                Form11.Show()
                Me.Hide()
            Else
                MsgBox("Invalid Username or Password!", MsgBoxStyle.Critical)
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class