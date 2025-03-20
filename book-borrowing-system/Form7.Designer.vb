<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim ListViewItem1 As ListViewItem = New ListViewItem("")
        ListView1 = New ListView()
        message = New ColumnHeader()
        type = New ColumnHeader()
        datenow = New ColumnHeader()
        Button1 = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.BorderStyle = BorderStyle.None
        ListView1.Columns.AddRange(New ColumnHeader() {message, type, datenow})
        ListView1.Font = New Font("Arial", 9F)
        ListView1.Items.AddRange(New ListViewItem() {ListViewItem1})
        ListView1.Location = New Point(12, 37)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(378, 362)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' message
        ' 
        message.Width = 200
        ' 
        ' type
        ' 
        type.Width = 80
        ' 
        ' datenow
        ' 
        datenow.Width = 95
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightCoral
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(339, 8)
        Button1.Name = "Button1"
        Button1.Size = New Size(51, 23)
        Button1.TabIndex = 1
        Button1.Text = "Close"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 16)
        Label1.TabIndex = 2
        Label1.Text = "Notifications"
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(402, 412)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(ListView1)
        Name = "Form7"
        Text = "Form7"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents message As ColumnHeader
    Friend WithEvents type As ColumnHeader
    Friend WithEvents datenow As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
