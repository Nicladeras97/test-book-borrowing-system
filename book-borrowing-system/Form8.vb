Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form8
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
    Private bookID As String
    Private bookTitle As String
    Private bookImage As String
    Private copies As Integer

    Public Sub New(selectedBookID As String, title As String, imagePath As String, availableCopies As Integer)
        InitializeComponent()
        bookID = selectedBookID
        bookTitle = title
        bookImage = imagePath
        copies = availableCopies

        Label3.Text = bookID
        Label2.Text = bookTitle
        Label10.Text = copies.ToString()

        If File.Exists(bookImage) Then
            PictureBox5.Image = Image.FromFile(bookImage)
        Else
            PictureBox5.Image = My.Resources.image
        End If
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = bookTitle
        Label3.Text = bookID
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsNumeric(TextBox3.Text) Then
            MessageBox.Show("Please enter a valid contact number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If copies <= 0 Then
            MessageBox.Show("No available copies for borrowing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim studentNumber As String = TextBox1.Text
                Dim fullName As String = TextBox2.Text
                Dim contactNumber As String = TextBox3.Text
                Dim borrowDate As Date = DateTimePicker1.Value
                Dim dueDate As Date = DateTimePicker2.Value

                Dim checkBorrowQuery As String = "SELECT COUNT(*) FROM borrow WHERE StudNo = @StudNo AND BookID = @BookID AND StatusName = 'Borrowed'"
                Using checkBorrowCmd As New MySqlCommand(checkBorrowQuery, conn)
                    checkBorrowCmd.Parameters.AddWithValue("@StudNo", studentNumber)
                    checkBorrowCmd.Parameters.AddWithValue("@BookID", bookID)
                    Dim alreadyBorrowed As Integer = Convert.ToInt32(checkBorrowCmd.ExecuteScalar())

                    If alreadyBorrowed > 0 Then
                        MessageBox.Show("You have already borrowed this book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Dim checkUserQuery As String = "SELECT COUNT(*) FROM users WHERE StudNo = @StudNo"
                Using checkCmd As New MySqlCommand(checkUserQuery, conn)
                    checkCmd.Parameters.AddWithValue("@StudNo", studentNumber)
                    Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If userExists = 0 Then
                        Dim insertUserQuery As String = "INSERT INTO users (StudNo, FullName, ContactNumber) VALUES (@StudNo, @FullName, @ContactNumber)"
                        Using insertUserCmd As New MySqlCommand(insertUserQuery, conn)
                            insertUserCmd.Parameters.AddWithValue("@StudNo", studentNumber)
                            insertUserCmd.Parameters.AddWithValue("@FullName", fullName)
                            insertUserCmd.Parameters.AddWithValue("@ContactNumber", contactNumber)
                            insertUserCmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using

                Dim insertQuery As String = "INSERT INTO borrow (StudNo, BookID, BorrowDate, DueDate, StatusName) VALUES (@StudNo, @BookID, @BorrowDate, @DueDate, 'Borrowed')"
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@StudNo", studentNumber)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate)
                    cmd.Parameters.AddWithValue("@DueDate", dueDate)
                    cmd.ExecuteNonQuery()
                End Using

                Dim updateQuery As String = "UPDATE book 
                    SET Copies = Copies - 1, 
                        Status = CASE WHEN Copies - 1 = 0 THEN 'Borrowed' ELSE 'Available' END 
                    WHERE BookID = @BookID"
                Using cmdUpdate As New MySqlCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@BookID", bookID)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                MessageBox.Show("Book successfully borrowed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Form2.Show()
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
