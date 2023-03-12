using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lochat.Console.Commands;

public class SendCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        if (settings == null)
        {
            System.Console.WriteLine(Messages.SettingsNotSpecified);
            return;
        }

        if (args.Any())
        {
            string? text;
            string? server;
            if (args.Count() == 1)
            {
                text = args.First();
                server = settings.DefaultServer;
            }
            else if (args.Count() == 2)
            {
                text = args.First();
                server = args.Skip(1).First();
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "send");
                return;
            }
            var chat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText($@"\\{server}\Shared\Lochat\chat.json")) ?? new();
            var message = new Message(text, settings.Profile);
            chat.Messages = chat.Messages.Append(message).ToList();
            File.WriteAllText($@"\\{server}\Shared\Lochat\chat.json", JsonConvert.SerializeObject(chat));
            System.Console.WriteLine(Messages.SentSuccessfully, text);
        }
        else
        {
            System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "send");
        }
    }

    public async Task ExecuteAsync(Settings settings, IEnumerable<string> args)
    {
        if (settings == null)
        {
            System.Console.WriteLine(Messages.SettingsNotSpecified);
            return;
        }

        if (args.Any())
        {
            string? server;
            string? text;
            if (args.Count() == 1)
            {
                text = args.First();
                server = settings.DefaultServer;
            }
            else if (args.Count() == 2)
            {
                text = args.First();
                server = args.Skip(1).First();
            }
            else
            {
                System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "send");
                return;
            }
            var chat = JsonConvert.DeserializeObject<Chat>(await File.ReadAllTextAsync($@"\\{server}\Shared\Lochat\chat.json").ConfigureAwait(true)) ?? new();
            var message = new Message(text, settings.Profile);
            chat.Messages = chat.Messages.Append(message).ToList();
            await File.WriteAllTextAsync($@"\\{server}\Shared\Lochat\chat.json", JsonConvert.SerializeObject(chat)).ConfigureAwait(true);
            System.Console.WriteLine(Messages.SentSuccessfully, text);
        }
        else
        {
            System.Console.WriteLine(Messages.UnsupportedArgumentsCount, "send");
        }
    }

    public bool IsAsyncEnabled()
    {
        return true;
    }
}
