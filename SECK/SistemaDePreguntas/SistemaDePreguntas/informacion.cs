using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class informacion : Form
    {
        public informacion()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {            

        }
        public void crystalReportLoad()
        {
            crystalReportViewer1.ReportSource = this;
        }
    }
}
