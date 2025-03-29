Imports MySql.Data.MySqlClient

Public Class Form9
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing")
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            Dim query As String = "SELECT condition_id, condition_status FROM book_condition"
            cmd = New MySqlCommand(query, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                ComboBox1.Items.Add(reader("condition_status").ToString())
            End While
            reader.Close()

            Dim queryAccno As String = "SELECT book_id FROM books_borrowed"
            cmd = New MySqlCommand(queryAccno, conn)
            reader = cmd.ExecuteReader()

            While reader.Read()
                ComboBox2.Items.Add(reader("book_id").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim accNo As String = ComboBox2.SelectedItem?.ToString()

        If String.IsNullOrEmpty(accNo) Then
            MessageBox.Show("Please select an Accession Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()
            Dim query As String = "SELECT b.*, bb.borrower_id, bb.date_borrowed, bb.due_date, u.FullName, u.StudNo, u.Year_Section, u.Course_Strand, u.ContactNumber, u.Email, bc.condition_status " &
                                  "FROM books AS b " &
                                  "JOIN books_borrowed AS bb ON b.Accno = bb.book_id " &
                                  "JOIN users AS u ON bb.borrower_id = u.UserID " &
                                  "JOIN book_condition AS bc ON bb.condition_id = bc.condition_id " &
                                  "WHERE b.Accno = @Accno"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Accno", accNo)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                Label2.Text = reader("Title").ToString()
                Label23.Text = reader("ISBN").ToString()
                Label18.Text = reader("Author").ToString()
                Label20.Text = reader("Year").ToString()
                Label22.Text = reader("Publisher").ToString()
                Label10.Text = reader("Section").ToString()
                Label15.Text = reader("Rack").ToString()
                Label14.Text = reader("CallNumber").ToString()
                Label25.Text = reader("StudNo").ToString()
                Label24.Text = reader("FullName").ToString()
                Label11.Text = reader("Year_Section").ToString()
                Label31.Text = reader("Course_Strand").ToString()
                Label28.Text = reader("ContactNumber").ToString()
                Label26.Text = reader("Email").ToString()
                ComboBox1.SelectedItem = reader("condition_status").ToString()
            Else
                MessageBox.Show("Book record not found or not borrowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving book details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            reader.Close()
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim accNo = ComboBox2.SelectedItem?.ToString

        If String.IsNullOrEmpty(accNo) Then
            MessageBox.Show("Please select a book to return.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()
            Dim borrowerID = 0
            Dim getBorrowerQuery = "SELECT borrower_id, due_date FROM books_borrowed WHERE book_id = @Accno"
            Dim borrowerCmd As New MySqlCommand(getBorrowerQuery, conn)
            borrowerCmd.Parameters.AddWithValue("@Accno", accNo)

            Dim borrowerReader = borrowerCmd.ExecuteReader
            Dim dueDate As Date
            If borrowerReader.Read Then
                borrowerID = Convert.ToInt32(borrowerReader("borrower_id"))
                dueDate = Convert.ToDateTime(borrowerReader("due_date"))
            Else
                MessageBox.Show("Error: Borrower record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                borrowerReader.Close()
                conn.Close()
                Exit Sub
            End If
            borrowerReader.Close()

            Dim selectedCondition = ComboBox1.SelectedItem.ToString
            Dim selectedConditionID = 0
            Dim conditionQuery = "SELECT condition_id FROM book_condition WHERE condition_status = @ConditionStatus"
            Dim conditionCmd As New MySqlCommand(conditionQuery, conn)
            conditionCmd.Parameters.AddWithValue("@ConditionStatus", selectedCondition)

            Dim conditionReader = conditionCmd.ExecuteReader
            If conditionReader.Read Then
                selectedConditionID = Convert.ToInt32(conditionReader("condition_id"))
            Else
                MessageBox.Show("Error: Condition not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conditionReader.Close()
                conn.Close()
                Exit Sub
            End If
            conditionReader.Close()

            Dim penaltyAmount As Double = 0
            If Date.Now > dueDate Then
                Dim overdueDays = (Date.Now - dueDate).Days
                Dim penaltyInput = InputBox("This book is overdue. Enter penalty amount:", "Overdue Penalty")
                If Not Double.TryParse(penaltyInput, penaltyAmount) Then
                    MessageBox.Show("Invalid penalty amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                    Exit Sub
                End If
            End If

            Dim returnQuery = "INSERT INTO returned_books (BorrowerID, BookID, ConditionID, `Return Date`, `Penalty Fee`) VALUES (@BorrowerID, @BookID, @ConditionID, @ReturnDate, @PenaltyFee)"
            Dim returnCmd As New MySqlCommand(returnQuery, conn)
            returnCmd.Parameters.AddWithValue("@BorrowerID", borrowerID)
            returnCmd.Parameters.AddWithValue("@BookID", accNo)
            returnCmd.Parameters.AddWithValue("@ConditionID", selectedConditionID)
            returnCmd.Parameters.AddWithValue("@ReturnDate", Date.Now.ToString("yyyy-MM-dd"))
            returnCmd.Parameters.AddWithValue("@PenaltyFee", penaltyAmount)
            returnCmd.ExecuteNonQuery()

            Dim deleteQuery = "DELETE FROM books_borrowed WHERE book_id = @Accno"
            Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
            deleteCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteCmd.ExecuteNonQuery()

            MessageBox.Show("Book successfully returned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form4 As New Form4
            form4.Show()
            Hide()
        Catch ex As Exception
            MessageBox.Show("Error during book return: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim accNo = ComboBox2.SelectedItem?.ToString()

        If String.IsNullOrEmpty(accNo) Then
            MessageBox.Show("Please select a book that is lost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Dim borrowerID As Integer = 0
            Dim dueDate As Date
            Dim getBorrowerQuery As String = "SELECT borrower_id, due_date FROM books_borrowed WHERE book_id = @Accno"
            Dim borrowerCmd As New MySqlCommand(getBorrowerQuery, conn, transaction)
            borrowerCmd.Parameters.AddWithValue("@Accno", accNo)
            Dim borrowerReader As MySqlDataReader = borrowerCmd.ExecuteReader()

            If borrowerReader.Read() Then
                borrowerID = Convert.ToInt32(borrowerReader("borrower_id"))
                dueDate = Convert.ToDateTime(borrowerReader("due_date"))
            Else
                MessageBox.Show("Error: Borrower record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                borrowerReader.Close()
                transaction.Rollback()
                conn.Close()
                Exit Sub
            End If
            borrowerReader.Close()

            Dim lostPenaltyInput As String = InputBox("Enter penalty amount for the lost book:", "Lost Book Penalty")
            Dim lostPenaltyAmount As Double
            If Not Double.TryParse(lostPenaltyInput, lostPenaltyAmount) Then
                MessageBox.Show("Invalid penalty amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                transaction.Rollback()
                conn.Close()
                Exit Sub
            End If

            Dim insertLostBookQuery As String = "INSERT INTO lost_books (bookID, BorrowerID, Penalty_fee) VALUES (@BookID, @BorrowerID, @PenaltyFee)"
            Dim insertLostCmd As New MySqlCommand(insertLostBookQuery, conn, transaction)
            insertLostCmd.Parameters.AddWithValue("@BookID", accNo)
            insertLostCmd.Parameters.AddWithValue("@BorrowerID", borrowerID)
            insertLostCmd.Parameters.AddWithValue("@PenaltyFee", lostPenaltyAmount)
            insertLostCmd.ExecuteNonQuery()

            Dim deleteBorrowedQuery As String = "DELETE FROM books_borrowed WHERE book_id = @Accno"
            Dim deleteBorrowedCmd As New MySqlCommand(deleteBorrowedQuery, conn, transaction)
            deleteBorrowedCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteBorrowedCmd.ExecuteNonQuery()

            Dim deleteBookQuery As String = "DELETE FROM books WHERE Accno = @Accno"
            Dim deleteBookCmd As New MySqlCommand(deleteBookQuery, conn, transaction)
            deleteBookCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteBookCmd.ExecuteNonQuery()

            transaction.Commit()

            MessageBox.Show("Book marked as lost and recorded in lost books table.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim form4 As New Form4
            form4.Show()
            Hide()
        Catch ex As Exception
            MessageBox.Show("Error during lost book processing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub
End Class
