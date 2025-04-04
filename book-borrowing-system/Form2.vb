Imports MySql.Data.MySqlClient

Public Class Form2
    Private connString As String = "server=localhost; user=root; password=; database=book-borrowing;"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookAccnos()
        Button1.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button1.Enabled = ComboBox1.SelectedItem IsNot Nothing
    End Sub


    Private Sub LoadBookAccnos()
        ComboBox1.Items.Clear()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT Accno FROM books"
                Using cmd As New MySqlCommand(query, conn)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox1.Items.Add(reader("Accno").ToString())
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading Accno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an Accno.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAccNo As String = ComboBox1.SelectedItem.ToString()
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM books WHERE Accno = @Accno"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Label10.Text = reader("Title").ToString()
                        Label12.Text = reader("Author").ToString()
                        Label13.Text = reader("Year").ToString()
                        Label14.Text = reader("Publisher").ToString()
                        Label23.Text = reader("ISBN").ToString()
                        Label15.Text = reader("Section").ToString()
                        Label17.Text = reader("CallNumber").ToString()
                        Label16.Text = reader("Rack").ToString()
                    Else
                        MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving book details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select an Accno to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAccNo As String = ComboBox1.SelectedItem.ToString()

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                Dim checkQuery As String = "SELECT COUNT(*) FROM books_borrowed WHERE book_id = @Accno"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This book is currently borrowed and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim deleteQuery As String = "DELETE FROM books WHERE Accno = @Accno"
                Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                    deleteCmd.Parameters.AddWithValue("@Accno", selectedAccNo)
                    deleteCmd.ExecuteNonQuery()
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Dim back As New Form15
                back.Show()
                Me.Hide()

            Catch ex As Exception
                MessageBox.Show("Error deleting book: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cancel As New Form15
        cancel.Show()
        Me.Hide()
    End Sub


End Class