﻿namespace CapaPresentacion.Forms.CRUD
{
    partial class FPreguntaVFCRUD
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
            this.lbl_Tema = new System.Windows.Forms.Label();
            this.cb_Tema = new System.Windows.Forms.ComboBox();
            this.btn_LeerCSV = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Tema
            // 
            this.lbl_Tema.AutoSize = true;
            this.lbl_Tema.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Tema.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.lbl_Tema.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_Tema.Location = new System.Drawing.Point(189, 192);
            this.lbl_Tema.Name = "lbl_Tema";
            this.lbl_Tema.Size = new System.Drawing.Size(52, 19);
            this.lbl_Tema.TabIndex = 5;
            this.lbl_Tema.Text = "TEMA";
            // 
            // cb_Tema
            // 
            this.cb_Tema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Tema.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.cb_Tema.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cb_Tema.FormattingEnabled = true;
            this.cb_Tema.Location = new System.Drawing.Point(251, 188);
            this.cb_Tema.Name = "cb_Tema";
            this.cb_Tema.Size = new System.Drawing.Size(742, 27);
            this.cb_Tema.TabIndex = 4;
            // 
            // btn_LeerCSV
            // 
            this.btn_LeerCSV.AutoSize = true;
            this.btn_LeerCSV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_LeerCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LeerCSV.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.btn_LeerCSV.ForeColor = System.Drawing.Color.White;
            this.btn_LeerCSV.Location = new System.Drawing.Point(12, 187);
            this.btn_LeerCSV.Name = "btn_LeerCSV";
            this.btn_LeerCSV.Size = new System.Drawing.Size(144, 29);
            this.btn_LeerCSV.TabIndex = 3;
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
            this.pb_logo.TabIndex = 77;
            this.pb_logo.TabStop = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.AutoSize = true;
            this.btn_eliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_eliminar.Location = new System.Drawing.Point(12, 222);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(144, 29);
            this.btn_eliminar.TabIndex = 79;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // FPreguntaVFCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.EspacioBlanco;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.lbl_Tema);
            this.Controls.Add(this.cb_Tema);
            this.Controls.Add(this.btn_LeerCSV);
            this.Name = "FPreguntaVFCRUD";
            this.Text = "FPreguntaVFCRUD";
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Tema;
        private System.Windows.Forms.ComboBox cb_Tema;
        private System.Windows.Forms.Button btn_LeerCSV;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Button btn_eliminar;

    }
}