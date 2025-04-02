Imports MySql.Data.MySqlClient

Public Class Form8
    Dim connString As String = "server=localhost;user id=root;password=;database=book-borrowing"

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBooks()
        LoadBookConditions()
    End Sub

    Private Sub LoadBooks()
        ComboBox2.Items.Clear()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox2.Items.Add(reader("Accno").ToString())
                    End While
                    reader.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading books: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadBookConditions()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT condition_id, condition_status FROM book_condition WHERE condition_id <> 4"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox1.Items.Add(New With {
                        .Text = reader("condition_status").ToString(),
                        .Value = Convert.ToInt32(reader("condition_id"))
                    })
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading conditions: " & ex.Message)
            End Try
        End Using
        ComboBox1.DisplayMember = "Text"
        ComboBox1.ValueMember = "Value"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox2.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAccNo As String = ComboBox2.SelectedItem.ToString()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM books WHERE Accno = @Accno"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ComboBox2.Text = reader("Accno").ToString()
                            Label2.Text = reader("Title").ToString()
                            Label10.Text = reader("Author").ToString()
                            Label20.Text = reader("Year").ToString()
                            Label22.Text = reader("Publisher").ToString()
                            Label3.Text = reader("ISBN").ToString()
                            Label26.Text = reader("Section").ToString()
                            Label15.Text = reader("Rack").ToString()
                            Label14.Text = reader("CallNumber").ToString()
                        Else
                            MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving book details: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT FullName, Year_Section, Course_Strand, ContactNumber, Email FROM users WHERE StudNo = @StudNo"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudNo", TextBox1.Text)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox2.Text = reader("FullName").ToString()
                            TextBox5.Text = reader("Year_Section").ToString()
                            TextBox6.Text = reader("Course_Strand").ToString()
                            TextBox3.Text = reader("ContactNumber").ToString()
                            TextBox4.Text = reader("Email").ToString()
                        Else
                            MessageBox.Show("Student not found. Please input details.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            TextBox2.Clear()
                            TextBox5.Clear()
                            TextBox6.Clear()
                            TextBox3.Clear()
                            TextBox4.Clear()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
           ComboBox1.SelectedItem Is Nothing Then

            MessageBox.Show("Please fill in all fields before borrowing.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim accNo As String = ComboBox2.Text
        Dim conditionId As Integer = DirectCast(ComboBox1.SelectedItem, Object).Value

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim userId As Integer
                Dim userIdQuery As String = "SELECT UserID FROM users WHERE StudNo = @StudNo"

                Using userCmd As New MySqlCommand(userIdQuery, conn)
                    userCmd.Parameters.AddWithValue("@StudNo", TextBox1.Text)
                    Dim result As Object = userCmd.ExecuteScalar()

                    If result Is Nothing Then
                        MessageBox.Show("Student number not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    userId = Convert.ToInt32(result)
                End Using

                Dim checkQuery As String = "SELECT COUNT(*) FROM books_borrowed WHERE book_id = @AccNo AND borrower_id = @UserId"

                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@AccNo", accNo)
                    checkCmd.Parameters.AddWithValue("@UserId", userId)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("This book is already borrowed by the student.", "Duplicate Borrow", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Dim insertQuery As String = "INSERT INTO books_borrowed (borrower_id, book_id, condition_id, date_borrowed, due_date, time) VALUES (@UserId, @BookId, @ConditionId, @DateBorrowed, @DueDate, @Time)"

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@UserId", userId)
                    cmd.Parameters.AddWithValue("@BookId", accNo)
                    cmd.Parameters.AddWithValue("@ConditionId", conditionId)
                    cmd.Parameters.AddWithValue("@DateBorrowed", DateTime.Now.Date)
                    cmd.Parameters.AddWithValue("@DueDate", DateTimePicker2.Value)
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Book successfully borrowed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Dim back As New Form4
                back.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub
End Class
