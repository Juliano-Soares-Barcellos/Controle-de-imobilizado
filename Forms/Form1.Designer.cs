namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.computadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patrimonioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imobilizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarComputadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telaDeCadastramentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fonesEHeadsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procurarFoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procurarPorCodigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porMêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirArquivoCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarArquivoAntesConsertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirFoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(751, 599);
            this.panel1.MinimumSize = new System.Drawing.Size(751, 599);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 599);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computadorToolStripMenuItem,
            this.fonesEHeadsetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // computadorToolStripMenuItem
            // 
            this.computadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telaDeCadastramentoToolStripMenuItem,
            this.cadastrarComputadorToolStripMenuItem,
            this.patrimonioToolStripMenuItem,
            this.imobilizadosToolStripMenuItem});
            this.computadorToolStripMenuItem.Name = "computadorToolStripMenuItem";
            this.computadorToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.computadorToolStripMenuItem.Text = "Computador";
            // 
            // patrimonioToolStripMenuItem
            // 
            this.patrimonioToolStripMenuItem.Name = "patrimonioToolStripMenuItem";
            this.patrimonioToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.patrimonioToolStripMenuItem.Text = "Patrimonio";
            this.patrimonioToolStripMenuItem.Click += new System.EventHandler(this.patrimonioToolStripMenuItem_Click);
            // 
            // imobilizadosToolStripMenuItem
            // 
            this.imobilizadosToolStripMenuItem.Name = "imobilizadosToolStripMenuItem";
            this.imobilizadosToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.imobilizadosToolStripMenuItem.Text = "Imobilizados";
            this.imobilizadosToolStripMenuItem.Click += new System.EventHandler(this.imobilizadosToolStripMenuItem_Click);
            // 
            // cadastrarComputadorToolStripMenuItem
            // 
            this.cadastrarComputadorToolStripMenuItem.Name = "cadastrarComputadorToolStripMenuItem";
            this.cadastrarComputadorToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cadastrarComputadorToolStripMenuItem.Text = "Cadastrar Computador";
            this.cadastrarComputadorToolStripMenuItem.Click += new System.EventHandler(this.cadastrarComputadorToolStripMenuItem_Click);
            // 
            // telaDeCadastramentoToolStripMenuItem
            // 
            this.telaDeCadastramentoToolStripMenuItem.Name = "telaDeCadastramentoToolStripMenuItem";
            this.telaDeCadastramentoToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.telaDeCadastramentoToolStripMenuItem.Text = "Conserto";
            this.telaDeCadastramentoToolStripMenuItem.Click += new System.EventHandler(this.telaDeCadastramentoToolStripMenuItem_Click);
            // 
            // fonesEHeadsetToolStripMenuItem
            // 
            this.fonesEHeadsetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procurarFoneToolStripMenuItem,
            this.arquivoCsvToolStripMenuItem,
            this.inserirFoneToolStripMenuItem});
            this.fonesEHeadsetToolStripMenuItem.Name = "fonesEHeadsetToolStripMenuItem";
            this.fonesEHeadsetToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.fonesEHeadsetToolStripMenuItem.Text = "Fones e Headset";
            // 
            // procurarFoneToolStripMenuItem
            // 
            this.procurarFoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procurarPorCodigoToolStripMenuItem,
            this.porMêsToolStripMenuItem});
            this.procurarFoneToolStripMenuItem.Name = "procurarFoneToolStripMenuItem";
            this.procurarFoneToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.procurarFoneToolStripMenuItem.Text = "Procurar Fone";
            // 
            // procurarPorCodigoToolStripMenuItem
            // 
            this.procurarPorCodigoToolStripMenuItem.Name = "procurarPorCodigoToolStripMenuItem";
            this.procurarPorCodigoToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.procurarPorCodigoToolStripMenuItem.Text = "Por Codigo";
            this.procurarPorCodigoToolStripMenuItem.Click += new System.EventHandler(this.procurarPorCodigoToolStripMenuItem_Click);
            // 
            // porMêsToolStripMenuItem
            // 
            this.porMêsToolStripMenuItem.Name = "porMêsToolStripMenuItem";
            this.porMêsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.porMêsToolStripMenuItem.Text = "Por mês";
            this.porMêsToolStripMenuItem.Click += new System.EventHandler(this.porMêsToolStripMenuItem_Click);
            // 
            // arquivoCsvToolStripMenuItem
            // 
            this.arquivoCsvToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirArquivoCsvToolStripMenuItem,
            this.criarArquivoAntesConsertoToolStripMenuItem});
            this.arquivoCsvToolStripMenuItem.Name = "arquivoCsvToolStripMenuItem";
            this.arquivoCsvToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.arquivoCsvToolStripMenuItem.Text = "Arquivo ";
            this.arquivoCsvToolStripMenuItem.Click += new System.EventHandler(this.arquivoCsvToolStripMenuItem_Click);
            // 
            // inserirArquivoCsvToolStripMenuItem
            // 
            this.inserirArquivoCsvToolStripMenuItem.Name = "inserirArquivoCsvToolStripMenuItem";
            this.inserirArquivoCsvToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.inserirArquivoCsvToolStripMenuItem.Text = "Inserir Arquivo csv";
            this.inserirArquivoCsvToolStripMenuItem.Click += new System.EventHandler(this.inserirArquivoCsvToolStripMenuItem_Click);
            // 
            // criarArquivoAntesConsertoToolStripMenuItem
            // 
            this.criarArquivoAntesConsertoToolStripMenuItem.Name = "criarArquivoAntesConsertoToolStripMenuItem";
            this.criarArquivoAntesConsertoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.criarArquivoAntesConsertoToolStripMenuItem.Text = "Criar Arquivo antes Conserto";
            this.criarArquivoAntesConsertoToolStripMenuItem.Click += new System.EventHandler(this.criarArquivoAntesConsertoToolStripMenuItem_Click);
            // 
            // inserirFoneToolStripMenuItem
            // 
            this.inserirFoneToolStripMenuItem.Name = "inserirFoneToolStripMenuItem";
            this.inserirFoneToolStripMenuItem.ShowShortcutKeys = false;
            this.inserirFoneToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.inserirFoneToolStripMenuItem.Text = "Inserir fone ";
            this.inserirFoneToolStripMenuItem.Click += new System.EventHandler(this.inserirFoneToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 561);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(751, 599);
            this.MinimumSize = new System.Drawing.Size(751, 599);
            this.Name = "Form1";
            this.Text = "Bem Vindo ao sistema de  gerenciamentos  de materiais de TI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem computadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fonesEHeadsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procurarFoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procurarPorCodigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porMêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirArquivoCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarArquivoAntesConsertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirFoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patrimonioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imobilizadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarComputadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telaDeCadastramentoToolStripMenuItem;
    }
}