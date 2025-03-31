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
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        SuspendLayout()
        ' 
        ' Button3
        ' 
        Button3.BackgroundImage = My.Resources.Resources.back
        Button3.BackgroundImageLayout = ImageLayout.Zoom
        Button3.Cursor = Cursors.Hand
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(38, 80)
        Button3.Name = "Button3"
        Button3.Size = New Size(30, 40)
        Button3.TabIndex = 13
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.LightBlue
        Button2.BackgroundImageLayout = ImageLayout.Center
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(617, 286)
        Button2.Name = "Button2"
        Button2.Size = New Size(239, 228)
        Button2.TabIndex = 15
        Button2.Text = "Manage Books"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightBlue
        Button1.BackgroundImageLayout = ImageLayout.Center
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(913, 286)
        Button1.Name = "Button1"
        Button1.Size = New Size(239, 228)
        Button1.TabIndex = 16
        Button1.Text = "Book Reports"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.LightBlue
        Button4.BackgroundImageLayout = ImageLayout.Center
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(311, 286)
        Button4.Name = "Button4"
        Button4.Size = New Size(239, 228)
        Button4.TabIndex = 17
        Button4.Text = "Return Book"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.LightBlue
        Button5.BackgroundImageLayout = ImageLayout.Center
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Location = New Point(617, 552)
        Button5.Name = "Button5"
        Button5.Size = New Size(239, 65)
        Button5.TabIndex = 18
        Button5.Text = "Automated Send Email"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        ControlBox = False
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button1)
        Controls.Add(Button2)
        Controls.Add(Button3)
        Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.ActiveCaptionText
        Name = "Form4"
        Text = "     "
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
