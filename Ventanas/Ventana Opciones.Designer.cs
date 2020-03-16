namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Opciones
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
            this.listaUsuarios = new System.Windows.Forms.Button();
            this.verExamenes = new System.Windows.Forms.Button();
            this.cargarPreguntas = new System.Windows.Forms.Button();
            this.modificarTiempos = new System.Windows.Forms.Button();
            this.setAdministrador = new System.Windows.Forms.Button();
            this.verPreguntas = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listaUsuarios
            // 
            this.listaUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.listaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaUsuarios.Location = new System.Drawing.Point(494, 45);
            this.listaUsuarios.Name = "listaUsuarios";
            this.listaUsuarios.Size = new System.Drawing.Size(106, 51);
            this.listaUsuarios.TabIndex = 0;
            this.listaUsuarios.Text = "Ver Lista Usuarios";
            this.listaUsuarios.UseVisualStyleBackColor = false;
            this.listaUsuarios.Click += new System.EventHandler(this.listaUsuarios_Click);
            // 
            // verExamenes
            // 
            this.verExamenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.verExamenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verExamenes.Location = new System.Drawing.Point(187, 45);
            this.verExamenes.Name = "verExamenes";
            this.verExamenes.Size = new System.Drawing.Size(106, 51);
            this.verExamenes.TabIndex = 1;
            this.verExamenes.Text = "Ver Examenes";
            this.verExamenes.UseVisualStyleBackColor = false;
            this.verExamenes.Click += new System.EventHandler(this.verExamenes_Click);
            // 
            // cargarPreguntas
            // 
            this.cargarPreguntas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cargarPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarPreguntas.Location = new System.Drawing.Point(187, 179);
            this.cargarPreguntas.Name = "cargarPreguntas";
            this.cargarPreguntas.Size = new System.Drawing.Size(106, 51);
            this.cargarPreguntas.TabIndex = 2;
            this.cargarPreguntas.Text = "Cargar Preguntas";
            this.cargarPreguntas.UseVisualStyleBackColor = false;
            this.cargarPreguntas.Click += new System.EventHandler(this.cargarPreguntas_Click_1);
            // 
            // modificarTiempos
            // 
            this.modificarTiempos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.modificarTiempos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarTiempos.Location = new System.Drawing.Point(494, 179);
            this.modificarTiempos.Name = "modificarTiempos";
            this.modificarTiempos.Size = new System.Drawing.Size(106, 51);
            this.modificarTiempos.TabIndex = 3;
            this.modificarTiempos.Text = "Modificar Tiempos ";
            this.modificarTiempos.UseVisualStyleBackColor = false;
            this.modificarTiempos.Click += new System.EventHandler(this.modificarTiempos_Click);
            // 
            // setAdministrador
            // 
            this.setAdministrador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.setAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setAdministrador.Location = new System.Drawing.Point(187, 312);
            this.setAdministrador.Name = "setAdministrador";
            this.setAdministrador.Size = new System.Drawing.Size(106, 52);
            this.setAdministrador.TabIndex = 4;
            this.setAdministrador.Text = "Configurar Administrador";
            this.setAdministrador.UseVisualStyleBackColor = false;
            this.setAdministrador.Click += new System.EventHandler(this.setAdministrador_Click);
            // 
            // verPreguntas
            // 
            this.verPreguntas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.verPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verPreguntas.Location = new System.Drawing.Point(494, 312);
            this.verPreguntas.Name = "verPreguntas";
            this.verPreguntas.Size = new System.Drawing.Size(106, 50);
            this.verPreguntas.TabIndex = 8;
            this.verPreguntas.Text = "Ver Preguntas";
            this.verPreguntas.UseVisualStyleBackColor = false;
            this.verPreguntas.Click += new System.EventHandler(this.verPreguntas_Click);
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver.Location = new System.Drawing.Point(686, 429);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(83, 33);
            this.volver.TabIndex = 9;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = false;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
            // 
            // Ventana_Opciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.verPreguntas);
            this.Controls.Add(this.setAdministrador);
            this.Controls.Add(this.modificarTiempos);
            this.Controls.Add(this.cargarPreguntas);
            this.Controls.Add(this.verExamenes);
            this.Controls.Add(this.listaUsuarios);
            this.Name = "Ventana_Opciones";
            this.Text = "Ventana_Opciones";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listaUsuarios;
        private System.Windows.Forms.Button verExamenes;
        private System.Windows.Forms.Button cargarPreguntas;
        private System.Windows.Forms.Button modificarTiempos;
        private System.Windows.Forms.Button setAdministrador;
        private System.Windows.Forms.Button verPreguntas;
        private System.Windows.Forms.Button volver;
    }
}