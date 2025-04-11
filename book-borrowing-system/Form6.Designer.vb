<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        Button4 = New Button()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        TextBox1 = New TextBox()
        Label1 = New Label()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        Button5 = New Button()
        Label2 = New Label()
        Button6 = New Button()
        PrintDocument1 = New Printing.PrintDocument()
        Label3 = New Label()
        Label4 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = SystemColors.HotTrack
        Button2.Cursor = Cursors.Hand
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 12F, FontStyle.Bold)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(1314, 36)
        Button2.Name = "Button2"
        Button2.Size = New Size(89, 33)
        Button2.TabIndex = 7
        Button2.Text = "Export"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Anchor = AnchorStyles.None
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.BackgroundColor = SystemColors.ButtonHighlight
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.LightBlue
        DataGridViewCellStyle1.Font = New Font("Arial", 16F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = Color.LightBlue
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Cursor = Cursors.Hand
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Arial", 16F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.ControlDark
        DataGridView1.Location = New Point(38, 87)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Arial", 16F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1365, 623)
        DataGridView1.TabIndex = 14
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.None
        Button4.BackColor = SystemColors.HotTrack
        Button4.Cursor = Cursors.Hand
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 12F, FontStyle.Bold)
        Button4.ForeColor = Color.White
        Button4.Location = New Point(1214, 36)
        Button4.Name = "Button4"
        Button4.Size = New Size(89, 33)
        Button4.TabIndex = 15
        Button4.Text = "Print"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.Font = New Font("Arial", 16F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(534, 36)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(331, 32)
        ComboBox1.TabIndex = 32
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Anchor = AnchorStyles.None
        ComboBox2.Font = New Font("Arial", 16F, FontStyle.Bold)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(1036, 36)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(162, 32)
        ComboBox2.TabIndex = 34
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Font = New Font("Arial", 16F)
        TextBox1.Location = New Point(124, 37)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(280, 32)
        TextBox1.TabIndex = 37
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16F)
        Label1.Location = New Point(38, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(80, 25)
        Label1.TabIndex = 38
        Label1.Text = "Search"
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.None
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Arial", 16F)
        Button5.Location = New Point(552, 732)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 34)
        Button5.TabIndex = 39
        Button5.Text = "Back"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.Font = New Font("Arial", 16F)
        Label2.Location = New Point(633, 732)
        Label2.Name = "Label2"
        Label2.Size = New Size(195, 34)
        Label2.TabIndex = 40
        Label2.Text = "Label2"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.None
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Arial", 16F)
        Button6.Location = New Point(834, 732)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 34)
        Button6.TabIndex = 41
        Button6.Text = "Next"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 16F)
        Label3.Location = New Point(437, 39)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 25)
        Label3.TabIndex = 42
        Label3.Text = "Filter By"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 16F)
        Label4.Location = New Point(871, 39)
        Label4.Name = "Label4"
        Label4.Size = New Size(159, 25)
        Label4.TabIndex = 43
        Label4.Text = "Items per Page"
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1446, 790)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Button6)
        Controls.Add(Label2)
        Controls.Add(Button5)
        Controls.Add(ComboBox1)
        Controls.Add(Label1)
        Controls.Add(TextBox1)
        Controls.Add(ComboBox2)
        Controls.Add(Button4)
        Controls.Add(Button2)
        Controls.Add(DataGridView1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Location = New Point(266, 111)
        Name = "Form6"
        StartPosition = FormStartPosition.Manual
        Text = "Book Reports"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
