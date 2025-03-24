Imports MySql.Data.MySqlClient

Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadNotifications()
    End Sub

    Private Sub LoadNotifications()
        Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

        Try
            conn.Open()

            Dim query As String = "SELECT NotifID, NotifType AS 'Type', Message, DATE_FORMAT(NotifDate, '%Y-%m-%d %H:%i:%s') AS 'Datenow', IsRead FROM notification WHERE NotifDate >= DATE_SUB(NOW(), INTERVAL 1 MONTH)"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()

            adapter.Fill(table)

            DataGridView1.DataSource = table

            DataGridView1.ColumnHeadersVisible = False

            DataGridView1.Columns("NotifID").Visible = False
            DataGridView1.Columns("IsRead").Visible = False
            DataGridView1.Columns("Type").Width = 80
            DataGridView1.Columns("Message").Width = 250
            DataGridView1.Columns("Datenow").Width = 100

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim isRead As Boolean = Convert.ToBoolean(row.Cells("IsRead").Value)
                If Not isRead Then
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

        Try
            conn.Open()

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                Dim notifID As Integer = Convert.ToInt32(row.Cells("NotifID").Value)

                Dim query As String = "UPDATE notification SET IsRead = 1 WHERE NotifID = @NotifID"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NotifID", notifID)

                cmd.ExecuteNonQuery()
            Next

            LoadNotifications()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class
