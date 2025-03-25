Imports MySql.Data.MySqlClient

Public Class Form12
    Private pageSize As Integer = 20
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private currentFilter As String = ""

    ' 🟢 TextBox Search
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        currentPage = 1
        LoadData()
    End Sub

    ' 🟢 Pagination: Previous Page
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadData()
        End If
    End Sub

    ' 🟢 Pagination: Next Page
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            LoadData()
        End If
    End Sub

    ' 🟢 Filter by Status
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString().Trim() <> "All" Then
            currentFilter = $"AND Status = '{ComboBox1.SelectedItem}'"
        Else
            currentFilter = ""
        End If

        currentPage = 1
        LoadData()
    End Sub

    ' 🟢 Back Button
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form2 As New Form11()
        form2.Show()
        Me.Hide()
    End Sub

    ' 🟢 Form Load
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFilterOptions()
        LoadData()
        AddBorrowButton()
    End Sub

    ' 🟢 Load Filter Options
    Private Sub LoadFilterOptions()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Available")
        ComboBox1.Items.Add("Borrowed")
        ComboBox1.Items.Add("Damaged")
        ComboBox1.Items.Add("Lost")
        ComboBox1.SelectedIndex = 0
    End Sub

    ' 🟢 Load Data with Pagination
    Private Sub LoadData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            ' 🔥 Use parameters for filtering
            Dim filter As String = If(currentFilter <> "", currentFilter, "")
            Dim searchQuery As String = ""
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                searchQuery = "AND (ISBN LIKE @Search OR Title LIKE @Search OR Author LIKE @Search OR Year LIKE @Search OR Category LIKE @Search OR Status LIKE @Search OR CallNumber LIKE @Search)"
            End If

            ' ✅ Count total records
            Dim countQuery As String = $"SELECT COUNT(*) FROM book WHERE 1=1 {filter} {searchQuery}"
            Using cmd As New MySqlCommand(countQuery, conn)
                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' ✅ Fetch paginated data
            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim query As String = $"SELECT ISBN, Title, Author, Year, Category, Status, Image, Copies, AddedDate, CallNumber, RackNumber 
                                  FROM book 
                                  WHERE 1=1 {filter} {searchQuery} 
                                  LIMIT @Offset, @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Offset", offset)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)

                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                DataGridView1.DataSource = table
            End Using

            ' ✅ Update pagination label
            Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
            Label2.Text = $"{currentPage}/{totalPages}"

            ' ✅ Disable/Enable navigation buttons
            Button1.Enabled = (currentPage > 1)
            Button2.Enabled = (currentPage < totalPages)

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    ' 🟢 Add "Borrow" button
    Private Sub AddBorrowButton()
        If Not DataGridView1.Columns.Contains("Borrow") Then
            Dim btn As New DataGridViewButtonColumn()
            btn.HeaderText = "Action"
            btn.Name = "Borrow"
            btn.Text = "Borrow"
            btn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(btn)
        End If
    End Sub

    ' 🟢 Handle "Borrow" button click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Borrow").Index Then
            Try
                Dim row = DataGridView1.Rows(e.RowIndex)

                Dim isbn As String = row.Cells("ISBN").Value.ToString()
                Dim title As String = row.Cells("Title").Value.ToString()
                Dim author As String = row.Cells("Author").Value.ToString()
                Dim year As String = row.Cells("Year").Value.ToString()
                Dim category As String = row.Cells("Category").Value.ToString()
                Dim copies As Integer = CInt(row.Cells("Copies").Value)
                Dim callNumber As String = row.Cells("CallNumber").Value.ToString()
                Dim rackNumber As String = row.Cells("RackNumber").Value.ToString()
                Dim imagePath As String = ""

                ' ✅ Fetch image path
                Using conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")
                    conn.Open()

                    Dim query As String = "SELECT Image FROM book WHERE ISBN = @ISBN"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@ISBN", isbn)

                        Dim reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            imagePath = reader("Image").ToString()
                        End If
                    End Using
                End Using

                ' ✅ Open Borrow Form
                Dim borrowForm As New Form8(isbn, title, author, year, category, imagePath, copies, callNumber, rackNumber)
                borrowForm.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
