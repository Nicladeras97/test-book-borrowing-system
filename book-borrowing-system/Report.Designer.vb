﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Button1 = New Button()
        ListBox1 = New ListBox()
        ListBox2 = New ListBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(462, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(130, 20)
        Label2.TabIndex = 2
        Label2.Text = "Borrower's Record"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(67, 101)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(898, 511)
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
        ' Button1
        ' 
        Button1.BackgroundImage = My.Resources.Resources.back
        Button1.BackgroundImageLayout = ImageLayout.Zoom
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(67, 36)
        Button1.Name = "Button1"
        Button1.Size = New Size(30, 40)
        Button1.TabIndex = 14
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(883, 399)
        ListBox1.Margin = New Padding(3, 4, 3, 4)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(137, 244)
        ListBox1.TabIndex = 18
        ' 
        ' ListBox2
        ' 
        ListBox2.FormattingEnabled = True
        ListBox2.Location = New Point(739, 399)
        ListBox2.Margin = New Padding(3, 4, 3, 4)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(137, 244)
        ListBox2.TabIndex = 19
        ' 
        ' Report
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1845, 819)
        Controls.Add(ListBox2)
        Controls.Add(ListBox1)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Label2)
        Location = New Point(266, 111)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Report"
        StartPosition = FormStartPosition.Manual
        Text = "Email Managent"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
End Class
