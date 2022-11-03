using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ikvm.runtime;
using IKVM;
using java.net;
using static System.Console;

namespace JavaPort
{
    public class JavaUser
    {
        public string GetName()
        {
            URL url = new(@"file:Library/demo.jar");
            URL[] urls = { url };
            URLClassLoader loader = new URLClassLoader(urls);

            try
            {
                // load the Class
                java.lang.Class cl = java.lang.Class.forName("com.kws.User", true, loader);

                // Create a Object via Java reflection
                object obj = cl.newInstance();
                WriteLine(obj);
                obj = cl.getConstructor().newInstance();
                WriteLine(obj);

                //Create a object via C# reflection
                Type type = ikvm.runtime.Util.getInstanceTypeFromClass(cl);

                // create an instance of that type
                object instance = Activator.CreateInstance(type);
                var mth = type.GetMethod("GetUser");
                string res = mth.Invoke(instance, null).ToString();
                WriteLine($"Method Invoked with value: {res}");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
                WriteLine(ex.StackTrace);
            }





            return string.Empty;
        }
    }
}
