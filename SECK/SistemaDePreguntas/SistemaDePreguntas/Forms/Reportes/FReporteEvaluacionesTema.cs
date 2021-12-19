using Microsoft.Reporting.WinForms;
using CapaNegocio;
using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.Reportes
{
    public partial class FReporteEvaluacionesTema : Form
    {
        public FReporteEvaluacionesTema()
        {
            InitializeComponent();
        }

        private void FReporteEvaluaciones_Load(object sender, EventArgs e)
        {
            LlenarCombos();
        }
        private void LlenarCombos() 
        {
            cb_cedula.DisplayMember = "CEDULAS";
            cb_cedula.ValueMember = "CEDULAS";
            cb_cedula.DataSource = NConductor.Mostrar();
        }
        public void Actual_Report(string cedula)
        {
            cb_idPrueba.DisplayMember = "ID";
            cb_idPrueba.ValueMember = "ID";
            cb_idPrueba.DataSource = NEvaluacion.MostrarPorIDConductor(cedula);

            rv.LocalReport.DataSources.Clear();

            DataTable dt_Eval = NEvaluacion.MostrarPorIDEval((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Evaluacion;
            dsour_Evaluacion = new ReportDataSource();
            dsour_Evaluacion.Name = "DataSet_DEvaluacion";
            dsour_Evaluacion.Value = dt_Eval;
            rv.LocalReport.DataSources.Add(dsour_Evaluacion);

            DataTable dt_Cond = NConductor.MostrarDatos_dt(cedula);
            ReportDataSource dsour_Conductor; 
            dsour_Conductor = new ReportDataSource();
            dsour_Conductor.Name = "DataSet_DConductor";
            dsour_Conductor.Value = dt_Cond;
            rv.LocalReport.DataSources.Add(dsour_Conductor);

            DataTable dt_Cues = NRegistroPreguntas.Mostrar_Por_ID_Evaluacion((string)cb_idPrueba.SelectedValue);// NConductor.MostrarDatos_dt((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Cuestionario;
            dsour_Cuestionario = new ReportDataSource();
            dsour_Cuestionario.Name = "DataSet_DCuestionario";
            dsour_Cuestionario.Value = dt_Cues;
            rv.LocalReport.DataSources.Add(dsour_Cuestionario);

            DataTable dt_Opc = NORegistroOpcionesPreguntas.MostrarEvaluacionConOpciones((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Opciones;
            dsour_Opciones = new ReportDataSource();
            dsour_Opciones.Name = "DataSet_DOpcionesCuestionario";
            dsour_Opciones.Value = dt_Opc;
            rv.LocalReport.DataSources.Add(dsour_Opciones);

            DataTable dt_Rep = NReportePreguntaYOpciones.Mostrar((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Rep;
            dsour_Rep = new ReportDataSource();
            dsour_Rep.Name = "DataSet_DReportePreguntaYOpciones";
            dsour_Rep.Value = dt_Rep;
            rv.LocalReport.DataSources.Add(dsour_Rep);

            // Refresh the report     
            rv.RefreshReport();
        }        
        private void Actualiza_Datos_Reporte()
        {
            rv.LocalReport.DataSources.Clear();

            DataTable dt_Eval = NEvaluacion.MostrarPorIDEval((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Evaluacion;
            dsour_Evaluacion = new ReportDataSource();
            dsour_Evaluacion.Name = "DataSet_DEvaluacion";
            dsour_Evaluacion.Value = dt_Eval;
            rv.LocalReport.DataSources.Add(dsour_Evaluacion);

            DataTable dt_Cond = NConductor.MostrarDatos_dt((string)cb_cedula.SelectedValue);
            ReportDataSource dsour_Conductor; 
            dsour_Conductor = new ReportDataSource();
            dsour_Conductor.Name = "DataSet_DConductor";
            dsour_Conductor.Value = dt_Cond;
            rv.LocalReport.DataSources.Add(dsour_Conductor);

            DataTable dt_Cues = NRegistroPreguntas.Mostrar_Por_ID_Evaluacion((string)cb_idPrueba.SelectedValue);// NConductor.MostrarDatos_dt((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Cuestionario;
            dsour_Cuestionario = new ReportDataSource();
            dsour_Cuestionario.Name = "DataSet_DCuestionario";
            dsour_Cuestionario.Value = dt_Cues;
            rv.LocalReport.DataSources.Add(dsour_Cuestionario);

            DataTable dt_Opc = NORegistroOpcionesPreguntas.MostrarEvaluacionConOpciones((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Opciones;
            dsour_Opciones = new ReportDataSource();
            dsour_Opciones.Name = "DataSet_DOpcionesCuestionario";
            dsour_Opciones.Value = dt_Opc;
            rv.LocalReport.DataSources.Add(dsour_Opciones);

            DataTable dt_Rep = NReportePreguntaYOpciones.Mostrar((string)cb_idPrueba.SelectedValue);
            ReportDataSource dsour_Rep;
            dsour_Rep = new ReportDataSource();
            dsour_Rep.Name = "DataSet_DReportePreguntaYOpciones";
            dsour_Rep.Value = dt_Rep;
            rv.LocalReport.DataSources.Add(dsour_Rep);

            // Refresh the report     
            rv.RefreshReport();
        }

        private void cb_cedula_SelectedValueChanged(object sender, EventArgs e)
        {
            cb_idPrueba.DisplayMember = "ID";
            cb_idPrueba.ValueMember = "ID";
            cb_idPrueba.DataSource = NEvaluacion.MostrarPorIDConductor((string)cb_cedula.SelectedValue);
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            Actualiza_Datos_Reporte();
        }
    }
}           