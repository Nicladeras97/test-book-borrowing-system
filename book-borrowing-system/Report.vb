Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.X509

Public Class Report
    Private Timer As New Timer()
    Private EmailSent As Boolean = False
    Private Const ConnectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer.Interval = 1000
        AddHandler Timer.Tick, AddressOf OnTimerTick
        Timer.Start()
    End Sub

    Private isProcessing As Boolean = False

    Private Sub OnTimerTick(sender As Object, e As EventArgs)
        If isProcessing Then Return

        DataGrid()

        isProcessing = True
        Task.Run(Sub()
                     Try
                         CheckDateAndSendEmail()
                     Catch ex As Exception
                         MessageBox.Show("Error in CheckDateAndSendEmail: " & ex.Message)
                     Finally
                         isProcessing = False
                     End Try
                 End Sub)
    End Sub

    Private Sub DataGrid()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim query As String = "SELECT b.borrower_id, u.FullName, b.date_borrowed, b.due_date, w.Title, o.deadline " &
                      "FROM books_borrowed AS b " &
                      "INNER JOIN users AS u ON b.borrower_id = u.UserID " &
                      "INNER JOIN books AS w ON b.book_id = w.Accno " &
                      "INNER JOIN email_message AS o ON b.notify_id = o.message_id "


                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        DataGridView1.Rows.Clear()

                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        DataGridView1.ColumnCount = 5
                        DataGridView1.Columns(0).Name = "TargetDate"
                        DataGridView1.Columns(1).Name = "Book Borrowed"
                        DataGridView1.Columns(2).Name = "Date Borrowed"
                        DataGridView1.Columns(3).Name = "Return Date"
                        DataGridView1.Columns(4).Name = "Status"

                        While reader.Read()
                            Dim borrowerName As String = reader("FullName").ToString()
                            Dim book_Title As String = reader("Title").ToString()
                            Dim dateBorrowed As String = DateTime.Parse(reader("date_borrowed").ToString()).ToString("MM-dd-yyyy")
                            Dim dueDate As String = DateTime.Parse(reader("due_date").ToString()).ToString("MM-dd-yyyy")
                            Dim status As String = reader("deadline").ToString()


                            DataGridView1.Rows.Add(borrowerName, book_Title, dateBorrowed, dueDate, status)
                        End While
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while fetching borrower data: " & ex.Message)
        End Try
    End Sub

    Private Sub AddToListBox(ByVal listBox As ListBox, ByVal value As String)
        If listBox.InvokeRequired Then
            listBox.Invoke(Sub() listBox.Items.Add(value))
        Else
            listBox.Items.Add(value)
        End If
    End Sub

    Dim due_time As String
    Dim notify_id As String

    Private Sub CheckDateAndSendEmail()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim dueday As New List(Of String)()
                Dim almost_due As New List(Of String)()
                Dim overdue As New List(Of String)()

                Dim select_query As String = "SELECT borrow_id, due_date, time, notify_id FROM books_borrowed"
                Using select_cmd As New MySqlCommand(select_query, conn)
                    Using select_reader As MySqlDataReader = select_cmd.ExecuteReader()
                        While select_reader.Read()
                            Dim borrow_date As String = select_reader("due_date").ToString().Trim()
                            Dim borrowId As String = select_reader("borrow_id").ToString()
                            due_time = select_reader("time").ToString()
                            notify_id = select_reader("notify_id").ToString()


                            Dim TargetDate As DateTime
                            If DateTime.TryParse(borrow_date, TargetDate) Then
                                Console.WriteLine($"Parsed Target Date: {TargetDate}")
                            Else
                                Console.WriteLine($"Error: Invalid date format in database: {borrow_date}")
                                Continue While
                            End If

                            Dim currentDate As DateTime = DateTime.Today

                            If TargetDate.Year > 1 Then
                                If currentDate = TargetDate Then
                                    dueday.Add(borrowId)

                                ElseIf currentDate = TargetDate.AddDays(-1) OrElse currentDate = TargetDate.AddDays(-7) Then
                                    almost_due.Add(borrowId)

                                ElseIf currentDate > TargetDate Then
                                    overdue.Add(borrowId)

                                End If
                            Else
                                Console.WriteLine($"Error: Unrepresentable DateTime for Borrow ID {borrowId}")
                            End If
                        End While
                    End Using
                End Using

                Dim notifyMappings As New Dictionary(Of List(Of String), String) From {
                {dueday, "3"},
                {almost_due, "1"},
                {overdue, "2"}
            }
                Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")

                For Each kvp In notifyMappings
                    Dim list As List(Of String) = kvp.Key
                    Dim notifyId As String = kvp.Value

                    If list.Count > 0 Then
                        For Each borrowId In list
                            Dim updateQuery As String = "UPDATE books_borrowed SET notify_id = @newNotify_id WHERE borrow_id = @borrowId"
                            Using update_cmd As New MySqlCommand(updateQuery, conn)
                                update_cmd.Parameters.AddWithValue("@newNotify_id", notifyId)
                                update_cmd.Parameters.AddWithValue("@borrowId", borrowId)
                                update_cmd.ExecuteNonQuery()
                            End Using

                            If currentTime = due_time AndAlso notify_id <> 4 Then
                                SendEmailAutomatically(borrowId)
                            End If

                        Next
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while checking time and sending emails: " & ex.Message)
        End Try
    End Sub

    Private Sub SendEmailAutomatically(ByVal borrowId As String)
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")

                Dim Email_query As String = "SELECT k.borrower_id, k.due_date, k.time, k.notify_id, j.Email, d.subject, d.message_content, a.Title " &
                                        "FROM books_borrowed AS k " &
                                        "INNER JOIN users AS j ON k.borrower_id = j.UserID " &
                                        "INNER JOIN email_message AS d ON k.notify_id = d.message_id " &
                                        "INNER JOIN books AS a ON k.book_id = a.Accno " &
                                        "WHERE k.borrow_id = @borrowId"

                Using email_cmd As New MySqlCommand(Email_query, conn)
                    email_cmd.Parameters.AddWithValue("@borrowId", borrowId)

                    Using email_reader As MySqlDataReader = email_cmd.ExecuteReader()
                        While email_reader.Read()
                            Dim time As String = email_reader("time").ToString()
                            Dim notify_id As Integer = Convert.ToInt32(email_reader("notify_id"))
                            AddToListBox(ListBox1, time)
                            AddToListBox(ListBox2, currentTime)

                            Dim email As String = email_reader("Email").ToString()
                            Dim email_subject As String = email_reader("subject").ToString()
                            Dim email_body As String = email_reader("message_content").ToString()
                            Dim book_title As String = email_reader("Title").ToString()
                            Dim due_date As String = DateTime.Parse(email_reader("due_date").ToString()).ToString("MM-dd-yyyy")

                            Using smtp As New SmtpClient("smtp.gmail.com", 587),
                                  mail As New MailMessage()
                                smtp.Credentials = New NetworkCredential("librarian.cmilibrary@gmail.com", "ahcn wipo tyhe wfhw")
                                smtp.EnableSsl = True

                                mail.From = New MailAddress("librarian.cmilibrary@gmail.com")
                                mail.To.Add(email)
                                mail.Subject = email_subject
                                mail.Body = email_body & Environment.NewLine & Environment.NewLine &
                                            "Book Title: " & book_title & Environment.NewLine &
                                            "Return Date: " & due_date & Environment.NewLine & Environment.NewLine &
                                            "This email was sent at " & DateTime.Now.ToString("HH:mm")

                                smtp.Send(mail)
                            End Using
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error sending email: {ex.Message}")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form15
        back.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New Form15
        back.Show()
        Me.Hide()
    End Sub
End Class


'Credits to Allysa Pacunio for this code.


'for testing
'remove mo nalang yung listbox after testing
'pagremove ng listbox, remove na rin yung line 80-86 kasi para yun sa listbox (AddToListBox)


'listbox1 = Target time from database
'listbox2 = Concurrent time. Update every second
'24 hours ang format ng time hours:minutes:seconds
'ang date  = year-month-day

'sample testing For due today : edit mo sa database ng borrowed book yung duedate sa date ngayon.
'                               set mo yung time na malapit sa time ngayon. ex. 11:30 na. edit mo yug time ng 11:31:00 then run mo yung system before 11:31:00
'                               login then punta sa report form .
'                               wait mo mag 11:31. may timer na listbox para malaman mo kung malapit na. dapat mareceive mo yung email at exactly 11:30.
'                               may date sa email incase na may interruptions like mahina ang internet connection 


'sample testing For almostdue : edit mo sa database ng borrowed book yung duedate ng 7 days before today or 1 day before today.
'                               set mo yung time na malapit sa time ngayon. ex. 11:30 na. edit mo yug time ng 11:31:00 then run mo yung system before 11:31:00
'                               login then punta sa report form .
'                               wait mo mag 11:31. may timer na listbox para malaman mo kung malapit na. dapat mareceive mo yung email at exactly 11:30.
'                               may date sa email incase na may interruptions like mahina ang internet connection 

'sample testing For overdue : edit mo sa database ng borrowed book yung duedate ng 1 day or more days away from today. ex. 21 ngayon set mo ng 22 or 23 or 24
'                               set mo yung time na malapit sa time ngayon. ex. 11:30 na. edit mo yug time ng 11:31:00 then run mo yung system before 11:31:00
'                               login then punta sa report form .
'                               wait mo mag 11:31. may timer na listbox para malaman mo kung malapit na. dapat mareceive mo yung email at exactly 11:30.
'                               may date sa email incase na may interruptions like mahina ang internet connection 

'optional lang yung pagpunta pa sa report form. pwede na nang irun mo lang yung system then wait mo yung email.

'nag uupdate ang notify id depende sa date. pagkakainsert lang ng data at 4 pa ang notify id, pag nirun mo dapat magbabago na yun unless malayo pa ang due date. 

'kung gusto mo iedit yung laman ng email, edit mo yung table ng email_message then message_content. kung format naman, line 209

'nagdagdag ako ng notify id sa form8, sa pagborrow yun ng book. matic na 4 ang value pag nanghiram kasi walang pang duedate.

'testing nyo sa maramihan at iba ibang account. natry ko lang kasi sa dalawang account

'every seconds sya nagchecheck ng date para walang delay tsaka madaling matesting

'wala naman akong nadagdag sa database bukod sa naginsert ako ng data sa borrowed_books. nilink ko lang yung notify id sa table ng email message. patanggal ng (3) pag gagamitin yung database na ginamit ko para same name sa existing at nasa code pag nag import. 

'Goodluck! Fighting!