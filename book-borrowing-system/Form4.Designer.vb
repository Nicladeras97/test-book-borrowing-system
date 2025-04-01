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
        Button2 = New Button()
        Button1 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.LightBlue
        Button2.BackgroundImageLayout = ImageLayout.Center
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(355, 313)
        Button2.Name = "Button2"
        Button2.Size = New Size(314, 62)
        Button2.TabIndex = 15
        Button2.Text = "Manage Books"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightBlue
        Button1.BackgroundImageLayout = ImageLayout.Center
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(691, 313)
        Button1.Name = "Button1"
        Button1.Size = New Size(314, 62)
        Button1.TabIndex = 16
        Button1.Text = "Book Reports"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.LightBlue
        Button4.BackgroundImageLayout = ImageLayout.Center
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(691, 225)
        Button4.Name = "Button4"
        Button4.Size = New Size(314, 62)
        Button4.TabIndex = 17
        Button4.Text = "Received Book"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.LightBlue
        Button5.BackgroundImageLayout = ImageLayout.Center
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Location = New Point(517, 401)
        Button5.Name = "Button5"
        Button5.Size = New Size(314, 62)
        Button5.TabIndex = 18
        Button5.Text = "Automated Send Email"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.LightBlue
        Button6.BackgroundImageLayout = ImageLayout.Center
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Location = New Point(355, 225)
        Button6.Name = "Button6"
        Button6.Size = New Size(314, 62)
        Button6.TabIndex = 19
        Button6.Text = "Lend Book"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackgroundImage = My.Resources.Resources.logout
        Button7.BackgroundImageLayout = ImageLayout.Zoom
        Button7.Cursor = Cursors.Hand
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Location = New Point(46, 75)
        Button7.Name = "Button7"
        Button7.Size = New Size(30, 26)
        Button7.TabIndex = 20
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        ControlBox = False
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button1)
        Controls.Add(Button2)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        Name = "Form4"
        Text = "     "
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
