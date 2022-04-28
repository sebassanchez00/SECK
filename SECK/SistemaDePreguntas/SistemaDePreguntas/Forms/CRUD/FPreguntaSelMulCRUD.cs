using CapaDatos;
using CapaNegocio;
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

            #region Ajustes datagridview preguntas ---------------------------------------------

            dgvPreguntas.ColumnCount = 4;
            dgvPreguntas.AutoGenerateColumns = false; //No incrusta las columnas automaticamente en la propidedad DataSource 
            //Environment.CurrentDirectory

            dgvImg_upd = new DataGridViewImageColumn();
            dgvImg_upd.Name = "col_Actualizar";
            dgvImg_upd.HeaderText = string.Empty;
            dgvImg_upd.DataPropertyName = "col_Actualizar";
            dgvImg_upd.Width = 35;
            dgvImg_upd.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvImg_upd.Image = Image.FromFile(@"C:\Users\INFORMATICA1\Documents\Sebastian Sanchez\TFS\SistemaDePreguntas\SistemaDePreguntas\SistemaDePreguntas\Imagenes\update.png");
            dgvImg_upd.Image = Image.FromFile(Environment.CurrentDirectory + "\\Imagenes\\update.png");
            dgvPreguntas.Columns.Insert(0, dgvImg_upd);

            dgvImg_del = new DataGridViewImageColumn();
            dgvImg_del.Name = "col_Eliminar";
            dgvImg_del.HeaderText = string.Empty;
            dgvImg_del.DataPropertyName = "col_Eliminar";
            dgvImg_del.Width = 35;
            dgvImg_del.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvImg_del.Image = Image.FromFile(@"C:\Users\INFORMATICA1\Documents\Sebastian Sanchez\TFS\SistemaDePreguntas\SistemaDePreguntas\SistemaDePreguntas\Imagenes\delete.png");
            dgvImg_del.Image = Image.FromFile(Environment.CurrentDirectory + "\\Imagenes\\delete.png");
            dgvPreguntas.Columns.Insert(1, dgvImg_del);

            dgvPreguntas.Columns[2].Name = "ID";
            dgvPreguntas.Columns[2].HeaderText = "ID";
            dgvPreguntas.Columns[2].DataPropertyName = "ID";
            dgvPreguntas.Columns[2].Width = 35;
            dgvPreguntas.Columns[2].ReadOnly = true;

            dgvCB_Tema = new DataGridViewComboBoxColumn();
            dgvCB_Tema.Name = "TEMA";
            dgvCB_Tema.HeaderText = "TEMA";
            dgvCB_Tema.DataPropertyName = "TEMA";
            dgvCB_Tema.DataSource = NTema.Mostrar();
            dgvCB_Tema.DisplayMember = "Enunciado";
            dgvCB_Tema.ValueMember = "Enunciado";
            dgvCB_Tema.Width = 250;
            dgvPreguntas.Columns.Insert(3, dgvCB_Tema);

            dgvPreguntas.Columns[4].HeaderText = "ENUNCIADO";
            dgvPreguntas.Columns[4].Name = "ENUNCIADO";
            dgvPreguntas.Columns[4].DataPropertyName = "ENUNCIADO";
            dgvPreguntas.Columns[4].Width = 400;

            dgvPreguntas.DataSource = NPregunta.MostrarSelMul();

            #endregion ------------------------------------------------------------

            #region Ajustes datagridview opciones ---------------------------------

            dgvOpciones.ColumnCount = 3;
            dgvOpciones.AutoGenerateColumns = false; //No incrusta las columnas automaticamente en la propidedad DataSource

            dgvImg_upd = new DataGridViewImageColumn();
            dgvImg_upd.Name = "col_Actualizar";
            dgvImg_upd.HeaderText = string.Empty;
            dgvImg_upd.DataPropertyName = "col_Actualizar";
            dgvImg_upd.Width = 35;
            dgvImg_upd.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvImg_upd.Image = Image.FromFile(@"C:\Users\INFORMATICA1\Documents\Sebastian Sanchez\TFS\SistemaDePreguntas\SistemaDePreguntas\SistemaDePreguntas\Imagenes\update.png");
            dgvImg_upd.Image = Image.FromFile(Environment.CurrentDirectory + "\\Imagenes\\update.png");
            dgvOpciones.Columns.Insert(0, dgvImg_upd);

            dgvImg_del = new DataGridViewImageColumn();
            dgvImg_del.Name = "col_Eliminar";
            dgvImg_del.HeaderText = string.Empty;
            dgvImg_del.DataPropertyName = "col_Eliminar";
            dgvImg_del.Width = 35;
            dgvImg_del.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dgvImg_del.Image = Image.FromFile(@"C:\Users\INFORMATICA1\Documents\Sebastian Sanchez\TFS\SistemaDePreguntas\SistemaDePreguntas\SistemaDePreguntas\Imagenes\delete.png");
            dgvImg_del.Image = Image.FromFile(Environment.CurrentDirectory + "\\Imagenes\\delete.png");
            dgvOpciones.Columns.Insert(1, dgvImg_del);

            dgvOpciones.Columns[2].Name = "ID";
            dgvOpciones.Columns[2].HeaderText = "ID";
            dgvOpciones.Columns[2].DataPropertyName = "ID";
            dgvOpciones.Columns[2].Width = 35;
            dgvOpciones.Columns[2].ReadOnly = true;

            dgvOpciones.Columns[3].Name = "ENUNCIADO";
            dgvOpciones.Columns[3].HeaderText = "ENUNCIADO";
            dgvOpciones.Columns[3].DataPropertyName = "ENUNCIADO";
            dgvOpciones.Columns[3].Width = 150;
            dgvOpciones.Columns[3].ReadOnly = true;

            dgvOpciones.Columns[4].Name = "ES_CORRECTA";
            dgvOpciones.Columns[4].HeaderText = "ES_CORRECTA";
            dgvOpciones.Columns[4].DataPropertyName = "ES_CORRECTA";
            dgvOpciones.Columns[4].Width = 150;

            #endregion ------------------------------------------------------------

            #region Ajustes Combobox------------------------------------------------------------
            tb_Op1.TextChanged += tb_Op1_TextChanged;
            tb_Op2.TextChanged += tb_Op1_TextChanged;
            tb_Op3.TextChanged += tb_Op1_TextChanged;
            tb_Op4.TextChanged += tb_Op1_TextChanged;
            cb_Tema.DataSource = NTema.Mostrar();
            cb_Tema.DisplayMember = "Enunciado";
            cb_Tema.ValueMember = "ID";
            cb_Tema_CSV.DataSource = NTema.Mostrar();
            cb_Tema_CSV.DisplayMember = "Enunciado";
            cb_Tema_CSV.ValueMember = "ID";
            #endregion ------------------------------------------------------------
        }

        void tb_Op1_TextChanged(object sender, EventArgs e)
        {
            //Cada vez que se cambian los textbox se actualiza combobox
            cb_Rta.DataSource = new[] { tb_Op1.Text, tb_Op2.Text, tb_Op3.Text, tb_Op4.Text };
        }
        //
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer click se valida si se presionan los botones insertar o actualizar
            //Se pregunta por una validación en messagebox    
            //Finalmente se envian instrucciones a BD       
            if ((dgvPreguntas.Columns[e.ColumnIndex].DataPropertyName == "col_Actualizar") && (flagEditando == true))
            {
                //Instruccion Udpate
                DialogResult rta;
                rta = MessageBox.Show("¿Realmente desea cambiar la pregunta con ID " + dgvPreguntas.Rows[e.RowIndex].Cells["ID"].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    short ID = (short)dgvPreguntas.Rows[e.RowIndex].Cells["ID"].Value;
                    string Tema = (string)dgvPreguntas.Rows[e.RowIndex].Cells["ENUNCIADO"].Value;
                    string Enunciado = (string)dgvPreguntas.Rows[e.RowIndex].Cells["ENUNCIADO"].Value;

                    //NPregunta.Editar(ID, ID_Pregunta, Respuesta, Enunciado);
                    //dgvPreguntas.DataSource = NPregunta.MostrarSelMul();
                    flagEditando = false;
                }
            }
            else if (dgvPreguntas.Columns[e.ColumnIndex].DataPropertyName == "col_Eliminar")
            {
                //Instrucción delete
                DialogResult rta;
                rta = MessageBox.Show("¿Realmente desea eliminar la pregunta con ID" + dgvPreguntas.Rows[e.RowIndex].Cells["ID"].Value.ToString() + " ?", "Atención", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    NPregunta.EliminarSelMulPorID((short)dgvPreguntas.Rows[e.RowIndex].Cells["ID"].Value);
                    dgvPreguntas.DataSource = NPregunta.MostrarSelMul();
                }
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Pinta toda la fila si una celda se ha editado.
            if (e.RowIndex >= 0)
            {
                flagEditando = true;
                foreach (DataGridViewCell i_DCell in dgvPreguntas.Rows[e.RowIndex].Cells)
                {
                    i_DCell.Style.BackColor = Color.Red;
                }
            }
        }

        private void FPreguntasCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Pide confirmación para salir cuando está editando una fila
            if (flagEditando == true)
            {
                DialogResult rta;
                rta = MessageBox.Show("Existen valores editados que no se han almacenado. ¿Salir de todos modos?", "Atención", MessageBoxButtons.YesNo);
                if (rta == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btn_InsertPregunta_Click(object sender, EventArgs e)
        {
            lbl_AvisoValidacion.Visible = false;
            if (tb_Enunciado.Text == "" || tb_Op1.Text == "" || tb_Op2.Text == "" || tb_Op3.Text == "" || tb_Op4.Text == "")
            {
                lbl_AvisoValidacion.Visible = true;
                return;
            }
            else
            {
                //int ID_Pregunta = int.Parse(cb_IDTipoPregunta.Text);
                string Respuesta = cb_Rta.Text;
                string Opcion1 = tb_Op1.Text;
                string Opcion2 = tb_Op2.Text;
                string Opcion3 = tb_Op3.Text;
                string Opcion4 = tb_Op4.Text;
                string Opcion5 = "";
                //string Enunciado = tb_Enunciado.Text;
                //NPregunta.Insertar(ID_Pregunta, Respuesta, Opcion1, Opcion2, Opcion3, Opcion4, Opcion5, Enunciado);
                dgvPreguntas.DataSource = NPregunta.MostrarSelMul();
            }
        }

        private void dgvPreguntas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Despliega las opciones de respuesta en el dgvOpciones
            dgvOpciones.DataSource = null;
            dgvOpciones.DataSource = NOpcionesRespuesta.MostrarporId((short)dgvPreguntas.Rows[e.RowIndex].Cells["ID"].Value);
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

            LPreguntas = Utilidades.LeerArchivo(FileName, int.Parse(this.cb_Tema.SelectedValue.ToString()),TipoPreg.SelMul);

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
            NPregunta.EliminarSelMul();
        }
    }
}