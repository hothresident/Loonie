using System;
using System.IO;

namespace Translation.Services
{
    public static class FileReader
    {
        public static string Read(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                // Read the stream to a string, and write the string to the console.
                return sr.ReadToEnd();
            }
        }
    }
}
