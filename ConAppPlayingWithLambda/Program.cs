namespace ConAppPlayingWithLambda;

public class Program
{
	static async Task Main() => await Task.Run(() => Console.WriteLine("Lambda Expressions"));
}

public class MxCurrency 
{
	public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UdfCurrency 
{
    public string? Code { get; set; }
    public string? Description { get; set; }
}


