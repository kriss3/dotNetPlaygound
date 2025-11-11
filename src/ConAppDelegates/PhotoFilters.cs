using System;

namespace ConAppDelegates;

public class PhotoFilters 
{
    public static void ApplyBrightness(Photo photo) => Console.WriteLine($"Applying brightness.{photo.Brightness} ");

    public void ApplyingContrast(Photo photo) => Console.WriteLine("Applying contrast.");

    public void Resize(Photo photo) => Console.WriteLine("Resizing the photo.");
}
