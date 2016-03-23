Imports dRemote.App
Imports dRemote.My
Imports WeifenLuo.WinFormsUI.Docking
Imports dRemote.App.Runtime
Imports dRemote.Connection

Namespace UI
    Namespace Window
        Public Class Tree
            Inherits Base
#Region "Form Stuff"
            Private Sub Tree_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
                ApplyLanguage()

                AddHandler Themes.ThemeManager.ThemeChanged, AddressOf ApplyTheme
                ApplyTheme()

                txtSearch.Multiline = True
                txtSearch.MinimumSize = New Size(0, 14)
                txtSearch.Size = New Size(txtSearch.Size.Width, 14)
                txtSearch.Multiline = False

            End Sub

            Private Sub ApplyLanguage()
                Text = Language.strConnections
                TabText = Language.strConnections

                'mMenAddConnection.ToolTipText = Language.strAddConnection
                'mMenAddFolder.ToolTipText = Language.strAddFolder
                mMenView.ToolTipText = Language.strMenuView.Replace("&", "")
                mMenViewExpandAllFolders.Text = Language.strExpandAllFolders
                mMenViewCollapseAllFolders.Text = Language.strCollapseAllFolders
                mMenSortAscending.ToolTipText = Language.strSortAsc

                cMenTreeConnect.Text = Language.strConnect
                cMenTreeConnectWithOptions.Text = Language.strConnectWithOptions
                cMenTreeConnectWithOptionsConnectToConsoleSession.Text = Language.strConnectToConsoleSession
                cMenTreeConnectWithOptionsDontConnectToConsoleSession.Text = Language.strDontConnectToConsoleSessionMenuItem
                cMenTreeConnectWithOptionsConnectInFullscreen.Text = Language.strConnectInFullscreen
                cMenTreeConnectWithOptionsNoCredentials.Text = Language.strConnectNoCredentials
                cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Text = Language.strChoosePanelBeforeConnecting
                cMenTreeDisconnect.Text = Language.strMenuDisconnect

                cMenTreeToolsExternalApps.Text = Language.strMenuExternalTools
                cMenTreeToolsTransferFile.Text = Language.strMenuTransferFile

                cMenTreeDuplicate.Text = Language.strDuplicate
                cMenTreeRename.Text = Language.strRename
                cMenTreeDelete.Text = Language.strMenuDelete

                cMenTreeImport.Text = Language.strImportMenuItem
                cMenTreeImportFile.Text = Language.strImportFromFileMenuItem
                cMenTreeImportActiveDirectory.Text = Language.strImportAD
                cMenTreeImportPortScan.Text = Language.strImportPortScan
                cMenTreeExportFile.Text = Language.strExportToFileMenuItem

                cMenTreeAddConnection.Text = Language.strAddConnection
                cMenTreeAddFolder.Text = Language.strAddFolder

                cMenTreeToolsSort.Text = Language.strSort
                cMenTreeToolsSortAscending.Text = Language.strSortAsc
                cMenTreeToolsSortDescending.Text = Language.strSortDesc
                cMenTreeMoveUp.Text = Language.strMoveUp
                cMenTreeMoveDown.Text = Language.strMoveDown

                txtSearch.Text = Language.strSearchPrompt
            End Sub

            Public Sub ApplyTheme()
                With Themes.ThemeManager.ActiveTheme
                    msMain.BackColor = .ToolbarBackgroundColor
                    msMain.ForeColor = .ToolbarTextColor
                    tvConnections.BackColor = .ConnectionsPanelBackgroundColor
                    tvConnections.ForeColor = .ConnectionsPanelTextColor
                    tvConnections.LineColor = .ConnectionsPanelTreeLineColor
                    BackColor = .ToolbarBackgroundColor
                    txtSearch.BackColor = .SearchBoxBackgroundColor
                    txtSearch.ForeColor = .SearchBoxTextPromptColor
                End With
            End Sub
#End Region

#Region "Public Methods"
            Public Sub New()
                WindowType = Type.Tree
                InitializeComponent()
                FillImageList()

                DescriptionTooltip = New ToolTip
                DescriptionTooltip.InitialDelay = 300
                DescriptionTooltip.ReshowDelay = 0


                Windows.treePanel.Focus()

                dRemote.Tree.Node.TreeView = tvConnections

                If My.Settings.FirstStart And
                Not My.Settings.LoadConsFromCustomLocation And
                Not IO.File.Exists(GetStartupConnectionFileName()) Then
                    NewConnections(GetStartupConnectionFileName())
                End If
                LoadConnections(tvConnections:=tvConnections)

            End Sub
            Public Sub New(ByVal panel As DockContent)
                WindowType = Type.Tree
                DockPnl = panel
                InitializeComponent()
                FillImageList()

                DescriptionTooltip = New ToolTip
                DescriptionTooltip.InitialDelay = 300
                DescriptionTooltip.ReshowDelay = 0
            End Sub

            Public Sub InitialRefresh()
                tvConnections_AfterSelect(tvConnections, New TreeViewEventArgs(tvConnections.SelectedNode, TreeViewAction.ByMouse))
            End Sub
#End Region

#Region "Public Properties"
            Public Property DescriptionTooltip() As ToolTip
#End Region

#Region "Private Methods"
            Private Sub FillImageList()
                Try
                    imgListTree.Images.Add(Resources.Root)
                    imgListTree.Images.Add(Resources.Folder)
                    imgListTree.Images.Add(Resources.Play)
                    imgListTree.Images.Add(Resources.Pause)
                    imgListTree.Images.Add(Resources.PuttySessions)
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "FillImageList (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub tvConnections_BeforeLabelEdit(ByVal sender As Object, ByVal e As NodeLabelEditEventArgs) Handles tvConnections.BeforeLabelEdit
                cMenTreeDelete.ShortcutKeys = Keys.None
            End Sub

            Private Sub tvConnections_AfterLabelEdit(ByVal sender As Object, ByVal e As NodeLabelEditEventArgs) Handles tvConnections.AfterLabelEdit
                Try
                    cMenTreeDelete.ShortcutKeys = Keys.Delete

                    dRemote.Tree.Node.FinishRenameSelectedNode(e.Label)

                    'Dim pane As WeifenLuo.WinFormsUI.Docking.DockPane = GetClosestPane(sender)
                    'pane.DockPanel
                    'Dim f2 As New Forms.Form2()
                    'f2.Show(pane.DockPanel, DockState.Document)


                    Windows.configForm.pGrid_SelectedObjectChanged()
                    ShowHideTreeContextMenuItems(e.Node)
                    SaveConnectionsBG()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_AfterLabelEdit (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub tvConnections_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles tvConnections.AfterSelect
                Try
                    Select Case dRemote.Tree.Node.GetNodeType(e.Node)
                        Case dRemote.Tree.Node.Type.Connection, dRemote.Tree.Node.Type.PuttySession
                            Windows.configForm.SetPropertyGridObject(e.Node.Tag)
                        Case dRemote.Tree.Node.Type.Container
                            Windows.configForm.SetPropertyGridObject(TryCast(e.Node.Tag, Container.Info).ConnectionInfo)
                        Case dRemote.Tree.Node.Type.Root, dRemote.Tree.Node.Type.PuttyRoot
                            Windows.configForm.SetPropertyGridObject(e.Node.Tag)
                        Case Else
                            Exit Sub
                    End Select

                    Windows.configForm.pGrid_SelectedObjectChanged()
                    ShowHideTreeContextMenuItems(e.Node)
                    Windows.sessionsForm.GetSessions(True)

                    LastSelected = dRemote.Tree.Node.GetConstantID(e.Node)
                Catch ex As Exception
                    If Not IsNothing(MessageCollector) Then
                        MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_AfterSelect (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                    End If
                End Try
            End Sub

            Private Sub tvConnections_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles tvConnections.NodeMouseClick
                Try
                    ShowHideTreeContextMenuItems(tvConnections.SelectedNode)
                    tvConnections.SelectedNode = e.Node

                    If e.Button = MouseButtons.Left Then
                        If Settings.SingleClickOnConnectionOpensIt And _
                            (dRemote.Tree.Node.GetNodeType(e.Node) = dRemote.Tree.Node.Type.Connection Or _
                             dRemote.Tree.Node.GetNodeType(e.Node) = dRemote.Tree.Node.Type.PuttySession) Then
                            OpenConnection(tvConnections)
                        End If

                        If Settings.SingleClickSwitchesToOpenConnection And dRemote.Tree.Node.GetNodeType(e.Node) = dRemote.Tree.Node.Type.Connection Then
                            SwitchToOpenConnection(e.Node.Tag)
                        End If
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_NodeMouseClick (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub tvConnections_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles tvConnections.NodeMouseDoubleClick
                If dRemote.Tree.Node.GetNodeType(dRemote.Tree.Node.SelectedNode) = dRemote.Tree.Node.Type.Connection Or
                   dRemote.Tree.Node.GetNodeType(dRemote.Tree.Node.SelectedNode) = dRemote.Tree.Node.Type.PuttySession Then
                    If My.Settings.Beta Then
                        OpenConnectionV2(tvConnections, sender)
                    Else
                        OpenConnection(tvConnections)
                    End If

                End If
            End Sub
            'Sub fr2_resize(sender As Object, e As EventArgs)
            '    Dim s As String = ""
            'End Sub
            ''Sub fr2_resizeEnd(sender As Object, e As EventArgs)
            ''    Dim s As String = ""
            ''End Sub




            Private Sub tvConnections_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles tvConnections.MouseMove
                Try
                    dRemote.Tree.Node.SetNodeToolTip(e, DescriptionTooltip)
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_MouseMove (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub EnableMenuItemsRecursive(ByVal items As ToolStripItemCollection, Optional ByVal enable As Boolean = True)
                Dim menuItem As ToolStripMenuItem
                For Each item As ToolStripItem In items
                    menuItem = TryCast(item, ToolStripMenuItem)
                    If menuItem Is Nothing Then Continue For
                    menuItem.Enabled = enable
                    If menuItem.HasDropDownItems Then
                        EnableMenuItemsRecursive(menuItem.DropDownItems, enable)
                    End If
                Next
            End Sub

            Private Sub ShowHideTreeContextMenuItems(ByVal selectedNode As TreeNode)
                If selectedNode Is Nothing Then Return

                Try
                    cMenTree.Enabled = True
                    EnableMenuItemsRecursive(cMenTree.Items)

                    Select Case dRemote.Tree.Node.GetNodeType(selectedNode)
                        Case dRemote.Tree.Node.Type.Connection
                            Dim connectionInfo As dRemote.Connection.Info = selectedNode.Tag

                            If connectionInfo.OpenConnections.Count = 0 Then
                                cMenTreeDisconnect.Enabled = False
                            End If

                            If Not (connectionInfo.Protocol = dRemote.Connection.Protocol.Protocols.SSH1 Or _
                                    connectionInfo.Protocol = dRemote.Connection.Protocol.Protocols.SSH2) Then
                                cMenTreeToolsTransferFile.Enabled = False
                            End If

                            If Not (connectionInfo.Protocol = dRemote.Connection.Protocol.Protocols.RDP Or _
                                    connectionInfo.Protocol = dRemote.Connection.Protocol.Protocols.ICA) Then
                                cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = False
                                cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = False
                            End If

                            If (connectionInfo.Protocol = dRemote.Connection.Protocol.Protocols.IntApp) Then
                                cMenTreeConnectWithOptionsNoCredentials.Enabled = False
                            End If
                        Case dRemote.Tree.Node.Type.PuttySession
                            Dim puttySessionInfo As dRemote.Connection.PuttySession.Info = selectedNode.Tag

                            cMenTreeAddConnection.Enabled = False
                            cMenTreeAddFolder.Enabled = False

                            If puttySessionInfo.OpenConnections.Count = 0 Then
                                cMenTreeDisconnect.Enabled = False
                            End If

                            If Not (puttySessionInfo.Protocol = dRemote.Connection.Protocol.Protocols.SSH1 Or _
                                    puttySessionInfo.Protocol = dRemote.Connection.Protocol.Protocols.SSH2) Then
                                cMenTreeToolsTransferFile.Enabled = False
                            End If

                            cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = False
                            cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = False
                            cMenTreeToolsSort.Enabled = False
                            cMenTreeDuplicate.Enabled = False
                            cMenTreeRename.Enabled = False
                            'cMenTreeDelete.Enabled = False
                            cMenTreeMoveUp.Enabled = False
                            cMenTreeMoveDown.Enabled = False
                        Case dRemote.Tree.Node.Type.Container
                            cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = False
                            cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = False
                            cMenTreeDisconnect.Enabled = False

                            Dim openConnections As Integer = 0
                            Dim connectionInfo As dRemote.Connection.Info
                            For Each node As TreeNode In selectedNode.Nodes
                                If TypeOf node.Tag Is dRemote.Connection.Info Then
                                    connectionInfo = node.Tag
                                    openConnections = openConnections + connectionInfo.OpenConnections.Count
                                End If
                            Next
                            If openConnections = 0 Then
                                cMenTreeDisconnect.Enabled = False
                            End If

                            cMenTreeToolsTransferFile.Enabled = False
                            cMenTreeToolsExternalApps.Enabled = False
                        Case dRemote.Tree.Node.Type.Root
                            cMenTreeConnect.Enabled = False
                            cMenTreeConnectWithOptions.Enabled = False
                            cMenTreeConnectWithOptionsConnectInFullscreen.Enabled = False
                            cMenTreeConnectWithOptionsConnectToConsoleSession.Enabled = False
                            cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Enabled = False
                            cMenTreeDisconnect.Enabled = False
                            cMenTreeToolsTransferFile.Enabled = False
                            cMenTreeToolsExternalApps.Enabled = False
                            cMenTreeDuplicate.Enabled = False
                            cMenTreeDelete.Enabled = False
                            cMenTreeMoveUp.Enabled = False
                            cMenTreeMoveDown.Enabled = False
                        Case dRemote.Tree.Node.Type.PuttyRoot
                            cMenTreeAddConnection.Enabled = False
                            cMenTreeAddFolder.Enabled = False
                            cMenTreeConnect.Enabled = False
                            cMenTreeConnectWithOptions.Enabled = False
                            cMenTreeDisconnect.Enabled = False
                            cMenTreeToolsTransferFile.Enabled = False
                            cMenTreeConnectWithOptions.Enabled = False
                            cMenTreeToolsSort.Enabled = False
                            cMenTreeToolsExternalApps.Enabled = False
                            cMenTreeDuplicate.Enabled = False
                            cMenTreeRename.Enabled = True
                            cMenTreeDelete.Enabled = False
                            cMenTreeMoveUp.Enabled = False
                            cMenTreeMoveDown.Enabled = False
                        Case Else
                            cMenTree.Enabled = False
                    End Select
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "ShowHideTreeContextMenuItems (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub
#End Region

#Region "Drag and Drop"
            Private Shared Sub tvConnections_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles tvConnections.DragDrop
                Try
                    'Check that there is a TreeNode being dragged
                    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

                    'Get the TreeView raising the event (in case multiple on form)
                    Dim selectedTreeview As TreeView = CType(sender, TreeView)

                    'Get the TreeNode being dragged
                    Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

                    'The target node should be selected from the DragOver event
                    Dim targetNode As TreeNode = selectedTreeview.SelectedNode

                    If dropNode Is targetNode Then
                        Exit Sub
                    End If

                    If dRemote.Tree.Node.GetNodeType(dropNode) = dRemote.Tree.Node.Type.Root Then
                        Exit Sub
                    End If

                    If dropNode Is targetNode.Parent Then
                        Exit Sub
                    End If

                    'Remove the drop node from its current location
                    dropNode.Remove()

                    'If there is no targetNode add dropNode to the bottom of
                    'the TreeView root nodes, otherwise add it to the end of
                    'the dropNode child nodes

                    If dRemote.Tree.Node.GetNodeType(targetNode) = dRemote.Tree.Node.Type.Root Or dRemote.Tree.Node.GetNodeType(targetNode) = dRemote.Tree.Node.Type.Container Then
                        targetNode.Nodes.Insert(0, dropNode)
                    Else
                        targetNode.Parent.Nodes.Insert(targetNode.Index + 1, dropNode)
                    End If

                    If dRemote.Tree.Node.GetNodeType(dropNode) = dRemote.Tree.Node.Type.Connection Or dRemote.Tree.Node.GetNodeType(dropNode) = dRemote.Tree.Node.Type.Container Then
                        If dRemote.Tree.Node.GetNodeType(dropNode.Parent) = dRemote.Tree.Node.Type.Container Then
                            dropNode.Tag.Parent = dropNode.Parent.Tag
                        ElseIf dRemote.Tree.Node.GetNodeType(dropNode.Parent) = dRemote.Tree.Node.Type.Root Then
                            dropNode.Tag.Parent = Nothing
                            If dRemote.Tree.Node.GetNodeType(dropNode) = dRemote.Tree.Node.Type.Connection Then
                                dropNode.Tag.Inherit.TurnOffInheritanceCompletely()
                            ElseIf dRemote.Tree.Node.GetNodeType(dropNode) = dRemote.Tree.Node.Type.Container Then
                                dropNode.Tag.ConnectionInfo.Inherit.TurnOffInheritanceCompletely()
                            End If
                        End If
                    End If

                    'Ensure the newly created node is visible to
                    'the user and select it
                    dropNode.EnsureVisible()
                    selectedTreeview.SelectedNode = dropNode

                    SaveConnectionsBG()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_DragDrop (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub tvConnections_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles tvConnections.DragEnter
                Try
                    'See if there is a TreeNode being dragged
                    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
                        'TreeNode found allow move effect
                        e.Effect = DragDropEffects.Move
                    Else
                        'No TreeNode found, prevent move
                        e.Effect = DragDropEffects.None
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_DragEnter (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub tvConnections_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles tvConnections.DragOver
                Try
                    'Check that there is a TreeNode being dragged 
                    If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

                    'Get the TreeView raising the event (in case multiple on form)
                    Dim selectedTreeview As TreeView = CType(sender, TreeView)

                    'As the mouse moves over nodes, provide feedback to 
                    'the user by highlighting the node that is the 
                    'current drop target
                    Dim pt As Point = CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
                    Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

                    'Select the node currently under the cursor
                    selectedTreeview.SelectedNode = targetNode

                    'Check that the selected node is not the dropNode and
                    'also that it is not a child of the dropNode and 
                    'therefore an invalid target
                    Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

                    Dim puttyRootInfo As Root.PuttySessions.Info
                    Do Until targetNode Is Nothing
                        puttyRootInfo = TryCast(targetNode.Tag, Root.PuttySessions.Info)
                        If puttyRootInfo IsNot Nothing Or targetNode Is dropNode Then
                            e.Effect = DragDropEffects.None
                            Return
                        End If
                        targetNode = targetNode.Parent
                    Loop

                    'Currently selected node is a suitable target
                    e.Effect = DragDropEffects.Move
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_DragOver (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub tvConnections_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles tvConnections.ItemDrag
                Try
                    Dim dragTreeNode As TreeNode = TryCast(e.Item, TreeNode)
                    If dragTreeNode Is Nothing Then Return

                    If dragTreeNode.Tag Is Nothing Then Return
                    If TypeOf dragTreeNode.Tag Is dRemote.Connection.PuttySession.Info Or _
                       Not (TypeOf dragTreeNode.Tag Is dRemote.Connection.Info Or _
                            TypeOf dragTreeNode.Tag Is Container.Info) Then
                        tvConnections.SelectedNode = dragTreeNode
                        Return
                    End If

                    'Set the drag node and initiate the DragDrop 
                    DoDragDrop(e.Item, DragDropEffects.Move)
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_ItemDrag (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub
#End Region

#Region "Tree Context Menu"
            Private Shared Sub mMenFileLoad_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenFileLoad.Click
                If IsConnectionsFileLoaded Then
                    Select Case MsgBox(Language.strSaveConnectionsFileBeforeOpeningAnother, MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                        Case MsgBoxResult.Yes
                            SaveConnections()
                        Case MsgBoxResult.Cancel
                            Return
                    End Select
                End If

                LoadConnections(True)
            End Sub
            Private Sub cMenTreeAddConnection_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeAddConnection.Click
                AddConnection()
                SaveConnectionsBG()
            End Sub

            Private Sub cMenTreeAddFolder_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeAddFolder.Click
                AddFolder()
                SaveConnectionsBG()
            End Sub

            Private Sub cMenTreeConnect_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnect.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.DoNotJump, tvConnections)
                End If
            End Sub

            Private Sub cMenTreeConnectWithOptionsConnectToConsoleSession_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnectWithOptionsConnectToConsoleSession.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender, dRemote.Connection.Info.Force.UseConsoleSession Or dRemote.Connection.Info.Force.DoNotJump)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.UseConsoleSession Or dRemote.Connection.Info.Force.DoNotJump, tvConnections)
                End If
            End Sub

            Private Sub cMenTreeConnectWithOptionsNoCredentials_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnectWithOptionsNoCredentials.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender, dRemote.Connection.Info.Force.NoCredentials)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.NoCredentials, tvConnections)
                End If

            End Sub

            Private Sub cMenTreeConnectWithOptionsDontConnectToConsoleSession_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnectWithOptionsDontConnectToConsoleSession.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender, dRemote.Connection.Info.Force.DontUseConsoleSession Or dRemote.Connection.Info.Force.DoNotJump)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.DontUseConsoleSession Or dRemote.Connection.Info.Force.DoNotJump, tvConnections)
                End If
            End Sub

            Private Sub cMenTreeConnectWithOptionsConnectInFullscreen_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnectWithOptionsConnectInFullscreen.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender, dRemote.Connection.Info.Force.Fullscreen Or dRemote.Connection.Info.Force.DoNotJump)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.Fullscreen Or dRemote.Connection.Info.Force.DoNotJump, tvConnections)
                End If
            End Sub

            Private Sub cMenTreeConnectWithOptionsChoosePanelBeforeConnecting_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Click
                If My.Settings.Beta Then
                    OpenConnectionV2(tvConnections, sender, dRemote.Connection.Info.Force.OverridePanel Or dRemote.Connection.Info.Force.DoNotJump)
                Else
                    OpenConnection(dRemote.Connection.Info.Force.OverridePanel Or dRemote.Connection.Info.Force.DoNotJump, tvConnections)
                End If
            End Sub

            Private Sub cMenTreeDisconnect_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeDisconnect.Click
                DisconnectConnection()
            End Sub

            Private Shared Sub cMenTreeToolsTransferFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeToolsTransferFile.Click
                SshTransferFile()
            End Sub

            Private Sub mMenSortAscending_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenSortAscending.Click
                tvConnections.BeginUpdate()
                dRemote.Tree.Node.Sort(tvConnections.Nodes.Item(0), SortOrder.Ascending)
                tvConnections.EndUpdate()
                SaveConnectionsBG()
            End Sub

            Private Sub cMenTreeToolsSortAscending_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeToolsSortAscending.Click
                tvConnections.BeginUpdate()
                dRemote.Tree.Node.Sort(tvConnections.SelectedNode, SortOrder.Ascending)
                tvConnections.EndUpdate()
                SaveConnectionsBG()
            End Sub

            Private Sub cMenTreeToolsSortDescending_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeToolsSortDescending.Click
                tvConnections.BeginUpdate()
                dRemote.Tree.Node.Sort(tvConnections.SelectedNode, SortOrder.Descending)
                tvConnections.EndUpdate()
                SaveConnectionsBG()
            End Sub

            Private Sub cMenTree_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles cMenTree.Opening
                AddExternalApps()
            End Sub

            Private Shared Sub cMenTreeToolsExternalAppsEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
                StartExternalApp(sender.Tag)
            End Sub

            Private Sub cMenTreeDuplicate_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeDuplicate.Click
                dRemote.Tree.Node.CloneNode(tvConnections.SelectedNode)
                SaveConnectionsBG()
            End Sub

            Private Shared Sub cMenTreeRename_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeRename.Click
                dRemote.Tree.Node.StartRenameSelectedNode()
                SaveConnectionsBG()
            End Sub

            Private Shared Sub cMenTreeDelete_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeDelete.Click
                dRemote.Tree.Node.DeleteSelectedNode()
                SaveConnectionsBG()
            End Sub

            Private Shared Sub cMenTreeImportFile_Click(sender As System.Object, e As EventArgs) Handles cMenTreeImportFile.Click
                Import.ImportFromFile(Windows.treeForm.tvConnections.Nodes(0), Windows.treeForm.tvConnections.SelectedNode, True)
            End Sub

            Private Shared Sub cMenTreeImportActiveDirectory_Click(sender As System.Object, e As EventArgs) Handles cMenTreeImportActiveDirectory.Click
                Windows.Show(Type.ActiveDirectoryImport)
            End Sub

            Private Shared Sub cMenTreeImportPortScan_Click(sender As System.Object, e As EventArgs) Handles cMenTreeImportPortScan.Click
                Windows.Show(UI.Window.Type.PortScan, True)
            End Sub

            Private Shared Sub cMenTreeExportFile_Click(sender As System.Object, e As EventArgs) Handles cMenTreeExportFile.Click
                Export.ExportToFile(Windows.treeForm.tvConnections.Nodes(0), Windows.treeForm.tvConnections.SelectedNode)
            End Sub
            Private Shared Sub cMenTreeMoveUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeMoveUp.Click
                dRemote.Tree.Node.MoveNodeUp()
                SaveConnectionsBG()
            End Sub

            Private Shared Sub cMenTreeMoveDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cMenTreeMoveDown.Click
                dRemote.Tree.Node.MoveNodeDown()
                SaveConnectionsBG()
            End Sub
#End Region

#Region "Context Menu Actions"
            Public Sub AddConnection()
                Try
                    If tvConnections.SelectedNode Is Nothing Then tvConnections.SelectedNode = tvConnections.Nodes.Item(0)

                    Dim newTreeNode As TreeNode = dRemote.Tree.Node.AddNode(dRemote.Tree.Node.Type.Connection)
                    If newTreeNode Is Nothing Then
                        MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "UI.Window.Tree.AddConnection() failed." & vbNewLine & "dRemote.Tree.Node.AddNode() returned Nothing.", True)
                        Return
                    End If

                    Dim containerNode As TreeNode = tvConnections.SelectedNode
                    If dRemote.Tree.Node.GetNodeType(containerNode) = dRemote.Tree.Node.Type.Connection Then
                        containerNode = containerNode.Parent
                    End If

                    Dim newConnectionInfo As New dRemote.Connection.Info()
                    If dRemote.Tree.Node.GetNodeType(containerNode) = dRemote.Tree.Node.Type.Root Then
                        newConnectionInfo.Inherit.TurnOffInheritanceCompletely()
                    Else
                        newConnectionInfo.Parent = containerNode.Tag
                        Dim defaultinherit As Boolean = My.Settings.Inherit
                        If defaultinherit Then
                            newConnectionInfo.Inherit.CacheBitmaps = defaultinherit
                            newConnectionInfo.Inherit.Colors = defaultinherit
                            newConnectionInfo.Inherit.Description = defaultinherit
                            newConnectionInfo.Inherit.DisplayThemes = defaultinherit
                            newConnectionInfo.Inherit.DisplayWallpaper = defaultinherit
                            newConnectionInfo.Inherit.EnableFontSmoothing = defaultinherit
                            newConnectionInfo.Inherit.EnableDesktopComposition = defaultinherit
                            newConnectionInfo.Inherit.Domain = defaultinherit
                            newConnectionInfo.Inherit.Icon = defaultinherit
                            newConnectionInfo.Inherit.Panel = defaultinherit
                            newConnectionInfo.Inherit.Password = defaultinherit
                            newConnectionInfo.Inherit.Port = defaultinherit
                            newConnectionInfo.Inherit.Protocol = defaultinherit
                            newConnectionInfo.Inherit.PuttySession = defaultinherit
                            newConnectionInfo.Inherit.RedirectDiskDrives = defaultinherit
                            newConnectionInfo.Inherit.RedirectKeys = defaultinherit
                            newConnectionInfo.Inherit.RedirectPorts = defaultinherit
                            newConnectionInfo.Inherit.RedirectPrinters = defaultinherit
                            newConnectionInfo.Inherit.RedirectSmartCards = defaultinherit
                            newConnectionInfo.Inherit.RedirectSound = defaultinherit
                            newConnectionInfo.Inherit.Resolution = defaultinherit
                            newConnectionInfo.Inherit.AutomaticResize = defaultinherit
                            newConnectionInfo.Inherit.UseConsoleSession = defaultinherit
                            newConnectionInfo.Inherit.UseCredSsp = defaultinherit
                            newConnectionInfo.Inherit.RenderingEngine = defaultinherit
                            newConnectionInfo.Inherit.Username = defaultinherit
                            'newConnectionInfo.Inherit.ICAEncryptionStrength = defaultinherit
                            newConnectionInfo.Inherit.ICAEncryption = defaultinherit
                            newConnectionInfo.Inherit.RDPAuthenticationLevel = defaultinherit
                            newConnectionInfo.Inherit.LoadBalanceInfo = defaultinherit
                            newConnectionInfo.Inherit.PreExtApp = defaultinherit
                            newConnectionInfo.Inherit.PostExtApp = defaultinherit
                            newConnectionInfo.Inherit.MacAddress = defaultinherit
                            newConnectionInfo.Inherit.UserField = defaultinherit
                            newConnectionInfo.Inherit.ExtApp = defaultinherit
                            newConnectionInfo.Inherit.VNCCompression = defaultinherit
                            newConnectionInfo.Inherit.VNCEncoding = defaultinherit
                            newConnectionInfo.Inherit.VNCAuthMode = defaultinherit
                            newConnectionInfo.Inherit.VNCProxyType = defaultinherit
                            newConnectionInfo.Inherit.VNCProxyIP = defaultinherit
                            newConnectionInfo.Inherit.VNCProxyPort = defaultinherit
                            newConnectionInfo.Inherit.VNCProxyUsername = defaultinherit
                            newConnectionInfo.Inherit.VNCProxyPassword = defaultinherit
                            newConnectionInfo.Inherit.VNCColors = defaultinherit
                            newConnectionInfo.Inherit.VNCSmartSizeMode = defaultinherit
                            newConnectionInfo.Inherit.VNCViewOnly = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayHostname = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayUseConnectionCredentials = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayUsername = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayPassword = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayDomain = defaultinherit
                            newConnectionInfo.Inherit.RDGatewayUsageMethod = defaultinherit
                        End If
                    End If

                    newConnectionInfo.TreeNode = newTreeNode
                    newTreeNode.Tag = newConnectionInfo
                    ConnectionList.Add(newConnectionInfo)

                    containerNode.Nodes.Add(newTreeNode)

                    tvConnections.SelectedNode = newTreeNode
                    tvConnections.SelectedNode.BeginEdit()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "UI.Window.Tree.AddConnection() failed." & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Public Sub AddFolder()
                Try
                    Dim newNode As TreeNode = dRemote.Tree.Node.AddNode(dRemote.Tree.Node.Type.Container)
                    Dim newContainerInfo As New Container.Info()
                    newNode.Tag = newContainerInfo
                    newContainerInfo.TreeNode = newNode

                    Dim selectedNode As TreeNode = dRemote.Tree.Node.SelectedNode
                    Dim parentNode As TreeNode
                    If selectedNode Is Nothing Then
                        parentNode = tvConnections.Nodes(0)
                    Else
                        If dRemote.Tree.Node.GetNodeType(selectedNode) = dRemote.Tree.Node.Type.Connection Then
                            parentNode = selectedNode.Parent
                        Else
                            parentNode = selectedNode
                        End If
                    End If

                    newContainerInfo.ConnectionInfo = New dRemote.Connection.Info(newContainerInfo)
                    newContainerInfo.ConnectionInfo.Name = newNode.Text

                    ' We can only inherit from a container node, not the root node or connection nodes
                    If dRemote.Tree.Node.GetNodeType(parentNode) = dRemote.Tree.Node.Type.Container Then
                        newContainerInfo.Parent = parentNode.Tag
                    Else
                        newContainerInfo.ConnectionInfo.Inherit.TurnOffInheritanceCompletely()
                    End If

                    ContainerList.Add(newContainerInfo)
                    parentNode.Nodes.Add(newNode)

                    tvConnections.SelectedNode = newNode
                    tvConnections.SelectedNode.BeginEdit()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, String.Format(Language.strErrorAddFolderFailed, ex.Message), True)
                End Try
            End Sub

            Private Sub DisconnectConnection()
                Try
                    If tvConnections.SelectedNode IsNot Nothing Then
                        If TypeOf tvConnections.SelectedNode.Tag Is dRemote.Connection.Info Then
                            Dim conI As dRemote.Connection.Info = tvConnections.SelectedNode.Tag
                            For i As Integer = 0 To conI.OpenConnections.Count - 1
                                conI.OpenConnections(i).Disconnect()
                            Next
                        End If

                        If TypeOf tvConnections.SelectedNode.Tag Is Container.Info Then
                            For Each n As TreeNode In tvConnections.SelectedNode.Nodes
                                If TypeOf n.Tag Is dRemote.Connection.Info Then
                                    Dim conI As dRemote.Connection.Info = n.Tag
                                    For i As Integer = 0 To conI.OpenConnections.Count - 1
                                        conI.OpenConnections(i).Disconnect()
                                    Next
                                End If
                            Next
                        End If
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "DisconnectConnection (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub SshTransferFile()
                Try
                    Windows.Show(Type.SSHTransfer)

                    Dim conI As dRemote.Connection.Info = dRemote.Tree.Node.SelectedNode.Tag

                    Windows.sshtransferForm.Hostname = conI.Hostname
                    Windows.sshtransferForm.Username = conI.Username
                    Windows.sshtransferForm.Password = conI.Password
                    Windows.sshtransferForm.Port = conI.Port
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "SSHTransferFile (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub AddExternalApps()
                Try
                    'clean up
                    cMenTreeToolsExternalApps.DropDownItems.Clear()

                    'add ext apps
                    For Each extA As Tools.ExternalTool In Runtime.ExternalTools
                        Dim nItem As New ToolStripMenuItem
                        nItem.Text = extA.DisplayName
                        nItem.Tag = extA

                        nItem.Image = extA.Image

                        AddHandler nItem.Click, AddressOf cMenTreeToolsExternalAppsEntry_Click

                        cMenTreeToolsExternalApps.DropDownItems.Add(nItem)
                    Next
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "cMenTreeTools_DropDownOpening failed (UI.Window.Tree)" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub StartExternalApp(ByVal externalTool As Tools.ExternalTool)
                Try
                    If dRemote.Tree.Node.GetNodeType(dRemote.Tree.Node.SelectedNode) = dRemote.Tree.Node.Type.Connection Or
                       dRemote.Tree.Node.GetNodeType(dRemote.Tree.Node.SelectedNode) = dRemote.Tree.Node.Type.PuttySession Then
                        externalTool.Start(dRemote.Tree.Node.SelectedNode.Tag)
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "cMenTreeToolsExternalAppsEntry_Click failed (UI.Window.Tree)" & vbNewLine & ex.Message, True)
                End Try
            End Sub
#End Region

#Region "Menu"
            Private Shared Sub mMenViewExpandAllFolders_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenViewExpandAllFolders.Click
                dRemote.Tree.Node.ExpandAllNodes()
            End Sub

            Private Sub mMenViewCollapseAllFolders_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenViewCollapseAllFolders.Click
                If tvConnections.SelectedNode IsNot Nothing Then
                    If tvConnections.SelectedNode.IsEditing Then tvConnections.SelectedNode.EndEdit(False)
                End If
                dRemote.Tree.Node.CollapseAllNodes()
            End Sub
#End Region

#Region "Search"
            Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.GotFocus
                txtSearch.ForeColor = Themes.ThemeManager.ActiveTheme.SearchBoxTextColor
                If txtSearch.Text = Language.strSearchPrompt Then
                    txtSearch.Text = ""
                End If
            End Sub

            Private Sub txtSearch_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.LostFocus
                If txtSearch.Text = "" Then
                    txtSearch.ForeColor = Themes.ThemeManager.ActiveTheme.SearchBoxTextPromptColor
                    txtSearch.Text = Language.strSearchPrompt
                End If
            End Sub

            Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSearch.KeyDown
                Try
                    If e.KeyCode = Keys.Escape Then
                        e.Handled = True
                        tvConnections.Focus()
                    ElseIf e.KeyCode = Keys.Up Then
                        tvConnections.SelectedNode = tvConnections.SelectedNode.PrevVisibleNode
                    ElseIf e.KeyCode = Keys.Down Then
                        tvConnections.SelectedNode = tvConnections.SelectedNode.NextVisibleNode
                    Else
                        tvConnections_KeyDown(sender, e)
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "txtSearch_KeyDown (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
                tvConnections.SelectedNode = dRemote.Tree.Node.Find(tvConnections.Nodes(0), txtSearch.Text)
            End Sub

            Private Sub tvConnections_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tvConnections.KeyPress
                Try
                    If Char.IsLetterOrDigit(e.KeyChar) Then
                        txtSearch.Text = e.KeyChar

                        txtSearch.Focus()
                        txtSearch.SelectionStart = txtSearch.TextLength
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_KeyPress (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Sub tvConnections_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tvConnections.KeyDown
                Try
                    If e.KeyCode = Keys.Enter Then
                        If TypeOf tvConnections.SelectedNode.Tag Is dRemote.Connection.Info Then
                            e.Handled = True
                            OpenConnection(tvConnections)
                        Else
                            If tvConnections.SelectedNode.IsExpanded Then
                                tvConnections.SelectedNode.Collapse(True)
                            Else
                                tvConnections.SelectedNode.Expand()
                            End If
                        End If
                    ElseIf e.KeyCode = Keys.Escape Xor e.KeyCode = Keys.Control Or e.KeyCode = Keys.F Then
                        txtSearch.Focus()
                        txtSearch.SelectionStart = txtSearch.TextLength
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "tvConnections_KeyDown (UI.Window.Tree) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Shared Sub mMenFileNew_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenFileNew.Click
                Dim saveFileDialog As SaveFileDialog = Tools.Controls.ConnectionsSaveAsDialog
                If Not saveFileDialog.ShowDialog() = DialogResult.OK Then Return

                NewConnections(saveFileDialog.FileName)
            End Sub

            Private Shared Sub mMenFileSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenFileSave.Click
                SaveConnections()
            End Sub

            Private Shared Sub mMenFileSaveAs_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mMenFileSaveAs.Click
                SaveConnectionsAs()
            End Sub


            Private Shared Sub mMenFileImportFromFile_Click(sender As System.Object, e As EventArgs) Handles mMenFileImportFromFile.Click
                Import.ImportFromFile(Windows.treeForm.tvConnections.Nodes(0), Windows.treeForm.tvConnections.SelectedNode)
            End Sub

            Private Shared Sub mMenFileImportFromActiveDirectory_Click(sender As System.Object, e As EventArgs) Handles mMenFileImportFromActiveDirectory.Click
                Windows.Show(UI.Window.Type.ActiveDirectoryImport)
            End Sub

            Private Shared Sub mMenFileImportFromPortScan_Click(sender As System.Object, e As EventArgs) Handles mMenFileImportFromPortScan.Click
                Windows.Show(UI.Window.Type.PortScan, True)
            End Sub

            Private Shared Sub mMenFileExport_Click(sender As System.Object, e As EventArgs) Handles mMenFileExport.Click
                Export.ExportToFile(Windows.treeForm.tvConnections.Nodes(0), Windows.treeForm.tvConnections.SelectedNode)
            End Sub


#End Region
        End Class
    End Namespace
End Namespace