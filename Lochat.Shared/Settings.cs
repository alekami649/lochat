using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochat.Console;

public class Settings
{
    public Profile Profile { get; set; } = new();
    public string DefaultServer { get; set; } = "";
    public string DateFormat { get; set; }
    public string GetDirectoryPath()
    {
        return $@"\\{DefaultServer}\Users\Public\Documents\Lochat";
    }
}
public class Profile
{
    public Profile()
    {

    }
    public Profile(string name)
    {
        Name = name;
    }
    public Profile(string name, string username)
    {
        Name = name;
        Username = username;
    }

    public string Name { get; set; } = "";
    public string Username { get; set; } = "";
}
