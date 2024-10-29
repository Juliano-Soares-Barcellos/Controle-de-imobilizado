namespace ProjetoDeControleDeMateriaisMandadoParaConserto.Forms
{
    partial class FiltroMes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroMes));
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Tabela = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.BtnGrafico = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LbVerifica = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ano2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Carregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxGrafico = new System.Windows.Forms.ComboBox();
            this.ComboMes2 = new System.Windows.Forms.ComboBox();
            this.TextAno = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbAté = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboMes1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.graficoBox = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabela)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel2.BackgroundImage = global::ProjetoDeControleDeMateriaisMandadoParaConserto.Properties.Resources.m___Cópia__2_;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.Tabela);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(1, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 655);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(199, 608);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Gravar Dados";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 545);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(266, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Total de vezes que estes produtos foram consertados :";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(386, 495);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "label7";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 448);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "label7";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "produtos Consertado neste mês :";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 448);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Total de produtos na garantia";
            this.label13.Visible = false;
            // 
            // Tabela
            // 
            this.Tabela.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabela.Location = new System.Drawing.Point(3, 257);
            this.Tabela.Name = "Tabela";
            this.Tabela.Size = new System.Drawing.Size(485, 174);
            this.Tabela.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Procurar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.comboBox1.Location = new System.Drawing.Point(218, 163);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox2.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.comboBox2.Location = new System.Drawing.Point(218, 105);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(68, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Escolha o Ano :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(68, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 19);
            this.label15.TabIndex = 1;
            this.label15.Text = "Escolha o mes :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(121, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(244, 32);
            this.label16.TabIndex = 0;
            this.label16.Text = "Produtos no mês:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::ProjetoDeControleDeMateriaisMandadoParaConserto.Properties.Resources.m__Busca_computador;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.BtnGrafico);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.LbVerifica);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 116);
            this.panel3.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Enabled = false;
            this.label17.Font = new System.Drawing.Font("Eras Medium ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(54, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(632, 42);
            this.label17.TabIndex = 7;
            this.label17.Text = "Escolha uma das Opcões";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnGrafico
            // 
            this.BtnGrafico.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnGrafico.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.BtnGrafico.Location = new System.Drawing.Point(430, 76);
            this.BtnGrafico.Name = "BtnGrafico";
            this.BtnGrafico.Size = new System.Drawing.Size(186, 32);
            this.BtnGrafico.TabIndex = 6;
            this.BtnGrafico.Text = "Verificar por Gráficos";
            this.BtnGrafico.UseVisualStyleBackColor = true;
            this.BtnGrafico.Click += new System.EventHandler(this.testbtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(152, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Verificar  Materiais Por Meses";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LbVerifica
            // 
            this.LbVerifica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LbVerifica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbVerifica.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbVerifica.Location = new System.Drawing.Point(131, -361);
            this.LbVerifica.Name = "LbVerifica";
            this.LbVerifica.Size = new System.Drawing.Size(432, 42);
            this.LbVerifica.TabIndex = 4;
            this.LbVerifica.Text = "Verificar Consertos";
            this.LbVerifica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = global::ProjetoDeControleDeMateriaisMandadoParaConserto.Properties.Resources.m__Busca_computador;
            this.panel1.Controls.Add(this.Carregar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxGrafico);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.graficoBox);
            this.panel1.Controls.Add(this.Ano2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ComboMes2);
            this.panel1.Controls.Add(this.TextAno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LbAté);
            this.panel1.Controls.Add(this.ComboMes1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 626);
            this.panel1.TabIndex = 5;
            // 
            // Ano2
            // 
            this.Ano2.Location = new System.Drawing.Point(655, 64);
            this.Ano2.Mask = "####";
            this.Ano2.Name = "Ano2";
            this.Ano2.Size = new System.Drawing.Size(30, 20);
            this.Ano2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(592, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ano :";
            // 
            // Carregar
            // 
            this.Carregar.Location = new System.Drawing.Point(343, 157);
            this.Carregar.Name = "Carregar";
            this.Carregar.Size = new System.Drawing.Size(96, 28);
            this.Carregar.TabIndex = 15;
            this.Carregar.Text = "Carregar";
            this.Carregar.UseVisualStyleBackColor = true;
            this.Carregar.Click += new System.EventHandler(this.Carregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(180, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Selecione o tipo de gráfico :";
            // 
            // cbxGrafico
            // 
            this.cbxGrafico.FormattingEnabled = true;
            this.cbxGrafico.Items.AddRange(new object[] {
            "Pie",
            "Column",
            "Line",
            "Spline",
            "Area",
            "Bar",
            "BoxPlot",
            "Bubble",
            "Candlestick",
            "Doughnut",
            "ErrorBar",
            "FastLine",
            "FastPoint",
            "Funnel",
            "Kagi",
            "Point",
            "PointAndfigure",
            "Polar",
            "Pyramid",
            "Radar",
            "Range",
            "RangeBar",
            "RangeColumn",
            "Renko",
            "SplineArea",
            "SplineRange",
            "StackedArea",
            "StackedArea100",
            "StackedBar",
            "StackedBar100",
            "StackedColumn",
            "StackedColumn100",
            "StepLine",
            "Stock",
            "ThreeLineBreack",
            "Area",
            "Spline",
            "Line"});
            this.cbxGrafico.Location = new System.Drawing.Point(417, 113);
            this.cbxGrafico.Name = "cbxGrafico";
            this.cbxGrafico.Size = new System.Drawing.Size(121, 21);
            this.cbxGrafico.TabIndex = 13;
            this.cbxGrafico.Text = "Selecione";
            // 
            // ComboMes2
            // 
            this.ComboMes2.FormattingEnabled = true;
            this.ComboMes2.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.ComboMes2.Location = new System.Drawing.Point(456, 63);
            this.ComboMes2.Name = "ComboMes2";
            this.ComboMes2.Size = new System.Drawing.Size(121, 21);
            this.ComboMes2.TabIndex = 12;
            this.ComboMes2.Text = "Mês";
            // 
            // TextAno
            // 
            this.TextAno.Location = new System.Drawing.Point(349, 64);
            this.TextAno.Mask = "####";
            this.TextAno.Name = "TextAno";
            this.TextAno.Size = new System.Drawing.Size(29, 20);
            this.TextAno.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ano :";
            // 
            // LbAté
            // 
            this.LbAté.AutoSize = true;
            this.LbAté.BackColor = System.Drawing.Color.Transparent;
            this.LbAté.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAté.Location = new System.Drawing.Point(397, 61);
            this.LbAté.Name = "LbAté";
            this.LbAté.Size = new System.Drawing.Size(40, 23);
            this.LbAté.TabIndex = 9;
            this.LbAté.Text = "Até :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 46);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grafico";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboMes1
            // 
            this.ComboMes1.FormattingEnabled = true;
            this.ComboMes1.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.ComboMes1.Location = new System.Drawing.Point(150, 63);
            this.ComboMes1.Name = "ComboMes1";
            this.ComboMes1.Size = new System.Drawing.Size(121, 21);
            this.ComboMes1.TabIndex = 3;
            this.ComboMes1.Text = "Mês";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escolha De :";
            // 
            // graficoBox
            // 
            chartArea1.Name = "ChartArea1";
            this.graficoBox.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graficoBox.Legends.Add(legend1);
            this.graficoBox.Location = new System.Drawing.Point(0, 190);
            this.graficoBox.Name = "graficoBox";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graficoBox.Series.Add(series1);
            this.graficoBox.Size = new System.Drawing.Size(750, 432);
            this.graficoBox.TabIndex = 0;
            this.graficoBox.Text = "chart1";
            // 
            // FiltroMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiltroMes";
            this.Text = "FiltroMes2";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabela)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView Tabela;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnGrafico;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LbVerifica;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoBox;
        private System.Windows.Forms.ComboBox ComboMes2;
        private System.Windows.Forms.MaskedTextBox TextAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbAté;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboMes1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxGrafico;
        private System.Windows.Forms.Button Carregar;
        private System.Windows.Forms.MaskedTextBox Ano2;
        private System.Windows.Forms.Label label5;
    }
}