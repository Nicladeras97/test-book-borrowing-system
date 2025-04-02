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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
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
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Panel1 = New Panel()
        Label5 = New Label()
        LinkLabel1 = New LinkLabel()
        Button1 = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Button2 = New Button()
        Panel2 = New Panel()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.BackColor = Color.Transparent
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), Image)
        LogoPictureBox.Location = New Point(234, 211)
        LogoPictureBox.Margin = New Padding(3, 4, 3, 4)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(412, 416)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Arial", 9.75F)
        UsernameLabel.Location = New Point(44, 200)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(85, 31)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Username"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Font = New Font("Arial", 9.75F)
        PasswordLabel.Location = New Point(44, 248)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(80, 31)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Password"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Cursor = Cursors.IBeam
        UsernameTextBox.Location = New Point(130, 202)
        UsernameTextBox.Margin = New Padding(3, 4, 3, 4)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(227, 27)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Cursor = Cursors.IBeam
        PasswordTextBox.Location = New Point(130, 252)
        PasswordTextBox.Margin = New Padding(3, 4, 3, 4)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(227, 27)
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
        OK.Location = New Point(44, 299)
        OK.Margin = New Padding(3, 4, 3, 4)
        OK.Name = "OK"
        OK.Size = New Size(313, 40)
        OK.TabIndex = 4
        OK.Text = "LOGIN"
        OK.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
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
        Panel1.Location = New Point(941, 136)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(395, 491)
        Panel1.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ActiveCaptionText
        Label5.Location = New Point(44, 403)
        Label5.Name = "Label5"
        Label5.Size = New Size(161, 17)
        Label5.TabIndex = 9
        Label5.Text = "Don't have an account?"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.Transparent
        LinkLabel1.Location = New Point(211, 400)
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
        Button1.Location = New Point(44, 347)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(313, 39)
        Button1.TabIndex = 7
        Button1.Text = "EXIT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(114, 124)
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
        Label3.Location = New Point(69, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(266, 40)
        Label3.TabIndex = 5
        Label3.Text = "Welcome Back!"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(23, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(750, 93)
        Label1.TabIndex = 5
        Label1.Text = "Book Management"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Arial", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(23, 127)
        Label2.Name = "Label2"
        Label2.Size = New Size(227, 67)
        Label2.TabIndex = 6
        Label2.Text = "System"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.IndianRed
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 12F)
        Button2.ForeColor = SystemColors.ControlLightLight
        Button2.Location = New Point(1204, 49)
        Button2.Name = "Button2"
        Button2.Size = New Size(122, 45)
        Button2.TabIndex = 8
        Button2.Text = "Barcode"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Panel1)
        Panel2.Controls.Add(LogoPictureBox)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1482, 753)
        Panel2.TabIndex = 9
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
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        WindowState = FormWindowState.Maximized
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel

End Class
