Imports MySql.Data.MySqlClient

Public Class Form3
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Dim conn As New MySqlConnection(connString)

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadBorrowedBooks()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        LoadBorrowedBooks(TextBox1.Text)
    End Sub

    Private Sub SetupDataGridView()
        With DataGridView1
            .Columns.Clear()
            .Rows.Clear()
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .EnableHeadersVisualStyles = False
            .DefaultCellStyle.Font = New Font("Arial", 9)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowTemplate.Height = 30
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub LoadBorrowedBooks(Optional searchQuery As String = "")
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT borrow.BorrowID, borrow.BookID, book.Title, book.Author, borrow.StudNo, users.FullName, borrow.BorrowDate, borrow.DueDate, book.Image " &
                      "FROM borrow " &
                      "INNER JOIN book ON borrow.BookID = book.BookID " &
                      "INNER JOIN users ON borrow.StudNo = users.StudNo " &
                      "WHERE borrow.StatusName = 'Borrowed' " &
                      "AND (book.Title LIKE @search OR users.FullName LIKE @search)"


            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    DataGridView1.Columns.Add("BorrowID", "Borrow ID")
                    DataGridView1.Columns.Add("BookID", "Book ID")
                    DataGridView1.Columns.Add("Title", "Title")
                    DataGridView1.Columns.Add("Author", "Author")
                    DataGridView1.Columns.Add("StudNo", "Student No")
                    DataGridView1.Columns.Add("FullName", "Borrower Name")
                    DataGridView1.Columns.Add("BorrowDate", "Borrow Date")
                    DataGridView1.Columns.Add("DueDate", "Due Date")

                    Dim returnButton As New DataGridViewButtonColumn()
                    returnButton.Name = "Return"
                    returnButton.HeaderText = "Action"
                    returnButton.Text = "Return"
                    returnButton.UseColumnTextForButtonValue = True
                    DataGridView1.Columns.Add(returnButton)

                    While reader.Read()
                        DataGridView1.Rows.Add(
                            reader("BorrowID").ToString(),
                            reader("BookID").ToString(),
                            reader("Title").ToString(),
                            reader("Author").ToString(),
                            reader("StudNo").ToString(),
                            reader("FullName").ToString(),
                            Convert.ToDateTime(reader("BorrowDate")).ToString("MMM dd, yyyy"),
                            Convert.ToDateTime(reader("DueDate")).ToString("MMM dd, yyyy")
                        )
                    End While
                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = DataGridView1.Columns("Return").Index AndAlso e.RowIndex >= 0 Then
            Dim borrowID As String = DataGridView1.Rows(e.RowIndex).Cells("BorrowID").Value.ToString()
            Dim bookID As String = DataGridView1.Rows(e.RowIndex).Cells("BookID").Value.ToString()
            Dim title As String = DataGridView1.Rows(e.RowIndex).Cells("Title").Value.ToString()
            Dim studentName As String = DataGridView1.Rows(e.RowIndex).Cells("FullName").Value.ToString()
            Dim studNo As String = DataGridView1.Rows(e.RowIndex).Cells("StudNo").Value.ToString()

            Dim imagePath As String = ""
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim imgQuery As String = "SELECT Image FROM book WHERE BookID = @BookID"
                Using cmd As New MySqlCommand(imgQuery, conn)
                    cmd.Parameters.AddWithValue("@BookID", bookID)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        imagePath = reader("Image").ToString()
                    End If
                End Using
            End Using

            'Dim returnForm As New Form9(borrowID, bookID, title, studentName, studNo, imagePath)
            'returnForm.Show()
            'Me.Hide()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New Form11()
        back.Show()
        Me.Hide()
    End Sub
End Class
