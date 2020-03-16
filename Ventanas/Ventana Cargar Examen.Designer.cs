namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Cargar_Examen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoria = new System.Windows.Forms.ComboBox();
            this.dificultad = new System.Windows.Forms.ComboBox();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cargaExamen = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.conjunto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la Categoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione la Dificultad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccione la Cantidad:";
            // 
            // categoria
            // 
            this.categoria.FormattingEnabled = true;
            this.categoria.Location = new System.Drawing.Point(299, 112);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(170, 21);
            this.categoria.TabIndex = 3;
            // 
            // dificultad
            // 
            this.dificultad.FormattingEnabled = true;
            this.dificultad.Location = new System.Drawing.Point(299, 174);
            this.dificultad.Name = "dificultad";
            this.dificultad.Size = new System.Drawing.Size(170, 21);
            this.dificultad.TabIndex = 4;
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(299, 240);
            this.cantidad.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(170, 20);
            this.cantidad.TabIndex = 5;
            this.cantidad.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Seleccione el Conjunto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cargar Examen";
            // 
            // cargaExamen
            // 
            this.cargaExamen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cargaExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargaExamen.Location = new System.Drawing.Point(543, 390);
            this.cargaExamen.Name = "cargaExamen";
            this.cargaExamen.Size = new System.Drawing.Size(89, 48);
            this.cargaExamen.TabIndex = 9;
            this.cargaExamen.Text = "Cargar Examen";
            this.cargaExamen.UseVisualStyleBackColor = false;
            this.cargaExamen.Click += new System.EventHandler(this.cargaExamen_Click);
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver.Location = new System.Drawing.Point(675, 398);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(88, 32);
            this.volver.TabIndex = 10;
            this.volver.Text = "Volver";
            this.volver.UseMnemonic = false;
            this.volver.UseVisualStyleBackColor = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // conjunto
            // 
            this.conjunto.FormattingEnabled = true;
            this.conjunto.Location = new System.Drawing.Point(299, 294);
            this.conjunto.Name = "conjunto";
            this.conjunto.Size = new System.Drawing.Size(170, 21);
            this.conjunto.TabIndex = 11;
            // 
            // Ventana_Cargar_Examen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conjunto);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.cargaExamen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.dificultad);
            this.Controls.Add(this.categoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ventana_Cargar_Examen";
            this.Text = "Cargar Examen";
            this.Load += new System.EventHandler(this.Ventana_Cargar_Examen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoria;
        private System.Windows.Forms.ComboBox dificultad;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cargaExamen;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.ComboBox conjunto;
    }
}