Imports System.Security.Permissions
Imports System.Threading
Imports dRemote.App.Runtime

Namespace Connection
    Namespace Protocol
        Public Class Base
#Region "Properties"
#Region "Control"
            Private _Name As String
            Public Property Name() As String
                Get
                    Return Me._Name
                End Get
                Set(ByVal value As String)
                    Me._Name = value
                End Set
            End Property

            Private WithEvents _connectionWindow As UI.Window.Connection
            Public Property ConnectionWindow As UI.Window.Connection
                Get
                    Return _connectionWindow
                End Get
                Set(value As UI.Window.Connection)
                    _connectionWindow = value
                End Set
            End Property

            Private _interfaceControl As InterfaceControl
            Public Property InterfaceControl() As InterfaceControl
                Get
                    Return _interfaceControl
                End Get
                Set(ByVal value As InterfaceControl)
                    _interfaceControl = value
                    ConnectionWindow = TryCast(_interfaceControl.GetContainerControl(), UI.Window.Connection)
                End Set
            End Property

            Private _Control As Control
            Public Property Control() As Control
                Get
                    Return Me._Control
                End Get
                Set(ByVal value As Control)
                    Me._Control = value
                End Set
            End Property
            'Private _resizestarted As Boolean
            'Public Property resizestarted() As Boolean
            '    Get
            '        Return Me._resizestarted
            '    End Get
            '    Set(ByVal value As Boolean)
            '        Me._resizestarted = value
            '    End Set
            'End Property
#End Region

            Private _Force As dRemote.Connection.Info.Force
            Public Property Force() As dRemote.Connection.Info.Force
                Get
                    Return Me._Force
                End Get
                Set(ByVal value As dRemote.Connection.Info.Force)
                    Me._Force = value
                End Set
            End Property

            Public WithEvents tmrReconnect As New Timers.Timer(2000)
            Public WithEvents ReconnectGroup As ReconnectGroup
#End Region

#Region "Methods"
            Public Overridable Sub Focus()
                Try
                    Me._Control.Focus()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "Couldn't focus Control (Connection.Protocol.Base)" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Public resizeStarted As Boolean = False

            Public WithEvents resizeTimer As New Timers.Timer(500)


            Public Overridable Sub ResizeV2(ByVal sender As System.Object, ByVal e As EventArgs)
                resizeTimer.AutoReset = False
                If Not resizeStarted Then
                    Me.ResizeBegin(sender, e)
                    resizeStarted = True
                End If

                resizeTimer.Stop()
                resizeTimer.Start()
            End Sub

            Public Overridable Sub ResizeEnd_elapsed(ByVal sender As System.Object, ByVal e As EventArgs) Handles resizeTimer.Elapsed
                If resizeStarted And Not System.Windows.Forms.MouseButtons.Left Then
                    Me.ResizeEnd(sender, e)
                    resizeStarted = False
                ElseIf resizeStarted Then
                    resizeTimer.Start()
                End If
            End Sub

            Public Overridable Sub ResizeBegin(ByVal sender As System.Object, ByVal e As EventArgs) Handles _connectionWindow.ResizeBegin

            End Sub

            Public Overridable Sub Resize(ByVal sender As System.Object, ByVal e As EventArgs) Handles _connectionWindow.Resize

            End Sub

            Public Overridable Sub ResizeEnd(ByVal sender As System.Object, ByVal e As EventArgs) Handles _connectionWindow.ResizeEnd

            End Sub

            Public Overridable Function SetProps() As Boolean
                Try
                    Me._interfaceControl.Parent.Tag = Me._interfaceControl
                    Me._interfaceControl.Show()

                    If Me._Control IsNot Nothing Then
                        Me._Control.Name = Me._Name
                        Me._Control.Parent = Me._interfaceControl
                        Me._Control.Location = Me._interfaceControl.Location
                        Me._Control.Size = Me.InterfaceControl.Size
                        Me._Control.Anchor = Me._interfaceControl.Anchor
                    End If

                    Return True
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "Couldn't SetProps (Connection.Protocol.Base)" & vbNewLine & ex.Message, True)
                    Return False
                End Try
            End Function

            Public Overridable Function Connect() As Boolean
                'If InterfaceControl.Info.Protocol <> Protocols.RDP Then
                RaiseEvent Connected(Me)
                'End If
            End Function

            Public Overridable Sub Disconnect()
                Me.Close()
            End Sub

            Public Overridable Sub Close()
                Dim t As New Thread(AddressOf CloseBG)
                t.SetApartmentState(Threading.ApartmentState.STA)
                t.IsBackground = True
                t.Start()
            End Sub

            Private Sub CloseBG()
                If Not IsNothing(Control) AndAlso Control.InvokeRequired Then
                    Control.Invoke(New Action(AddressOf CloseBG))
                    Return
                End If
                RaiseEvent Closed(Me)

                Try
                    tmrReconnect.Enabled = False

                    If Me._Control IsNot Nothing Then
                        Try
                            Me.DisposeControl()
                        Catch ex As Exception
                            MessageCollector.AddMessage(Messages.MessageClass.WarningMsg, "Could not dispose control, probably form is already closed (Connection.Protocol.Base)" & vbNewLine & ex.Message, True)
                        End Try
                    End If

                    If Me._interfaceControl IsNot Nothing Then
                        'Try
                        If Me._interfaceControl.Parent IsNot Nothing Then
                            If My.Settings.Beta And Me._interfaceControl.Parent.[GetType]().ToString() = "dRemote.Forms.frmConnections" Then

                                Dim parent As Form = CType(Me._interfaceControl.Parent, Form)
                                If Me._interfaceControl.Parent.Tag IsNot Nothing Then
                                    Me.SetTagToNothing()
                                End If
                                Me.DisposeInterface()
                                parent.Close()

                            Else
                                If Me._interfaceControl.Parent.Tag IsNot Nothing Then
                                    Me.SetTagToNothing()
                                End If
                                Me.DisposeInterface()
                            End If

                        End If
                        'Catch ex As Exception
                        '    MessageCollector.AddMessage(Messages.MessageClass.WarningMsg, "Could not set InterfaceControl.Parent.Tag or Dispose Interface, probably form is already closed (Connection.Protocol.Base)" & vbNewLine & ex.Message, True)
                        'End Try
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "Couldn't Close InterfaceControl BG (Connection.Protocol.Base)" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Private Delegate Sub DisposeInterfaceCB()
            Private Sub DisposeInterface()
                If Me._interfaceControl.InvokeRequired Then
                    Dim s As New DisposeInterfaceCB(AddressOf DisposeInterface)
                    Me._interfaceControl.Invoke(s)
                Else
                    Me._interfaceControl.Dispose()
                End If
            End Sub

            Private Delegate Sub SetTagToNothingCB()
            Private Sub SetTagToNothing()
                If Me._interfaceControl.Parent.InvokeRequired Then
                    Dim s As New SetTagToNothingCB(AddressOf SetTagToNothing)
                    Me._interfaceControl.Parent.Invoke(s)
                Else
                    Me._interfaceControl.Parent.Tag = Nothing
                End If
            End Sub

            Private Delegate Sub DisposeControlCB()
            Private Sub DisposeControl()
                If Me._Control.InvokeRequired Then
                    Dim s As New DisposeControlCB(AddressOf DisposeControl)
                    Me._Control.Invoke(s)
                Else
                    Me._Control.Dispose()
                End If
            End Sub
#End Region

#Region "Events"
            Public Event Connecting(ByVal sender As Object)
            Public Event Connected(ByVal sender As Object)
            Public Event Disconnected(ByVal sender As Object, ByVal DisconnectedMessage As String)
            Public Event ErrorOccured(ByVal sender As Object, ByVal ErrorMessage As String)
            Public Event Closing(ByVal sender As Object)
            Public Event Closed(ByVal sender As Object)

            Public Sub Event_Closing(ByVal sender As Object)
                RaiseEvent Closing(sender)
            End Sub

            Public Sub Event_Closed(ByVal sender As Object)
                RaiseEvent Closed(sender)
            End Sub

            Public Sub Event_Connecting(ByVal sender As Object)
                RaiseEvent Connecting(sender)
            End Sub

            Public Sub Event_Connected(ByVal sender As Object)
                RaiseEvent Connected(sender)
            End Sub

            Public Sub Event_Disconnected(ByVal sender As Object, ByVal DisconnectedMessage As String)
                RaiseEvent Disconnected(sender, DisconnectedMessage)
            End Sub

            Public Sub Event_ErrorOccured(ByVal sender As Object, ByVal ErrorMsg As String)
                RaiseEvent ErrorOccured(sender, ErrorMsg)
            End Sub

            Public Sub Event_ReconnectGroupCloseClicked() Handles ReconnectGroup.CloseClicked
                Close()
            End Sub
#End Region
#Region "Tab Actions"
            Sub cmenTabScreenshot(ByVal sender As System.Object, ByVal e As System.EventArgs)
                Dim cmenTab As ContextMenuStrip = sender.Parent
                Dim conForm As Form = cmenTab.Parent
                cmenTab.Close()
                Application.DoEvents()
                Windows.screenshotForm.AddScreenshot(Tools.Misc.TakeScreenshot(conForm))
            End Sub
            Sub ToggleSmartSize(Sender As Object, e As EventArgs)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.RDP Then
                        Dim rdp As dRemote.Connection.Protocol.RDP = IC.Protocol
                        rdp.ToggleSmartSize()
                    ElseIf TypeOf IC.Protocol Is dRemote.Connection.Protocol.VNC Then
                        Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                        vnc.ToggleSmartSize()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "ToggleSmartSize (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub TransferFile(Sender As Object, e As EventArgs)
                Try

                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If IC.Info.Protocol = dRemote.Connection.Protocol.Protocols.SSH1 Or IC.Info.Protocol = dRemote.Connection.Protocol.Protocols.SSH2 Then
                        SSHTransferFile()
                    ElseIf IC.Info.Protocol = dRemote.Connection.Protocol.Protocols.VNC Then
                        VNCTransferFile()
                    End If

                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "TransferFile (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub SSHTransferFile()
                Try

                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    Windows.Show(UI.Window.Type.SSHTransfer)

                    Dim conI As dRemote.Connection.Info = IC.Info

                    Windows.sshtransferForm.Hostname = conI.Hostname
                    Windows.sshtransferForm.Username = conI.Username
                    Windows.sshtransferForm.Password = conI.Password
                    Windows.sshtransferForm.Port = conI.Port
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "SSHTransferFile (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub VNCTransferFile()
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl
                    Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                    vnc.StartFileTransfer()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "VNCTransferFile (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub ToggleViewOnly(Sender As Object, e As EventArgs)
                Try

                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.VNC Then
                        Sender.Checked = Not Sender.Checked

                        Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                        vnc.ToggleViewOnly()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "ToggleViewOnly (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub StartChat(Sender As Object, e As EventArgs)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.VNC Then
                        Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                        vnc.StartChat()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "StartChat (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub RefreshScreen(Sender As Object, e As EventArgs)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.VNC Then
                        Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                        vnc.RefreshScreen()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "RefreshScreen (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub cmenTabSendSpecialKeysCtrlAltDel(ByVal sender As System.Object, ByVal e As System.EventArgs)
                Me.SendSpecialKeys(dRemote.Connection.Protocol.VNC.SpecialKeys.CtrlAltDel)
            End Sub

            Sub cmenTabSendSpecialKeysCtrlEsc(ByVal sender As System.Object, ByVal e As System.EventArgs)
                Me.SendSpecialKeys(dRemote.Connection.Protocol.VNC.SpecialKeys.CtrlEsc)

            End Sub
            Sub SendSpecialKeys(ByVal Keys As dRemote.Connection.Protocol.VNC.SpecialKeys)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.VNC Then
                        Dim vnc As dRemote.Connection.Protocol.VNC = IC.Protocol
                        vnc.SendSpecialKeys(Keys)
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "SendSpecialKeys (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub ToggleFullscreen(Sender As Object, e As EventArgs)
                Try

                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf IC.Protocol Is dRemote.Connection.Protocol.RDP Then
                        Dim rdp As dRemote.Connection.Protocol.RDP = IC.Protocol
                        rdp.ToggleFullscreen()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "ToggleFullscreen (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub ShowPuttySettingsDialog(Sender As Object, e As EventArgs)
                Try
                    Dim objInterfaceControl As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    If TypeOf objInterfaceControl.Protocol Is dRemote.Connection.Protocol.PuttyBase Then
                        Dim objPuttyBase As dRemote.Connection.Protocol.PuttyBase = objInterfaceControl.Protocol

                        objPuttyBase.ShowSettingsDialog()
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "ShowPuttySettingsDialog (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub StartExternalApp(ByVal Sender As Object, ByVal e As System.EventArgs)
                Try
                    Dim extA As Tools.ExternalTool = Sender.Tag
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    extA.Start(IC.Info)
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "cmenTabExternalAppsEntry_Click failed (UI.Window.Tree)" & vbNewLine & ex.Message, True)
                End Try
            End Sub

            Sub CloseTabMenu(Sender As Object, e As EventArgs)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    IC.Protocol.Close()
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "CloseTabMenu (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub
            Sub RenameTab(Sender As ToolStripMenuItem, e As EventArgs)
                Try
                    Dim tab As Form = Me.InterfaceControl.Parent
                    Dim nTitle As String = InputBox(My.Language.strNewTitle & ":", , tab.Text.Replace("&&", "&"))

                    If nTitle <> "" Then
                        tab.Text = nTitle.Replace("&", "&&")
                    End If
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "RenameTab (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub


            Overridable Sub Reconnect(Sender As Object, e As EventArgs)
                Try
                    Dim IC As dRemote.Connection.InterfaceControl = Me.InterfaceControl

                    IC.Protocol.Close()
                    IC.Protocol.Resize(Sender, e)
                    IC.Protocol.Connect()

                    'IC.Protocol.Disconnect()
                    'IC.Protocol.Connect()

                    'App.Runtime.OpenConnectionV2(Nothing, Me.InterfaceControl)
                Catch ex As Exception
                    MessageCollector.AddMessage(Messages.MessageClass.ErrorMsg, "Reconnect (UI.Window.Connections) failed" & vbNewLine & ex.Message, True)
                End Try
            End Sub
#End Region

        End Class
    End Namespace
End Namespace