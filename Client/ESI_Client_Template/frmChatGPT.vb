Imports Azure.AI.OpenAI
Imports Azure
Imports OpenAI
Imports OpenAI.Chat
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Public Class frmChatGPT
    Private Async Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click


        Dim clientOptions As New OpenAIClientOptions
        'clientOptions.Endpoint =
        Dim client As New AzureOpenAIClient(New Uri(azure_openai_endpoint), New AzureKeyCredential(azure_openai_key))

        Dim chat_client = client.GetChatClient(azure_openai_model)
        Dim messages As New List(Of ChatMessage) From {
            New SystemChatMessage(textPrompt.Text)
        }

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
        If completion IsNot Nothing Then
            Dim v = JsonConvert.SerializeObject(completion.Content(0))

            Dim jsonResult As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(v)
            'Dim dataArray = CType(jsonResult("data"), Newtonsoft.Json.Linq.JArray)
            'Dim firstItem = dataArray(0)
            Dim content = jsonResult("Text")

            textResponse.Text = content.ToString()

        Else
            textResponse.Text = "No response received."
        End If

        'MessageBox.Show(reply)
    End Sub

    Private Sub frmChatGPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
