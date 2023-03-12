namespace Lochat.Shared;

public class Message
{
    public Message()
    {

    }
    public Message(string text, Profile sender)
    {
        Sender = sender;
        Text = text;
        Sent = DateTime.UtcNow;
    }

    public Profile Sender { get; set; } = new();
    public string Text { get; set; } = "";
    public DateTime Sent { get; set; }
}