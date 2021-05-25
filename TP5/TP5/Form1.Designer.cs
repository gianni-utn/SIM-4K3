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
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "filas a partir de la hora";
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
            this.txtIteracionesAPartirDe.Location = new System.Drawing.Point(785, 12);
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
            this.label2.Size = new System.Drawing.Size(219, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cantidad de semanas a simular:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 729);
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
    }
}

