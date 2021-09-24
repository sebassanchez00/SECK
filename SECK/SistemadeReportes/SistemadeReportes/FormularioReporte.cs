using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
//using CrystalDecisions.Shared;
using ReportesBDSimuladoresVehiculo;

namespace SistemadeReportes
{
    public partial class FormularioReporte : Form
    {
        CrystalReport2 rpt;
        public FormularioReporte()
        {

            InitializeComponent();
            rpt = new CrystalReport2();
        }


        public string idreporte;

        private void FormularioReporte_Load(object sender, EventArgs e)
        {
            //string consultar = "select * from v_reportes_usuarios where id_reporte= '" + IDREPORTE + "'";
           
            //rpt.SetDataSource(NReportes.GenerarReporte(idreporte));
            //rpt.SetParameterValue("TipopSimulacion", "Camioneta Pickup");
            crystalReportViewer1.ReportSource = rpt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carpeta = "Kirvit";
            string ruta = @"D:\Reportes\";


            if (Directory.Exists(ruta))
            {
                //              


                string path = ruta + "12" + ".pdf";
                // Declarar variables y obtener las opciones de exportación.
                //ExportOptions exportOpts = new ExportOptions();
                //PdfFormatOptions excelFormatOpts = new PdfFormatOptions();
                //DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                //exportOpts = rpt.ExportOptions;

                // Establecer las opciones de formato de Excel.
                //excelFormatOpts.ExcelUseConstantColumnWidth = true;
                //exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
                //exportOpts.FormatOptions = excelFormatOpts;

                // Establecer las opciones de archivo de disco y de exportación.
                //exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                //diskOpts.DiskFileName = path;
                //exportOpts.DestinationOptions = diskOpts;

                //rpt.Export();


                if (Directory.Exists(path))
                {

                    MessageBox.Show("guardado");

                }
            }

            else
            {
                //Directory.CreateDirectory(ruta);
                //string path = ruta + "12" + ".pdf";
                //// Declarar variables y obtener las opciones de exportación.
                //ExportOptions exportOpts = new ExportOptions();
                //PdfFormatOptions excelFormatOpts = new PdfFormatOptions();
                //DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                //exportOpts = rpt.ExportOptions;

                //// Establecer las opciones de formato de Excel.
                ////excelFormatOpts.ExcelUseConstantColumnWidth = true;
                //exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
                //exportOpts.FormatOptions = excelFormatOpts;

                //// Establecer las opciones de archivo de disco y de exportación.
                //exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                //diskOpts.DiskFileName = path;
                //exportOpts.DestinationOptions = diskOpts;

                //rpt.Export();

            }
        }


    }
}
