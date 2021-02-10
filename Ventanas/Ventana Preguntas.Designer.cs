namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Preguntas
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
            this.components = new System.ComponentModel.Container();
            this.preg = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.siguiente = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.CantidadPreguntas = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.npgsqlCommand1 = new Npgsql.NpgsqlCommand();
            this.SuspendLayout();
            // 
            // preg
            // 
            this.preg.AutoSize = true;
            this.preg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preg.Location = new System.Drawing.Point(39, 54);
            this.preg.Name = "preg";
            this.preg.Size = new System.Drawing.Size(21, 20);
            this.preg.TabIndex = 4;
            this.preg.Text = "* ";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // siguiente
            // 
            this.siguiente.BackColor = System.Drawing.Color.LightCoral;
            this.siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siguiente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.siguiente.Location = new System.Drawing.Point(648, 272);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(126, 38);
            this.siguiente.TabIndex = 5;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = false;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(535, 20);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 16);
            this.time.TabIndex = 6;
            // 
            // CantidadPreguntas
            // 
            this.CantidadPreguntas.AutoSize = true;
            this.CantidadPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantidadPreguntas.Location = new System.Drawing.Point(9, 9);
            this.CantidadPreguntas.Name = "CantidadPreguntas";
            this.CantidadPreguntas.Size = new System.Drawing.Size(0, 16);
            this.CantidadPreguntas.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 98);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(748, 168);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // npgsqlCommand1
            // 
            this.npgsqlCommand1.AllResultTypesAreUnknown = false;
            this.npgsqlCommand1.Transaction = null;
            this.npgsqlCommand1.UnknownResultTypeList = null;
            // 
            // Ventana_Preguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 325);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.CantidadPreguntas);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.time);
            this.Controls.Add(this.preg);
            this.Name = "Ventana_Preguntas";
            this.Text = "Pregunta";
            this.Load += new System.EventHandler(this.VPreguntas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label preg;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label CantidadPreguntas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Npgsql.NpgsqlCommand npgsqlCommand1;
    }
}