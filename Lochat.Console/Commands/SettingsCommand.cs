namespace Lochat.Console.Commands;

public class SettingsCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (args.Any() && settings != null)
        {
#pragma warning disable CA1308 // ToLowerInvariant()
            if (args.Count() == 1)
            {
                var arg = args.First();
                if (arg.ToLowerInvariant().InRange("--init", "init", "--initialize", "initialize"))
                {

                    System.Console.Write(Messages.EnterYourName);
                    var name = System.Console.ReadLine() ?? "Name";
                    System.Console.Write(Messages.EnterYourUsername);
                    var username = System.Console.ReadLine() ?? "username";
                    username = "@" + username.Replace("_", " ", StringComparison.InvariantCultureIgnoreCase)
                                             .Replace("@", "", StringComparison.InvariantCultureIgnoreCase)
                                             .ToLowerInvariant();

                    var profile = new Profile(name, username);
                    System.Console.Write(Messages.EnterDefaultServer);
                    var defaultServer = System.Console.ReadLine() ?? Environment.MachineName;
                    var newSettings = new Settings
                    {
                        Profile = profile,
                        DefaultServer = defaultServer
                    };
                    File.WriteAllText("settings", JsonConvert.SerializeObject(newSettings));
                    System.Console.WriteLine(Messages.FirstSetupEnded, defaultServer);
                    if (Directory.Exists(newSettings.GetDirectoryPath()))
                    {
                        System.Console.WriteLine(Messages.SuccessConnecting, defaultServer);
                    }
                    else
                    {
                        System.Console.WriteLine(Messages.ErrorConnectingFolderNotFound, defaultServer);
                    }

                }
                else if (arg.ToLowerInvariant().InRange("--name", "name"))
                {
                    System.Console.WriteLine(Messages.NameValue, settings.Profile.Name);
                }
                else if (arg.ToLowerInvariant().InRange("--username", "username", "--nickname", "nickname"))
                {
                    System.Console.WriteLine(Messages.UsernameValue, settings.Profile.Username);
                }
                else if (arg.ToLowerInvariant().InRange("--defaultServer", "defaultServer", "--default_server", "default_server", "--server", "server"))
                {
                    System.Console.WriteLine(Messages.DefaultServerValue, settings.DefaultServer);
                }
                else if (arg.ToLowerInvariant().InRange("--dateFormat", "dateFormat", "--date_format", "date_format"))
                {
                    System.Console.WriteLine(Messages.DateFormatValue, settings.DateFormat);
                }
                else if (arg.ToLowerInvariant().InRange("--folderPath", "folderPath", "--folder_path", "folder_path"))
                {
                    System.Console.WriteLine(Messages.FolderPathValue, settings.DefaultServer, settings.FolderPath);
                }
            }
            else if (args.Count() == 2)
            {
                var arg = args.First();
                var value = args.Skip(1).First();
                if (arg.ToLowerInvariant().InRange("--name", "name"))
                {
                    System.Console.WriteLine(Messages.SetNameValue, value);
                    settings.Profile.Name = value;
                }
                else if (arg.ToLowerInvariant().InRange("--username", "username", "--nickname", "nickname"))
                {
                    System.Console.WriteLine(Messages.SetUsernameValue, "@" + value.ToLowerInvariant());
                    settings.Profile.Username = "@" + value.ToLowerInvariant();
                }
                else if (arg.ToLowerInvariant().InRange("--defaultServer", "defaultServer", "--default_server", "default_server", "--server", "server"))
                {
                    System.Console.WriteLine(Messages.SetDefaultServerValue, value);
                    settings.DefaultServer = value;
                }
                else if (arg.ToLowerInvariant().InRange("--dateFormat", "dateFormat", "--date_format", "date_format"))
                {
                    System.Console.WriteLine(Messages.SetDateFormatValue, value);
                    settings.DateFormat = value;
                }
                else if (arg.ToLowerInvariant().InRange("--folderPath", "folderPath", "--folder_path", "folder_path"))
                {
                    System.Console.WriteLine(Messages.SetFolderPathValue, settings.DefaultServer, settings.FolderPath);
                    settings.FolderPath = value;
                }
                var json = JsonConvert.SerializeObject(settings);
                File.WriteAllText("settings.json", json);
#pragma warning restore CA1308 // ToLowerInvariant()
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "settings");
            }
        }
    }

    public async Task ExecuteAsync(Settings settings, IEnumerable<string> args)
    {
        if (args.Any() && settings != null)
        {
#pragma warning disable CA1308 // ToLowerInvariant()
            if (args.Count() == 1)
            {
                var arg = args.First();
                if (arg.ToLowerInvariant().InRange("--init", "init", "--initialize", "initialize"))
                {

                    System.Console.Write(Messages.EnterYourName);
                    var name = System.Console.ReadLine() ?? "Name";
                    System.Console.Write(Messages.EnterYourUsername);
                    var username = System.Console.ReadLine() ?? "username";
                    username = "@" + username.Replace("_", " ", StringComparison.InvariantCultureIgnoreCase)
                                             .Replace("@", "", StringComparison.InvariantCultureIgnoreCase)
                                             .ToLowerInvariant();
                    var profile = new Profile(name, username);
                    System.Console.Write(Messages.EnterDefaultServer);
                    var defaultServer = System.Console.ReadLine() ?? Environment.MachineName;
                    var newSettings = new Settings
                    {
                        Profile = profile,
                        DefaultServer = defaultServer
                    };
                    await File.WriteAllTextAsync("settings", JsonConvert.SerializeObject(newSettings)).ConfigureAwait(true);
                    System.Console.WriteLine(Messages.FirstSetupEnded, defaultServer);
                    if (Directory.Exists(newSettings.GetDirectoryPath()))
                    {
                        System.Console.WriteLine(Messages.SuccessConnecting, defaultServer);
                    }
                    else
                    {
                        System.Console.WriteLine(Messages.ErrorConnectingFolderNotFound, defaultServer);
                    }

                }
                else if (arg.ToLowerInvariant().InRange("--name", "name"))
                {
                    System.Console.WriteLine(Messages.NameValue, settings.Profile.Name);
                }
                else if (arg.ToLowerInvariant().InRange("--username", "username", "--nickname", "nickname"))
                {
                    System.Console.WriteLine(Messages.UsernameValue, settings.Profile.Username);
                }
                else if (arg.ToLowerInvariant().InRange("--defaultServer", "defaultServer", "--default_server", "default_server", "--server", "server"))
                {
                    System.Console.WriteLine(Messages.DefaultServerValue, settings.DefaultServer);
                }
                else if (arg.ToLowerInvariant().InRange("--dateFormat", "dateFormat", "--date_format", "date_format"))
                {
                    System.Console.WriteLine(Messages.DateFormatValue, settings.DateFormat);
                }
                else if (arg.ToLowerInvariant().InRange("--folderPath", "folderPath", "--folder_path", "folder_path"))
                {
                    System.Console.WriteLine(Messages.FolderPathValue, settings.DefaultServer, settings.FolderPath);
                }
            }
            else if (args.Count() == 2)
            {
                var arg = args.First();
                var value = args.Skip(1).First();
                if (arg.ToLowerInvariant().InRange("--name", "name"))
                {
                    System.Console.WriteLine(Messages.SetNameValue, value);
                    settings.Profile.Name = value;
                }
                else if (arg.ToLowerInvariant().InRange("--username", "username", "--nickname", "nickname"))
                {
                    System.Console.WriteLine(Messages.SetUsernameValue, "@" + value.ToLowerInvariant());
                    settings.Profile.Username = "@" + value.ToLowerInvariant();
                }
                else if (arg.ToLowerInvariant().InRange("--defaultServer", "defaultServer", "--default_server", "default_server", "--server", "server"))
                {
                    System.Console.WriteLine(Messages.SetDefaultServerValue, value);
                    settings.DefaultServer = value;
                }
                else if (arg.ToLowerInvariant().InRange("--dateFormat", "dateFormat", "--date_format", "date_format"))
                {
                    System.Console.WriteLine(Messages.SetDateFormatValue, value);
                    settings.DateFormat = value;
                }
                else if (arg.ToLowerInvariant().InRange("--folderPath", "folderPath", "--folder_path", "folder_path"))
                {
                    System.Console.WriteLine(Messages.SetFolderPathValue, settings.DefaultServer, settings.FolderPath);
                    settings.FolderPath = value;
                }
                var json = JsonConvert.SerializeObject(settings);
                await File.WriteAllTextAsync("settings.json", json).ConfigureAwait(true);
#pragma warning restore CA1308 // ToLowerInvariant()
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "settings");
            }
        }
    }

    public bool IsAsyncEnabled()
    {
        return false;
    }
}
