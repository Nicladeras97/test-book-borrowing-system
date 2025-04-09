<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Report
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label2 = New Label()
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(736, 43)
        Label2.Name = "Label2"
        Label2.Size = New Size(185, 24)
        Label2.TabIndex = 2
        Label2.Text = "Borrower's Record"
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.back
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(32, 25)
        Button3.Name = "Button3"
        Button3.Size = New Size(30, 40)
        Button3.TabIndex = 14
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Anchor = AnchorStyles.None
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.BackgroundColor = SystemColors.ButtonHighlight
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.LightBlue
        DataGridViewCellStyle1.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = Color.LightBlue
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Cursor = Cursors.Hand
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.ControlDark
        DataGridView1.Location = New Point(354, 90)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(940, 469)
        DataGridView1.TabIndex = 20
        ' 
        ' Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1614, 614)
        Controls.Add(DataGridView1)
        Controls.Add(Label2)
        Location = New Point(266, 111)
        Name = "Report"
        StartPosition = FormStartPosition.Manual
        Text = "Email Managent"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
