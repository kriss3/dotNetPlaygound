using System;
using static System.Console;

namespace ConAppDelegates;


class Program
{
    static void Main()
    {

        var processor = new PhotoProcessor();
        var filters = new PhotoFilters();
        Action<Photo> filterHandler = filters.ApplyBrightness;
        filterHandler += filters.ApplyingContrast;
        filterHandler += filters.Resize;
        filterHandler += RemoveRedEye;
        processor.Process("photo.jpg", filterHandler); 

        ReadLine();
    }

    static void RemoveRedEye(Photo photo) 
    {
        WriteLine("Removing Red Eye from the photo.");
    }
}
