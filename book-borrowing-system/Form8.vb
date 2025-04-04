Imports MySql.Data.MySqlClient

Public Class Form8
    Dim connString As String = "server=localhost;user id=root;password=;database=book-borrowing"
    Private WithEvents BarcodeTimer As New Timer()
    Private scanAccno As String = ""
    Private scanStudno As String = ""
    Private scanType As String = ""

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Focus()
        LoadBooks()
        LoadBookConditions()
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDown
        BarcodeTimer.Interval = 500
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
                Dim query As String = "SELECT condition_id, condition_status FROM book_condition WHERE condition_id NOT IN (3, 4, 5)"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim accNo = ComboBox2.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query = "SELECT FullName, Year_Section, Course_Strand, ContactNumber, Email FROM users WHERE StudNo = @StudNo"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudNo", TextBox1.Text)
                    Using reader = cmd.ExecuteReader
                        If reader.Read Then
                            TextBox2.Text = reader("FullName").ToString
                            TextBox5.Text = reader("Year_Section").ToString
                            TextBox6.Text = reader("Course_Strand").ToString
                            TextBox3.Text = reader("ContactNumber").ToString
                            TextBox4.Text = reader("Email").ToString
                        Else
                            MessageBox.Show("No record found. Please input details.", "No record found", MessageBoxButtons.OK, MessageBoxIcon.None)
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
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse  ' StudNo
       String.IsNullOrWhiteSpace(TextBox2.Text) OrElse  ' FullName
       String.IsNullOrWhiteSpace(TextBox3.Text) OrElse  ' ContactNumber
       ComboBox1.SelectedItem Is Nothing Then  ' Book Condition

            MessageBox.Show("Please fill in all fields before borrowing.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim accNo As String = ComboBox2.Text
        Dim studNo As String = TextBox1.Text
        Dim fullName As String = TextBox2.Text
        Dim yearSection As String = TextBox5.Text
        Dim course As String = TextBox6.Text
        Dim contact As String = TextBox3.Text
        Dim email As String = TextBox4.Text
        Dim conditionId As Integer = DirectCast(ComboBox1.SelectedItem, Object).Value

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim userId As Integer
                Dim userIdQuery As String = "SELECT UserID FROM users WHERE StudNo = @StudNo"

                Using userCmd As New MySqlCommand(userIdQuery, conn)
                    userCmd.Parameters.AddWithValue("@StudNo", studNo)
                    Dim result As Object = userCmd.ExecuteScalar()

                    If result Is Nothing Then
                        Dim insertUserQuery As String = "INSERT INTO users (StudNo, FullName, Year_Section, Course_Strand, ContactNumber, Email) VALUES (@StudNo, @FullName, @YearSection, @Course, @Contact, @Email)"

                        Using insertCmd As New MySqlCommand(insertUserQuery, conn)
                            insertCmd.Parameters.AddWithValue("@StudNo", studNo)
                            insertCmd.Parameters.AddWithValue("@FullName", fullName)
                            insertCmd.Parameters.AddWithValue("@YearSection", yearSection)
                            insertCmd.Parameters.AddWithValue("@Course", course)
                            insertCmd.Parameters.AddWithValue("@Contact", contact)
                            insertCmd.Parameters.AddWithValue("@Email", email)
                            insertCmd.ExecuteNonQuery()
                        End Using

                        userId = CInt(New MySqlCommand("SELECT LAST_INSERT_ID()", conn).ExecuteScalar())
                    Else
                        userId = Convert.ToInt32(result)
                    End If
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

                Dim insertQuery As String = "INSERT INTO books_borrowed (borrower_id, book_id, condition_id, date_borrowed, due_date, time, notify_id) VALUES (@UserId, @BookId, @ConditionId, @DateBorrowed, @DueDate, @Time, @NotifyID)"

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@UserId", userId)
                    cmd.Parameters.AddWithValue("@BookId", accNo)
                    cmd.Parameters.AddWithValue("@ConditionId", conditionId)
                    cmd.Parameters.AddWithValue("@DateBorrowed", DateTime.Now.Date)
                    cmd.Parameters.AddWithValue("@DueDate", DateTimePicker2.Value)
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@NotifyID", 4)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Book successfully borrowed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Dim back As New Form15
                back.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim back As New Form15
        back.Show()
        Hide()
    End Sub

    Private Sub ProcessBarcodeAccno(barcode As String)
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim borrowedQuery As String = "SELECT COUNT(*) FROM books_borrowed WHERE book_id = @Accno"
                Using borrowedCmd As New MySqlCommand(borrowedQuery, conn)
                    borrowedCmd.Parameters.AddWithValue("@Accno", barcode)
                    Dim count As Integer = Convert.ToInt32(borrowedCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("This book is already borrowed.", "Borrowed Book", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ComboBox2.Text = ""
                        Exit Sub
                    End If
                End Using

                Dim bookQuery As String = "SELECT * FROM books WHERE Accno = @Accno"
                Using bookCmd As New MySqlCommand(bookQuery, conn)
                    bookCmd.Parameters.AddWithValue("@Accno", barcode)
                    Using reader As MySqlDataReader = bookCmd.ExecuteReader()
                        If reader.Read() Then
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
                            ComboBox2.Text = ""
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error retrieving book details: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub ProcessBarcodeStudno(studentID As String)
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT FullName, Year_Section, Course_Strand, ContactNumber, Email FROM users WHERE StudNo = @StudNo"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudNo", studentID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox2.Text = reader("FullName").ToString()
                            TextBox5.Text = reader("Year_Section").ToString()
                            TextBox6.Text = reader("Course_Strand").ToString()
                            TextBox3.Text = reader("ContactNumber").ToString()
                            TextBox4.Text = reader("Email").ToString()
                        Else
                            MessageBox.Show("No student found with that ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TextBox2.Clear()
                            TextBox5.Clear()
                            TextBox6.Clear()
                            TextBox3.Clear()
                            TextBox4.Clear()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving student data: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If String.IsNullOrWhiteSpace(ComboBox2.Text) Then Return

        scanAccno = ComboBox2.Text.Trim()
        scanType = "accno"
        BarcodeTimer.Stop()
        BarcodeTimer.Start()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then Return

        scanStudno = TextBox1.Text.Trim()
        scanType = "studno"
        BarcodeTimer.Stop()
        BarcodeTimer.Start()
    End Sub

    Private Sub BarcodeTimer_Tick(sender As Object, e As EventArgs) Handles BarcodeTimer.Tick
        BarcodeTimer.Stop()

        If scanType = "accno" AndAlso scanAccno.Length >= 11 Then
            ProcessBarcodeAccno(scanAccno)
        ElseIf scanType = "studno" AndAlso scanStudno.Length >= 6 Then
            ProcessBarcodeStudno(scanStudno)
        End If
    End Sub

End Class
