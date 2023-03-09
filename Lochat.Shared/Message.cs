using Lochat.Console;

namespace Lochat.Shared;

public class Message
{
    public Profile Sender { get; set; } = new();
    public string Text { get; set; } = "";
    public DateTime Sent { get; set; }
}