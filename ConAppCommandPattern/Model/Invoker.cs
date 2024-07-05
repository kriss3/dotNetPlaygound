namespace ConAppCommandPattern.Model;

public class Invoker
{
    Command? _cmd;

    public void SetCommand(Command cmd)
    {
        _cmd = cmd;
    }
    public void ExecuteCommand()
    {
        _cmd?.Execute();
    }
}
