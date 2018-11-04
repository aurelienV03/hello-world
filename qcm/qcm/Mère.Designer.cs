namespace qcm
{
    partial class Mère
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ValiderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fenêtreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mosaiquehorizontaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mosaiqueverticaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aproposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.fenêtreToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1202, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.fermerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ValiderToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.nouveauToolStripMenuItem.Text = "&Ouvrir";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.fermerToolStripMenuItem.Text = "Fe&rmer";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 6);
            // 
            // ValiderToolStripMenuItem
            // 
            this.ValiderToolStripMenuItem.Name = "ValiderToolStripMenuItem";
            this.ValiderToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.ValiderToolStripMenuItem.Text = "&Valider";
            this.ValiderToolStripMenuItem.Click += new System.EventHandler(this.ValiderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // fenêtreToolStripMenuItem
            // 
            this.fenêtreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.mosaiquehorizontaleToolStripMenuItem,
            this.mosaiqueverticaleToolStripMenuItem});
            this.fenêtreToolStripMenuItem.Name = "fenêtreToolStripMenuItem";
            this.fenêtreToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fenêtreToolStripMenuItem.Text = "F&enêtre";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // mosaiquehorizontaleToolStripMenuItem
            // 
            this.mosaiquehorizontaleToolStripMenuItem.Name = "mosaiquehorizontaleToolStripMenuItem";
            this.mosaiquehorizontaleToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.mosaiquehorizontaleToolStripMenuItem.Text = "Mosaique &horizontale";
            this.mosaiquehorizontaleToolStripMenuItem.Click += new System.EventHandler(this.mosaiquehorizontaleToolStripMenuItem_Click);
            // 
            // mosaiqueverticaleToolStripMenuItem
            // 
            this.mosaiqueverticaleToolStripMenuItem.Name = "mosaiqueverticaleToolStripMenuItem";
            this.mosaiqueverticaleToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.mosaiqueverticaleToolStripMenuItem.Text = "Mosaique &verticale";
            this.mosaiqueverticaleToolStripMenuItem.Click += new System.EventHandler(this.mosaiqueverticaleToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aproposToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "&Aide";
            // 
            // aproposToolStripMenuItem
            // 
            this.aproposToolStripMenuItem.Name = "aproposToolStripMenuItem";
            this.aproposToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aproposToolStripMenuItem.Text = "A &propos...";
            this.aproposToolStripMenuItem.Click += new System.EventHandler(this.aproposToolStripMenuItem_Click);
            // 
            // Mère
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 716);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mère";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QCM";
            this.Load += new System.EventHandler(this.Mère_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fenêtreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaiquehorizontaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaiqueverticaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aproposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValiderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

