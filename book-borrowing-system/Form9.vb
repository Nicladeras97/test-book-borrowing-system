Imports MySql.Data.MySqlClient

Public Class Form9
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"

    Private isbn As String
    Private title As String
    Private author As String
    Private year As String
    Private category As String
    Private imagePath As String
    Private copies As Integer
    Private callNumber As String
    Private rackNumber As String
    Private borrowID As Integer
    Private studNo As String

    Public Sub New(borrowID As Integer, studNo As String, isbn As String, title As String, author As String, year As String, category As String, imagePath As String, copies As Integer, callNumber As String, rackNumber As String)
        InitializeComponent()
        Me.borrowID = borrowID
        Me.studNo = studNo
        Me.isbn = isbn
        Me.title = title
        Me.author = author
        Me.year = year
        Me.category = category
        Me.imagePath = imagePath
        Me.copies = copies
        Me.callNumber = callNumber
        Me.rackNumber = rackNumber
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label23.Text = isbn
        Label2.Text = title
        Label18.Text = author
        Label20.Text = year
        Label22.Text = category
        Label27.Text = copies.ToString()
        Label14.Text = callNumber
        Label15.Text = rackNumber

        If Not String.IsNullOrEmpty(imagePath) AndAlso IO.File.Exists(imagePath) Then
            Using fs As New IO.FileStream(imagePath, IO.FileMode.Open, IO.FileAccess.Read)
                PictureBox1.Image = Image.FromStream(fs)
            End Using
        Else
            PictureBox1.Image = My.Resources.image
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
            SELECT b.BorrowID, b.StudNo, u.FullName, u.ContactNumber, u.Email
            FROM borrow AS b
            INNER JOIN users AS u ON b.StudNo = u.StudNo
            WHERE b.ISBN = @ISBN AND b.StatusName = 'Borrowed' 
            LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            borrowID = reader.GetInt32("BorrowID")
                            studNo = reader.GetString("StudNo")

                            Label25.Text = $"{studNo}"
                            Label24.Text = $"{reader.GetString("FullName")}"
                            Label11.Text = $"{reader.GetString("ContactNumber")}"
                            Label26.Text = $"{reader.GetString("Email")}"
                        Else
                            MessageBox.Show("No active borrow record found for this book.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End Using
                End Using
            End Using

            Using conn2 As New MySqlConnection(connString)
                conn2.Open()

                Dim updateQuery As String = "
                    UPDATE book
                    SET Status = 'Borrowed'
                    WHERE ISBN = @ISBN;"

                Using cmd2 As New MySqlCommand(updateQuery, conn2)
                    cmd2.Parameters.AddWithValue("@ISBN", isbn)
                    cmd2.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnGood()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_good (BorrowID, ISBN, StudNo, ReturnDate) 
                VALUES (@BorrowID, @ISBN, @StudNo, NOW());

                UPDATE book
                SET Status = 'Available', Copies = Copies + 1
                WHERE ISBN = @ISBN;

                UPDATE borrow
                SET StatusName = 'Returned'
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                    cmd.Parameters.AddWithValue("@StudNo", studNo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim back As New Form12
            back.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnDamaged(damageDescription As String, fineAmount As Decimal)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_damaged (BorrowID, ISBN, StudNo, ReturnDate, DamageDescription, FineAmount) 
                VALUES (@BorrowID, @ISBN, @StudNo, NOW(), @DamageDescription, @FineAmount);

                UPDATE book
                SET Status = 'Damaged' 
                WHERE ISBN = @ISBN;

                UPDATE borrow
                SET StatusName = 'Returned (Damaged)' 
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                    cmd.Parameters.AddWithValue("@StudNo", studNo)
                    cmd.Parameters.AddWithValue("@DamageDescription", damageDescription)
                    cmd.Parameters.AddWithValue("@FineAmount", fineAmount)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Book returned as damaged. Fine: ₱{fineAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim back As New Form12
            back.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnLost(fineAmount As Decimal, gracePeriod As Date)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO return_lost (BorrowID, ISBN, StudNo, FineAmount, GracePeriod, ReportDate) 
                VALUES (@BorrowID, @ISBN, @StudNo, @FineAmount, @GracePeriod, NOW());

                UPDATE book
                SET Status = 'Lost'
                WHERE ISBN = @ISBN;

                UPDATE borrow
                SET StatusName = 'Returned (Lost)' 
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@ISBN", isbn)
                    cmd.Parameters.AddWithValue("@StudNo", studNo)
                    cmd.Parameters.AddWithValue("@FineAmount", fineAmount)
                    cmd.Parameters.AddWithValue("@GracePeriod", gracePeriod)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Lost book recorded successfully! Grace period until {gracePeriod:yyyy-MM-dd}. Fine: ₱{fineAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim back As New Form12
            back.Show()
            Me.Hide()

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
        Dim graceInput As String = InputBox("Enter grace period (in days):", "Grace Period")

        If String.IsNullOrEmpty(graceInput) Then Exit Sub

        Dim graceDays As Integer
        If Not Integer.TryParse(graceInput, graceDays) OrElse graceDays < 0 Then
            MessageBox.Show("Invalid grace period.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim gracePeriod As Date = Date.Today.AddDays(graceDays)

        Dim fineInput As String = InputBox("Enter damage fee:", "Lost Book")

        If String.IsNullOrEmpty(fineInput) Then Exit Sub

        Dim fineAmount As Decimal
        If Not Decimal.TryParse(fineInput, fineAmount) OrElse fineAmount < 0 Then
            MessageBox.Show("Invalid fine amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ReturnLost(fineAmount, gracePeriod)
    End Sub


    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub

End Class
