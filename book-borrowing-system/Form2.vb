Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form2
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"
    Dim conn As New MySqlConnection(connString)

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadAvailableBooks()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        LoadAvailableBooks(TextBox1.Text)
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

    Private Sub LoadAvailableBooks(Optional searchQuery As String = "")
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Using conn As New MySqlConnection(connString)
            Dim query As String = "SELECT BookID, Title, Author, Copies, Image FROM book " &
                              "WHERE Status = 'Available' " &
                              "AND Copies > 0 " &
                              "AND (Title LIKE @search OR Author LIKE @search)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")

                Try
                    conn.Open()
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    DataGridView1.Columns.Add("BookID", "Book ID")
                    DataGridView1.Columns.Add("Title", "Title")
                    DataGridView1.Columns.Add("Author", "Author")
                    DataGridView1.Columns.Add("Copies", "Copies")

                    Dim borrowButton As New DataGridViewButtonColumn()
                    borrowButton.Name = "Borrow"
                    borrowButton.HeaderText = "Action"
                    borrowButton.Text = "Borrow"
                    borrowButton.UseColumnTextForButtonValue = True
                    DataGridView1.Columns.Add(borrowButton)

                    While reader.Read()
                        DataGridView1.Rows.Add(
                        reader("BookID").ToString(),
                        reader("Title").ToString(),
                        reader("Author").ToString(),
                        reader("Copies").ToString()
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

        If e.ColumnIndex = DataGridView1.Columns("Borrow").Index AndAlso e.RowIndex >= 0 Then
            Dim bookID As String = DataGridView1.Rows(e.RowIndex).Cells("BookID").Value.ToString()
            Dim title As String = DataGridView1.Rows(e.RowIndex).Cells("Title").Value.ToString()
            Dim author As String = DataGridView1.Rows(e.RowIndex).Cells("Author").Value.ToString()
            Dim copies As String = DataGridView1.Rows(e.RowIndex).Cells("Copies").Value.ToString()

            Dim borrowForm As New Form8(bookID, title, author, copies, author)
            borrowForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New Form11()
        back.Show()
        Me.Hide()
    End Sub
End Class
