Imports System.Collections.Concurrent
Imports System.IO
Imports System.Windows.Forms.AxHost
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
    Dim RestartPoints As Integer
    Dim InvalidShares As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'Configure open file dialog box
            ExecutableDialog.Filter = "Executable File|*.exe"
            ExecutableDialog.InitialDirectory = Environment.SpecialFolder.UserProfile

            'Load Persistent properties
            txtLocation.Text = My.Settings.ExecutableLocation
            If txtLocation.Text = "" Or Not File.Exists(txtLocation.Text) Then Get_Executable_Location()
            If txtLocation.Text = "" Or Not File.Exists(txtLocation.Text) Then
                'User has cancelled the open file dialog without choosing a valid location, so close the application
                ForceClose = True
                Me.Close()
            End If
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

            'Initialise invalid share counter
            InvalidShares = 0

            'Clear output window
            txtOutput.Text = ""

            'Centre Form on screen
            Me.CenterToScreen()

            'Set force close flag to false
            ForceClose = False

        Catch ex As Exception
            Log_Error(ex)
        End Try

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

            'Hide the legend to the right of the chart
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

            'Hide the legend to the right of the chart
            chtBalance.Series(0).IsVisibleInLegend = False

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Try
            Start_miner()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Start_miner()

        Dim StartInfo As ProcessStartInfo = New ProcessStartInfo

        Try
            'Configure process
            StartInfo.FileName = txtLocation.Text
            StartInfo.WorkingDirectory = NoncerPath
            StartInfo.RedirectStandardOutput = True
            StartInfo.RedirectStandardError = True
            StartInfo.UseShellExecute = False
            StartInfo.CreateNoWindow = True

            'Start process
            MiningProcess = Process.Start(StartInfo)

            'start readers for redirects
            MiningProcess.BeginOutputReadLine()
            MiningProcess.BeginErrorReadLine()

            'Create fresh queue for output
            OutputQueue = New ConcurrentQueue(Of String)

            'Update status
            Update_Status("running")

            'Reset restart points
            RestartPoints = 0

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        Try
            Stop_Miner()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Stop_Miner()

        Dim TestProcess() As Process

        Try
            'Kill
            Try
                MiningProcess.Kill()
            Catch
                'ignore any failure
            End Try

            'And kill again to be sure
            Try
                TestProcess = Process.GetProcessesByName("noncerpro.exe")
                For Each Process In TestProcess
                    Process.Kill()
                Next
            Catch
                'Ignore any failure
            End Try

            'Update status
            Update_Status("stopped")

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Update_Status(status As String)

        Try
            'Update status
            If status = "running" Then
                Running = True
                btnStart.Enabled = False
                btnStop.Enabled = True
                timCheckStatus.Enabled = True
                timProcessOutput.Enabled = True
                timUpdateChart.Enabled = True
                NotifyIcon.Text = "NoncerPro Running"
                pbxStatus.Image = My.Resources.MiningGreen
                NotifyIcon.Icon = My.Resources.MiningGreen1
                Me.Icon = My.Resources.MiningGreen1
            Else
                Running = False
                btnStart.Enabled = True
                btnStop.Enabled = False
                timCheckStatus.Enabled = False
                timProcessOutput.Enabled = False
                timUpdateChart.Enabled = False
                NotifyIcon.Text = "NoncerPro Stopped"
                pbxStatus.Image = My.Resources.MiningRed
                NotifyIcon.Icon = My.Resources.MiningRed1
                Me.Icon = My.Resources.MiningRed1
            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub timCheckStatus_Tick(sender As Object, e As EventArgs) Handles timCheckStatus.Tick

        Try
            Check_Status()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Check_Status()

        Dim TestProcess As Process

        'Check if process is running and set status accordingly
        Try
            TestProcess = Process.GetProcessById(MiningProcess.Id)
            If RestartPoints < 100 Then RestartPoints += 1
            Update_Status("running")
        Catch
            If RestartPoints > 60 Then
                Start_miner()
            Else
                Update_Status("stopped")
            End If
        End Try

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            If ForceClose = False And e.CloseReason = CloseReason.UserClosing Then
                'Just minimise
                Me.WindowState = FormWindowState.Minimized
                e.Cancel = True
            Else
                'Genuine close event
                Stop_Miner()
            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

        Try
            Process.Start(My.Settings.NoncerProDownload)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub MiningProcess_OutputDataReceived(sender As Object, e As DataReceivedEventArgs) Handles MiningProcess.OutputDataReceived

        Try
            'Add miner process output to the queue
            OutputQueue.Enqueue(e.Data)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub MiningProcess_ErrorDataReceived(sender As Object, e As DataReceivedEventArgs) Handles MiningProcess.ErrorDataReceived

        Try
            'Add miner process error to the queue
            OutputQueue.Enqueue(e.Data)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub timProcessOutput_Tick(sender As Object, e As EventArgs) Handles timProcessOutput.Tick

        Dim LastLine As String = ""

        Try

            If OutputQueue.Count > 0 Then

                'Remove next output line from the queue for processing
                OutputQueue.TryDequeue(LastLine)

                If Not LastLine Is Nothing Then

                    'Remove colour code characters for neatness
                    LastLine = LastLine.Replace("[32minfo[39m", " info ")
                    LastLine = LastLine.Replace("[33mwarn[39m", " warn ")
                    LastLine = LastLine.Replace("[31merror[39m", " error ")

                    If LastLine.Contains(" warn ") Then
                        txtOutput.SelectionColor = Color.Orange
                        Display_Balloon_Tip("warn", LastLine.Substring(30))
                    ElseIf LastLine.Contains(" error ") Then
                        txtOutput.SelectionColor = Color.Red
                        If LastLine.Substring(31, 43) = "Error from pool: invalid share: invalid pow" Then
                            InvalidShares += 1
                            txtInvalidShares.Text = InvalidShares
                        Else
                            Display_Balloon_Tip("error", LastLine.Substring(31))
                        End If
                    Else
                        txtOutput.SelectionColor = Color.DeepSkyBlue
                    End If

                    'Output data to output textbox
                    txtOutput.AppendText(LastLine + Environment.NewLine)

                    'Do further processing of output
                    Process_Output(LastLine)

                End If

            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Process_Output(Data As String)

        Dim Key As String

        Try
            If Data.Length > 36 Then

                Key = Data.Substring(30, 5)

                'Identify line to be processed and forward to the appropriate subroutine
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

            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Update_Block_Height(Data As String)

        Try
            Dim BlockHeight As String = Data.Substring(48)
            txtBlockHeight.Text = BlockHeight

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Update_Difficulty(Data As String)

        Try
            Dim Difficulty As String = Data.Substring(50)
            txtDifficulty.Text = Difficulty

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Update_Hashrate(Data As String)

        Try
            Dim Hashrate() As String = Data.Substring(46).Split(" ")

            'Get units of hash rate
            lblHashRate.Text = "Hash rate (" + Hashrate(1) + ")"

            'Get value of hash rate
            txtHashrate.Text = Hashrate(0)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Update_Pool_Balance(Data As String)

        Try
            Dim PoolBalance() As String = Data.Substring(44).Split(" ")

            'Get units of balance
            lblPoolBalance.Text = "Pool Balance (" + PoolBalance(1) + ")"
            lblConfirmedPoolBalance.Text = "Confirmed Pool Balance (" + PoolBalance(1) + ")"

            'Get Pool balance
            txtPoolBalance.Text = PoolBalance(0)

            'Get confirmed pool balance
            txtConfirmedPoolBalance.Text = PoolBalance(3)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click

        Try
            'close for real (set forceclose flag)
            ForceClose = True
            Me.Close()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub NotifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseClick

        Try
            'Only handle left mouse button click
            If e.Button = MouseButtons.Left Then
                If Me.WindowState = FormWindowState.Minimized Then
                    Me.Show()
                    Me.WindowState = FormWindowState.Normal
                Else
                    Me.WindowState = FormWindowState.Minimized
                End If
            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Try
            'This is necessary to stop the window title bar being visible when minimised
            If Me.WindowState = FormWindowState.Minimized Then Me.Hide()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Try
            'Save persistent settings
            My.Settings.ExecutableLocation = txtLocation.Text

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Get_Executable_Location()

        Try
            ExecutableDialog.ShowDialog()
            txtLocation.Text = ExecutableDialog.FileName

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnLocation_Click(sender As Object, e As EventArgs) Handles btnLocation.Click

        Try
            Get_Executable_Location()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Load_Configuration()

        Dim ConfigFile As String

        Try
            ConfigFile = NoncerPath + "\miner.conf"

            If File.Exists(ConfigFile + ".bak") Then
                'Backup config exists so not first time in
                If File.Exists(ConfigFile) Then
                    'Config file exists so use it
                    Read_Configuration(ConfigFile)
                Else
                    'No config file so load defaults
                    Load_Default_Config()
                End If
            Else
                If File.Exists(ConfigFile) Then
                    'No backup config, so first time in. Copy original config to backup and load defaults
                    File.Move(ConfigFile, ConfigFile + ".bak")
                    Load_Default_Config()
                Else
                    'No backup config and no original config, so create empty backup and load defaults
                    File.AppendAllText(ConfigFile + ".bak", "")
                    Load_Default_Config()
                End If
            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Read_Configuration(ConfigFile As String)

        Dim ConfigLine() As String

        Try
            'Parse the config file and store values in the controls
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

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Load_Default_Config()

        Try
            'Load default values into controls as no valid config file exists
            txtConfigAddress.Text = ""
            txtConfigName.Text = "Rig1"
            txtConfigServer.Text = "eu.nimpool.io"
            txtConfigPort.Text = "8444"
            txtConfigDevices.Text = "0"
            txtConfigThreads.Text = "2"
            txtConfigBatchsize.Text = "50"
            chkConfigAPI.Checked = True
            txtConfigAPIport.Text = "3000"
            chkConfigOptimizer.Checked = False
            txtConfigDifficulty.Text = "32"
            chkConfigAutoOptimise.Checked = True

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Save_Configuration()

        Dim ConfigFile As String
        Dim Config As String = ""

        Try
            ConfigFile = NoncerPath + "\miner.conf"

            'Delete old version
            If File.Exists(ConfigFile) Then File.Delete(ConfigFile)

            'Build configuration file text from values in the controls
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

            'Write the text to a new config file
            File.AppendAllText(ConfigFile, Config)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnConfigSave_Click(sender As Object, e As EventArgs) Handles btnConfigSave.Click

        Try
            'Save configuration to config file
            Save_Configuration()

            'Restart miner if its running, in order to pick up configuration changes
            If Running = True Then
                Stop_Miner()
                System.Threading.Thread.Sleep(1000)
                Start_miner()
            End If

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub btnConfigCancel_Click(sender As Object, e As EventArgs) Handles btnConfigCancel.Click

        Try
            'Re-load configuration from file into controls, thus undoing any changes made
            Load_Configuration()

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Log_Error(ex As Exception)

        Dim LogEntry As String

        Try
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

        Catch
            'Do Nothing to avoid an endless loop
        End Try

    End Sub

    Private Sub btnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click

        Try
            txtError.Text = ""

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub timUpdateChart_Tick(sender As Object, e As EventArgs) Handles timUpdateChart.Tick

        Try
            'only update charts once both hashrate and balance have been updated at least once
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

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

    Private Sub Display_Balloon_Tip(Severity As String, Message As String)

        Dim Title As String

        Try
            'Configure Balloon tip
            If Severity = "warn" Then
                Title = "Warning"
                NotifyIcon.BalloonTipIcon = ToolTipIcon.Warning
            Else
                Title = "Error"
                NotifyIcon.BalloonTipIcon = ToolTipIcon.Error
            End If

            NotifyIcon.BalloonTipTitle = "Noncer Pro " + Title
            NotifyIcon.BalloonTipText = Message

            'Show Balloon tip
            NotifyIcon.ShowBalloonTip(8000)

        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

End Class
