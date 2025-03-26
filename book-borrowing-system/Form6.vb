Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class Form6
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

