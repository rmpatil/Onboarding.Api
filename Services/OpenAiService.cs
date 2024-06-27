//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json.Linq;
//public class OpenAIService
//{
//    private readonly string _apiKey;
//    private readonly int maxTokens = 150;
//    private readonly string model = "gpt-3.5-turbo";
//    private static readonly HttpClient _httpClient = new HttpClient();
//    public OpenAIService(string apiKey)
//    {
//        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
//        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
//    }
//    public async Task<string> GenerateText(string prompt)
//    {
//        var requestBody = new
//        {
//            model = model,
//            prompt = "What are tyl products",
//            max_tokens = maxTokens
            
//        };
//        var jsonContent = new StringContent(JObject.FromObject(requestBody).ToString(), Encoding.UTF8, "application/json");
//        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);
//        if (!response.IsSuccessStatusCode)
//        {
//            var errorContent = await response.Content.ReadAsStringAsync();
//            throw new Exception($"OpenAI API request failed with status code {response.StatusCode}: {errorContent}");
//        }
//        var responseString = await response.Content.ReadAsStringAsync();
//        var responseData = JObject.Parse(responseString);
//        return responseData["choices"][0]["text"].ToString();
//    }
//}