namespace ConAppDu.DriverOrApi;

using System.Diagnostics;
using static System.Console;

internal class Program
{
    static void Main()
    {
        WriteLine("Hello from the Driver...");
        Helper hp = new("BioTrack");

        if (hp.MyList.All(s => !string.IsNullOrWhiteSpace(s)))
        {
            WriteLine("All elements are valid.");
        }
        else
        {
            WriteLine("Some elements are empty or null.");
        }

        Parent c1 = new Child1();
        Parent c2 = new Child2();


        Debug.Print($"{c1.Type}");
        Debug.Print($"{c2.Type}");

        ReadLine();
    }
}

public class Helper(string myControl)
{
    private readonly string _control = myControl;

    public List<string> MyList { get; set; } = new List<string>() { "test1", "test2", "test3", "test4" };
}

public abstract record Parent(Enums.TraceType Type);

public record Child1() : Parent(Enums.TraceType.BioTrack);

public record Child2() : Parent(Enums.TraceType.Metrc);

public class Enums
{
    public enum TraceType
    {
        BioTrack,
        Metrc
    }
}




