using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleNotes.Models;

internal class Document
{
    public string? FilePath { get; set; }

    public string Content { get; set; } = "";

    public bool IsModified { get; set; }
}