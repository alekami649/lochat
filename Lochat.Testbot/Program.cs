using Lochat.Shared;
using Newtonsoft.Json;
using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System.Linq;

var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json")) ?? new();
var lastUtcRead = DateTime.UtcNow;
var watcher = new FileSystemWatcher(settings.GetDirectoryPath(), "*.json")
{
    NotifyFilter = NotifyFilters.LastWrite
};
var messages = new List<ChatMessage> {
    ChatMessage.FromSystem("You are a helpful assistant.")
};
var client = new OpenAIService(new OpenAiOptions() { ApiKey = File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "ChatGPT", "apikey.secret")),
                                                     Organization = File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "ChatGPT", "orgid.secret")) });
watcher.Changed += OnChatUpdated;
watcher.EnableRaisingEvents = true;
Console.ReadKey();
watcher.Dispose();
var chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "chat.json"))) ?? new();
Console.ReadKey();
void OnChatUpdated(object sender, FileSystemEventArgs e)
{
    if (e.Name == "chat.json")
    {
        Thread.Sleep(1000);
        chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(e.FullPath)) ?? new();
        var messages = chat.Messages.Where(message => message.Sent > lastUtcRead).ToArray();
        lastUtcRead = DateTime.UtcNow;
        foreach (var message in messages.ToArray())
        {
            MessageReceived(message);
        }
    }
};

void MessageReceived(Message message)
{
    if (message.Text.StartsWith("ChatGPT, ", StringComparison.InvariantCultureIgnoreCase))
    {
        var prompt = message.Text["ChatGPT, ".Length..];
        messages.Add(ChatMessage.FromUser(prompt));
        var result = client.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = messages,
            Model = Models.ChatGpt3_5Turbo,
            MaxTokens = 256
        }).Result;
        messages.Add(result.Choices[0].Message);
        chat.Messages = chat.Messages.Append(new Message(result.Choices[0].Message.Content.Trim('\n'), settings.Profile)).ToList();
        var newChat = JsonConvert.SerializeObject(chat);
        File.WriteAllText(Path.Combine(settings.GetDirectoryPath(), "chat.json"), newChat);
    }
}
