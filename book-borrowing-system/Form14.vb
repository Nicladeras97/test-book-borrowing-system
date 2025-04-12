Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

Public Class Form14
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub BtnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        If txtFullName.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()


            Dim checkQuery As String = "SELECT COUNT(*) FROM librarians WHERE Username = @Username"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If userExists > 0 Then
                MessageBox.Show("Username already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                Exit Sub
            End If


            Dim hashedPassword As String = HashPassword(txtPassword.Text)


            Dim query As String = "INSERT INTO librarians (FullName, Username, Password) VALUES (@FullName, @Username, @Password)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", hashedPassword)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            txtFullName.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            txtConfirmPassword.Clear()


            Dim login As New Form1
            login.ShowDialog()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnBack_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnBack.LinkClicked
        Dim back As New Form1
        back.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.Eye_closed
        txtPassword.UseSystemPasswordChar = True
        PictureBox3.Image = My.Resources.Eye_closed
        txtConfirmPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If txtPassword.UseSystemPasswordChar Then
            txtPassword.UseSystemPasswordChar = False
            PictureBox1.Image = My.Resources.eye
        Else
            txtPassword.UseSystemPasswordChar = True
            PictureBox1.Image = My.Resources.Eye_closed
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If txtConfirmPassword.UseSystemPasswordChar Then
            txtConfirmPassword.UseSystemPasswordChar = False
            PictureBox3.Image = My.Resources.eye
        Else
            txtConfirmPassword.UseSystemPasswordChar = True
            PictureBox3.Image = My.Resources.Eye_closed
        End If
    End Sub


End Class