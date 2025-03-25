<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
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
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        ComboBox1 = New ComboBox()
        Button1 = New Button()
        Label2 = New Label()
        Button2 = New Button()
        Back = New Button()
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        Label3 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Cursor = Cursors.IBeam
        TextBox1.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(139, 74)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(307, 26)
        TextBox1.TabIndex = 7
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightBlue
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1482, 54)
        Panel1.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(43, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(107, 19)
        Label1.TabIndex = 1
        Label1.Text = "Book Shelves"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(14, 15)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(22, 21)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Cursor = Cursors.Hand
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(1040, 74)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(311, 27)
        ComboBox1.TabIndex = 9
        ' 
        ' Button1
        ' 
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(627, 698)
        Button1.Name = "Button1"
        Button1.Size = New Size(66, 28)
        Button1.TabIndex = 11
        Button1.Text = "Back"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(700, 699)
        Label2.Name = "Label2"
        Label2.Size = New Size(68, 24)
        Label2.TabIndex = 12
        Label2.Text = "01/10"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button2
        ' 
        Button2.Cursor = Cursors.Hand
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(774, 697)
        Button2.Name = "Button2"
        Button2.Size = New Size(66, 28)
        Button2.TabIndex = 13
        Button2.Text = "Next"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Back
        ' 
        Back.BackgroundImage = My.Resources.Resources.back
        Back.BackgroundImageLayout = ImageLayout.Zoom
        Back.Cursor = Cursors.Hand
        Back.FlatAppearance.BorderSize = 0
        Back.FlatStyle = FlatStyle.Flat
        Back.Location = New Point(37, 79)
        Back.Name = "Back"
        Back.Size = New Size(17, 15)
        Back.TabIndex = 41
        Back.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.Highlight
        Button3.Cursor = Cursors.Hand
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.White
        Button3.Location = New Point(1358, 73)
        Button3.Name = "Button3"
        Button3.Size = New Size(89, 27)
        Button3.TabIndex = 42
        Button3.Text = "Filter"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.WhiteSmoke
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(43, 133)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1404, 539)
        DataGridView1.TabIndex = 43
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(71, 77)
        Label3.Name = "Label3"
        Label3.Size = New Size(62, 19)
        Label3.TabIndex = 44
        Label3.Text = "Search"
        ' 
        ' Form12
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1482, 753)
        ControlBox = False
        Controls.Add(Label3)
        Controls.Add(DataGridView1)
        Controls.Add(Button3)
        Controls.Add(Back)
        Controls.Add(Button2)
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(ComboBox1)
        Controls.Add(Panel1)
        Controls.Add(TextBox1)
        Font = New Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form12"
        Text = "Form12"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Back As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
End Class
