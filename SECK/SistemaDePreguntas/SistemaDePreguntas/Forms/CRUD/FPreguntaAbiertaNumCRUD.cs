using CapaNegocio;
using CapaNegocio.Logica.Carga;
using CapaPresentacion.Logica;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.CRUD
{
    public partial class FPreguntaAbiertaNumCRUD : Form
    {
        public FPreguntaAbiertaNumCRUD()
        {
            InitializeComponent();
            if (File.Exists(Properties.Settings.Default.RutaLogo))
                pb_logo.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
        }
        
        private void btn_LeerCSV_Click(object sender, EventArgs e)
        {
            string FilePath = string.Empty;

            PCuadroDialogo PCuadroDialogo_obj = new PCuadroDialogo();
            FilePath = PCuadroDialogo_obj.leerNombreArchivo();

            NLectorAbiertaNumerica lector_obj = new NLectorAbiertaNumerica(FilePath);

            try
            { 
                lector_obj.Leer();
                MessageBox.Show("Se ingresaron correctamente las preguntas");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "No se ingresaron las preguntas");
            }     
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            NPregunta.EliminarAbNum();
            MessageBox.Show("Todas las preguntas de tipo abierta numérica fueron eliminadas");
        }
    }
}
