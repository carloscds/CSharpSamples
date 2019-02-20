namespace CentralizarJanela
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirJanelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroDaTelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroDaJanelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirJanelaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirJanelaToolStripMenuItem
            // 
            this.abrirJanelaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centroDaTelaToolStripMenuItem,
            this.centroDaJanelaToolStripMenuItem});
            this.abrirJanelaToolStripMenuItem.Name = "abrirJanelaToolStripMenuItem";
            this.abrirJanelaToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.abrirJanelaToolStripMenuItem.Text = "Abrir Janela";
            // 
            // centroDaTelaToolStripMenuItem
            // 
            this.centroDaTelaToolStripMenuItem.Name = "centroDaTelaToolStripMenuItem";
            this.centroDaTelaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.centroDaTelaToolStripMenuItem.Text = "Centro da Tela";
            this.centroDaTelaToolStripMenuItem.Click += new System.EventHandler(this.centroDaTelaToolStripMenuItem_Click);
            // 
            // centroDaJanelaToolStripMenuItem
            // 
            this.centroDaJanelaToolStripMenuItem.Name = "centroDaJanelaToolStripMenuItem";
            this.centroDaJanelaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.centroDaJanelaToolStripMenuItem.Text = "Centro da Janela";
            this.centroDaJanelaToolStripMenuItem.Click += new System.EventHandler(this.centroDaJanelaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algumas dicas simples de alinhamento de janela, mas que pode ser aplicado a qualq" +
    "uer controle";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Centralizar Janela";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirJanelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroDaTelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroDaJanelaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

