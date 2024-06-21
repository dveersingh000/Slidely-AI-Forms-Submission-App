Imports System.Windows.Forms
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class frmCreateSubmission
    Private stopwatch As Stopwatch
    Private stopwatchTimer As Timer

    Private Sub frmCreateSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the KeyPreview property to true to allow the form to capture key presses.
        Me.KeyPreview = True

        ' Initialize stopwatch and timer
        stopwatch = New Stopwatch()
        stopwatchTimer = New Timer()
        AddHandler stopwatchTimer.Tick, AddressOf UpdateStopwatch
        stopwatchTimer.Interval = 1000 ' 1 second
    End Sub

    Private Sub UpdateStopwatch(sender As Object, e As EventArgs)
        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub frmCreateSubmission_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            ToggleStopwatch()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            SubmitForm()
        End If
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        ToggleStopwatch()
    End Sub

    Private Sub ToggleStopwatch()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            stopwatchTimer.Stop()
        Else
            stopwatch.Start()
            stopwatchTimer.Start()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        SubmitForm()
    End Sub

    Private Async Sub SubmitForm()
        Dim client As New HttpClient()

        Dim data As New Dictionary(Of String, String) From {
            {"name", txtName.Text},
            {"email", txtEmail.Text},
            {"phone", txtPhone.Text},
            {"github_link", txtGithubLink.Text},
            {"stopwatch_time", lblStopwatchTime.Text}
        }

        Dim json As String = JsonConvert.SerializeObject(data)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Try
            Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
            response.EnsureSuccessStatusCode()
            MessageBox.Show("Submission saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
