
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

        Dim connections As New UI.Window.Tree()
        'connections.Show(DockPanel1, DockState.DockLeftAutoHide)
        connections.Show(DockPanel1, DockState.DockLeft)

        Dim cfg As New UI.Window.Config()
        Windows.configForm = cfg
        'connections.Show(DockPanel1, DockState.DockLeftAutoHide)
        cfg.Show(DockPanel1)
        cfg.DockTo(connections.Pane, DockStyle.Bottom, 30)

        'Windows.treePanel.Show(frmMain.pnlDock, DockState.DockLeft)
        'Windows.configPanel.Show(frmMain.pnlDock)
        'Windows.configPanel.DockTo(Windows.treePanel.Pane, DockStyle.Bottom, -1)

        'Dim f2 As New Forms.Form2()
        'f2.Show(DockPanel1, DockState.DockLeft)
        'Dim f3 As New Forms.Form2()
        'f3.Show(DockPanel1, DockState.DockRight)
        'Dim f4 As New Forms.Form2()
        'f4.Show(DockPanel1, DockState.Document)

    End Sub

    Private Sub frmMainV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim menu As IActiveMenu = ActiveMenu.GetInstance(Me)


        Dim mnubutton As New ActiveButton()
        mnubutton.BackColor = Color.Transparent
        mnubutton.Text = "Menu"
        AddHandler mnubutton.Click, AddressOf mnubutton_Click
        menu.Items.Add(mnubutton)

        Dim btnV1 As New ActiveButton()
        btnV1.BackColor = Color.Transparent
        btnV1.Text = "Back to dRemote V1"
        AddHandler btnV1.Click, AddressOf btnV1_Click
        menu.Items.Add(btnV1)



    End Sub

    Private Sub mnubutton_Click(sender As Object, e As EventArgs)

        MessageBox.Show("Menu is not done yes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Dim f2 As New Forms.Form2()
        'f2.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub btnV1_Click(sender As Object, e As EventArgs)

        'frmMain.Show()
        'Me.Hide()
        'My.Settings.Beta = False
        Select Case MsgBox("Save Connection?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
            Case MsgBoxResult.Yes
                SaveConnections()
            Case MsgBoxResult.Cancel
                Return
        End Select
        System.Windows.Forms.Application.Restart()
        'Application.Exit()
        'Process.Start(Application.ExecutablePath)

    End Sub
    Private Sub frmMainV2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Select Case MsgBox("Save Connection?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
            Case MsgBoxResult.Yes
                SaveConnections()
            Case MsgBoxResult.Cancel
                Return
        End Select
        Shutdown.Quit()
    End Sub


End Class