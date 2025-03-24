<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        PictureBox5 = New PictureBox()
        Label3 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label5 = New Label()
        TextBox3 = New TextBox()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Button1 = New Button()
        DateTimePicker1 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        Button2 = New Button()
        Label10 = New Label()
        Label11 = New Label()
        TextBox4 = New TextBox()
        Label12 = New Label()
        Button3 = New Button()
        Label13 = New Label()
        Label14 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(982, 53)
        Panel1.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 19)
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
        ' Label2
        ' 
        Label2.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(76, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(441, 98)
        Label2.TabIndex = 4
        Label2.Text = "Book Title"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.image
        PictureBox5.Location = New Point(589, 78)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(317, 362)
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox5.TabIndex = 6
        PictureBox5.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.White
        Label3.BorderStyle = BorderStyle.Fixed3D
        Label3.FlatStyle = FlatStyle.Flat
        Label3.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(172, 197)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 25)
        Label3.TabIndex = 7
        Label3.Text = "000000"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(76, 272)
        Label4.Name = "Label4"
        Label4.Size = New Size(151, 23)
        Label4.TabIndex = 8
        Label4.Text = "Student Number"
        ' 
        ' TextBox1
        ' 
        TextBox1.Cursor = Cursors.IBeam
        TextBox1.Location = New Point(274, 272)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(198, 26)
        TextBox1.TabIndex = 9
        ' 
        ' TextBox2
        ' 
        TextBox2.Cursor = Cursors.IBeam
        TextBox2.Location = New Point(274, 310)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(279, 26)
        TextBox2.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(76, 310)
        Label5.Name = "Label5"
        Label5.Size = New Size(172, 23)
        Label5.TabIndex = 10
        Label5.Text = "Name of Borrower"
        ' 
        ' TextBox3
        ' 
        TextBox3.Cursor = Cursors.IBeam
        TextBox3.Location = New Point(274, 350)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(279, 26)
        TextBox3.TabIndex = 13
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(76, 350)
        Label6.Name = "Label6"
        Label6.Size = New Size(152, 23)
        Label6.TabIndex = 12
        Label6.Text = "Contact Number"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(76, 431)
        Label7.Name = "Label7"
        Label7.Size = New Size(122, 23)
        Label7.TabIndex = 14
        Label7.Text = "Borrow Date"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(76, 468)
        Label8.Name = "Label8"
        Label8.Size = New Size(93, 23)
        Label8.TabIndex = 16
        Label8.Text = "Due Date"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(274, 197)
        Label9.Name = "Label9"
        Label9.Size = New Size(82, 23)
        Label9.TabIndex = 18
        Label9.Text = "Copy ID"
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonHighlight
        Button1.Location = New Point(589, 473)
        Button1.Name = "Button1"
        Button1.Size = New Size(317, 41)
        Button1.TabIndex = 20
        Button1.Text = "BORROW"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Cursor = Cursors.Hand
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(274, 428)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(279, 26)
        DateTimePicker1.TabIndex = 21
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Cursor = Cursors.Hand
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.Location = New Point(274, 465)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(279, 26)
        DateTimePicker2.TabIndex = 22
        ' 
        ' Button2
        ' 
        Button2.BackgroundImage = My.Resources.Resources.back
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.Cursor = Cursors.Hand
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(14, 78)
        Button2.Name = "Button2"
        Button2.Size = New Size(15, 15)
        Button2.TabIndex = 23
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.White
        Label10.BorderStyle = BorderStyle.Fixed3D
        Label10.FlatStyle = FlatStyle.Flat
        Label10.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(397, 197)
        Label10.Name = "Label10"
        Label10.Size = New Size(156, 23)
        Label10.TabIndex = 24
        Label10.Text = "000000"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(76, 197)
        Label11.Name = "Label11"
        Label11.Size = New Size(81, 23)
        Label11.TabIndex = 25
        Label11.Text = "Book ID"
        ' 
        ' TextBox4
        ' 
        TextBox4.Cursor = Cursors.IBeam
        TextBox4.Location = New Point(274, 390)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(279, 26)
        TextBox4.TabIndex = 27
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(76, 390)
        Label12.Name = "Label12"
        Label12.Size = New Size(58, 23)
        Label12.TabIndex = 26
        Label12.Text = "Email"
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.DarkGreen
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.ForeColor = SystemColors.ButtonHighlight
        Button3.Location = New Point(478, 272)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 26)
        Button3.TabIndex = 28
        Button3.Text = "Check"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(76, 234)
        Label13.Name = "Label13"
        Label13.Size = New Size(117, 23)
        Label13.TabIndex = 29
        Label13.Text = "Call Number"
        ' 
        ' Label14
        ' 
        Label14.BackColor = Color.White
        Label14.BorderStyle = BorderStyle.Fixed3D
        Label14.FlatStyle = FlatStyle.Flat
        Label14.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(274, 234)
        Label14.Name = "Label14"
        Label14.Size = New Size(279, 23)
        Label14.TabIndex = 30
        Label14.Text = "000000"
        ' 
        ' Form8
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(982, 553)
        ControlBox = False
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Button3)
        Controls.Add(TextBox4)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Button2)
        Controls.Add(DateTimePicker2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Button1)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(TextBox3)
        Controls.Add(Label6)
        Controls.Add(TextBox2)
        Controls.Add(Label5)
        Controls.Add(TextBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(PictureBox5)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form8"
        Text = "Borrow Form"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
End Class
