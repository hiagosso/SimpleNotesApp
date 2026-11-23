namespace SimpleNotes;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        var mainForm = new MainForm();

        if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
        {
            mainForm.OpenFileFromCommandLine(args[0]);
        }

        Application.Run(mainForm);
    }
}
