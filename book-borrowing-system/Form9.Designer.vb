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
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Label9 = New Label()
        TextBox4 = New TextBox()
        Label7 = New Label()
        TextBox2 = New TextBox()
        Label5 = New Label()
        TextBox1 = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        PictureBox5 = New PictureBox()
        PictureBox4 = New PictureBox()
        Label2 = New Label()
        Label6 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
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
        Label1.Size = New Size(133, 15)
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
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonHighlight
        Button1.Location = New Point(589, 443)
        Button1.Name = "Button1"
        Button1.Size = New Size(317, 41)
        Button1.TabIndex = 37
        Button1.Text = "RETURN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(80, 260)
        Label9.Name = "Label9"
        Label9.Size = New Size(104, 18)
        Label9.TabIndex = 35
        Label9.Text = "No. of Copies"
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(274, 377)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(247, 23)
        TextBox4.TabIndex = 32
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(80, 377)
        Label7.Name = "Label7"
        Label7.Size = New Size(91, 18)
        Label7.TabIndex = 31
        Label7.Text = "Return Date"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(274, 334)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(247, 23)
        TextBox2.TabIndex = 28
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(80, 334)
        Label5.Name = "Label5"
        Label5.Size = New Size(78, 18)
        Label5.TabIndex = 27
        Label5.Text = "Full Name"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(274, 296)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(247, 23)
        TextBox1.TabIndex = 26
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(80, 296)
        Label4.Name = "Label4"
        Label4.Size = New Size(120, 18)
        Label4.TabIndex = 25
        Label4.Text = "Student Number"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(80, 229)
        Label3.Name = "Label3"
        Label3.Size = New Size(44, 18)
        Label3.TabIndex = 24
        Label3.Text = "0000"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.image
        PictureBox5.Location = New Point(589, 121)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(317, 299)
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox5.TabIndex = 23
        PictureBox5.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.back
        PictureBox4.Location = New Point(50, 121)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(15, 16)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 22
        PictureBox4.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(80, 118)
        Label2.Name = "Label2"
        Label2.Size = New Size(441, 98)
        Label2.TabIndex = 21
        Label2.Text = "Book Title"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(274, 260)
        Label6.Name = "Label6"
        Label6.Size = New Size(26, 18)
        Label6.TabIndex = 38
        Label6.Text = "00"
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        Controls.Add(Label6)
        Controls.Add(Button1)
        Controls.Add(Label9)
        Controls.Add(TextBox4)
        Controls.Add(Label7)
        Controls.Add(TextBox2)
        Controls.Add(Label5)
        Controls.Add(TextBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox4)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Name = "Form9"
        Text = "Return Book"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
End Class
