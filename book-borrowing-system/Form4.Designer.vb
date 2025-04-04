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
        RepairBooksToolStripMenuItem = New ToolStripMenuItem()
        BarcodeToolStripMenuItem = New ToolStripMenuItem()
        Panel1 = New Panel()
        Button1 = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
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
        MenuStrip1.Items.AddRange(New ToolStripItem() {LendReceivedToolStripMenuItem, ReceivedBooksToolStripMenuItem, ManageBooksToolStripMenuItem, BarcodeToolStripMenuItem, SettingsToolStripMenuItem})
        MenuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        MenuStrip1.Location = New Point(82, 121)
        MenuStrip1.Margin = New Padding(50)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(300, 658)
        MenuStrip1.TabIndex = 2
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LendReceivedToolStripMenuItem
        ' 
        LendReceivedToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        LendReceivedToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        LendReceivedToolStripMenuItem.Name = "LendReceivedToolStripMenuItem"
        LendReceivedToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        LendReceivedToolStripMenuItem.Size = New Size(293, 56)
        LendReceivedToolStripMenuItem.Text = "Lend Books"
        LendReceivedToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ReceivedBooksToolStripMenuItem
        ' 
        ReceivedBooksToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        ReceivedBooksToolStripMenuItem.Margin = New Padding(0, 50, 0, 50)
        ReceivedBooksToolStripMenuItem.Name = "ReceivedBooksToolStripMenuItem"
        ReceivedBooksToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        ReceivedBooksToolStripMenuItem.Size = New Size(293, 56)
        ReceivedBooksToolStripMenuItem.Text = "Received Books"
        ReceivedBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ManageBooksToolStripMenuItem
        ' 
        ManageBooksToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AddBooksToolStripMenuItem, EditBooksToolStripMenuItem, DeleteBooksToolStripMenuItem, ImportToolStripMenuItem, DownloadTemplateToolStripMenuItem, REportsToolStripMenuItem, RepairBooksToolStripMenuItem})
        ManageBooksToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText
        ManageBooksToolStripMenuItem.Name = "ManageBooksToolStripMenuItem"
        ManageBooksToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        ManageBooksToolStripMenuItem.Size = New Size(293, 56)
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
        ' RepairBooksToolStripMenuItem
        ' 
        RepairBooksToolStripMenuItem.Name = "RepairBooksToolStripMenuItem"
        RepairBooksToolStripMenuItem.Size = New Size(425, 44)
        RepairBooksToolStripMenuItem.Text = "Repair Books"
        ' 
        ' BarcodeToolStripMenuItem
        ' 
        BarcodeToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText
        BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        BarcodeToolStripMenuItem.Padding = New Padding(0, 10, 0, 10)
        BarcodeToolStripMenuItem.Size = New Size(293, 56)
        BarcodeToolStripMenuItem.Text = "Barcode"
        BarcodeToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveBorder
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1605, 93)
        Panel1.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.AutoSize = True
        Button1.BackColor = Color.Red
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1344, 15)
        Button1.Name = "Button1"
        Button1.Size = New Size(131, 56)
        Button1.TabIndex = 8
        Button1.Text = "EXIT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(113, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(506, 44)
        Label1.TabIndex = 2
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
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(293, 44)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' Form4
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1487, 776)
        ControlBox = False
        Controls.Add(MenuStrip1)
        Controls.Add(Panel1)
        DoubleBuffered = True
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        MinimizeBox = False
        Name = "Form4"
        StartPosition = FormStartPosition.CenterParent
        Text = "     "
        TransparencyKey = Color.White
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ReceivedBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepairBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
End Class
