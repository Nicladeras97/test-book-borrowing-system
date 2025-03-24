<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
    Inherits System.Windows.Forms.Form


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


    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox4 = New PictureBox()
        Label2 = New Label()
        lblBookTitle = New Label()
        lblAuthor = New Label()
        lblISBN = New Label()
        lblCopies = New Label()
        lblCategory = New Label()
        lblYear = New Label()
        numId = New Label()
        txtBookTitle = New TextBox()
        txtAuthor = New TextBox()
        txtISBN = New TextBox()
        txtCopies = New TextBox()
        txtCategory = New TextBox()
        txtYear = New TextBox()
        Label11 = New Label()
        btnAddBook = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.Size = New Size(984, 53)
        Panel1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 19)
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
        ' PictureBox4
        ' 
        PictureBox4.Cursor = Cursors.Hand
        PictureBox4.Image = My.Resources.Resources.back
        PictureBox4.Location = New Point(38, 83)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(15, 16)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 23
        PictureBox4.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(59, 83)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 19)
        Label2.TabIndex = 24
        Label2.Text = "Add Book"
        ' 
        ' lblBookTitle
        ' 
        lblBookTitle.AutoSize = True
        lblBookTitle.Font = New Font("Arial", 12F)
        lblBookTitle.Location = New Point(146, 180)
        lblBookTitle.Name = "lblBookTitle"
        lblBookTitle.Size = New Size(46, 23)
        lblBookTitle.TabIndex = 25
        lblBookTitle.Text = "Title"
        ' 
        ' lblAuthor
        ' 
        lblAuthor.AutoSize = True
        lblAuthor.Font = New Font("Arial", 12F)
        lblAuthor.Location = New Point(146, 240)
        lblAuthor.Name = "lblAuthor"
        lblAuthor.Size = New Size(67, 23)
        lblAuthor.TabIndex = 26
        lblAuthor.Text = "Author"
        ' 
        ' lblISBN
        ' 
        lblISBN.AutoSize = True
        lblISBN.Font = New Font("Arial", 12F)
        lblISBN.Location = New Point(146, 280)
        lblISBN.Name = "lblISBN"
        lblISBN.Size = New Size(55, 23)
        lblISBN.TabIndex = 27
        lblISBN.Text = "ISBN"
        ' 
        ' lblCopies
        ' 
        lblCopies.AutoSize = True
        lblCopies.Font = New Font("Arial", 12F)
        lblCopies.Location = New Point(146, 320)
        lblCopies.Name = "lblCopies"
        lblCopies.Size = New Size(153, 23)
        lblCopies.TabIndex = 28
        lblCopies.Text = "Number of Copy"
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.Font = New Font("Arial", 12F)
        lblCategory.Location = New Point(146, 360)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(91, 23)
        lblCategory.TabIndex = 29
        lblCategory.Text = "Category"
        ' 
        ' lblYear
        ' 
        lblYear.AutoSize = True
        lblYear.Font = New Font("Arial", 12F)
        lblYear.Location = New Point(146, 400)
        lblYear.Name = "lblYear"
        lblYear.Size = New Size(51, 23)
        lblYear.TabIndex = 31
        lblYear.Text = "Year"
        ' 
        ' numId
        ' 
        numId.AutoSize = True
        numId.Font = New Font("Arial", 12F)
        numId.Location = New Point(146, 140)
        numId.Name = "numId"
        numId.Size = New Size(81, 23)
        numId.TabIndex = 32
        numId.Text = "Book ID"
        ' 
        ' txtBookTitle
        ' 
        txtBookTitle.Location = New Point(306, 179)
        txtBookTitle.Name = "txtBookTitle"
        txtBookTitle.Size = New Size(569, 26)
        txtBookTitle.TabIndex = 33
        ' 
        ' txtAuthor
        ' 
        txtAuthor.Location = New Point(306, 239)
        txtAuthor.Name = "txtAuthor"
        txtAuthor.Size = New Size(569, 26)
        txtAuthor.TabIndex = 34
        ' 
        ' txtISBN
        ' 
        txtISBN.Location = New Point(306, 279)
        txtISBN.Name = "txtISBN"
        txtISBN.Size = New Size(569, 26)
        txtISBN.TabIndex = 35
        ' 
        ' txtCopies
        ' 
        txtCopies.Location = New Point(306, 319)
        txtCopies.Name = "txtCopies"
        txtCopies.Size = New Size(569, 26)
        txtCopies.TabIndex = 36
        ' 
        ' txtCategory
        ' 
        txtCategory.Location = New Point(306, 359)
        txtCategory.Name = "txtCategory"
        txtCategory.Size = New Size(569, 26)
        txtCategory.TabIndex = 37
        ' 
        ' txtYear
        ' 
        txtYear.Location = New Point(306, 399)
        txtYear.Name = "txtYear"
        txtYear.Size = New Size(569, 26)
        txtYear.TabIndex = 38
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F)
        Label11.Location = New Point(306, 140)
        Label11.Name = "Label11"
        Label11.Size = New Size(54, 23)
        Label11.TabIndex = 40
        Label11.Text = "0000"
        ' 
        ' btnAddBook
        ' 
        btnAddBook.BackColor = SystemColors.HotTrack
        btnAddBook.Cursor = Cursors.Hand
        btnAddBook.FlatAppearance.BorderSize = 0
        btnAddBook.FlatStyle = FlatStyle.Flat
        btnAddBook.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddBook.ForeColor = SystemColors.ButtonHighlight
        btnAddBook.Location = New Point(792, 494)
        btnAddBook.Name = "btnAddBook"
        btnAddBook.Size = New Size(83, 23)
        btnAddBook.TabIndex = 41
        btnAddBook.Text = "ADD"
        btnAddBook.UseVisualStyleBackColor = False
        ' 
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(984, 561)
        ControlBox = False
        Controls.Add(btnAddBook)
        Controls.Add(Label11)
        Controls.Add(txtYear)
        Controls.Add(txtCategory)
        Controls.Add(txtCopies)
        Controls.Add(txtISBN)
        Controls.Add(txtAuthor)
        Controls.Add(txtBookTitle)
        Controls.Add(numId)
        Controls.Add(lblYear)
        Controls.Add(lblCategory)
        Controls.Add(lblCopies)
        Controls.Add(lblISBN)
        Controls.Add(lblAuthor)
        Controls.Add(lblBookTitle)
        Controls.Add(Label2)
        Controls.Add(PictureBox4)
        Controls.Add(Panel1)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form10"
        Text = "Add Books"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblBookTitle As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblISBN As Label
    Friend WithEvents lblCopies As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents numId As Label
    Friend WithEvents txtBookTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents txtCopies As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnAddBook As Button
End Class
