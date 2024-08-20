using Ardalis.GuardClauses;
using static System.Console;

namespace ConAppPlayingWithGuards;

public class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, World!");
        TestGuard();
        CreatePersonWithoutGuard("John", 17);
        CreatePerson("John", 17);
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

    private static void CreatePersonWithoutGuard(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        if (age <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be greater than 0.");
        }
    }

    private static void CreatePerson(string name, int age)
    {
        //if (string.IsNullOrWhiteSpace(name))
        //{
        //    throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        //}
        Guard.Against.NullOrWhiteSpace(name, nameof(name));

        //if (age <= 0)
        //{
        //    throw new ArgumentOutOfRangeException(nameof(age), "Age must be greater than 0.");
        //}
        Guard.Against.NegativeOrZero(age, nameof(age));
    }

}
