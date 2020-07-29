namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Set_Administrador
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
            this.setAdmin = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.listaCheckedBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el/los usuarios:";
            // 
            // setAdmin
            // 
            this.setAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.setAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setAdmin.Location = new System.Drawing.Point(162, 274);
            this.setAdmin.Name = "setAdmin";
            this.setAdmin.Size = new System.Drawing.Size(120, 55);
            this.setAdmin.TabIndex = 1;
            this.setAdmin.Text = "Hacer Administrador";
            this.setAdmin.UseVisualStyleBackColor = false;
            this.setAdmin.Click += new System.EventHandler(this.setAdmin_Click);
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(342, 282);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(90, 38);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // listaCheckedBox
            // 
            this.listaCheckedBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listaCheckedBox.FormattingEnabled = true;
            this.listaCheckedBox.Location = new System.Drawing.Point(283, 37);
            this.listaCheckedBox.Name = "listaCheckedBox";
            this.listaCheckedBox.Size = new System.Drawing.Size(205, 214);
            this.listaCheckedBox.TabIndex = 5;
            // 
            // Ventana_Set_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(589, 342);
            this.Controls.Add(this.listaCheckedBox);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.setAdmin);
            this.Controls.Add(this.label1);
            this.Name = "Ventana_Set_Administrador";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.SetAdministrador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setAdmin;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.CheckedListBox listaCheckedBox;
    }
}