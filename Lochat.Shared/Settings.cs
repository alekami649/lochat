using Newtonsoft.Json;

namespace Lochat.Shared;

public class Settings
{
    [JsonProperty("profile", Order = 1), JsonRequired]
    public Profile Profile { get; set; } = new();

    [JsonProperty("defaultServer", Order = 2), JsonRequired]
    public string DefaultServer { get; set; } = "";

    [JsonProperty("dateFormat", Order = 3), JsonRequired]
    public string DateFormat { get; set; } = "ss':'mm':'HH' 'dd'.'MM'.'yyyy";

    [JsonProperty("folderPath", Order = 4)]
    public string FolderPath { get; set; } = @"\Shared\Lochat";

    public string GetDirectoryPath()
    {
        return $@"\\{DefaultServer}\{FolderPath}";
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

    [JsonProperty("name", Order = 1), JsonRequired]
    public string Name { get; set; } = "";
    [JsonProperty("username", Order = 2), JsonRequired]
    public string Username { get; set; } = "";
}
