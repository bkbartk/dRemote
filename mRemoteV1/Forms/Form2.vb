Imports WeifenLuo.WinFormsUI.Docking

Namespace Forms
    Partial Public Class Form2
        Inherits DockContent
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(27, 31)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Not Yet Done"
            '
            'Form2
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "Form2"
            Me.Text = "text"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Label1 As Label

        Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace