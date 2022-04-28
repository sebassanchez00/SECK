﻿using CapaDatos;
using CapaNegocio;
using CapaNegocio.Logica;
using CapaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.CRUD
{
    public partial class FPreguntaAbiertaNumCRUD : Form
    {
        public FPreguntaAbiertaNumCRUD()
        {
            InitializeComponent();
            LlenarCombos();
            if (File.Exists(Properties.Settings.Default.RutaLogo))
                pb_logo.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
        }

        void LlenarCombos()
        {
            cb_Tema.DataSource = NTema.Mostrar();
            cb_Tema.DisplayMember = "Enunciado";
            cb_Tema.ValueMember = "ID";
        }
        private void btn_LeerCSV_Click(object sender, EventArgs e)
        {
            List<DPregunta> LPreguntas = new List<DPregunta>();
            string FileName = string.Empty;

            using (var ofd = new OpenFileDialog())
            {
                //Obtiene nombre del archivo a leer
                ofd.Multiselect = false;
                ofd.Title = "SELECCION ARCHIVO DE PREGUNTAS";
                ofd.Filter = "Archivo .csv | *.csv";
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                { FileName = ofd.FileName; }
                else { return; }
            }

            LPreguntas = NUtilidades.LeerArchivo(FileName, int.Parse(this.cb_Tema.SelectedValue.ToString()), TipoPreg.AbiertaNumerica);

            if (LPreguntas == null)
                return;

            bool flag_inserto = false;
            foreach (DPregunta preg in LPreguntas)
            {
                NPregunta.Insertar(preg.Tema, preg.Id_TipoPregunta, preg.Enunciado, preg.Imagen, preg.Opcion1, preg.EsCorrectaOp1, preg.Opcion2, preg.EsCorrectaOp2, preg.Opcion3, preg.EsCorrectaOp3, preg.Opcion4, preg.EsCorrectaOp4);
                flag_inserto = true;
            }

            if (flag_inserto == true)
                MessageBox.Show("Se guardaron exitosamente todas las preguntas", "Atención");
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            NPregunta.EliminarAbNum();
        }
    }
}
