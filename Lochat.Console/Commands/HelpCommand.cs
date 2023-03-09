using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Console.Commands;

public class HelpCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {

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
