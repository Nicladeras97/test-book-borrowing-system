<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        ComboBox1 = New ComboBox()
        Button4 = New Button()
        Label11 = New Label()
        Label8 = New Label()
        Button2 = New Button()
        Button1 = New Button()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label9 = New Label()
        Label23 = New Label()
        Label10 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Label17 = New Label()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(488, 104)
        ComboBox1.Margin = New Padding(3, 2, 3, 2)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(344, 23)
        ComboBox1.TabIndex = 118
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.None
        Button4.BackColor = Color.DarkGreen
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.ForeColor = SystemColors.ButtonHighlight
        Button4.Location = New Point(837, 104)
        Button4.Margin = New Padding(3, 2, 3, 2)
        Button4.Name = "Button4"
        Button4.Size = New Size(66, 23)
        Button4.TabIndex = 117
        Button4.Text = "Check"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(318, 285)
        Label11.Name = "Label11"
        Label11.Size = New Size(73, 18)
        Label11.TabIndex = 115
        Label11.Text = "Publisher"
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(318, 107)
        Label8.Name = "Label8"
        Label8.Size = New Size(109, 18)
        Label8.TabIndex = 112
        Label8.Text = "Accession No."
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = Color.Red
        Button2.Cursor = Cursors.Hand
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 12F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(609, 434)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(82, 37)
        Button2.TabIndex = 110
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.Green
        Button1.Cursor = Cursors.Hand
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 12F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(503, 434)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(82, 37)
        Button1.TabIndex = 109
        Button1.Text = "Delete"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(318, 393)
        Label7.Name = "Label7"
        Label7.Size = New Size(88, 18)
        Label7.TabIndex = 108
        Label7.Text = "LC Call No."
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(318, 359)
        Label6.Name = "Label6"
        Label6.Size = New Size(44, 18)
        Label6.TabIndex = 106
        Label6.Text = "Rack"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(318, 244)
        Label5.Name = "Label5"
        Label5.Size = New Size(112, 18)
        Label5.TabIndex = 104
        Label5.Text = "Year Published"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(318, 322)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 18)
        Label4.TabIndex = 102
        Label4.Text = "Section "
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(318, 208)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 18)
        Label3.TabIndex = 100
        Label3.Text = "Author"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(318, 173)
        Label2.Name = "Label2"
        Label2.Size = New Size(36, 18)
        Label2.TabIndex = 98
        Label2.Text = "Title"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(514, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(173, 32)
        Label1.TabIndex = 97
        Label1.Text = "Delete Book"
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.None
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(318, 139)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 18)
        Label9.TabIndex = 114
        Label9.Text = "ISBN"
        ' 
        ' Label23
        ' 
        Label23.Anchor = AnchorStyles.None
        Label23.BackColor = SystemColors.ButtonFace
        Label23.BorderStyle = BorderStyle.Fixed3D
        Label23.FlatStyle = FlatStyle.Flat
        Label23.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label23.Location = New Point(488, 139)
        Label23.Name = "Label23"
        Label23.Size = New Size(415, 19)
        Label23.TabIndex = 119
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.None
        Label10.BackColor = SystemColors.ButtonFace
        Label10.BorderStyle = BorderStyle.Fixed3D
        Label10.FlatStyle = FlatStyle.Flat
        Label10.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(488, 172)
        Label10.Name = "Label10"
        Label10.Size = New Size(415, 19)
        Label10.TabIndex = 120
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.None
        Label12.BackColor = SystemColors.ButtonFace
        Label12.BorderStyle = BorderStyle.Fixed3D
        Label12.FlatStyle = FlatStyle.Flat
        Label12.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(488, 207)
        Label12.Name = "Label12"
        Label12.Size = New Size(415, 19)
        Label12.TabIndex = 121
        ' 
        ' Label13
        ' 
        Label13.Anchor = AnchorStyles.None
        Label13.BackColor = SystemColors.ButtonFace
        Label13.BorderStyle = BorderStyle.Fixed3D
        Label13.FlatStyle = FlatStyle.Flat
        Label13.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(488, 243)
        Label13.Name = "Label13"
        Label13.Size = New Size(415, 19)
        Label13.TabIndex = 122
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.BackColor = SystemColors.ButtonFace
        Label14.BorderStyle = BorderStyle.Fixed3D
        Label14.FlatStyle = FlatStyle.Flat
        Label14.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(488, 284)
        Label14.Name = "Label14"
        Label14.Size = New Size(415, 19)
        Label14.TabIndex = 123
        ' 
        ' Label15
        ' 
        Label15.Anchor = AnchorStyles.None
        Label15.BackColor = SystemColors.ButtonFace
        Label15.BorderStyle = BorderStyle.Fixed3D
        Label15.FlatStyle = FlatStyle.Flat
        Label15.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(488, 320)
        Label15.Name = "Label15"
        Label15.Size = New Size(415, 19)
        Label15.TabIndex = 124
        ' 
        ' Label16
        ' 
        Label16.Anchor = AnchorStyles.None
        Label16.BackColor = SystemColors.ButtonFace
        Label16.BorderStyle = BorderStyle.Fixed3D
        Label16.FlatStyle = FlatStyle.Flat
        Label16.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(488, 358)
        Label16.Name = "Label16"
        Label16.Size = New Size(415, 19)
        Label16.TabIndex = 125
        ' 
        ' Label17
        ' 
        Label17.Anchor = AnchorStyles.None
        Label17.BackColor = SystemColors.ButtonFace
        Label17.BorderStyle = BorderStyle.Fixed3D
        Label17.FlatStyle = FlatStyle.Flat
        Label17.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(488, 392)
        Label17.Name = "Label17"
        Label17.Size = New Size(415, 19)
        Label17.TabIndex = 126
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1265, 494)
        Controls.Add(Label17)
        Controls.Add(Label16)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label10)
        Controls.Add(Label23)
        Controls.Add(ComboBox1)
        Controls.Add(Button4)
        Controls.Add(Label11)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        DoubleBuffered = True
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
End Class
