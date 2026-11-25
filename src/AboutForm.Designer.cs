namespace SimpleNotes
{
    partial class AboutForm
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
            picture = new System.Windows.Forms.PictureBox();
            titleLabel = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            link = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Location = new System.Drawing.Point(160, 20);
            picture.Name = "picture";
            picture.Size = new System.Drawing.Size(80, 80);
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(20, 110);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(360, 30);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Simple Notes";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            versionLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            versionLabel.Location = new System.Drawing.Point(20, 145);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new System.Drawing.Size(360, 20);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "Versão 1.0.0";
            versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Location = new System.Drawing.Point(40, 180);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(320, 50);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Um simples app de bloco de notas feito com intuito de estudar C#.";
            descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // link
            // 
            link.Location = new System.Drawing.Point(20, 250);
            link.Name = "link";
            link.Size = new System.Drawing.Size(360, 20);
            link.TabIndex = 4;
            link.TabStop = true;
            link.Text = "Ver projeto no GitHub";
            link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            link.LinkClicked += LinkLinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 350);
            Controls.Add(link);
            Controls.Add(descriptionLabel);
            Controls.Add(versionLabel);
            Controls.Add(titleLabel);
            Controls.Add(picture);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Sobre";
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.LinkLabel link;
    }
}
