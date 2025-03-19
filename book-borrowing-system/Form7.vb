Imports MySql.Data.MySqlClient

Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNotifications()
    End Sub

    Private Sub LoadNotifications()
        Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

        Try
            conn.Open()

            Dim deleteExpiredQuery As String = "DELETE FROM notification WHERE NotifDate < DATE_SUB(NOW(), INTERVAL 1 MONTH)"
            Dim deleteCmd As New MySqlCommand(deleteExpiredQuery, conn)
            deleteCmd.ExecuteNonQuery()

            Dim query As String = "SELECT * FROM notification WHERE NotifDate >= DATE_SUB(NOW(), INTERVAL 1 MONTH) ORDER BY NotifDate DESC"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ListView1.Items.Clear()

            While reader.Read()
                Dim message As String = reader("Message").ToString()
                Dim notifType As String = reader("NotifType").ToString()
                Dim notifDate As DateTime = Convert.ToDateTime(reader("NotifDate"))

                Dim item As New ListViewItem(message)
                item.SubItems.Add(notifType)
                item.SubItems.Add(notifDate.ToString("MM-dd-yyyy HH:mm"))

                ListView1.Items.Add(item)
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
