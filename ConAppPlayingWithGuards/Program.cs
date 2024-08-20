namespace ConAppPlayingWithGuards;

using static System.Console;
public class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, World!");
        TestGuard();
        await Task.CompletedTask;
    }

    private static void TestGuard()
    {
        var age = 17;
        if (age < 18)
        {
            throw new Exception("You are not allowed to enter this site.");
        }
    }
}
