Imports MySql.Data.MySqlClient

Public Class Form8
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

    Private isbn As String
    Private title As String
    Private author As String
    Private year As String
    Private category As String
    Private imagePath As String
    Private copies As Integer
    Private callNumber As String
    Private rackNumber As String

    Public Sub New(isbn As String, title As String, author As String, year As String, category As String, imagePath As String, copies As Integer, callNumber As String, rackNumber As String)
        InitializeComponent()
        Me.isbn = isbn
        Me.title = title
        Me.author = author
        Me.year = year
        Me.category = category
        Me.imagePath = imagePath
        Me.copies = copies
        Me.callNumber = callNumber
        Me.rackNumber = rackNumber
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = isbn
        Label2.Text = title
        Label18.Text = author
        Label20.Text = year
        Label22.Text = category
        Label10.Text = copies.ToString()
        Label14.Text = callNumber
        Label15.Text = rackNumber

        If Not String.IsNullOrEmpty(imagePath) AndAlso IO.File.Exists(imagePath) Then
            PictureBox1.Image = Image.FromFile(imagePath)
        Else
            PictureBox1.Image = My.Resources.image
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim studNo = TextBox1.Text.Trim
        If String.IsNullOrEmpty(studNo) Then
            MessageBox.Show("Please enter a Student Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query = "SELECT FullName, ContactNumber, Email FROM users WHERE StudNo = @StudNo"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@StudNo", studNo)

        Try
            conn.Open()
            Dim reader = cmd.ExecuteReader

            If reader.Read Then
                TextBox2.Text = reader("FullName").ToString
                TextBox3.Text = reader("ContactNumber").ToString
                TextBox4.Text = reader("Email").ToString
            Else
                Dim result = MessageBox.Show("Student not found. Enter details?", "New Borrower", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                Else
                    Return
                End If
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studNo As String = TextBox1.Text.Trim()
        Dim name As String = TextBox2.Text.Trim()
        Dim contact As String = TextBox3.Text.Trim()
        Dim email As String = TextBox4.Text.Trim()
        Dim borrowDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim dueDate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim isbn As String = Label3.Text.Trim()

        If String.IsNullOrEmpty(studNo) Or String.IsNullOrEmpty(name) Or String.IsNullOrEmpty(contact) Or String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(isbn) Then
            MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim identifier As String = ""
        Dim identifierType As String = ""

        Try
            conn.Open()

            Dim copyQuery As String = "SELECT CopyID FROM copies WHERE ISBN = @ISBN AND Status = 'Available' LIMIT 1"
            Dim copyCmd As New MySqlCommand(copyQuery, conn)
            copyCmd.Parameters.AddWithValue("@ISBN", isbn)

            Dim copyReader As MySqlDataReader = copyCmd.ExecuteReader()

            If copyReader.Read() Then
                identifier = copyReader("CopyID").ToString()
                identifierType = "CopyID"
            Else
                identifier = Label3.Text.Trim()
                identifierType = "ISBN"
            End If
            copyReader.Close()

            Dim insertQuery As String = "INSERT INTO borrow (StudNo, ISBN, BorrowDate, DueDate, StatusName, Title) " &
                            "VALUES (@StudNo, @ISBN, @BorrowDate, @DueDate, 'Borrowed', @Title)"
            Dim insertCmd As New MySqlCommand(insertQuery, conn)
            insertCmd.Parameters.AddWithValue("@StudNo", studNo)
            insertCmd.Parameters.AddWithValue("@ISBN", identifier)
            insertCmd.Parameters.AddWithValue("@BorrowDate", borrowDate)
            insertCmd.Parameters.AddWithValue("@DueDate", dueDate)
            insertCmd.Parameters.AddWithValue("@Title", Label2.Text.Trim())

            insertCmd.ExecuteNonQuery()

            Dim updateQuery As String = ""

            If identifierType = "CopyID" Then
                updateQuery = "UPDATE copies SET Status = 'Borrowed' WHERE CopyID = @Identifier"
            Else
                updateQuery = "UPDATE book SET Status = 'Borrowed' WHERE ISBN = @Identifier"
            End If

            Dim updateCmd As New MySqlCommand(updateQuery, conn)
            updateCmd.Parameters.AddWithValue("@Identifier", identifier)
            updateCmd.ExecuteNonQuery()

            MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim back As New Form12
            back.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub

End Class
