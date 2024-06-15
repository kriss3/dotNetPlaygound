
using static System.Console;
namespace ConAppPlayingWithErrorHandling
{
    public class Program
    {
        static async Task Main()
        {
            await Prompt();
        }

        private static async Task Prompt() 
        {
            var message = "Playing with Erorr Handling + Result Pattern in C#";
            await Task.Run(() => WriteLine(message));
            Run();
        }

        private static void Run()
        {
            //TODO: Implement a driver method that utilizes Resul/Error type;
            throw new NotImplementedException();
        }
    }

    public sealed record Error(int Code, string? ErrorMessage = null) 
    {
        public static readonly Error None = new(0, string.Empty);
    }

    public class Result 
    {
        private Result(bool isSuccess, Error error) 
        {
            if (isSuccess && error != Error.None|| !isSuccess && error != Error.None) 
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsError => !IsSuccess;

        public Error? Error { get; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
    }
}
