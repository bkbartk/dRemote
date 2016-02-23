<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainV2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainV2))
        Me.DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.VS2013BlueTheme2 = New WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme()
        Me.mainMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmenTabSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAmout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'DockPanel1
        '
        Me.DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel1.DockBackColor = System.Drawing.SystemColors.Control
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.ShowDocumentIcon = True
        Me.DockPanel1.Size = New System.Drawing.Size(664, 383)
        Me.DockPanel1.TabIndex = 0
        Me.DockPanel1.Theme = Me.VS2013BlueTheme2
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmenTabSep1, Me.btnAmout})
        Me.mainMenu.Name = "cmenTab"
        Me.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mainMenu.Size = New System.Drawing.Size(108, 32)
        Me.mainMenu.Text = "File"
        '
        'cmenTabSep1
        '
        Me.cmenTabSep1.Name = "cmenTabSep1"
        Me.cmenTabSep1.Size = New System.Drawing.Size(104, 6)
        '
        'btnAmout
        '
        Me.btnAmout.Image = Global.dRemote.My.Resources.Resources.Help
        Me.btnAmout.Name = "btnAmout"
        Me.btnAmout.Size = New System.Drawing.Size(107, 22)
        Me.btnAmout.Text = "About"
        '
        'frmMainV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(664, 383)
        Me.Controls.Add(Me.DockPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMainV2"
        Me.Text = "dRemote"
        Me.mainMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VS2013BlueTheme1 As WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme
    Friend WithEvents DockPanel1 As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents VS2013BlueTheme2 As WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme
    Friend WithEvents mainMenu As ContextMenuStrip
    Friend WithEvents cmenTabSep1 As ToolStripSeparator
    Friend WithEvents btnAmout As ToolStripMenuItem
End Class
