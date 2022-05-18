using CapaNegocio;
using CapaNegocio.Logica.Carga;
using CapaPresentacion.Logica;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.CRUD
{
    public partial class FPreguntaSelMulCRUD : Form
    {
        DataGridViewImageColumn dgvImg_upd;
        DataGridViewImageColumn dgvImg_del;
        DataGridViewComboBoxColumn dgvCB_Tema;
        bool flagEditando { get; set; }

        public FPreguntaSelMulCRUD()
        {
            InitializeComponent();
            this.MaximizeBox = true;
        }

        void tb_Op1_TextChanged(object sender, EventArgs e)
        {

        }
        //
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FPreguntasCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_InsertPregunta_Click(object sender, EventArgs e)
        {

        }

        private void dgvPreguntas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_LeerCSV_Click(object sender, EventArgs e)
        {
            string FilePath = string.Empty;

            PCuadroDialogo PCuadroDialogo_obj = new PCuadroDialogo();
            FilePath = PCuadroDialogo_obj.leerNombreArchivo();

            NLectorSeleccionMultiple lector_obj = new NLectorSeleccionMultiple(FilePath);

            try
            {
                lector_obj.Leer();
                MessageBox.Show("Se ingresaron correctamente las preguntas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se ingresaron las preguntas");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            NPregunta.EliminarSelMul();
            MessageBox.Show("Todas las preguntas de tipo selección múltiple fueron eliminadas");
        }
    }
}