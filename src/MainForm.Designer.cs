namespace SimpleNotes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusMessage = new ToolStripStatusLabel();
            zoomIndicator = new ToolStripStatusLabel();
            textArea = new TextBox();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, helpMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, openMenuItem, toolStripSeparator1, saveMenuItem, saveAsMenuItem, toolStripSeparator2, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(61, 20);
            fileMenuItem.Text = "&Arquivo";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newMenuItem.Size = new Size(220, 22);
            newMenuItem.Text = "&Novo";
            newMenuItem.Click += NewMenuItemClick;
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Size = new Size(220, 22);
            openMenuItem.Text = "&Abrir";
            openMenuItem.Click += OpenMenuItemClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(217, 6);
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(220, 22);
            saveMenuItem.Text = "&Salvar";
            saveMenuItem.Click += SaveMenuItemClick;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsMenuItem.Size = new Size(220, 22);
            saveAsMenuItem.Text = "Salvar &como...";
            saveAsMenuItem.Click += SaveAsMenuItemClick;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(217, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeyDisplayString = "Esc";
            exitMenuItem.Size = new Size(220, 22);
            exitMenuItem.Text = "&Sair";
            exitMenuItem.Click += ExitMenuItemClick;
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(50, 20);
            helpMenuItem.Text = "&Ajuda";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(104, 22);
            aboutMenuItem.Text = "&Sobre";
            aboutMenuItem.Click += AboutMenuItemClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusMessage, zoomIndicator });
            statusStrip.Location = new Point(0, 578);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            // 
            // statusMessage
            // 
            statusMessage.Name = "statusMessage";
            statusMessage.Size = new Size(728, 17);
            statusMessage.Spring = true;
            statusMessage.Text = "Pronto";
            statusMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zoomIndicator
            // 
            zoomIndicator.Name = "zoomIndicator";
            zoomIndicator.Size = new Size(57, 17);
            zoomIndicator.Text = "Zoom: 14";
            zoomIndicator.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textArea
            // 
            textArea.AcceptsReturn = true;
            textArea.AcceptsTab = true;
            textArea.BorderStyle = BorderStyle.None;
            textArea.Dock = DockStyle.Fill;
            textArea.Location = new Point(0, 24);
            textArea.Multiline = true;
            textArea.Name = "textArea";
            textArea.ScrollBars = ScrollBars.Both;
            textArea.Size = new Size(800, 554);
            textArea.TabIndex = 2;
            textArea.TextChanged += TextAreaTextChanged;
            textArea.MouseWheel += TextAreaMouseWheel;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(textArea);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(500, 400);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Notes";
            FormClosing += MainFormClosing;
            Load += MainFormLoad;
            KeyDown += MainFormKeyDown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripStatusLabel zoomIndicator;
        private System.Windows.Forms.TextBox textArea;
    }
}
