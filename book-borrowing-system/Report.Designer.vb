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
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        Button3 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Name = "Label2"
        Label2.TabIndex = 2
        Label2.Text = "Borrower's Record"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Name = "DataGridView1"
        DataGridView1.TabIndex = 9
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
        ' Report
        ' 
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DataGridView1)
        Controls.Add(Label2)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Report"
        Text = "Report"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
End Class
