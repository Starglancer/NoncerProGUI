Imports System.Collections.Concurrent
Imports System.IO

Public Class Form1

    'Global Variables
    Dim Running As Boolean
    Dim OutputQueue As ConcurrentQueue(Of String) = New ConcurrentQueue(Of String)
    Dim ForceClose As Boolean
    Dim NoncerPath As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Configure open file dialog box
        ExecutableDialog.Filter = "Executable File|*.exe"
        ExecutableDialog.InitialDirectory = Environment.SpecialFolder.UserProfile

        'Load Persistent properties
        txtLocation.Text = My.Settings.ExecutableLocation
        If txtLocation.Text = "" Or Not File.Exists(txtLocation.Text) Then Get_Executable_Location()
        NoncerPath = Path.GetDirectoryName(txtLocation.Text)

        'Load configuration file
        Load_Configuration()

        Save_Configuration()

        'Set timer intervals
        timCheckStatus.Interval = 1000
        timProcessOutput.Interval = 1000

        'Set Initial Status as stopped
        Update_Status("stopped")

        'Clear output window
        txtOutput.Text = ""

        'Centre Form on screen
        Me.CenterToScreen()

        'Set force close flag to false
        ForceClose = False

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Dim StartInfo As ProcessStartInfo = New ProcessStartInfo

        StartInfo.FileName = txtLocation.Text
        StartInfo.WorkingDirectory = NoncerPath
        StartInfo.RedirectStandardOutput = True
        StartInfo.RedirectStandardError = True
        StartInfo.UseShellExecute = False
        StartInfo.CreateNoWindow = True

        MiningProcess = Process.Start(StartInfo)
        MiningProcess.BeginOutputReadLine()
        MiningProcess.BeginErrorReadLine()

        Update_Status("running")

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        MiningProcess.Kill()
        Update_Status("stopped")

    End Sub

    Private Sub Update_Status(status As String)

        Dim TestProcess As Process

        'Check if process is running and set status accordingly
        If status = "check" Then
            Try
                TestProcess = Process.GetProcessById(MiningProcess.Id)
                status = "running"
            Catch
                status = "stopped"
            End Try
        End If

        'Update status
        If status = "running" Then
            pbxStatus.Image = My.Resources.MiningGreen
            Running = True
            btnStart.Enabled = False
            btnStop.Enabled = True
            timCheckStatus.Enabled = True
            timProcessOutput.Enabled = True
            NotifyIcon.Icon = My.Resources.MiningGreen1
            NotifyIcon.Text = "NoncerPro Running"
            Me.Icon = My.Resources.MiningGreen1
        Else
            pbxStatus.Image = My.Resources.MiningRed
            Running = False
            btnStart.Enabled = True
            btnStop.Enabled = False
            timCheckStatus.Enabled = False
            timProcessOutput.Enabled = False
            NotifyIcon.Icon = My.Resources.MiningRed1
            NotifyIcon.Text = "NoncerPro Stopped"
            Me.Icon = My.Resources.MiningRed1
        End If

    End Sub

    Private Sub timCheckStatus_Tick(sender As Object, e As EventArgs) Handles timCheckStatus.Tick

        Update_Status("check")

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If ForceClose = False And e.CloseReason = CloseReason.UserClosing Then
            'Just minimise
            Me.WindowState = FormWindowState.Minimized
            e.Cancel = True
        Else
            'Genuine close event
            Try
                MiningProcess.Kill()
            Catch
            End Try
        End If

    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

        Process.Start(My.Settings.NoncerProDownload)

    End Sub

    Private Sub MiningProcess_OutputDataReceived(sender As Object, e As DataReceivedEventArgs) Handles MiningProcess.OutputDataReceived

        OutputQueue.Enqueue(e.Data)

    End Sub

    Private Sub MiningProcess_ErrorDataReceived(sender As Object, e As DataReceivedEventArgs) Handles MiningProcess.ErrorDataReceived

        OutputQueue.Enqueue(e.Data)

    End Sub

    Private Sub timProcessOutput_Tick(sender As Object, e As EventArgs) Handles timProcessOutput.Tick

        Dim LastLine As String = ""

        If OutputQueue.Count > 0 Then
            OutputQueue.TryDequeue(LastLine)
            LastLine = LastLine.Replace("[32minfo[39m", " info ")
            LastLine = LastLine.Replace("[33mwarn[39m", " warn ")
            LastLine = LastLine.Replace("[31merror[39m", " error ")
            txtOutput.AppendText(LastLine + Environment.NewLine)
            Process_Output(LastLine)
        End If

    End Sub

    Private Sub Process_Output(Data As String)

        Dim Key As String

        Key = Data.Substring(30, 5)

        Select Case Key
            Case "New B"
                'Block Height
                Update_Block_Height(Data)
            Case "Diffi"
                'Difficulty
                Update_Difficulty(Data)
            Case "Total"
                'Hash Rate
                Update_Hashrate(Data)
            Case "Pool "
                'Pool Balance
                Update_Pool_Balance(Data)
        End Select

    End Sub

    Private Sub Update_Block_Height(Data As String)

        Dim BlockHeight As String = Data.Substring(48)
        txtBlockHeight.Text = BlockHeight

    End Sub

    Private Sub Update_Difficulty(Data As String)

        Dim Difficulty As String = Data.Substring(50)
        txtDifficulty.Text = Difficulty

    End Sub

    Private Sub Update_Hashrate(Data As String)

        Dim Hashrate() As String = Data.Substring(46).Split(" ")
        lblHashRate.Text = "Hash rate (" + Hashrate(1) + ")"
        txtHashrate.Text = Hashrate(0)

    End Sub

    Private Sub Update_Pool_Balance(Data As String)

        Dim PoolBalance() As String = Data.Substring(44).Split(" ")
        lblPoolBalance.Text = "Pool Balance (" + PoolBalance(1) + ")"
        lblConfirmedPoolBalance.Text = "Confirmed Pool Balance (" + PoolBalance(1) + ")"
        txtPoolBalance.Text = PoolBalance(0)
        txtConfirmedPoolBalance.Text = PoolBalance(3)

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click

        ForceClose = True
        Me.Close()

    End Sub

    Private Sub NotifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseClick

        'Only handle left mouse button click
        If e.Button = MouseButtons.Left Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Minimized
            End If
        End If

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then Me.Hide()

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'Save persistent settings
        My.Settings.ExecutableLocation = txtLocation.Text

        'Save configuration
        Save_Configuration()

    End Sub

    Private Sub Get_Executable_Location()

        ExecutableDialog.ShowDialog()
        txtLocation.Text = ExecutableDialog.FileName

    End Sub

    Private Sub btnLocation_Click(sender As Object, e As EventArgs) Handles btnLocation.Click

        Get_Executable_Location()

    End Sub

    Private Sub Load_Configuration()

        'Loader the configuration from the config file into the application
        Dim ConfigFile As String
        Dim ConfigLine() As String

        ConfigFile = NoncerPath + "\miner.conf"

        If File.Exists(ConfigFile) Then
            ConfigLine = File.ReadAllLines(ConfigFile)
            txtConfigAddress.Text = ConfigLine(1).Substring(12).Replace(""",", "")
            txtConfigName.Text = ConfigLine(2).Substring(9).Replace(""",", "")
            txtConfigServer.Text = ConfigLine(3).Substring(11).Replace("',", "")
            txtConfigPort.Text = ConfigLine(4).Substring(8).Replace(",", "")
            txtConfigDevices.Text = ConfigLine(5).Substring(11).Replace(",", "")
            txtConfigThreads.Text = ConfigLine(6).Substring(11).Replace(",", "")
            txtConfigBatchsize.Text = ConfigLine(7).Substring(13).Replace(",", "")
            If ConfigLine(8).Substring(7).Replace(",", "") = "true" Then
                chkConfigAPI.Checked = True
            Else
                chkConfigAPI.Checked = False
            End If
            txtConfigAPIport.Text = ConfigLine(9).Substring(11).Replace(",", "")
            If ConfigLine(10).Substring(13).Replace(",", "") = "true" Then
                chkConfigOptimizer.Checked = True
            Else
                chkConfigOptimizer.Checked = False
            End If
            txtConfigDifficulty.Text = ConfigLine(11).Substring(14).Replace(",", "")
            If ConfigLine(12).Substring(17).Replace(",", "") = "true" Then
                chkConfigAutoOptimise.Checked = True
            Else
                chkConfigAutoOptimise.Checked = False
            End If
        End If

    End Sub

    Private Sub Save_Configuration()

        'Loader the configuration from the config file into the application
        Dim ConfigFile As String
        Dim Config As String = ""

        ConfigFile = NoncerPath + "\miner.conf"

        'Delete old version
        If File.Exists(ConfigFile) Then File.Delete(ConfigFile)

        'Build configuration file text
        Config += "{" + Environment.NewLine
        Config += """address"": """ + txtConfigAddress.Text + """," + Environment.NewLine
        Config += """name"": """ + txtConfigName.Text + """," + Environment.NewLine
        Config += """server"": '" + txtConfigServer.Text + "'," + Environment.NewLine
        Config += """port"": " + txtConfigPort.Text + "," + Environment.NewLine
        Config += """devices"": " + txtConfigDevices.Text + "," + Environment.NewLine
        Config += """threads"": " + txtConfigThreads.Text + "," + Environment.NewLine
        Config += """batchsize"": " + txtConfigBatchsize.Text + "," + Environment.NewLine
        If chkConfigAPI.Checked = True Then
            Config += """api"": true," + Environment.NewLine
        Else
            Config += """api"": false," + Environment.NewLine
        End If
        Config += """apiport"": " + txtConfigAPIport.Text + "," + Environment.NewLine
        If chkConfigOptimizer.Checked = True Then
            Config += """optimizer"": true," + Environment.NewLine
        Else
            Config += """optimizer"": false," + Environment.NewLine
        End If
        Config += """difficulty"": " + txtConfigDifficulty.Text + "," + Environment.NewLine
        If chkConfigAutoOptimise.Checked = True Then
            Config += """autoOptimizer"": true," + Environment.NewLine
        Else
            Config += """autoOptimizer"": false," + Environment.NewLine
        End If
        Config += "}" + Environment.NewLine

        File.AppendAllText(ConfigFile, Config)

    End Sub

End Class
