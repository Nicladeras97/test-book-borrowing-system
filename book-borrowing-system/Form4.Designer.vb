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
        Label1 = New Label()
        Label2 = New Label()
        ProgressBar1 = New ProgressBar()
        lblStatus = New Label()
        Panel1 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnSendNewsletter
        ' 
        btnSendNewsletter.Anchor = AnchorStyles.None
        btnSendNewsletter.BackColor = Color.IndianRed
        btnSendNewsletter.Cursor = Cursors.Hand
        btnSendNewsletter.FlatStyle = FlatStyle.Flat
        btnSendNewsletter.Font = New Font("Arial", 28F)
        btnSendNewsletter.ForeColor = Color.White
        btnSendNewsletter.Location = New Point(384, 422)
        btnSendNewsletter.Margin = New Padding(4, 3, 4, 3)
        btnSendNewsletter.Name = "btnSendNewsletter"
        btnSendNewsletter.Size = New Size(240, 75)
        btnSendNewsletter.TabIndex = 22
        btnSendNewsletter.Text = "SEND"
        btnSendNewsletter.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.Font = New Font("Arial", 20F)
        Label1.Location = New Point(2, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(907, 164)
        Label1.TabIndex = 23
        Label1.Text = "Inform all borrowers that new book(s) have been added to the Library!" & vbCrLf & "Click the button below to send personalized recommendations to all borrowers."
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 40F, FontStyle.Bold)
        Label2.Location = New Point(291, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(317, 63)
        Label2.TabIndex = 24
        Label2.Text = "Send Email"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Anchor = AnchorStyles.None
        ProgressBar1.Location = New Point(206, 359)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(611, 28)
        ProgressBar1.TabIndex = 25
        ProgressBar1.Visible = False
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.None
        lblStatus.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus.Location = New Point(206, 325)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(611, 20)
        lblStatus.TabIndex = 26
        lblStatus.Text = "Sending to:  "
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(61, 29)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(913, 273)
        Panel1.TabIndex = 27
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1029, 540)
        Controls.Add(Panel1)
        Controls.Add(lblStatus)
        Controls.Add(ProgressBar1)
        Controls.Add(btnSendNewsletter)
        Font = New Font("Arial", 12F)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Form4"
        Text = "Form4"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSendNewsletter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents Panel1 As Panel
End Class
