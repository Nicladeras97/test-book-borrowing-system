Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class Form5
    Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing"

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ComboBox1.Font = New Font("Arial", 16, FontStyle.Regular)
            ComboBox2.Font = New Font("Arial", 16, FontStyle.Regular)

            ComboBox1.DrawMode = DrawMode.OwnerDrawFixed
            ComboBox2.DrawMode = DrawMode.OwnerDrawFixed

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
            ComboBox1.Focus()

            ComboBox2.Items.Add("1")
            ComboBox2.Items.Add("10")
            ComboBox2.Items.Add("25")
            ComboBox2.Items.Add("50")
            ComboBox2.Items.Add("100")
            ComboBox2.Items.Add("500")
            ComboBox2.Items.Add("1000")
            ComboBox2.SelectedIndex = 1

            LoadRepairBooks(25)
        Catch ex As Exception
            MessageBox.Show("Error loading repair books: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        If e.Index < 0 Then Return
        e.DrawBackground()
        Using myFont As New Font("Arial", 16)
            e.Graphics.DrawString(ComboBox1.Items(e.Index).ToString(), myFont, Brushes.Black, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub


    Private Sub ComboBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox2.DrawItem
        If e.Index < 0 Then Return
        e.DrawBackground()
        Using myFont As New Font("Arial", 16)
            e.Graphics.DrawString(ComboBox2.Items(e.Index).ToString(), myFont, Brushes.Black, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Button1.PerformClick()
        End If
    End Sub

    Private Sub LoadRepairBooks(recordCount As Integer)
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT b.Accno, b.Title, b.CallNumber, b.Rack, b.`Penalty Fee` " &
                                      "FROM books_deleted b WHERE b.ConditionID = 5 LIMIT @RecordCount"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@RecordCount", recordCount)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ComboBox1.Items.Clear()
                While reader.Read()
                    ComboBox1.Items.Add(reader("Accno").ToString())
                End While
                reader.Close()


                Dim dgvQuery As String = "SELECT b.Accno, b.Title, b.CallNumber, b.Rack, b.`Penalty Fee` " &
                                         "FROM books_deleted b WHERE b.ConditionID = 5 LIMIT @RecordCount"
                Dim dgvCmd As New MySqlCommand(dgvQuery, conn)
                dgvCmd.Parameters.AddWithValue("@RecordCount", recordCount)
                Dim dgvAdapter As New MySqlDataAdapter(dgvCmd)
                Dim dgvTable As New DataTable()
                dgvAdapter.Fill(dgvTable)
                DataGridView1.DataSource = dgvTable
                DataGridView1.Columns(4).HeaderText = "Penalty Fee"

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
        Dim selectedAccNo = ComboBox1.Text.Trim()

        If String.IsNullOrEmpty(selectedAccNo) Then
            MessageBox.Show("Please scan or enter an Accession Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim checkQuery As String = "SELECT * FROM books_deleted WHERE Accno = @Accno AND ConditionID = 5"
                Dim checkCmd As New MySqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                Dim reader As MySqlDataReader = checkCmd.ExecuteReader()

                If Not reader.Read() Then
                    reader.Close()
                    MessageBox.Show("Book not found in the repair list.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim result = MessageBox.Show("Is the book repaired?", "Repair Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
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
                    ComboBox1.Text = ""
                    ComboBox1.Focus()
                Else
                    reader.Close()
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error while returning book: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error returning repaired book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
