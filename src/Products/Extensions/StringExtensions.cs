using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Middleware.Products.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> GetDirectoryItems(this IEnumerable<string> folderPaths, IEnumerable<string> folderNames, Action<string> directoryNotFound) =>
            folderPaths
                .SelectMany(folder => folder
                    .GetFolders(folderNames, directoryNotFound));

        public static IEnumerable<string> GetFolders(this string folderPath, IEnumerable<string> folderNames, Action<string> directoryNotFound) =>
            folderNames
                .Select(folderName => folderPath
                    .WithSubFolder(folderName)
                    .ValidatePath(directoryNotFound));

        public static string WithSubFolder(this string path, string name) => Path.Combine(path, name);

        private static string ValidatePath(this string path, Action<string> directoryNotFound)
        {
            if (!Directory.Exists(path))
                directoryNotFound(path);

            return path;
        }


    }
}