using System.Globalization;

namespace Lochat.Console.Commands;

public class JoinCommand : ICommand
{
    DateTime LastWrite = DateTime.Now;
    object _lock = new object();
    int[] inputPosition = { System.Console.WindowWidth + Messages.EnterYourMessage.Length, System.Console.WindowHeight };
    int[] outputPosition = { System.Console.GetCursorPosition().Left, System.Console.GetCursorPosition().Top };
    bool transferControl = false;

    public void Execute(Settings settings, IEnumerable<string> args)
    {
        //if (!args.Any() && settings != null)
        //{
        //    var watcher = new FileSystemWatcher(settings.GetDirectoryPath(), "*.json");
        //    watcher.Dispose();
        //    watcher.NotifyFilter = NotifyFilters.LastWrite;
        //    watcher.Changed += OnChanged;
        //}
        //else
        //{
        //    var directoryPath = $@"\\{args.First()}\Public\Documents\Lochat";
        //    var watcher = new FileSystemWatcher(directoryPath, "*.json");
        //    watcher.Dispose();
        //    watcher.NotifyFilter = NotifyFilters.LastWrite;
        //    watcher.Changed += OnChanged;
        //    //Read(settings);
        //}
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
