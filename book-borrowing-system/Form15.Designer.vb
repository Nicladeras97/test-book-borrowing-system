﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form15
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form15))
        Panel1 = New Panel()
        PictureBox2 = New PictureBox()
        Label3 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
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
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        PictureBox3 = New PictureBox()
        mainPanel = New Panel()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveBorder
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1942, 124)
        Panel1.TabIndex = 6
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.BackgroundImageLayout = ImageLayout.Center
        PictureBox2.Cursor = Cursors.Hand
        PictureBox2.Location = New Point(1869, 0)
        PictureBox2.Margin = New Padding(3, 4, 3, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(61, 124)
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Arial", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(1619, 32)
        Label3.Name = "Label3"
        Label3.Size = New Size(214, 69)
        Label3.TabIndex = 9
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(129, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(626, 55)
        Label1.TabIndex = 1
        Label1.Text = "Book-Management System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.cmilogo
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(122, 124)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.AutoSize = False
        MenuStrip1.BackColor = SystemColors.ActiveBorder
        MenuStrip1.BackgroundImageLayout = ImageLayout.None
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.Font = New Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {LendReceivedToolStripMenuItem, ReceivedBooksToolStripMenuItem, ManageBooksToolStripMenuItem, BarcodeToolStripMenuItem, SettingsToolStripMenuItem})
        MenuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        MenuStrip1.Location = New Point(0, 124)
        MenuStrip1.Margin = New Padding(57, 67, 57, 67)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(7, 3, 0, 3)
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(295, 911)
        MenuStrip1.TabIndex = 7
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LendReceivedToolStripMenuItem
        ' 
        LendReceivedToolStripMenuItem.BackColor = Color.Transparent
        LendReceivedToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        LendReceivedToolStripMenuItem.Margin = New Padding(0, 20, 0, 20)
        LendReceivedToolStripMenuItem.Name = "LendReceivedToolStripMenuItem"
        LendReceivedToolStripMenuItem.Padding = New Padding(0, 0, 80, 40)
        LendReceivedToolStripMenuItem.Size = New Size(287, 84)
        LendReceivedToolStripMenuItem.Text = "Lend Books"
        LendReceivedToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ReceivedBooksToolStripMenuItem
        ' 
        ReceivedBooksToolStripMenuItem.BackColor = Color.Transparent
        ReceivedBooksToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        ReceivedBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 20)
        ReceivedBooksToolStripMenuItem.Name = "ReceivedBooksToolStripMenuItem"
        ReceivedBooksToolStripMenuItem.Padding = New Padding(0, 0, 25, 40)
        ReceivedBooksToolStripMenuItem.Size = New Size(287, 84)
        ReceivedBooksToolStripMenuItem.Text = "Received Books"
        ReceivedBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ManageBooksToolStripMenuItem
        ' 
        ManageBooksToolStripMenuItem.BackColor = Color.Transparent
        ManageBooksToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AddBooksToolStripMenuItem, EditBooksToolStripMenuItem, DeleteBooksToolStripMenuItem, ImportToolStripMenuItem, DownloadTemplateToolStripMenuItem, REportsToolStripMenuItem, RepairBooksToolStripMenuItem})
        ManageBooksToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        ManageBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 20)
        ManageBooksToolStripMenuItem.Name = "ManageBooksToolStripMenuItem"
        ManageBooksToolStripMenuItem.Padding = New Padding(0, 0, 45, 40)
        ManageBooksToolStripMenuItem.Size = New Size(287, 84)
        ManageBooksToolStripMenuItem.Text = "Manage Books"
        ManageBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' AddBooksToolStripMenuItem
        ' 
        AddBooksToolStripMenuItem.BackColor = Color.Transparent
        AddBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        AddBooksToolStripMenuItem.Name = "AddBooksToolStripMenuItem"
        AddBooksToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        AddBooksToolStripMenuItem.Size = New Size(425, 52)
        AddBooksToolStripMenuItem.Text = "Add"
        AddBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' EditBooksToolStripMenuItem
        ' 
        EditBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        EditBooksToolStripMenuItem.Name = "EditBooksToolStripMenuItem"
        EditBooksToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        EditBooksToolStripMenuItem.Size = New Size(425, 52)
        EditBooksToolStripMenuItem.Text = "Edit"
        EditBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' DeleteBooksToolStripMenuItem
        ' 
        DeleteBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        DeleteBooksToolStripMenuItem.Name = "DeleteBooksToolStripMenuItem"
        DeleteBooksToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        DeleteBooksToolStripMenuItem.Size = New Size(425, 52)
        DeleteBooksToolStripMenuItem.Text = "Delete"
        DeleteBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ImportToolStripMenuItem
        ' 
        ImportToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        ImportToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        ImportToolStripMenuItem.Size = New Size(425, 52)
        ImportToolStripMenuItem.Text = "Import"
        ImportToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' DownloadTemplateToolStripMenuItem
        ' 
        DownloadTemplateToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        DownloadTemplateToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        DownloadTemplateToolStripMenuItem.Size = New Size(425, 52)
        DownloadTemplateToolStripMenuItem.Text = "Download Template"
        DownloadTemplateToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' REportsToolStripMenuItem
        ' 
        REportsToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        REportsToolStripMenuItem.Name = "REportsToolStripMenuItem"
        REportsToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        REportsToolStripMenuItem.Size = New Size(425, 52)
        REportsToolStripMenuItem.Text = "Reports"
        REportsToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' RepairBooksToolStripMenuItem
        ' 
        RepairBooksToolStripMenuItem.Margin = New Padding(0, 0, 0, 5)
        RepairBooksToolStripMenuItem.Name = "RepairBooksToolStripMenuItem"
        RepairBooksToolStripMenuItem.Padding = New Padding(0, 0, 0, 10)
        RepairBooksToolStripMenuItem.Size = New Size(425, 52)
        RepairBooksToolStripMenuItem.Text = "Repair Books"
        RepairBooksToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BarcodeToolStripMenuItem
        ' 
        BarcodeToolStripMenuItem.BackColor = Color.Transparent
        BarcodeToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        BarcodeToolStripMenuItem.Margin = New Padding(0, 0, 0, 20)
        BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        BarcodeToolStripMenuItem.Padding = New Padding(0, 10, 125, 40)
        BarcodeToolStripMenuItem.Size = New Size(287, 94)
        BarcodeToolStripMenuItem.Text = "Barcode"
        BarcodeToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.BackColor = Color.Transparent
        SettingsToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight
        SettingsToolStripMenuItem.Margin = New Padding(0, 0, 0, 20)
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Padding = New Padding(0, 0, 127, 40)
        SettingsToolStripMenuItem.Size = New Size(287, 84)
        SettingsToolStripMenuItem.Text = "Settings"
        SettingsToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Location = New Point(628, 96)
        PictureBox3.Margin = New Padding(3, 2, 3, 2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(577, 609)
        PictureBox3.TabIndex = 8
        PictureBox3.TabStop = False
        ' 
        ' mainPanel
        ' 
        mainPanel.BackColor = Color.Transparent
        mainPanel.Dock = DockStyle.Fill
        mainPanel.Location = New Point(0, 0)
        mainPanel.Name = "mainPanel"
        mainPanel.Size = New Size(1942, 1035)
        mainPanel.TabIndex = 9
        ' 
        ' Form15
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1942, 1035)
        ControlBox = False
        Controls.Add(PictureBox3)
        Controls.Add(MenuStrip1)
        Controls.Add(Panel1)
        Controls.Add(mainPanel)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form15"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RepairBooksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents mainPanel As Panel

End Class
