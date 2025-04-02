﻿Imports MySql.Data.MySqlClient
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
        ' Validation: Check if any field is empty
        If txtFullName.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if passwords match
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            ' Check if username already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM librarians WHERE Username = @Username"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If userExists > 0 Then
                MessageBox.Show("Username already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                Exit Sub
            End If

            ' Hash the password before storing it
            Dim hashedPassword As String = HashPassword(txtPassword.Text)

            ' Insert new librarian with hashed password
            Dim query As String = "INSERT INTO librarians (FullName, Username, Password) VALUES (@FullName, @Username, @Password)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", hashedPassword) ' Store hashed password

            cmd.ExecuteNonQuery()
            MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear fields
            txtFullName.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            txtConfirmPassword.Clear()

            ' Redirect to login
            Me.Hide()
            Form1.Show()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form1.Show() ' Assuming Form1 is your login form
    End Sub

End Class