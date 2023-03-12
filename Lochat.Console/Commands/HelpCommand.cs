namespace Lochat.Console.Commands;

public class HelpCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (!args.Any())
        {

        }
        else
        {
#pragma warning disable CA1308 // ToLowerInvariant()
            var command = args.First().ToLowerInvariant();
#pragma warning restore CA1308 // ToLowerInvariant()
            if (command.InRange("join"))
            {
                System.Console.WriteLine(Help.JoinCommand);
            }
            //else if (command.InRange("send"))
            //{
            //    System.Console.WriteLine(Help.SendCommand);
            //}
            //else if (command.InRange("join"))
            //{
            //    System.Console.WriteLine(Help.JoinCommmand);
            //}
            //else if (command.InRange("settings"))
            //{
            //    System.Console.WriteLine(Help.SettingsCommand);
            //}
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
