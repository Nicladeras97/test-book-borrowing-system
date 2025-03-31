<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button2 = New Button()
        Button8 = New Button()
        Button5 = New Button()
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
        Panel1.Size = New Size(1482, 53)
        Panel1.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(43, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 19)
        Label1.TabIndex = 1
        Label1.Text = "Books"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(14, 15)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(20, 21)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(252, 215)
        Button1.Name = "Button1"
        Button1.Size = New Size(425, 76)
        Button1.TabIndex = 11
        Button1.Text = "Add Book"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.back
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(37, 80)
        Button3.Name = "Button3"
        Button3.Size = New Size(15, 15)
        Button3.TabIndex = 12
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.DarkGoldenrod
        Button4.Cursor = Cursors.Hand
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.White
        Button4.Location = New Point(252, 307)
        Button4.Name = "Button4"
        Button4.Size = New Size(425, 76)
        Button4.TabIndex = 13
        Button4.Text = "Import"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ActiveCaption
        Button2.Cursor = Cursors.Hand
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(479, 412)
        Button2.Name = "Button2"
        Button2.Size = New Size(425, 76)
        Button2.TabIndex = 16
        Button2.Text = "Download Template"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.Red
        Button8.Cursor = Cursors.Hand
        Button8.FlatStyle = FlatStyle.Flat
        Button8.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button8.ForeColor = Color.White
        Button8.Location = New Point(703, 307)
        Button8.Name = "Button8"
        Button8.Size = New Size(425, 76)
        Button8.TabIndex = 22
        Button8.Text = "Delete Book"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Green
        Button5.Cursor = Cursors.Hand
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = Color.White
        Button5.Location = New Point(703, 215)
        Button5.Name = "Button5"
        Button5.Size = New Size(425, 76)
        Button5.TabIndex = 23
        Button5.Text = "Edit Book"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1482, 753)
        ControlBox = False
        Controls.Add(Button5)
        Controls.Add(Button8)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button4)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form5"
        Text = "     "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button5 As Button
End Class
