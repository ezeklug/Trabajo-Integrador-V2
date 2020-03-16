namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Modificar_Tiempo
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
            this.conjunto = new System.Windows.Forms.Label();
            this.ListaConjuntos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tiempo = new System.Windows.Forms.TextBox();
            this.modificar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar tiempo de un Conjunto";
            // 
            // conjunto
            // 
            this.conjunto.AutoSize = true;
            this.conjunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conjunto.Location = new System.Drawing.Point(36, 147);
            this.conjunto.Name = "conjunto";
            this.conjunto.Size = new System.Drawing.Size(342, 18);
            this.conjunto.TabIndex = 1;
            this.conjunto.Text = "-Seleccione el conjunto que desea modificar";
            // 
            // ListaConjuntos
            // 
            this.ListaConjuntos.FormattingEnabled = true;
            this.ListaConjuntos.Location = new System.Drawing.Point(399, 148);
            this.ListaConjuntos.Name = "ListaConjuntos";
            this.ListaConjuntos.Size = new System.Drawing.Size(121, 21);
            this.ListaConjuntos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tiempo por pregunta(segundos):";
            // 
            // tiempo
            // 
            this.tiempo.Location = new System.Drawing.Point(399, 210);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(119, 20);
            this.tiempo.TabIndex = 4;
            // 
            // modificar
            // 
            this.modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificar.Location = new System.Drawing.Point(440, 305);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(80, 31);
            this.modificar.TabIndex = 5;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = false;
            this.modificar.Click += new System.EventHandler(this.modificar_Click_1);
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver.Location = new System.Drawing.Point(687, 407);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(80, 31);
            this.volver.TabIndex = 6;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Ventana_Modificar_Tiempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListaConjuntos);
            this.Controls.Add(this.conjunto);
            this.Controls.Add(this.label1);
            this.Name = "Ventana_Modificar_Tiempo";
            this.Text = "Ventana_Modificar_Tiempo";
            this.Load += new System.EventHandler(this.Ventana_Modificar_Tiempo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label conjunto;
        private System.Windows.Forms.ComboBox ListaConjuntos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tiempo;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button volver;
    }
}