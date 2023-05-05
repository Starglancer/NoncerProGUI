Imports System.Collections.Concurrent
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1

    'Global Variables
    Dim Running As Boolean
    Dim OutputQueue As ConcurrentQueue(Of String)
    Dim ForceClose As Boolean
    Dim NoncerPath As String
    Dim DataArray(,) As Decimal
    Dim DataPointer As Integer
    Dim MaxDataPointer As Integer
    Dim TrendDurationMinutes As Integer
    Dim UpdateIntervalSeconds As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Configure open file dialog box
        ExecutableDialog.Filter = "Executable File|*.exe"
        ExecutableDialog.InitialDirectory = Environment.SpecialFolder.UserProfile

        'Load Persistent properties
        txtLocation.Text = My.Settings.ExecutableLocation
        If txtLocation.Text = "" Or Not File.Exists(txtLocation.Text) Then Get_Executable_Location()
        NoncerPath = Path.GetDirectoryName(txtLocation.Text)

        'Set constants
        TrendDurationMinutes = 60
        UpdateIntervalSeconds = 10

        'Initialise Data Capture for charts
        DataPointer = 0
        MaxDataPointer = Convert.ToInt32(TrendDurationMinutes * 60 / UpdateIntervalSeconds)
        ReDim DataArray(MaxDataPointer + 1, 2)

        'Configure hashrate chart
        Configure_Hashrate_Chart()

        'Configure balance chart
        Configure_Balance_Chart()

        'Load configuration file
        Load_Configuration()

        'Set timer intervals
        timCheckStatus.Interval = 1000
        timProcessOutput.Interval = 1000
        timUpdateChart.Interval = UpdateIntervalSeconds * 1000

        'Set Initial Status as stopped
        Update_Status("stopped")

        'Clear output window
        txtOutput.Text = ""

        'Centre Form on screen
        Me.CenterToScreen()

        'Set force close flag to false
        ForceClose = False

    End Sub

    Private Sub Configure_Hashrate_Chart()

        Try
            With chtHashRate.ChartAreas(0)
                .AxisX.Title = "Time (minutes)"
                .AxisX.MajorGrid.LineColor = Color.Gainsboro
                .AxisX.Minimum = 0
                .AxisY.Title = "Hash Rate"
                .AxisY.MajorGrid.LineColor = Color.Gainsboro
                .AxisY.IsStartedFromZero = False
                .BackColor = Color.White
                .BorderColor = Color.Black
                .BorderDashStyle = ChartDashStyle.Solid
                .BorderWidth = 1
            End With

            chtHashRate.Series(0).IsVisibleInLegend = False

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Configure_Balance_Chart()

        Try
            With chtBalance.ChartAreas(0)
                .AxisX.Title = "Time (minutes)"
                .AxisX.MajorGrid.LineColor = Color.Gainsboro
                .AxisX.Minimum = 0
                .AxisY.Title = "Pool Balance"
                .AxisY.MajorGrid.LineColor = Color.Gainsboro
                .AxisY.IsStartedFromZero = False
                .BackColor = Color.White
                .BorderColor = Color.Black
                .BorderDashStyle = ChartDashStyle.Solid
                .BorderWidth = 1
            End With

            chtBalance.Series(0).IsVisibleInLegend = False

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Start_miner()

    End Sub

    Private Sub Start_miner()

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

        OutputQueue = New ConcurrentQueue(Of String)

        Update_Status("running")

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        Stop_Miner()

    End Sub

    Private Sub Stop_Miner()

        Dim TestProcess() As Process

        'Kill
        Try
            MiningProcess.Kill()
        Catch
        End Try

        'And kill again to be sure
        Try
            TestProcess = Process.GetProcessesByName("noncerpro.exe")
            For Each Process In TestProcess
                Process.Kill()
            Next
        Catch
        End Try

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
            timUpdateChart.Enabled = True
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
            timUpdateChart.Enabled = False
            txtConfirmedPoolBalance.Text = "0"
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
            Stop_Miner()

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

    End Sub

    Private Sub Get_Executable_Location()

        ExecutableDialog.ShowDialog()
        txtLocation.Text = ExecutableDialog.FileName

    End Sub

    Private Sub btnLocation_Click(sender As Object, e As EventArgs) Handles btnLocation.Click

        Get_Executable_Location()

    End Sub

    Private Sub Load_Configuration()

        Dim ConfigFile As String

        ConfigFile = NoncerPath + "\miner.conf"

        If File.Exists(ConfigFile + ".bak") Then
            If File.Exists(ConfigFile) Then
                Read_Configuration(ConfigFile)
            Else
                Load_Default_Config()
            End If
        Else
            If File.Exists(ConfigFile) Then
                File.Move(ConfigFile, ConfigFile + ".bak")
                Load_Default_Config()
            Else
                File.AppendAllText(ConfigFile + ".bak", "")
                Load_Default_Config()
            End If
        End If

    End Sub

    Private Sub Read_Configuration(ConfigFile As String)

        Dim ConfigLine() As String

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

    End Sub

    Private Sub Load_Default_Config()

        txtConfigAddress.Text = ""
        txtConfigName.Text = "Rig1"
        txtConfigServer.Text = "eu.nimpool.io"
        txtConfigPort.Text = "8444"
        txtConfigDevices.Text = "0"
        txtConfigThreads.Text = "2"
        txtConfigBatchsize.Text = "92"
        chkConfigAPI.Checked = True
        txtConfigAPIport.Text = "3000"
        chkConfigOptimizer.Checked = False
        txtConfigDifficulty.Text = "32"
        chkConfigAutoOptimise.Checked = True

    End Sub

    Private Sub Save_Configuration()

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

    Private Sub btnConfigSave_Click(sender As Object, e As EventArgs) Handles btnConfigSave.Click

        Save_Configuration()

        If Running = True Then
            Stop_Miner()
            System.Threading.Thread.Sleep(1000)
            Start_miner()
        End If

    End Sub

    Private Sub btnConfigCancel_Click(sender As Object, e As EventArgs) Handles btnConfigCancel.Click

        Load_Configuration()

    End Sub

    Private Sub Log_Error(ex As Exception)

        Dim LogEntry As String

        'Construct Log Entry
        LogEntry = "----------------------------------------------"
        LogEntry += Environment.NewLine
        LogEntry += Date.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")
        LogEntry += Environment.NewLine
        LogEntry += "----------------------------------------------"
        LogEntry += Environment.NewLine
        LogEntry += "Exception Message: " + ex.Message
        LogEntry += Environment.NewLine
        LogEntry += "StackTrace: " + ex.StackTrace
        LogEntry += Environment.NewLine
        LogEntry += "Source: " + ex.Source
        LogEntry += Environment.NewLine
        LogEntry += "TargetSite: " + ex.TargetSite.ToString
        LogEntry += Environment.NewLine

        'Write entry to log
        txtError.AppendText(LogEntry)

    End Sub

    Private Sub btnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click

        txtError.Text = ""

    End Sub

    Private Sub timUpdateChart_Tick(sender As Object, e As EventArgs) Handles timUpdateChart.Tick

        If txtHashrate.Text <> "0" And txtPoolBalance.Text <> "0" Then

            'Store current Hashrate
            DataArray(DataPointer, 0) = Convert.ToDecimal(txtHashrate.Text)

            'Display Hashrate Graph
            chtHashRate.Series.Clear()
            chtHashRate.Series.Add("Hash Rate")

            With chtHashRate.Series(0)
                .IsVisibleInLegend = False
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .BorderWidth = 3
                .Color = Color.DarkGray
                .BorderDashStyle = ChartDashStyle.Solid

                For N As Integer = 0 To DataPointer
                    .Points.AddXY(N * UpdateIntervalSeconds / 60, DataArray(N, 0))
                Next

            End With

            'Store current Balance
            DataArray(DataPointer, 1) = Convert.ToDecimal(txtPoolBalance.Text)

            'Display Balance Graph
            chtBalance.Series.Clear()
            chtBalance.Series.Add("Pool Balance")

            With chtBalance.Series(0)
                .IsVisibleInLegend = False
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                .BorderWidth = 3
                .Color = Color.DarkGray
                .BorderDashStyle = ChartDashStyle.Solid

                For N As Integer = 0 To DataPointer
                    .Points.AddXY(N * UpdateIntervalSeconds / 60, DataArray(N, 1))
                Next

            End With

            'Increment pointer
            DataPointer += 1

            'Shift array contents once we reach maximum duration
            If DataPointer > MaxDataPointer Then
                DataPointer = MaxDataPointer
                For N As Integer = 0 To MaxDataPointer - 1
                    DataArray(N, 0) = DataArray(N + 1, 0)
                    DataArray(N, 1) = DataArray(N + 1, 1)
                Next
            End If

        End If

    End Sub

End Class
