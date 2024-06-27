using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Onboarding.Api.Requests;
public class OpenAIService1
{
    private readonly string _apiKey;
    private readonly int maxTokens = 150;
    private readonly string model = "gpt-3.5-turbo";
    private static readonly HttpClient _httpClient = new HttpClient();
    public OpenAIService1(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }
    public async Task<string> GenerateChatCompletion(List<ChatMessage> messages)
    {
        var requestBody = new ChatRequest
        {
            Model = model,
            Messages= messages
        };
        var jsonContent = new StringContent(JObject.FromObject(requestBody).ToString(), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"OpenAI API request failed with status code {response.StatusCode}: {errorContent}");
        }
        var responseString = await response.Content.ReadAsStringAsync();
        var responseData = JObject.Parse(responseString);
        return responseData["choices"][0]["message"]["content"].ToString();
    }
}