namespace Examen_Virtual
{
    partial class ExamenTerminado
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
            this.usuarioNombre = new System.Windows.Forms.Label();
            this.puntaje = new System.Windows.Forms.Label();
            this.tiempo = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.cerrar = new System.Windows.Forms.Button();
            this.ranking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usuarioNombre
            // 
            this.usuarioNombre.AutoSize = true;
            this.usuarioNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioNombre.Location = new System.Drawing.Point(23, 28);
            this.usuarioNombre.Name = "usuarioNombre";
            this.usuarioNombre.Size = new System.Drawing.Size(0, 20);
            this.usuarioNombre.TabIndex = 0;
            // 
            // puntaje
            // 
            this.puntaje.AutoSize = true;
            this.puntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntaje.Location = new System.Drawing.Point(23, 102);
            this.puntaje.Name = "puntaje";
            this.puntaje.Size = new System.Drawing.Size(80, 20);
            this.puntaje.TabIndex = 1;
            this.puntaje.Text = "Puntaje: ";
            // 
            // tiempo
            // 
            this.tiempo.AutoSize = true;
            this.tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.Location = new System.Drawing.Point(23, 162);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(77, 20);
            this.tiempo.TabIndex = 2;
            this.tiempo.Text = "Tiempo: ";
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(23, 222);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(69, 20);
            this.fecha.TabIndex = 3;
            this.fecha.Text = "Fecha: ";
            // 
            // cerrar
            // 
            this.cerrar.BackColor = System.Drawing.Color.Olive;
            this.cerrar.Location = new System.Drawing.Point(623, 393);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(165, 45);
            this.cerrar.TabIndex = 4;
            this.cerrar.Text = "Cerrar Sesion";
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // ranking
            // 
            this.ranking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ranking.Location = new System.Drawing.Point(438, 393);
            this.ranking.Name = "ranking";
            this.ranking.Size = new System.Drawing.Size(165, 45);
            this.ranking.TabIndex = 5;
            this.ranking.Text = "Ver Ranking ";
            this.ranking.UseVisualStyleBackColor = false;
            this.ranking.Click += new System.EventHandler(this.ranking_Click);
            // 
            // ExamenTerminado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ranking);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.puntaje);
            this.Controls.Add(this.usuarioNombre);
            this.Name = "ExamenTerminado";
            this.Text = "ExamenTerminado";
            this.Load += new System.EventHandler(this.ExamenTerminado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usuarioNombre;
        private System.Windows.Forms.Label puntaje;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Button ranking;
    }
}