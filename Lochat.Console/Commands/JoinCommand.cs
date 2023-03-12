using System.Globalization;

namespace Lochat.Console.Commands;

public class JoinCommand : ICommand
{
    DateTime lastUtcRead = DateTime.UtcNow;
    Settings settings = new();

    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (settings == null)
        {
            System.Console.WriteLine(Messages.SettingsNotSpecified);
            return;
        }
        else
        {
            this.settings = settings;
            var server = "";
            if (!args.Any())
            {
                server = settings.DefaultServer;
            }
            else if (args.Count() == 1)
            {
                settings.DefaultServer = args.First();
            }
            else if (args.Count() == 2)
            {
                settings.DefaultServer = args.Skip(1).First();
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "join");
                return;
            }
            System.Console.WriteLine(Messages.SuccessConnecting, server);
            var chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(Path.Combine(settings.GetDirectoryPath(), "chat.json"))) ?? new();
            if (chat.Messages.Count < 10)
            {
                var messages = chat.Messages.ToArray();
                foreach (var message in messages.ToArray())
                {
                    var convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(message.Sent, TimeZoneInfo.Local);
                    System.Console.WriteLine(Messages.Message, message.Sender.Name, message.Sender.Username, convertedDateTime.ToString(settings.DateFormat, CultureInfo.InvariantCulture), message.Text);
                }
            }
            else
            {
                var messages = chat.Messages.TakeLast(10).ToArray();
                foreach (var message in messages.ToArray())
                {
                    var convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(message.Sent, TimeZoneInfo.Local);
                    System.Console.WriteLine(Messages.Message, message.Sender.Name, message.Sender.Username, convertedDateTime.ToString(settings.DateFormat, CultureInfo.InvariantCulture), message.Text);
                }
            }
            var watcher = new FileSystemWatcher(settings.GetDirectoryPath(), "*.json")
            {
                NotifyFilter = NotifyFilters.LastWrite
            };
            watcher.Changed += OnFileChanged;
            watcher.EnableRaisingEvents = true;
            System.Console.ReadKey();
            watcher.Dispose();
        }
    }
    private void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.Name == "chat.json" && e.ChangeType == WatcherChangeTypes.Changed)
        {
#pragma warning disable CA5394 // Random is unsecure o_O
            Thread.Sleep(Random.Shared.Next(100, 500));
#pragma warning restore CA5394 // Random is unsecure O_o
            var chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(e.FullPath)) ?? new();
            var messages = chat.Messages.Where(message => message.Sent > lastUtcRead).ToArray();
            lastUtcRead = DateTime.UtcNow;
            foreach (var message in messages.ToArray())
            {
                var convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(message.Sent, TimeZoneInfo.Local);
                System.Console.WriteLine(Messages.Message, message.Sender.Name, message.Sender.Username, convertedDateTime.ToString(settings.DateFormat, CultureInfo.InvariantCulture), message.Text);
            }
        }
        else
        {
            return;
        }
    }

    public Task ExecuteAsync(Settings settings, IEnumerable<string> args)
    {
        return Task.CompletedTask;
    }

    public bool IsAsyncEnabled()
    {
        return false;
    }
}

public enum ConnectProtocol
{
    Unknown = 0,
    FileWatcher = 1
}