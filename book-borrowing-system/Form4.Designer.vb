<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
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
        Panel1 = New Panel()
        Button1 = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        MenuStrip1.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        MenuStrip1.Location = New Point(0, 123)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(300, 617)
        MenuStrip1.Stretch = False
        MenuStrip1.TabIndex = 2
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LendReceivedToolStripMenuItem
        ' 
        LendReceivedToolStripMenuItem.ForeColor = Color.Black
        LendReceivedToolStripMenuItem.Name = "LendReceivedToolStripMenuItem"
        LendReceivedToolStripMenuItem.Padding = New Padding(20, 0, 20, 0)
        LendReceivedToolStripMenuItem.Size = New Size(293, 44)
        LendReceivedToolStripMenuItem.Text = "Lend Books"
        ' 
        ' ReceivedBooksToolStripMenuItem
        ' 
        ReceivedBooksToolStripMenuItem.Name = "ReceivedBooksToolStripMenuItem"
        ReceivedBooksToolStripMenuItem.Size = New Size(293, 44)
        ReceivedBooksToolStripMenuItem.Text = "Received Books"
        ' 
        ' ManageBooksToolStripMenuItem
        ' 
        ManageBooksToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AddBooksToolStripMenuItem, EditBooksToolStripMenuItem, DeleteBooksToolStripMenuItem, ImportToolStripMenuItem, DownloadTemplateToolStripMenuItem, REportsToolStripMenuItem})
        ManageBooksToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText
        ManageBooksToolStripMenuItem.Name = "ManageBooksToolStripMenuItem"
        ManageBooksToolStripMenuItem.Size = New Size(293, 44)
        ManageBooksToolStripMenuItem.Text = "Manage Books"
        ' 
        ' AddBooksToolStripMenuItem
        ' 
        AddBooksToolStripMenuItem.Name = "AddBooksToolStripMenuItem"
        AddBooksToolStripMenuItem.Size = New Size(425, 44)
        AddBooksToolStripMenuItem.Text = "Add"
        ' 
        ' EditBooksToolStripMenuItem
        ' 
        EditBooksToolStripMenuItem.Name = "EditBooksToolStripMenuItem"
        EditBooksToolStripMenuItem.Size = New Size(425, 44)
        EditBooksToolStripMenuItem.Text = "Edit"
        ' 
        ' DeleteBooksToolStripMenuItem
        ' 
        DeleteBooksToolStripMenuItem.Name = "DeleteBooksToolStripMenuItem"
        DeleteBooksToolStripMenuItem.Size = New Size(425, 44)
        DeleteBooksToolStripMenuItem.Text = "Delete"
        ' 
        ' ImportToolStripMenuItem
        ' 
        ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        ImportToolStripMenuItem.Size = New Size(425, 44)
        ImportToolStripMenuItem.Text = "Import"
        ' 
        ' DownloadTemplateToolStripMenuItem
        ' 
        DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        DownloadTemplateToolStripMenuItem.Size = New Size(425, 44)
        DownloadTemplateToolStripMenuItem.Text = "Download Template"
        ' 
        ' REportsToolStripMenuItem
        ' 
        REportsToolStripMenuItem.Name = "REportsToolStripMenuItem"
        REportsToolStripMenuItem.Size = New Size(425, 44)
        REportsToolStripMenuItem.Text = "Reports"
        ' 
        ' BarcodeToolStripMenuItem
        ' 
        BarcodeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CreateToolStripMenuItem})
        BarcodeToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText
        BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        BarcodeToolStripMenuItem.Size = New Size(293, 44)
        BarcodeToolStripMenuItem.Text = "Barcode"
        ' 
        ' CreateToolStripMenuItem
        ' 
        CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        CreateToolStripMenuItem.Size = New Size(215, 44)
        CreateToolStripMenuItem.Text = "Create"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1370, 120)
        Panel1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackgroundImage = My.Resources.Resources.Vector__6_
        Button1.BackgroundImageLayout = ImageLayout.Zoom
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(1284, 40)
        Button1.Name = "Button1"
        Button1.Size = New Size(54, 46)
        Button1.TabIndex = 2
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(156, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(536, 46)
        Label1.TabIndex = 1
        Label1.Text = "Book- Management System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.cmilogo
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(133, 120)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.library_1
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1370, 749)
        ControlBox = False
        Controls.Add(Panel1)
        Controls.Add(MenuStrip1)
        DoubleBuffered = True
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        MinimizeBox = False
        Name = "Form4"
        StartPosition = FormStartPosition.Manual
        Text = "     "
        TransparencyKey = Color.White
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LendReceivedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ReceivedBooksToolStripMenuItem As ToolStripMenuItem
End Class
