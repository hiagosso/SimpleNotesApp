
using SimpleNotes.utils;
using System;
using System.IO;
using System.Security;

namespace SimpleNotes.Services;

internal static class FileService
{
    public static bool TryOpenFile(
        string filePath,
        out string content,
        out Exception? error)
    {
        try
        {
            content = FileOperations.OpenFile(filePath);
            error = null;

            return true;
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException ||
            ex is SecurityException)
        {
            content = string.Empty;
            error = ex;

            return false;
        }
    }

    public static bool TrySaveFile(
        string filePath,
        string content,
        out Exception? error)
    {
        try
        {
            FileOperations.SaveFile(filePath, content);
            error = null;

            return true;
        }
        catch (Exception ex) when (
            ex is IOException ||
            ex is UnauthorizedAccessException ||
            ex is ArgumentException ||
            ex is SecurityException)
        {
            error = ex;

            return false;
        }
    }
}
