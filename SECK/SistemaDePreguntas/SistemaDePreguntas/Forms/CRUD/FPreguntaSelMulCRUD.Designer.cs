namespace CapaPresentacion.Forms.CRUD
{
    partial class FPreguntaSelMulCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPreguntaSelMulCRUD));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_LeerCSV = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btn_LeerCSV
            // 
            this.btn_LeerCSV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_LeerCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LeerCSV.ForeColor = System.Drawing.Color.White;
            this.btn_LeerCSV.Location = new System.Drawing.Point(15, 190);
            this.btn_LeerCSV.Name = "btn_LeerCSV";
            this.btn_LeerCSV.Size = new System.Drawing.Size(144, 30);
            this.btn_LeerCSV.TabIndex = 16;
            this.btn_LeerCSV.Text = "Cargar Preguntas .csv";
            this.btn_LeerCSV.UseVisualStyleBackColor = false;
            this.btn_LeerCSV.Click += new System.EventHandler(this.btn_LeerCSV_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_eliminar.Location = new System.Drawing.Point(15, 225);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(144, 30);
            this.btn_eliminar.TabIndex = 20;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // FPreguntaSelMulCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.EspacioBlanco;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_LeerCSV);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FPreguntaSelMulCRUD";
            this.Text = "Cargue Preguntas Selección Múltiple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPreguntasCRUD_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_LeerCSV;
        private System.Windows.Forms.Button btn_eliminar;
    }
}