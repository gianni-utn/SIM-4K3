namespace TP4
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
            this.txtSemanasASimular = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIteracionesAPartirDe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grdSimulacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSemanasASimular
            // 
            this.txtSemanasASimular.Location = new System.Drawing.Point(180, 23);
            this.txtSemanasASimular.Name = "txtSemanasASimular";
            this.txtSemanasASimular.Size = new System.Drawing.Size(60, 20);
            this.txtSemanasASimular.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cantidad de semanas a simular";
            // 
            // txtIteracionesAPartirDe
            // 
            this.txtIteracionesAPartirDe.Location = new System.Drawing.Point(524, 23);
            this.txtIteracionesAPartirDe.Name = "txtIteracionesAPartirDe";
            this.txtIteracionesAPartirDe.Size = new System.Drawing.Size(41, 20);
            this.txtIteracionesAPartirDe.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Mostrar ";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Location = new System.Drawing.Point(329, 23);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(40, 20);
            this.txtIteraciones.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "semanas a partir de la semana";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 31);
            this.button1.TabIndex = 30;
            this.button1.Text = "Simular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdSimulacion
            // 
            this.grdSimulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSimulacion.Location = new System.Drawing.Point(24, 62);
            this.grdSimulacion.Name = "grdSimulacion";
            this.grdSimulacion.Size = new System.Drawing.Size(1113, 345);
            this.grdSimulacion.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 450);
            this.Controls.Add(this.grdSimulacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIteraciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIteracionesAPartirDe);
            this.Controls.Add(this.txtSemanasASimular);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdSimulacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSemanasASimular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIteracionesAPartirDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdSimulacion;
    }
}

