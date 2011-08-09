using System;
using System.IO;

namespace Common
{
    public class PathHelpers
    {
        public static string InCurrentAppDomain(string path)
        {
            var inCurrentAppDomainPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            return Path.GetFullPath(inCurrentAppDomainPath);
        }
    }
}
