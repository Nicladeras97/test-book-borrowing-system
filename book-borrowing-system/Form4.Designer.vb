<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        btnSendNewsletter = New Button()
        SuspendLayout()
        ' 
        ' btnSendNewsletter
        ' 
        btnSendNewsletter.BackColor = Color.IndianRed
        btnSendNewsletter.FlatStyle = FlatStyle.Flat
        btnSendNewsletter.Font = New Font("Arial", 10F)
        btnSendNewsletter.ForeColor = Color.White
        btnSendNewsletter.Location = New Point(273, 132)
        btnSendNewsletter.Name = "btnSendNewsletter"
        btnSendNewsletter.Size = New Size(263, 139)
        btnSendNewsletter.TabIndex = 22
        btnSendNewsletter.Text = "Send"
        btnSendNewsletter.UseVisualStyleBackColor = False
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnSendNewsletter)
        Name = "Form4"
        Text = "Form4"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSendNewsletter As Button
End Class
