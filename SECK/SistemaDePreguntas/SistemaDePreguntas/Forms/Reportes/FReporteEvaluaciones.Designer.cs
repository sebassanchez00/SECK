namespace CapaPresentacion.Forms.Reportes
{
    partial class FReporteEvaluaciones
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DEvaluacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_cedula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_idPrueba = new System.Windows.Forms.ComboBox();
            this.DReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Generar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DEvaluacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DReportesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DEvaluacionBindingSource
            // 
            this.DEvaluacionBindingSource.DataSource = typeof(CapaDatos.DEvaluacion);
            // 
            // rv
            // 
            this.rv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            reportDataSource1.Name = "DataSet_DEvaluacion";
            reportDataSource1.Value = this.DEvaluacionBindingSource;
            this.rv.LocalReport.DataSources.Add(reportDataSource1);
            this.rv.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.RepEvaluacion.rdlc";
            this.rv.Location = new System.Drawing.Point(51, 61);
            this.rv.Margin = new System.Windows.Forms.Padding(0);
            this.rv.Name = "rv";
            this.rv.Padding = new System.Windows.Forms.Padding(90, 0, 90, 0);
            this.rv.Size = new System.Drawing.Size(904, 634);
            this.rv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(54, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cédula:";
            // 
            // cb_cedula
            // 
            this.cb_cedula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cedula.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.cb_cedula.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cb_cedula.FormattingEnabled = true;
            this.cb_cedula.Location = new System.Drawing.Point(123, 18);
            this.cb_cedula.Name = "cb_cedula";
            this.cb_cedula.Size = new System.Drawing.Size(172, 28);
            this.cb_cedula.TabIndex = 2;
            this.cb_cedula.SelectedValueChanged += new System.EventHandler(this.cb_cedula_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(405, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Prueba:";
            // 
            // cb_idPrueba
            // 
            this.cb_idPrueba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_idPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_idPrueba.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.cb_idPrueba.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cb_idPrueba.FormattingEnabled = true;
            this.cb_idPrueba.Location = new System.Drawing.Point(494, 18);
            this.cb_idPrueba.Name = "cb_idPrueba";
            this.cb_idPrueba.Size = new System.Drawing.Size(172, 28);
            this.cb_idPrueba.TabIndex = 4;
            // 
            // DReportesBindingSource
            // 
            this.DReportesBindingSource.DataSource = typeof(CapaDatos.DReportePreguntaYOpciones);
            // 
            // btn_Generar
            // 
            this.btn_Generar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Generar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generar.ForeColor = System.Drawing.Color.White;
            this.btn_Generar.Location = new System.Drawing.Point(834, 13);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(121, 37);
            this.btn_Generar.TabIndex = 5;
            this.btn_Generar.Text = "Generar";
            this.btn_Generar.UseVisualStyleBackColor = false;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // FReporteEvaluaciones
            // 
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btn_Generar);
            this.Controls.Add(this.cb_idPrueba);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_cedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rv);
            this.Name = "FReporteEvaluaciones";
            this.Load += new System.EventHandler(this.FReporteEvaluaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DEvaluacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DReportesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rv;
        private System.Windows.Forms.BindingSource DReportesBindingSource;
        private System.Windows.Forms.BindingSource DEvaluacionBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_cedula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_idPrueba;
        private System.Windows.Forms.Button btn_Generar;


    }
}