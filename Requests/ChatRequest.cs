using Newtonsoft.Json;

namespace Onboarding.Api.Requests
{
 
    public class ChatRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("messages")]
        public List<ChatMessage> Messages { get; set; }
    }
}
