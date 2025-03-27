Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form10
    Public Property BookID As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse  ' Title
           String.IsNullOrWhiteSpace(TextBox9.Text) OrElse  ' ISBN
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse  ' Author
           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse  ' Year
           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse  ' Section
           String.IsNullOrWhiteSpace(TextBox6.Text) OrElse  ' Copies
           String.IsNullOrWhiteSpace(TextBox1.Text) OrElse  ' Call Number
           String.IsNullOrWhiteSpace(TextBox2.Text) OrElse  ' Rack
           String.IsNullOrWhiteSpace(TextBox9.Text) Then    ' ISBN

            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim title As String = TextBox3.Text.Trim()
        Dim author As String = TextBox4.Text.Trim()
        Dim year As String = TextBox8.Text.Trim()
        Dim section As String = TextBox7.Text.Trim()
        Dim status As String = "Available"
        Dim copies As Integer
        Dim isbn As String = TextBox9.Text.Trim()

        If Not Integer.TryParse(TextBox6.Text.Trim(), copies) OrElse copies <= 0 Then
            MessageBox.Show("Invalid copies value. Must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim callNumber As String = TextBox1.Text.Trim()
        Dim rack As String = TextBox2.Text.Trim()

        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim bookID As String = GenerateNextBookID(conn, section, year)

                Dim query As String = "
                    INSERT INTO book (BookID, ISBN, Title, Author, Year, Section, Status, Copies, CallNumber, Rack, AddedDate, Publisher) 
                    VALUES (@BookID, @ISBN, @Title, @Author, @Year, @Section, @Status, @Copies, @CallNumber, @Rack, @AddedDate, @Publisher)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Author", author)
                    cmd.Parameters.AddWithValue("@Year", year)
                    cmd.Parameters.AddWithValue("@Section", section)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@Copies", copies)
                    cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                    cmd.Parameters.AddWithValue("@Rack", rack)
                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@Publisher", "Unknown")

                    cmd.ExecuteNonQuery()
                End Using

                For i As Integer = 1 To copies
                    Dim copyID As String = $"{bookID}-{i:D2}"

                    Dim copyQuery As String = "
                        INSERT INTO copies (CopyID, BookID, ISBN, Status) 
                        VALUES (@CopyID, @BookID, @ISBN, 'Available')"

                    Using cmd As New MySqlCommand(copyQuery, conn)
                        cmd.Parameters.AddWithValue("@CopyID", copyID)
                        cmd.Parameters.AddWithValue("@BookID", bookID)
                        cmd.Parameters.AddWithValue("@ISBN", isbn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show($"Book {bookID} and {copies} copies added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim form5 As New Form5
                form5.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function GenerateNextBookID(conn As MySqlConnection, section As String, year As String) As String
        Dim prefix As String = section.Substring(0, Math.Min(3, section.Length)).ToUpper() & year

        Dim query As String = $"SELECT MAX(BookID) FROM book WHERE BookID LIKE '{prefix}%'"

        Using cmd As New MySqlCommand(query, conn)
            Dim lastID As Object = cmd.ExecuteScalar()

            Dim nextNumber As Integer = 1
            If lastID IsNot DBNull.Value AndAlso lastID IsNot Nothing AndAlso lastID.ToString().Length >= 7 Then
                Dim lastNumber As String = lastID.ToString().Substring(7, 4)
                If Integer.TryParse(lastNumber, nextNumber) Then
                    nextNumber += 1
                End If
            End If

            Return $"{prefix}{nextNumber:0000}"
        End Using
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form5 As New Form5
        form5.Show()
        Me.Hide()
    End Sub
End Class
