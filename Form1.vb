Imports System.Collections.Concurrent
Imports System.IO

Public Class Form1

    'Global Variables
    Dim Running As Boolean
    Dim OutputQueue As ConcurrentQueue(Of String) = New ConcurrentQueue(Of String)
    Dim ForceClose As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Configure open file dialog box
        ExecutableDialog.Filter = "Executable File|*.exe"
        ExecutableDialog.InitialDirectory = Environment.SpecialFolder.UserProfile

        'Load Persistent properties
        txtLocation.Text = My.Settings.ExecutableLocation
        If txtLocation.Text = "" Or Not File.Exists(txtLocation.Text) Then Get_Executable_Location()

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
        StartInfo.WorkingDirectory = Path.GetDirectoryName(txtLocation.Text)
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
        Else
            pbxStatus.Image = My.Resources.MiningRed
            Running = False
            btnStart.Enabled = True
            btnStop.Enabled = False
            timCheckStatus.Enabled = False
            timProcessOutput.Enabled = False
            NotifyIcon.Icon = My.Resources.MiningRed1
            NotifyIcon.Text = "NoncerPro Stopped"
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
            LastLine = LastLine.Replace("[32minfo[39m", " info  ")
            LastLine = LastLine.Replace("[33mwarn[39m", " warn  ")
            LastLine = LastLine.Replace("[31merror[39m", " error ")
            txtOutput.AppendText(LastLine + Environment.NewLine)
            Process_Output(LastLine)
        End If

    End Sub

    Private Sub Process_Output(Data As String)

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

End Class
