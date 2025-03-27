Imports MySql.Data.MySqlClient

Public Class Form9
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Private bookID As String
    Private title As String
    Private author As String
    Private year As String
    Private section As String
    Private copies As Integer
    Private callNumber As String
    Private rack As String
    Private borrowID As Integer
    Private studNo As String
    Private publisher As String
    Private isbn As String

    Public Sub New(studNo As String, bookID As String, isbn As String, title As String, author As String, year As String, publisher As String, section As String, copies As Integer, callNumber As String, rack As String)
        InitializeComponent()
        Me.studNo = studNo
        Me.bookID = bookID
        Me.title = title
        Me.author = author
        Me.year = year
        Me.section = section
        Me.copies = copies
        Me.callNumber = callNumber
        Me.rack = rack
        Me.publisher = publisher
        Me.isbn = isbn
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label02.Text = bookID.ToString()
        Label2.Text = title
        Label03.Text = author
        Label04.Text = year
        Label06.Text = section
        Label08.Text = copies.ToString()
        Label14.Text = callNumber
        Label09.Text = Convert.ToString(rack)
        Label05.Text = publisher
        Label01.Text = isbn

        If LoadBorrowerInfo() Then
            UpdateBookStatus("Borrowed")
        Else
            MessageBox.Show("No active borrow record found for this book.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub


    Private Function LoadBorrowerInfo() As Boolean
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "
                    SELECT b.BorrowID, b.StudNo, u.Name, u.ContactNum, u.Email, u.YearSection, u.Course
                    FROM borrow AS b
                    INNER JOIN users AS u ON b.StudNo = u.StudNo
                    WHERE b.BookID = @BookID AND b.StatusName IN ('Borrowed', 'Active', 'On Loan')
                    LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim borrowIDString As String = reader("BorrowID").ToString()
                            If Not reader.IsDBNull(reader.GetOrdinal("BorrowID")) Then
                                borrowID = reader.GetInt32("BorrowID")
                            Else
                                borrowID = 0
                            End If



                            studNo = reader.GetString("StudNo")
                            Label25.Text = $"{studNo}"
                            Label24.Text = $"{reader.GetString("Name")}"
                            Label11.Text = $"{reader.GetString("YearSection")}"
                            Label31.Text = $"{reader.GetString("Course")}"
                            Label28.Text = $"{reader.GetString("ContactNum")}"
                            Label26.Text = $"{reader.GetString("Email")}"
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading borrower info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function


    Private Sub UpdateBookStatus(status As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim updateQuery As String = "
                    UPDATE book
                    SET Status = @Status
                    WHERE BookID = @BookID;"
                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating book status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReturnGood()
        Try
            If borrowID = 0 Then
                MessageBox.Show("Invalid Borrow ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim query As String = "
                INSERT INTO return_good (BorrowID, BookID, StudNo, ReturnDate) 
                VALUES (@BorrowID, @BookID, @StudNo, NOW());

                UPDATE book
                SET Status = 'Available'
                WHERE BookID = @BookID;

                UPDATE borrow
                SET StatusName = 'Returned'
                WHERE BorrowID = @BorrowID;"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
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
            If borrowID = 0 Then
                MessageBox.Show("Invalid Borrow ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

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
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReturnGood()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim damageDescription As String = InputBox("Enter damage description:", "Damaged Book")
        If String.IsNullOrWhiteSpace(damageDescription) Then Exit Sub
        Dim fineAmount As Decimal = CDec(InputBox("Enter fine amount:", "Fine"))
        ReturnDamaged(damageDescription, fineAmount)
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub
End Class
