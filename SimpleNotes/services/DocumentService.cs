
using System;
using SimpleNotes.Models;

namespace SimpleNotes.Services;

internal class DocumentService
{
    public Document CurrentDocument { get; private set; } = new();

    public void NewDocument()
    {
        CurrentDocument = new Document();
    }

    public void UpdateContent(string content)
    {
        if (CurrentDocument.Content == content)
            return;

        CurrentDocument.Content = content;
        CurrentDocument.IsModified = true;
    }

    public bool OpenDocument(string filePath, out Exception? error)
    {
        if (!FileService.TryOpenFile(
            filePath,
            out string content,
            out error))
        {
            return false;
        }

        CurrentDocument = new Document
        {
            FilePath = filePath,
            Content = content,
            IsModified = false
        };

        return true;
    }

    public bool SaveDocument(out Exception? error)
    {
        if (CurrentDocument.FilePath == null)
        {
            error = null;
            return false;
        }

        return SaveDocumentAs(CurrentDocument.FilePath, out error);
    }

    public bool SaveDocumentAs(string filePath, out Exception? error)
    {
        if (!FileService.TrySaveFile(
            filePath,
            CurrentDocument.Content,
            out error))
        {
            return false;
        }

        CurrentDocument.FilePath = filePath;
        CurrentDocument.IsModified = false;

        return true;
    }
}
