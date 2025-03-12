Imports MySql.Data.MySqlClient

Public Class Form8
    Dim connString As String = "server=localhost; user=root; password=; database=borrowing_system;"

    Private bookID As String
    Private bookTitle As String
    Private bookImage As String

    Public Sub New(id As String, title As String, image As String, status As String)
        InitializeComponent()
        bookID = id
        bookTitle = title
        bookImage = image
    End Sub

    Private Sub BorrowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox5.ImageLocation = bookImage
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
        Dim form As New Form2()
        form.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection(connString)

        Try
            conn.Open()

            Dim studentNumber As String = TextBox1.Text
            Dim fullName = TextBox2.Text
            Dim contactNumber = TextBox3.Text
            Dim borrowDate = DateTimePicker1.Value
            Dim dueDate = DateTimePicker2.Value

            Dim checkUserQuery = "SELECT COUNT(*) FROM users WHERE StudNo = @StudNo"
            Dim checkCmd As New MySqlCommand(checkUserQuery, conn)
            checkCmd.Parameters.AddWithValue("@StudNo", studentNumber)
            Dim userExists = Convert.ToInt32(checkCmd.ExecuteScalar)

            If userExists = 0 Then
                Dim insertUserQuery = "INSERT INTO users (StudNo, FName, CNumber) VALUES (@StudNo, @FName, @CNumber)"
                Dim insertUserCmd As New MySqlCommand(insertUserQuery, conn)
                insertUserCmd.Parameters.AddWithValue("@StudNo", studentNumber)
                insertUserCmd.Parameters.AddWithValue("@FName", fullName)
                insertUserCmd.Parameters.AddWithValue("@CNumber", contactNumber)
                insertUserCmd.ExecuteNonQuery()
            End If

            Dim insertQuery = "INSERT INTO borrow (StudNo, BookID, BorrowDate, DueDate, StatusID) 
                                         VALUES (@StudNo, @BookID, @BorrowDate, @DueDate, 'Borrowed')"
            Dim cmd As New MySqlCommand(insertQuery, conn)
            cmd.Parameters.AddWithValue("@StudNo", studentNumber)
            cmd.Parameters.AddWithValue("@BookID", bookID)
            cmd.Parameters.AddWithValue("@BorrowDate", borrowDate)
            cmd.Parameters.AddWithValue("@DueDate", dueDate)
            cmd.ExecuteNonQuery()

            Dim updateQuery = "UPDATE book SET StatusID = 'Borrowed' WHERE BookID = @BookID"
            Dim cmdUpdate As New MySqlCommand(updateQuery, conn)
            cmdUpdate.Parameters.AddWithValue("@BookID", bookID)
            cmdUpdate.ExecuteNonQuery()

            MessageBox.Show("Book successfully borrowed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim displayForm As New Form2
            displayForm.Show()
            Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class
