using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace SimpleNotes.utils;

internal static class FileOperations
{
    public static string OpenFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            return reader.ReadToEnd();
        }
    }

    public static void SaveFile(string filePath, string content)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(content);
        }
    }
}