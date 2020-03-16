namespace Examen_Virtual
{
    partial class setExamen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setExamen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoria = new System.Windows.Forms.ComboBox();
            this.saludo = new System.Windows.Forms.Label();
            this.volver = new System.Windows.Forms.Button();
            this.btnComenzarExamen = new System.Windows.Forms.Button();
            this.dificultad = new System.Windows.Forms.ComboBox();
            this.cantidadPreguntas = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.conjunto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la categoría de las preguntas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elija el nivel de dificultad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad de preguntas";
            // 
            // categoria
            // 
            this.categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoria.FormattingEnabled = true;
            this.categoria.Location = new System.Drawing.Point(430, 96);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(192, 21);
            this.categoria.TabIndex = 3;
            // 
            // saludo
            // 
            this.saludo.AutoSize = true;
            this.saludo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saludo.Location = new System.Drawing.Point(12, 19);
            this.saludo.Name = "saludo";
            this.saludo.Size = new System.Drawing.Size(143, 25);
            this.saludo.TabIndex = 4;
            this.saludo.Text = "Bienvenido, ";
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.Olive;
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver.Location = new System.Drawing.Point(600, 406);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(101, 32);
            this.volver.TabIndex = 5;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // btnComenzarExamen
            // 
            this.btnComenzarExamen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnComenzarExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzarExamen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnComenzarExamen.Location = new System.Drawing.Point(432, 301);
            this.btnComenzarExamen.Name = "btnComenzarExamen";
            this.btnComenzarExamen.Size = new System.Drawing.Size(189, 48);
            this.btnComenzarExamen.TabIndex = 6;
            this.btnComenzarExamen.Text = "Comenzar Examen";
            this.btnComenzarExamen.UseVisualStyleBackColor = false;
            this.btnComenzarExamen.Click += new System.EventHandler(this.btnComenzarExamen_Click);
            // 
            // dificultad
            // 
            this.dificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dificultad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dificultad.FormattingEnabled = true;
            this.dificultad.Location = new System.Drawing.Point(430, 151);
            this.dificultad.Name = "dificultad";
            this.dificultad.Size = new System.Drawing.Size(192, 21);
            this.dificultad.TabIndex = 9;
            // 
            // cantidadPreguntas
            // 
            this.cantidadPreguntas.Location = new System.Drawing.Point(433, 203);
            this.cantidadPreguntas.Name = "cantidadPreguntas";
            this.cantidadPreguntas.Size = new System.Drawing.Size(189, 20);
            this.cantidadPreguntas.TabIndex = 10;
            this.cantidadPreguntas.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Seleccione el conjunto";
            // 
            // conjunto
            // 
            this.conjunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conjunto.FormattingEnabled = true;
            this.conjunto.Location = new System.Drawing.Point(429, 247);
            this.conjunto.Name = "conjunto";
            this.conjunto.Size = new System.Drawing.Size(192, 21);
            this.conjunto.TabIndex = 12;
            // 
            // setExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(721, 450);
            this.Controls.Add(this.conjunto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cantidadPreguntas);
            this.Controls.Add(this.dificultad);
            this.Controls.Add(this.btnComenzarExamen);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.saludo);
            this.Controls.Add(this.categoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "setExamen";
            this.Text = "Examen Virtual";
            this.Load += new System.EventHandler(this.setExamen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadPreguntas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoria;
        private System.Windows.Forms.Label saludo;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button btnComenzarExamen;
        private System.Windows.Forms.ComboBox dificultad;
        private System.Windows.Forms.NumericUpDown cantidadPreguntas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox conjunto;
    }
}