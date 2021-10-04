using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using CapaPresentacion.Base;


namespace CapaPresentacion.Forms.Configuracion
{
    public partial class FConfigEval : Form
    {
        DataTable DtTemas;

        public FConfigEval()
        {
            InitializeComponent();
            CargarLicencias();
            try
            {
                cb_MinEval.SelectedItem = Properties.Settings.Default.MinEval.ToString();
                cb_SegEval.SelectedItem = Properties.Settings.Default.SegEval.ToString();
                cb_NPreguntas.SelectedItem = Properties.Settings.Default.NumPreguntas.ToString();
                tb_DescripcionEval.Text = Properties.Settings.Default.DescripcionEval;
                tb_ciudad.Text = Properties.Settings.Default.Ciudad;
                tb_patrocinador.Text = Properties.Settings.Default.Patrocinador;
                tb_empresa.Text = Properties.Settings.Default.Empresa;
                dtp_inicioCampaña.Value = DateTime.Parse(Properties.Settings.Default.FechaInicioCampaña);
                dtp_finCampaña.Value = DateTime.Parse(Properties.Settings.Default.FechaFinCampaña);
                tb_direccion.Text = Properties.Settings.Default.Direccion;
                tb_nombreCampaña.Text = Properties.Settings.Default.NombreCampaña;
                tb_rutaLogo.Text = Properties.Settings.Default.RutaLogo;
                cb_LicenciaPorDefecto.SelectedValue = Properties.Settings.Default.LicenciaPorDefecto;
                if (File.Exists(Properties.Settings.Default.RutaLogo))
                    pb_logo.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            cb_MinEval.SelectedValueChanged += cb_SelectedValueChanged;
            cb_SegEval.SelectedValueChanged += cb_SelectedValueChanged;
            cb_NPreguntas.SelectedValueChanged += cb_SelectedValueChanged;
            tb_DescripcionEval.TextChanged += cb_SelectedValueChanged;
            tb_ciudad.TextChanged += cb_SelectedValueChanged;
            tb_patrocinador.TextChanged += cb_SelectedValueChanged;
            tb_empresa.TextChanged += cb_SelectedValueChanged;
            dtp_inicioCampaña.TextChanged += cb_SelectedValueChanged;
            dtp_finCampaña.TextChanged += cb_SelectedValueChanged;
            tb_direccion.TextChanged += cb_SelectedValueChanged;
            tb_nombreCampaña.TextChanged += cb_SelectedValueChanged;
            tb_rutaLogo.TextChanged += cb_SelectedValueChanged;
            cb_LicenciaPorDefecto.SelectedValueChanged += cb_SelectedValueChanged;

            clb.ItemCheck += clb_ItemCheck;

            CargarTemas();
        }

        /// <summary>
        /// Cada que se cambia un checkbox, se actualiza DtTemas con el valor del check (Incluir_En_Evaluacion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clb_ItemCheck(object sender, EventArgs e)
        {
            int indice = clb.SelectedIndex;
            if (indice == -1)
                return;

            string Enunc = clb.SelectedItem.ToString();
            bool check = clb.GetItemChecked(indice);

            foreach (DataRow row in DtTemas.Rows)
            {
                if (row["Enunciado"].ToString() == Enunc)
                    row["Incluir_En_Evaluacion"] = !check;
            }
            btn_Guardar.Enabled = true;
        }

        /// <summary>
        /// Recupera los temas desde la BD y los convierte en CheckedListBox
        /// </summary>
        void CargarTemas()
        {
            DtTemas = NTema.Mostrar();
            foreach (DataRow row in DtTemas.Rows)
            {
                clb.Items.Add(row["Enunciado"], (bool)row["Incluir_En_Evaluacion"]);
            }
        }

        void CargarLicencias()
        {
            DataTable rta = NTipoLicencia.Mostrar();

            this.cb_LicenciaPorDefecto.DataSource = rta;
            this.cb_LicenciaPorDefecto.DisplayMember = "TIPO_LICENCIA";
            this.cb_LicenciaPorDefecto.ValueMember = "ID";
        }

        private void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in DtTemas.Rows)
            {
                int Id = Convert.ToInt32(dr["ID"]);
                int Com = Convert.ToInt32(dr["ID_Competencia"]);
                string Enunc = dr["Enunciado"].ToString();
                bool Inc = (bool)dr["Incluir_En_Evaluacion"];
                NTema.Editar(Id, Com, Enunc, Inc);
            }
            Properties.Settings.Default.MinEval = int.Parse(cb_MinEval.SelectedItem.ToString());
            Properties.Settings.Default.SegEval = int.Parse(cb_SegEval.SelectedItem.ToString());
            Properties.Settings.Default.NumPreguntas = int.Parse(cb_NPreguntas.SelectedItem.ToString());
            Properties.Settings.Default.DescripcionEval = tb_DescripcionEval.Text;
            Properties.Settings.Default.Ciudad = tb_ciudad.Text;
            Properties.Settings.Default.Patrocinador = tb_patrocinador.Text;
            Properties.Settings.Default.Empresa = tb_empresa.Text;
            Properties.Settings.Default.FechaInicioCampaña = dtp_inicioCampaña.Value.ToString();
            Properties.Settings.Default.FechaFinCampaña = dtp_finCampaña.Value.ToString();
            Properties.Settings.Default.Direccion = tb_direccion.Text;
            Properties.Settings.Default.NombreCampaña = tb_nombreCampaña.Text;
            Properties.Settings.Default.RutaLogo = tb_rutaLogo.Text;
            Properties.Settings.Default.LicenciaPorDefecto = int.Parse(cb_LicenciaPorDefecto.SelectedValue.ToString());
            if (File.Exists(Properties.Settings.Default.RutaLogo))
                pb_logo.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);

            Properties.Settings.Default.Save();
            btn_Guardar.Enabled = false;
        }

        private void FConfigEval_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_Guardar.Enabled == true)
            {
                DialogResult rst;
                rst = MessageBox.Show("Hay cambios que no se han guardado, ¿Desea realmente salir?", "Atención", MessageBoxButtons.YesNo);
                if (rst != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btn_cargarLogo_Click(object sender, EventArgs e)
        {
            //string FileName = string.Empty;
            using (var ofd = new OpenFileDialog())
            {
                //Obtiene nombre del archivo a leer
                ofd.Multiselect = false;
                ofd.Title = "SELECCION LOGO";
                ofd.Filter = "JPEG|*.jpg|Bitmaps|*.bmp";
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                { tb_rutaLogo.Text = ofd.FileName; }
                else { return; }
            }
        }

    }
}
