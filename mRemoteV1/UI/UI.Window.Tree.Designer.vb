Namespace UI
    Namespace Window
        Partial Public Class Tree
            Inherits Base
#Region " Windows Form Designer generated code "
            Private components As System.ComponentModel.IContainer
            Friend WithEvents txtSearch As System.Windows.Forms.TextBox
            Friend WithEvents pnlConnections As System.Windows.Forms.Panel
            Friend WithEvents imgListTree As System.Windows.Forms.ImageList
            Friend WithEvents msMain As System.Windows.Forms.MenuStrip
            Friend WithEvents mMenView As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents mMenViewExpandAllFolders As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents mMenViewCollapseAllFolders As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTree As System.Windows.Forms.ContextMenuStrip
            Friend WithEvents cMenTreeAddConnection As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeAddFolder As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeSep1 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents cMenTreeConnect As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptions As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptionsConnectToConsoleSession As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptionsNoCredentials As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptionsConnectInFullscreen As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeDisconnect As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeSep2 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents cMenTreeToolsTransferFile As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeToolsSort As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeToolsSortAscending As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeToolsSortDescending As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeSep3 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents cMenTreeRename As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeDelete As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeSep4 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents cMenTreeMoveUp As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeMoveDown As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
            Friend WithEvents cMenTreeToolsExternalApps As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeDuplicate As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptionsChoosePanelBeforeConnecting As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeConnectWithOptionsDontConnectToConsoleSession As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents mMenSortAscending As System.Windows.Forms.ToolStripMenuItem
            Public WithEvents tvConnections As System.Windows.Forms.TreeView
            Private Sub InitializeComponent()
                Me.components = New System.ComponentModel.Container()
                Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Connections")
                Me.tvConnections = New System.Windows.Forms.TreeView()
                Me.cMenTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
                Me.cMenTreeConnect = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptions = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptionsConnectToConsoleSession = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptionsConnectInFullscreen = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptionsNoCredentials = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeDisconnect = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeSep1 = New System.Windows.Forms.ToolStripSeparator()
                Me.cMenTreeToolsExternalApps = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeToolsTransferFile = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeSep2 = New System.Windows.Forms.ToolStripSeparator()
                Me.cMenTreeDuplicate = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeRename = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeDelete = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeSep3 = New System.Windows.Forms.ToolStripSeparator()
                Me.cMenTreeImport = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeImportFile = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeImportActiveDirectory = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeImportPortScan = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeExportFile = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeSep4 = New System.Windows.Forms.ToolStripSeparator()
                Me.cMenTreeAddConnection = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeAddFolder = New System.Windows.Forms.ToolStripMenuItem()
                Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
                Me.cMenTreeToolsSort = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeToolsSortAscending = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeToolsSortDescending = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeMoveUp = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTreeMoveDown = New System.Windows.Forms.ToolStripMenuItem()
                Me.imgListTree = New System.Windows.Forms.ImageList(Me.components)
                Me.pnlConnections = New System.Windows.Forms.Panel()
                Me.PictureBox1 = New System.Windows.Forms.PictureBox()
                Me.txtSearch = New System.Windows.Forms.TextBox()
                Me.msMain = New System.Windows.Forms.MenuStrip()
                Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileNew = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileLoad = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileSave = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
                Me.cmenimport = New System.Windows.Forms.ToolStripMenuItem()
                Me.ToolStripMenuItem26 = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileImportFromFile = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileImportFromActiveDirectory = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileImportFromPortScan = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenFileExport = New System.Windows.Forms.ToolStripMenuItem()
                Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
                Me.mMenView = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenViewExpandAllFolders = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenViewCollapseAllFolders = New System.Windows.Forms.ToolStripMenuItem()
                Me.mMenSortAscending = New System.Windows.Forms.ToolStripMenuItem()
                Me.cMenTree.SuspendLayout()
                Me.pnlConnections.SuspendLayout()
                CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
                Me.msMain.SuspendLayout()
                Me.SuspendLayout()
                '
                'tvConnections
                '
                Me.tvConnections.AllowDrop = True
                Me.tvConnections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.tvConnections.BorderStyle = System.Windows.Forms.BorderStyle.None
                Me.tvConnections.ContextMenuStrip = Me.cMenTree
                Me.tvConnections.HideSelection = False
                Me.tvConnections.ImageIndex = 0
                Me.tvConnections.ImageList = Me.imgListTree
                Me.tvConnections.LabelEdit = True
                Me.tvConnections.Location = New System.Drawing.Point(0, 0)
                Me.tvConnections.Name = "tvConnections"
                TreeNode1.Name = "nodeRoot"
                TreeNode1.Text = "Connections"
                Me.tvConnections.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
                Me.tvConnections.SelectedImageIndex = 0
                Me.tvConnections.Size = New System.Drawing.Size(233, 410)
                Me.tvConnections.TabIndex = 20
                '
                'cMenTree
                '
                Me.cMenTree.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.cMenTree.ImageScalingSize = New System.Drawing.Size(20, 20)
                Me.cMenTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cMenTreeConnect, Me.cMenTreeConnectWithOptions, Me.cMenTreeDisconnect, Me.cMenTreeSep1, Me.cMenTreeToolsExternalApps, Me.cMenTreeToolsTransferFile, Me.cMenTreeSep2, Me.cMenTreeDuplicate, Me.cMenTreeRename, Me.cMenTreeDelete, Me.cMenTreeSep3, Me.cMenTreeImport, Me.cMenTreeExportFile, Me.cMenTreeSep4, Me.cMenTreeAddConnection, Me.cMenTreeAddFolder, Me.ToolStripSeparator1, Me.cMenTreeToolsSort, Me.cMenTreeMoveUp, Me.cMenTreeMoveDown})
                Me.cMenTree.Name = "cMenTree"
                Me.cMenTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
                Me.cMenTree.Size = New System.Drawing.Size(191, 424)
                '
                'cMenTreeConnect
                '
                Me.cMenTreeConnect.Image = Global.dRemote.My.Resources.Resources.Play
                Me.cMenTreeConnect.Name = "cMenTreeConnect"
                Me.cMenTreeConnect.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
                Me.cMenTreeConnect.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeConnect.Text = "Connect"
                '
                'cMenTreeConnectWithOptions
                '
                Me.cMenTreeConnectWithOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cMenTreeConnectWithOptionsConnectToConsoleSession, Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession, Me.cMenTreeConnectWithOptionsConnectInFullscreen, Me.cMenTreeConnectWithOptionsNoCredentials, Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting})
                Me.cMenTreeConnectWithOptions.Name = "cMenTreeConnectWithOptions"
                Me.cMenTreeConnectWithOptions.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeConnectWithOptions.Text = "Connect (with options)"
                '
                'cMenTreeConnectWithOptionsConnectToConsoleSession
                '
                Me.cMenTreeConnectWithOptionsConnectToConsoleSession.Image = Global.dRemote.My.Resources.Resources.monitor_go
                Me.cMenTreeConnectWithOptionsConnectToConsoleSession.Name = "cMenTreeConnectWithOptionsConnectToConsoleSession"
                Me.cMenTreeConnectWithOptionsConnectToConsoleSession.Size = New System.Drawing.Size(235, 26)
                Me.cMenTreeConnectWithOptionsConnectToConsoleSession.Text = "Connect to console session"
                '
                'cMenTreeConnectWithOptionsDontConnectToConsoleSession
                '
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession.Image = Global.dRemote.My.Resources.Resources.monitor_delete
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession.Name = "cMenTreeConnectWithOptionsDontConnectToConsoleSession"
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession.Size = New System.Drawing.Size(235, 26)
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession.Text = "Don't connect to console session"
                Me.cMenTreeConnectWithOptionsDontConnectToConsoleSession.Visible = False
                '
                'cMenTreeConnectWithOptionsConnectInFullscreen
                '
                Me.cMenTreeConnectWithOptionsConnectInFullscreen.Image = Global.dRemote.My.Resources.Resources.arrow_out
                Me.cMenTreeConnectWithOptionsConnectInFullscreen.Name = "cMenTreeConnectWithOptionsConnectInFullscreen"
                Me.cMenTreeConnectWithOptionsConnectInFullscreen.Size = New System.Drawing.Size(235, 26)
                Me.cMenTreeConnectWithOptionsConnectInFullscreen.Text = "Connect in fullscreen"
                '
                'cMenTreeConnectWithOptionsNoCredentials
                '
                Me.cMenTreeConnectWithOptionsNoCredentials.Image = Global.dRemote.My.Resources.Resources.key_delete
                Me.cMenTreeConnectWithOptionsNoCredentials.Name = "cMenTreeConnectWithOptionsNoCredentials"
                Me.cMenTreeConnectWithOptionsNoCredentials.Size = New System.Drawing.Size(235, 26)
                Me.cMenTreeConnectWithOptionsNoCredentials.Text = "Connect without credentials"
                '
                'cMenTreeConnectWithOptionsChoosePanelBeforeConnecting
                '
                Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Image = Global.dRemote.My.Resources.Resources.Panels
                Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Name = "cMenTreeConnectWithOptionsChoosePanelBeforeConnecting"
                Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Size = New System.Drawing.Size(235, 26)
                Me.cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Text = "Choose panel before connecting"
                '
                'cMenTreeDisconnect
                '
                Me.cMenTreeDisconnect.Image = Global.dRemote.My.Resources.Resources.Pause
                Me.cMenTreeDisconnect.Name = "cMenTreeDisconnect"
                Me.cMenTreeDisconnect.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeDisconnect.Text = "Disconnect"
                '
                'cMenTreeSep1
                '
                Me.cMenTreeSep1.Name = "cMenTreeSep1"
                Me.cMenTreeSep1.Size = New System.Drawing.Size(187, 6)
                '
                'cMenTreeToolsExternalApps
                '
                Me.cMenTreeToolsExternalApps.Image = Global.dRemote.My.Resources.Resources.ExtApp
                Me.cMenTreeToolsExternalApps.Name = "cMenTreeToolsExternalApps"
                Me.cMenTreeToolsExternalApps.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeToolsExternalApps.Text = "External Applications"
                '
                'cMenTreeToolsTransferFile
                '
                Me.cMenTreeToolsTransferFile.Image = Global.dRemote.My.Resources.Resources.SSHTransfer
                Me.cMenTreeToolsTransferFile.Name = "cMenTreeToolsTransferFile"
                Me.cMenTreeToolsTransferFile.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeToolsTransferFile.Text = "Transfer File (SSH)"
                '
                'cMenTreeSep2
                '
                Me.cMenTreeSep2.Name = "cMenTreeSep2"
                Me.cMenTreeSep2.Size = New System.Drawing.Size(187, 6)
                '
                'cMenTreeDuplicate
                '
                Me.cMenTreeDuplicate.Image = Global.dRemote.My.Resources.Resources.page_copy
                Me.cMenTreeDuplicate.Name = "cMenTreeDuplicate"
                Me.cMenTreeDuplicate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
                Me.cMenTreeDuplicate.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeDuplicate.Text = "Duplicate"
                '
                'cMenTreeRename
                '
                Me.cMenTreeRename.Image = Global.dRemote.My.Resources.Resources.Rename
                Me.cMenTreeRename.Name = "cMenTreeRename"
                Me.cMenTreeRename.ShortcutKeys = System.Windows.Forms.Keys.F2
                Me.cMenTreeRename.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeRename.Text = "Rename"
                '
                'cMenTreeDelete
                '
                Me.cMenTreeDelete.Image = Global.dRemote.My.Resources.Resources.Delete
                Me.cMenTreeDelete.Name = "cMenTreeDelete"
                Me.cMenTreeDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
                Me.cMenTreeDelete.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeDelete.Text = "Delete"
                '
                'cMenTreeSep3
                '
                Me.cMenTreeSep3.Name = "cMenTreeSep3"
                Me.cMenTreeSep3.Size = New System.Drawing.Size(187, 6)
                '
                'cMenTreeImport
                '
                Me.cMenTreeImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cMenTreeImportFile, Me.cMenTreeImportActiveDirectory, Me.cMenTreeImportPortScan})
                Me.cMenTreeImport.Name = "cMenTreeImport"
                Me.cMenTreeImport.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeImport.Text = "&Import"
                '
                'cMenTreeImportFile
                '
                Me.cMenTreeImportFile.Name = "cMenTreeImportFile"
                Me.cMenTreeImportFile.Size = New System.Drawing.Size(213, 22)
                Me.cMenTreeImportFile.Text = "Import from &File..."
                '
                'cMenTreeImportActiveDirectory
                '
                Me.cMenTreeImportActiveDirectory.Name = "cMenTreeImportActiveDirectory"
                Me.cMenTreeImportActiveDirectory.Size = New System.Drawing.Size(213, 22)
                Me.cMenTreeImportActiveDirectory.Text = "Import from &Active Directory..."
                '
                'cMenTreeImportPortScan
                '
                Me.cMenTreeImportPortScan.Name = "cMenTreeImportPortScan"
                Me.cMenTreeImportPortScan.Size = New System.Drawing.Size(213, 22)
                Me.cMenTreeImportPortScan.Text = "Import from &Port Scan..."
                '
                'cMenTreeExportFile
                '
                Me.cMenTreeExportFile.Name = "cMenTreeExportFile"
                Me.cMenTreeExportFile.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeExportFile.Text = "&Export to File..."
                '
                'cMenTreeSep4
                '
                Me.cMenTreeSep4.Name = "cMenTreeSep4"
                Me.cMenTreeSep4.Size = New System.Drawing.Size(187, 6)
                '
                'cMenTreeAddConnection
                '
                Me.cMenTreeAddConnection.Image = Global.dRemote.My.Resources.Resources.Connection_Add
                Me.cMenTreeAddConnection.Name = "cMenTreeAddConnection"
                Me.cMenTreeAddConnection.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeAddConnection.Text = "New Connection"
                '
                'cMenTreeAddFolder
                '
                Me.cMenTreeAddFolder.Image = Global.dRemote.My.Resources.Resources.Folder_Add
                Me.cMenTreeAddFolder.Name = "cMenTreeAddFolder"
                Me.cMenTreeAddFolder.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeAddFolder.Text = "New Folder"
                '
                'ToolStripSeparator1
                '
                Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
                Me.ToolStripSeparator1.Size = New System.Drawing.Size(187, 6)
                '
                'cMenTreeToolsSort
                '
                Me.cMenTreeToolsSort.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cMenTreeToolsSortAscending, Me.cMenTreeToolsSortDescending})
                Me.cMenTreeToolsSort.Name = "cMenTreeToolsSort"
                Me.cMenTreeToolsSort.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeToolsSort.Text = "Sort"
                '
                'cMenTreeToolsSortAscending
                '
                Me.cMenTreeToolsSortAscending.Image = Global.dRemote.My.Resources.Resources.Sort_AZ
                Me.cMenTreeToolsSortAscending.Name = "cMenTreeToolsSortAscending"
                Me.cMenTreeToolsSortAscending.Size = New System.Drawing.Size(161, 26)
                Me.cMenTreeToolsSortAscending.Text = "Ascending (A-Z)"
                '
                'cMenTreeToolsSortDescending
                '
                Me.cMenTreeToolsSortDescending.Image = Global.dRemote.My.Resources.Resources.Sort_ZA
                Me.cMenTreeToolsSortDescending.Name = "cMenTreeToolsSortDescending"
                Me.cMenTreeToolsSortDescending.Size = New System.Drawing.Size(161, 26)
                Me.cMenTreeToolsSortDescending.Text = "Descending (Z-A)"
                '
                'cMenTreeMoveUp
                '
                Me.cMenTreeMoveUp.Image = Global.dRemote.My.Resources.Resources.Arrow_Up
                Me.cMenTreeMoveUp.Name = "cMenTreeMoveUp"
                Me.cMenTreeMoveUp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Up), System.Windows.Forms.Keys)
                Me.cMenTreeMoveUp.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeMoveUp.Text = "Move up"
                '
                'cMenTreeMoveDown
                '
                Me.cMenTreeMoveDown.Image = Global.dRemote.My.Resources.Resources.Arrow_Down
                Me.cMenTreeMoveDown.Name = "cMenTreeMoveDown"
                Me.cMenTreeMoveDown.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Down), System.Windows.Forms.Keys)
                Me.cMenTreeMoveDown.Size = New System.Drawing.Size(190, 26)
                Me.cMenTreeMoveDown.Text = "Move down"
                '
                'imgListTree
                '
                Me.imgListTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
                Me.imgListTree.ImageSize = New System.Drawing.Size(16, 16)
                Me.imgListTree.TransparentColor = System.Drawing.Color.Transparent
                '
                'pnlConnections
                '
                Me.pnlConnections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.pnlConnections.Controls.Add(Me.PictureBox1)
                Me.pnlConnections.Controls.Add(Me.txtSearch)
                Me.pnlConnections.Controls.Add(Me.tvConnections)
                Me.pnlConnections.Location = New System.Drawing.Point(0, 25)
                Me.pnlConnections.Name = "pnlConnections"
                Me.pnlConnections.Size = New System.Drawing.Size(233, 428)
                Me.pnlConnections.TabIndex = 9
                '
                'PictureBox1
                '
                Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
                Me.PictureBox1.Image = Global.dRemote.My.Resources.Resources.Search
                Me.PictureBox1.Location = New System.Drawing.Point(2, 412)
                Me.PictureBox1.Name = "PictureBox1"
                Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
                Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
                Me.PictureBox1.TabIndex = 1
                Me.PictureBox1.TabStop = False
                '
                'txtSearch
                '
                Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
                Me.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText
                Me.txtSearch.Location = New System.Drawing.Point(19, 413)
                Me.txtSearch.Name = "txtSearch"
                Me.txtSearch.Size = New System.Drawing.Size(212, 13)
                Me.txtSearch.TabIndex = 30
                Me.txtSearch.TabStop = False
                Me.txtSearch.Text = "Search"
                '
                'msMain
                '
                Me.msMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.msMain.ImageScalingSize = New System.Drawing.Size(15, 15)
                Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.cmenimport, Me.mMenView, Me.mMenSortAscending})
                Me.msMain.Location = New System.Drawing.Point(0, 0)
                Me.msMain.Name = "msMain"
                Me.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
                Me.msMain.ShowItemToolTips = True
                Me.msMain.Size = New System.Drawing.Size(233, 28)
                Me.msMain.TabIndex = 10
                Me.msMain.Text = "MenuStrip1"
                '
                'ToolStripMenuItem2
                '
                Me.ToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMenFileNew, Me.mMenFileLoad, Me.mMenFileSave, Me.mMenFileSaveAs})
                Me.ToolStripMenuItem2.Image = Global.dRemote.My.Resources.Resources.Connections_New
                Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
                Me.ToolStripMenuItem2.Size = New System.Drawing.Size(32, 24)
                Me.ToolStripMenuItem2.Text = "&File"
                Me.ToolStripMenuItem2.ToolTipText = "Open / Save"
                '
                'mMenFileNew
                '
                Me.mMenFileNew.Image = Global.dRemote.My.Resources.Resources.Connections_New
                Me.mMenFileNew.Name = "mMenFileNew"
                Me.mMenFileNew.Size = New System.Drawing.Size(265, 26)
                Me.mMenFileNew.Text = "New Connection File"
                '
                'mMenFileLoad
                '
                Me.mMenFileLoad.Image = Global.dRemote.My.Resources.Resources.Connections_Load
                Me.mMenFileLoad.Name = "mMenFileLoad"
                Me.mMenFileLoad.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
                Me.mMenFileLoad.Size = New System.Drawing.Size(265, 26)
                Me.mMenFileLoad.Text = "Open Connection File..."
                '
                'mMenFileSave
                '
                Me.mMenFileSave.Image = Global.dRemote.My.Resources.Resources.Connections_Save
                Me.mMenFileSave.Name = "mMenFileSave"
                Me.mMenFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
                Me.mMenFileSave.Size = New System.Drawing.Size(265, 26)
                Me.mMenFileSave.Text = "Save Connection File"
                '
                'mMenFileSaveAs
                '
                Me.mMenFileSaveAs.Image = Global.dRemote.My.Resources.Resources.Connections_SaveAs
                Me.mMenFileSaveAs.Name = "mMenFileSaveAs"
                Me.mMenFileSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
                Me.mMenFileSaveAs.Size = New System.Drawing.Size(265, 26)
                Me.mMenFileSaveAs.Text = "Save Connection File As..."
                '
                'cmenimport
                '
                Me.cmenimport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.cmenimport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem26, Me.mMenFileExport, Me.ToolStripSeparator9})
                Me.cmenimport.Image = Global.dRemote.My.Resources.Resources.File
                Me.cmenimport.Name = "cmenimport"
                Me.cmenimport.Size = New System.Drawing.Size(32, 24)
                Me.cmenimport.Text = "&File"
                Me.cmenimport.ToolTipText = "Import / Export"
                '
                'ToolStripMenuItem26
                '
                Me.ToolStripMenuItem26.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMenFileImportFromFile, Me.mMenFileImportFromActiveDirectory, Me.mMenFileImportFromPortScan})
                Me.ToolStripMenuItem26.Image = Global.dRemote.My.Resources.Resources.Connection_Duplicate
                Me.ToolStripMenuItem26.Name = "ToolStripMenuItem26"
                Me.ToolStripMenuItem26.Size = New System.Drawing.Size(144, 22)
                Me.ToolStripMenuItem26.Text = "&Import"
                '
                'mMenFileImportFromFile
                '
                Me.mMenFileImportFromFile.Image = Global.dRemote.My.Resources.Resources.Connection_Duplicate
                Me.mMenFileImportFromFile.Name = "mMenFileImportFromFile"
                Me.mMenFileImportFromFile.Size = New System.Drawing.Size(217, 26)
                Me.mMenFileImportFromFile.Text = "Import from &File..."
                '
                'mMenFileImportFromActiveDirectory
                '
                Me.mMenFileImportFromActiveDirectory.Image = Global.dRemote.My.Resources.Resources.ActiveDirectory
                Me.mMenFileImportFromActiveDirectory.Name = "mMenFileImportFromActiveDirectory"
                Me.mMenFileImportFromActiveDirectory.Size = New System.Drawing.Size(217, 26)
                Me.mMenFileImportFromActiveDirectory.Text = "Import from &Active Directory..."
                '
                'mMenFileImportFromPortScan
                '
                Me.mMenFileImportFromPortScan.Image = Global.dRemote.My.Resources.Resources.PortScan
                Me.mMenFileImportFromPortScan.Name = "mMenFileImportFromPortScan"
                Me.mMenFileImportFromPortScan.Size = New System.Drawing.Size(217, 26)
                Me.mMenFileImportFromPortScan.Text = "Import from &Port Scan..."
                '
                'mMenFileExport
                '
                Me.mMenFileExport.Image = Global.dRemote.My.Resources.Resources.Connections_Save
                Me.mMenFileExport.Name = "mMenFileExport"
                Me.mMenFileExport.Size = New System.Drawing.Size(144, 22)
                Me.mMenFileExport.Text = "&Export to File..."
                '
                'ToolStripSeparator9
                '
                Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
                Me.ToolStripSeparator9.Size = New System.Drawing.Size(141, 6)
                '
                'mMenView
                '
                Me.mMenView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.mMenView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMenViewExpandAllFolders, Me.mMenViewCollapseAllFolders})
                Me.mMenView.Image = Global.dRemote.My.Resources.Resources.View
                Me.mMenView.Name = "mMenView"
                Me.mMenView.Size = New System.Drawing.Size(32, 24)
                Me.mMenView.Text = "&View"
                '
                'mMenViewExpandAllFolders
                '
                Me.mMenViewExpandAllFolders.Image = Global.dRemote.My.Resources.Resources.Expand
                Me.mMenViewExpandAllFolders.Name = "mMenViewExpandAllFolders"
                Me.mMenViewExpandAllFolders.Size = New System.Drawing.Size(165, 26)
                Me.mMenViewExpandAllFolders.Text = "Expand all folders"
                '
                'mMenViewCollapseAllFolders
                '
                Me.mMenViewCollapseAllFolders.Image = Global.dRemote.My.Resources.Resources.Collapse
                Me.mMenViewCollapseAllFolders.Name = "mMenViewCollapseAllFolders"
                Me.mMenViewCollapseAllFolders.Size = New System.Drawing.Size(165, 26)
                Me.mMenViewCollapseAllFolders.Text = "Collapse all folders"
                '
                'mMenSortAscending
                '
                Me.mMenSortAscending.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
                Me.mMenSortAscending.Image = Global.dRemote.My.Resources.Resources.Sort_AZ
                Me.mMenSortAscending.Name = "mMenSortAscending"
                Me.mMenSortAscending.Size = New System.Drawing.Size(32, 24)
                '
                'Tree
                '
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
                Me.ClientSize = New System.Drawing.Size(233, 453)
                Me.Controls.Add(Me.msMain)
                Me.Controls.Add(Me.pnlConnections)
                Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.HideOnClose = True
                Me.Icon = Global.dRemote.My.Resources.Resources.Root_Icon
                Me.Name = "Tree"
                Me.TabText = "Connections"
                Me.Text = "Connections"
                Me.cMenTree.ResumeLayout(False)
                Me.pnlConnections.ResumeLayout(False)
                Me.pnlConnections.PerformLayout()
                CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
                Me.msMain.ResumeLayout(False)
                Me.msMain.PerformLayout()
                Me.ResumeLayout(False)
                Me.PerformLayout()

            End Sub
            Friend WithEvents cMenTreeImport As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeExportFile As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
            Friend WithEvents cMenTreeImportFile As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeImportActiveDirectory As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents cMenTreeImportPortScan As System.Windows.Forms.ToolStripMenuItem
            Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
            Friend WithEvents mMenFileNew As ToolStripMenuItem
            Friend WithEvents mMenFileLoad As ToolStripMenuItem
            Friend WithEvents mMenFileSave As ToolStripMenuItem
            Friend WithEvents mMenFileSaveAs As ToolStripMenuItem
            Friend WithEvents cmenimport As ToolStripMenuItem
            Friend WithEvents ToolStripMenuItem26 As ToolStripMenuItem
            Friend WithEvents mMenFileImportFromFile As ToolStripMenuItem
            Friend WithEvents mMenFileImportFromActiveDirectory As ToolStripMenuItem
            Friend WithEvents mMenFileImportFromPortScan As ToolStripMenuItem
            Friend WithEvents mMenFileExport As ToolStripMenuItem
            Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
#End Region
        End Class
    End Namespace
End Namespace
