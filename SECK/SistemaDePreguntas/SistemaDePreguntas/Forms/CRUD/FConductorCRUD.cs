using CapaNegocio;
using Fotografia;
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
    public partial class FConductorCRUD : Form
    {
        FotoHandler fotoObj;
        Timer TCamara;
        bool GuardarYCerrar = false;

        public FConductorCRUD()
        {
            InitializeComponent();
            LlenarCombos();
            if (File.Exists(Properties.Settings.Default.RutaLogo))
                pb_logo.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
            InicioCamara();
        }

        /// <summary>
        /// Asigna valores a los textbox del formulario
        /// </summary>
        /// <param name="CCObj"></param>
        //public void AsignarCampos(NConductor CCObj)
        //{
        //    this.tb_Cedula.Text = CCObj.VoConductor_obj.Cedula;
        //    this.tb_Nombre.Text = CCObj.VoConductor_obj.Nombre;
        //    this.tb_Apellido.Text = CCObj.VoConductor_obj.Apellido;
        //    this.cb_Genero.SelectedIndex = (CCObj.VoConductor_obj.Genero == (short)Enums.Genero.M) ? cb_Genero.FindStringExact("Masculino") : cb_Genero.FindStringExact("Femenino"); // 
        //    this.dtp_FNacimiento.Value = (CCObj.VoConductor_obj.FechaNacimiento.HasValue == true) ? CCObj.VoConductor_obj.FechaNacimiento.GetValueOrDefault() : DateTime.Now; //
        //    this.tb_Empresa.Text = Properties.Settings.Default.Empresa;
        //    GuardarYCerrar = true;
        //}

        /// <summary>
        /// Asigna valores a los textbox del formulario
        /// </summary>
        /// <param name="CCObj"></param>
        public void AsignarCampos(CapaNegocio.Logica.NModeloConductor CCObj)
        {
            this.tb_Cedula.Text = CCObj.VoConductor_obj.Cedula;
            this.tb_Nombre.Text = CCObj.VoConductor_obj.Nombre;
            this.tb_Apellido.Text = CCObj.VoConductor_obj.Apellido;
            this.cb_Genero.SelectedIndex = (CCObj.VoConductor_obj.Genero == (short)Enums.Genero.M) ? cb_Genero.FindStringExact("Masculino") : cb_Genero.FindStringExact("Femenino"); // 
            this.dtp_FNacimiento.Value = (CCObj.VoConductor_obj.FechaNacimiento.HasValue == true) ? CCObj.VoConductor_obj.FechaNacimiento.GetValueOrDefault() : DateTime.Now; //
            this.tb_Empresa.Text = Properties.Settings.Default.Empresa;
            GuardarYCerrar = true;
        }

        void LlenarCombos()
        {
            cb_Genero.DataSource = NGenero.Mostrar();
            cb_Genero.DisplayMember = "Enunciado";
            cb_Genero.ValueMember = "ID";

            cb_TipoLicencia.DataSource = NTipoLicencia.Mostrar();
            cb_TipoLicencia.DisplayMember = "TIPO_LICENCIA";
            cb_TipoLicencia.ValueMember = "ID";
        }

        private void InicioCamara()
        {
            if (fotoObj == null)
            {
                fotoObj = new FotoHandler();
                TCamara = new Timer();
                TCamara.Interval = 200;
                TCamara.Tick += (a, b) => { pb_Streaming.Image = fotoObj.ImagenBitMap;};
                TCamara.Start();
                btn_Captura.Visible = true;
            }
        }

        private void btn_Captura_Click(object sender, EventArgs e)
        {
            if (fotoObj == null || fotoObj.Error == true)
            {
                MessageBox.Show("Existe un error con la cámara", "Atención");
                fotoObj = null;
                TCamara = null;
                return;
            }
            if (pb_Streaming.Image == null)
                return;
            this.pb_Captura.Image = pb_Streaming.Image;
            this.pb_Captura2.Image = pb_Streaming.Image;
        }

        private void FConductorCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TCamara != null)
                TCamara.Stop();
            if (fotoObj != null)
                fotoObj.Apagar();
        }

        private void btn_InsertarCond_Click(object sender, EventArgs e)
        {
            lbl_AvisoValidacion.Visible = false;
            byte[] Aux_Imagen;
            if (this.tb_Cedula.Text == "" || this.tb_Nombre.Text == "" || this.tb_Apellido.Text == "" || this.pb_Captura.Image == null)
            {
                lbl_AvisoValidacion.Visible = true;
                return;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pb_Captura.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Aux_Imagen = ms.ToArray();
                }

                CapaNegocio.NConductor.Insertar(this.tb_Cedula.Text, this.tb_Nombre.Text, this.tb_Apellido.Text, int.Parse(this.cb_TipoLicencia.SelectedValue.ToString()), this.tb_CodLicencia.Text, this.tb_Empresa.Text, int.Parse(this.cb_Genero.SelectedValue.ToString()), Aux_Imagen, Aux_Imagen, dtp_FNacimiento.Value);
                MessageBox.Show("El conductor está ya registrado en el sistema", "Usuario registrado");
                if (GuardarYCerrar == true)
                this.Close();
            }
        }

    }
}
