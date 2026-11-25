using SimpleNotes.Services;

namespace SimpleNotes;

internal sealed partial class MainForm : Form
{
    private readonly DocumentService documentService = new();
    private bool isLoadingDocument;
    private float currentFontSize = 14;

    private const float MinFontSize = 7;
    private const float MaxFontSize = 40;

    public MainForm()
    {
        InitializeComponent();

        // Configurações de runtime que não pertencem ao Designer.
        textArea.Font = new Font(textArea.Font.FontFamily, currentFontSize);

        if (File.Exists("Assets\\icone.ico"))
        {
            Icon = new Icon("Assets\\icone.ico");
        }

        UpdateTitle();
        UpdateZoomIndicator();
    }

    internal void OpenFileFromCommandLine(string filePath)
    {
        OpenDocument(filePath);
    }

    private void UpdateTitle()
    {
        var document = documentService.CurrentDocument;
        var fileName = document.FilePath != null
            ? Path.GetFileName(document.FilePath)
            : "Sem título";

        Text = "Simple Notes - " + (document.IsModified ? "*" : "") + fileName;
    }

    private void UpdateZoomIndicator()
    {
        zoomIndicator.Text = $"Zoom: {currentFontSize:0}";
    }

    private void UpdateEditor()
    {
        isLoadingDocument = true;
        textArea.Text = documentService.CurrentDocument.Content;
        isLoadingDocument = false;
        UpdateTitle();
    }

    private bool ConfirmUnsavedChanges()
    {
        if (!documentService.CurrentDocument.IsModified)
        {
            return true;
        }

        var result = MessageBox.Show(
            this,
            "Existem alterações não salvas. Deseja salvar?",
            "Simple Notes",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Warning);

        return result switch
        {
            DialogResult.Yes => SaveCurrentDocument(),
            DialogResult.No => true,
            _ => false
        };
    }

    private bool SaveCurrentDocument()
    {
        var document = documentService.CurrentDocument;

        if (document.FilePath == null)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
                FileName = "Novo arquivo.txt",
                DefaultExt = "txt",
                AddExtension = true
            };

            return dialog.ShowDialog(this) == DialogResult.OK
                && SaveDocumentAs(dialog.FileName);
        }

        if (!documentService.SaveDocument(out var error))
        {
            ShowFileError("salvar", error);
            return false;
        }

        statusMessage.Text = "Arquivo salvo com sucesso.";
        UpdateTitle();
        return true;
    }

    private bool SaveDocumentAs(string filePath)
    {
        if (!documentService.SaveDocumentAs(filePath, out var error))
        {
            ShowFileError("salvar", error);
            return false;
        }

        statusMessage.Text = "Arquivo salvo com sucesso.";
        UpdateTitle();
        return true;
    }

    private void SaveDocumentAsDialog()
    {
        var fileName = documentService.CurrentDocument.FilePath != null
            ? Path.GetFileName(documentService.CurrentDocument.FilePath)
            : "Novo arquivo.txt";

        using var dialog = new SaveFileDialog
        {
            Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
            FileName = fileName,
            DefaultExt = "txt",
            AddExtension = true
        };

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            SaveDocumentAs(dialog.FileName);
        }
    }

    private void ShowFileError(string operation, Exception? error)
    {
        MessageBox.Show(
            this,
            $"Não foi possível {operation} o arquivo.\n\n{error?.Message}",
            "Erro",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        statusMessage.Text = "Erro na operação do arquivo.";
    }

    private void NewDocument()
    {
        if (!ConfirmUnsavedChanges())
        {
            return;
        }

        documentService.NewDocument();
        UpdateEditor();
        statusMessage.Text = "Novo documento criado.";
    }

    private bool OpenDocument(string filePath)
    {
        if (!documentService.OpenDocument(filePath, out var error))
        {
            ShowFileError("abrir", error);
            return false;
        }

        UpdateEditor();
        statusMessage.Text = "Arquivo aberto com sucesso.";
        return true;
    }

    private void OpenDocumentDialog()
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        if (ConfirmUnsavedChanges())
        {
            OpenDocument(dialog.FileName);
        }
    }

    private void TextAreaTextChanged(object? sender, EventArgs e)
    {
        if (isLoadingDocument)
        {
            return;
        }

        documentService.UpdateContent(textArea.Text);
        UpdateTitle();
    }

    private void TextAreaMouseWheel(object? sender, MouseEventArgs e)
    {
        if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
        {
            return;
        }

        currentFontSize = Math.Clamp(
            currentFontSize + (e.Delta > 0 ? 1 : -1),
            MinFontSize,
            MaxFontSize);

        textArea.Font = new Font(textArea.Font.FontFamily, currentFontSize);
        UpdateZoomIndicator();
    }

    private void MainFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!ConfirmUnsavedChanges())
        {
            e.Cancel = true;
        }
    }

    private void MainFormKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            Close();
            e.Handled = true;
        }
    }

    private void MainFormLoad(object? sender, EventArgs e)
    {
        Activate();
        textArea.Focus();
    }

    private void NewMenuItemClick(object? sender, EventArgs e) => NewDocument();

    private void OpenMenuItemClick(object? sender, EventArgs e) => OpenDocumentDialog();

    private void SaveMenuItemClick(object? sender, EventArgs e) => SaveCurrentDocument();

    private void SaveAsMenuItemClick(object? sender, EventArgs e) => SaveDocumentAsDialog();

    private void ExitMenuItemClick(object? sender, EventArgs e) => Close();

    private void AboutMenuItemClick(object? sender, EventArgs e)
    {
        using var about = new AboutForm();
        about.ShowDialog(this);
    }
}
