using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Console.Commands;

public class VersionCommand : ICommand
{
    public void Execute(Settings settings, IEnumerable<string> args)
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        if (version == null)
        {
            System.Console.WriteLine(Messages.VersionError);
        }
        else
        {
            System.Console.WriteLine(Messages.CurrentVersion, version.Major, version.Minor, version.Build, version.Revision);
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
