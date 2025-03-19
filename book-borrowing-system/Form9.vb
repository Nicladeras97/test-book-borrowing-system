Imports System.IO
Imports MySql.Data.MySqlClient

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
            PictureBox5.Image = Image.FromFile(ImagePath)
        Else
            PictureBox5.Image = My.Resources.image
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to return this book?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ReturnBook()
        End If
    End Sub

    ' ✅ Keep this ReturnBook() method
    Private Sub ReturnBook()
        If CheckBox1.Checked AndAlso Not (CheckBox2.Checked Or CheckBox3.Checked) Then
            Using conn As New MySqlConnection(connString)
                Try
                    conn.Open()

                    Dim transaction As MySqlTransaction = conn.BeginTransaction()

                    Try
                        ' Update borrow status
                        Dim query As String = "UPDATE borrow SET StatusName = 'Available' WHERE BorrowID = @BorrowID"
                        Using cmd As New MySqlCommand(query, conn, transaction)
                            cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Update book stock
                        Dim updateStockQuery As String = "UPDATE book SET Copies = Copies + 1 WHERE BookID = @BookID"
                        Using cmd As New MySqlCommand(updateStockQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@BookID", BookID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Insert into returned table
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
        Else
            MessageBox.Show("The book must be in 'Good' condition to be returned.", "Return Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form3()
        back.Show()
        Me.Close()
    End Sub

End Class
