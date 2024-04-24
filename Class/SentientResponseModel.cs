using System.Text.Json.Serialization;

namespace Inconfessio.Class;

public class SentientResponseModel
{
    // [JsonPropertyName("response_id")]
    // public string? ResponseId { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
    // [JsonPropertyName("generation_id")]
    // public string? GenerationId { get; set; }
    // [JsonPropertyName("chat_history")]
    // public List<string> ChatHistory { get; set; }
    // [JsonPropertyName("finish_reason")]
    // public string? FinishReason { get; set; }
    // [JsonPropertyName("meta")]
    // public string? Meta { get; set; }
}