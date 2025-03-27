Imports MySql.Data.MySqlClient

Public Class Form9
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"

    Private accno As String
    Private title As String
    Private author As String
    Private year As String
    Private section As String
    Private copies As Integer
    Private callNumber As String
    Private rack As String
    Private publisher As String
    Private borrowID As Integer
    Private studNo As String

    Public Sub New(borrowID As Integer, studNo As String, accno As String, title As String, author As String, year As String, section As String, copies As Integer, callNumber As String, rack As String, publisher As String)
        InitializeComponent()
        Me.borrowID = borrowID
        Me.studNo = studNo
        Me.accno = accno
        Me.title = title
        Me.author = author
        Me.year = year
        Me.section = section
        Me.copies = copies
        Me.callNumber = callNumber
        Me.rack = rack
        Me.publisher = publisher
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label27.Text = accno
        Label2.Text = title
        Label18.Text = author
        Label20.Text = year
        Label10.Text = section
        'Label27.Text = copies.ToString()
        Label14.Text = callNumber
        Label15.Text = rack
        Label22.Text = publisher

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                SELECT b.BorrowID, b.StudNo, u.FullName, u.ContactNumber, u.Email, u.YearSection, u.Course
                FROM borrow AS b
                INNER JOIN users AS u ON b.StudNo = u.StudNo
                WHERE b.Accno = @Accno AND b.StatusName = 'Borrowed' 
                LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", accno)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            borrowID = reader.GetInt32("BorrowID")
                            studNo = reader.GetString("StudNo")

                            Label25.Text = $"{studNo}"
                            Label24.Text = $"{reader.GetString("FullName")}"
                            Label28.Text = $"{reader.GetString("ContactNumber")}"
                            Label26.Text = $"{reader.GetString("Email")}"
                            Label11.Text = $"{reader.GetString("YearSection")}"
                            Label31.Text = $"{reader.GetString("Course")}"
                        Else
                            MessageBox.Show("No active borrow record found for this book.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End Using
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
                INSERT INTO return_good (BorrowID, Accno, StudNo, ReturnDate) 
                VALUES (@BorrowID, @Accno, @StudNo, NOW());

                UPDATE book
                SET Status = 'Available'
                WHERE Accno = @Accno;

                UPDATE borrow
                SET StatusName = 'Returned'
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@Accno", accno)
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
                INSERT INTO return_damaged (BorrowID, Accno, StudNo, ReturnDate, DamageDescription, FineAmount) 
                VALUES (@BorrowID, @Accno, @StudNo, NOW(), @DamageDescription, @FineAmount);

                UPDATE book
                SET Status = 'Damaged'
                WHERE Accno = @Accno;

                UPDATE borrow
                SET StatusName = 'Returned (Damaged)'
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@Accno", accno)
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
                INSERT INTO return_lost (BorrowID, Accno, StudNo, FineAmount, GracePeriod, ReportDate) 
                VALUES (@BorrowID, @Accno, @StudNo, @FineAmount, @GracePeriod, NOW());

                UPDATE book
                SET Status = 'Lost'
                WHERE Accno = @Accno;

                UPDATE borrow
                SET StatusName = 'Returned (Lost)'
                WHERE BorrowID = @BorrowID;"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BorrowID", borrowID)
                    cmd.Parameters.AddWithValue("@Accno", accno)
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
        Dim graceDays As Integer = CInt(InputBox("Enter grace period (in days):", "Grace Period"))
        Dim fineAmount As Decimal = CDec(InputBox("Enter fine amount:", "Lost Book"))

        Dim gracePeriod As Date = Date.Today.AddDays(graceDays)

        ReturnLost(fineAmount, gracePeriod)
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub
End Class
