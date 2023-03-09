using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Console.Commands;

public interface ICommand
{
    bool IsAsyncEnabled();
    void Execute(Settings settings, IEnumerable<string> args);
    Task ExecuteAsync(Settings settings, IEnumerable<string> args);
}
