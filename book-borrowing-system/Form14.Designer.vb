Imports System.Text
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Label1 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
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
        LogoPictureBox = New PictureBox()
        txtUsername = New TextBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 48.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(602, 75)
        Label1.TabIndex = 6
        Label1.Text = "Book Management"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Arial", 36.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(67, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(183, 55)
        Label2.TabIndex = 7
        Label2.Text = "System"
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
        Panel1.Location = New Point(822, 92)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(318, 340)
        Panel1.TabIndex = 8
        ' 
        ' btnBack
        ' 
        btnBack.AutoSize = True
        btnBack.Location = New Point(214, 311)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(78, 15)
        btnBack.TabIndex = 13
        btnBack.TabStop = True
        btnBack.Text = "Login instead"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 9.75F)
        Label6.Location = New Point(20, 213)
        Label6.Name = "Label6"
        Label6.Size = New Size(112, 16)
        Label6.TabIndex = 12
        Label6.Text = "Confirm Password"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.Cursor = Cursors.IBeam
        txtConfirmPassword.Location = New Point(142, 206)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.PasswordChar = "*"c
        txtConfirmPassword.Size = New Size(161, 23)
        txtConfirmPassword.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Arial", 9.75F)
        Label5.Location = New Point(20, 170)
        Label5.Name = "Label5"
        Label5.Size = New Size(70, 23)
        Label5.TabIndex = 8
        Label5.Text = "Password"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Cursor = Cursors.IBeam
        txtPassword.Location = New Point(142, 170)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(161, 23)
        txtPassword.TabIndex = 9
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.book
        PictureBox1.Location = New Point(20, 17)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(30, 30)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.ActiveCaptionText
        Label4.Location = New Point(89, 70)
        Label4.Name = "Label4"
        Label4.Size = New Size(146, 15)
        Label4.TabIndex = 6
        Label4.Text = "Please enter your details."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(98, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(127, 32)
        Label3.TabIndex = 5
        Label3.Text = "Sign Up!"
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Font = New Font("Arial", 9.75F)
        PasswordLabel.Location = New Point(20, 136)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(70, 23)
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
        btnSignUp.Location = New Point(32, 262)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(271, 30)
        btnSignUp.TabIndex = 4
        btnSignUp.Text = "SIGNUP"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Arial", 9.75F)
        UsernameLabel.Location = New Point(20, 100)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(74, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "Full Name"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtFullName
        ' 
        txtFullName.BorderStyle = BorderStyle.FixedSingle
        txtFullName.Cursor = Cursors.IBeam
        txtFullName.Location = New Point(142, 100)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(161, 23)
        txtFullName.TabIndex = 1
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = My.Resources.Resources.book
        LogoPictureBox.Location = New Point(234, 202)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(292, 230)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 8
        LogoPictureBox.TabStop = False
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Cursor = Cursors.IBeam
        txtUsername.Location = New Point(142, 136)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(161, 23)
        txtUsername.TabIndex = 14
        ' 
        ' Form14
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1297, 565)
        Controls.Add(LogoPictureBox)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form14"
        Text = "Form14"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents btnSignUp As Button
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBack As LinkLabel

    ' MySQL Connection String (Modify this as needed)
    Dim conn As New MySqlConnection("server=localhost; user=root; password=; database=book-borrowing;")

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub BtnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        ' Validation: Check if any field is empty
        If txtFullName.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if passwords match
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            ' Check if username already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM librarians WHERE Username = @Username"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If userExists > 0 Then
                MessageBox.Show("Username already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                Exit Sub
            End If

            ' Hash the password before storing it
            Dim hashedPassword As String = HashPassword(txtPassword.Text)

            ' Insert new librarian with hashed password
            Dim query As String = "INSERT INTO librarians (FullName, Username, Password) VALUES (@FullName, @Username, @Password)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", hashedPassword) ' Store hashed password

            cmd.ExecuteNonQuery()
            MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear fields
            txtFullName.Clear()
            txtUsername.Clear()
            txtPassword.Clear()
            txtConfirmPassword.Clear()

            ' Redirect to login
            Me.Hide()
            Form1.Show()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form1.Show() ' Assuming Form1 is your login form
    End Sub

    Friend WithEvents txtUsername As TextBox
End Class
