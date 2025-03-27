Imports MySql.Data.MySqlClient

Public Class Form8
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

    Private bookID As String
    Private title As String
    Private author As String
    Private year As String
    Private section As String
    Private publisher As String
    Private isbn As String
    Private callNumber As String
    Private rack As String

    Public Sub New(bookID As String, title As String, author As String, year As String, section As String, publisher As String, isbn As String, callNumber As String, rack As String)
        InitializeComponent()
        Me.bookID = bookID
        Me.title = title
        Me.author = author
        Me.year = year
        Me.section = section
        Me.publisher = publisher
        Me.isbn = isbn
        Me.callNumber = callNumber
        Me.rack = rack
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label02.Text = bookID
        Label2.Text = title
        Label03.Text = author
        Label04.Text = year
        Label06.Text = section
        Label10.Text = callNumber
        Label09.Text = rack
        Label05.Text = publisher
        Label01.Text = isbn
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim studNo = TextBox1.Text.Trim
        If String.IsNullOrEmpty(studNo) Then
            MessageBox.Show("Please enter a Student Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query = "SELECT Name, ContactNum, Email, YearSection, Course FROM users WHERE StudNo = @StudNo"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@StudNo", studNo)

        Try
            conn.Open()
            Dim reader = cmd.ExecuteReader

            If reader.Read Then
                TextBox2.Text = reader("Name").ToString
                TextBox3.Text = reader("YearSection").ToString
                TextBox4.Text = reader("Course").ToString
                TextBox5.Text = reader("ContactNum").ToString
                TextBox6.Text = reader("Email").ToString
            Else
                Dim result = MessageBox.Show("Student not found. Enter details?", "New Borrower", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                Else
                    Return
                End If
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studNo As String = TextBox1.Text.Trim()
        Dim name As String = TextBox2.Text.Trim()
        Dim ys As String = TextBox3.Text.Trim()
        Dim course As String = TextBox4.Text.Trim()
        Dim contact As String = TextBox5.Text.Trim()
        Dim email As String = TextBox6.Text.Trim()
        Dim borrowDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim dueDate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")

        If String.IsNullOrEmpty(studNo) Or String.IsNullOrEmpty(name) Or String.IsNullOrEmpty(ys) Or String.IsNullOrEmpty(course) Or String.IsNullOrEmpty(contact) Or String.IsNullOrEmpty(email) Then
            MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()

            Dim checkUserQuery As String = "SELECT COUNT(*) FROM users WHERE StudNo = @StudNo"
            Dim checkUserCmd As New MySqlCommand(checkUserQuery, conn)
            checkUserCmd.Parameters.AddWithValue("@StudNo", studNo)

            Dim exists As Integer = Convert.ToInt32(checkUserCmd.ExecuteScalar())

            If exists = 0 Then
                Dim insertUserQuery As String = "
                INSERT INTO users (StudNo, Name, YearSection, Course, ContactNum, Email)
                VALUES (@StudNo, @Name, @YearSection, @Course, @Contact, @Email)"
                Dim insertUserCmd As New MySqlCommand(insertUserQuery, conn)
                insertUserCmd.Parameters.AddWithValue("@StudNo", studNo)
                insertUserCmd.Parameters.AddWithValue("@Name", name)
                insertUserCmd.Parameters.AddWithValue("@YearSection", ys)
                insertUserCmd.Parameters.AddWithValue("@Course", course)
                insertUserCmd.Parameters.AddWithValue("@Contact", contact)
                insertUserCmd.Parameters.AddWithValue("@Email", email)
                insertUserCmd.ExecuteNonQuery()
            End If

            Dim checkQuery As String = "SELECT Status FROM book WHERE BookID = @BookID"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@BookID", bookID)

            Dim status As String = Convert.ToString(checkCmd.ExecuteScalar())

            If status = "Available" Then
                Dim insertQuery As String = "
                INSERT INTO borrow (StudNo, BookID, BorrowDate, DueDate, StatusName)
                VALUES (@StudNo, @BookID, @BorrowDate, @DueDate, 'Borrowed')"
                Dim insertCmd As New MySqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@StudNo", studNo)
                insertCmd.Parameters.AddWithValue("@BookID", bookID)
                insertCmd.Parameters.AddWithValue("@BorrowDate", borrowDate)
                insertCmd.Parameters.AddWithValue("@DueDate", dueDate)
                insertCmd.ExecuteNonQuery()

                Dim updateQuery As String = "UPDATE book SET Status = 'Borrowed' WHERE BookID = @BookID"
                Dim updateCmd As New MySqlCommand(updateQuery, conn)
                updateCmd.Parameters.AddWithValue("@BookID", bookID)
                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim back As New Form12
                back.Show()
                Me.Hide()
            Else
                MessageBox.Show("Book is not available.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub
End Class
