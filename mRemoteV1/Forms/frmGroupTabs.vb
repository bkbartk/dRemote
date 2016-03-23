Imports WeifenLuo.WinFormsUI.Docking
Namespace Forms
    Public Class frmGroupTabs
        Inherits DockContent

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroupTabs))
            Me.VS2013BlueTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme()
            Me.pnlGroup = New WeifenLuo.WinFormsUI.Docking.DockPanel()
            Me.SuspendLayout()
            '
            'pnlGroup
            '
            Me.pnlGroup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGroup.Location = New System.Drawing.Point(0, 0)
            Me.pnlGroup.Name = "pnlGroup"
            Me.pnlGroup.Size = New System.Drawing.Size(284, 261)
            Me.pnlGroup.TabIndex = 3
            '
            'frmGroupTabs
            '
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Controls.Add(Me.pnlGroup)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.Name = "frmGroupTabs"
            Me.Text = "New Group Tab"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents VS2013BlueTheme1 As VS2013BlueTheme
        Friend WithEvents pnlGroup As DockPanel

        Private Sub frmGroupTabs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace