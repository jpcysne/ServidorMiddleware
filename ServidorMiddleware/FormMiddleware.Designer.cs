namespace ServidorMiddleware
{
    partial class FormMiddleware
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
            this.IPTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConectarBotao = new System.Windows.Forms.Button();
            this.MemoriaTXT = new System.Windows.Forms.TextBox();
            this.CPUTXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Atualizar = new System.Windows.Forms.Button();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MEMBloqueioTXT = new System.Windows.Forms.TextBox();
            this.CPUBloqueioTXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CPUPossuiTXT = new System.Windows.Forms.TextBox();
            this.MEMPossuiTXT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BotaoBloqueio = new System.Windows.Forms.Button();
            this.BotaoMEMCPUAtual = new System.Windows.Forms.Button();
            this.BotaoRecurso = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CPURecursoTXT = new System.Windows.Forms.TextBox();
            this.MEMRecursoTXT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BuscarServidores = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxServidores = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ConectarOutroServ = new System.Windows.Forms.Button();
            this.IPOutroServTXT = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTXT
            // 
            this.IPTXT.Location = new System.Drawing.Point(129, 52);
            this.IPTXT.Name = "IPTXT";
            this.IPTXT.Size = new System.Drawing.Size(100, 20);
            this.IPTXT.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Atual do Servidor:";
            // 
            // ConectarBotao
            // 
            this.ConectarBotao.Location = new System.Drawing.Point(265, 50);
            this.ConectarBotao.Name = "ConectarBotao";
            this.ConectarBotao.Size = new System.Drawing.Size(75, 23);
            this.ConectarBotao.TabIndex = 2;
            this.ConectarBotao.Text = "Conectar";
            this.ConectarBotao.UseVisualStyleBackColor = true;
            this.ConectarBotao.Click += new System.EventHandler(this.ConectarBotao_Click);
            // 
            // MemoriaTXT
            // 
            this.MemoriaTXT.Location = new System.Drawing.Point(87, 60);
            this.MemoriaTXT.Name = "MemoriaTXT";
            this.MemoriaTXT.ReadOnly = true;
            this.MemoriaTXT.Size = new System.Drawing.Size(100, 20);
            this.MemoriaTXT.TabIndex = 3;
            // 
            // CPUTXT
            // 
            this.CPUTXT.Location = new System.Drawing.Point(87, 100);
            this.CPUTXT.Name = "CPUTXT";
            this.CPUTXT.ReadOnly = true;
            this.CPUTXT.Size = new System.Drawing.Size(100, 20);
            this.CPUTXT.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Memoria:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "CPU:";
            // 
            // Atualizar
            // 
            this.Atualizar.Location = new System.Drawing.Point(94, 137);
            this.Atualizar.Name = "Atualizar";
            this.Atualizar.Size = new System.Drawing.Size(75, 23);
            this.Atualizar.TabIndex = 7;
            this.Atualizar.Text = "Atualizar";
            this.Atualizar.UseVisualStyleBackColor = true;
            this.Atualizar.Click += new System.EventHandler(this.Atualizar_Click);
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(16, 192);
            this.txtServidor.Multiline = true;
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(249, 98);
            this.txtServidor.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Memoria / CPU Total";
            // 
            // MEMBloqueioTXT
            // 
            this.MEMBloqueioTXT.Location = new System.Drawing.Point(89, 40);
            this.MEMBloqueioTXT.Name = "MEMBloqueioTXT";
            this.MEMBloqueioTXT.ReadOnly = true;
            this.MEMBloqueioTXT.Size = new System.Drawing.Size(100, 20);
            this.MEMBloqueioTXT.TabIndex = 12;
            // 
            // CPUBloqueioTXT
            // 
            this.CPUBloqueioTXT.Location = new System.Drawing.Point(89, 84);
            this.CPUBloqueioTXT.Name = "CPUBloqueioTXT";
            this.CPUBloqueioTXT.ReadOnly = true;
            this.CPUBloqueioTXT.Size = new System.Drawing.Size(100, 20);
            this.CPUBloqueioTXT.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "CPU:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Memoria:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "CPU:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Memoria:";
            // 
            // CPUPossuiTXT
            // 
            this.CPUPossuiTXT.Location = new System.Drawing.Point(93, 84);
            this.CPUPossuiTXT.Name = "CPUPossuiTXT";
            this.CPUPossuiTXT.Size = new System.Drawing.Size(100, 20);
            this.CPUPossuiTXT.TabIndex = 17;
            // 
            // MEMPossuiTXT
            // 
            this.MEMPossuiTXT.Location = new System.Drawing.Point(93, 40);
            this.MEMPossuiTXT.Name = "MEMPossuiTXT";
            this.MEMPossuiTXT.Size = new System.Drawing.Size(100, 20);
            this.MEMPossuiTXT.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Bloqueio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Memoria/ CPU Possui";
            // 
            // BotaoBloqueio
            // 
            this.BotaoBloqueio.Location = new System.Drawing.Point(89, 117);
            this.BotaoBloqueio.Name = "BotaoBloqueio";
            this.BotaoBloqueio.Size = new System.Drawing.Size(75, 23);
            this.BotaoBloqueio.TabIndex = 23;
            this.BotaoBloqueio.Text = "Atualizar";
            this.BotaoBloqueio.UseVisualStyleBackColor = true;
            // 
            // BotaoMEMCPUAtual
            // 
            this.BotaoMEMCPUAtual.Location = new System.Drawing.Point(93, 120);
            this.BotaoMEMCPUAtual.Name = "BotaoMEMCPUAtual";
            this.BotaoMEMCPUAtual.Size = new System.Drawing.Size(75, 23);
            this.BotaoMEMCPUAtual.TabIndex = 24;
            this.BotaoMEMCPUAtual.Text = "Atualizar";
            this.BotaoMEMCPUAtual.UseVisualStyleBackColor = true;
            this.BotaoMEMCPUAtual.Click += new System.EventHandler(this.BotaoMEMCPUAtual_Click);
            // 
            // BotaoRecurso
            // 
            this.BotaoRecurso.Location = new System.Drawing.Point(7, 180);
            this.BotaoRecurso.Name = "BotaoRecurso";
            this.BotaoRecurso.Size = new System.Drawing.Size(75, 23);
            this.BotaoRecurso.TabIndex = 29;
            this.BotaoRecurso.Text = "Atualizar";
            this.BotaoRecurso.UseVisualStyleBackColor = true;
            this.BotaoRecurso.Click += new System.EventHandler(this.BotaoRecurso_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "CPU:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Memoria:";
            // 
            // CPURecursoTXT
            // 
            this.CPURecursoTXT.Location = new System.Drawing.Point(74, 144);
            this.CPURecursoTXT.Name = "CPURecursoTXT";
            this.CPURecursoTXT.Size = new System.Drawing.Size(100, 20);
            this.CPURecursoTXT.TabIndex = 26;
            // 
            // MEMRecursoTXT
            // 
            this.MEMRecursoTXT.Location = new System.Drawing.Point(74, 100);
            this.MEMRecursoTXT.Name = "MEMRecursoTXT";
            this.MEMRecursoTXT.Size = new System.Drawing.Size(100, 20);
            this.MEMRecursoTXT.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Recurso ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BuscarServidores);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.comboBoxServidores);
            this.panel1.Controls.Add(this.MEMRecursoTXT);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.CPURecursoTXT);
            this.panel1.Controls.Add(this.BotaoRecurso);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(363, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 230);
            this.panel1.TabIndex = 31;
            // 
            // BuscarServidores
            // 
            this.BuscarServidores.Location = new System.Drawing.Point(101, 180);
            this.BuscarServidores.Name = "BuscarServidores";
            this.BuscarServidores.Size = new System.Drawing.Size(75, 23);
            this.BuscarServidores.TabIndex = 33;
            this.BuscarServidores.Text = "Buscar";
            this.BuscarServidores.UseVisualStyleBackColor = true;
            this.BuscarServidores.Click += new System.EventHandler(this.BuscarServidores_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Servidores";
            // 
            // comboBoxServidores
            // 
            this.comboBoxServidores.FormattingEnabled = true;
            this.comboBoxServidores.Location = new System.Drawing.Point(68, 57);
            this.comboBoxServidores.Name = "comboBoxServidores";
            this.comboBoxServidores.Size = new System.Drawing.Size(121, 21);
            this.comboBoxServidores.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.MEMPossuiTXT);
            this.panel2.Controls.Add(this.BotaoMEMCPUAtual);
            this.panel2.Controls.Add(this.CPUPossuiTXT);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(571, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 157);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.MEMBloqueioTXT);
            this.panel3.Controls.Add(this.CPUBloqueioTXT);
            this.panel3.Controls.Add(this.BotaoBloqueio);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(363, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 157);
            this.panel3.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.MemoriaTXT);
            this.panel4.Controls.Add(this.CPUTXT);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.Atualizar);
            this.panel4.Location = new System.Drawing.Point(570, 192);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 173);
            this.panel4.TabIndex = 34;
            // 
            // ConectarOutroServ
            // 
            this.ConectarOutroServ.Location = new System.Drawing.Point(265, 100);
            this.ConectarOutroServ.Name = "ConectarOutroServ";
            this.ConectarOutroServ.Size = new System.Drawing.Size(75, 23);
            this.ConectarOutroServ.TabIndex = 35;
            this.ConectarOutroServ.Text = "Conectar";
            this.ConectarOutroServ.UseVisualStyleBackColor = true;
            this.ConectarOutroServ.Click += new System.EventHandler(this.ConectarOutroServ_Click);
            // 
            // IPOutroServTXT
            // 
            this.IPOutroServTXT.Location = new System.Drawing.Point(129, 100);
            this.IPOutroServTXT.Name = "IPOutroServTXT";
            this.IPOutroServTXT.Size = new System.Drawing.Size(100, 20);
            this.IPOutroServTXT.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "IP Outro Servidor:";
            // 
            // FormMiddleware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 434);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.IPOutroServTXT);
            this.Controls.Add(this.ConectarOutroServ);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.ConectarBotao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPTXT);
            this.Name = "FormMiddleware";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConectarBotao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Atualizar;
        public System.Windows.Forms.TextBox MemoriaTXT;
        public System.Windows.Forms.TextBox CPUTXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MEMBloqueioTXT;
        private System.Windows.Forms.TextBox CPUBloqueioTXT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BotaoBloqueio;
        private System.Windows.Forms.Button BotaoMEMCPUAtual;
        private System.Windows.Forms.Button BotaoRecurso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CPURecursoTXT;
        private System.Windows.Forms.TextBox MEMRecursoTXT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ConectarOutroServ;
        private System.Windows.Forms.TextBox IPOutroServTXT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Button BuscarServidores;
        public System.Windows.Forms.ComboBox comboBoxServidores;
        public System.Windows.Forms.TextBox CPUPossuiTXT;
        public System.Windows.Forms.TextBox MEMPossuiTXT;
    }
}

