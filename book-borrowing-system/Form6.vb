Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Form6
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing;")

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadReportTypes()
    End Sub

    Private Sub LoadCategories()
        Try
            conn.Open()

            Dim query As String = "SELECT Category FROM category"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            Dim newRow As DataRow = table.NewRow()
            newRow("Category") = "All"
            table.Rows.InsertAt(newRow, 0)

            ComboBox1.DataSource = table
            ComboBox1.DisplayMember = "Category"
            ComboBox1.ValueMember = "Category"

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadReportTypes()
        ComboBox2.Items.Add("All")
        ComboBox2.Items.Add("Frequent Books")
        ComboBox2.Items.Add("Top Borrowers")
        ComboBox2.Items.Add("Overdue Books")
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim category = ComboBox1.SelectedValue.ToString
            Dim reportType = ComboBox2.SelectedItem.ToString
            Dim fromDate = DateTimePicker1.Value
            Dim toDate = DateTimePicker2.Value

            If fromDate > toDate Then
                MessageBox.Show("Invalid date range. 'From' date must be earlier than 'To' date.")
                Exit Sub
            End If

            Dim query = ""

            Select Case reportType
                Case "All"
                    query = "
                        SELECT 
                            b.BorrowID, 
                            b.StudNo, 
                            u.FullName, 
                            u.ContactNumber, 
                            b.BookID, 
                            bk.Title, 
                            bk.Author, 
                            bk.Year, 
                            bk.ISBN, 
                            bk.Category, 
                            b.BorrowDate, 
                            b.DueDate, 
                            b.StatusName,
                            COUNT(b.BorrowID) AS TimesBorrowed 
                        FROM borrow b
                        JOIN book bk ON b.BookID = bk.BookID
                        JOIN users u ON b.StudNo = u.StudNo
                        WHERE (b.BorrowDate BETWEEN @FromDate AND @ToDate)
                    "

                    If category <> "All" Then
                        query &= " AND bk.Category = @Category "
                    End If

                    query &= "
                        GROUP BY b.BorrowID
                        ORDER BY b.BorrowDate DESC
                    "

                Case "Frequent Books"
                    query = "
                        SELECT 
                            bk.BookID, 
                            bk.Title, 
                            bk.Author, 
                            bk.Year, 
                            bk.ISBN, 
                            bk.Category, 
                            COUNT(b.BorrowID) AS TimesBorrowed
                        FROM borrow b
                        JOIN book bk ON b.BookID = bk.BookID
                        WHERE (b.BorrowDate BETWEEN @FromDate AND @ToDate)
                    "

                    If category <> "All" Then
                        query &= " AND bk.Category = @Category "
                    End If

                    query &= "
                        GROUP BY bk.BookID
                        ORDER BY TimesBorrowed DESC
                    "

                Case "Top Borrowers"
                    query = "
                        SELECT 
                            b.StudNo, 
                            u.FullName, 
                            u.ContactNumber, 
                            COUNT(b.BorrowID) AS BorrowCount
                        FROM borrow b
                        JOIN users u ON b.StudNo = u.StudNo
                        WHERE (b.BorrowDate BETWEEN @FromDate AND @ToDate)
                    "

                    If category <> "All" Then
                        query &= " AND b.BookID IN (SELECT BookID FROM book WHERE Category = @Category) "
                    End If

                    query &= "
                        GROUP BY b.StudNo
                        ORDER BY BorrowCount DESC
                    "

                Case "Overdue Books"
                    query = "
                        SELECT 
                            b.BorrowID, 
                            b.StudNo, 
                            u.FullName, 
                            u.ContactNumber, 
                            b.BookID, 
                            bk.Title, 
                            bk.Author, 
                            b.DueDate, 
                            b.StatusName
                        FROM borrow b
                        JOIN book bk ON b.BookID = bk.BookID
                        JOIN users u ON b.StudNo = u.StudNo
                        WHERE b.DueDate < CURDATE() AND b.StatusName <> 'Returned'
                    "

                    If category <> "All" Then
                        query &= " AND bk.Category = @Category "
                    End If

                    query &= "
                        ORDER BY b.DueDate ASC
                    "

            End Select

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FromDate", fromDate)
            cmd.Parameters.AddWithValue("@ToDate", toDate)

            If category <> "All" Then
                cmd.Parameters.AddWithValue("@Category", category)
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable

            conn.Open()
            adapter.Fill(table)
            conn.Close()

            DataGridView1.DataSource = table
            DataGridView1.AutoResizeColumns()

            If table.Rows.Count = 0 Then
                MessageBox.Show("No records found for the selected filter.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub ExportToExcel()
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Save Excel File"
            saveFileDialog.FileName = "Report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

            If saveFileDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            Dim workbook As New XLWorkbook()
            Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Report")

            For col As Integer = 0 To DataGridView1.Columns.Count - 1
                worksheet.Cell(1, col + 1).Value = DataGridView1.Columns(col).HeaderText
                worksheet.Cell(1, col + 1).Style.Font.Bold = True
                worksheet.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray
            Next

            For row As Integer = 0 To DataGridView1.Rows.Count - 1
                For col As Integer = 0 To DataGridView1.Columns.Count - 1
                    worksheet.Cell(row + 2, col + 1).Value = DataGridView1.Rows(row).Cells(col).Value?.ToString()
                Next
            Next

            worksheet.Columns().AdjustToContents()

            workbook.SaveAs(saveFileDialog.FileName)
            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error exporting to Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportToExcel()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Close()
    End Sub

End Class
