<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MiningProcess = New System.Diagnostics.Process()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tabStatus = New System.Windows.Forms.TabPage()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.lblStarglancer = New System.Windows.Forms.Label()
        Me.lblBy = New System.Windows.Forms.Label()
        Me.lblNoncerProGUI = New System.Windows.Forms.Label()
        Me.pbxStatus = New System.Windows.Forms.PictureBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tabOutput = New System.Windows.Forms.TabPage()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.gbxNoncerPro = New System.Windows.Forms.GroupBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.timCheckStatus = New System.Windows.Forms.Timer(Me.components)
        Me.timProcessOutput = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecutableDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl.SuspendLayout()
        Me.tabStatus.SuspendLayout()
        CType(Me.pbxStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOutput.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.gbxNoncerPro.SuspendLayout()
        Me.NotifyIconMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MiningProcess
        '
        Me.MiningProcess.StartInfo.Domain = ""
        Me.MiningProcess.StartInfo.LoadUserProfile = False
        Me.MiningProcess.StartInfo.Password = Nothing
        Me.MiningProcess.StartInfo.StandardErrorEncoding = Nothing
        Me.MiningProcess.StartInfo.StandardOutputEncoding = Nothing
        Me.MiningProcess.StartInfo.UserName = ""
        Me.MiningProcess.SynchronizingObject = Me
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.tabStatus)
        Me.TabControl.Controls.Add(Me.tabOutput)
        Me.TabControl.Controls.Add(Me.tabSettings)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(800, 450)
        Me.TabControl.TabIndex = 0
        '
        'tabStatus
        '
        Me.tabStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tabStatus.Controls.Add(Me.btnDownload)
        Me.tabStatus.Controls.Add(Me.lblStarglancer)
        Me.tabStatus.Controls.Add(Me.lblBy)
        Me.tabStatus.Controls.Add(Me.lblNoncerProGUI)
        Me.tabStatus.Controls.Add(Me.pbxStatus)
        Me.tabStatus.Controls.Add(Me.btnStop)
        Me.tabStatus.Controls.Add(Me.btnStart)
        Me.tabStatus.Location = New System.Drawing.Point(4, 22)
        Me.tabStatus.Name = "tabStatus"
        Me.tabStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStatus.Size = New System.Drawing.Size(792, 424)
        Me.tabStatus.TabIndex = 0
        Me.tabStatus.Text = "Status"
        Me.tabStatus.UseVisualStyleBackColor = True
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(454, 335)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(153, 23)
        Me.btnDownload.TabIndex = 6
        Me.btnDownload.Text = "Download Noncer Pro"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'lblStarglancer
        '
        Me.lblStarglancer.AutoSize = True
        Me.lblStarglancer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStarglancer.Location = New System.Drawing.Point(472, 226)
        Me.lblStarglancer.Name = "lblStarglancer"
        Me.lblStarglancer.Size = New System.Drawing.Size(122, 25)
        Me.lblStarglancer.TabIndex = 5
        Me.lblStarglancer.Text = "Starglancer"
        '
        'lblBy
        '
        Me.lblBy.AutoSize = True
        Me.lblBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBy.Location = New System.Drawing.Point(520, 173)
        Me.lblBy.Name = "lblBy"
        Me.lblBy.Size = New System.Drawing.Size(27, 20)
        Me.lblBy.TabIndex = 4
        Me.lblBy.Text = "By"
        '
        'lblNoncerProGUI
        '
        Me.lblNoncerProGUI.AutoSize = True
        Me.lblNoncerProGUI.Font = New System.Drawing.Font("Chatelaine Pro", 47.99999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoncerProGUI.Location = New System.Drawing.Point(329, 64)
        Me.lblNoncerProGUI.Name = "lblNoncerProGUI"
        Me.lblNoncerProGUI.Size = New System.Drawing.Size(437, 76)
        Me.lblNoncerProGUI.TabIndex = 3
        Me.lblNoncerProGUI.Text = "Noncer Pro GUI"
        '
        'pbxStatus
        '
        Me.pbxStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbxStatus.Image = Global.NoncerProGUI.My.Resources.Resources.MiningAmber
        Me.pbxStatus.Location = New System.Drawing.Point(34, 32)
        Me.pbxStatus.Name = "pbxStatus"
        Me.pbxStatus.Size = New System.Drawing.Size(265, 252)
        Me.pbxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxStatus.TabIndex = 2
        Me.pbxStatus.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(123, 365)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop Miner"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(123, 303)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start Miner"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tabOutput
        '
        Me.tabOutput.Controls.Add(Me.txtOutput)
        Me.tabOutput.Location = New System.Drawing.Point(4, 22)
        Me.tabOutput.Name = "tabOutput"
        Me.tabOutput.Size = New System.Drawing.Size(792, 424)
        Me.tabOutput.TabIndex = 1
        Me.tabOutput.Text = "Output"
        Me.tabOutput.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.White
        Me.txtOutput.ForeColor = System.Drawing.Color.Black
        Me.txtOutput.Location = New System.Drawing.Point(11, 9)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(769, 405)
        Me.txtOutput.TabIndex = 0
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.gbxNoncerPro)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Size = New System.Drawing.Size(792, 424)
        Me.tabSettings.TabIndex = 2
        Me.tabSettings.Text = "GUI Settings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'gbxNoncerPro
        '
        Me.gbxNoncerPro.Controls.Add(Me.btnLocation)
        Me.gbxNoncerPro.Controls.Add(Me.txtLocation)
        Me.gbxNoncerPro.Controls.Add(Me.lblLocation)
        Me.gbxNoncerPro.Location = New System.Drawing.Point(15, 14)
        Me.gbxNoncerPro.Name = "gbxNoncerPro"
        Me.gbxNoncerPro.Size = New System.Drawing.Size(763, 64)
        Me.gbxNoncerPro.TabIndex = 0
        Me.gbxNoncerPro.TabStop = False
        Me.gbxNoncerPro.Text = "Noncer Pro"
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(696, 28)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(26, 20)
        Me.btnLocation.TabIndex = 2
        Me.btnLocation.Text = "..."
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(141, 28)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(557, 20)
        Me.txtLocation.TabIndex = 1
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(30, 31)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(105, 13)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "Noncer Pro Location"
        '
        'timCheckStatus
        '
        Me.timCheckStatus.Interval = 1000
        '
        'timProcessOutput
        '
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.NotifyIconMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Visible = True
        '
        'NotifyIconMenu
        '
        Me.NotifyIconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExit})
        Me.NotifyIconMenu.Name = "NotifyIconMenu"
        Me.NotifyIconMenu.Size = New System.Drawing.Size(94, 26)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(93, 22)
        Me.mnuExit.Text = "Exit"
        '
        'ExecutableDialog
        '
        Me.ExecutableDialog.Title = "Specify NoncerPro Location"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Noncer Pro GUI"
        Me.TabControl.ResumeLayout(False)
        Me.tabStatus.ResumeLayout(False)
        Me.tabStatus.PerformLayout()
        CType(Me.pbxStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOutput.ResumeLayout(False)
        Me.tabOutput.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.gbxNoncerPro.ResumeLayout(False)
        Me.gbxNoncerPro.PerformLayout()
        Me.NotifyIconMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MiningProcess As Process
    Friend WithEvents TabControl As TabControl
    Friend WithEvents tabStatus As TabPage
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents pbxStatus As PictureBox
    Friend WithEvents btnDownload As Button
    Friend WithEvents lblStarglancer As Label
    Friend WithEvents lblBy As Label
    Friend WithEvents lblNoncerProGUI As Label
    Friend WithEvents timCheckStatus As Timer
    Friend WithEvents tabOutput As TabPage
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents timProcessOutput As Timer
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents NotifyIconMenu As ContextMenuStrip
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents gbxNoncerPro As GroupBox
    Friend WithEvents btnLocation As Button
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents ExecutableDialog As OpenFileDialog
End Class
