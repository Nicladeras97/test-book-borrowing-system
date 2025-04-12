Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form4
    Private Const ConnectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub btnSendNewsletter_Click(sender As Object, e As EventArgs) Handles btnSendNewsletter.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.Value = 0
        Me.Enabled = False
        Application.DoEvents()

        Try
            SendNewsletter()
        Finally
            ProgressBar1.Visible = False
            Me.Enabled = True
        End Try
    End Sub

    Private Sub SendNewsletter()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                If conn.State <> ConnectionState.Open Then
                    MessageBox.Show("Failed to open the database connection.")
                    Return
                End If

                Dim interestQuery As String =
                "SELECT DISTINCT u.Email, u.FullName, b.Section " &
                "FROM returned_books AS rb " &
                "INNER JOIN books AS b ON rb.BookID = b.Accno " &
                "INNER JOIN users AS u ON rb.BorrowerID = u.UserID"

                Dim userInterests As New Dictionary(Of String, HashSet(Of String))()
                Dim userNames As New Dictionary(Of String, String)()

                Using cmd As New MySqlCommand(interestQuery, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim email As String = reader("Email").ToString()
                            Dim fullName As String = reader("FullName").ToString()
                            Dim section As String = reader("Section").ToString()

                            If Not userInterests.ContainsKey(email) Then
                                userInterests(email) = New HashSet(Of String)()
                                userNames(email) = fullName
                            End If
                            userInterests(email).Add(section)
                        End While
                    End Using
                End Using

                If userInterests.Count = 0 Then
                    MessageBox.Show("No user interests found.")
                    Return
                End If

                Dim newBooksQuery As String =
                "SELECT Title, Author, Section, Accno FROM books WHERE AddedDate = CURDATE()"

                Dim newBooks As New List(Of Dictionary(Of String, String))()

                Using cmd As New MySqlCommand(newBooksQuery, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim book As New Dictionary(Of String, String) From {
                            {"Title", reader("Title").ToString()},
                            {"Author", reader("Author").ToString()},
                            {"Section", reader("Section").ToString()},
                            {"Accno", reader("Accno").ToString()}
                        }
                            newBooks.Add(book)
                        End While
                    End Using
                End Using

                If newBooks.Count = 0 Then
                    MessageBox.Show("No newly added books today.")
                    Return
                End If

                ProgressBar1.Value = 0
                ProgressBar1.Maximum = userInterests.Count
                lblStatus.Visible = True

                Dim currentProgress As Integer = 0
                Dim successfulSends As Integer = 0

                For Each entry In userInterests
                    Dim email As String = entry.Key
                    Dim fullName As String = userNames(email)
                    Dim interests As HashSet(Of String) = entry.Value

                    Dim matchedBooks As New List(Of String)()

                    For Each book In newBooks
                        If interests.Contains(book("Section")) Then
                            Dim bookDetails As String =
                            vbCrLf & "📘 Title: " & book("Title") & vbCrLf &
                            "✍️ Author: " & book("Author") & vbCrLf &
                            "🔖 Section: " & book("Section") & vbCrLf &
                            "📚 Accession No: " & book("Accno") & vbCrLf
                            matchedBooks.Add(bookDetails)
                        End If
                    Next

                    If matchedBooks.Count > 0 Then
                        Dim emailBody As String =
                        $"Hi {fullName}," & vbCrLf & vbCrLf &
                        "Great news! We've added some exciting new books to our library that we think you'll love — based on the categories you've shown interest in before." & vbCrLf & vbCrLf &
                        "Here are the new arrivals you might like:" & vbCrLf &
                        String.Join("", matchedBooks) & vbCrLf &
                        "We hope these titles spark your interest. Be sure to visit the library soon and check them out before they're gone!" & vbCrLf & vbCrLf &
                        "Happy reading," & vbCrLf &
                        "Your CMI Library 📖"

                        Try
                            lblStatus.Text = $"Sending to: {email} ({currentProgress + 1} of {userInterests.Count})"
                            Application.DoEvents()

                            SendEmail(email, emailBody)
                            successfulSends += 1
                            Debug.WriteLine("Email sent to: " & email)
                        Catch ex As Exception
                            LogError("Error sending to " & email & ": " & ex.Message)
                        Finally
                            currentProgress += 1
                            ProgressBar1.Value = currentProgress
                            Application.DoEvents()
                            Threading.Thread.Sleep(300)
                        End Try
                    Else
                        currentProgress += 1
                        ProgressBar1.Value = currentProgress
                        Application.DoEvents()
                    End If
                Next

                lblStatus.Text = "Done sending all emails."

                If successfulSends = 0 Then
                    MessageBox.Show("No newsletters were sent. No matching books found.")
                Else
                    MessageBox.Show("Newsletter sent successfully!")
                End If
            End Using
        Catch ex As MySqlException
            LogError("MySQL Error: " & ex.Message)
            MessageBox.Show("MySQL Error: " & ex.Message)
        Catch ex As Exception
            LogError("Error sending newsletter: " & ex.Message)
            MessageBox.Show("Error sending newsletter: " & ex.Message)
        Finally
            lblStatus.Visible = False
        End Try
    End Sub



    Private Sub SendEmail(email As String, emailBody As String)
        Try
            Using smtp As New SmtpClient("smtp.gmail.com", 587),
                  mail As New MailMessage()
                smtp.Credentials = New NetworkCredential("librarian.cmilibrary@gmail.com", "ahcn wipo tyhe wfhw")
                smtp.EnableSsl = True
                smtp.Timeout = 10000

                mail.From = New MailAddress("librarian.cmilibrary@gmail.com")
                mail.To.Add(email)
                mail.Subject = "📚 Personalized Book Recommendations Just for You!"
                mail.Body = emailBody

                smtp.Send(mail)
            End Using
        Catch ex As Exception
            Throw New Exception("Failed to send email to " & email & ": " & ex.Message)
        End Try
    End Sub

    Private Sub LogError(errorMessage As String)
        Dim logFilePath As String = "C:\LibrarySystem\ErrorLog.txt"
        Try
            Dim directoryPath As String = Path.GetDirectoryName(logFilePath)
            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
            End If
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & errorMessage)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging error: " & ex.Message)
        End Try
    End Sub
End Class
