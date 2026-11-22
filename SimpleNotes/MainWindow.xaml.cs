
using Microsoft.Win32;
using SimpleNotes.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleNotes;

public partial class MainWindow : Window
{
    private readonly DocumentService documentService = new();

    private bool isLoadingDocument = false;

    private double currentFontSize = 20;

    private const double MinFontSize = 10;
    private const double MaxFontSize = 40;

    public MainWindow()
    {
        InitializeComponent();

        UpdateTitle();
        UpdateZoomIndicator();
    }
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Activate();
        Focus();
        textArea.Focus();
    }

    // Atualiza o título da janela.
    private void UpdateTitle()
    {
        var document = documentService.CurrentDocument;

        string fileName = document.FilePath != null
            ? Path.GetFileName(document.FilePath)
            : "Sem título";

        Title = "Simple Notes - "
            + (document.IsModified ? "*" : "")
            + fileName;
    }

    // Atualiza o indicador de zoom.
    private void UpdateZoomIndicator()
    {
        ZoomIndicator.Text = $"Zoom: {currentFontSize:0}";
    }

    // Atualiza o editor com o conteúdo do documento atual.
    private void UpdateEditor()
    {
        isLoadingDocument = true;

        textArea.Text = documentService.CurrentDocument.Content;

        isLoadingDocument = false;

        UpdateTitle();
    }

    // Confirma se o usuário deseja salvar alterações pendentes.
    private bool ConfirmUnsavedChanges()
    {
        if (!documentService.CurrentDocument.IsModified)
            return true;

        MessageBoxResult result = MessageBox.Show(
            "Existem alterações não salvas. Deseja salvar?",
            "Simple Notes",
            MessageBoxButton.YesNoCancel,
            MessageBoxImage.Warning
        );

        switch (result)
        {
            case MessageBoxResult.Yes:
                return SaveCurrentDocument();

            case MessageBoxResult.No:
                return true;

            default:
                return false;
        }
    }

    // Salva o documento atual.
    private bool SaveCurrentDocument()
    {
        var document = documentService.CurrentDocument;

        if (document.FilePath == null)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
                FileName = "Novo arquivo.txt",
                DefaultExt = ".txt",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() != true)
                return false;

            return SaveDocumentAs(saveFileDialog.FileName);
        }

        if (!documentService.SaveDocument(out Exception? error))
        {
            ShowFileError("salvar", error);
            return false;
        }

        StatusMessage.Text = "Arquivo salvo com sucesso.";

        UpdateTitle();

        return true;
    }

    // Salva o documento em um caminho específico.
    private bool SaveDocumentAs(string filePath)
    {
        if (!documentService.SaveDocumentAs(filePath, out Exception? error))
        {
            ShowFileError("salvar", error);
            return false;
        }

        StatusMessage.Text = "Arquivo salvo com sucesso.";

        UpdateTitle();

        return true;
    }

    // Exibe erros relacionados às operações de arquivo.
    private void ShowFileError(string operation, Exception? error)
    {
        MessageBox.Show(
            $"Não foi possível {operation} o arquivo.\n\n{error?.Message}",
            "Erro",
            MessageBoxButton.OK,
            MessageBoxImage.Error
        );

        StatusMessage.Text = "Erro na operação do arquivo.";
    }

    // Cria um novo documento.
    private void newFileBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!ConfirmUnsavedChanges())
            return;

        documentService.NewDocument();

        UpdateEditor();

        StatusMessage.Text = "Novo documento criado.";
    }
  
    // abrir documento.
    private bool OpenDocument(string filePath)
    {
        if (!documentService.OpenDocument(
            filePath,
            out Exception? error))
        {
            ShowFileError("abrir", error);
            return false;
        }

        UpdateEditor();

        StatusMessage.Text = "Arquivo aberto com sucesso.";

        return true;
    }
    // abrir documento pelo cmd.
    internal void OpenFileFromCommandLine(string filePath)
    {
        OpenDocument(filePath);
    }

    // Abre um documento existente.
    private void openFileBtn_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() != true)
            return;

        if (!ConfirmUnsavedChanges())
            return;

        OpenDocument(openFileDialog.FileName);
    }


    // Salva o documento atual.
    private void saveFileBtn_Click(object sender, RoutedEventArgs e)
    {
        SaveCurrentDocument();
    }

    // Salva o documento com outro nome ou caminho.
    private void SaveFileAsBtn_Click(object sender, RoutedEventArgs e)
    {
        string fileName = documentService.CurrentDocument.FilePath != null
            ? Path.GetFileName(documentService.CurrentDocument.FilePath)
            : "Novo arquivo.txt";

        var saveFileDialog = new SaveFileDialog
        {
            Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
            FileName = fileName,
            DefaultExt = ".txt",
            AddExtension = true
        };

        if (saveFileDialog.ShowDialog() != true)
            return;

        SaveDocumentAs(saveFileDialog.FileName);
    }

    // Fecha a janela.
    private void exitBtn_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    // Abre a janela Sobre.
    private void aboutBtn_Click(object sender, RoutedEventArgs e)
    {
        var aboutWindow = new AboutWindow();

        aboutWindow.Owner = this;
        aboutWindow.ShowDialog();
    }

    // Detecta alterações no conteúdo do editor.
    private void textArea_TextChanged(
        object sender,
        TextChangedEventArgs e)
    {
        if (isLoadingDocument)
            return;

        documentService.UpdateContent(textArea.Text);

        UpdateTitle();
    }

    // Controla o zoom usando Ctrl + roda do mouse.
    private void TextArea_PreviewMouseWheel(object sender,MouseWheelEventArgs e)
    {
        if (!Keyboard.IsKeyDown(Key.LeftCtrl) &&
            !Keyboard.IsKeyDown(Key.RightCtrl))
        {
            return;
        }

        currentFontSize += e.Delta > 0 ? 1 : -1;

        currentFontSize = Math.Clamp(
            currentFontSize,
            MinFontSize,
            MaxFontSize
        );

        textArea.FontSize = currentFontSize;

        UpdateZoomIndicator();

        e.Handled = true;
    }

    // Impede o fechamento caso existam alterações não salvas.
    private void MainWindow_Closing(object? sender, CancelEventArgs e)
    {
        if (!ConfirmUnsavedChanges())
        {
            e.Cancel = true;
        }
    }

    private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        // Evita que teclas modificadoras interfiram na identificação do atalho.
        ModifierKeys modifiers = Keyboard.Modifiers;

        if (modifiers == ModifierKeys.Control)
        {
            switch (e.Key)
            {
                case Key.N:
                    newFileBtn_Click(this, new RoutedEventArgs());
                    e.Handled = true;
                    break;

                case Key.O:
                    openFileBtn_Click(this, new RoutedEventArgs());
                    e.Handled = true;
                    break;

                case Key.S:
                    saveFileBtn_Click(this, new RoutedEventArgs());
                    e.Handled = true;
                    break;
            }
        }
        else if (modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
        {
            if (e.Key == Key.S)
            {
                SaveFileAsBtn_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }
        }
        else if (modifiers == ModifierKeys.None && e.Key == Key.Escape)
        {
            Close();
            e.Handled = true;
        }
    }
}
