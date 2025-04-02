Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
    Dim cmd As MySqlCommand

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Form14.Show()
        Me.Hide()
        Try
            conn.Open()

            Dim query As String = "SELECT Password FROM librarians WHERE Username=@Username"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim storedHash As Object = cmd.ExecuteScalar()

            If storedHash IsNot Nothing Then

                Dim enteredHash As String = ComputeSHA256(PasswordTextBox.Text)


                If storedHash.ToString() = enteredHash Then
                    Form4.Show()
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
        Dim hashBytes As Byte() = SHA256.HashData(Encoding.UTF8.GetBytes(password))
        Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
    End Function


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form14.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim barcode As New Form3
        barcode.Show()
    End Sub
End Class
