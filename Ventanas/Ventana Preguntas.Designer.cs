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
            this.opcionA = new System.Windows.Forms.RadioButton();
            this.opcionB = new System.Windows.Forms.RadioButton();
            this.opcionC = new System.Windows.Forms.RadioButton();
            this.opcionD = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.siguiente = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            // opcionA
            // 
            this.opcionA.AutoSize = true;
            this.opcionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionA.Location = new System.Drawing.Point(29, 66);
            this.opcionA.Name = "opcionA";
            this.opcionA.Size = new System.Drawing.Size(14, 13);
            this.opcionA.TabIndex = 1;
            this.opcionA.TabStop = true;
            this.opcionA.UseVisualStyleBackColor = true;
            // 
            // opcionB
            // 
            this.opcionB.AutoSize = true;
            this.opcionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionB.Location = new System.Drawing.Point(29, 126);
            this.opcionB.Name = "opcionB";
            this.opcionB.Size = new System.Drawing.Size(14, 13);
            this.opcionB.TabIndex = 2;
            this.opcionB.TabStop = true;
            this.opcionB.UseVisualStyleBackColor = true;
            // 
            // opcionC
            // 
            this.opcionC.AutoSize = true;
            this.opcionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionC.Location = new System.Drawing.Point(29, 192);
            this.opcionC.Name = "opcionC";
            this.opcionC.Size = new System.Drawing.Size(14, 13);
            this.opcionC.TabIndex = 3;
            this.opcionC.TabStop = true;
            this.opcionC.UseVisualStyleBackColor = true;
            // 
            // opcionD
            // 
            this.opcionD.AutoSize = true;
            this.opcionD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionD.Location = new System.Drawing.Point(29, 259);
            this.opcionD.Name = "opcionD";
            this.opcionD.Size = new System.Drawing.Size(14, 13);
            this.opcionD.TabIndex = 4;
            this.opcionD.TabStop = true;
            this.opcionD.UseVisualStyleBackColor = true;
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
            this.siguiente.Location = new System.Drawing.Point(610, 303);
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
            this.time.Size = new System.Drawing.Size(69, 16);
            this.time.TabIndex = 6;
            this.time.Text = "Tiempo: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opcionB);
            this.groupBox1.Controls.Add(this.opcionA);
            this.groupBox1.Controls.Add(this.siguiente);
            this.groupBox1.Controls.Add(this.opcionC);
            this.groupBox1.Controls.Add(this.opcionD);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 347);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // VPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.time);
            this.Controls.Add(this.preg);
            this.Name = "VPreguntas";
            this.Text = "Pregunta";
            this.Load += new System.EventHandler(this.VPreguntas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label preg;
        private System.Windows.Forms.RadioButton opcionA;
        private System.Windows.Forms.RadioButton opcionB;
        private System.Windows.Forms.RadioButton opcionC;
        private System.Windows.Forms.RadioButton opcionD;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}