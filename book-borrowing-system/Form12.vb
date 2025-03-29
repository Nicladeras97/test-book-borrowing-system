Imports MySql.Data.MySqlClient

Public Class Form12
    Private pageSize As Integer = 20
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not DataGridView1.Columns.Contains("Borrow") Then
            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.Name = "Borrow"
            btnColumn.HeaderText = "Action"
            btnColumn.Text = "Borrow"
            btnColumn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(btnColumn)
        End If

        LoadData()
    End Sub

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

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form2 As New Form11()
        form2.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = DataGridView1.Columns("Borrow").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim accNo As String = DataGridView1.Rows(e.RowIndex).Cells("Accession No").Value?.ToString()
                Dim title As String = DataGridView1.Rows(e.RowIndex).Cells("Title").Value?.ToString()
                Dim author As String = DataGridView1.Rows(e.RowIndex).Cells("Author").Value?.ToString()
                Dim year As String = DataGridView1.Rows(e.RowIndex).Cells("Year").Value?.ToString()
                Dim publisher As String = DataGridView1.Rows(e.RowIndex).Cells("Publisher").Value?.ToString()
                Dim isbn As String = DataGridView1.Rows(e.RowIndex).Cells("ISBN").Value?.ToString()
                Dim section As String = DataGridView1.Rows(e.RowIndex).Cells("Section").Value?.ToString()
                Dim rack As String = DataGridView1.Rows(e.RowIndex).Cells("Rack").Value?.ToString()
                Dim callnumber As String = DataGridView1.Rows(e.RowIndex).Cells("CallNumber").Value?.ToString()

                Dim form8 As New Form8(accNo, title, author, year, publisher, isbn, section, rack, callnumber)
                form8.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}")
            End Try
        End If
    End Sub


    Private Sub LoadData()
        Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

        Try
            conn.Open()

            Dim searchQuery As String = ""
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                searchQuery = "AND (b.Title LIKE @Search OR b.Author LIKE @Search OR b.Accno LIKE @Search OR b.Section LIKE @Search)"
            End If

            Dim countQuery As String = $"
                SELECT COUNT(*) 
                FROM books b
                LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id
                WHERE bb.book_id IS NULL {searchQuery}"

            Using cmd As New MySqlCommand(countQuery, conn)
                If searchQuery <> "" Then
                    cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                End If
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim query As String = $"
                SELECT 
                    b.Accno AS `Accession No`,
                    b.Title AS `Title`,
                    b.Author AS `Author`,
                    b.Year AS `Year`,
                    b.Section AS `Section`,
                    b.AddedDate AS `Date Added`,
                    b.CallNumber AS `CallNumber`,
                    b.Rack AS `Rack`,
                    b.Publisher AS `Publisher`,
                    b.ISBN As `ISBN`
                FROM books b
                LEFT JOIN books_borrowed bb ON b.Accno = bb.book_id
                WHERE bb.book_id IS NULL {searchQuery}
                LIMIT @Offset, @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Offset", offset)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)
                If searchQuery <> "" Then
                    cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
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

End Class
