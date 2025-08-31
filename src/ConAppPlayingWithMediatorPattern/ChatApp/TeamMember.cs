namespace ConAppPlayingWithMediatorPattern.ChatApp;
public abstract class TeamMember(string name)
{
	private ChatRoom? _chatRoom;
	public string Name { get; } = name;
	

	internal void SetChatRoom(ChatRoom chatRoom)
    {
        _chatRoom = chatRoom;
    }

    public void Send(string message)
    {
        _chatRoom?.Send(Name, message);
    }

    public static void Receive(string from, string message) 
    {
        Console.WriteLine($"From: {from}: `{message}`");
    }
}   
