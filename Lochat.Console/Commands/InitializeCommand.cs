using System.Diagnostics;
using System.Globalization;

namespace Lochat.Console.Commands;

public class InitializeCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (args.Any())
        {
            if (args.Count() == 1) //folder
            {
                var chat = new Chat();
                var folder = args.First();
                var chatJson = JsonConvert.SerializeObject(chat);
                File.WriteAllText(Path.Combine(folder, "chat.json"), chatJson);
            }
            else // 2 or more
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "init");
            }
        }
        else
        {
            var chat = new Chat();
            if (!Directory.Exists(@"C:\Shared"))
            {
                Directory.CreateDirectory(@"C:\Shared");
            }
            Directory.CreateDirectory(@"C:\Shared\Lochat");
            var folder = @"C:\Shared\Lochat";
            var chatJson = JsonConvert.SerializeObject(chat);
            File.WriteAllText(Path.Combine(folder, "chat.json"), chatJson);
            Share(folder, "Shared");
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

    public static void Share(string folder, string name)
    {
        var args = string.Format(CultureInfo.InvariantCulture, "share {0}={1} \"{2}\"", name, folder, $@"\\{Environment.MachineName}\{name}");

        var info = new ProcessStartInfo("net", args)
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = info };
        process.Start();
        process.WaitForExit();
        process.Dispose();
    }
}
