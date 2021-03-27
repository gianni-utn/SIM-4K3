namespace SIM_4K3_TP1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cboMetodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_semilla = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_m = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_c = new System.Windows.Forms.TextBox();
            this.lbl_c = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txt_a = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grdResultado = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCantIntervalos = new System.Windows.Forms.ComboBox();
            this.btnRealizarTest = new System.Windows.Forms.Button();
            this.grdPuntoB = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMetodo
            // 
            this.cboMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodo.FormattingEnabled = true;
            this.cboMetodo.Items.AddRange(new object[] {
            "Congruencial lineal",
            "Congruencial multiplicativo",
            "Función del lenguaje utilizado"});
            this.cboMetodo.Location = new System.Drawing.Point(80, 28);
            this.cboMetodo.Name = "cboMetodo";
            this.cboMetodo.Size = new System.Drawing.Size(169, 21);
            this.cboMetodo.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Semilla";
            // 
            // txt_semilla
            // 
            this.txt_semilla.Location = new System.Drawing.Point(94, 55);
            this.txt_semilla.Name = "txt_semilla";
            this.txt_semilla.Size = new System.Drawing.Size(155, 20);
            this.txt_semilla.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "m";
            // 
            // txt_m
            // 
            this.txt_m.Location = new System.Drawing.Point(94, 107);
            this.txt_m.Name = "txt_m";
            this.txt_m.Size = new System.Drawing.Size(155, 20);
            this.txt_m.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "a";
            // 
            // txt_c
            // 
            this.txt_c.Location = new System.Drawing.Point(94, 133);
            this.txt_c.Name = "txt_c";
            this.txt_c.Size = new System.Drawing.Size(155, 20);
            this.txt_c.TabIndex = 20;
            // 
            // lbl_c
            // 
            this.lbl_c.AutoSize = true;
            this.lbl_c.Location = new System.Drawing.Point(34, 136);
            this.lbl_c.Name = "lbl_c";
            this.lbl_c.Size = new System.Drawing.Size(13, 13);
            this.lbl_c.TabIndex = 24;
            this.lbl_c.Text = "c";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(161, 171);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(88, 20);
            this.txtCantidad.TabIndex = 21;
            this.txtCantidad.Text = "1000000";
            // 
            // txt_a
            // 
            this.txt_a.Location = new System.Drawing.Point(94, 81);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(155, 20);
            this.txt_a.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(34, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 32);
            this.label6.TabIndex = 25;
            this.label6.Text = "Cantidad por primera vez";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Metodo";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(37, 221);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(212, 32);
            this.btnCalcular.TabIndex = 26;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(37, 271);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(212, 37);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // grdResultado
            // 
            this.grdResultado.AllowUserToAddRows = false;
            this.grdResultado.AllowUserToDeleteRows = false;
            this.grdResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultado.Location = new System.Drawing.Point(281, 28);
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.ReadOnly = true;
            this.grdResultado.RowHeadersWidth = 51;
            this.grdResultado.Size = new System.Drawing.Size(273, 386);
            this.grdResultado.TabIndex = 28;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "67144 - Maria Belén Campos Mantelli",
            "68213 - Franco Fadini",
            "68214 - Matias Hospital",
            "67781 - Facundo Agustin Mallia",
            "64813 - Gianni Vildoza"});
            this.listBox1.Location = new System.Drawing.Point(40, 345);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(213, 69);
            this.listBox1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Integrantes Grupo 8";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(576, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Cantidad de intervalos";
            // 
            // cboCantIntervalos
            // 
            this.cboCantIntervalos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCantIntervalos.FormattingEnabled = true;
            this.cboCantIntervalos.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cboCantIntervalos.Location = new System.Drawing.Point(694, 55);
            this.cboCantIntervalos.Name = "cboCantIntervalos";
            this.cboCantIntervalos.Size = new System.Drawing.Size(121, 21);
            this.cboCantIntervalos.TabIndex = 30;
            // 
            // btnRealizarTest
            // 
            this.btnRealizarTest.Location = new System.Drawing.Point(840, 55);
            this.btnRealizarTest.Name = "btnRealizarTest";
            this.btnRealizarTest.Size = new System.Drawing.Size(88, 21);
            this.btnRealizarTest.TabIndex = 31;
            this.btnRealizarTest.Text = "Realizar TEST";
            this.btnRealizarTest.UseVisualStyleBackColor = true;
            this.btnRealizarTest.Click += new System.EventHandler(this.btnRealizarTest_Click);
            // 
            // grdPuntoB
            // 
            this.grdPuntoB.AllowUserToAddRows = false;
            this.grdPuntoB.AllowUserToDeleteRows = false;
            this.grdPuntoB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPuntoB.Location = new System.Drawing.Point(579, 87);
            this.grdPuntoB.Name = "grdPuntoB";
            this.grdPuntoB.ReadOnly = true;
            this.grdPuntoB.RowHeadersWidth = 51;
            this.grdPuntoB.Size = new System.Drawing.Size(768, 327);
            this.grdPuntoB.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(576, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Prueba de Ji-Cuadrada";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // grafico
            // 
            chartArea1.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafico.Legends.Add(legend1);
            this.grafico.Location = new System.Drawing.Point(41, 434);
            this.grafico.Name = "grafico";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafico.Series.Add(series1);
            this.grafico.Size = new System.Drawing.Size(1307, 252);
            this.grafico.TabIndex = 36;
            this.grafico.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 729);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grdPuntoB);
            this.Controls.Add(this.btnRealizarTest);
            this.Controls.Add(this.cboCantIntervalos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboMetodo);
            this.Controls.Add(this.grdResultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_m);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_semilla);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txt_c);
            this.Controls.Add(this.txt_a);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_c);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuntoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMetodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_semilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_m;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_c;
        private System.Windows.Forms.Label lbl_c;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txt_a;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView grdResultado;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCantIntervalos;
        private System.Windows.Forms.Button btnRealizarTest;
        private System.Windows.Forms.DataGridView grdPuntoB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
    }
}

