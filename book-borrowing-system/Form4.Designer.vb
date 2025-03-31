<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Panel1 = New Panel()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Button4 = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.Size = New Size(1370, 53)
        Panel1.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(165, 16)
        Label1.TabIndex = 1
        Label1.Text = "Book Management System"
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
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightBlue
        Panel2.Controls.Add(PictureBox4)
        Panel2.Controls.Add(Label2)
        Panel2.Cursor = Cursors.Hand
        Panel2.Location = New Point(493, 268)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(196, 206)
        Panel2.TabIndex = 4
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.logo
        PictureBox4.Location = New Point(75, 94)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(50, 53)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 1
        PictureBox4.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(41, 57)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 19)
        Label2.TabIndex = 0
        Label2.Text = "Manage Books"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightBlue
        Panel3.Controls.Add(PictureBox5)
        Panel3.Controls.Add(Label3)
        Panel3.Cursor = Cursors.Hand
        Panel3.Location = New Point(753, 268)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(196, 206)
        Panel3.TabIndex = 5
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.list
        PictureBox5.Location = New Point(78, 94)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(50, 53)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 1
        PictureBox5.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(50, 57)
        Label3.Name = "Label3"
        Label3.Size = New Size(99, 19)
        Label3.TabIndex = 0
        Label3.Text = "Book Report"
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.back
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(38, 80)
        Button3.Name = "Button3"
        Button3.Size = New Size(30, 40)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.LightBlue
        Button2.BackgroundImageLayout = ImageLayout.Center
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(617, 286)
        Button2.Name = "Button2"
        Button2.Size = New Size(239, 228)
        Button2.TabIndex = 15
        Button2.Text = "Manage Books"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightBlue
        Button1.BackgroundImageLayout = ImageLayout.Center
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(913, 286)
        Button1.Name = "Button1"
        Button1.Size = New Size(239, 228)
        Button1.TabIndex = 16
        Button1.Text = "Book Reports"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.LightBlue
        Button4.BackgroundImageLayout = ImageLayout.Center
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(311, 286)
        Button4.Name = "Button4"
        Button4.Size = New Size(239, 228)
        Button4.TabIndex = 17
        Button4.Text = "Return Book"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 16.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        ControlBox = False
        Controls.Add(Button4)
        Controls.Add(Button1)
        Controls.Add(Button2)
        Controls.Add(Button3)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        Name = "Form4"
        Text = "     "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
End Class
