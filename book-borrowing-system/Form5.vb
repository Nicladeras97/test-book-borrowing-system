Imports MySql.Data.MySqlClient

Public Class Form5
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox2.Items.Add("1")
            ComboBox2.Items.Add("10")
            ComboBox2.Items.Add("25")
            ComboBox2.Items.Add("50")
            ComboBox2.Items.Add("100")
            ComboBox2.Items.Add("500")
            ComboBox2.SelectedIndex = 0
            LoadRepairBooks(25)
        Catch ex As Exception
            MessageBox.Show("Error loading repair books: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRepairBooks(recordCount As Integer)
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim query As String = "SELECT Accno, Title, CallNumber, Rack FROM books_deleted WHERE ConditionID = 5 LIMIT @RecordCount"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@RecordCount", recordCount)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ComboBox1.Items.Clear()
                While reader.Read()
                    ComboBox1.Items.Add(reader("Accno").ToString())
                End While
                reader.Close()

                Dim dgvQuery As String = "SELECT Accno, Title, CallNumber, Rack FROM books_deleted WHERE ConditionID = 5 LIMIT @RecordCount"
                Dim dgvCmd As New MySqlCommand(dgvQuery, conn)
                dgvCmd.Parameters.AddWithValue("@RecordCount", recordCount)
                Dim dgvAdapter As New MySqlDataAdapter(dgvCmd)
                Dim dgvTable As New DataTable()
                dgvAdapter.Fill(dgvTable)
                DataGridView1.DataSource = dgvTable

            Catch ex As MySqlException
                MessageBox.Show("Database error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error loading repair books: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim recordCount As Integer = Convert.ToInt32(ComboBox2.SelectedItem.ToString())

        LoadRepairBooks(recordCount)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedAccNo = ComboBox1.SelectedItem?.ToString()

        If String.IsNullOrEmpty(selectedAccNo) Then
            MessageBox.Show("Please select a book to return.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim result = MessageBox.Show("Is the book repaired?", "Repair Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(connString)
                    conn.Open()

                    Dim query As String = "SELECT * FROM books_deleted WHERE Accno = @Accno"
                    Dim cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        Dim title = reader("Title").ToString()
                        Dim author = reader("Author").ToString()
                        Dim year = reader("Year").ToString()
                        Dim publisher = reader("Publisher").ToString()
                        Dim isbn = reader("ISBN").ToString()
                        Dim section = reader("Section").ToString()
                        Dim callNumber = reader("CallNumber").ToString()
                        Dim rack = reader("Rack").ToString()

                        reader.Close()

                        Dim insertQuery As String = "INSERT INTO books (Accno, Title, Author, Year, Publisher, ISBN, Section, CallNumber, Rack) " &
                                                    "VALUES (@Accno, @Title, @Author, @Year, @Publisher, @ISBN, @Section, @CallNumber, @Rack)"
                        Dim insertCmd As New MySqlCommand(insertQuery, conn)
                        insertCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                        insertCmd.Parameters.AddWithValue("@Title", title)
                        insertCmd.Parameters.AddWithValue("@Author", author)
                        insertCmd.Parameters.AddWithValue("@Year", year)
                        insertCmd.Parameters.AddWithValue("@Publisher", publisher)
                        insertCmd.Parameters.AddWithValue("@ISBN", isbn)
                        insertCmd.Parameters.AddWithValue("@Section", section)
                        insertCmd.Parameters.AddWithValue("@CallNumber", callNumber)
                        insertCmd.Parameters.AddWithValue("@Rack", rack)
                        insertCmd.ExecuteNonQuery()

                        Dim deleteQuery As String = "DELETE FROM books_deleted WHERE Accno = @Accno"
                        Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                        deleteCmd.ExecuteNonQuery()

                        MessageBox.Show("Book successfully returned to the books table.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim recordCount As Integer = Convert.ToInt32(ComboBox2.SelectedItem.ToString())
                        LoadRepairBooks(recordCount)
                    Else
                        MessageBox.Show("Book not found in the returned_books table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Database error while returning book: " & ex.Message & vbCrLf & ex.StackTrace, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error returning repaired book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
