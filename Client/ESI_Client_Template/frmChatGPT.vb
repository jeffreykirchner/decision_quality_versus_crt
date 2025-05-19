Imports Azure.AI.OpenAI
Imports Azure
Imports OpenAI
Imports OpenAI.Chat
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json
Imports OpenAI.Assistants

Public Class frmChatGPT

    Dim messages As New List(Of ChatMessage) From {
        New SystemChatMessage("You are a helpful AI assistant that answers questions concisely.")
    }
    Private Async Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click

        cmdSend.Enabled = False
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

        Dim clientOptions As New OpenAIClientOptions
        'clientOptions.Endpoint =
        Dim client As New AzureOpenAIClient(New Uri(azure_openai_endpoint), New AzureKeyCredential(azure_openai_key))

        Dim chat_client = client.GetChatClient(azure_openai_model)

        Dim options As New ChatCompletionOptions With {
            .Temperature = 1.0F,
            .MaxOutputTokenCount = 800,
            .TopP = 1.0F,
            .FrequencyPenalty = 0.0F,
            .PresencePenalty = 0.0F
        }

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

        'send message to server
        Dim str As String = ""
        str &= textPrompt.Text & ";"
        str &= content & ";"

        frmClient.AC.sendMessage("07", str)

        'clear text box
        textPrompt.Clear()
        textPrompt.Enabled = True
        textPrompt.Focus()
        cmdSend.Enabled = True
        cmdSend.Text = "Send"

        'MessageBox.Show(reply)
    End Sub

    Private Sub frmChatGPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub textPrompt_KeyUp(sender As Object, e As KeyEventArgs) Handles textPrompt.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdSend_Click(sender, e)
        End If
    End Sub

    Private Sub textPrompt_Click(sender As Object, e As EventArgs) Handles textPrompt.Click
        If textPrompt.Text = "Type your question here." Then
            textPrompt.Clear()
        End If
    End Sub
End Class
