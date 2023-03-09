using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Console.Commands;

public class SettingsCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (args.Any() && settings != null)
        {
            var settingsNames = new List<string> { "--name", "--username", "--defaultServer", "--dateFormat" };
            if (args.Count() == 1)
            {
                if (args.First().InRange(settingsNames))
                {
                    var arg = args.First();
                    if (arg == "--name")
                    {
                        System.Console.WriteLine(Messages.NameValue, settings.Profile.Name);
                    }
                    else if (arg == "--username")
                    {
                        System.Console.WriteLine(Messages.UsernameValue, settings.Profile.Username);
                    }
                    else if (arg == "--defaultServer")
                    {
                        System.Console.WriteLine(Messages.DefaultServerValue, settings.DefaultServer);
                    }
                    else if (arg == "--dateFormat")
                    {
                        System.Console.WriteLine(Messages.DateFormatValue, settings.DateFormat);
                    }
                }
            }
            else if (args.Count() == 2)
            {
                if (args.First().InRange(settingsNames))
                {
                    var arg = args.First();
                    var value = args.Skip(1).First();
                    if (arg == "--name")
                    {
                        System.Console.WriteLine(Messages.SetNameValue, settings.Profile.Name);
                        settings.Profile.Name = value;
                    }
                    else if (arg == "--username")
                    {
                        System.Console.WriteLine(Messages.SetUsernameValue, settings.Profile.Username);
                        settings.Profile.Username = value;
                    }
                    else if (arg == "--defaultServer")
                    {
                        System.Console.WriteLine(Messages.SetDefaultServerValue, settings.DefaultServer);
                        settings.DefaultServer = value;
                    }
                    else if (arg == "--dateFormat")
                    {
                        System.Console.WriteLine(Messages.SetDateFormatValue, settings.DateFormat);
                        settings.DateFormat = value;
                    }
                }
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "settings");
            }
        }
    }

    public Task ExecuteAsync(Settings settings, IEnumerable<string> args)
    {
        return Task.CompletedTask;
    }

    public bool IsAsyncEnabled()
    {
        return true;
    }
}
