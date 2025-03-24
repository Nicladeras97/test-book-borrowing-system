Imports MySql.Data.MySqlClient

Public Class Form9
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"

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
        Label7.Text = StudentName
        Label8.Text = StudNo

        If Not String.IsNullOrEmpty(ImagePath) AndAlso IO.File.Exists(ImagePath) Then
            PictureBox5.Image = Image.FromFile(ImagePath)
        Else
            PictureBox5.Image = My.Resources.image
        End If
    End Sub

    Private Sub ReturnGood()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_good (BorrowID, BookID, StudNo, ReturnDate) 
                VALUES (@BorrowID, @BookID, @StudNo, NOW());

                UPDATE book
                SET Copies = Copies + 1, Status = 'Available'
                WHERE BookID = @BookID;

                UPDATE borrow
                SET StatusName = 'Returned'
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                    cmd.Parameters.AddWithValue("@BookID", BookID)
                    cmd.Parameters.AddWithValue("@StudNo", StudNo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form3 As New Form3
            form3.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnDamaged(damageDescription As String, fineAmount As Decimal)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_damaged (BorrowID, BookID, StudNo, ReturnDate, DamageDescription, FineAmount) 
                VALUES (@BorrowID, @BookID, @StudNo, NOW(), @DamageDescription, @FineAmount);

                UPDATE book
                SET Status = 'Damaged' 
                WHERE BookID = @BookID;

                UPDATE borrow
                SET StatusName = 'Returned (Damaged)' 
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                    cmd.Parameters.AddWithValue("@BookID", BookID)
                    cmd.Parameters.AddWithValue("@StudNo", StudNo)
                    cmd.Parameters.AddWithValue("@DamageDescription", damageDescription)
                    cmd.Parameters.AddWithValue("@FineAmount", fineAmount)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Book returned as damaged. Fine: ₱{fineAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form3 As New Form3
            form3.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnLost(fineAmount As Decimal, gracePeriod As Date)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_lost (BorrowID, BookID, StudNo, FineAmount, GracePeriod, ReportDate) 
                VALUES (@BorrowID, @BookID, @StudNo, @FineAmount, @GracePeriod, NOW());

                UPDATE book
                SET Status = 'Lost'
                WHERE BookID = @BookID;

                UPDATE borrow
                SET StatusName = 'Returned (Lost)', 
                    DueDate = NULL  
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", BorrowID)
                    cmd.Parameters.AddWithValue("@BookID", BookID)
                    cmd.Parameters.AddWithValue("@StudNo", StudNo)
                    cmd.Parameters.AddWithValue("@FineAmount", fineAmount)
                    cmd.Parameters.AddWithValue("@GracePeriod", gracePeriod)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Lost book recorded successfully! Grace period until {gracePeriod:yyyy-MM-dd}. Fine: ₱{fineAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form3 As New Form3
            form3.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReturnGood()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim damageDescription As String = InputBox("Enter damage description:", "Damaged Book")

        If String.IsNullOrWhiteSpace(damageDescription) Then Exit Sub

        Dim fineInput As String = InputBox("Enter fine amount:", "Damage Fine")

        Dim fineAmount As Decimal
        If Not Decimal.TryParse(fineInput, fineAmount) OrElse fineAmount < 0 Then
            MessageBox.Show("Invalid fine amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ReturnDamaged(damageDescription, fineAmount)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fineInput As String = InputBox("Enter damage fee:", "Lost Book")

        If String.IsNullOrEmpty(fineInput) Then Exit Sub

        Dim fineAmount As Decimal
        If Not Decimal.TryParse(fineInput, fineAmount) OrElse fineAmount < 0 Then
            MessageBox.Show("Invalid fine amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim gracePeriod As Date = Date.Today.AddDays(7)
        ReturnLost(fineAmount, gracePeriod)
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim back As New Form3
        back.Show()
        Me.Close()
    End Sub
End Class
