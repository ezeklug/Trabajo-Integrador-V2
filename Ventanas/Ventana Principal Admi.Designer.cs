namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Principal_Admi

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
            this.comenzarExamen = new System.Windows.Forms.Button();
            this.verRanking = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Label();
            this.cerrarSesion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Opciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comenzarExamen
            // 
            this.comenzarExamen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.comenzarExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comenzarExamen.Location = new System.Drawing.Point(327, 234);
            this.comenzarExamen.Name = "comenzarExamen";
            this.comenzarExamen.Size = new System.Drawing.Size(140, 47);
            this.comenzarExamen.TabIndex = 0;
            this.comenzarExamen.Text = "Comenzar Examen";
            this.comenzarExamen.UseVisualStyleBackColor = false;
            this.comenzarExamen.Click += new System.EventHandler(this.comenzarExamen_Click_1);
            // 
            // verRanking
            // 
            this.verRanking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.verRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verRanking.Location = new System.Drawing.Point(80, 235);
            this.verRanking.Name = "verRanking";
            this.verRanking.Size = new System.Drawing.Size(140, 47);
            this.verRanking.TabIndex = 1;
            this.verRanking.Text = "Ver Ranking";
            this.verRanking.UseVisualStyleBackColor = false;
            this.verRanking.Click += new System.EventHandler(this.verRanking_Click_1);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(69, 32);
            this.user.Name = "user";
            this.user.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.user.Size = new System.Drawing.Size(0, 18);
            this.user.TabIndex = 3;
            // 
            // cerrarSesion
            // 
            this.cerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarSesion.Location = new System.Drawing.Point(648, 391);
            this.cerrarSesion.Name = "cerrarSesion";
            this.cerrarSesion.Size = new System.Drawing.Size(140, 47);
            this.cerrarSesion.TabIndex = 4;
            this.cerrarSesion.Text = "Cerrar Sesión";
            this.cerrarSesion.UseVisualStyleBackColor = false;
            this.cerrarSesion.Click += new System.EventHandler(this.cerrarSesion_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Qué desea hacer?";
            // 
            // Opciones
            // 
            this.Opciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Opciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Opciones.Location = new System.Drawing.Point(543, 234);
            this.Opciones.Name = "Opciones";
            this.Opciones.Size = new System.Drawing.Size(140, 47);
            this.Opciones.TabIndex = 7;
            this.Opciones.Text = "Opciones";
            this.Opciones.UseVisualStyleBackColor = false;
            this.Opciones.Click += new System.EventHandler(this.Opciones_Click);
            // 
            // Ventana_Principal_Admi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Opciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cerrarSesion);
            this.Controls.Add(this.user);
            this.Controls.Add(this.verRanking);
            this.Controls.Add(this.comenzarExamen);
            this.Name = "Ventana_Principal_Admi";
            this.Text = "Examen Virtual";
            this.Load += new System.EventHandler(this.Ventana_Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button comenzarExamen;
        private System.Windows.Forms.Button verRanking;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Button cerrarSesion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Opciones;
    }
}