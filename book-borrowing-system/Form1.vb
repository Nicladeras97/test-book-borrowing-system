Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        conn = New MySqlConnection("server=localhost; user=root; password=; database=borrowing-system;")

        Try
            conn.Open()
            Dim query As String = "SELECT * FROM login WHERE Username=@Username AND Pass=@Pass"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text)
            cmd.Parameters.AddWithValue("@pass", PasswordTextBox.Text)

            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                MsgBox("Login Successful!", MsgBoxStyle.Information)

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

End Class

