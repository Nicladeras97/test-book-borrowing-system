Imports MySql.Data.MySqlClient

Public Class Form12
    Private pageSize As Integer = 20
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private currentFilter As String = ""

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        currentPage = 1
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadData()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            LoadData()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString().Trim() <> "All" Then
            currentFilter = $"AND Status = '{ComboBox1.SelectedItem}'"
        Else
            currentFilter = ""
        End If

        currentPage = 1
        LoadData()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form2 As New Form11()
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFilterOptions()
        LoadData()
    End Sub

    Private Sub LoadFilterOptions()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Available")
        ComboBox1.Items.Add("Borrowed")
        ComboBox1.Items.Add("Damaged")
        ComboBox1.Items.Add("Lost")
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub LoadData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim filter As String = If(currentFilter <> "", currentFilter, "")
            Dim searchQuery As String = ""
            Dim excludeLost As String = "AND Status != 'Removed'"

            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                searchQuery = "AND (ISBN LIKE @Search OR BookID LIKE @Search OR Title LIKE @Search OR Author LIKE @Search OR Year LIKE @Search OR Section LIKE @Search OR Publisher LIKE @Search OR Status LIKE @Search OR CallNumber LIKE @Search)"
            End If

            Dim countQuery As String = $"SELECT COUNT(*) FROM book WHERE 1=1 {filter} {searchQuery} {excludeLost}"
            Using cmd As New MySqlCommand(countQuery, conn)
                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim query As String = "SELECT b.BookID, b.ISBN, b.Title, b.Author, b.Year, b.Section, b.Publisher, b.Status, b.Copies, b.AddedDate, b.CallNumber, b.Rack, " &
                                  "br.StudNo, br.BorrowID " &
                                  "FROM book b " &
                                  "LEFT JOIN borrow br ON b.BookID = br.BookID " &
                                  "WHERE 1=1 " & filter & searchQuery & excludeLost & " " &
                                  "LIMIT @Offset, @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Offset", offset)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)
                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table

                If DataGridView1.Columns.Contains("StudNo") Then
                    DataGridView1.Columns("StudNo").Visible = False
                End If
                If DataGridView1.Columns.Contains("BorrowID") Then
                    DataGridView1.Columns("BorrowID").Visible = False
                End If

                AddOrUpdateButtonColumn()
            End Using

            Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
            Label2.Text = $"{currentPage}/{totalPages}"
            Button1.Enabled = (currentPage > 1)
            Button2.Enabled = (currentPage < totalPages)

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub AddOrUpdateButtonColumn()
        If DataGridView1.Columns.Contains("Action") Then
            DataGridView1.Columns.Remove("Action")
        End If

        Dim btn As New DataGridViewButtonColumn()
        btn.HeaderText = "Action"
        btn.Name = "Action"
        btn.Text = "Action"
        btn.UseColumnTextForButtonValue = False
        DataGridView1.Columns.Add(btn)

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("Status").Value IsNot Nothing Then
                Dim status As String = row.Cells("Status").Value.ToString()
                If status = "Available" Then
                    row.Cells("Action").Value = "Borrow"
                ElseIf status = "Borrowed" OrElse status = "Damaged" OrElse status = "Lost" Then
                    row.Cells("Action").Value = "Return"
                End If
            End If
        Next
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Action").Index Then
            Try
                Dim row = DataGridView1.Rows(e.RowIndex)

                Dim borrowID As String = ""
                If row.Cells("BorrowID").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("BorrowID").Value) Then
                    borrowID = row.Cells("BorrowID").Value.ToString()
                Else
                    borrowID = "0"
                End If

                Dim borrowIDNum As Integer
                If Not Integer.TryParse(borrowID, borrowIDNum) Then
                    borrowIDNum = 0
                End If

                Dim bookID As String = row.Cells("BookID").Value.ToString()
                Dim isbn As String = row.Cells("ISBN").Value.ToString()
                Dim title As String = row.Cells("Title").Value.ToString()
                Dim author As String = row.Cells("Author").Value.ToString()
                Dim year As String = row.Cells("Year").Value.ToString()
                Dim section As String = row.Cells("Section").Value.ToString()
                Dim publisher As String = row.Cells("Publisher").Value.ToString()
                Dim status As String = row.Cells("Status").Value.ToString()
                Dim callNumber As String = row.Cells("CallNumber").Value.ToString()
                Dim studNo As String = ""

                If row.Cells("StudNo").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("StudNo").Value) Then
                    studNo = row.Cells("StudNo").Value.ToString()
                End If

                Dim rack As String = row.Cells("Rack").Value.ToString()

                Dim copies As Integer = 0
                If Not IsDBNull(row.Cells("Copies").Value) AndAlso Integer.TryParse(row.Cells("Copies").Value.ToString(), copies) Then
                    copies = Convert.ToInt32(row.Cells("Copies").Value)
                End If

                Select Case status
                    Case "Available"
                        Dim form8 As New Form8(bookID, title, author, year, section, publisher, isbn, callNumber, rack)
                        form8.Show()

                    Case "Borrowed"
                        Dim returnForm As New Form9(bookID, title, author, year, section, copies, callNumber, rack, borrowIDNum.ToString(), studNo, publisher)
                        returnForm.Show()

                    Case "Damaged"
                        Dim result As DialogResult = MessageBox.Show("Has the book been repaired and the fine paid?", "Confirm Repair", MessageBoxButtons.YesNo)
                        If result = DialogResult.Yes Then
                            Using conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
                                conn.Open()
                                Dim query As String = "UPDATE book SET Status = 'Available' WHERE BookID = @BookID"
                                Using cmd As New MySqlCommand(query, conn)
                                    cmd.Parameters.AddWithValue("@BookID", bookID)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End Using
                            LoadData()
                        End If
                End Select

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}")
            End Try
        End If
    End Sub


End Class
