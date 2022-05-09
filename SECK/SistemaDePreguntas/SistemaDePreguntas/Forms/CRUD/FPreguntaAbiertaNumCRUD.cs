using CapaDatos;
using CapaNegocio;
using CapaNegocio.Logica.Carga;
using CapaNegocio.Enums;
using CapaPresentacion.Logica;
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
            string FilePath = string.Empty;

            PCuadroDialogo PCuadroDialogo_obj = new PCuadroDialogo();
            FilePath = PCuadroDialogo_obj.leerNombreArchivo();

            NLectorAbiertaNumerica lector_obj = new NLectorAbiertaNumerica(FilePath);
            lector_obj.Leer();

            MessageBox.Show("Se ingresaron correctamente las preguntas");
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            NPregunta.EliminarAbNum();
        }
    }
}
