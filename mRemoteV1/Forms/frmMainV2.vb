
Imports TheCodeKing.ActiveButtons.Controls
Imports WeifenLuo.WinFormsUI.Docking

Imports System.IO
Imports dRemote.App
Imports dRemote.My
Imports SharedLibraryNG
Imports System.Text
Imports dRemote.App.Runtime
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Crownwood
Imports dRemote.App.Native
Imports PSTaskDialog
Imports dRemote.Config
Imports dRemote.Themes

Public Class frmMainV2
    Public Sub New()
        InitializeComponent()


        Windows.treeForm = New UI.Window.Tree()
        'connections.Show(DockPanel1, DockState.DockLeftAutoHide)
        Windows.treeForm.Show(DockPanel1, DockState.DockLeft)
        Windows.treeForm = Windows.treeForm


        Windows.configForm = New UI.Window.Config()
        'connections.Show(DockPanel1, DockState.DockLeftAutoHide)
        Windows.configForm.Show(DockPanel1)
        Windows.configForm.DockTo(Windows.treeForm.Pane, DockStyle.Bottom, 30)

        Windows.dockPanel = DockPanel1

    End Sub

    'Public Shared Sub CreatePanels()
    '    Windows.configForm = New UI.Window.Config(Windows.configPanel)
    '    Windows.configPanel = Windows.configForm

    '    Windows.treeForm = New UI.Window.Tree(Windows.treePanel)
    '    Windows.treePanel = Windows.treeForm
    '    Tree.Node.TreeView = Windows.treeForm.tvConnections

    '    Windows.errorsForm = New UI.Window.ErrorsAndInfos(Windows.errorsPanel)
    '    Windows.errorsPanel = Windows.errorsForm

    '    Windows.sessionsForm = New UI.Window.Sessions(Windows.sessionsPanel)
    '    Windows.sessionsPanel = Windows.sessionsForm

    '    Windows.screenshotForm = New UI.Window.ScreenshotManager(Windows.screenshotPanel)
    '    Windows.screenshotPanel = Windows.screenshotForm

    '    Windows.updateForm = New UI.Window.Update(Windows.updatePanel)
    '    Windows.updatePanel = Windows.updateForm

    '    Windows.AnnouncementForm = New UI.Window.Announcement(Windows.AnnouncementPanel)
    '    Windows.AnnouncementPanel = Windows.AnnouncementForm
    'End Sub


    Private Sub frmMainV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim menu As IActiveMenu = ActiveMenu.GetInstance(Me)


        Dim mnubutton As New ActiveButton()
        mnubutton.BackColor = Color.Transparent
        mnubutton.Text = "Menu"
        AddHandler mnubutton.Click, AddressOf mnubutton_MouseClick
        menu.Items.Add(mnubutton)

        Dim btnV1 As New ActiveButton()
        btnV1.BackColor = Color.Transparent
        btnV1.Text = "Back to dRemote V1"
        AddHandler btnV1.Click, AddressOf btnV1_Click
        menu.Items.Add(btnV1)

        Dim brows As New WebBrowser
        brows.Url = New Uri(App.Info.General.UrlStart)

        brows.ScrollBarsEnabled = False
        brows.Dock = Dock.Fill
        'SetBrowsResolution()
        DockPanel1.Controls.Add(brows)
        AddHandler brows.Navigating, AddressOf brows_Navigating


    End Sub

    Private Sub brows_Navigating(sender As Object, e As System.Windows.Forms.WebBrowserNavigatingEventArgs)
        Dim url As String = e.Url.ToString
        If e.TargetFrameName = "" And url <> "about:blank" Then
            Process.Start(url)
            e.Cancel = True
        End If
    End Sub

    Private Sub mnubutton_MouseClick(sender As ActiveButton, e As MouseEventArgs)

        mainMenu.Show(Me.Width - sender.Left - 200, 20)

    End Sub

    Private Sub btnV1_Click(sender As Object, e As EventArgs)

        'frmMain.Show()
        'Me.Hide()
        'My.Settings.Beta = False
        'Select Case MsgBox("Save Connection?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
        '    Case MsgBoxResult.Yes
        '        SaveConnections()
        '    Case MsgBoxResult.Cancel
        '        Return
        'End Select
        My.Settings.Beta = False
        System.Windows.Forms.Application.Restart()
        'Application.Exit()
        'Process.Start(Application.ExecutablePath)

    End Sub
    Private Sub frmMainV2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Select Case MsgBox("Save Connection?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
        '    Case MsgBoxResult.Yes
        '        SaveConnections()
        '    Case MsgBoxResult.Cancel
        '        Return
        'End Select
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub btnAmout_Click(sender As Object, e As EventArgs) Handles btnAmout.Click
        Dim frmAbout As New UI.Window.About
        frmAbout.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub mMenToolsOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMenToolsOptions.Click
        Using optionsForm As New Forms.OptionsForm()
            optionsForm.ShowDialog(Me)
        End Using
    End Sub
    Private Sub mMenToolsUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMenToolsUpdate.Click
        App.Runtime.Windows.Show(UI.Window.Type.Update)
    End Sub
End Class