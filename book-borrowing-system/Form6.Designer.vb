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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        Button4 = New Button()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        TextBox1 = New TextBox()
        Label1 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.HotTrack
        Button2.Cursor = Cursors.Hand
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(1314, 39)
        Button2.Name = "Button2"
        Button2.Size = New Size(89, 28)
        Button2.TabIndex = 7
        Button2.Text = "Export"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.BackgroundColor = SystemColors.ButtonHighlight
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.LightBlue
        DataGridViewCellStyle2.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightBlue
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Cursor = Cursors.Hand
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.ControlDark
        DataGridView1.Location = New Point(38, 87)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1365, 670)
        DataGridView1.TabIndex = 14
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.HotTrack
        Button4.Cursor = Cursors.Hand
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.White
        Button4.Location = New Point(1219, 39)
        Button4.Name = "Button4"
        Button4.Size = New Size(89, 28)
        Button4.TabIndex = 15
        Button4.Text = "Print"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(573, 28)
        Label3.Name = "Label3"
        Label3.Size = New Size(25, 19)
        Label3.TabIndex = 31
        Label3.Text = "To"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(312, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(47, 19)
        Label2.TabIndex = 30
        Label2.Text = "From"
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Location = New Point(604, 23)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(189, 26)
        DateTimePicker2.TabIndex = 29
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(366, 22)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(201, 26)
        DateTimePicker1.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Arial", 12.0F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(772, 41)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(253, 26)
        ComboBox1.TabIndex = 32
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Arial", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(1040, 40)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(162, 32)
        ComboBox2.TabIndex = 34
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Arial", 12.0F)
        TextBox1.Location = New Point(102, 46)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(280, 26)
        TextBox1.TabIndex = 37
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(38, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 18)
        Label1.TabIndex = 38
        Label1.Text = "Search"
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(9.0F, 18.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1446, 790)
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
End Class
