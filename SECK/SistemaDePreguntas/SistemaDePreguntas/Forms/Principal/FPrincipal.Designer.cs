namespace CapaPresentacion.Forms.Principal
{
    partial class FPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.MenuStrip_Ppl = new System.Windows.Forms.MenuStrip();
            this.TSMI_Autenticación = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Configuracion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AdmPreguntas = new System.Windows.Forms.ToolStripMenuItem();
            this.selecciónMúltipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdaderoFalsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abiertaNuméricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecciónMúltipleConImagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AdmCond = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AdmEval = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Programacion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Registro = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Eval = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_NuevaEval = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Reporte = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Evaluaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_EvaluacionesConTema = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Ppl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip_Ppl
            // 
            this.MenuStrip_Ppl.BackColor = System.Drawing.Color.White;
            this.MenuStrip_Ppl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuStrip_Ppl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Autenticación,
            this.TSMI_Configuracion,
            this.TSMI_Programacion,
            this.TSMI_Registro,
            this.TSMI_Eval,
            this.TSMI_Reporte});
            this.MenuStrip_Ppl.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Ppl.Name = "MenuStrip_Ppl";
            this.MenuStrip_Ppl.Size = new System.Drawing.Size(1083, 35);
            this.MenuStrip_Ppl.TabIndex = 2;
            this.MenuStrip_Ppl.Text = "menuStrip1";
            // 
            // TSMI_Autenticación
            // 
            this.TSMI_Autenticación.Enabled = false;
            this.TSMI_Autenticación.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Autenticación.Name = "TSMI_Autenticación";
            this.TSMI_Autenticación.Size = new System.Drawing.Size(153, 31);
            this.TSMI_Autenticación.Text = "Autenticación";
            // 
            // TSMI_Configuracion
            // 
            this.TSMI_Configuracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_AdmPreguntas,
            this.TSMI_AdmCond,
            this.TSMI_AdmEval});
            this.TSMI_Configuracion.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Configuracion.Name = "TSMI_Configuracion";
            this.TSMI_Configuracion.Size = new System.Drawing.Size(158, 31);
            this.TSMI_Configuracion.Text = "Configuracion";
            // 
            // TSMI_AdmPreguntas
            // 
            this.TSMI_AdmPreguntas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecciónMúltipleToolStripMenuItem,
            this.verdaderoFalsoToolStripMenuItem,
            this.abiertaNuméricaToolStripMenuItem,
            this.selecciónMúltipleConImagenToolStripMenuItem});
            this.TSMI_AdmPreguntas.Name = "TSMI_AdmPreguntas";
            this.TSMI_AdmPreguntas.Size = new System.Drawing.Size(205, 32);
            this.TSMI_AdmPreguntas.Text = "Preguntas";
            // 
            // selecciónMúltipleToolStripMenuItem
            // 
            this.selecciónMúltipleToolStripMenuItem.Name = "selecciónMúltipleToolStripMenuItem";
            this.selecciónMúltipleToolStripMenuItem.Size = new System.Drawing.Size(376, 32);
            this.selecciónMúltipleToolStripMenuItem.Text = "Selección Múltiple";
            this.selecciónMúltipleToolStripMenuItem.Click += new System.EventHandler(this.TSMI_AdmPreguntaSelMul_Click);
            // 
            // verdaderoFalsoToolStripMenuItem
            // 
            this.verdaderoFalsoToolStripMenuItem.Name = "verdaderoFalsoToolStripMenuItem";
            this.verdaderoFalsoToolStripMenuItem.Size = new System.Drawing.Size(376, 32);
            this.verdaderoFalsoToolStripMenuItem.Text = "Verdadero/Falso";
            this.verdaderoFalsoToolStripMenuItem.Click += new System.EventHandler(this.TSMI_VerdaderoFalso_Click);
            // 
            // abiertaNuméricaToolStripMenuItem
            // 
            this.abiertaNuméricaToolStripMenuItem.Name = "abiertaNuméricaToolStripMenuItem";
            this.abiertaNuméricaToolStripMenuItem.Size = new System.Drawing.Size(376, 32);
            this.abiertaNuméricaToolStripMenuItem.Text = "Abierta Numérica";
            this.abiertaNuméricaToolStripMenuItem.Click += new System.EventHandler(this.TSMI_AbiertaNumerica_Click);
            // 
            // selecciónMúltipleConImagenToolStripMenuItem
            // 
            this.selecciónMúltipleConImagenToolStripMenuItem.Name = "selecciónMúltipleConImagenToolStripMenuItem";
            this.selecciónMúltipleConImagenToolStripMenuItem.Size = new System.Drawing.Size(376, 32);
            this.selecciónMúltipleConImagenToolStripMenuItem.Text = "Selección Múltiple con Imagen";
            this.selecciónMúltipleConImagenToolStripMenuItem.Click += new System.EventHandler(this.TSMI_SelMulImg_Click);
            // 
            // TSMI_AdmCond
            // 
            this.TSMI_AdmCond.Name = "TSMI_AdmCond";
            this.TSMI_AdmCond.Size = new System.Drawing.Size(205, 32);
            this.TSMI_AdmCond.Text = "Conductores";
            this.TSMI_AdmCond.Click += new System.EventHandler(this.TSMI_AdmCond_Click);
            // 
            // TSMI_AdmEval
            // 
            this.TSMI_AdmEval.Name = "TSMI_AdmEval";
            this.TSMI_AdmEval.Size = new System.Drawing.Size(205, 32);
            this.TSMI_AdmEval.Text = "Evaluación";
            this.TSMI_AdmEval.Click += new System.EventHandler(this.TSMI_AdmEval_Click);
            // 
            // TSMI_Programacion
            // 
            this.TSMI_Programacion.Enabled = false;
            this.TSMI_Programacion.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Programacion.Name = "TSMI_Programacion";
            this.TSMI_Programacion.Size = new System.Drawing.Size(159, 31);
            this.TSMI_Programacion.Text = "Programación";
            // 
            // TSMI_Registro
            // 
            this.TSMI_Registro.Enabled = false;
            this.TSMI_Registro.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Registro.Name = "TSMI_Registro";
            this.TSMI_Registro.Size = new System.Drawing.Size(103, 31);
            this.TSMI_Registro.Text = "Registro";
            // 
            // TSMI_Eval
            // 
            this.TSMI_Eval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_NuevaEval});
            this.TSMI_Eval.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Eval.Name = "TSMI_Eval";
            this.TSMI_Eval.Size = new System.Drawing.Size(125, 31);
            this.TSMI_Eval.Text = "Evaluación";
            // 
            // TSMI_NuevaEval
            // 
            this.TSMI_NuevaEval.Name = "TSMI_NuevaEval";
            this.TSMI_NuevaEval.Size = new System.Drawing.Size(145, 32);
            this.TSMI_NuevaEval.Text = "Nueva";
            this.TSMI_NuevaEval.Click += new System.EventHandler(this.TSMI_Nueva_Click);
            // 
            // TSMI_Reporte
            // 
            this.TSMI_Reporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Evaluaciones,
            this.TSMI_EvaluacionesConTema});
            this.TSMI_Reporte.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMI_Reporte.Name = "TSMI_Reporte";
            this.TSMI_Reporte.Size = new System.Drawing.Size(109, 31);
            this.TSMI_Reporte.Text = "Reportes";
            // 
            // TSMI_Evaluaciones
            // 
            this.TSMI_Evaluaciones.Name = "TSMI_Evaluaciones";
            this.TSMI_Evaluaciones.Size = new System.Drawing.Size(313, 32);
            this.TSMI_Evaluaciones.Text = "Evaluaciones";
            this.TSMI_Evaluaciones.Click += new System.EventHandler(this.TSMI_Evaluaciones_Click);
            // 
            // TSMI_EvaluacionesConTema
            // 
            this.TSMI_EvaluacionesConTema.Name = "TSMI_EvaluacionesConTema";
            this.TSMI_EvaluacionesConTema.Size = new System.Drawing.Size(313, 32);
            this.TSMI_EvaluacionesConTema.Text = "Evaluaciones con Temas";
            this.TSMI_EvaluacionesConTema.Click += new System.EventHandler(this.TSMI_EvaluacionesConTema_Click);
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1083, 730);
            this.Controls.Add(this.MenuStrip_Ppl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStrip_Ppl;
            this.Name = "FPrincipal";
            this.Text = "SISTEMA DE PREGUNTAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPrincipal_Load);
            this.MenuStrip_Ppl.ResumeLayout(false);
            this.MenuStrip_Ppl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Ppl;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Eval;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Configuracion;
        private System.Windows.Forms.ToolStripMenuItem TSMI_NuevaEval;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AdmPreguntas;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Reporte;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Evaluaciones;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AdmEval;
        private System.Windows.Forms.ToolStripMenuItem selecciónMúltipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdaderoFalsoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abiertaNuméricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecciónMúltipleConImagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AdmCond;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Autenticación;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Programacion;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Registro;
        private System.Windows.Forms.ToolStripMenuItem TSMI_EvaluacionesConTema;
    }
}