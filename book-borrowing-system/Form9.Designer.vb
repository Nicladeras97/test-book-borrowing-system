<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
        Button3 = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Label7 = New Label()
        TextBox2 = New TextBox()
        Label5 = New Label()
        TextBox1 = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        PictureBox5 = New PictureBox()
        Label2 = New Label()
        Label11 = New Label()
        Button2 = New Button()
        Label6 = New Label()
        ComboBox1 = New ComboBox()
        DateTimePicker1 = New DateTimePicker()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(984, 57)
        Panel1.TabIndex = 4
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.notification
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(948, 18)
        Button3.Name = "Button3"
        Button3.Size = New Size(15, 16)
        Button3.TabIndex = 10
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(147, 16)
        Label1.TabIndex = 1
        Label1.Text = "Book Borrowing System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(12, 16)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(20, 22)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonHighlight
        Button1.Location = New Point(589, 473)
        Button1.Name = "Button1"
        Button1.Size = New Size(317, 44)
        Button1.TabIndex = 37
        Button1.Text = "RETURN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(80, 403)
        Label7.Name = "Label7"
        Label7.Size = New Size(129, 18)
        Label7.TabIndex = 31
        Label7.Text = "Conditon of Book"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(274, 356)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(247, 22)
        TextBox2.TabIndex = 28
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(80, 360)
        Label5.Name = "Label5"
        Label5.Size = New Size(98, 18)
        Label5.TabIndex = 27
        Label5.Text = "Borrowed By"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(274, 316)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(247, 22)
        TextBox1.TabIndex = 26
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(80, 320)
        Label4.Name = "Label4"
        Label4.Size = New Size(120, 18)
        Label4.TabIndex = 25
        Label4.Text = "Student Number"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(274, 272)
        Label3.Name = "Label3"
        Label3.Size = New Size(62, 18)
        Label3.TabIndex = 24
        Label3.Text = "000000"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.image
        PictureBox5.Location = New Point(589, 129)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(317, 319)
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox5.TabIndex = 23
        PictureBox5.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(80, 126)
        Label2.Name = "Label2"
        Label2.Size = New Size(441, 105)
        Label2.TabIndex = 21
        Label2.Text = "Book Title"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(80, 272)
        Label11.Name = "Label11"
        Label11.Size = New Size(64, 18)
        Label11.TabIndex = 39
        Label11.Text = "Book ID"
        ' 
        ' Button2
        ' 
        Button2.BackgroundImage = My.Resources.Resources.back
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(59, 129)
        Button2.Name = "Button2"
        Button2.Size = New Size(15, 16)
        Button2.TabIndex = 40
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(80, 444)
        Label6.Name = "Label6"
        Label6.Size = New Size(91, 18)
        Label6.TabIndex = 41
        Label6.Text = "Return Date"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(274, 397)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(247, 24)
        ComboBox1.TabIndex = 42
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CalendarFont = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePicker1.Location = New Point(274, 441)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(247, 22)
        DateTimePicker1.TabIndex = 43
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        Controls.Add(DateTimePicker1)
        Controls.Add(ComboBox1)
        Controls.Add(Label6)
        Controls.Add(Button2)
        Controls.Add(Label11)
        Controls.Add(Button1)
        Controls.Add(Label7)
        Controls.Add(TextBox2)
        Controls.Add(Label5)
        Controls.Add(TextBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(PictureBox5)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form9"
        Text = "Return Book"
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
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
