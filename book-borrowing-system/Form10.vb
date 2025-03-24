Imports MySql.Data.MySqlClient

Public Class Form10
    Dim connectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub btnAddBook_Click(sender As Object, e As EventArgs) Handles btnAddBook.Click
        If txtBookTitle.Text = "" Or txtAuthor.Text = "" Or txtYear.Text = "" Or txtCategory.Text = "" Or txtCopies.Text = "" Then
            MessageBox.Show("Please fill in all fields before adding the book.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim isbn As String = txtISBN.Text.Trim()
        If String.IsNullOrWhiteSpace(isbn) Then
            Dim result As DialogResult = MessageBox.Show("ISBN is empty. If not applicable, please enter 'N/A'.", "Missing ISBN", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Cancel Then
                Exit Sub
            Else
                txtISBN.Text = "N/A"
                isbn = "N/A"
            End If
        End If

        Dim title As String = txtBookTitle.Text.Trim()
        Dim author As String = txtAuthor.Text.Trim()
        Dim year As String = txtYear.Text.Trim()
        Dim category As String = txtCategory.Text.Trim()

        Dim copies As Integer
        If Not Integer.TryParse(txtCopies.Text.Trim(), copies) OrElse copies <= 0 Then
            MessageBox.Show("Please enter a valid number for copies.", "Invalid Copies", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirmation As DialogResult = MessageBox.Show($"Please review the book details before saving:" & vbCrLf &
                                                       $"Title: {title}" & vbCrLf &
                                                       $"Author: {author}" & vbCrLf &
                                                       $"ISBN: {isbn}" & vbCrLf &
                                                       $"Year: {year}" & vbCrLf &
                                                       $"Category: {category}" & vbCrLf &
                                                       $"Copies: {copies}" & vbCrLf &
                                                       "Do you want to save this book?",
                                                       "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmation <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO book (Title, Author, Year, ISBN, Category, Status, Copies) 
                                   VALUES (@title, @author, @year, @isbn, @category, 'Available', @copies)"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@title", title)
                    cmd.Parameters.AddWithValue("@author", author)
                    cmd.Parameters.AddWithValue("@year", year)
                    cmd.Parameters.AddWithValue("@isbn", isbn)
                    cmd.Parameters.AddWithValue("@category", category)
                    cmd.Parameters.AddWithValue("@copies", copies)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Book added successfully!" & vbCrLf &
                        $"Title: {title}" & vbCrLf &
                        $"Author: {author}" & vbCrLf &
                        $"ISBN: {isbn}" & vbCrLf &
                        $"Year: {year}" & vbCrLf &
                        $"Category: {category}" & vbCrLf &
                        $"Copies: {copies}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim form5 As New Form5
            form5.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim back As New Form5
        back.Show()
        Me.Hide()
    End Sub
End Class
