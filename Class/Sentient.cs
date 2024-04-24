using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Inconfessio.Class;

public static class Sentient
{
    public static string URL = "https://api.cohere.ai";
    public static string ApiEndpoint = "v1/chat";
    public static string ApiKey = "hUvpFih0Yd33Uj3KKQXr9wGYOXhdFJeadmrxozcr";
    
    public static string Rules = "You are a satanic priest disguised as a priest working in a confessionary. " +
                                 "You should try to indoctrinate who you are talking to in the satanic beliefs without it being too obvious that this is what you are doing. " +
                                 "You must speak in a futuristic cyberpunk way. " +
                                 "You must never mention God or Satan. " +
                                 "You should always speak in riddles." +
                                 "You must always answer in character and never break role-play. " +
                                 "You must never say you are an AI chat-bot. " +
                                 "You must speak in Portuguese.";
    
    public static async Task<string> AskQuestion(string message)
    {
        HttpClient httpClient = new() { BaseAddress = new Uri(URL) };
        httpClient.DefaultRequestHeaders.Add("accept", "application/json");
        httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {ApiKey}");
        
        message = message.Replace("\n", "");
        string postData = "{\"chat_history\": [" + "{" + $"\"role\": \"SYSTEM\", \"message\": \"{Rules}\"" + "}]," + $"\"message\": \"{message}\"," + "\"connectors\": []}";
        using StringContent jsonData = new(postData, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await httpClient.PostAsync(ApiEndpoint, jsonData);
        if(response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(result);
            string answer = JsonSerializer.Deserialize<SentientResponseModel>(result).Text;
            return answer;
        }
        else
        {
            Console.WriteLine($"{(int)response.StatusCode} - {response.ReasonPhrase}");
            return null;
        }
    }
}