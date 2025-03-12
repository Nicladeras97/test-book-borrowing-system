<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Panel2 = New Panel()
        PictureBox4 = New PictureBox()
        Label2 = New Label()
        Panel3 = New Panel()
        PictureBox5 = New PictureBox()
        Label3 = New Label()
        Panel4 = New Panel()
        PictureBox6 = New PictureBox()
        Label4 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.TabIndex = 3
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
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightBlue
        Panel2.Controls.Add(PictureBox4)
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(145, 186)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(196, 206)
        Panel2.TabIndex = 4
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.list
        PictureBox4.Location = New Point(69, 94)
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
        Label2.Location = New Point(72, 57)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 16)
        Label2.TabIndex = 0
        Label2.Text = "Books"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightBlue
        Panel3.Controls.Add(PictureBox5)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(405, 186)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(196, 206)
        Panel3.TabIndex = 5
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = My.Resources.Resources.Group_43
        PictureBox5.Location = New Point(75, 94)
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
        Label3.Location = New Point(73, 57)
        Label3.Name = "Label3"
        Label3.Size = New Size(55, 16)
        Label3.TabIndex = 0
        Label3.Text = "Records"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LightBlue
        Panel4.Controls.Add(PictureBox6)
        Panel4.Controls.Add(Label4)
        Panel4.Location = New Point(661, 186)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(196, 206)
        Panel4.TabIndex = 6
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Image = My.Resources.Resources.records
        PictureBox6.Location = New Point(75, 94)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(50, 53)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 1
        PictureBox6.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(82, 57)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 16)
        Label4.TabIndex = 0
        Label4.Text = "Logs"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        Name = "Form4"
        Text = "Form4"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label4 As Label
End Class
