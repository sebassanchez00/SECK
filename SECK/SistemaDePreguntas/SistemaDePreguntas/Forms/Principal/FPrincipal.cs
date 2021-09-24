using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Forms.CRUD;
using CapaPresentacion.Forms.Principal;
using CapaPresentacion.Forms.Configuracion;
using CapaPresentacion.Forms.Reportes;

namespace CapaPresentacion.Forms.Principal
{
    public partial class FPrincipal : Form
    {
        Timer T_ = new Timer();

        FPreguntas FPreguntasObj_;
        FConfigEval FConfigEvalObj_;
        FPreguntaSelMulCRUD FPreguntSelMulCRUDObj_;
        FPreguntaSelMulImgCRUD FPreguntaSelMulImgRUDObj_;
        FPreguntaVFCRUD FPreguntaVFCRUDObj_;
        FPreguntaAbiertaNumCRUD FPreguntaAbiertaNumCRUDObj_;
        FConductorCRUD FConductorCRUDObj_;
        FReporteEvaluaciones FReporteEvaluacionesObj_;
        FReportes FInformacionObj_;

        public FPreguntas FPreguntasObj
        {
            get { return FPreguntasObj_; }
            set { FPreguntasObj_ = value; }
        }
        public FConfigEval FConfigEvalObj
        {
            get { return FConfigEvalObj_; }
            set { FConfigEvalObj_ = value; }
        }
        public FPreguntaSelMulCRUD FPreguntSelMulCRUDObj
        {
            get { return FPreguntSelMulCRUDObj_; }
            set { FPreguntSelMulCRUDObj_ = value; }
        }
        public FPreguntaSelMulImgCRUD FPreguntaSelMulImgRUDObj
        {
            get { return FPreguntaSelMulImgRUDObj_; }
            set { FPreguntaSelMulImgRUDObj_ = value; }
        }
        public FPreguntaVFCRUD FPreguntaVFCRUDObj
        {
            get { return FPreguntaVFCRUDObj_; }
            set { FPreguntaVFCRUDObj_ = value; }
        }
        public FPreguntaAbiertaNumCRUD FPreguntaAbiertaNumCRUDObj
        {
            get { return FPreguntaAbiertaNumCRUDObj_; }
            set { FPreguntaAbiertaNumCRUDObj_ = value; }
        }
        public FConductorCRUD FConductorCRUDObj
        {
            get { return FConductorCRUDObj_; }
            set { FConductorCRUDObj_ = value; }
        }
        public FReporteEvaluaciones FReporteEvaluacionesObj
        {
            get { return FReporteEvaluacionesObj_; }
            set { FReporteEvaluacionesObj_ = value; }
        }
        public FReportes FInformacionObj
        {
            get { return FInformacionObj_; }
            set { FInformacionObj_ = value; }
        }        

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            ValidarConfig();
        }

        private void ValidarConfig()
        {
            //Añade Dll a la carpeta bin (o release) 
            if (!File.Exists("BXLPDC.dll"))
            {
                var outStream = new StreamWriter("BXLPDC.dll", false);
                var binStream = new BinaryWriter(outStream.BaseStream);
                binStream.Write(Properties.Resources.BXLPDC);
                binStream.Close();
            }
            //Añade Dll a la carpeta bin (o release) 
            if (!File.Exists("BXLPDC_x64.dll"))
            {
                var outStream = new StreamWriter("BXLPDC_x64.dll", false);
                var binStream = new BinaryWriter(outStream.BaseStream);
                binStream.Write(Properties.Resources.BXLPDC_x64);
                binStream.Close();
            }
            //Verifica el string de conexion 
            if (!NConexion.TestCon())
            {
                MessageBox.Show(
                    string.Format("No hay conexion con la base de datos. {0}{0}La aplicación tratará de reconfigurar la conexion. A continuación la aplicación se cerrará. Intente abrir la aplicación nuevamente.{0}{0}Si el problema persiste contacte al soporte técnico", System.Environment.NewLine)
                    , "Error");
                NConexion.EscribirConString();

                //Si entró en el if indica que se está configurando la BD por primera vez, entonces se alimenta la base de datos con los datos básicos

                NConfiguracionBD.InsertarDatosBasicos();
                this.Close();
            }
        }

        private void TSMI_Nueva_Click(object sender, EventArgs e)
        {
            T_.Enabled = false;
            Mostrar_FPreguntasObj();
        }
        private void TSMI_AdmPreguntaSelMul_Click(object sender, EventArgs e)
        {
            Mostrar_FPreguntSelMulCRUDObj();
        }
        private void TSMI_AdmEval_Click(object sender, EventArgs e)
        {
            Mostrar_FConfigEvalObj();
        }
        private void TSMI_SelMulImg_Click(object sender, EventArgs e)
        {
            Mostrar_FPreguntaSelMulImgRUDObj();
        }
        private void TSMI_VerdaderoFalso_Click(object sender, EventArgs e)
        {
            Mostrar_FPreguntaVFCRUDObj();
        }
        private void TSMI_AbiertaNumerica_Click(object sender, EventArgs e)
        {
            Mostrar_FPreguntaAbiertaNumCRUDObj();
        }
        private void TSMI_AdmCond_Click(object sender, EventArgs e)
        {
            Mostrar_FConductorCRUDObj();
        }
        private void TSMI_Evaluaciones_Click(object sender, EventArgs e)
        {
            Mostrar_FReporteEvaluacionesObj();
        }
        public void Mostrar_FPreguntasObj()
        {
            if (FPreguntasObj_ == null)
            {
                FPreguntasObj_ = new FPreguntas();
                FPreguntasObj_.MdiParent = this;
                FPreguntasObj_.Show();
                FPreguntasObj_.WindowState = FormWindowState.Maximized;
                FPreguntasObj_.FormClosed += (sender_, EventArgs_) => { FPreguntasObj_ = null; };
            }
            else
            {
                FPreguntasObj_.Show();
                FPreguntasObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FPreguntSelMulCRUDObj()
        {
            if (FPreguntSelMulCRUDObj_ == null)
            {
                FPreguntSelMulCRUDObj_ = new FPreguntaSelMulCRUD();
                FPreguntSelMulCRUDObj_.MdiParent = this;
                FPreguntSelMulCRUDObj_.Show();
                FPreguntSelMulCRUDObj_.WindowState = FormWindowState.Maximized;
                FPreguntSelMulCRUDObj_.FormClosed += (sender_, EventArgs_) => { FPreguntSelMulCRUDObj_ = null; };
            }
            else
            {
                FPreguntSelMulCRUDObj_.Show();
                FPreguntSelMulCRUDObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FConfigEvalObj()
        {
            if (FConfigEvalObj_ == null)
            {
                FConfigEvalObj_ = new FConfigEval();
                FConfigEvalObj_.MdiParent = this;
                FConfigEvalObj_.Show();
                FConfigEvalObj_.WindowState = FormWindowState.Maximized;
                FConfigEvalObj_.FormClosed += (sender_, EventArgs_) => { FConfigEvalObj_ = null; };
            }
            else
            {
                FConfigEvalObj_.Show();
                FConfigEvalObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FPreguntaSelMulImgRUDObj()
        {
            if (FPreguntaSelMulImgRUDObj_ == null)
            {
                FPreguntaSelMulImgRUDObj_ = new FPreguntaSelMulImgCRUD();
                FPreguntaSelMulImgRUDObj_.MdiParent = this;
                FPreguntaSelMulImgRUDObj_.Show();
                FPreguntaSelMulImgRUDObj_.WindowState = FormWindowState.Maximized;
                FPreguntaSelMulImgRUDObj_.FormClosed += (sender_, EventArgs_) => { FPreguntaSelMulImgRUDObj_ = null; };
            }
            else
            {
                FPreguntaSelMulImgRUDObj_.Show();
                FPreguntaSelMulImgRUDObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FPreguntaVFCRUDObj()
        {
            if (FPreguntaVFCRUDObj_ == null)
            {
                FPreguntaVFCRUDObj_ = new FPreguntaVFCRUD();
                FPreguntaVFCRUDObj_.MdiParent = this;
                FPreguntaVFCRUDObj_.Show();
                FPreguntaVFCRUDObj_.WindowState = FormWindowState.Maximized;
                FPreguntaVFCRUDObj_.FormClosed += (sender_, EventArgs_) => { FPreguntaVFCRUDObj_ = null; };
            }
            else
            {
                FPreguntaVFCRUDObj_.Show();
                FPreguntaVFCRUDObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FPreguntaAbiertaNumCRUDObj()
        {
            if (FPreguntaAbiertaNumCRUDObj_ == null)
            {
                FPreguntaAbiertaNumCRUDObj_ = new FPreguntaAbiertaNumCRUD();
                FPreguntaAbiertaNumCRUDObj_.MdiParent = this;
                FPreguntaAbiertaNumCRUDObj_.Show();
                FPreguntaAbiertaNumCRUDObj_.WindowState = FormWindowState.Maximized;
                FPreguntaAbiertaNumCRUDObj_.FormClosed += (sender_, EventArgs_) => { FPreguntaAbiertaNumCRUDObj_ = null; };
            }
            else
            {
                FPreguntaAbiertaNumCRUDObj_.Show();
                FPreguntaAbiertaNumCRUDObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FConductorCRUDObj()
        {
            if (FConductorCRUDObj_ == null)
            {
                FConductorCRUDObj_ = new Forms.CRUD.FConductorCRUD();
                FConductorCRUDObj_.MdiParent = this;
                FConductorCRUDObj_.Show();
                FConductorCRUDObj_.WindowState = FormWindowState.Maximized;
                FConductorCRUDObj_.FormClosed += (sender_, EventArgs_) => { FConductorCRUDObj_ = null; };
            }
            else
            {
                FConductorCRUDObj_.Show();
                FConductorCRUDObj_.WindowState = FormWindowState.Maximized;
            }
        }
        public void Mostrar_FInformeObj()
        {           
            if (FReporteEvaluacionesObj_ == null)
            {
                FInformacionObj_ = new FReportes();
                FInformacionObj_.MdiParent = this;
                FInformacionObj_.Show();
                FInformacionObj_.WindowState = FormWindowState.Maximized;
                FInformacionObj_.FormClosed += (sender_, EventArgs_) => { FInformacionObj_ = null; };
            }
            else
            {
                FInformacionObj_.Show();
                FInformacionObj_.WindowState = FormWindowState.Maximized;
            }
//            informacionobj.crystalReportLoad();
        }

        public void Mostrar_FReporteEvaluacionesObj()
        {
            if (FReporteEvaluacionesObj_ == null)
            {
                FReporteEvaluacionesObj_ = new FReporteEvaluaciones();
                FReporteEvaluacionesObj_.MdiParent = this;
                FReporteEvaluacionesObj_.Show();
                FReporteEvaluacionesObj_.WindowState = FormWindowState.Maximized;
                FReporteEvaluacionesObj_.FormClosed += (sender_, EventArgs_) => { FReporteEvaluacionesObj_ = null; };
            }
            else
            {
                FReporteEvaluacionesObj_.Show();
                FReporteEvaluacionesObj_.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Abre el form FPreguntas después de 2 segundos
        /// </summary>
        public void AbrirFormPreguntasConDelay()
        {
            T_.Tick += TSMI_Nueva_Click;
            T_.Enabled = true;
            T_.Interval = 1000;
        }
    
        /// <summary>
        /// Cambia la visibilidad del menúStrip
        /// </summary>
        public void VisibilidadMenuStrip(bool Visibilidad)
        {
            this.MenuStrip_Ppl.Visible = Visibilidad;
        }

        private void HOY_Click(object sender, EventArgs e)
        {
            Mostrar_FInformeObj();
            //            Mostrar_FReporteEvaluacionesObj();
        }
    }
}