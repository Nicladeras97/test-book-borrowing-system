Imports MySql.Data.MySqlClient

Public Class Form8
    Dim connString As String = "server=localhost;user id=root;password=;database=book-borrowing"

    Private accno As String
    Private title As String
    Private author As String
    Private year As String
    Private section As String
    Private publisher As String
    Private copies As Integer
    Private callNumber As String
    Private rack As String

    Public Sub New(accno As String, title As String, author As String, year As String, section As String, publisher As String, copies As Integer, callNumber As String, rack As String)
        InitializeComponent()
        Me.accno = accno
        Me.title = title
        Me.author = author
        Me.year = year
        Me.section = section
        Me.publisher = publisher
        Me.copies = copies
        Me.callNumber = callNumber
        Me.rack = rack
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label18.Text = accno
        Label2.Text = title
        Label20.Text = author
        Label22.Text = year
        Label26.Text = section
        Label3.Text = publisher
        'Label10.Text = copies.ToString()
        Label14.Text = callNumber
        Label15.Text = rack
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim studNo = TextBox1.Text.Trim()

        If String.IsNullOrEmpty(studNo) Then
            MessageBox.Show("Please enter a Student Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim query = "SELECT FullName, ContactNumber, Email, YearSection, Course FROM users WHERE StudNo = @StudNo"

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudNo", studNo)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox2.Text = reader("FullName").ToString()
                            TextBox5.Text = reader("YearSection").ToString()
                            TextBox6.Text = reader("Course").ToString()
                            TextBox3.Text = reader("ContactNumber").ToString()
                            TextBox4.Text = reader("Email").ToString()
                        Else
                            Dim result = MessageBox.Show("Student not found. Enter details?", "New Borrower", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If result = DialogResult.Yes Then
                                TextBox2.Clear()
                                TextBox3.Clear()
                                TextBox4.Clear()
                            End If
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studNo As String = TextBox1.Text.Trim()
        Dim name As String = TextBox2.Text.Trim()
        Dim contact As String = TextBox3.Text.Trim()
        Dim email As String = TextBox4.Text.Trim()
        Dim borrowDate As Date = DateTimePicker1.Value
        Dim dueDate As Date = DateTimePicker2.Value

        If String.IsNullOrEmpty(studNo) OrElse String.IsNullOrEmpty(name) OrElse
           String.IsNullOrEmpty(contact) OrElse String.IsNullOrEmpty(email) Then
            MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dueDate <= borrowDate Then
            MessageBox.Show("Due date must be later than borrow date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                Dim query As String = "
                INSERT INTO borrow (StudNo,  Accno, BorrowDate, DueDate, StatusName)
                SELECT @StudNo, @Accno, @BorrowDate, @DueDate, 'Borrowed'
                FROM book AS b
                WHERE b.Accno = @Accno"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudNo", studNo)
                    cmd.Parameters.AddWithValue("@Accno", accno)
                    cmd.Parameters.AddWithValue("@BorrowDate", borrowDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@DueDate", dueDate.ToString("yyyy-MM-dd"))
                    cmd.ExecuteNonQuery()
                End Using

                Dim updateQuery As String = "UPDATE book SET Status = 'Borrowed' WHERE Accno = @Accno"
                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@Accno", accno)
                    updateCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim back As New Form12
                back.Show()
                Me.Hide()

            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New Form12
        back.Show()
        Me.Hide()
    End Sub
End Class
