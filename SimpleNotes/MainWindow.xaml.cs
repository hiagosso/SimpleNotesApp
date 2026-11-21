using Microsoft.Win32;
using SimpleNotes.utils;
using System.Windows;
using System.Windows.Input;

namespace SimpleNotes;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string? currentFilePath;
    private bool isModified = false;
    private double currentFontSize = 20;
    private const double MinFontSize = 15;
    private const double MaxFontSize = 40;

    public MainWindow()
    {
        InitializeComponent();
        UpdateTitle();
        
    }
    private void UpdateTitle()
    {
        string fileName = currentFilePath != null
            ? System.IO.Path.GetFileName(currentFilePath)
            : "Novo arquivo.txt";

        Title = "Simple Notes - " + (isModified ? "*" : "") + fileName;
    }

    public void exitBtn_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    public void aboutBtn_Click(Object sender, RoutedEventArgs e)
    {
        var aboutWindow = new AboutWindow();
        aboutWindow.ShowDialog();
    }

    public void openFileBtn_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            textArea.Text = FileOperations.OpenFile(openFileDialog.FileName);
            currentFilePath = openFileDialog.FileName;
            isModified = false;
            UpdateTitle();
        }
    }

    public void SaveFileBtn_Click(object sender, RoutedEventArgs e)
    {
        if (currentFilePath == null)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
                FileName = "Novo arquivo.txt",
                DefaultExt = ".txt",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                currentFilePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
        }

        FileOperations.SaveFile(currentFilePath, textArea.Text);

        isModified = false;
        UpdateTitle();
    }

    private void textArea_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (!isModified)
        {
            isModified = true;
            UpdateTitle();
        }
    }

    private void TextArea_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (Keyboard.IsKeyDown(Key.LeftCtrl) ||
            Keyboard.IsKeyDown(Key.RightCtrl))
        {
            if (e.Delta > 0)
                currentFontSize += 1;
            else
                currentFontSize -= 1;

            currentFontSize = Math.Clamp(
                currentFontSize,
                MinFontSize,
                MaxFontSize
            );

            textArea.FontSize = currentFontSize;

            e.Handled = true;
        }
    }

}