using System;
using System.IO;
using System.Reflection;

namespace ConsoleRunner
{
    public class DiLoader
    {
        private static Assembly _tradeLoaderAssembly;
        private static readonly string LocalPath;

        static DiLoader()
        {
            LocalPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public static T GetType<T>(string assemblyString)

        {
            var typeString = assemblyString.Split(',')[0];
            var dllString = assemblyString.Split(',')[1];

            if (_tradeLoaderAssembly == null)
                _tradeLoaderAssembly =
                    Assembly.LoadFile(Path.Combine(LocalPath, dllString) + ".dll");
            var type = _tradeLoaderAssembly.GetType(typeString);
            return (T) Activator.CreateInstance(type);
        }
    }
}