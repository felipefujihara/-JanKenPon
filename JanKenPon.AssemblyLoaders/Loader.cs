using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JanKenPon.AssemblyLoaders
{
    public static class Loader<T> where T : class
    {
        public static List<T> LoadAssemblies(string locationPath)
        {
            var allAssemblies = new List<Assembly>();
            var result = new List<T>();
            var lookFor = typeof(T).FullName;

            string path = Path.GetDirectoryName(locationPath);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));

            foreach (var item in allAssemblies)
            {
                var types = item.GetTypes().Where(p => p.GetInterface(lookFor) != null);
                foreach (var type in types)
                {
                    result.Add(Activator.CreateInstance(type) as T);
                }
            }
            return result;
        }
    }
}
