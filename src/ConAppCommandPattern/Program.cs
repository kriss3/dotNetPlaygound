using ConAppCommandPattern.Model;
using static System.Console;

namespace ConAppCommandPattern;

public class Program
{
    static void Main()
    {
        WriteLine("Executing Command Pattern!");

     
    }

    private string Run() 
    {
        await Task.Run(() =>
        {
            //this is my driver function. 
            //I need: Receiver, Command, Invoker
            Receiver receiver = new();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new();

            // now that I have base infrastructure ready make a setup:
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            ReadKey();
        });
    }
}
