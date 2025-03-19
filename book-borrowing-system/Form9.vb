Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form9
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Dim conn As New MySqlConnection(connString)

    Private BorrowID As String
    Private BookID As String
    Private BookTitle As String
    Private StudentName As String
    Private StudNo As String
    Private ImagePath As String

    Public Sub New(borrowID As String, bookID As String, title As String, studentName As String, studNo As String, imagePath As String)
        InitializeComponent()
        Me.BorrowID = borrowID
        Me.BookID = bookID
        Me.BookTitle = title
        Me.StudentName = studentName
        Me.StudNo = studNo
        Me.ImagePath = imagePath
    End Sub


    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = BookTitle
        Label3.Text = BookID
        TextBox2.Text = StudentName
        TextBox1.Text = StudNo

        If Not String.IsNullOrEmpty(ImagePath) AndAlso IO.File.Exists(ImagePath) Then
            PictureBox1.Image = Image.FromFile(ImagePath)
        Else
            PictureBox1.Image = My.Resources.image
            MessageBox.Show("Image not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to return this book?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ReturnBook()
        End If
    End Sub

    Private Sub LoadBookImage(bookID As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "SELECT Image FROM book WHERE BookID = @BookID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        Dim imagePath As String = reader("Image").ToString()

                        If File.Exists(imagePath) Then
                            PictureBox1.Image = Image.FromFile(imagePath)
                        Else
                            PictureBox1.Image = Nothing
                            MessageBox.Show("Image not found at path: " & imagePath, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnBook()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    Dim query As String = "UPDATE borrow SET StatusName = 'Available' WHERE BorrowID = @BorrowID"
                    Using cmd As New MySqlCommand(query, conn, transaction)
                        cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim updateStockQuery As String = "UPDATE book SET Copies = Copies + 1 WHERE BookID = @BookID"
                    Using cmd As New MySqlCommand(updateStockQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@BookID", BookID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim insertReturnedQuery As String = "INSERT INTO returned (BorrowID, BookID, StudentName, StudNo, ReturnDate) " &
                                                    "VALUES (@BorrowID, @BookID, @StudentName, @StudNo, NOW())"
                    Using cmd As New MySqlCommand(insertReturnedQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                        cmd.Parameters.AddWithValue("@BookID", BookID)
                        cmd.Parameters.AddWithValue("@StudentName", StudentName)
                        cmd.Parameters.AddWithValue("@StudNo", StudNo)
                        cmd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()

                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim form3 As New Form3()
                    form3.Show()
                    Me.Close()

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Transaction failed: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form3()
        back.Show()
        Me.Close()
    End Sub

End Class
