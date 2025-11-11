using static System.Console;
namespace ConAppDelegates;

public class Photo(string photoPath)
{
    private readonly string _photoPath = photoPath;
	public int Brightness { get; init; }

	public static Photo Load(string path) => new(path);

    public static void Save() 
    {
        WriteLine("...Persisting the photo to storage.");
    }

	public override string ToString()
	{
		return $"Photo from Location: {_photoPath}";
	}
}
