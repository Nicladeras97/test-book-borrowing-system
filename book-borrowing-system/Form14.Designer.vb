<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form14
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
        txtUsername = New TextBox()
        btnBack = New LinkLabel()
        Label6 = New Label()
        txtConfirmPassword = New TextBox()
        Label5 = New Label()
        txtPassword = New TextBox()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        Label3 = New Label()
        PasswordLabel = New Label()
        btnSignUp = New Button()
        UsernameLabel = New Label()
        txtFullName = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        LogoPictureBox = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(btnBack)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(txtConfirmPassword)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(PasswordLabel)
        Panel1.Controls.Add(btnSignUp)
        Panel1.Controls.Add(UsernameLabel)
        Panel1.Controls.Add(txtFullName)
        Panel1.Location = New Point(949, 123)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(363, 453)
        Panel1.TabIndex = 9
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Cursor = Cursors.IBeam
        txtUsername.Location = New Point(162, 181)
        txtUsername.Margin = New Padding(3, 4, 3, 4)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(184, 27)
        txtUsername.TabIndex = 14
        ' 
        ' btnBack
        ' 
        btnBack.AutoSize = True
        btnBack.Location = New Point(245, 415)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(98, 20)
        btnBack.TabIndex = 13
        btnBack.TabStop = True
        btnBack.Text = "Login instead"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 9.75F)
        Label6.Location = New Point(23, 284)
        Label6.Name = "Label6"
        Label6.Size = New Size(143, 19)
        Label6.TabIndex = 12
        Label6.Text = "Confirm Password"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.Cursor = Cursors.IBeam
        txtConfirmPassword.Location = New Point(162, 275)
        txtConfirmPassword.Margin = New Padding(3, 4, 3, 4)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.PasswordChar = "*"c
        txtConfirmPassword.Size = New Size(184, 27)
        txtConfirmPassword.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Arial", 9.75F)
        Label5.Location = New Point(23, 227)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 31)
        Label5.TabIndex = 8
        Label5.Text = "Password"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Cursor = Cursors.IBeam
        txtPassword.Location = New Point(162, 227)
        txtPassword.Margin = New Padding(3, 4, 3, 4)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(184, 27)
        txtPassword.TabIndex = 9
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.book
        PictureBox1.Location = New Point(23, 23)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(34, 40)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(102, 93)
        Label4.Name = "Label4"
        Label4.Size = New Size(172, 17)
        Label4.TabIndex = 6
        Label4.Text = "Please enter your details."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(112, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(156, 40)
        Label3.TabIndex = 5
        Label3.Text = "Sign Up!"
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Font = New Font("Arial", 9.75F)
        PasswordLabel.Location = New Point(23, 181)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(80, 31)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "Username"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnSignUp
        ' 
        btnSignUp.BackColor = SystemColors.HotTrack
        btnSignUp.BackgroundImageLayout = ImageLayout.None
        btnSignUp.Cursor = Cursors.Hand
        btnSignUp.FlatAppearance.BorderSize = 0
        btnSignUp.FlatStyle = FlatStyle.Flat
        btnSignUp.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSignUp.ForeColor = Color.White
        btnSignUp.Location = New Point(37, 349)
        btnSignUp.Margin = New Padding(3, 4, 3, 4)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(310, 40)
        btnSignUp.TabIndex = 4
        btnSignUp.Text = "SIGNUP"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Arial", 9.75F)
        UsernameLabel.Location = New Point(23, 133)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(85, 31)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "Full Name"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtFullName
        ' 
        txtFullName.BorderStyle = BorderStyle.FixedSingle
        txtFullName.Cursor = Cursors.IBeam
        txtFullName.Location = New Point(162, 133)
        txtFullName.Margin = New Padding(3, 4, 3, 4)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(184, 27)
        txtFullName.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Arial", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(60, 158)
        Label2.Name = "Label2"
        Label2.Size = New Size(227, 67)
        Label2.TabIndex = 12
        Label2.Text = "System"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(60, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(750, 93)
        Label1.TabIndex = 11
        Label1.Text = "Book Management"
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = My.Resources.Resources.book
        LogoPictureBox.Location = New Point(267, 269)
        LogoPictureBox.Margin = New Padding(3, 4, 3, 4)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(334, 307)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 10
        LogoPictureBox.TabStop = False
        ' 
        ' Form14
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1482, 753)
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(LogoPictureBox)
        Controls.Add(Panel1)
        Name = "Form14"
        Text = "     "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnBack As LinkLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents btnSignUp As Button
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LogoPictureBox As PictureBox
End Class
