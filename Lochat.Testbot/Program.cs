using Lochat.BotAPI;
using Lochat.Shared;
using Newtonsoft.Json;
using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json")) ?? new();
var lastUtcRead = DateTime.UtcNow;
var messages = new List<ChatMessage> {
    ChatMessage.FromSystem("You are a helpful assistant.")
};
var service = new OpenAIService(new OpenAiOptions() { ApiKey = File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "ChatGPT", "apikey.secret")),
                                                      Organization = File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "ChatGPT", "orgid.secret")) });

var client = new LochatBotClient(settings);
client.OnMessageReceived += MessageReceived;

Console.ReadKey();

void MessageReceived(object sender, Message message, Chat chat, Settings settings)
{
    if (message.Text.StartsWith("ChatGPT, ", StringComparison.InvariantCultureIgnoreCase))
    {
        var prompt = message.Text["ChatGPT, ".Length..];
        messages.Add(ChatMessage.FromUser(prompt));
        var result = service.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
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
