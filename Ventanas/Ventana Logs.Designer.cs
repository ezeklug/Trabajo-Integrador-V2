namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Logs
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
            this.Bitacora = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Bitacora
            // 
            this.Bitacora.AutoSize = true;
            this.Bitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bitacora.Location = new System.Drawing.Point(12, 23);
            this.Bitacora.Name = "Bitacora";
            this.Bitacora.Size = new System.Drawing.Size(186, 20);
            this.Bitacora.TabIndex = 2;
            this.Bitacora.Text = "Bitacora de Monitoreo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 356);
            this.dataGridView1.TabIndex = 3;
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.volver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver.Location = new System.Drawing.Point(670, 404);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 34);
            this.volver.TabIndex = 4;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Ventana_Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Bitacora);
            this.Name = "Ventana_Logs";
            this.Text = "Ventana_Logs";
            this.Load += new System.EventHandler(this.Ventana_Logs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Bitacora;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button volver;
    }
}