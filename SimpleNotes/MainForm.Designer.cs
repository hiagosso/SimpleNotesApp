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
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            zoomIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            textArea = new System.Windows.Forms.TextBox();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileMenuItem, helpMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(800, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newMenuItem, openMenuItem, toolStripSeparator1, saveMenuItem, saveAsMenuItem, toolStripSeparator2, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new System.Drawing.Size(61, 20);
            fileMenuItem.Text = "&Arquivo";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            newMenuItem.Size = new System.Drawing.Size(180, 22);
            newMenuItem.Text = "&Novo";
            newMenuItem.Click += NewMenuItemClick;
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openMenuItem.Size = new System.Drawing.Size(180, 22);
            openMenuItem.Text = "&Abrir";
            openMenuItem.Click += OpenMenuItemClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveMenuItem.Size = new System.Drawing.Size(180, 22);
            saveMenuItem.Text = "&Salvar";
            saveMenuItem.Click += SaveMenuItemClick;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.S;
            saveAsMenuItem.Size = new System.Drawing.Size(180, 22);
            saveAsMenuItem.Text = "Salvar &como...";
            saveAsMenuItem.Click += SaveAsMenuItemClick;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeyDisplayString = "Esc";
            exitMenuItem.Size = new System.Drawing.Size(180, 22);
            exitMenuItem.Text = "&Sair";
            exitMenuItem.Click += ExitMenuItemClick;
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(50, 20);
            helpMenuItem.Text = "&Ajuda";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size(180, 22);
            aboutMenuItem.Text = "&Sobre";
            aboutMenuItem.Click += AboutMenuItemClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusMessage, zoomIndicator });
            statusStrip.Location = new System.Drawing.Point(0, 578);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(800, 22);
            statusStrip.TabIndex = 1;
            // 
            // statusMessage
            // 
            statusMessage.Name = "statusMessage";
            statusMessage.Size = new System.Drawing.Size(729, 17);
            statusMessage.Spring = true;
            statusMessage.Text = "Pronto";
            statusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoomIndicator
            // 
            zoomIndicator.Name = "zoomIndicator";
            zoomIndicator.Size = new System.Drawing.Size(55, 17);
            zoomIndicator.Text = "Zoom: 14";
            zoomIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textArea
            // 
            textArea.AcceptsReturn = true;
            textArea.AcceptsTab = true;
            textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textArea.Dock = System.Windows.Forms.DockStyle.Fill;
            textArea.Location = new System.Drawing.Point(0, 24);
            textArea.Multiline = true;
            textArea.Name = "textArea";
            textArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textArea.Size = new System.Drawing.Size(800, 554);
            textArea.TabIndex = 2;
            textArea.TextChanged += TextAreaTextChanged;
            textArea.MouseWheel += TextAreaMouseWheel;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(textArea);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            MinimumSize = new System.Drawing.Size(500, 400);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
