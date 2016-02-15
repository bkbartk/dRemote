
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
        connections.Show(DockPanel1, DockState.DockLeftAutoHide)

        'Dim f2 As New Forms.Form2()
        'f2.Show(DockPanel1, DockState.DockLeft)
        'Dim f3 As New Forms.Form2()
        'f3.Show(DockPanel1, DockState.DockRight)
        'Dim f4 As New Forms.Form2()
        'f4.Show(DockPanel1, DockState.Document)

    End Sub

    Private Sub frmMainV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim menu As IActiveMenu = ActiveMenu.GetInstance(Me)
        Dim button As New ActiveButton()
        button.BackColor = Color.Transparent
        button.Text = "File"
        AddHandler button.Click, AddressOf button_Click
        menu.Items.Add(button)

        My.Settings.Beta = True

    End Sub

    Private Sub button_Click(sender As Object, e As EventArgs)

        Dim f2 As New Forms.Form2()
        f2.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub frmMainV2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Shutdown.Quit()
    End Sub
End Class