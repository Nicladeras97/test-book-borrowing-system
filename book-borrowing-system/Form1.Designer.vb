Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography

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
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Panel1 = New Panel()
        linkGoToSignUp = New LinkLabel()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        Label3 = New Label()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = My.Resources.Resources.book
        LogoPictureBox.Location = New Point(234, 202)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(292, 230)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Arial", 9.75F)
        UsernameLabel.Location = New Point(38, 150)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(74, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Username"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Font = New Font("Arial", 9.75F)
        PasswordLabel.Location = New Point(38, 186)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(70, 23)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Password"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Cursor = Cursors.IBeam
        UsernameTextBox.Location = New Point(114, 152)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(161, 23)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Cursor = Cursors.IBeam
        PasswordTextBox.Location = New Point(114, 189)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(161, 23)
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
        OK.Location = New Point(24, 246)
        OK.Name = "OK"
        OK.Size = New Size(271, 30)
        OK.TabIndex = 4
        OK.Text = "LOGIN"
        OK.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(linkGoToSignUp)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(PasswordLabel)
        Panel1.Controls.Add(OK)
        Panel1.Controls.Add(UsernameLabel)
        Panel1.Controls.Add(PasswordTextBox)
        Panel1.Controls.Add(UsernameTextBox)
        Panel1.Location = New Point(822, 92)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(318, 340)
        Panel1.TabIndex = 5
        ' 
        ' linkGoToSignUp
        ' 
        linkGoToSignUp.AutoSize = True
        linkGoToSignUp.Location = New Point(206, 304)
        linkGoToSignUp.Name = "linkGoToSignUp"
        linkGoToSignUp.Size = New Size(89, 15)
        linkGoToSignUp.TabIndex = 8
        linkGoToSignUp.TabStop = True
        linkGoToSignUp.Text = "Create Account"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.book
        PictureBox1.Location = New Point(142, 31)
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
        Label4.Location = New Point(93, 110)
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
        Label3.Location = New Point(59, 74)
        Label3.Name = "Label3"
        Label3.Size = New Size(216, 32)
        Label3.TabIndex = 5
        Label3.Text = "Welcome Back!"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1225, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(60, 29)
        Button1.TabIndex = 7
        Button1.Text = "EXIT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 48.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(602, 75)
        Label1.TabIndex = 5
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
        Label2.TabIndex = 6
        Label2.Text = "System"
        ' 
        ' Form1
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1297, 565)
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "Book Borrowing System"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents linkGoToSignUp As LinkLabel

    ' Database connection string
    Private conn As New MySqlConnection("server=localhost;user id=root;password=;database=book-borrowing")

    ' Function to hash input password for comparison
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub BtnSignUp_Click(sender As Object, e As EventArgs) Handles OK.Click
        ' Validation: Ensure both fields are filled
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            conn.Open()

            ' Retrieve stored hashed password
            Dim query As String = "SELECT Password FROM librarians WHERE Username = @Username"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

            Dim storedHash As Object = cmd.ExecuteScalar()

            ' Check if user exists
            If storedHash IsNot Nothing Then
                Dim inputHashedPassword As String = HashPassword(PasswordTextBox.Text)

                ' Compare stored and input hashed passwords
                If storedHash.ToString() = inputHashedPassword Then
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Hide the current form
                    Me.Hide()

                    ' Show Form11 only if it's not already open
                    If Not Form11.Visible Then
                        Form11.Show()
                    End If

                Else
                    MessageBox.Show("Incorrect password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

End Class