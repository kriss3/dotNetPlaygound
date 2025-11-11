using System;

namespace ConAppDelegates.v2;

public class PhotoProcessor 
{
    //public delegate void PhotoFilterHandler(Photo photo);
    public static void Process(string path, Action<Photo> filterHandler) 
    {
        var photo = Photo.Load(path);
        filterHandler(photo);
        Photo.Save();
    }
}
