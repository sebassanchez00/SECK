using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using CapaPresentacion.Reportes;

namespace CapaPresentacion.Forms.Reportes
{
    public partial class FReportes : Form
    {
        public FReportes()
        {
            InitializeComponent();
        }

        private void FReportes_Load(object sender, EventArgs e)
        {
            CrystalReporte rpt = new CrystalReporte();
            crystalReportViewer1.ReportSource = rpt;
        }


    }
}
