Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1

    Dim cmd As MySqlCommand

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Try
            conn.Open()

            ' Query to get stored hashed password
            Dim query As String = "SELECT Password FROM librarians WHERE Username=@Username"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim storedHash As Object = cmd.ExecuteScalar()

            If storedHash IsNot Nothing Then
                ' Compute hash of entered password
                Dim enteredHash As String = ComputeSHA256(PasswordTextBox.Text)

                ' Compare stored hash with entered hash
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
            ' Ensure connection is closed properly
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' Function to hash password using SHA-256
    Private Function ComputeSHA256(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower()
        End Using
    End Function

End Class