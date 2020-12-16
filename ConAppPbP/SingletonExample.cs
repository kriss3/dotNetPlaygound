using System.Runtime.CompilerServices;

namespace ConAppPbP
{
    public class SingletonExample
    {
        private static SingletonExample mySingleton;
        protected SingletonExample() { }

        private static readonly object syncLock = new object();

        public static SingletonExample Instance() 
        {
            if (mySingleton == null)
            {
                lock (syncLock) 
                {
                    if (mySingleton == null)
                    {
                        mySingleton = new SingletonExample();
                    }
                }
            }
            return mySingleton;
        }
    }
}