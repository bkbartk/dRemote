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
        Me.mainMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsSSHTransfer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsUVNCSC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsExternalApps = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsPortScan = New System.Windows.Forms.ToolStripMenuItem()
        Me.cMenLayout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenViewResetLayout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenViewConnections = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenViewConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMenToolsOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmenTabSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAmout = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.VS2013BlueTheme2 = New WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.cMenLayout, Me.mMenToolsUpdate, Me.mMenToolsOptions, Me.cmenTabSep1, Me.btnAmout})
        Me.mainMenu.Name = "cmenTab"
        Me.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mainMenu.Size = New System.Drawing.Size(172, 142)
        Me.mainMenu.Text = "File"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMenToolsSSHTransfer, Me.mMenToolsUVNCSC, Me.mMenToolsExternalApps, Me.mMenToolsPortScan})
        Me.ToolsToolStripMenuItem.Image = Global.dRemote.My.Resources.Resources.Options
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'mMenToolsSSHTransfer
        '
        Me.mMenToolsSSHTransfer.Image = Global.dRemote.My.Resources.Resources.SSHTransfer
        Me.mMenToolsSSHTransfer.Name = "mMenToolsSSHTransfer"
        Me.mMenToolsSSHTransfer.Size = New System.Drawing.Size(184, 22)
        Me.mMenToolsSSHTransfer.Text = "SSH File Transfer"
        '
        'mMenToolsUVNCSC
        '
        Me.mMenToolsUVNCSC.Image = Global.dRemote.My.Resources.Resources.UVNC_SC
        Me.mMenToolsUVNCSC.Name = "mMenToolsUVNCSC"
        Me.mMenToolsUVNCSC.Size = New System.Drawing.Size(184, 22)
        Me.mMenToolsUVNCSC.Text = "UltraVNC SingleClick"
        Me.mMenToolsUVNCSC.Visible = False
        '
        'mMenToolsExternalApps
        '
        Me.mMenToolsExternalApps.Image = Global.dRemote.My.Resources.Resources.ExtApp
        Me.mMenToolsExternalApps.Name = "mMenToolsExternalApps"
        Me.mMenToolsExternalApps.Size = New System.Drawing.Size(184, 22)
        Me.mMenToolsExternalApps.Text = "External Applications"
        '
        'mMenToolsPortScan
        '
        Me.mMenToolsPortScan.Image = Global.dRemote.My.Resources.Resources.PortScan
        Me.mMenToolsPortScan.Name = "mMenToolsPortScan"
        Me.mMenToolsPortScan.Size = New System.Drawing.Size(184, 22)
        Me.mMenToolsPortScan.Text = "Port Scan"
        '
        'cMenLayout
        '
        Me.cMenLayout.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMenViewResetLayout, Me.mMenViewConnections, Me.mMenViewConfig})
        Me.cMenLayout.Image = Global.dRemote.My.Resources.Resources.Panels
        Me.cMenLayout.Name = "cMenLayout"
        Me.cMenLayout.Size = New System.Drawing.Size(171, 22)
        Me.cMenLayout.Text = "Layout"
        '
        'mMenViewResetLayout
        '
        Me.mMenViewResetLayout.Image = Global.dRemote.My.Resources.Resources.application_side_tree
        Me.mMenViewResetLayout.Name = "mMenViewResetLayout"
        Me.mMenViewResetLayout.Size = New System.Drawing.Size(141, 22)
        Me.mMenViewResetLayout.Text = "Reset Layout"
        '
        'mMenViewConnections
        '
        Me.mMenViewConnections.Checked = True
        Me.mMenViewConnections.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mMenViewConnections.Image = Global.dRemote.My.Resources.Resources.Root
        Me.mMenViewConnections.Name = "mMenViewConnections"
        Me.mMenViewConnections.Size = New System.Drawing.Size(141, 22)
        Me.mMenViewConnections.Text = "Connections"
        '
        'mMenViewConfig
        '
        Me.mMenViewConfig.Checked = True
        Me.mMenViewConfig.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mMenViewConfig.Image = Global.dRemote.My.Resources.Resources.cog
        Me.mMenViewConfig.Name = "mMenViewConfig"
        Me.mMenViewConfig.Size = New System.Drawing.Size(141, 22)
        Me.mMenViewConfig.Text = "Config"
        '
        'mMenToolsUpdate
        '
        Me.mMenToolsUpdate.Image = Global.dRemote.My.Resources.Resources.Update
        Me.mMenToolsUpdate.Name = "mMenToolsUpdate"
        Me.mMenToolsUpdate.Size = New System.Drawing.Size(171, 22)
        Me.mMenToolsUpdate.Text = "Check for Updates"
        '
        'mMenToolsOptions
        '
        Me.mMenToolsOptions.Image = Global.dRemote.My.Resources.Resources.Config
        Me.mMenToolsOptions.Name = "mMenToolsOptions"
        Me.mMenToolsOptions.Size = New System.Drawing.Size(171, 22)
        Me.mMenToolsOptions.Text = "Options"
        '
        'cmenTabSep1
        '
        Me.cmenTabSep1.Name = "cmenTabSep1"
        Me.cmenTabSep1.Size = New System.Drawing.Size(168, 6)
        '
        'btnAmout
        '
        Me.btnAmout.Image = Global.dRemote.My.Resources.Resources.Help
        Me.btnAmout.Name = "btnAmout"
        Me.btnAmout.Size = New System.Drawing.Size(171, 22)
        Me.btnAmout.Text = "About"
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
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mainMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VS2013BlueTheme1 As WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme
    Friend WithEvents DockPanel1 As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents VS2013BlueTheme2 As WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme
    Friend WithEvents mainMenu As ContextMenuStrip
    Friend WithEvents cmenTabSep1 As ToolStripSeparator
    Friend WithEvents btnAmout As ToolStripMenuItem
    Friend WithEvents mMenToolsOptions As ToolStripMenuItem
    Friend WithEvents mMenToolsUpdate As ToolStripMenuItem
    Friend WithEvents cMenLayout As ToolStripMenuItem
    Friend WithEvents mMenViewResetLayout As ToolStripMenuItem
    Friend WithEvents mMenViewConnections As ToolStripMenuItem
    Friend WithEvents mMenViewConfig As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mMenToolsUVNCSC As ToolStripMenuItem
    Friend WithEvents mMenToolsPortScan As ToolStripMenuItem
    Friend WithEvents mMenToolsExternalApps As ToolStripMenuItem
    Friend WithEvents mMenToolsSSHTransfer As ToolStripMenuItem
End Class
