Imports System.Diagnostics
Module Module1

    Sub Main()
        If My.Application.CommandLineArgs.Count = 0 Then
            Shell("TaskMgr.exe", AppWinStyle.NormalFocus, False)
        Else
            Dim ProcessName As String = My.Application.CommandLineArgs(0).ToString
            Try
                Dim CurrentProcesses() As Process
                CurrentProcesses = Process.GetProcessesByName(ProcessName)
                For Each proc As Process In CurrentProcesses
                    proc.Kill()
                    MsgBox(String.Format("'{0}'  killed!", ProcessName), MsgBoxStyle.Information, "Process Kill")
                    Exit Sub
                Next
                CurrentProcesses = Process.GetProcesses
                Dim s As New System.Text.StringBuilder
                For Each proc As Process In CurrentProcesses
                    If proc.ProcessName.StartsWith(ProcessName.Substring(0, 1)) Then
                        s.AppendLine(String.Format("{0}; {1}", proc.ProcessName, proc.MainWindowTitle))
                    End If
                Next

                MsgBox(String.Format("'{0}' not found {1}{2}", ProcessName, vbCrLf, s.ToString), MsgBoxStyle.Information, "Process Kill")
            Catch ex As Exception
                MsgBox(String.Format("Process Name: {0}{1}{2}", ProcessName, vbCrLf & vbCrLf, ex.Message))
                '  C3Lib1.Exc1.Show("CLib1.Util0.MemoryOnlyKill", "Process Name:" & ProcessName, ex)
            End Try
        End If
    End Sub

End Module                     