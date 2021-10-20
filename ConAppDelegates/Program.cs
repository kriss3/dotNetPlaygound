using System;

namespace ConAppDelegates
{

    class Program
    {
        static void Main(string[] args)
        {

            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyingContrast;
            filterHandler += filters.Resize;
            filterHandler += RemoveRedEye;
            processor.Process("photo.jpg", filterHandler); 

            Console.ReadLine();
        }

        static void RemoveRedEye(Photo photo) 
        {
            Console.WriteLine("Removing Red Eye from the photo.");
        }
    }
}
