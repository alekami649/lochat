using Lochat.Shared;
using Newtonsoft.Json;

namespace Lochat.BotAPI;

public class LochatBotClient
{
    readonly Settings settings;
    readonly FileSystemWatcher watcher;
    DateTime lastUtcRead;

    public LochatBotClient(Settings botSettings)
    {
        settings = botSettings;
        lastUtcRead = DateTime.UtcNow;
        watcher = new FileSystemWatcher(botSettings.GetDirectoryPath(), "*.json");
        watcher.Changed += OnChatFileChanged;
        watcher.EnableRaisingEvents = true;
        OnMessageReceived += PrivateOnMessage;
    }

    private void PrivateOnMessage(object sender, Message message, Chat chat, Settings settings)
    {
    }

    private void OnChatFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.Name == "chat.json")
        {
            Thread.Sleep(1000);
            var chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "chat.json"))) ?? new();
            var messages = chat.Messages.Where(message => message.Sent > lastUtcRead).ToArray();
            lastUtcRead = DateTime.UtcNow;
            foreach (var message in messages.ToArray())
            {
                OnMessageReceived.Invoke(this, message, chat, settings);
            }
        }
        else
        {
            return;
        }
    }

    public delegate void MessageReceivedEventHandler(object sender, Message message, Chat chat, Settings settings);

    public event MessageReceivedEventHandler OnMessageReceived;

    
}