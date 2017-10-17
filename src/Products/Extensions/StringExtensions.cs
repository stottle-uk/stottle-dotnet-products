using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Middleware.Products.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<Stream> ConvertToStreams(this string filePath)
        {
            return Directory
                .GetFiles(filePath)
                .Select(file => file.ConvertToStream());
        }

        public static Stream ConvertToStream(this string filePath)
        {
            using (var stream = new MemoryStream())
            {
                var bytes = File.ReadAllBytes(filePath);
                stream.Write(bytes, 0, bytes.Length);
                return stream;
            };
        }

        public static IEnumerable<string> GetSubDirectory(this IEnumerable<string> folderPaths, string directoryName, Action<string> directoryNotFound) =>
            folderPaths
                .Select(folder => folder
                    .WithSubFolder(directoryName)
                    .ValidatePath(directoryNotFound));

        public static IEnumerable<KeyValuePair<string, string>> GetDirectorySubFolders(this IEnumerable<string> folderPaths, IEnumerable<string> folderNames) =>
            folderPaths.GetDirectorySubFolders(folderNames, path => { });

        public static IEnumerable<KeyValuePair<string, string>> GetDirectorySubFolders(this IEnumerable<string> folderPaths, IEnumerable<string> folderNames, Action<string> directoryNotFound) =>
            folderPaths
                .SelectMany(folder =>
                     folderNames.Select(folderName => new KeyValuePair<string, string>(folderName, folder.WithSubFolder(folderName).ValidatePath(directoryNotFound)))
                );

        private static string WithSubFolder(this string path, string name) => Path.Combine(path, name);

        private static string ValidatePath(this string path, Action<string> directoryNotFound)
        {
            if (!Directory.Exists(path))
                directoryNotFound(path);

            return path;
        }
    }
}