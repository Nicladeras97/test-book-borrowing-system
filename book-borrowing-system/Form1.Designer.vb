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
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        Label3 = New Label()
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
        LogoPictureBox.Location = New Point(267, 269)
        LogoPictureBox.Margin = New Padding(3, 4, 3, 4)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(334, 307)
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
        UsernameTextBox.Size = New Size(183, 27)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Cursor = Cursors.IBeam
        PasswordTextBox.Location = New Point(130, 252)
        PasswordTextBox.Margin = New Padding(3, 4, 3, 4)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(183, 27)
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
        OK.Location = New Point(23, 327)
        OK.Margin = New Padding(3, 4, 3, 4)
        OK.Name = "OK"
        OK.Size = New Size(310, 40)
        OK.TabIndex = 4
        OK.Text = "LOGIN"
        OK.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(PasswordLabel)
        Panel1.Controls.Add(OK)
        Panel1.Controls.Add(UsernameLabel)
        Panel1.Controls.Add(PasswordTextBox)
        Panel1.Controls.Add(UsernameTextBox)
        Panel1.Location = New Point(939, 122)
        Panel1.Margin = New Padding(3, 4, 3, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(363, 454)
        Panel1.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(23, 375)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(310, 39)
        Button1.TabIndex = 7
        Button1.Text = "EXIT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.book
        PictureBox1.Location = New Point(162, 41)
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
        Label4.Location = New Point(96, 141)
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
        Label3.Location = New Point(44, 92)
        Label3.Name = "Label3"
        Label3.Size = New Size(266, 40)
        Label3.TabIndex = 5
        Label3.Text = "Welcome Back!"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(60, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(750, 93)
        Label1.TabIndex = 5
        Label1.Text = "Book Management"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Arial", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(77, 163)
        Label2.Name = "Label2"
        Label2.Size = New Size(227, 67)
        Label2.TabIndex = 6
        Label2.Text = "System"
        ' 
        ' Form1
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1482, 753)
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
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

End Class
