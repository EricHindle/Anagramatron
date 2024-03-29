﻿'
' Copyright (c) 2020,2021, Eric Hindle
' All rights reserved.
'
' Author E Hindle
' Created June 2020

Public Class FrmLogViewer
    Dim currentDate As Date
    Dim isZoomOn As Boolean
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub LogViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.LogViewPos)
        isZoomOn = My.Settings.logZoomOn
        ZoomToolStripMenuItem.Checked = isZoomOn
        SetZoom()
        LoadTodaysLog()
    End Sub
    Private Sub ClearLog()
        LogUtil.ClearLogFile()
        rtbLog.Text = ""
    End Sub
    Private Sub BtnNoZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoZoom.Click
        TrackBar1.Value = 10
    End Sub
    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        rtbLog.ZoomFactor = TrackBar1.Value / 10
        btnNoZoom.Text = rtbLog.ZoomFactor
    End Sub
    Private Sub WrapTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrapTextToolStripMenuItem.Click
        rtbLog.WordWrap = WrapTextToolStripMenuItem.Checked
    End Sub
    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        isZoomOn = ZoomToolStripMenuItem.Checked
        SetZoom()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        rtbLog.Copy()
    End Sub
    Private Sub CopyAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllToolStripMenuItem.Click
        rtbLog.SelectAll()
        rtbLog.Copy()
        rtbLog.Select(0, 0)
    End Sub
    Private Sub BtnClearLog_Click(sender As Object, e As EventArgs) Handles BtnClearLog.Click
        ClearLog()
        rtbLog.Text = LogUtil.GetLogContents()
    End Sub

    Private Sub FrmLogViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.LogViewPos = SetFormPos(Me)
        My.Settings.logZoomOn = isZoomOn
        My.Settings.logZoomValue = TrackBar1.Value
        My.Settings.Save()
    End Sub

    Private Sub BtnNextFile_Click(sender As Object, e As EventArgs) Handles BtnNextFile.Click
        ShowNewFile(1)
    End Sub
    Private Sub BtnPrevFile_Click(sender As Object, e As EventArgs) Handles BtnPrevFile.Click
        ShowNewFile(-1)
    End Sub
    Private Sub ShowNewFile(interval As Integer)
        Dim newDate As Date = DateAdd(DateInterval.Day, interval, currentDate)
        Dim newLogFileName As String = LogUtil.GetLogfileName(newDate)
        Dim logContents As String = ""
        If My.Computer.FileSystem.FileExists(newLogFileName) Then
            BtnClearLog.Enabled = False
            Me.Text = "Log: " & newLogFileName
            If newLogFileName = LogUtil.GetLogfileName Then
                logContents = LogUtil.GetLogContents
                BtnClearLog.Enabled = True
            Else
                Try
                    logContents = My.Computer.FileSystem.ReadAllText(newLogFileName).Replace(vbTab, " ")
                Catch ex As System.IO.IOException
                    logContents = newLogFileName & " cannot be opened" & vbCrLf & ex.Message
                End Try
            End If
        Else
            logContents = newLogFileName & " cannot be found"
        End If
        rtbLog.Text = logContents
        currentDate = newDate
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        LoadTodaysLog()
    End Sub
    Private Sub LoadTodaysLog()
        currentDate = Today
        Me.Text = "Log: " & LogUtil.GetLogfileName
        rtbLog.Text = LogUtil.GetLogContents()
        BtnClearLog.Enabled = True
    End Sub
    Private Sub SetZoom()
        TrackBar1.Visible = isZoomOn
        btnNoZoom.Visible = isZoomOn
        If isZoomOn Then
            TrackBar1.Value = My.Settings.logZoomValue
        Else
            TrackBar1.Value = 10
        End If
    End Sub
End Class
