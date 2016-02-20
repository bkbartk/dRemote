Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionsForm
        Inherits Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
            Me.PagePanel = New System.Windows.Forms.Panel()
            Me.OkButton = New System.Windows.Forms.Button()
            Me.CancelButtonControl = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'PagePanel
            '
            resources.ApplyResources(Me.PagePanel, "PagePanel")
            Me.PagePanel.Name = "PagePanel"
            '
            'OkButton
            '
            resources.ApplyResources(Me.OkButton, "OkButton")
            Me.OkButton.Name = "OkButton"
            Me.OkButton.UseVisualStyleBackColor = True
            '
            'CancelButtonControl
            '
            Me.CancelButtonControl.DialogResult = System.Windows.Forms.DialogResult.Cancel
            resources.ApplyResources(Me.CancelButtonControl, "CancelButtonControl")
            Me.CancelButtonControl.Name = "CancelButtonControl"
            Me.CancelButtonControl.UseVisualStyleBackColor = True
            '
            'OptionsForm
            '
            Me.AcceptButton = Me.OkButton
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.CancelButtonControl
            Me.Controls.Add(Me.CancelButtonControl)
            Me.Controls.Add(Me.OkButton)
            Me.Controls.Add(Me.PagePanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "OptionsForm"
            Me.ShowInTaskbar = False
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PageListView As dRemote.Controls.ListView
        Friend WithEvents PagePanel As System.Windows.Forms.Panel
        Friend WithEvents OkButton As System.Windows.Forms.Button
        Friend WithEvents CancelButtonControl As System.Windows.Forms.Button
    End Class
End Namespace