Imports MySql.Data.MySqlClient

Public Class Form10
    Public Property Accno As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ensure all fields are filled
        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse  ' Title
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse  ' Author
           String.IsNullOrWhiteSpace(TextBox8.Text) OrElse  ' Year
           String.IsNullOrWhiteSpace(TextBox7.Text) OrElse  ' Section
           String.IsNullOrWhiteSpace(TextBox6.Text) OrElse  ' Copies
           String.IsNullOrWhiteSpace(TextBox1.Text) OrElse  ' Call Number
           String.IsNullOrWhiteSpace(TextBox2.Text) Then    ' Rack 

            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim title As String = TextBox3.Text.Trim()
        Dim author As String = TextBox4.Text.Trim()
        Dim year As String = TextBox8.Text.Trim()
        Dim section As String = TextBox7.Text.Trim()
        Dim status As String = "Available"
        Dim copies As Integer

        If Not Integer.TryParse(TextBox6.Text.Trim(), copies) OrElse copies <= 0 Then
            MessageBox.Show("Invalid copies value. Must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim callNumber As String = TextBox1.Text.Trim()
        Dim rack As String = TextBox2.Text.Trim()

        ' Generate Accno based on the section, year, and auto-increment logic
        Dim accno As String = GenerateAccno(section, year)

        ' Insert into the database
        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                ' Insert book details
                Dim query As String = "INSERT INTO book (Accno, Title, Author, Year, Section, Status, Copies, CallNumber, Rack) 
                                       VALUES (@Accno, @Title, @Author, @Year, @Section, @Status, @Copies, @CallNumber, @Rack)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", accno)
                    cmd.Parameters.AddWithValue("@Title", title)
                    cmd.Parameters.AddWithValue("@Author", author)
                    cmd.Parameters.AddWithValue("@Year", year)
                    cmd.Parameters.AddWithValue("@Section", section)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@Copies", copies)
                    cmd.Parameters.AddWithValue("@CallNumber", callNumber)
                    cmd.Parameters.AddWithValue("@Rack", rack)

                    cmd.ExecuteNonQuery()
                End Using

                ' Insert the individual copies based on the generated Accno
                For i As Integer = 1 To copies
                    Dim copyID As String = $"{accno}-{i:D2}" ' Format to 2 digits
                    Dim copyQuery As String = "INSERT INTO copies (CopyID, Accno, Status) VALUES (@CopyID, @Accno, 'Available')"
                    Using cmd As New MySqlCommand(copyQuery, conn)
                        cmd.Parameters.AddWithValue("@CopyID", copyID)
                        cmd.Parameters.AddWithValue("@Accno", accno)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Function to generate Accno
    Private Function GenerateAccno(section As String, year As String) As String
        ' Get the first 3 letters of the section
        Dim sectionPrefix As String = section.Substring(0, 3).ToUpper()

        ' Get the latest Accno to find the next auto-incremented number
        Dim connString As String = "server=localhost; user=root; password=; database=book-borrowing;"
        Using conn As New MySqlConnection(connString)
            conn.Open()

            Dim query As String = "SELECT Accno FROM book WHERE Section = @Section AND Year = @Year ORDER BY Accno DESC LIMIT 1"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Section", section)
                cmd.Parameters.AddWithValue("@Year", year)
                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    ' Extract the last incremented number from the Accno
                    Dim lastAccno As String = result.ToString()
                    Dim lastNumber As Integer = Convert.ToInt32(lastAccno.Substring(6)) + 1
                    Return $"{sectionPrefix}{year}-{lastNumber:D4}"
                Else
                    ' If no records found, start from 0001
                    Return $"{sectionPrefix}{year}-0001"
                End If
            End Using
        End Using
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim close As New Form5
        close.Show()
        Me.Close()
    End Sub
End Class
