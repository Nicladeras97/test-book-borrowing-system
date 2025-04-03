<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class Form1
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Panel1 = New Panel()
        PictureBox2 = New PictureBox()
        Label5 = New Label()
        LinkLabel1 = New LinkLabel()
        Button1 = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Arial", 9.75F)
        UsernameLabel.Location = New Point(67, 196)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(96, 31)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Username"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Font = New Font("Arial", 9.75F)
        PasswordLabel.Location = New Point(67, 238)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(96, 31)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Password"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Cursor = Cursors.IBeam
        UsernameTextBox.Location = New Point(169, 200)
        UsernameTextBox.Margin = New Padding(3, 4, 3, 4)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(239, 27)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Cursor = Cursors.IBeam
        PasswordTextBox.Location = New Point(169, 244)
        PasswordTextBox.Margin = New Padding(3, 4, 3, 4)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.Size = New Size(211, 27)
        PasswordTextBox.TabIndex = 3
        ' 
        ' OK
        ' 
        OK.BackColor = SystemColors.HotTrack
        OK.BackgroundImageLayout = ImageLayout.None
        OK.Cursor = Cursors.Hand
        OK.FlatAppearance.BorderSize = 0
        OK.FlatStyle = FlatStyle.Flat
        OK.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        OK.ForeColor = Color.White
        OK.Location = New Point(68, 292)
        OK.Margin = New Padding(3, 4, 3, 4)
        OK.Name = "OK"
        OK.Size = New Size(340, 39)
        OK.TabIndex = 4
        OK.Text = "LOGIN"
        OK.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(LinkLabel1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(PasswordLabel)
        Panel1.Controls.Add(OK)
        Panel1.Controls.Add(UsernameLabel)
        Panel1.Controls.Add(PasswordTextBox)
        Panel1.Controls.Add(UsernameTextBox)
        Panel1.Location = New Point(464, 148)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(482, 532)
        Panel1.TabIndex = 5
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImageLayout = ImageLayout.Center
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
        PictureBox2.Cursor = Cursors.Hand
        PictureBox2.Location = New Point(377, 244)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(31, 27)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ActiveCaptionText
        Label5.Location = New Point(114, 441)
        Label5.Name = "Label5"
        Label5.Size = New Size(161, 17)
        Label5.TabIndex = 9
        Label5.Text = "Don't have an account?"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.Transparent
        LinkLabel1.Location = New Point(281, 438)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(63, 20)
        LinkLabel1.TabIndex = 8
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Register"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(68, 346)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(340, 38)
        Button1.TabIndex = 7
        Button1.Text = "EXIT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(153, 138)
        Label4.Name = "Label4"
        Label4.Size = New Size(172, 17)
        Label4.TabIndex = 6
        Label4.Text = "Please enter your details."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(108, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(266, 40)
        Label3.TabIndex = 5
        Label3.Text = "Welcome Back!"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1482, 70)
        Panel2.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(94, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(385, 33)
        Label1.TabIndex = 1
        Label1.Text = "Book- Management System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.cmilogo
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(72, 70)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1482, 753)
        ControlBox = False
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox

End Class
