using System.Numerics;

const string settingsFilePath = "settings.json";

if (!File.Exists(settingsFilePath))
{
    var command = new SettingsCommand();
    if (command.IsAsyncEnabled())
    {
        await command.ExecuteAsync(new Settings(), new string[1] { "initialize" }).ConfigureAwait(true);
    }
    else
    {
        command.Execute(new Settings(), new string[1] { "initialize" });
    }
}
if (args == null || args.Length == 0)
{
    var command = new HelpCommand();
    var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFilePath)) ?? new();
    if (command.IsAsyncEnabled())
    {
        await command.ExecuteAsync(settings, Array.Empty<string>()).ConfigureAwait(true);
    }
    else
    {
        command.Execute(settings, Array.Empty<string>());
    }
}
else
{
    var command = args.First();
    var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsFilePath)) ?? new();
    if (command.InRange("help", "?"))
    {
        var instance = new HelpCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, Array.Empty<string>()).ConfigureAwait(true);
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
            await instance.ExecuteAsync(settings, args.Skip(1)).ConfigureAwait(true);
        }
        else
        {
            instance.Execute(settings, args.Skip(1));
        }
    }
    else if (command.InRange("send"))
    {
        var instance = new SendCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, args.Skip(1)).ConfigureAwait(true);
        }
        else
        {
            instance.Execute(settings, args.Skip(1));
        }
    }
    else if (command.InRange("settings"))
    {
        var instance = new SettingsCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, args.Skip(1)).ConfigureAwait(true);
        }
        else
        {
            instance.Execute(settings, args.Skip(1));
        }
    }
    else if (command.InRange("version"))
    {
        var instance = new VersionCommand();
        if (instance.IsAsyncEnabled())
        {
            await instance.ExecuteAsync(settings, args).ConfigureAwait(true);
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