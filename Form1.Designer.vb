<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
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
        Me.tabStatistics = New System.Windows.Forms.TabPage()
        Me.chtBalance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chtHashRate = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.txtConfirmedPoolBalance = New System.Windows.Forms.TextBox()
        Me.lblConfirmedPoolBalance = New System.Windows.Forms.Label()
        Me.txtPoolBalance = New System.Windows.Forms.TextBox()
        Me.lblPoolBalance = New System.Windows.Forms.Label()
        Me.txtHashrate = New System.Windows.Forms.TextBox()
        Me.lblHashRate = New System.Windows.Forms.Label()
        Me.txtDifficulty = New System.Windows.Forms.TextBox()
        Me.lblDifficulty = New System.Windows.Forms.Label()
        Me.txtBlockHeight = New System.Windows.Forms.TextBox()
        Me.lblBlockHeight = New System.Windows.Forms.Label()
        Me.tabOutput = New System.Windows.Forms.TabPage()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.tabConfig = New System.Windows.Forms.TabPage()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.btnConfigCancel = New System.Windows.Forms.Button()
        Me.btnConfigSave = New System.Windows.Forms.Button()
        Me.chkConfigAutoOptimise = New System.Windows.Forms.CheckBox()
        Me.chkConfigOptimizer = New System.Windows.Forms.CheckBox()
        Me.chkConfigAPI = New System.Windows.Forms.CheckBox()
        Me.txtConfigDevices = New System.Windows.Forms.TextBox()
        Me.lblConfigDevices = New System.Windows.Forms.Label()
        Me.txtConfigThreads = New System.Windows.Forms.TextBox()
        Me.lblConfigThreads = New System.Windows.Forms.Label()
        Me.txtConfigBatchsize = New System.Windows.Forms.TextBox()
        Me.lblConfigBatchsize = New System.Windows.Forms.Label()
        Me.lblConfigAPI = New System.Windows.Forms.Label()
        Me.txtConfigAPIport = New System.Windows.Forms.TextBox()
        Me.lblAPIPort = New System.Windows.Forms.Label()
        Me.lblConfigOptimizer = New System.Windows.Forms.Label()
        Me.txtConfigDifficulty = New System.Windows.Forms.TextBox()
        Me.lblConfigDifficulty = New System.Windows.Forms.Label()
        Me.lblConfigAutooptimise = New System.Windows.Forms.Label()
        Me.txtConfigPort = New System.Windows.Forms.TextBox()
        Me.lblConfigPort = New System.Windows.Forms.Label()
        Me.txtConfigServer = New System.Windows.Forms.TextBox()
        Me.lblConfigServer = New System.Windows.Forms.Label()
        Me.txtConfigName = New System.Windows.Forms.TextBox()
        Me.lblConfigName = New System.Windows.Forms.Label()
        Me.txtConfigAddress = New System.Windows.Forms.TextBox()
        Me.lblConfigAddress = New System.Windows.Forms.Label()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.gbxErrorLog = New System.Windows.Forms.GroupBox()
        Me.btnClearLog = New System.Windows.Forms.Button()
        Me.txtError = New System.Windows.Forms.TextBox()
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
        Me.timUpdateChart = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl.SuspendLayout()
        Me.tabStatus.SuspendLayout()
        CType(Me.pbxStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabStatistics.SuspendLayout()
        CType(Me.chtBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtHashRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOutput.SuspendLayout()
        Me.tabConfig.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.gbxErrorLog.SuspendLayout()
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
        Me.TabControl.Controls.Add(Me.tabStatistics)
        Me.TabControl.Controls.Add(Me.tabOutput)
        Me.TabControl.Controls.Add(Me.tabConfig)
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
        Me.tabStatus.BackColor = System.Drawing.Color.Transparent
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
        'tabStatistics
        '
        Me.tabStatistics.BackColor = System.Drawing.Color.Transparent
        Me.tabStatistics.Controls.Add(Me.chtBalance)
        Me.tabStatistics.Controls.Add(Me.chtHashRate)
        Me.tabStatistics.Controls.Add(Me.txtConfirmedPoolBalance)
        Me.tabStatistics.Controls.Add(Me.lblConfirmedPoolBalance)
        Me.tabStatistics.Controls.Add(Me.txtPoolBalance)
        Me.tabStatistics.Controls.Add(Me.lblPoolBalance)
        Me.tabStatistics.Controls.Add(Me.txtHashrate)
        Me.tabStatistics.Controls.Add(Me.lblHashRate)
        Me.tabStatistics.Controls.Add(Me.txtDifficulty)
        Me.tabStatistics.Controls.Add(Me.lblDifficulty)
        Me.tabStatistics.Controls.Add(Me.txtBlockHeight)
        Me.tabStatistics.Controls.Add(Me.lblBlockHeight)
        Me.tabStatistics.Location = New System.Drawing.Point(4, 22)
        Me.tabStatistics.Name = "tabStatistics"
        Me.tabStatistics.Size = New System.Drawing.Size(792, 424)
        Me.tabStatistics.TabIndex = 3
        Me.tabStatistics.Text = "Statistics"
        '
        'chtBalance
        '
        Me.chtBalance.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.chtBalance.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chtBalance.Legends.Add(Legend1)
        Me.chtBalance.Location = New System.Drawing.Point(0, 242)
        Me.chtBalance.Name = "chtBalance"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chtBalance.Series.Add(Series1)
        Me.chtBalance.Size = New System.Drawing.Size(792, 179)
        Me.chtBalance.TabIndex = 11
        Me.chtBalance.Text = "Chart2"
        '
        'chtHashRate
        '
        Me.chtHashRate.BackColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.chtHashRate.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chtHashRate.Legends.Add(Legend2)
        Me.chtHashRate.Location = New System.Drawing.Point(0, 60)
        Me.chtHashRate.Name = "chtHashRate"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chtHashRate.Series.Add(Series2)
        Me.chtHashRate.Size = New System.Drawing.Size(792, 185)
        Me.chtHashRate.TabIndex = 10
        Me.chtHashRate.Text = "Chart1"
        '
        'txtConfirmedPoolBalance
        '
        Me.txtConfirmedPoolBalance.BackColor = System.Drawing.Color.White
        Me.txtConfirmedPoolBalance.Location = New System.Drawing.Point(412, 34)
        Me.txtConfirmedPoolBalance.Name = "txtConfirmedPoolBalance"
        Me.txtConfirmedPoolBalance.ReadOnly = True
        Me.txtConfirmedPoolBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtConfirmedPoolBalance.TabIndex = 9
        Me.txtConfirmedPoolBalance.Text = "0"
        Me.txtConfirmedPoolBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfirmedPoolBalance
        '
        Me.lblConfirmedPoolBalance.Location = New System.Drawing.Point(248, 37)
        Me.lblConfirmedPoolBalance.Name = "lblConfirmedPoolBalance"
        Me.lblConfirmedPoolBalance.Size = New System.Drawing.Size(158, 13)
        Me.lblConfirmedPoolBalance.TabIndex = 8
        Me.lblConfirmedPoolBalance.Text = "Confirmed Pool Balance"
        Me.lblConfirmedPoolBalance.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPoolBalance
        '
        Me.txtPoolBalance.BackColor = System.Drawing.Color.White
        Me.txtPoolBalance.Location = New System.Drawing.Point(129, 34)
        Me.txtPoolBalance.Name = "txtPoolBalance"
        Me.txtPoolBalance.ReadOnly = True
        Me.txtPoolBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtPoolBalance.TabIndex = 7
        Me.txtPoolBalance.Text = "0"
        Me.txtPoolBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPoolBalance
        '
        Me.lblPoolBalance.Location = New System.Drawing.Point(4, 37)
        Me.lblPoolBalance.Name = "lblPoolBalance"
        Me.lblPoolBalance.Size = New System.Drawing.Size(119, 13)
        Me.lblPoolBalance.TabIndex = 6
        Me.lblPoolBalance.Text = "Pool Balance"
        Me.lblPoolBalance.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtHashrate
        '
        Me.txtHashrate.BackColor = System.Drawing.Color.White
        Me.txtHashrate.Location = New System.Drawing.Point(657, 9)
        Me.txtHashrate.Name = "txtHashrate"
        Me.txtHashrate.ReadOnly = True
        Me.txtHashrate.Size = New System.Drawing.Size(100, 20)
        Me.txtHashrate.TabIndex = 5
        Me.txtHashrate.Text = "0"
        Me.txtHashrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblHashRate
        '
        Me.lblHashRate.Location = New System.Drawing.Point(541, 12)
        Me.lblHashRate.Name = "lblHashRate"
        Me.lblHashRate.Size = New System.Drawing.Size(110, 13)
        Me.lblHashRate.TabIndex = 4
        Me.lblHashRate.Text = "Hash Rate"
        Me.lblHashRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDifficulty
        '
        Me.txtDifficulty.BackColor = System.Drawing.Color.White
        Me.txtDifficulty.Location = New System.Drawing.Point(412, 8)
        Me.txtDifficulty.Name = "txtDifficulty"
        Me.txtDifficulty.ReadOnly = True
        Me.txtDifficulty.Size = New System.Drawing.Size(100, 20)
        Me.txtDifficulty.TabIndex = 3
        Me.txtDifficulty.Text = "0"
        Me.txtDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDifficulty
        '
        Me.lblDifficulty.AutoSize = True
        Me.lblDifficulty.Location = New System.Drawing.Point(359, 11)
        Me.lblDifficulty.Name = "lblDifficulty"
        Me.lblDifficulty.Size = New System.Drawing.Size(47, 13)
        Me.lblDifficulty.TabIndex = 2
        Me.lblDifficulty.Text = "Difficulty"
        Me.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBlockHeight
        '
        Me.txtBlockHeight.BackColor = System.Drawing.Color.White
        Me.txtBlockHeight.Location = New System.Drawing.Point(129, 8)
        Me.txtBlockHeight.Name = "txtBlockHeight"
        Me.txtBlockHeight.ReadOnly = True
        Me.txtBlockHeight.Size = New System.Drawing.Size(100, 20)
        Me.txtBlockHeight.TabIndex = 1
        Me.txtBlockHeight.Text = "0"
        Me.txtBlockHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblBlockHeight
        '
        Me.lblBlockHeight.AutoSize = True
        Me.lblBlockHeight.Location = New System.Drawing.Point(55, 11)
        Me.lblBlockHeight.Name = "lblBlockHeight"
        Me.lblBlockHeight.Size = New System.Drawing.Size(68, 13)
        Me.lblBlockHeight.TabIndex = 0
        Me.lblBlockHeight.Text = "Block Height"
        Me.lblBlockHeight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tabOutput
        '
        Me.tabOutput.BackColor = System.Drawing.Color.Transparent
        Me.tabOutput.Controls.Add(Me.txtOutput)
        Me.tabOutput.Location = New System.Drawing.Point(4, 22)
        Me.tabOutput.Name = "tabOutput"
        Me.tabOutput.Size = New System.Drawing.Size(792, 424)
        Me.tabOutput.TabIndex = 1
        Me.tabOutput.Text = "Output"
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
        'tabConfig
        '
        Me.tabConfig.BackColor = System.Drawing.Color.Transparent
        Me.tabConfig.Controls.Add(Me.lblWarning)
        Me.tabConfig.Controls.Add(Me.btnConfigCancel)
        Me.tabConfig.Controls.Add(Me.btnConfigSave)
        Me.tabConfig.Controls.Add(Me.chkConfigAutoOptimise)
        Me.tabConfig.Controls.Add(Me.chkConfigOptimizer)
        Me.tabConfig.Controls.Add(Me.chkConfigAPI)
        Me.tabConfig.Controls.Add(Me.txtConfigDevices)
        Me.tabConfig.Controls.Add(Me.lblConfigDevices)
        Me.tabConfig.Controls.Add(Me.txtConfigThreads)
        Me.tabConfig.Controls.Add(Me.lblConfigThreads)
        Me.tabConfig.Controls.Add(Me.txtConfigBatchsize)
        Me.tabConfig.Controls.Add(Me.lblConfigBatchsize)
        Me.tabConfig.Controls.Add(Me.lblConfigAPI)
        Me.tabConfig.Controls.Add(Me.txtConfigAPIport)
        Me.tabConfig.Controls.Add(Me.lblAPIPort)
        Me.tabConfig.Controls.Add(Me.lblConfigOptimizer)
        Me.tabConfig.Controls.Add(Me.txtConfigDifficulty)
        Me.tabConfig.Controls.Add(Me.lblConfigDifficulty)
        Me.tabConfig.Controls.Add(Me.lblConfigAutooptimise)
        Me.tabConfig.Controls.Add(Me.txtConfigPort)
        Me.tabConfig.Controls.Add(Me.lblConfigPort)
        Me.tabConfig.Controls.Add(Me.txtConfigServer)
        Me.tabConfig.Controls.Add(Me.lblConfigServer)
        Me.tabConfig.Controls.Add(Me.txtConfigName)
        Me.tabConfig.Controls.Add(Me.lblConfigName)
        Me.tabConfig.Controls.Add(Me.txtConfigAddress)
        Me.tabConfig.Controls.Add(Me.lblConfigAddress)
        Me.tabConfig.Location = New System.Drawing.Point(4, 22)
        Me.tabConfig.Name = "tabConfig"
        Me.tabConfig.Size = New System.Drawing.Size(792, 424)
        Me.tabConfig.TabIndex = 4
        Me.tabConfig.Text = "Config"
        '
        'lblWarning
        '
        Me.lblWarning.AutoSize = True
        Me.lblWarning.Location = New System.Drawing.Point(264, 17)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(263, 13)
        Me.lblWarning.TabIndex = 29
        Me.lblWarning.Text = "Saving any configuration changes will restart the miner"
        '
        'btnConfigCancel
        '
        Me.btnConfigCancel.Location = New System.Drawing.Point(461, 377)
        Me.btnConfigCancel.Name = "btnConfigCancel"
        Me.btnConfigCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigCancel.TabIndex = 28
        Me.btnConfigCancel.Text = "Cancel"
        Me.btnConfigCancel.UseVisualStyleBackColor = True
        '
        'btnConfigSave
        '
        Me.btnConfigSave.Location = New System.Drawing.Point(217, 377)
        Me.btnConfigSave.Name = "btnConfigSave"
        Me.btnConfigSave.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigSave.TabIndex = 27
        Me.btnConfigSave.Text = "Save"
        Me.btnConfigSave.UseVisualStyleBackColor = True
        '
        'chkConfigAutoOptimise
        '
        Me.chkConfigAutoOptimise.AutoSize = True
        Me.chkConfigAutoOptimise.Location = New System.Drawing.Point(267, 341)
        Me.chkConfigAutoOptimise.Name = "chkConfigAutoOptimise"
        Me.chkConfigAutoOptimise.Size = New System.Drawing.Size(15, 14)
        Me.chkConfigAutoOptimise.TabIndex = 26
        Me.chkConfigAutoOptimise.UseVisualStyleBackColor = True
        '
        'chkConfigOptimizer
        '
        Me.chkConfigOptimizer.AutoSize = True
        Me.chkConfigOptimizer.Location = New System.Drawing.Point(267, 288)
        Me.chkConfigOptimizer.Name = "chkConfigOptimizer"
        Me.chkConfigOptimizer.Size = New System.Drawing.Size(15, 14)
        Me.chkConfigOptimizer.TabIndex = 25
        Me.chkConfigOptimizer.UseVisualStyleBackColor = True
        '
        'chkConfigAPI
        '
        Me.chkConfigAPI.AutoSize = True
        Me.chkConfigAPI.Location = New System.Drawing.Point(267, 236)
        Me.chkConfigAPI.Name = "chkConfigAPI"
        Me.chkConfigAPI.Size = New System.Drawing.Size(15, 14)
        Me.chkConfigAPI.TabIndex = 24
        Me.chkConfigAPI.UseVisualStyleBackColor = True
        '
        'txtConfigDevices
        '
        Me.txtConfigDevices.Location = New System.Drawing.Point(267, 154)
        Me.txtConfigDevices.Name = "txtConfigDevices"
        Me.txtConfigDevices.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigDevices.TabIndex = 23
        Me.txtConfigDevices.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigDevices
        '
        Me.lblConfigDevices.AutoSize = True
        Me.lblConfigDevices.Location = New System.Drawing.Point(215, 157)
        Me.lblConfigDevices.Name = "lblConfigDevices"
        Me.lblConfigDevices.Size = New System.Drawing.Size(46, 13)
        Me.lblConfigDevices.TabIndex = 22
        Me.lblConfigDevices.Text = "Devices"
        Me.lblConfigDevices.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigThreads
        '
        Me.txtConfigThreads.Location = New System.Drawing.Point(267, 180)
        Me.txtConfigThreads.Name = "txtConfigThreads"
        Me.txtConfigThreads.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigThreads.TabIndex = 21
        Me.txtConfigThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigThreads
        '
        Me.lblConfigThreads.AutoSize = True
        Me.lblConfigThreads.Location = New System.Drawing.Point(215, 183)
        Me.lblConfigThreads.Name = "lblConfigThreads"
        Me.lblConfigThreads.Size = New System.Drawing.Size(46, 13)
        Me.lblConfigThreads.TabIndex = 20
        Me.lblConfigThreads.Text = "Threads"
        Me.lblConfigThreads.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigBatchsize
        '
        Me.txtConfigBatchsize.Location = New System.Drawing.Point(267, 208)
        Me.txtConfigBatchsize.Name = "txtConfigBatchsize"
        Me.txtConfigBatchsize.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigBatchsize.TabIndex = 19
        Me.txtConfigBatchsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigBatchsize
        '
        Me.lblConfigBatchsize.AutoSize = True
        Me.lblConfigBatchsize.Location = New System.Drawing.Point(208, 211)
        Me.lblConfigBatchsize.Name = "lblConfigBatchsize"
        Me.lblConfigBatchsize.Size = New System.Drawing.Size(53, 13)
        Me.lblConfigBatchsize.TabIndex = 18
        Me.lblConfigBatchsize.Text = "Batchsize"
        Me.lblConfigBatchsize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConfigAPI
        '
        Me.lblConfigAPI.AutoSize = True
        Me.lblConfigAPI.Location = New System.Drawing.Point(237, 237)
        Me.lblConfigAPI.Name = "lblConfigAPI"
        Me.lblConfigAPI.Size = New System.Drawing.Size(24, 13)
        Me.lblConfigAPI.TabIndex = 16
        Me.lblConfigAPI.Text = "API"
        Me.lblConfigAPI.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigAPIport
        '
        Me.txtConfigAPIport.Location = New System.Drawing.Point(267, 260)
        Me.txtConfigAPIport.Name = "txtConfigAPIport"
        Me.txtConfigAPIport.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigAPIport.TabIndex = 15
        Me.txtConfigAPIport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAPIPort
        '
        Me.lblAPIPort.AutoSize = True
        Me.lblAPIPort.Location = New System.Drawing.Point(215, 263)
        Me.lblAPIPort.Name = "lblAPIPort"
        Me.lblAPIPort.Size = New System.Drawing.Size(46, 13)
        Me.lblAPIPort.TabIndex = 14
        Me.lblAPIPort.Text = "API Port"
        Me.lblAPIPort.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConfigOptimizer
        '
        Me.lblConfigOptimizer.AutoSize = True
        Me.lblConfigOptimizer.Location = New System.Drawing.Point(211, 289)
        Me.lblConfigOptimizer.Name = "lblConfigOptimizer"
        Me.lblConfigOptimizer.Size = New System.Drawing.Size(50, 13)
        Me.lblConfigOptimizer.TabIndex = 12
        Me.lblConfigOptimizer.Text = "Optimizer"
        Me.lblConfigOptimizer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigDifficulty
        '
        Me.txtConfigDifficulty.Location = New System.Drawing.Point(267, 312)
        Me.txtConfigDifficulty.Name = "txtConfigDifficulty"
        Me.txtConfigDifficulty.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigDifficulty.TabIndex = 11
        Me.txtConfigDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigDifficulty
        '
        Me.lblConfigDifficulty.AutoSize = True
        Me.lblConfigDifficulty.Location = New System.Drawing.Point(214, 315)
        Me.lblConfigDifficulty.Name = "lblConfigDifficulty"
        Me.lblConfigDifficulty.Size = New System.Drawing.Size(47, 13)
        Me.lblConfigDifficulty.TabIndex = 10
        Me.lblConfigDifficulty.Text = "Difficulty"
        Me.lblConfigDifficulty.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConfigAutooptimise
        '
        Me.lblConfigAutooptimise.AutoSize = True
        Me.lblConfigAutooptimise.Location = New System.Drawing.Point(189, 341)
        Me.lblConfigAutooptimise.Name = "lblConfigAutooptimise"
        Me.lblConfigAutooptimise.Size = New System.Drawing.Size(72, 13)
        Me.lblConfigAutooptimise.TabIndex = 8
        Me.lblConfigAutooptimise.Text = "Auto Optimise"
        Me.lblConfigAutooptimise.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigPort
        '
        Me.txtConfigPort.Location = New System.Drawing.Point(267, 128)
        Me.txtConfigPort.Name = "txtConfigPort"
        Me.txtConfigPort.Size = New System.Drawing.Size(77, 20)
        Me.txtConfigPort.TabIndex = 7
        Me.txtConfigPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigPort
        '
        Me.lblConfigPort.AutoSize = True
        Me.lblConfigPort.Location = New System.Drawing.Point(235, 131)
        Me.lblConfigPort.Name = "lblConfigPort"
        Me.lblConfigPort.Size = New System.Drawing.Size(26, 13)
        Me.lblConfigPort.TabIndex = 6
        Me.lblConfigPort.Text = "Port"
        Me.lblConfigPort.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigServer
        '
        Me.txtConfigServer.Location = New System.Drawing.Point(267, 102)
        Me.txtConfigServer.Name = "txtConfigServer"
        Me.txtConfigServer.Size = New System.Drawing.Size(187, 20)
        Me.txtConfigServer.TabIndex = 5
        Me.txtConfigServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigServer
        '
        Me.lblConfigServer.AutoSize = True
        Me.lblConfigServer.Location = New System.Drawing.Point(223, 105)
        Me.lblConfigServer.Name = "lblConfigServer"
        Me.lblConfigServer.Size = New System.Drawing.Size(38, 13)
        Me.lblConfigServer.TabIndex = 4
        Me.lblConfigServer.Text = "Server"
        Me.lblConfigServer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigName
        '
        Me.txtConfigName.Location = New System.Drawing.Point(267, 76)
        Me.txtConfigName.Name = "txtConfigName"
        Me.txtConfigName.Size = New System.Drawing.Size(187, 20)
        Me.txtConfigName.TabIndex = 3
        Me.txtConfigName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigName
        '
        Me.lblConfigName.AutoSize = True
        Me.lblConfigName.Location = New System.Drawing.Point(226, 76)
        Me.lblConfigName.Name = "lblConfigName"
        Me.lblConfigName.Size = New System.Drawing.Size(35, 13)
        Me.lblConfigName.TabIndex = 2
        Me.lblConfigName.Text = "Name"
        Me.lblConfigName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtConfigAddress
        '
        Me.txtConfigAddress.Location = New System.Drawing.Point(267, 50)
        Me.txtConfigAddress.Name = "txtConfigAddress"
        Me.txtConfigAddress.Size = New System.Drawing.Size(337, 20)
        Me.txtConfigAddress.TabIndex = 1
        Me.txtConfigAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConfigAddress
        '
        Me.lblConfigAddress.AutoSize = True
        Me.lblConfigAddress.Location = New System.Drawing.Point(216, 53)
        Me.lblConfigAddress.Name = "lblConfigAddress"
        Me.lblConfigAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblConfigAddress.TabIndex = 0
        Me.lblConfigAddress.Text = "Address"
        Me.lblConfigAddress.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tabSettings
        '
        Me.tabSettings.BackColor = System.Drawing.Color.Transparent
        Me.tabSettings.Controls.Add(Me.gbxErrorLog)
        Me.tabSettings.Controls.Add(Me.gbxNoncerPro)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Size = New System.Drawing.Size(792, 424)
        Me.tabSettings.TabIndex = 2
        Me.tabSettings.Text = "GUI Settings"
        '
        'gbxErrorLog
        '
        Me.gbxErrorLog.Controls.Add(Me.btnClearLog)
        Me.gbxErrorLog.Controls.Add(Me.txtError)
        Me.gbxErrorLog.Location = New System.Drawing.Point(15, 89)
        Me.gbxErrorLog.Name = "gbxErrorLog"
        Me.gbxErrorLog.Size = New System.Drawing.Size(763, 321)
        Me.gbxErrorLog.TabIndex = 1
        Me.gbxErrorLog.TabStop = False
        Me.gbxErrorLog.Text = "Noncer Pro GUI Error Log"
        '
        'btnClearLog
        '
        Me.btnClearLog.Location = New System.Drawing.Point(347, 292)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(75, 23)
        Me.btnClearLog.TabIndex = 1
        Me.btnClearLog.Text = "Clear"
        Me.btnClearLog.UseVisualStyleBackColor = True
        '
        'txtError
        '
        Me.txtError.BackColor = System.Drawing.Color.White
        Me.txtError.Location = New System.Drawing.Point(9, 24)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtError.Size = New System.Drawing.Size(744, 262)
        Me.txtError.TabIndex = 0
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
        'timUpdateChart
        '
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
        Me.tabStatistics.ResumeLayout(False)
        Me.tabStatistics.PerformLayout()
        CType(Me.chtBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtHashRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOutput.ResumeLayout(False)
        Me.tabOutput.PerformLayout()
        Me.tabConfig.ResumeLayout(False)
        Me.tabConfig.PerformLayout()
        Me.tabSettings.ResumeLayout(False)
        Me.gbxErrorLog.ResumeLayout(False)
        Me.gbxErrorLog.PerformLayout()
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
    Friend WithEvents tabStatistics As TabPage
    Friend WithEvents lblBlockHeight As Label
    Friend WithEvents txtBlockHeight As TextBox
    Friend WithEvents txtDifficulty As TextBox
    Friend WithEvents lblDifficulty As Label
    Friend WithEvents txtHashrate As TextBox
    Friend WithEvents lblHashRate As Label
    Friend WithEvents txtConfirmedPoolBalance As TextBox
    Friend WithEvents lblConfirmedPoolBalance As Label
    Friend WithEvents txtPoolBalance As TextBox
    Friend WithEvents lblPoolBalance As Label
    Friend WithEvents tabConfig As TabPage
    Friend WithEvents txtConfigAddress As TextBox
    Friend WithEvents lblConfigAddress As Label
    Friend WithEvents txtConfigName As TextBox
    Friend WithEvents lblConfigName As Label
    Friend WithEvents txtConfigServer As TextBox
    Friend WithEvents lblConfigServer As Label
    Friend WithEvents txtConfigPort As TextBox
    Friend WithEvents lblConfigPort As Label
    Friend WithEvents chkConfigAPI As CheckBox
    Friend WithEvents txtConfigDevices As TextBox
    Friend WithEvents lblConfigDevices As Label
    Friend WithEvents txtConfigThreads As TextBox
    Friend WithEvents lblConfigThreads As Label
    Friend WithEvents txtConfigBatchsize As TextBox
    Friend WithEvents lblConfigBatchsize As Label
    Friend WithEvents lblConfigAPI As Label
    Friend WithEvents txtConfigAPIport As TextBox
    Friend WithEvents lblAPIPort As Label
    Friend WithEvents lblConfigOptimizer As Label
    Friend WithEvents txtConfigDifficulty As TextBox
    Friend WithEvents lblConfigDifficulty As Label
    Friend WithEvents lblConfigAutooptimise As Label
    Friend WithEvents chkConfigOptimizer As CheckBox
    Friend WithEvents chkConfigAutoOptimise As CheckBox
    Friend WithEvents btnConfigCancel As Button
    Friend WithEvents btnConfigSave As Button
    Friend WithEvents lblWarning As Label
    Friend WithEvents gbxErrorLog As GroupBox
    Friend WithEvents btnClearLog As Button
    Friend WithEvents txtError As TextBox
    Friend WithEvents chtBalance As DataVisualization.Charting.Chart
    Friend WithEvents chtHashRate As DataVisualization.Charting.Chart
    Friend WithEvents timUpdateChart As Timer
End Class
