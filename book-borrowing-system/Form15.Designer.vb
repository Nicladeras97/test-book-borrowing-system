<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form15
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form15))
        Panel1 = New Panel()
        MenuStrip1 = New MenuStrip()
        LendReceivedToolStripMenuItem = New ToolStripMenuItem()
        ReceivedBooksToolStripMenuItem = New ToolStripMenuItem()
        ManageBooksToolStripMenuItem = New ToolStripMenuItem()
        AddBooksToolStripMenuItem = New ToolStripMenuItem()
        EditBooksToolStripMenuItem = New ToolStripMenuItem()
        DeleteBooksToolStripMenuItem = New ToolStripMenuItem()
        ImportToolStripMenuItem = New ToolStripMenuItem()
        DownloadTemplateToolStripMenuItem = New ToolStripMenuItem()
        REportsToolStripMenuItem = New ToolStripMenuItem()
        BarcodeToolStripMenuItem = New ToolStripMenuItem()
        CreateToolStripMenuItem = New ToolStripMenuItem()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveBorder
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1894, 93)
        Panel1.TabIndex = 6
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.AutoSize = False
        MenuStrip1.BackColor = Color.Transparent
        MenuStrip1.BackgroundImageLayout = ImageLayout.None
        MenuStrip1.Dock = DockStyle.None
        MenuStrip1.Font = New Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {LendReceivedToolStripMenuItem, ReceivedBooksToolStripMenuItem, ManageBooksToolStripMenuItem, BarcodeToolStripMenuItem})
        MenuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        MenuStrip1.Location = New Point(0, 100)
        MenuStrip1.Margin = New Padding(50)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(324, 658)
        MenuStrip1.TabIndex = 7
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LendReceivedToolStripMenuItem
        ' 
        LendReceivedToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        LendReceivedToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        LendReceivedToolStripMenuItem.Name = "LendReceivedToolStripMenuItem"
        LendReceivedToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        LendReceivedToolStripMenuItem.Size = New Size(317, 56)
        LendReceivedToolStripMenuItem.Text = "Lend Books"
        LendReceivedToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ReceivedBooksToolStripMenuItem
        ' 
        ReceivedBooksToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        ReceivedBooksToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        ReceivedBooksToolStripMenuItem.Name = "ReceivedBooksToolStripMenuItem"
        ReceivedBooksToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        ReceivedBooksToolStripMenuItem.Size = New Size(317, 56)
        ReceivedBooksToolStripMenuItem.Text = "Received Books"
        ReceivedBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ManageBooksToolStripMenuItem
        ' 
        ManageBooksToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AddBooksToolStripMenuItem, EditBooksToolStripMenuItem, DeleteBooksToolStripMenuItem, ImportToolStripMenuItem, DownloadTemplateToolStripMenuItem, REportsToolStripMenuItem})
        ManageBooksToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        ManageBooksToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        ManageBooksToolStripMenuItem.Name = "ManageBooksToolStripMenuItem"
        ManageBooksToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        ManageBooksToolStripMenuItem.Size = New Size(317, 56)
        ManageBooksToolStripMenuItem.Text = "Manage Books"
        ManageBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' AddBooksToolStripMenuItem
        ' 
        AddBooksToolStripMenuItem.Name = "AddBooksToolStripMenuItem"
        AddBooksToolStripMenuItem.Size = New Size(349, 36)
        AddBooksToolStripMenuItem.Text = "Add"
        ' 
        ' EditBooksToolStripMenuItem
        ' 
        EditBooksToolStripMenuItem.Name = "EditBooksToolStripMenuItem"
        EditBooksToolStripMenuItem.Size = New Size(349, 36)
        EditBooksToolStripMenuItem.Text = "Edit"
        ' 
        ' DeleteBooksToolStripMenuItem
        ' 
        DeleteBooksToolStripMenuItem.Name = "DeleteBooksToolStripMenuItem"
        DeleteBooksToolStripMenuItem.Size = New Size(349, 36)
        DeleteBooksToolStripMenuItem.Text = "Delete"
        ' 
        ' ImportToolStripMenuItem
        ' 
        ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        ImportToolStripMenuItem.Size = New Size(349, 36)
        ImportToolStripMenuItem.Text = "Import"
        ' 
        ' DownloadTemplateToolStripMenuItem
        ' 
        DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        DownloadTemplateToolStripMenuItem.Size = New Size(349, 36)
        DownloadTemplateToolStripMenuItem.Text = "Download Template"
        ' 
        ' REportsToolStripMenuItem
        ' 
        REportsToolStripMenuItem.Name = "REportsToolStripMenuItem"
        REportsToolStripMenuItem.Size = New Size(349, 36)
        REportsToolStripMenuItem.Text = "Reports"
        ' 
        ' BarcodeToolStripMenuItem
        ' 
        BarcodeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CreateToolStripMenuItem})
        BarcodeToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        BarcodeToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        BarcodeToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        BarcodeToolStripMenuItem.Size = New Size(317, 56)
        BarcodeToolStripMenuItem.Text = "Barcode"
        BarcodeToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' CreateToolStripMenuItem
        ' 
        CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        CreateToolStripMenuItem.Size = New Size(173, 36)
        CreateToolStripMenuItem.Text = "Create"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(113, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(496, 44)
        Label1.TabIndex = 1
        Label1.Text = "Book-Management System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.cmilogo
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(107, 93)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Form15
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1487, 776)
        ControlBox = False
        Controls.Add(MenuStrip1)
        Controls.Add(Panel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form15"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LendReceivedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReceivedBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As ToolStripMenuItem
End Class
