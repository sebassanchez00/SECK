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
            this.dgvPreguntas = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Panel_Insertar = new System.Windows.Forms.Panel();
            this.lbl_Tema = new System.Windows.Forms.Label();
            this.cb_Tema = new System.Windows.Forms.ComboBox();
            this.lbl_AvisoValidacion = new System.Windows.Forms.Label();
            this.btn_InsertPregunta = new System.Windows.Forms.Button();
            this.cb_Rta = new System.Windows.Forms.ComboBox();
            this.tb_Op4 = new System.Windows.Forms.TextBox();
            this.tb_Op3 = new System.Windows.Forms.TextBox();
            this.tb_Op2 = new System.Windows.Forms.TextBox();
            this.tb_Op1 = new System.Windows.Forms.TextBox();
            this.tb_Enunciado = new System.Windows.Forms.TextBox();
            this.lbl_Rta = new System.Windows.Forms.Label();
            this.lbl_Enun = new System.Windows.Forms.Label();
            this.lbl_O4 = new System.Windows.Forms.Label();
            this.lbl_O3 = new System.Windows.Forms.Label();
            this.lbl_O2 = new System.Windows.Forms.Label();
            this.lbl_O1 = new System.Windows.Forms.Label();
            this.dgvOpciones = new System.Windows.Forms.DataGridView();
            this.btn_LeerCSV = new System.Windows.Forms.Button();
            this.Panel_Insertar_Desde_csv = new System.Windows.Forms.Panel();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Tema_CSV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
            this.Panel_Insertar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).BeginInit();
            this.Panel_Insertar_Desde_csv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPreguntas
            // 
            this.dgvPreguntas.AllowUserToAddRows = false;
            this.dgvPreguntas.AllowUserToDeleteRows = false;
            this.dgvPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreguntas.Location = new System.Drawing.Point(12, 264);
            this.dgvPreguntas.Name = "dgvPreguntas";
            this.dgvPreguntas.Size = new System.Drawing.Size(720, 463);
            this.dgvPreguntas.TabIndex = 0;
            this.dgvPreguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgvPreguntas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgvPreguntas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreguntas_RowEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Panel_Insertar
            // 
            this.Panel_Insertar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Insertar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Insertar.Controls.Add(this.lbl_Tema);
            this.Panel_Insertar.Controls.Add(this.cb_Tema);
            this.Panel_Insertar.Controls.Add(this.lbl_AvisoValidacion);
            this.Panel_Insertar.Controls.Add(this.btn_InsertPregunta);
            this.Panel_Insertar.Controls.Add(this.cb_Rta);
            this.Panel_Insertar.Controls.Add(this.tb_Op4);
            this.Panel_Insertar.Controls.Add(this.tb_Op3);
            this.Panel_Insertar.Controls.Add(this.tb_Op2);
            this.Panel_Insertar.Controls.Add(this.tb_Op1);
            this.Panel_Insertar.Controls.Add(this.tb_Enunciado);
            this.Panel_Insertar.Controls.Add(this.lbl_Rta);
            this.Panel_Insertar.Controls.Add(this.lbl_Enun);
            this.Panel_Insertar.Controls.Add(this.lbl_O4);
            this.Panel_Insertar.Controls.Add(this.lbl_O3);
            this.Panel_Insertar.Controls.Add(this.lbl_O2);
            this.Panel_Insertar.Controls.Add(this.lbl_O1);
            this.Panel_Insertar.Location = new System.Drawing.Point(13, 13);
            this.Panel_Insertar.Name = "Panel_Insertar";
            this.Panel_Insertar.Size = new System.Drawing.Size(983, 200);
            this.Panel_Insertar.TabIndex = 1;
            // 
            // lbl_Tema
            // 
            this.lbl_Tema.AutoSize = true;
            this.lbl_Tema.Location = new System.Drawing.Point(12, 170);
            this.lbl_Tema.Name = "lbl_Tema";
            this.lbl_Tema.Size = new System.Drawing.Size(34, 13);
            this.lbl_Tema.TabIndex = 18;
            this.lbl_Tema.Text = "Tema";
            // 
            // cb_Tema
            // 
            this.cb_Tema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Tema.FormattingEnabled = true;
            this.cb_Tema.Location = new System.Drawing.Point(93, 166);
            this.cb_Tema.Name = "cb_Tema";
            this.cb_Tema.Size = new System.Drawing.Size(454, 21);
            this.cb_Tema.TabIndex = 17;
            // 
            // lbl_AvisoValidacion
            // 
            this.lbl_AvisoValidacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AvisoValidacion.AutoSize = true;
            this.lbl_AvisoValidacion.ForeColor = System.Drawing.Color.Red;
            this.lbl_AvisoValidacion.Location = new System.Drawing.Point(629, 170);
            this.lbl_AvisoValidacion.Name = "lbl_AvisoValidacion";
            this.lbl_AvisoValidacion.Size = new System.Drawing.Size(262, 13);
            this.lbl_AvisoValidacion.TabIndex = 15;
            this.lbl_AvisoValidacion.Text = "Para insertar la pregunta debe llenar todos los campos";
            this.lbl_AvisoValidacion.Visible = false;
            // 
            // btn_InsertPregunta
            // 
            this.btn_InsertPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_InsertPregunta.Location = new System.Drawing.Point(897, 165);
            this.btn_InsertPregunta.Name = "btn_InsertPregunta";
            this.btn_InsertPregunta.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertPregunta.TabIndex = 14;
            this.btn_InsertPregunta.Text = "Insertar";
            this.btn_InsertPregunta.UseVisualStyleBackColor = true;
            this.btn_InsertPregunta.Click += new System.EventHandler(this.btn_InsertPregunta_Click);
            // 
            // cb_Rta
            // 
            this.cb_Rta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Rta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Rta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Rta.FormattingEnabled = true;
            this.cb_Rta.Location = new System.Drawing.Point(93, 140);
            this.cb_Rta.Name = "cb_Rta";
            this.cb_Rta.Size = new System.Drawing.Size(882, 21);
            this.cb_Rta.TabIndex = 12;
            // 
            // tb_Op4
            // 
            this.tb_Op4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Op4.Location = new System.Drawing.Point(94, 114);
            this.tb_Op4.Name = "tb_Op4";
            this.tb_Op4.Size = new System.Drawing.Size(882, 20);
            this.tb_Op4.TabIndex = 11;
            // 
            // tb_Op3
            // 
            this.tb_Op3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Op3.Location = new System.Drawing.Point(94, 88);
            this.tb_Op3.Name = "tb_Op3";
            this.tb_Op3.Size = new System.Drawing.Size(882, 20);
            this.tb_Op3.TabIndex = 10;
            // 
            // tb_Op2
            // 
            this.tb_Op2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Op2.Location = new System.Drawing.Point(94, 62);
            this.tb_Op2.Name = "tb_Op2";
            this.tb_Op2.Size = new System.Drawing.Size(882, 20);
            this.tb_Op2.TabIndex = 9;
            // 
            // tb_Op1
            // 
            this.tb_Op1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Op1.Location = new System.Drawing.Point(94, 36);
            this.tb_Op1.Name = "tb_Op1";
            this.tb_Op1.Size = new System.Drawing.Size(882, 20);
            this.tb_Op1.TabIndex = 8;
            // 
            // tb_Enunciado
            // 
            this.tb_Enunciado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Enunciado.Location = new System.Drawing.Point(94, 10);
            this.tb_Enunciado.Name = "tb_Enunciado";
            this.tb_Enunciado.Size = new System.Drawing.Size(882, 20);
            this.tb_Enunciado.TabIndex = 7;
            // 
            // lbl_Rta
            // 
            this.lbl_Rta.AutoSize = true;
            this.lbl_Rta.Location = new System.Drawing.Point(12, 144);
            this.lbl_Rta.Name = "lbl_Rta";
            this.lbl_Rta.Size = new System.Drawing.Size(58, 13);
            this.lbl_Rta.TabIndex = 6;
            this.lbl_Rta.Text = "Respuesta";
            // 
            // lbl_Enun
            // 
            this.lbl_Enun.AutoSize = true;
            this.lbl_Enun.Location = new System.Drawing.Point(12, 14);
            this.lbl_Enun.Name = "lbl_Enun";
            this.lbl_Enun.Size = new System.Drawing.Size(58, 13);
            this.lbl_Enun.TabIndex = 5;
            this.lbl_Enun.Text = "Enunciado";
            // 
            // lbl_O4
            // 
            this.lbl_O4.AutoSize = true;
            this.lbl_O4.Location = new System.Drawing.Point(12, 118);
            this.lbl_O4.Name = "lbl_O4";
            this.lbl_O4.Size = new System.Drawing.Size(50, 13);
            this.lbl_O4.TabIndex = 3;
            this.lbl_O4.Text = "Opción 4";
            // 
            // lbl_O3
            // 
            this.lbl_O3.AutoSize = true;
            this.lbl_O3.Location = new System.Drawing.Point(12, 92);
            this.lbl_O3.Name = "lbl_O3";
            this.lbl_O3.Size = new System.Drawing.Size(50, 13);
            this.lbl_O3.TabIndex = 2;
            this.lbl_O3.Text = "Opción 3";
            // 
            // lbl_O2
            // 
            this.lbl_O2.AutoSize = true;
            this.lbl_O2.Location = new System.Drawing.Point(12, 66);
            this.lbl_O2.Name = "lbl_O2";
            this.lbl_O2.Size = new System.Drawing.Size(50, 13);
            this.lbl_O2.TabIndex = 1;
            this.lbl_O2.Text = "Opción 2";
            // 
            // lbl_O1
            // 
            this.lbl_O1.AutoSize = true;
            this.lbl_O1.Location = new System.Drawing.Point(12, 40);
            this.lbl_O1.Name = "lbl_O1";
            this.lbl_O1.Size = new System.Drawing.Size(50, 13);
            this.lbl_O1.TabIndex = 0;
            this.lbl_O1.Text = "Opción 1";
            // 
            // dgvOpciones
            // 
            this.dgvOpciones.AllowUserToAddRows = false;
            this.dgvOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpciones.Location = new System.Drawing.Point(738, 264);
            this.dgvOpciones.Name = "dgvOpciones";
            this.dgvOpciones.Size = new System.Drawing.Size(258, 463);
            this.dgvOpciones.TabIndex = 2;
            // 
            // btn_LeerCSV
            // 
            this.btn_LeerCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LeerCSV.Location = new System.Drawing.Point(800, 6);
            this.btn_LeerCSV.Name = "btn_LeerCSV";
            this.btn_LeerCSV.Size = new System.Drawing.Size(176, 23);
            this.btn_LeerCSV.TabIndex = 16;
            this.btn_LeerCSV.Text = "Cargar Preguntas .csv";
            this.btn_LeerCSV.UseVisualStyleBackColor = true;
            this.btn_LeerCSV.Click += new System.EventHandler(this.btn_LeerCSV_Click);
            // 
            // Panel_Insertar_Desde_csv
            // 
            this.Panel_Insertar_Desde_csv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Insertar_Desde_csv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Insertar_Desde_csv.Controls.Add(this.btn_eliminar);
            this.Panel_Insertar_Desde_csv.Controls.Add(this.label1);
            this.Panel_Insertar_Desde_csv.Controls.Add(this.cb_Tema_CSV);
            this.Panel_Insertar_Desde_csv.Controls.Add(this.btn_LeerCSV);
            this.Panel_Insertar_Desde_csv.Location = new System.Drawing.Point(13, 219);
            this.Panel_Insertar_Desde_csv.Name = "Panel_Insertar_Desde_csv";
            this.Panel_Insertar_Desde_csv.Size = new System.Drawing.Size(984, 39);
            this.Panel_Insertar_Desde_csv.TabIndex = 19;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_eliminar.Location = new System.Drawing.Point(632, 6);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(81, 23);
            this.btn_eliminar.TabIndex = 20;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tema";
            // 
            // cb_Tema_CSV
            // 
            this.cb_Tema_CSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tema_CSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Tema_CSV.FormattingEnabled = true;
            this.cb_Tema_CSV.Location = new System.Drawing.Point(93, 7);
            this.cb_Tema_CSV.Name = "cb_Tema_CSV";
            this.cb_Tema_CSV.Size = new System.Drawing.Size(454, 21);
            this.cb_Tema_CSV.TabIndex = 19;
            // 
            // FPreguntaSelMulCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.Panel_Insertar_Desde_csv);
            this.Controls.Add(this.dgvOpciones);
            this.Controls.Add(this.Panel_Insertar);
            this.Controls.Add(this.dgvPreguntas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPreguntaSelMulCRUD";
            this.Text = "Administrar Preguntas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPreguntasCRUD_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
            this.Panel_Insertar.ResumeLayout(false);
            this.Panel_Insertar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).EndInit();
            this.Panel_Insertar_Desde_csv.ResumeLayout(false);
            this.Panel_Insertar_Desde_csv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreguntas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel Panel_Insertar;
        private System.Windows.Forms.Button btn_InsertPregunta;
        private System.Windows.Forms.ComboBox cb_Rta;
        private System.Windows.Forms.TextBox tb_Op4;
        private System.Windows.Forms.TextBox tb_Op3;
        private System.Windows.Forms.TextBox tb_Op2;
        private System.Windows.Forms.TextBox tb_Op1;
        private System.Windows.Forms.TextBox tb_Enunciado;
        private System.Windows.Forms.Label lbl_Rta;
        private System.Windows.Forms.Label lbl_Enun;
        private System.Windows.Forms.Label lbl_O4;
        private System.Windows.Forms.Label lbl_O3;
        private System.Windows.Forms.Label lbl_O2;
        private System.Windows.Forms.Label lbl_O1;
        private System.Windows.Forms.Label lbl_AvisoValidacion;
        private System.Windows.Forms.DataGridView dgvOpciones;
        private System.Windows.Forms.Label lbl_Tema;
        private System.Windows.Forms.ComboBox cb_Tema;
        private System.Windows.Forms.Button btn_LeerCSV;
        private System.Windows.Forms.Panel Panel_Insertar_Desde_csv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Tema_CSV;
        private System.Windows.Forms.Button btn_eliminar;
    }
}