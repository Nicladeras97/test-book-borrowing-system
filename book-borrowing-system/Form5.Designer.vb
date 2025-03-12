<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Panel1 = New Panel()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox4 = New PictureBox()
        Label2 = New Label()
        Panel2 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        PictureBox5 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(984, 53)
        Panel1.TabIndex = 4
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.notification
        PictureBox3.Location = New Point(950, 17)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(15, 16)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.home
        PictureBox2.Location = New Point(916, 17)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(15, 16)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(147, 16)
        Label1.TabIndex = 1
        Label1.Text = "Book Borrowing System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(12, 15)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(20, 21)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.add
        PictureBox4.Location = New Point(3, 3)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(20, 20)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 5
        PictureBox4.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(31, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 16)
        Label2.TabIndex = 6
        Label2.Text = "Add Books"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(PictureBox4)
        Panel2.Location = New Point(38, 82)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(108, 27)
        Panel2.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 7
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.283783F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 78.71622F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 183F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 163F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 117F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 63F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 75F))
        TableLayoutPanel1.Controls.Add(Label9, 6, 0)
        TableLayoutPanel1.Controls.Add(Label8, 5, 0)
        TableLayoutPanel1.Controls.Add(Label7, 4, 0)
        TableLayoutPanel1.Controls.Add(Label6, 3, 0)
        TableLayoutPanel1.Controls.Add(Label5, 2, 0)
        TableLayoutPanel1.Controls.Add(Label3, 0, 0)
        TableLayoutPanel1.Controls.Add(Label4, 1, 0)
        TableLayoutPanel1.Location = New Point(38, 131)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.Padding = New Padding(4)
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 10.7416878F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 89.25831F))
        TableLayoutPanel1.Size = New Size(906, 389)
        TableLayoutPanel1.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.FlatStyle = FlatStyle.Flat
        Label3.Location = New Point(7, 4)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 16)
        Label3.TabIndex = 0
        Label3.Text = "Book ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.FlatStyle = FlatStyle.Flat
        Label4.Location = New Point(70, 4)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 16)
        Label4.TabIndex = 1
        Label4.Text = "Book Title"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.FlatStyle = FlatStyle.Flat
        Label5.Location = New Point(303, 4)
        Label5.Name = "Label5"
        Label5.Size = New Size(78, 16)
        Label5.TabIndex = 2
        Label5.Text = "Book Author"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.FlatStyle = FlatStyle.Flat
        Label6.Location = New Point(486, 4)
        Label6.Name = "Label6"
        Label6.Size = New Size(37, 16)
        Label6.TabIndex = 3
        Label6.Text = "ISBN"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.FlatStyle = FlatStyle.Flat
        Label7.Location = New Point(649, 4)
        Label7.Name = "Label7"
        Label7.Size = New Size(59, 16)
        Label7.TabIndex = 4
        Label7.Text = "Category"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.FlatStyle = FlatStyle.Flat
        Label8.Location = New Point(766, 4)
        Label8.Name = "Label8"
        Label8.Size = New Size(47, 32)
        Label8.TabIndex = 5
        Label8.Text = "No. of Copies"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.FlatStyle = FlatStyle.Flat
        Label9.Location = New Point(829, 4)
        Label9.Name = "Label9"
        Label9.Size = New Size(45, 16)
        Label9.TabIndex = 6
        Label9.Text = "Status"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.back
        PictureBox5.Location = New Point(17, 87)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(15, 15)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 9
        PictureBox5.TabStop = False
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        Controls.Add(PictureBox5)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form5"
        Text = "Books"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox5 As PictureBox
End Class
