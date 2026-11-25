using System.Diagnostics;

namespace SimpleNotes;

internal sealed partial class AboutForm : Form
{
    private const string IconPath = "Assets\\icone.ico";

    public AboutForm()
    {
        InitializeComponent();
        LoadIcons();

        // Libera a imagem gerada a partir do ícone ao descartar o formulário.
        Disposed += (_, _) => picture.Image?.Dispose();
    }

    private void LoadIcons()
    {
        if (!File.Exists(IconPath))
        {
            return;
        }

        using var icon = new Icon(IconPath);
        picture.Image = icon.ToBitmap();
        Icon = new Icon(IconPath);
    }

    private void LinkLinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/hiagosso/SimpleNotesApp/",
            UseShellExecute = true
        });
    }
}
