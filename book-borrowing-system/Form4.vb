Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form4
    Private Const ConnectionString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub btnSendNewsletter_Click(sender As Object, e As EventArgs) Handles btnSendNewsletter.Click
        SendNewsletter()
    End Sub

    Private Sub SendNewsletter()
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()

                If conn.State <> ConnectionState.Open Then
                    MessageBox.Show("Failed to open the database connection.")
                    Return
                End If

                Dim query As String = "SELECT u.Email, u.FullName, b.Title, b.Author, b.AccNo " &
                                  "FROM users AS u " &
                                  "INNER JOIN books AS b ON b.AddedDate >= @LastWeekDate"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@LastWeekDate", DateTime.Now.AddDays(-7))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim emailList As New List(Of String)
                        Dim bookList As New HashSet(Of String)
                        Dim emailBody As String = "Dear Valued Borrowers," & Environment.NewLine & Environment.NewLine &
                                              "We are excited to inform you that new books have been added to the library!" & Environment.NewLine & Environment.NewLine

                        If reader.HasRows Then
                            While reader.Read()
                                Dim borrowerEmail As String = reader("Email").ToString()
                                Dim bookTitle As String = reader("Title").ToString()
                                Dim bookAuthor As String = reader("Author").ToString()
                                Dim accNo As String = reader("AccNo").ToString()

                                Dim bookIdentifier As String = $"{bookTitle} - {bookAuthor} - AccNo: {accNo}"
                                If Not bookList.Contains(bookIdentifier) Then
                                    bookList.Add(bookIdentifier)
                                    emailBody &= $"Title: {bookTitle}" & Environment.NewLine &
                                             $"Author: {bookAuthor}" & Environment.NewLine &
                                             $"AccNo: {accNo}" & Environment.NewLine & Environment.NewLine
                                End If

                                If Not emailList.Contains(borrowerEmail) Then
                                    emailList.Add(borrowerEmail)
                                End If
                            End While

                            emailBody &= "Visit the library to check out these and other great books!" & Environment.NewLine & Environment.NewLine &
                                     "Happy Reading!"

                            SendBulkEmail(emailList, emailBody)
                        Else
                            MessageBox.Show("No new books found for the newsletter.")
                        End If
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            LogError("MySQL Error: " & ex.Message)
            MessageBox.Show("MySQL Error: " & ex.Message)
        Catch ex As Exception
            LogError("Error sending newsletter: " & ex.Message)
            MessageBox.Show("Error sending newsletter: " & ex.Message)
        End Try
    End Sub



    Private Sub SendBulkEmail(emailList As List(Of String), emailBody As String)
        Try
            Using smtp As New SmtpClient("smtp.gmail.com", 587),
                  mail As New MailMessage()
                smtp.Credentials = New NetworkCredential("librarian.cmilibrary@gmail.com", "ahcn wipo tyhe wfhw")
                smtp.EnableSsl = True

                mail.From = New MailAddress("librarian.cmilibrary@gmail.com")
                mail.Subject = "New Books Added to the Library"
                mail.Body = emailBody

                For Each email As String In emailList
                    mail.Bcc.Add(email)
                Next

                smtp.Send(mail)
                MessageBox.Show("Newsletter sent successfully!")
            End Using
        Catch ex As Exception
            LogError("Error sending bulk email: " & ex.Message)
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub

    Private Sub LogError(errorMessage As String)
        Dim logFilePath As String = "C:\LibrarySystem\ErrorLog.txt"
        Try
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & errorMessage)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging error: " & ex.Message)
        End Try
    End Sub

End Class
