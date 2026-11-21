
using System.Windows;

namespace SimpleNotes;

public partial class App : Application
{

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = new MainWindow();

        MainWindow = mainWindow;

        mainWindow.Show();

        if (e.Args.Length > 0 &&
            !string.IsNullOrWhiteSpace(e.Args[0]))
        {
            mainWindow.OpenFileFromCommandLine(e.Args[0]);
        }
    }
}
