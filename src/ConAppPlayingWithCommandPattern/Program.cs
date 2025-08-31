using ConAppPlayingWithCommandPattern.Model;
using static System.Console;

namespace ConAppPlayingWithCommandPattern;

public class Program
{
    static void Main()
    {
        WriteLine("Executing Command Pattern!");
        var result = Execute();
        WriteLine($"Finished executing the Driver method with status: {result}");
    }

    private static string Execute() 
    {
        var result = "Success";
        //this is my driver function. 
        //I need: Receiver, Command, Invoker
        Receiver receiver = new();
        Command command = new ConcreteCommand(receiver);
        Invoker invoker = new();

        // now that I have base infrastructure ready make a setup:
        invoker.SetCommand(command);
        invoker.ExecuteCommand();

        ReadKey();
        return result;
    }
}
