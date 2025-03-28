Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1

    Dim cmd As MySqlCommand
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try
            conn.Open()

            Dim query As String = "SELECT Password FROM librarians WHERE Username=@Username"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim storedHash As Object = cmd.ExecuteScalar()

            If storedHash IsNot Nothing Then
                Dim enteredHash As String = ComputeSHA256(PasswordTextBox.Text)

                If storedHash.ToString() = enteredHash Then
                    Form11.Show()
                    Me.Hide()
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
        Using sha256 As SHA256 = SHA256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class


