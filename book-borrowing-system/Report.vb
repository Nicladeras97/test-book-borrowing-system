Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient

Public Class Report
    Private Timer As New Timer()
    Private EmailSent As Boolean = False
    Private Const ConnectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Automated Email Sender Without Date"

        Timer.Interval = 1000 ' 1 second interval
        AddHandler Timer.Tick, AddressOf OnTimerTick
        Timer.Start()
    End Sub

    Private isProcessing As Boolean = False

    Private Sub OnTimerTick(sender As Object, e As EventArgs)
        If isProcessing Then Return

        BorrowerData()

        isProcessing = True
        Task.Run(Sub()
                     Try
                         CheckTimeAndSendEmail()
                     Catch ex As Exception
                         MessageBox.Show("Error in CheckTimeAndSendEmail: " & ex.Message)
                     Finally
                         isProcessing = False ' Reset the flag
                     End Try
                 End Sub)
    End Sub


    Private Sub BorrowerData()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim query As String = "SELECT b.borrower_id, u.FullName, b.date_borrowed, b.due_date, b.time, w.Title, o.deadline " &
                      "FROM books_borrowed AS b " &
                      "INNER JOIN users AS u ON b.borrower_id = u.UserID " &
                      "INNER JOIN books AS w ON b.book_id = w.Accno " &
                      "INNER JOIN email_message AS o ON b.notify_id = o.message_id "


                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        DataGridView1.Rows.Clear()

                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        DataGridView1.ColumnCount = 5
                        DataGridView1.Columns(0).Name = "FullName"
                        DataGridView1.Columns(1).Name = "Book Borrowed"
                        DataGridView1.Columns(2).Name = "Date Borrowed"
                        DataGridView1.Columns(3).Name = "Return Date"
                        DataGridView1.Columns(4).Name = "Status"

                        While reader.Read()
                            Dim borrowerName As String = reader("FullName").ToString()
                            Dim book_Title As String = reader("Title").ToString()
                            Dim dateBurrowed As String = DateTime.Parse(reader("due_date").ToString()).ToString("MM-dd-yyyy")
                            Dim dueDate As String = DateTime.Parse(reader("due_date").ToString()).ToString("MM-dd-yyyy")
                            Dim status As String = reader("deadline").ToString()

                            DataGridView1.Rows.Add(borrowerName, book_Title, dateBurrowed, dueDate, status)
                        End While
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while fetching borrower data: " & ex.Message)
        End Try
    End Sub

    Private Sub CheckTimeAndSendEmail()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim dueday As New List(Of String)()
                Dim almost_due As New List(Of String)()
                Dim overdue As New List(Of String)()

                Dim select_query As String = "SELECT borrow_id, time FROM books_borrowed"
                Using select_cmd As New MySqlCommand(select_query, conn)
                    Using select_reader As MySqlDataReader = select_cmd.ExecuteReader()
                        While select_reader.Read()
                            Dim time As String = select_reader("time").ToString()
                            Dim borrowId As String = select_reader("borrow_id").ToString()

                            Dim dateParts() As String = time.Split(":"c)
                            Dim TargetDate As TimeSpan

                            If dateParts.Length = 3 Then
                                TargetDate = New TimeSpan(Convert.ToInt32(dateParts(0)),
                                                          Convert.ToInt32(dateParts(1)),
                                                          Convert.ToInt32(dateParts(2)))
                            Else
                                Throw New FormatException("Invalid time format in database.")
                            End If

                            Dim currentDate As TimeSpan = DateTime.Now.TimeOfDay

                            If currentDate >= TargetDate AndAlso currentDate < TargetDate.Add(New TimeSpan(0, 1, 0)) Then
                                dueday.Add(borrowId)
                            End If

                            If (currentDate >= TargetDate.Subtract(New TimeSpan(0, 7, 0)) AndAlso currentDate < TargetDate.Add(New TimeSpan(0, 1, 0))) OrElse
                               (currentDate >= TargetDate.Subtract(New TimeSpan(0, 1, 0)) AndAlso currentDate < TargetDate.Add(New TimeSpan(0, 1, 0))) Then
                                almost_due.Add(borrowId)
                            End If

                            If currentDate > TargetDate Then
                                overdue.Add(borrowId)
                            End If
                        End While
                    End Using
                End Using

                Dim notifyMappings As New Dictionary(Of List(Of String), String) From {
                    {dueday, "3"},
                    {almost_due, "1"},
                    {overdue, "2"}
                }

                For Each group In notifyMappings
                    For Each borrowId In group.Key
                        Dim updateQuery As String = "UPDATE books_borrowed SET notify_id = @newNotify_id WHERE borrow_id = @borrowId"
                        Using update_cmd As New MySqlCommand(updateQuery, conn)
                            update_cmd.Parameters.AddWithValue("@newNotify_id", group.Value)
                            update_cmd.Parameters.AddWithValue("@borrowId", borrowId)
                            update_cmd.ExecuteNonQuery()
                        End Using

                        SendEmailAutomatically()
                        EmailSent = True
                    Next
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while checking time and sending emails: " & ex.Message)
        End Try
    End Sub

    Private Sub SendEmailAutomatically()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim Email_query As String = "SELECT k.borrower_id, k.due_date, k.notify_id, j.Email, d.subject, d.message_content, a.Title " &
                                            "FROM books_borrowed AS k " &
                                            "INNER JOIN users AS j ON k.borrower_id = j.UserID " &
                                            "INNER JOIN email_message AS d ON k.notify_id = d.message_id " &
                                            "INNER JOIN books AS a ON k.book_id = a.Accno"

                Using email_cmd As New MySqlCommand(Email_query, conn)
                    Using email_reader As MySqlDataReader = email_cmd.ExecuteReader()
                        While email_reader.Read()
                            Dim notify_id As Integer = Convert.ToInt32(email_reader("notify_id"))
                            If notify_id <> 4 Then
                                Dim email As String = email_reader("Email").ToString()
                                Dim email_subject As String = email_reader("subject").ToString()
                                Dim email_body As String = email_reader("message_content").ToString()
                                Dim book_title As String = email_reader("Title").ToString()
                                Dim due_date As String = DateTime.Parse(email_reader("due_date").ToString()).ToString("MM-dd-yyyy")

                                Using smtp As New SmtpClient("smtp.gmail.com", 587),
                                      mail As New MailMessage()
                                    smtp.Credentials = New NetworkCredential("allysapacunio0023@gmail.com", "onuz bjon pqxu udkr")
                                    smtp.EnableSsl = True

                                    mail.From = New MailAddress("allysapacunio0023@gmail.com")
                                    mail.To.Add(email)
                                    mail.Subject = email_subject
                                    mail.Body = email_body & Environment.NewLine &
                                                "Book Title: " & book_title & Environment.NewLine &
                                                "Return Date: " & due_date

                                    smtp.Send(mail)
                                End Using
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while sending emails: " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New Form4
        back.Show()
        Me.Hide()
    End Sub
End Class
