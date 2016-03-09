Imports System.ComponentModel
Imports WeifenLuo.WinFormsUI.Docking

Namespace Forms
    Partial Public Class frmConnections
        Inherits DockContent
        Public Sub New()
            InitializeComponent()

        End Sub

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnections))
            Me.cmenTab = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.cmenTabFullscreen = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabSmartSize = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabViewOnly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.cmenTabScreenshot = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabStartChat = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabTransferFile = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabRefreshScreen = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabSendSpecialKeys = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabSendSpecialKeysCtrlAltDel = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabSendSpecialKeysCtrlEsc = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabPuttySettings = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabExternalApps = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabSep1 = New System.Windows.Forms.ToolStripSeparator()
            Me.cmenTabRenameTab = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabReconnect = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTabDisconnect = New System.Windows.Forms.ToolStripMenuItem()
            Me.cmenTab.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmenTab
            '
            Me.cmenTab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmenTabFullscreen, Me.cmenTabSmartSize, Me.cmenTabViewOnly, Me.ToolStripSeparator1, Me.cmenTabScreenshot, Me.cmenTabStartChat, Me.cmenTabTransferFile, Me.cmenTabRefreshScreen, Me.cmenTabSendSpecialKeys, Me.cmenTabPuttySettings, Me.cmenTabExternalApps, Me.cmenTabSep1, Me.cmenTabRenameTab, Me.cmenTabReconnect, Me.cmenTabDisconnect})
            Me.cmenTab.Name = "cmenTab"
            Me.cmenTab.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
            Me.cmenTab.Size = New System.Drawing.Size(188, 302)
            '
            'cmenTabFullscreen
            '
            Me.cmenTabFullscreen.Image = Global.dRemote.My.Resources.Resources.arrow_out
            Me.cmenTabFullscreen.Name = "cmenTabFullscreen"
            Me.cmenTabFullscreen.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabFullscreen.Text = "Fullscreen (RDP)"
            Me.cmenTabFullscreen.Visible = False
            '
            'cmenTabSmartSize
            '
            Me.cmenTabSmartSize.Image = Global.dRemote.My.Resources.Resources.SmartSize
            Me.cmenTabSmartSize.Name = "cmenTabSmartSize"
            Me.cmenTabSmartSize.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabSmartSize.Text = "SmartSize (RDP/VNC)"
            '
            'cmenTabViewOnly
            '
            Me.cmenTabViewOnly.Name = "cmenTabViewOnly"
            Me.cmenTabViewOnly.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabViewOnly.Text = "View Only (VNC)"
            Me.cmenTabViewOnly.Visible = False
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
            '
            'cmenTabScreenshot
            '
            Me.cmenTabScreenshot.Image = Global.dRemote.My.Resources.Resources.Screenshot_Add
            Me.cmenTabScreenshot.Name = "cmenTabScreenshot"
            Me.cmenTabScreenshot.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabScreenshot.Text = "Screenshot"
            Me.cmenTabScreenshot.Visible = False
            '
            'cmenTabStartChat
            '
            Me.cmenTabStartChat.Image = Global.dRemote.My.Resources.Resources.Chat
            Me.cmenTabStartChat.Name = "cmenTabStartChat"
            Me.cmenTabStartChat.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabStartChat.Text = "Start Chat (VNC)"
            Me.cmenTabStartChat.Visible = False
            '
            'cmenTabTransferFile
            '
            Me.cmenTabTransferFile.Image = Global.dRemote.My.Resources.Resources.SSHTransfer
            Me.cmenTabTransferFile.Name = "cmenTabTransferFile"
            Me.cmenTabTransferFile.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabTransferFile.Text = "Transfer File (SSH)"
            Me.cmenTabTransferFile.Visible = False
            '
            'cmenTabRefreshScreen
            '
            Me.cmenTabRefreshScreen.Image = Global.dRemote.My.Resources.Resources.Refresh
            Me.cmenTabRefreshScreen.Name = "cmenTabRefreshScreen"
            Me.cmenTabRefreshScreen.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabRefreshScreen.Text = "Refresh Screen (VNC)"
            Me.cmenTabRefreshScreen.Visible = False
            '
            'cmenTabSendSpecialKeys
            '
            Me.cmenTabSendSpecialKeys.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmenTabSendSpecialKeysCtrlAltDel, Me.cmenTabSendSpecialKeysCtrlEsc})
            Me.cmenTabSendSpecialKeys.Image = Global.dRemote.My.Resources.Resources.Keyboard
            Me.cmenTabSendSpecialKeys.Name = "cmenTabSendSpecialKeys"
            Me.cmenTabSendSpecialKeys.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabSendSpecialKeys.Text = "Send Command"
            Me.cmenTabSendSpecialKeys.Visible = False
            '
            'cmenTabSendSpecialKeysCtrlAltDel
            '
            Me.cmenTabSendSpecialKeysCtrlAltDel.Name = "cmenTabSendSpecialKeysCtrlAltDel"
            Me.cmenTabSendSpecialKeysCtrlAltDel.Size = New System.Drawing.Size(141, 22)
            Me.cmenTabSendSpecialKeysCtrlAltDel.Text = "Ctrl+Alt+Del"
            Me.cmenTabSendSpecialKeysCtrlAltDel.Visible = False
            '
            'cmenTabSendSpecialKeysCtrlEsc
            '
            Me.cmenTabSendSpecialKeysCtrlEsc.Name = "cmenTabSendSpecialKeysCtrlEsc"
            Me.cmenTabSendSpecialKeysCtrlEsc.Size = New System.Drawing.Size(141, 22)
            Me.cmenTabSendSpecialKeysCtrlEsc.Text = "Ctrl+Esc"
            Me.cmenTabSendSpecialKeysCtrlEsc.Visible = False
            '
            'cmenTabPuttySettings
            '
            Me.cmenTabPuttySettings.Name = "cmenTabPuttySettings"
            Me.cmenTabPuttySettings.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabPuttySettings.Text = "PuTTY Settings"
            Me.cmenTabPuttySettings.Visible = False
            '
            'cmenTabExternalApps
            '
            Me.cmenTabExternalApps.Image = CType(resources.GetObject("cmenTabExternalApps.Image"), System.Drawing.Image)
            Me.cmenTabExternalApps.Name = "cmenTabExternalApps"
            Me.cmenTabExternalApps.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabExternalApps.Text = "External Applications"
            '
            'cmenTabSep1
            '
            Me.cmenTabSep1.Name = "cmenTabSep1"
            Me.cmenTabSep1.Size = New System.Drawing.Size(184, 6)
            '
            'cmenTabRenameTab
            '
            Me.cmenTabRenameTab.Image = Global.dRemote.My.Resources.Resources.Rename
            Me.cmenTabRenameTab.Name = "cmenTabRenameTab"
            Me.cmenTabRenameTab.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabRenameTab.Text = "Rename Tab"
            '
            'cmenTabReconnect
            '
            Me.cmenTabReconnect.Image = CType(resources.GetObject("cmenTabReconnect.Image"), System.Drawing.Image)
            Me.cmenTabReconnect.Name = "cmenTabReconnect"
            Me.cmenTabReconnect.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabReconnect.Text = "Reconnect"
            '
            'cmenTabDisconnect
            '
            Me.cmenTabDisconnect.Image = Global.dRemote.My.Resources.Resources.Pause
            Me.cmenTabDisconnect.Name = "cmenTabDisconnect"
            Me.cmenTabDisconnect.Size = New System.Drawing.Size(187, 22)
            Me.cmenTabDisconnect.Text = "Disconnect"
            '
            'frmConnections
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmConnections"
            Me.Text = "New Tab"
            Me.cmenTab.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private components As System.ComponentModel.IContainer
        Friend WithEvents cmenTab As ContextMenuStrip
        Friend WithEvents cmenTabFullscreen As ToolStripMenuItem
        Friend WithEvents cmenTabSmartSize As ToolStripMenuItem
        Friend WithEvents cmenTabViewOnly As ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
        Friend WithEvents cmenTabScreenshot As ToolStripMenuItem
        Friend WithEvents cmenTabStartChat As ToolStripMenuItem
        Friend WithEvents cmenTabTransferFile As ToolStripMenuItem
        Friend WithEvents cmenTabRefreshScreen As ToolStripMenuItem
        Friend WithEvents cmenTabSendSpecialKeys As ToolStripMenuItem
        Friend WithEvents cmenTabSendSpecialKeysCtrlAltDel As ToolStripMenuItem
        Friend WithEvents cmenTabSendSpecialKeysCtrlEsc As ToolStripMenuItem
        Friend WithEvents cmenTabPuttySettings As ToolStripMenuItem
        Friend WithEvents cmenTabExternalApps As ToolStripMenuItem
        Friend WithEvents cmenTabSep1 As ToolStripSeparator
        Friend WithEvents cmenTabRenameTab As ToolStripMenuItem
        Friend WithEvents cmenTabReconnect As ToolStripMenuItem
        Friend WithEvents cmenTabDisconnect As ToolStripMenuItem


    End Class


End Namespace