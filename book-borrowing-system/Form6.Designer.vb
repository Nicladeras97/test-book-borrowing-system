<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Button2 = New Button()
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        Button4 = New Button()
        Button6 = New Button()
        Label5 = New Label()
        Button7 = New Button()
        Label3 = New Label()
        Label2 = New Label()
        DateTimePicker2 = New DateTimePicker()
        DateTimePicker1 = New DateTimePicker()
        ComboBox1 = New ComboBox()
        Button1 = New Button()
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
        Button2.Location = New Point(1346, 36)
        Button2.Name = "Button2"
        Button2.Size = New Size(89, 33)
        Button2.TabIndex = 7
        Button2.Text = "Export"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.back
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(38, 43)
        Button3.Name = "Button3"
        Button3.Size = New Size(27, 24)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
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
        DataGridView1.Location = New Point(38, 99)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1365, 500)
        DataGridView1.TabIndex = 14
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.HotTrack
        Button4.Cursor = Cursors.Hand
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.White
        Button4.Location = New Point(1251, 36)
        Button4.Name = "Button4"
        Button4.Size = New Size(89, 33)
        Button4.TabIndex = 15
        Button4.Text = "Print"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.Cursor = Cursors.Hand
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Location = New Point(985, 618)
        Button6.Name = "Button6"
        Button6.Size = New Size(66, 28)
        Button6.TabIndex = 23
        Button6.Text = "Next"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(530, 620)
        Label5.Name = "Label5"
        Label5.Size = New Size(449, 24)
        Label5.TabIndex = 22
        Label5.Text = "1/10"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button7
        ' 
        Button7.Cursor = Cursors.Hand
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Location = New Point(458, 618)
        Button7.Name = "Button7"
        Button7.Size = New Size(66, 28)
        Button7.TabIndex = 21
        Button7.Text = "Back"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(928, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(25, 19)
        Label3.TabIndex = 31
        Label3.Text = "To"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(667, 46)
        Label2.Name = "Label2"
        Label2.Size = New Size(47, 19)
        Label2.TabIndex = 30
        Label2.Text = "From"
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.CustomFormat = "MMMM dd, yyyy"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Location = New Point(959, 41)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(189, 26)
        DateTimePicker2.TabIndex = 29
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "MMMM dd, yyyy"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(721, 40)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(201, 26)
        DateTimePicker1.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(389, 40)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(253, 26)
        ComboBox1.TabIndex = 32
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1156, 36)
        Button1.Name = "Button1"
        Button1.Size = New Size(89, 33)
        Button1.TabIndex = 33
        Button1.Text = "Filter"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1446, 688)
        Controls.Add(Button1)
        Controls.Add(ComboBox1)
        Controls.Add(Label3)
        Controls.Add(Button6)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(DateTimePicker2)
        Controls.Add(Button7)
        Controls.Add(DateTimePicker1)
        Controls.Add(Button4)
        Controls.Add(Button2)
        Controls.Add(DataGridView1)
        Controls.Add(Button3)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form6"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
End Class
