<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label2 = New Label()
        PictureBox4 = New PictureBox()
        TextBox1 = New TextBox()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.TabIndex = 2
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
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Location = New Point(119, 238)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(734, 260)
        FlowLayoutPanel1.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(119, 197)
        Label2.Name = "Label2"
        Label2.Size = New Size(125, 18)
        Label2.TabIndex = 8
        Label2.Text = "Borrowed Books"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.search
        PictureBox4.Location = New Point(119, 95)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(23, 28)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 7
        PictureBox4.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(148, 95)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(705, 26)
        TextBox1.TabIndex = 6
        TextBox1.Text = "Search"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(Label2)
        Controls.Add(PictureBox4)
        Controls.Add(TextBox1)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form3"
        Text = "Form3"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TextBox1 As TextBox
End Class
