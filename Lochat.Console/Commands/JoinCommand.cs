using System.Globalization;

namespace Lochat.Console.Commands;

public class JoinCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (settings == null)
        {
            System.Console.WriteLine(Messages.SettingsNotSpecified);
            return;
        }
        else
        {
            var server = "";
            if (!args.Any())
            {
                server = settings.DefaultServer;
            }
            else if (args.Count() == 1)
            {
                server = args.First();
            }
            else if (args.Count() == 2)
            {
                server = args.Skip(1).First();
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "join");
                return;
            }
            System.Console.WriteLine(Messages.SuccessConnecting, server);
        }
    }

    private void Connect(Settings settings, string server, ConnectProtocol protocol)
    {
        if (protocol == ConnectProtocol.Unknown)
        {
            return;
        }
        else if (protocol == ConnectProtocol.FileWatcher)
        {
            var watcher = new FileSystemWatcher($@"\{server}\Users\Public\Documents\Lochat", "*.json")
            {
                NotifyFilter = NotifyFilters.LastWrite
            };
            watcher.Changed += OnFileChanged;
            watcher.Dispose();
            Task.Run(async () => await RunRead(settings, server, protocol).ConfigureAwait(false));
        }
    }

    private void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        if (e.Name == "chat.json")
        {
            var outChannel = System.Console.Out;
        }
        else
        {
            return;
        }
    }

    private async Task RunRead(Settings settings, string server, ConnectProtocol protocol)
    {
        var inChannel = System.Console.In;
        var message = await inChannel.ReadLineAsync().ConfigureAwait(false);
        
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