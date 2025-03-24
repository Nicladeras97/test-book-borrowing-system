Imports MySql.Data.MySqlClient

Public Class Form12
    Private pageSize As Integer = 20
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private currentFilter As String = ""

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

            Dim filter As String = ""
            If currentFilter <> "" Then
                filter = currentFilter
            End If

            Dim searchQuery As String = ""
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                searchQuery = "AND (ISBN LIKE @Search OR Title LIKE @Search OR Author LIKE @Search OR Year LIKE @Search OR Category LIKE @Search OR Status LIKE @Search OR CallNumber LIKE @Search)"
            End If

            Dim countQuery As String = $"SELECT COUNT(*) FROM book WHERE 1=1 {filter} {searchQuery}"
            Using cmd As New MySqlCommand(countQuery, conn)
                If currentFilter <> "" Then cmd.Parameters.AddWithValue("@Status", currentFilter)
                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim query As String = $"SELECT ISBN, Title, Author, Year, Category, Status, Image, Copies, AddedDate, CallNumber FROM book WHERE 1=1 {filter} {searchQuery} LIMIT {offset}, {pageSize}"

            Using cmd As New MySqlCommand(query, conn)
                If currentFilter <> "" Then cmd.Parameters.AddWithValue("@Status", currentFilter)
                If searchQuery <> "" Then cmd.Parameters.AddWithValue("@Search", $"%{TextBox1.Text.Trim()}%")

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        currentPage = 1
        LoadData()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        currentPage += 1
        LoadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        currentPage -= 1
        LoadData()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Dim form2 As New Form11()
        form2.Show()
        Me.Hide()
    End Sub
End Class
