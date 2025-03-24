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
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        PictureBox5 = New PictureBox()
        Label2 = New Label()
        Label11 = New Label()
        Back = New Button()
        Label6 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Button2 = New Button()
        Button3 = New Button()
        Label7 = New Label()
        Label8 = New Label()
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
        Panel1.Size = New Size(982, 57)
        Panel1.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 19)
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
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonHighlight
        Button1.Location = New Point(81, 466)
        Button1.Name = "Button1"
        Button1.Size = New Size(124, 44)
        Button1.TabIndex = 37
        Button1.Text = "Return"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(80, 359)
        Label5.Name = "Label5"
        Label5.Size = New Size(125, 23)
        Label5.TabIndex = 27
        Label5.Text = "Borrowed By"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(80, 319)
        Label4.Name = "Label4"
        Label4.Size = New Size(151, 23)
        Label4.TabIndex = 25
        Label4.Text = "Student Number"
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.ButtonFace
        Label3.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(274, 281)
        Label3.Name = "Label3"
        Label3.Size = New Size(273, 23)
        Label3.TabIndex = 24
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.image
        PictureBox5.Location = New Point(589, 120)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(317, 390)
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox5.TabIndex = 23
        PictureBox5.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(80, 120)
        Label2.Name = "Label2"
        Label2.Size = New Size(467, 105)
        Label2.TabIndex = 21
        Label2.Text = "Book Title"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(80, 281)
        Label11.Name = "Label11"
        Label11.Size = New Size(81, 23)
        Label11.TabIndex = 39
        Label11.Text = "Book ID"
        ' 
        ' Back
        ' 
        Back.BackgroundImage = My.Resources.Resources.back
        Back.BackgroundImageLayout = ImageLayout.Zoom
        Back.Cursor = Cursors.Hand
        Back.FlatAppearance.BorderSize = 0
        Back.FlatStyle = FlatStyle.Flat
        Back.Location = New Point(14, 78)
        Back.Name = "Back"
        Back.Size = New Size(15, 16)
        Back.TabIndex = 40
        Back.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(81, 401)
        Label6.Name = "Label6"
        Label6.Size = New Size(116, 23)
        Label6.TabIndex = 41
        Label6.Text = "Return Date"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CalendarFont = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePicker1.Cursor = Cursors.Hand
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(274, 399)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(273, 26)
        DateTimePicker1.TabIndex = 43
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.HotTrack
        Button2.Cursor = Cursors.Hand
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = SystemColors.ButtonHighlight
        Button2.Location = New Point(211, 466)
        Button2.Name = "Button2"
        Button2.Size = New Size(183, 44)
        Button2.TabIndex = 44
        Button2.Text = "Damaged"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.HotTrack
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = SystemColors.ButtonHighlight
        Button3.Location = New Point(400, 466)
        Button3.Name = "Button3"
        Button3.Size = New Size(147, 44)
        Button3.TabIndex = 45
        Button3.Text = "Lost"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.BackColor = SystemColors.ButtonFace
        Label7.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(274, 359)
        Label7.Name = "Label7"
        Label7.Size = New Size(273, 23)
        Label7.TabIndex = 46
        ' 
        ' Label8
        ' 
        Label8.BackColor = SystemColors.ButtonFace
        Label8.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(274, 319)
        Label8.Name = "Label8"
        Label8.Size = New Size(273, 23)
        Label8.TabIndex = 47
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(982, 553)
        ControlBox = False
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label6)
        Controls.Add(Back)
        Controls.Add(Label11)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(PictureBox5)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form9"
        Text = "Return Form"
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
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Back As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
