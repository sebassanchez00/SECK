namespace CapaPresentacion.Forms.CRUD
{
    partial class FPreguntaAbiertaNumCRUD
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
            this.btn_LeerCSV = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LeerCSV
            // 
            this.btn_LeerCSV.AutoSize = true;
            this.btn_LeerCSV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_LeerCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LeerCSV.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.btn_LeerCSV.ForeColor = System.Drawing.Color.White;
            this.btn_LeerCSV.Location = new System.Drawing.Point(15, 187);
            this.btn_LeerCSV.Name = "btn_LeerCSV";
            this.btn_LeerCSV.Size = new System.Drawing.Size(144, 30);
            this.btn_LeerCSV.TabIndex = 6;
            this.btn_LeerCSV.Text = "Cargar Preguntas";
            this.btn_LeerCSV.UseVisualStyleBackColor = false;
            this.btn_LeerCSV.Click += new System.EventHandler(this.btn_LeerCSV_Click);
            // 
            // pb_logo
            // 
            this.pb_logo.Location = new System.Drawing.Point(917, 4);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(80, 57);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 75;
            this.pb_logo.TabStop = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.AutoSize = true;
            this.btn_eliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_eliminar.Location = new System.Drawing.Point(15, 222);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(144, 30);
            this.btn_eliminar.TabIndex = 77;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // FPreguntaAbiertaNumCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.EspacioBlanco;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.btn_LeerCSV);
            this.Name = "FPreguntaAbiertaNumCRUD";
            this.Text = "Cargue Preguntas Abierta Numérica";
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_LeerCSV;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Button btn_eliminar;
    }
}