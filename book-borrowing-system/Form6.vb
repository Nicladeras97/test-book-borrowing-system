Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports System.Drawing.Printing

Public Class Form6
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing;")

    Private WithEvents printDocument As New PrintDocument()

    Private printFont As Font
    Private printLine As Integer = 0
    Private linesPerPage As Integer
    Private currentPage As Integer = 1

    Private Sub LoadFilteredBooks(filter As String)
        Dim query As String = ""

        Select Case filter
            Case "Overdue"
                query = "
                SELECT b.BorrowID, b.StudNo, c.CopyID, bk.Title, bk.Author, bk.Publisher, b.BorrowDate, b.DueDate
                FROM borrow AS b
                INNER JOIN copies AS c ON b.CopyID = c.CopyID
                INNER JOIN book AS bk ON b.BookID = bk.BookID
                WHERE b.DueDate < CURDATE() AND b.StatusName = 'Borrowed';"

            Case "Lost"
                query = "
                SELECT rl.ReturnLostID, rl.BorrowID, rl.StudNo, bk.Title, bk.Author, bk.Publisher, rl.ReportDate, rl.FineAmount
                FROM return_lost AS rl
                INNER JOIN borrow AS b ON rl.BorrowID = b.BorrowID
                INNER JOIN book AS bk ON b.BookID = bk.BookID;"

            Case "Damaged"
                query = "
                SELECT rd.ReturnDamagedID, rd.BorrowID, rd.StudNo, bk.Title, bk.Author, bk.Publisher, rd.ReturnDate, rd.DamageDescription, rd.FineAmount
                FROM return_damaged AS rd
                INNER JOIN borrow AS b ON rd.BorrowID = b.BorrowID
                INNER JOIN book AS bk ON b.BookID = bk.BookID;"

            Case "All"
                query = "
                SELECT 'Overdue' AS Type, b.BorrowID, b.StudNo, c.CopyID, bk.Title, bk.Author, bk.Publisher, b.BorrowDate, b.DueDate, NULL AS FineAmount
                FROM borrow AS b
                INNER JOIN copies AS c ON b.CopyID = c.CopyID
                INNER JOIN book AS bk ON b.BookID = bk.BookID
                WHERE b.DueDate < CURDATE() AND b.StatusName = 'Borrowed'

                UNION

                SELECT 'Lost' AS Type, rl.BorrowID, rl.StudNo, NULL AS CopyID, bk.Title, bk.Author, bk.Publisher, rl.ReportDate AS BorrowDate, NULL AS DueDate, rl.FineAmount
                FROM return_lost AS rl
                INNER JOIN borrow AS b ON rl.BorrowID = b.BorrowID
                INNER JOIN book AS bk ON b.BookID = bk.BookID

                UNION

                SELECT 'Damaged' AS Type, rd.BorrowID, rd.StudNo, NULL AS CopyID, bk.Title, bk.Author, bk.Publisher, rd.ReturnDate AS BorrowDate, NULL AS DueDate, rd.FineAmount
                FROM return_damaged AS rd
                INNER JOIN borrow AS b ON rd.BorrowID = b.BorrowID
                INNER JOIN book AS bk ON b.BookID = bk.BookID;"

            Case Else
                MessageBox.Show("Invalid filter selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
        End Select

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedFilter As String = ComboBox1.SelectedItem?.ToString()

        If String.IsNullOrEmpty(selectedFilter) Then
            MessageBox.Show("Please select a filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            LoadFilteredBooks(selectedFilter)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportToExcel()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim back As New Form4
        back.Show()
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim printDialog As New PrintDialog()
        printDialog.Document = printDocument

        If printDialog.ShowDialog() = DialogResult.OK Then
            printFont = New Font("Arial", 10)
            printDocument.Print()
        End If
    End Sub

    Private Sub printDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDocument.PrintPage
        Dim yPos As Single = e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim lineHeight As Single = printFont.GetHeight(e.Graphics) + 5
        Dim maxLines As Integer = CInt(e.MarginBounds.Height / lineHeight)

        linesPerPage = maxLines

        Dim line As Integer = 0
        Dim headerFont As New Font("Arial", 12, FontStyle.Bold)

        Dim xPos As Single = leftMargin
        For col As Integer = 0 To DataGridView1.Columns.Count - 1
            e.Graphics.DrawString(DataGridView1.Columns(col).HeaderText, headerFont, Brushes.Black, xPos, yPos)
            xPos += 150
        Next

        yPos += lineHeight
        line += 1

        While (printLine < DataGridView1.Rows.Count AndAlso line < linesPerPage)
            xPos = leftMargin

            For col As Integer = 0 To DataGridView1.Columns.Count - 1
                Dim cellValue As String = If(DataGridView1.Rows(printLine).Cells(col).Value IsNot Nothing, DataGridView1.Rows(printLine).Cells(col).Value.ToString(), "")
                e.Graphics.DrawString(cellValue, printFont, Brushes.Black, xPos, yPos)
                xPos += 150
            Next

            yPos += lineHeight
            printLine += 1
            line += 1
        End While

        e.HasMorePages = (printLine < DataGridView1.Rows.Count)

        If Not e.HasMorePages Then
            printLine = 0
            currentPage = 1
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Overdue")
        ComboBox1.Items.Add("Lost")
        ComboBox1.Items.Add("Damaged")
        ComboBox1.SelectedIndex = 0
    End Sub
End Class
