﻿Imports MySql.Data.MySqlClient

Public Class Form2
    Private connString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookAccnos()
        ComboBox1.Focus()
        Button1.Enabled = False
        Button1.ForeColor = Color.White
        Button1.UseVisualStyleBackColor = False
    End Sub

    Private Sub LoadBookAccnos()
        ComboBox1.Items.Clear()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox1.Items.Add(reader("Accno").ToString())
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading Accno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadBookDetails(accno As String)
        If String.IsNullOrWhiteSpace(accno) Then
            ClearLabels()
            Button1.Enabled = False
            Return
        End If

        accno = accno.Trim()

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM books WHERE Accno = @Accno"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", accno)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Label10.Text = reader("Title").ToString()
                        Label12.Text = reader("Author").ToString()
                        Label13.Text = reader("Year").ToString()
                        Label14.Text = reader("Publisher").ToString()
                        Label23.Text = reader("ISBN").ToString()
                        Label15.Text = reader("Section").ToString()
                        Label17.Text = reader("CallNumber").ToString()
                        Label16.Text = reader("Rack").ToString()
                        Button1.Enabled = True
                    Else
                        ClearLabels()
                        Button1.Enabled = False
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving book details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            ValidateAccnoInput()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        ValidateAccnoInput()
    End Sub

    Private Async Sub ValidateAccnoInput()
        Dim accNo As String = ComboBox1.Text.Trim()

        If String.IsNullOrEmpty(accNo) Then
            ClearLabels()
            Button1.Enabled = False
            Return
        End If

        Dim isBorrowed As Boolean = Await IsBookBorrowedAsync(accNo)

        If isBorrowed Then
            MessageBox.Show("This book cannot be deleted because it is either borrowed or under repair.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearLabels()
            Button1.Enabled = False
            Return
        End If

        LoadBookDetails(accNo)
    End Sub

    Private Async Function IsBookBorrowedAsync(accNo As String) As Task(Of Boolean)
        Using conn As New MySqlConnection(connString)
            Try
                Await conn.OpenAsync()
                Dim checkQuery As String = "SELECT 
                                      (SELECT COUNT(*) FROM books_borrowed WHERE book_id = @Accno) +
                                      (SELECT COUNT(*) FROM books_deleted WHERE Accno = @Accno) AS BlockedCount"

                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@Accno", accNo)
                    Dim count As Integer = Convert.ToInt32(Await cmd.ExecuteScalarAsync())
                    Return count > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Error checking book status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End Try
        End Using
    End Function

    Private Sub ClearLabels()
        Label10.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label23.Text = ""
        Label15.Text = ""
        Label17.Text = ""
        Label16.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.ForeColor = Color.White
        Button1.UseVisualStyleBackColor = False

        Dim selectedAccNo As String = ComboBox1.Text.Trim().Replace(vbCr, "").Replace(vbLf, "")

        If String.IsNullOrWhiteSpace(selectedAccNo) Then
            MessageBox.Show("Please select an Accno to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim deleteQuery As String = "DELETE FROM books WHERE Accno = @Accno"
                Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                    deleteCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    deleteCmd.ExecuteNonQuery()
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Dim back As New Form15
                back.ShowDialog()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error deleting book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cancel As New Form15
        cancel.ShowDialog()
        Me.Hide()
    End Sub
End Class
