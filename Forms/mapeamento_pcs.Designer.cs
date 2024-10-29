namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    partial class mapeamento_pcs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Cempresa = new System.Windows.Forms.ComboBox();
            this.LabelCMap = new System.Windows.Forms.Label();
            this.Cfiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BotaoFiltrar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lsetor = new System.Windows.Forms.Label();
            this.MaskBox = new System.Windows.Forms.MaskedTextBox();
            this.CombSetores = new System.Windows.Forms.ComboBox();
            this.EnterTab = new System.Windows.Forms.Button();
            this.quantidadeSistemas = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Lfiltro = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeSistemas)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Lfiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(400, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 637);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.05556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.94444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 388F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.quantidadeSistemas, 4, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 95);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Cempresa);
            this.panel3.Controls.Add(this.LabelCMap);
            this.panel3.Controls.Add(this.Cfiltro);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.BotaoFiltrar);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.MaximumSize = new System.Drawing.Size(380, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 118);
            this.panel3.TabIndex = 14;
            // 
            // Cempresa
            // 
            this.Cempresa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cempresa.FormattingEnabled = true;
            this.Cempresa.Items.AddRange(new object[] {
            "Clube Maxivida",
            "Maximidia"});
            this.Cempresa.Location = new System.Drawing.Point(184, 18);
            this.Cempresa.Name = "Cempresa";
            this.Cempresa.Size = new System.Drawing.Size(17, 21);
            this.Cempresa.TabIndex = 5;
            // 
            // LabelCMap
            // 
            this.LabelCMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelCMap.AutoSize = true;
            this.LabelCMap.BackColor = System.Drawing.Color.Transparent;
            this.LabelCMap.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCMap.Location = new System.Drawing.Point(3, 17);
            this.LabelCMap.Name = "LabelCMap";
            this.LabelCMap.Size = new System.Drawing.Size(175, 22);
            this.LabelCMap.TabIndex = 4;
            this.LabelCMap.Text = "Selecione empresa";
            // 
            // Cfiltro
            // 
            this.Cfiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cfiltro.FormattingEnabled = true;
            this.Cfiltro.Items.AddRange(new object[] {
            "setores",
            "pa",
            "TALK_id",
            "patrimonio"});
            this.Cfiltro.Location = new System.Drawing.Point(184, 58);
            this.Cfiltro.Name = "Cfiltro";
            this.Cfiltro.Size = new System.Drawing.Size(17, 21);
            this.Cfiltro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F);
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Procurar por :";
            // 
            // BotaoFiltrar
            // 
            this.BotaoFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoFiltrar.Location = new System.Drawing.Point(198, 85);
            this.BotaoFiltrar.Name = "BotaoFiltrar";
            this.BotaoFiltrar.Size = new System.Drawing.Size(0, 23);
            this.BotaoFiltrar.TabIndex = 6;
            this.BotaoFiltrar.Text = "Enter";
            this.BotaoFiltrar.UseVisualStyleBackColor = true;
            this.BotaoFiltrar.Click += new System.EventHandler(this.BotaoFiltrar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.Lsetor);
            this.panel4.Controls.Add(this.MaskBox);
            this.panel4.Controls.Add(this.CombSetores);
            this.panel4.Controls.Add(this.EnterTab);
            this.panel4.Location = new System.Drawing.Point(268, 6);
            this.panel4.MaximumSize = new System.Drawing.Size(500, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 118);
            this.panel4.TabIndex = 15;
            this.panel4.Visible = false;
            // 
            // Lsetor
            // 
            this.Lsetor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lsetor.AutoSize = true;
            this.Lsetor.BackColor = System.Drawing.Color.Transparent;
            this.Lsetor.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsetor.Location = new System.Drawing.Point(3, 22);
            this.Lsetor.Name = "Lsetor";
            this.Lsetor.Size = new System.Drawing.Size(166, 22);
            this.Lsetor.TabIndex = 9;
            this.Lsetor.Text = "selecione o setor :";
            this.Lsetor.Visible = false;
            // 
            // MaskBox
            // 
            this.MaskBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaskBox.Location = new System.Drawing.Point(183, 23);
            this.MaskBox.Mask = "0000000";
            this.MaskBox.Name = "MaskBox";
            this.MaskBox.Size = new System.Drawing.Size(87, 20);
            this.MaskBox.TabIndex = 10;
            this.MaskBox.Visible = false;
            // 
            // CombSetores
            // 
            this.CombSetores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CombSetores.FormattingEnabled = true;
            this.CombSetores.Location = new System.Drawing.Point(183, 22);
            this.CombSetores.Name = "CombSetores";
            this.CombSetores.Size = new System.Drawing.Size(88, 21);
            this.CombSetores.TabIndex = 8;
            this.CombSetores.Visible = false;
            // 
            // EnterTab
            // 
            this.EnterTab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnterTab.Location = new System.Drawing.Point(218, 58);
            this.EnterTab.Name = "EnterTab";
            this.EnterTab.Size = new System.Drawing.Size(69, 28);
            this.EnterTab.TabIndex = 12;
            this.EnterTab.Text = "Enter";
            this.EnterTab.UseVisualStyleBackColor = true;
            this.EnterTab.Visible = false;
            this.EnterTab.Click += new System.EventHandler(this.EnterTab_Click);
            // 
            // quantidadeSistemas
            // 
            this.quantidadeSistemas.AllowUserToAddRows = false;
            this.quantidadeSistemas.AllowUserToDeleteRows = false;
            this.quantidadeSistemas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.quantidadeSistemas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.quantidadeSistemas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.quantidadeSistemas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.quantidadeSistemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quantidadeSistemas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quantidadeSistemas.Location = new System.Drawing.Point(571, 6);
            this.quantidadeSistemas.MaximumSize = new System.Drawing.Size(600, 118);
            this.quantidadeSistemas.Name = "quantidadeSistemas";
            this.quantidadeSistemas.ReadOnly = true;
            this.quantidadeSistemas.RowHeadersVisible = false;
            this.quantidadeSistemas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.quantidadeSistemas.Size = new System.Drawing.Size(291, 118);
            this.quantidadeSistemas.TabIndex = 17;
            this.quantidadeSistemas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quantidadeSistemas_CellContentClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.checkBox1);
            this.panel8.Location = new System.Drawing.Point(27, 228);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1013, 25);
            this.panel8.TabIndex = 23;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(440, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 19);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Gravar a tabela em csv";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(344, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(379, 35);
            this.panel7.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mapeamento de Computadores";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Location = new System.Drawing.Point(260, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 0);
            this.panel6.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Location = new System.Drawing.Point(27, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 347);
            this.panel2.TabIndex = 13;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1009, 343);
            this.dataGridView.TabIndex = 0;
            // 
            // Lfiltro
            // 
            this.Lfiltro.AutoSize = true;
            this.Lfiltro.BackColor = System.Drawing.Color.Transparent;
            this.Lfiltro.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lfiltro.Location = new System.Drawing.Point(24, 340);
            this.Lfiltro.Name = "Lfiltro";
            this.Lfiltro.Size = new System.Drawing.Size(0, 22);
            this.Lfiltro.TabIndex = 11;
            this.Lfiltro.Visible = false;
            // 
            // mapeamento_pcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1058, 637);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1074, 675);
            this.Name = "mapeamento_pcs";
            this.Text = "mapeamento_pcs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeSistemas)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label Lfiltro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lsetor;
        private System.Windows.Forms.MaskedTextBox MaskBox;
        private System.Windows.Forms.ComboBox CombSetores;
        private System.Windows.Forms.Button EnterTab;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox Cempresa;
        private System.Windows.Forms.Label LabelCMap;
        private System.Windows.Forms.ComboBox Cfiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BotaoFiltrar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView quantidadeSistemas;
    }
}