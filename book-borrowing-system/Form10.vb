Imports MySql.Data.MySqlClient

Public Class Form10
    Public Property Accno As String = ""

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
    End Sub

    Private Sub ValidateFields()
        Button1.Enabled = Not (String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox5.Text) OrElse
                           String.IsNullOrWhiteSpace(TextBox9.Text))
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged,
                                                                          TextBox4.TextChanged,
                                                                          TextBox8.TextChanged,
                                                                          TextBox7.TextChanged,
                                                                          TextBox1.TextChanged,
                                                                          TextBox2.TextChanged,
                                                                          TextBox5.TextChanged,
                                                                          TextBox9.TextChanged
        ValidateFields()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse  ' Title
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse  ' Author
           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse  ' Year
           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse  ' Section
           String.IsNullOrWhiteSpace(TextBox1.Text) OrElse  ' Call Number
           String.IsNullOrWhiteSpace(TextBox2.Text) OrElse  ' Rack
           String.IsNullOrWhiteSpace(TextBox5.Text) OrElse  ' Publisher
           String.IsNullOrWhiteSpace(TextBox9.Text) Then    ' ISBN

            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim title As String = TextBox3.Text.Trim()
        Dim author As String = TextBox4.Text.Trim()
        Dim year As String = TextBox8.Text.Trim()
        Dim section As String = TextBox7.Text.Trim()
        Dim publisher As String = TextBox5.Text.Trim()
        Dim isbn As String = TextBox9.Text.Trim()
        Dim callNumber As String = TextBox1.Text.Trim()
        Dim rack As String = TextBox2.Text.Trim()
        Dim addedDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim copies As Integer
        If Not Integer.TryParse(TextBox6.Text.Trim(), copies) OrElse copies <= 0 Then
            MessageBox.Show("Invalid copies value. Must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim accnoList As List(Of String) = GenerateAccnos(copies)

        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                For Each accno As String In accnoList
                    Dim query As String = "INSERT INTO books (Accno, Title, Author, Year, Publisher, ISBN, Section, CallNumber, Rack, AddedDate) 
                                           VALUES (@Accno, @Title, @Author, @Year, @Publisher, @ISBN, @Section, @CallNumber, @Rack, @AddedDate)"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Accno", accno)
                        cmd.Parameters.AddWithValue("@Title", title)
                        cmd.Parameters.AddWithValue("@Author", author)
                        cmd.Parameters.AddWithValue("@Year", year)
                        cmd.Parameters.AddWithValue("@Publisher", publisher)
                        cmd.Parameters.AddWithValue("@ISBN", isbn)
                        cmd.Parameters.AddWithValue("@Section", section)
                        cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                        cmd.Parameters.AddWithValue("@Rack", rack)
                        cmd.Parameters.AddWithValue("@AddedDate", addedDate)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("Book(s) added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Private Function GenerateAccnos(copies As Integer) As List(Of String)
        Dim accnoList As New List(Of String)
        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Dim currentYear As String = DateTime.Now.Year.ToString()
        Dim lastNumber As Integer = 0

        Using conn As New MySqlConnection(connString)
            conn.Open()

            Dim query As String = $"SELECT MAX(Accno) FROM books WHERE Accno LIKE '{currentYear}%'"
            Using cmd As New MySqlCommand(query, conn)
                Dim lastAccno As Object = cmd.ExecuteScalar()
                If lastAccno IsNot DBNull.Value AndAlso lastAccno IsNot Nothing Then
                    Dim lastAccnoStr As String = lastAccno.ToString()
                    If lastAccnoStr.Length >= 10 Then
                        Dim numPart As String = lastAccnoStr.Substring(4, 6)
                        Integer.TryParse(numPart, lastNumber)
                    End If
                End If
            End Using

            For i As Integer = 1 To copies
                lastNumber += 1
                Dim accno As String = $"{currentYear}{lastNumber:000000}-01"
                accnoList.Add(accno)
            Next
        End Using

        Return accnoList
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim close As New Form15
        close.Show()
        Me.Hide()
    End Sub
End Class
