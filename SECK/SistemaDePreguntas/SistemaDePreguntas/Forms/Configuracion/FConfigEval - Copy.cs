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
    public partial class FConfigEval2 : Form
    {
        DataTable DtTemas;

        public FConfigEval2()
        {
            InitializeComponent();
            try
            {
                cb_MinEval.SelectedItem = Properties.Settings.Default.MinEval.ToString();
                cb_SegEval.SelectedItem = Properties.Settings.Default.SegEval.ToString();
                cb_NPreguntas.SelectedItem = Properties.Settings.Default.NumPreguntas.ToString();
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
    }
}
