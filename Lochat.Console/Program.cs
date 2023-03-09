using System.Threading.Tasks.Dataflow;

const string settingsFilePath = "settings.json";

if (!File.Exists(settingsFilePath))
{
    Console.Write(Messages.EnterYourName);
    var name = Console.ReadLine() ?? "Name";
    Console.Write(Messages.EnterYourUsername);
    var username = Console.ReadLine() ?? "username";
    var profile = new Profile(name, username);
    Console.Write(Messages.EnterDefaultServer);
    var defaultServer = Console.ReadLine() ?? Environment.MachineName;
    var settings = new Settings
    {
        Profile = profile,
        DefaultServer = defaultServer
    };
    File.WriteAllText(settingsFilePath, JsonConvert.SerializeObject(settings));
    Console.WriteLine(Messages.FirstSetupEnded, defaultServer);
    if (Directory.Exists(settings.GetDirectoryPath()))
    {
        Console.WriteLine(Messages.SuccessConnecting, defaultServer);
    }
    else
    {
        Console.WriteLine(Messages.ErrorConnectingFolderNotFound, defaultServer);
    }
}
else if (args == null || args.Length == 0)
{
    var command = new HelpCommand();
    var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFilePath)) ?? new();
    if (command.IsAsyncEnabled())
    {
        await command.ExecuteAsync(settings, Array.Empty<string>());
    }
    else
    {
        command.Execute(settings, Array.Empty<string>());
    }
}
else
{
    var command = args[0];
    var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFilePath)) ?? new();
    if (command.InRange("help", "?"))
    {
        var instance = new HelpCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, Array.Empty<string>());
        }
        else
        {
            instance.Execute(settings, Array.Empty<string>());
        }
    }
    else if (command.InRange("join"))
    {
        var instance = new JoinCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, args.Skip(1));
        }
        else
        {
            instance.Execute(settings, args.Skip(1));
        }
    }
    else
    {
        Console.WriteLine(Messages.CommandNotFound, command);
    }
}