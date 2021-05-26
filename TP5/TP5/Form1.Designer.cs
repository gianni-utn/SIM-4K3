namespace TP5
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
            this.grdSimulacion = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIteracionesAPartirDe = new System.Windows.Forms.TextBox();
            this.txtFilasASimular = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_prom_uso = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.prom_alumnos_regresan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSimulacion
            // 
            this.grdSimulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSimulacion.Location = new System.Drawing.Point(21, 51);
            this.grdSimulacion.Name = "grdSimulacion";
            this.grdSimulacion.Size = new System.Drawing.Size(1324, 604);
            this.grdSimulacion.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(1185, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 31);
            this.button1.TabIndex = 38;
            this.button1.Text = "Simular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(631, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "filas a partir del minuto";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtIteraciones.Location = new System.Drawing.Point(591, 12);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(40, 24);
            this.txtIteraciones.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(533, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Mostrar";
            // 
            // txtIteracionesAPartirDe
            // 
            this.txtIteracionesAPartirDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtIteracionesAPartirDe.Location = new System.Drawing.Point(787, 12);
            this.txtIteracionesAPartirDe.Name = "txtIteracionesAPartirDe";
            this.txtIteracionesAPartirDe.Size = new System.Drawing.Size(41, 24);
            this.txtIteracionesAPartirDe.TabIndex = 34;
            // 
            // txtFilasASimular
            // 
            this.txtFilasASimular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtFilasASimular.Location = new System.Drawing.Point(237, 12);
            this.txtFilasASimular.Name = "txtFilasASimular";
            this.txtFilasASimular.Size = new System.Drawing.Size(60, 24);
            this.txtFilasASimular.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cantidad de filas a simular:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(942, 671);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(369, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Capacidad de inscripción del sistema por hora en promedio (y por máquina):";
            // 
            // txt_prom_uso
            // 
            this.txt_prom_uso.AutoSize = true;
            this.txt_prom_uso.Location = new System.Drawing.Point(1310, 671);
            this.txt_prom_uso.Name = "txt_prom_uso";
            this.txt_prom_uso.Size = new System.Drawing.Size(25, 13);
            this.txt_prom_uso.TabIndex = 41;
            this.txt_prom_uso.Text = "      ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 671);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "% de alumnos que se van para regresar más tarde:";
            // 
            // prom_alumnos_regresan
            // 
            this.prom_alumnos_regresan.AutoSize = true;
            this.prom_alumnos_regresan.Location = new System.Drawing.Point(871, 671);
            this.prom_alumnos_regresan.Name = "prom_alumnos_regresan";
            this.prom_alumnos_regresan.Size = new System.Drawing.Size(19, 13);
            this.prom_alumnos_regresan.TabIndex = 43;
            this.prom_alumnos_regresan.Text = "    ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 729);
            this.Controls.Add(this.prom_alumnos_regresan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_prom_uso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdSimulacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIteraciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIteracionesAPartirDe);
            this.Controls.Add(this.txtFilasASimular);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSimulacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIteracionesAPartirDe;
        private System.Windows.Forms.TextBox txtFilasASimular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_prom_uso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label prom_alumnos_regresan;
    }
}

