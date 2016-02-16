
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
        mnubutton.Text = "File"
        AddHandler mnubutton.Click, AddressOf mnubutton_Click
        menu.Items.Add(mnubutton)

        Dim btnV1 As New ActiveButton()
        btnV1.BackColor = Color.Transparent
        btnV1.Text = "Back to dRemote V1"
        AddHandler btnV1.Click, AddressOf btnV1_Click
        menu.Items.Add(btnV1)



    End Sub

    Private Sub mnubutton_Click(sender As Object, e As EventArgs)

        Dim f2 As New Forms.Form2()
        f2.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub btnV1_Click(sender As Object, e As EventArgs)

        frmMain.Show()
        Me.Hide()
        My.Settings.Beta = False
    End Sub
    Private Sub frmMainV2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Shutdown.Quit()
    End Sub

    Private Sub DockPanel1_ActiveContentChanged(sender As Object, e As EventArgs) Handles DockPanel1.ActiveContentChanged

    End Sub
End Class