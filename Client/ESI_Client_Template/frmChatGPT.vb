Imports Azure.AI.OpenAI
Imports Azure
Imports OpenAI
Imports OpenAI.Chat
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json
Imports OpenAI.Assistants

Public Class frmChatGPT

    Dim messages As New List(Of ChatMessage) From {
        New SystemChatMessage("You are a helpful AI assistant that answers questions concisely."),
        New SystemChatMessage("Replay only with ASCII printable characters.")
    }

    Dim clientOptions As New OpenAIClientOptions

    Dim options As New ChatCompletionOptions With {
            .Temperature = 1.0F,
            .MaxOutputTokenCount = 800,
            .TopP = 1.0F,
            .FrequencyPenalty = 0.0F,
            .PresencePenalty = 0.0F
        }

    Dim client As New AzureOpenAIClient(New Uri(azure_openai_endpoint), New AzureKeyCredential(azure_openai_key))

    Private Async Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click
        Try
            cmdSend.Enabled = False
            cmdReset.Enabled = False
            textPrompt.Enabled = False
            cmdSend.Text = "Working..."

            'display prompt in textbox
            rtbResponse.AppendText(textPrompt.Text)
            rtbResponse.SelectionStart = rtbResponse.Text.Length - textPrompt.Text.Length
            rtbResponse.SelectionLength = textPrompt.Text.Length

            rtbResponse.SelectionAlignment = HorizontalAlignment.Right
            rtbResponse.AppendText(vbCrLf & vbCrLf)

            rtbResponse.Refresh()

            messages.Add(New UserChatMessage(textPrompt.Text))

            'clientOptions.Endpoint =

            Dim chat_client = client.GetChatClient(azure_openai_model)

            ' Create the chat completion request
            Dim completion As ChatCompletion = Await chat_client.CompleteChatAsync(messages, options)

            ' Print the response
            Dim content As String = "No response received."
            If completion IsNot Nothing Then
                Dim v = JsonConvert.SerializeObject(completion.Content(0))

                Dim jsonResult As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(v)
                content = jsonResult("Text")

                messages.Add(New AssistantChatMessage(content))
            End If

            rtbResponse.AppendText(content)
            rtbResponse.SelectionStart = rtbResponse.Text.Length - content.Length
            rtbResponse.SelectionLength = content.Length

            rtbResponse.SelectionAlignment = HorizontalAlignment.Left
            rtbResponse.ScrollToCaret()

            rtbResponse.AppendText(vbCrLf & vbCrLf)

            'send the reponse to the server.
            Dim str As String = ""
            str = textPrompt.Text & "|"
            str &= content.Replace("'", "`") & "|"

            frmClient.AC.sendMessage("07", str)

            'clear the text box
            textPrompt.Clear()
            textPrompt.Enabled = True
            textPrompt.Focus()
            cmdSend.Enabled = True
            cmdSend.Text = "Send"

            cmdReset.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'MessageBox.Show(reply)
    End Sub

    Private Sub frmChatGPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clear_screen()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub textPrompt_KeyUp(sender As Object, e As KeyEventArgs) Handles textPrompt.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cmdSend_Click(sender, e)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try

    End Sub

    Public Sub clear_screen()
        Try
            rtbResponse.Clear()
            textPrompt.Clear()
            textPrompt.Focus()

            'rtbResponse.Text = "Hi, I am a chat bot and here to help you. Ask me anything, however keep in mind that I cannot see your screen. This means you will have to explain what you see before asking me a question about it."
            'rtbResponse.SelectionStart = 0
            'rtbResponse.SelectionLength = rtbResponse.Text.Length
            'rtbResponse.SelectionAlignment = HorizontalAlignment.Center

            'rtbResponse.AppendText(vbCrLf & vbCrLf)

            messages = New List(Of ChatMessage) From {
                New SystemChatMessage("You are a helpful AI assistant that answers questions concisely.")
            }
            cmdSend.Enabled = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        Try
            clear_screen()

            Dim str As String = ""
            str = "RESET CHAT BOT" & ";"
            str &= "" & ";"

            frmClient.AC.sendMessage("07", str)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

End Class
