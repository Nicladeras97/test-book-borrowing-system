Imports MySql.Data.MySqlClient

Public Class Form9
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing")
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            ComboBox2.Focus()
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDown
            Dim query As String = "SELECT condition_id, condition_status FROM book_condition WHERE condition_id NOT IN (3, 4)"
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
        Dim accNo As String = ComboBox2.Text

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

    'Return Good
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim accNo = ComboBox2.SelectedItem?.ToString()

        If String.IsNullOrEmpty(accNo) Then
            MessageBox.Show("Please select a book to return.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            Dim borrowerID As Integer = 0
            Dim dueDate As Date
            Dim originalConditionID As Integer

            Dim getBorrowerQuery = "SELECT borrower_id, due_date, condition_id FROM books_borrowed WHERE book_id = @Accno"
            Dim borrowerCmd As New MySqlCommand(getBorrowerQuery, conn)
            borrowerCmd.Parameters.AddWithValue("@Accno", accNo)

            Dim borrowerReader = borrowerCmd.ExecuteReader()

            If borrowerReader.Read() Then
                borrowerID = Convert.ToInt32(borrowerReader("borrower_id"))
                dueDate = Convert.ToDateTime(borrowerReader("due_date"))
                originalConditionID = Convert.ToInt32(borrowerReader("condition_id"))
            Else
                MessageBox.Show("Error: Borrower record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                borrowerReader.Close()
                conn.Close()
                Exit Sub
            End If
            borrowerReader.Close()

            Dim selectedCondition = ComboBox1.SelectedItem.ToString()
            Dim selectedConditionID As Integer
            Dim conditionQuery = "SELECT condition_id FROM book_condition WHERE condition_status = @ConditionStatus"
            Dim conditionCmd As New MySqlCommand(conditionQuery, conn)
            conditionCmd.Parameters.AddWithValue("@ConditionStatus", selectedCondition)

            Dim conditionReader = conditionCmd.ExecuteReader()

            If conditionReader.Read() Then
                selectedConditionID = Convert.ToInt32(conditionReader("condition_id"))
            Else
                MessageBox.Show("Error: Condition not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conditionReader.Close()
                conn.Close()
                Exit Sub
            End If
            conditionReader.Close()

            If selectedConditionID <> originalConditionID Then
                MessageBox.Show("The condition of the book has changed. You cannot return it until the condition is verified and updated.", "Condition Change", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                conn.Close()
                Exit Sub
            End If

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

            If penaltyAmount > 0 Then
                returnCmd.Parameters.AddWithValue("@PenaltyFee", penaltyAmount)
            Else
                returnCmd.Parameters.AddWithValue("@PenaltyFee", 0)
            End If

            returnCmd.ExecuteNonQuery()

            Dim deleteQuery = "DELETE FROM books_borrowed WHERE book_id = @Accno"
            Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
            deleteCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteCmd.ExecuteNonQuery()

            MessageBox.Show("Book successfully returned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim menu As New Form15
            menu.Show()
            Hide()

        Catch ex As Exception
            MessageBox.Show("Error during book return: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    'Returned Damaged
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim accNo = ComboBox2.SelectedItem?.ToString()

        If String.IsNullOrEmpty(accNo) Then
            MessageBox.Show("Please select a book that is damaged.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            Dim originalConditionID As Integer
            Dim borrowerID As Integer
            Dim getBorrowerQuery = "SELECT borrower_id, condition_id FROM books_borrowed WHERE book_id = @Accno"
            Dim borrowerCmd As New MySqlCommand(getBorrowerQuery, conn)
            borrowerCmd.Parameters.AddWithValue("@Accno", accNo)
            Dim borrowerReader = borrowerCmd.ExecuteReader()

            If borrowerReader.Read() Then
                borrowerID = Convert.ToInt32(borrowerReader("borrower_id"))
                originalConditionID = Convert.ToInt32(borrowerReader("condition_id"))
            Else
                MessageBox.Show("Error: Borrower record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                borrowerReader.Close()
                conn.Close()
                Exit Sub
            End If
            borrowerReader.Close()

            Dim damagePenaltyInput = InputBox("Enter penalty amount for the damaged book:", "Damage Penalty")
            Dim damagePenaltyAmount As Double
            If Not Double.TryParse(damagePenaltyInput, damagePenaltyAmount) Then
                MessageBox.Show("Invalid penalty amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                Exit Sub
            End If

            Dim damageQuery = "INSERT INTO returned_books (BorrowerID, BookID, ConditionID, `Return Date`, `Penalty Fee`) VALUES (@BorrowerID, @BookID, 3, @ReturnDate, @PenaltyFee)"
            Dim damageCmd As New MySqlCommand(damageQuery, conn)
            damageCmd.Parameters.AddWithValue("@BorrowerID", borrowerID)
            damageCmd.Parameters.AddWithValue("@BookID", accNo)
            damageCmd.Parameters.AddWithValue("@ReturnDate", Date.Now.ToString("yyyy-MM-dd"))
            damageCmd.Parameters.AddWithValue("@PenaltyFee", damagePenaltyAmount)
            damageCmd.ExecuteNonQuery()

            Dim result As DialogResult = MessageBox.Show("Do you want to mark this book for repair?", "Repair Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Dim checkRepairQuery = "SELECT COUNT(*) FROM books_deleted WHERE Accno = @Accno"
                Dim checkRepairCmd As New MySqlCommand(checkRepairQuery, conn)
                checkRepairCmd.Parameters.AddWithValue("@Accno", accNo)
                Dim repairCount As Integer = Convert.ToInt32(checkRepairCmd.ExecuteScalar())

                If repairCount > 0 Then
                    MessageBox.Show("This book is already marked for repair.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim repairQuery = "INSERT INTO books_deleted (Accno, Title, Author, Year, Publisher, ISBN, Section, CallNumber, Rack, ConditionID, DeletedDate, borrower_id) " &
                                        "SELECT b.Accno, b.Title, b.Author, b.Year, b.Publisher, b.ISBN, b.Section, b.CallNumber, b.Rack, 5, @DeletionDate, r.BorrowerID " &
                                        "FROM books b JOIN returned_books r ON b.Accno = r.BookID WHERE r.BookID = @Accno AND r.ConditionID = 3"

                    Dim repairCmd As New MySqlCommand(repairQuery, conn)
                    repairCmd.Parameters.AddWithValue("@DeletionDate", Date.Now.ToString("yyyy-MM-dd"))
                    repairCmd.Parameters.AddWithValue("@Accno", accNo)
                    repairCmd.ExecuteNonQuery()

                    Dim removeBorrowedQuery = "DELETE FROM books_borrowed WHERE book_id = @Accno"
                    Dim removeBorrowedCmd As New MySqlCommand(removeBorrowedQuery, conn)
                    removeBorrowedCmd.Parameters.AddWithValue("@Accno", accNo)
                    removeBorrowedCmd.ExecuteNonQuery()

                    Dim deleteQuery = "DELETE FROM books WHERE Accno = @Accno"
                    Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
                    deleteCmd.Parameters.AddWithValue("@Accno", accNo)
                    deleteCmd.ExecuteNonQuery()

                    MessageBox.Show("Book marked for repair, moved to the deleted books list, and removed from the borrowing records.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim removeBorrowedQuery = "DELETE FROM books_borrowed WHERE book_id = @Accno"
                Dim removeBorrowedCmd As New MySqlCommand(removeBorrowedQuery, conn)
                removeBorrowedCmd.Parameters.AddWithValue("@Accno", accNo)
                removeBorrowedCmd.ExecuteNonQuery()

                MessageBox.Show("Book marked as damaged and remains available for borrowing.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            Dim menu As New Form15
            menu.Show()
            Hide()

        Catch ex As Exception
            MessageBox.Show("Error during damaged book processing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    'Lost
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
            Dim bookData As New Dictionary(Of String, String)

            Dim getBookQuery As String = "SELECT * FROM books WHERE Accno = @Accno"
            Dim bookCmd As New MySqlCommand(getBookQuery, conn, transaction)
            bookCmd.Parameters.AddWithValue("@Accno", accNo)
            Dim bookReader As MySqlDataReader = bookCmd.ExecuteReader()

            If bookReader.Read() Then
                bookData("Title") = bookReader("Title").ToString()
                bookData("Author") = bookReader("Author").ToString()
                bookData("Year") = bookReader("Year").ToString()
                bookData("Publisher") = bookReader("Publisher").ToString()
                bookData("ISBN") = bookReader("ISBN").ToString()
                bookData("Section") = bookReader("Section").ToString()
                bookData("CallNumber") = bookReader("CallNumber").ToString()
                bookData("Rack") = bookReader("Rack").ToString()
            Else
                MessageBox.Show("Error: Book record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bookReader.Close()
                transaction.Rollback()
                conn.Close()
                Exit Sub
            End If
            bookReader.Close()

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

            Dim insertLostBookQuery As String = "INSERT INTO returned_books (BorrowerID, BookID, ConditionID, `Return Date`, `Penalty Fee`) VALUES (@BorrowerID, @BookID, 4, @ReturnDate, @PenaltyFee)"
            Dim insertLostCmd As New MySqlCommand(insertLostBookQuery, conn, transaction)
            insertLostCmd.Parameters.AddWithValue("@BorrowerID", borrowerID)
            insertLostCmd.Parameters.AddWithValue("@BookID", accNo)
            insertLostCmd.Parameters.AddWithValue("@ReturnDate", Date.Now.ToString("yyyy-MM-dd"))
            insertLostCmd.Parameters.AddWithValue("@PenaltyFee", lostPenaltyAmount)
            insertLostCmd.ExecuteNonQuery()

            Dim insertDeletedQuery As String = "INSERT INTO books_deleted (Accno, Title, Author, Year, Publisher, ISBN, Section, CallNumber, Rack, ConditionID, borrower_id) VALUES (@Accno, @Title, @Author, @Year, @Publisher, @ISBN, @Section, @CallNumber, @Rack, 4, @borrower_id)"
            Dim insertDeletedCmd As New MySqlCommand(insertDeletedQuery, conn, transaction)
            insertDeletedCmd.Parameters.AddWithValue("@Accno", accNo)
            insertDeletedCmd.Parameters.AddWithValue("@Title", bookData("Title"))
            insertDeletedCmd.Parameters.AddWithValue("@Author", bookData("Author"))
            insertDeletedCmd.Parameters.AddWithValue("@Year", bookData("Year"))
            insertDeletedCmd.Parameters.AddWithValue("@Publisher", bookData("Publisher"))
            insertDeletedCmd.Parameters.AddWithValue("@ISBN", bookData("ISBN"))
            insertDeletedCmd.Parameters.AddWithValue("@Section", bookData("Section"))
            insertDeletedCmd.Parameters.AddWithValue("@CallNumber", bookData("CallNumber"))
            insertDeletedCmd.Parameters.AddWithValue("@Rack", bookData("Rack"))
            insertDeletedCmd.Parameters.AddWithValue("@borrower_id", borrowerID)
            insertDeletedCmd.ExecuteNonQuery()

            Dim deleteBorrowedQuery As String = "DELETE FROM books_borrowed WHERE book_id = @Accno"
            Dim deleteBorrowedCmd As New MySqlCommand(deleteBorrowedQuery, conn, transaction)
            deleteBorrowedCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteBorrowedCmd.ExecuteNonQuery()

            Dim deleteBookQuery As String = "DELETE FROM books WHERE Accno = @Accno"
            Dim deleteBookCmd As New MySqlCommand(deleteBookQuery, conn, transaction)
            deleteBookCmd.Parameters.AddWithValue("@Accno", accNo)
            deleteBookCmd.ExecuteNonQuery()

            transaction.Commit()

            MessageBox.Show("Book marked as lost.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim menu As New Form15
            menu.Show()
            Hide()
        Catch ex As Exception
            MessageBox.Show("Error during lost book processing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs)
        Dim back As New Form15
        back.Show()
        Hide()
    End Sub

End Class
