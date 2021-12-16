#define TEST
using CapaPresentacion.Forms.CRUD;
using CapaNegocio;
using CapaNegocio.Logica;
using Fotografia;
using Impresora;
using Microsoft.Speech.Synthesis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Forms.Principal
{
    public partial class FPreguntas : Form
    {
        Cedula ccEvaluado;
        NModeloConfiguracionPrueba Configuracion_obj;
        //int NumPreguntasConfiguradas;

        TimeSpan TSpanTime;
        Timer timer = new Timer();

        FPrincipal F;
        SpeechSynthesizer _synthesizer;

        public FPreguntas()
        {
            InitializeComponent();
            ccEvaluado = new Cedula();
            Configuracion_obj = new NModeloConfiguracionPrueba(Properties.Settings.Default.NumPreguntas);
            //Configuracion_obj.numeroPreguntas = Properties.Settings.Default.NumPreguntas;
            Configuracion_obj.setLicenciaPorDefectoDeseInt(Properties.Settings.Default.LicenciaPorDefecto);
        }

        private void FPreguntas_Load(object sender, EventArgs e)
        {
            //NumPreguntasConfiguradas = Properties.Settings.Default.NumPreguntas;
            //Configuracion inicial de controles
            if (File.Exists(Properties.Settings.Default.RutaLogo))
            {
                pb_logoPresentacion.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
                pb_logoUsuario.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
                pb_logoBionetria.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
                //pb_logoCuestionario.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
                pb_logoResultado.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);
            }

            this.tabc_Contenedor.TabPages.Remove(tp_Usuario);
            this.tabc_Contenedor.TabPages.Remove(tp_Cuestionario);
            this.tabc_Contenedor.TabPages.Remove(tp_Resultado);
            this.tabc_Contenedor.TabPages.Remove(tp_Biometria);
            lbl_Tiempo.Text = string.Format("00:{0:00}:{1:00}", Properties.Settings.Default.MinEval, Properties.Settings.Default.SegEval);

            this.lbl_Presentacion.Text =
            string.Format("Usted está a punto de iniciar la prueba de conocimientos sobre \n"
            + "conducción y seguridad víal. \n"
            + "Elija la respuesta correcta o llene el espacio según la pregunta. \n"
            + "La prueba tiene {0} preguntas para las cuales tiene un tiempo \n"
            + "máximo para responder de {1} minutos más {2} segundos \n\n"

            + "PATROCINADO POR:\n{3}\n\n"
            + "EMPRESA:\n{4}\n\n"
            + "CAMPAÑA:\n{5}\n",
            Configuracion_obj.numeroPreguntas.ToString(),
            Properties.Settings.Default.MinEval.ToString(),
            Properties.Settings.Default.SegEval,
            Properties.Settings.Default.Patrocinador,
            Properties.Settings.Default.Empresa,
            Properties.Settings.Default.NombreCampaña);

            //Oculta barra de menú
            F = new FPrincipal();
            F = (FPrincipal)this.MdiParent;
            F.VisibilidadMenuStrip(false);

            _synthesizer = new SpeechSynthesizer();
            _synthesizer.SetOutputToDefaultAudioDevice();
            _synthesizer.SelectVoice("Microsoft Server Speech Text to Speech Voice (es-ES, Helena)");
            _synthesizer.Volume = 80;
            _synthesizer.Rate = 0;
        }

        #region Tab Presentación
        private void btn_SigPresentacion_Click(object sender, EventArgs e)
        {
            this.tabc_Contenedor.TabPages.Remove(tp_Presentacion);
            this.tabc_Contenedor.TabPages.Add(tp_Usuario);
            this.tb_CCConductor.Focus();
#if TEST
            this.tb_CCConductor.Text = "1093214430";
#endif
        }
        #endregion

        #region Tab Usuario

        private void tb_CCConductor_Leave(object sender, EventArgs e)
        {
            //El foco siempre es el tb_CCConductor para el tab usuario
            this.tb_CCConductor.Focus();
        }

        List<char> buffer_char_list = new List<char>();

        private void txt_CCConductor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Aquí se lee desde la pistola y se construye la clase cédula con los resultados
            if (e.KeyChar == 45) //

                lbl_leyendo.Visible = true;

            if (lbl_leyendo.Visible == true)
            {
                buffer_char_list.Add(e.KeyChar);
                //tb_CCConductor.Text = "";
            }


            if (e.KeyChar == 13)
            {
                string resultado = new string(buffer_char_list.ToArray());
                ccEvaluado = new Cedula();
                string msg = ccEvaluado.AsignaCamposDesdeStream(resultado);
                if (msg != null)
                {
                    MessageBox.Show(msg);
                    tb_CCConductor.Text = "";
                    LblNombres.Text = string.Empty;
                    LblApellidos.Text = string.Empty;
                    Lbl_IDReportes.Text = string.Empty;
                }
                else
                {
                    tb_CCConductor.Text = ccEvaluado.NumeroCedula.ToString();
                    BtnBuscarUsuario_Click(null, null);
                }
                buffer_char_list.Clear();
                lbl_leyendo.Visible = false;
            }
        }

        //string Str_Cedula;
        private void BtnBuscarUsuario_Click(object sender, EventArgs e)
        {
            LblNombres.Text = string.Empty;
            LblApellidos.Text = string.Empty;
            Lbl_IDReportes.Text = string.Empty;
            btn_Sig_Usuario.Visible = false;

            int auxCC;
            if (!int.TryParse(tb_CCConductor.Text, out auxCC))
            {
                MessageBox.Show("El formato de cédula no es válido", "Error");
                return;
            }

            int AuxUsuarioExiste = NConductor.ConductorExiste(auxCC.ToString());
            if (AuxUsuarioExiste == 1)
            {
                BuscarUsuario(auxCC);
                ConstruyeIDReporte(auxCC);
                tb_CCConductor.Text = string.Empty;
                btn_Sig_Usuario.Visible = true;
                btn_SigUsuario_Click(null, null);
            }
            else
            {
                MessageBox.Show("Por favor regístrese para continuar.  Diligencie el formulario de registro y retome la prueba.", "No existe regitro para la cédula suministrada");

                F.Mostrar_FConductorCRUDObj(); //Muestra el formulario FConductorCRUD, el cual es un campo del Form FPrincipal
                F.FConductorCRUDObj.AsignarCampos(ccEvaluado);
            }
        }

        private void BuscarUsuario(int Str_Cedula)
        {
            string[] nuevo = NConductor.MostrarDatos_str(Str_Cedula.ToString());
            LblNombres.Text = nuevo[1].ToString();
            LblApellidos.Text = nuevo[2].ToString();
            //Reconstruye clase cedula con los datos desde la base de datos
            ccEvaluado.Limpiar();
            ccEvaluado.NumeroCedula = int.Parse(nuevo[0]);
            ccEvaluado.Nombres = nuevo[1].ToString();
            ccEvaluado.Apellidos = nuevo[2].ToString();
        }

        /// <summary>
        /// Construye el ID del nuevo reporte como "Consecutivo + Cédula + DígitoVerificación"
        /// </summary>
        private void ConstruyeIDReporte(int Str_Cedula)
        {
            int ConsecutivoReportes = NEvaluacion.BuscarEvaluaciones(Str_Cedula.ToString());
            if (ConsecutivoReportes >= 0)
            {
                ConsecutivoReportes++;
                string NumeroReporte = string.Format("{0}{1}", ConsecutivoReportes.ToString(), tb_CCConductor.Text);
                long dVer = Utilidades.Digito_Verificación(long.Parse(NumeroReporte));
                Lbl_IDReportes.Text = string.Format("{0}-{1}", NumeroReporte, dVer);
            }
        }

        FotoHandler fotoObj;
        Timer TCamara;
        private void btn_SigUsuario_Click(object sender, EventArgs e)
        {
#if TEST
            this.tabc_Contenedor.TabPages.Remove(tp_Usuario);
            this.tabc_Contenedor.TabPages.Add(tp_Cuestionario);
#else
            this.tabc_Contenedor.TabPages.Remove(tp_Usuario);
            this.tabc_Contenedor.TabPages.Add(tp_Biometria);
            btn_Sig_Usuario.Visible = false;

            if (fotoObj == null)
            {
                fotoObj = new FotoHandler();
                TCamara = new Timer();
                TCamara.Interval = 200;
                TCamara.Tick += (a, b) => { pb_Streaming.Image = fotoObj.ImagenBitMap; };
                TCamara.Start();
                btn_Capturar.Visible = true;
            }
#endif
        }
        #endregion

        #region Tab Biometría

        private void btn_Capturar_Click(object sender, EventArgs e)
        {
            if (fotoObj == null || fotoObj.Error == true)
            {
                btn_Capturar.Visible = false;
                MessageBox.Show("Existe un error con la cámara", "Atención");
                fotoObj = null;
                TCamara = null;
                return;
            }
            if (pb_Streaming.Image == null)
                return;
            this.pb_Captura.Image = pb_Streaming.Image;
            this.btn_Sig_Biometria.Visible = true;
        }

        private void btn_Sig_Biometria_Click(object sender, EventArgs e)
        {
            TCamara.Stop();
            fotoObj.Apagar();
            this.tabc_Contenedor.TabPages.Remove(tp_Biometria);
            this.tabc_Contenedor.TabPages.Add(tp_Cuestionario);
        }
        #endregion

        #region Tab Preguntas
        bool flag_Empezar = false;
        public int iPregunta = 0;
        //ArrayList ALPreguntas_Seleccionadas = new ArrayList();
        NModeloCuestionario Cuestionario_obj;
        NModeloCalificador Calificador_obj;

        private void Btn_EmpezarEncuesta_Click(object sender, EventArgs e)
        {
            if (flag_Empezar == false)
            {
                //Antes de empezar el cuestionario pinta la pregunta y construye la prueba
                if (ArmarCuestionarioAleatorio() == -1)
                {
                    MessageBox.Show("La base de datos no tiene preguntas suficientes", "Atención");
                    return;
                }
                IniciaCuentaAtras();
                PintarPregunta(iPregunta);
                this.Btn_EmpezarEncuesta.Text = "Siguiente";
                this.lbl_ProgresoTest.Visible = true;
                flag_Empezar = true;
            }
            else
            {
                if (ValidaRta() == false)
                {
                    MessageBox.Show("Escoja una respuesta o ingrese una respuesta válida", "Atención");
                    return;
                }

                CapturarResultado();

                if (iPregunta + 1 == Configuracion_obj.numeroPreguntas)
                {
                    FinPrueba();
                }
                else
                {
                    iPregunta++;
                    PintarPregunta(iPregunta);
                }
            }
        }

        /// <summary>
        /// Construye un cuestionario aleatorio en Cuestionario_obj
        /// </summary>
        private int ArmarCuestionarioAleatorio()
        {
            try
            {
                Cuestionario_obj = new NModeloCuestionario(Configuracion_obj);
                Calificador_obj = new NModeloCalificador();
                //Al tiempo de crear el cuestionario, crea el calificador con la misma lista
                Calificador_obj.alimentarDesdeListaVoPregunta(Cuestionario_obj.L_TodasLasPreguntasAleatorias);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Inicia el timer que controla el tiempo de la prueba
        /// </summary>
        private void IniciaCuentaAtras()
        {
            TSpanTime = new TimeSpan(0, Properties.Settings.Default.MinEval, Properties.Settings.Default.SegEval); //Toma el tiempo de la configuracion (min,seg)
            timer.Interval = 1000;
            timer.Tick += (a, b) =>
            {
                TSpanTime = TSpanTime.Subtract(new TimeSpan(0, 0, 1));
                lbl_Tiempo.Text = TSpanTime.ToString();
                if (TSpanTime < new TimeSpan(0, 2, 0))
                    lbl_Tiempo.ForeColor = Color.Brown;
                if (TSpanTime == TimeSpan.Parse("00:00:00"))
                {
                    timer.Stop();
                    FinPrueba();
                    return;
                }
            };
            timer.Start();
        }

        /// <summary>
        /// Dibuja las preguntas deacuerdo a su posicion en lista
        /// </summary>
        /// <param name="indice">La posicion de la pregunta </param>
        void PintarPregunta(int indice)
        {
            LimpiarTLP();
            short auxID = Cuestionario_obj.IdPreguntaDesdeIndice(indice);                           //ID de la pregunta
            string auxTipoPregunta = Cuestionario_obj.EnunciadoTipoPreguntaDesdeIndice(indice);     //Recupera el enunciado del tipo de pregunta                      
            string auxEnunciado = Cuestionario_obj.EnunciadoPreguntaDesdeIndice(indice);            //Recupera el enunciado de pregunta

            //Título de la pregunta
            tlp.Controls.Add(CrearLabel(auxEnunciado), 0, 0);

            //Botón audio del título
            tlp.Controls.Add(CrearBotonAudio(auxEnunciado), 1, 0);

            //Dependiendo del tipo de pregunta asigna las opciones y contruye los controles
            switch (auxTipoPregunta)
            {
                case "Seleccion múltiple con imagen":

                    DataTable auxdt2 = NOpcionesRespuesta.MostrarporId(auxID);
                    foreach (DataRow dr in auxdt2.Rows)
                    {
                        //Construye un radiobutton por cada opcion de respuesta que tiene la pregunta
                        string Aux_enunciado = dr["Enunciado"].ToString();
                        tlp.Controls.Add(CrearRadioButton(Aux_enunciado));

                        //Botón audio de la opción
                        tlp.Controls.Add(CrearBotonAudio(Aux_enunciado));
                    }

                    Byte[] data = new Byte[0];                  //
                    data = Cuestionario_obj.ImagenPreguntaDesdeIndice(indice);  // Carga imagen desde BD al PictureBox
                    MemoryStream mem = new MemoryStream(data);  //
                    pb_Imagen.Image = Image.FromStream(mem);    //
                    pb_Imagen.Visible = true;                   //
                    break;

                case "Selección múltiple":

                    DataTable auxdt = NOpcionesRespuesta.MostrarporId(auxID);
                    foreach (DataRow dr in auxdt.Rows)
                    {
                        //Construye un radiobutton por cada opcion de respuesta que tiene la pregunta
                        string Aux_enunciado = dr["Enunciado"].ToString();
                        tlp.Controls.Add(CrearRadioButton(Aux_enunciado));

                        //Botón audio de la opción
                        tlp.Controls.Add(CrearBotonAudio(Aux_enunciado));
                    }
                    pb_Imagen.Visible = false;
                    break;

                case "Pregunta abierta numérica":

                    pb_Imagen.Visible = false;
                    TextBox tb = new TextBox();
                    tb.Text = "Ingrese su respuesta";
                    tb.Font = new Font(emSize: 13, familyName: "Microsoft Sans Serif");
                    tb.ForeColor = Color.MidnightBlue;
                    tb.Name = "tb_Rpta_Pregunta_Numérica";
                    tb.Dock = DockStyle.Fill;
                    tb.GotFocus += (sender, eventargs) => tb.Text = string.Empty;
                    tlp.Controls.Add(tb);
                    break;

                case "Verdadero falso":

                    tlp.Controls.Add(CrearRadioButton("Verdadero"));
                    tlp.Controls.Add(CrearBotonAudio("Verdadero"));

                    tlp.Controls.Add(CrearRadioButton("Falso"));
                    tlp.Controls.Add(CrearBotonAudio("Falso"));

                    break;
            }
            lbl_ProgresoTest.Text = string.Format("{0:00}/{1:00}", indice + 1, Configuracion_obj.numeroPreguntas);
        }

        /// <summary>
        /// Alimenta Calificador_obj con respuestas de usuario
        /// </summary>
        void CapturarResultado()
        {
            foreach (Control ctrl in tlp.Controls)
            {
                if (ctrl is RadioButton)
                {
                    //Captura texto del radio seleccionado
                    RadioButton auxRB = (RadioButton)ctrl;
                    if (auxRB.Checked == true)
                        Calificador_obj.agregarRespuesta((short)iPregunta, auxRB.Text);
                }
                if (ctrl is TextBox)
                {
                    //Captura texto del textbox
                    TextBox auxtb = (TextBox)ctrl;
                    Calificador_obj.agregarRespuesta((short)iPregunta, auxtb.Text);
                }
            }
        }

        /// <summary>
        /// Limpia todos los controles del TableLayoutPanel
        /// </summary>
        private void LimpiarTLP()
        {
            while (tlp.Controls.Count > 0)
            {
                tlp.Controls[0].Dispose();
            }
        }

        /// <summary>
        /// Crea un radiobutton con animacion si esta seleccionado
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        private RadioButton CrearRadioButton(string Texto)
        {
            RadioButton rb = new RadioButton();
            rb.Text = Texto;
            rb.AutoSize = false;
            rb.AutoEllipsis = true;
            rb.Font = new Font(emSize: 13, familyName: "Microsoft Sans Serif");
            rb.ForeColor = Color.MidnightBlue;
            rb.Dock = DockStyle.Fill;
            rb.CheckedChanged += (obj, e) =>
            {
                rb.BackColor = rb.Checked ? Color.LightBlue : Color.White; ;
            };
            return rb;
        }

        /// <summary>
        /// Crea un boton que al clickearse dicta el texto en audio
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        private Button CrearBotonAudio(string Texto)
        {
            Button btnAudio = new Button();
            btnAudio.BackgroundImage = Properties.Resources.audio_azul;
            btnAudio.BackgroundImageLayout = ImageLayout.Zoom;
            btnAudio.Size = new Size(50, 50);
            btnAudio.Dock = DockStyle.None;
            btnAudio.Anchor = AnchorStyles.None;
            btnAudio.Click += (a, b) =>
            {
                _synthesizer.SpeakAsync(Texto);
            };
            return btnAudio;
        }

        /// <summary>
        /// Crea un label básico
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        private Label CrearLabel(string Texto)
        {
            Label lbl = new Label();
            lbl.Text = Texto;
            lbl.ForeColor = Color.Brown;
            lbl.Font = new Font(emSize: 13, family: new FontFamily("Microsoft Sans Serif"), style: FontStyle.Bold);
            lbl.Dock = DockStyle.Fill;
            lbl.AutoEllipsis = true;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            return lbl;
        }

        /// <summary>
        /// Valida que se dio respuesta a la pregunta
        /// </summary>
        /// <returns>Retorna trye si hay seleccion</returns>
        bool ValidaRta()
        {
            bool EsRptaAceptale = false;
            foreach (Control ctrl in tlp.Controls)
            {
                if (ctrl is RadioButton)
                {
                    //Valida que hay algún check
                    RadioButton auxRB = (RadioButton)ctrl;

                    if (auxRB.Checked == true)
                        EsRptaAceptale = true;
                }
                if (ctrl is TextBox)
                {
                    //Valida que respuesta es numérica
                    TextBox auxtb = (TextBox)ctrl;
                    double resultado;
                    if (double.TryParse(auxtb.Text, out resultado) == true)
                        EsRptaAceptale = true;
                }
            }
            return EsRptaAceptale;
        }

        private void FinPrueba()
        {
            timer.Stop();

            Btn_EmpezarEncuesta.Enabled = false;
            Btn_EmpezarEncuesta.Text = "Finalizado";
            btn_Sig_Cuestionario.Visible = true;

            lbl_cantidadPreg.Text = Calificador_obj.numTotalPreguntas.ToString();
            lbl_PreguntasRespondidas.Text = Calificador_obj.numContestadas.ToString();
            lbl_RespuestasCorrectas.Text = Calificador_obj.numCorrectas.ToString();
            lbl_RespuestasIncorrectas.Text = Calificador_obj.numIncorrectas.ToString();
            lbl_Calificacion.Text = string.Format("{0:00}/10 ", Calificador_obj.PuntajeGlobal.ToString());
            lbl_campana.Text = Properties.Settings.Default.NombreCampaña;
            lbl_nombres.Text = ccEvaluado.Nombres;
            lbl_apellidos.Text = ccEvaluado.Apellidos;
            lbl_codEval.Text = Lbl_IDReportes.Text;

            byte[] Aux_Imagen;
            using (MemoryStream ms = new MemoryStream())
            {
#if TEST
                //Aux_Imagen = 0xFFD8FFE000104A46494600010101006000600000FFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC00011080384064003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FC9D07F0A43D3F952F53D41FC68EBED5F7079E28F98F6A3184EFFF00D7ADBF86BF0EB58F8BFF0011B40F097876CFFB47C43E28D4ADF48D2ED3CE487ED375712AC50C7BE46545DCEEA37330519C9200CD7DB96FFF0006E07ED19A6789BC0BA578897C0FE15B9F1F6B52E8560B7BAD1B8F2678F4FBDD418CBF668E5014C1613005493BD9010012CB94EB421F1BB14937B1F0471FE7B521E95FAB3F16BFE0D66F15FC08FD9A7C7FF103C4DF17BC3DE77817C35A8F88469DA668735D2DF1B4B692710F9D24B1140FB0AEFD8DB720ED3D2BF29BF51D6952AF4EADDD3770716B7171B4735F4FFF00C1197E3CE95FB31FFC14B7E1A78DB5BB3D5350D374993518A4B7D39237B995A7D32EED902091D13EFCC99CB8C0CFD2BE5E2F919EDE86BD4FF626D2EEB5CFDABFC0D63656D3DDDEDDEA890416F0466496791832AA2A8C966248000E4935E9E5B85A589C5D2C357F82728C5F4D1B49EBE87919EE2EB6132DC462B0FF001C213947AEAA2DAD3AEA7F484DFF0005B3F8788A49F02FC51000C926DB4BE3FF0027EBA7FD9F7FE0AC7E03FDA37E32685E08D27C2FE3ED3352F10BCF1DB5C6A56B64B6AAD15BCB70C1CC575238CA42E0610F38E9D6BF26B50F8ADE1ABBBBFB28F11686A01FDE66FE21CFA7DEAFA73FE09B3E1AF3FF006BEF85BAD5A2FDA74D96EAF1E3BB886F81D64D3356891838F94867B5B95073CB5BCC0731B63F52E23F0CF867019557C55294BDA461271F7D6E936B4B6BE87F3AF0BF8B3C5998E7386C1D58C7D94A708C9FB36B47249EB7D34EA7EABF883C590F87356D0ECE582E657D7AF9AC2168954AC2EB6D3DC16932410BB6065E013B9978C648D5AE4BE23FFC8E3E01FF00B0F4BFFA6BBFAEB6BF9A0FEAF380D3BE2478AFC449773E99E1DF0EC96505FDDD8C6F75AFCD0CB27D9EE24B72C516CDC2E5A3240DC78239ACFF00833FB4A5AFC50F1CEAFE17BCB6B0D3BC45A419DA4B5B4D485F298E19FC87663B2378CEF2A40741B9645209F982F143E3C4FF000874568E5F0B6BBAD5AEA7ADEB90D94FA647E7996FBFB5EF025ABAFF00CB3DE3912B1D830DB8AE0674FE15D8F89ED3E39F86EE3C5BA84173ABEA7A06B974D676C8BF65D297ED3A385B689B01A40A3ABB1CB316202821471C71D4E75DE1E09B6B7D345DAEDDB7E96BFDC7A13CB6AD3C2AC5D469465F0EB772EF64AFB75BDBB6E7B2789358FF00847BC3B7F7FE5F9BF61B692E366EDBBF6296C670719C7A571B27C5ED4D3FE60B61FF008337FF00E315D1FC4D3B7E1B7887FEC1973FFA29ABCCEE2E2BF38E3DE21CC32FC5429E12AB8271BED17ADDFF003459E8E4F82A35E9B9558DDDFBBFD1A3D27E1F78D24F1AE9F7924B689672D9DC9B664498CCADFBB47C862ABD9C76ED5BF5E6FF00B3D6BD1EA3FF000915B2AC8AF1DF09F2C06194A0878FF81DBC9FA7AD793FFC1577E2F6ADFB347ECE32FC50B6F107C7FD2BC3FE0BF366F105BFC29D1FC35AA5FF00D8DD416BEB98B5AB69BFD1EDBCB3B9AD886459DE4915A38DA487EC784B31A98FCA68E2EACB9A524EEF457B49AE892E9D11E66654151C4CA945592FF23EA0ACAB4F164379E35D4343582E56E34EB1B5BF799957C9912792E11554E776E536CE5B200C3A609C903CD3F616BDF117887F670D1B5FF13EA5F17EEF50F13E7558ECFE26E9BA1E9DE23D1E075558EDA7B7D22086DA2F953CDD8E1A7433B2CA5597CA8FB3D1BFE4BB788FFEC03A57FE946A55F4470999F1CBF6B0F85BFB308D37FE1657C4AF007C3CFED9F33FB3FF00E126F10DA693F6EF2F6F99E57DA244DFB77A6EDB9C6F5CF515DCE97AA5B6B7A65BDED95C4177677712CF04F048248A78D80657561C329041047041AF92BF6C5F8F9E02FD9D7FE0A39F0435BF889E33F09781F42B8F03F8BECD2FBC43AB5BE9B6B34CD73A132C2B24CCAACECAAC42039214F1C57CAFE3FF008DFF0013BF648F827F0C3C2DE0DF12786BE00FC3BF196B1E32D6B48D5FC63A9DAF83AD34AB53A9F9FA3E96D35FE91A9C16C25B5B89A75B496DE09CA42116484C2F13007EAAF8A3C53A6781FC377FACEB5A8D8E91A3E956F25DDEDF5EDC25BDB59C31A96796491C8544550496620000926AE5BDC25DDBA4B13A49148A1D1D0E55D4F2083DC57E5CFED49FB59EB9E31F097ED15E0DF117C58D1BC6D79A87C1FD6F54B1F0E78075AD0B54F0FE890A6876ED2497F1FD9D358B69A49A691E095A692D658A68F3E5B958EA8F8FBE2C6B3F132F3E01F893E207C6DD63E15EB3E18F8A9159F88BC2C8340B7B3F876B2E89AA4562AF3DDD9CB249F6A44409732CAD15C1BE90C2887CA58803F55E8AFCFF00F847FB63F8DFC59FB51DAE98FF00167FB47C673F8EF5ED0BC41F07CE99A681E14F0FDAFDB459EAC55205D4A1DE90584A2E6E6E1EDA7FB7ED8E31E642169FFC12AFF6D5F197ED19E31F8622FBE34DBFC5CBDF147C3F975AF1EE876FA56996B1F80AFD0D90B3C8B58927B792E44B7198AE9A4F38C4F2C2B0C6A50007E86514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005159FE2CD1AE3C47E15D4B4FB3D5B50D06EEFED25B78353B0481EEB4E7742AB3C4B3C72C264424328963910951B91972A7C3FFE18DBE22FFD1D8FC7FF00FC147823FF0099EA00FA028ACFF09E8D71E1CF0AE9BA7DE6ADA86BD77616915BCFA9DFA40975A8BA20569E558238A112390598451C680B1DA8AB851A140051451401E1FF00B75FFC1427E1AFFC13CFE19DAF887C7FAD69F0DDEAD77059E8FA10D634DB0D4F5C792EEDAD5CDB0BFB9B684C701BB8A49E47955218B748ECAA2BCC3F66CFF82CCF80BF6A0F8BBE19F09683E14F107FC551AAB6891EAD69E2DF077882C34FBCFECDD43528E2BA1A46B77B3C3E6DBE977BE5B345B59A22323AD6FF00ED51F1122F81DFB7D7C20F1AEAFE1FF881AA7866DFE1FF008CB44B8BCF0C782B58F13FD92F2E751F0B4D6F14D1E9B6D71245E6476774CACEAAA7C8719CF15E41E1DD07C49FB61FFC15EB44F899E12F0DF88349F865E01D2BC3B77AB6ABE32F0D6BBE14BFBCBC86C7C7D622D34FB4D434E8BED7B7FE120B696697CC8D625080095A421003EFFA28A2800A28A280380D13F68ED0753FDA0B58F8657906A7A278A74FB34D534F8F51892387C4962563F36EAC1D5D84C904B2086643B6589F6168C4734124A7C1DFDA3B41F8F1E2DF17D878660D4EFF004BF075E2E973EBE2241A4EA17CA645B9B5B4977EE99ED591526709E52C927942469629D22F08FDB8FE00EBDFF0512F189F857670F897E1D785BC177316A7A87C48B48DEC75B86F9EDF315AF87A661904C5315BABC1BA211492DA2892492736BE97FB13EA3AF784BC0927C32F137822CFC21AA7C32B7B5D3209F42D31ED7C2FAE589575B6BAD34F2B102B0B096CCB196D5C6D26489E09E700F6BA28A2803F8A1CE78E839CF6A09E3DE931C1FD6949CFFF00AFA57DC1E79EBFFF0004FBB7D46EBF6F7F8211E8F776561ABCBE3FD056C6E6F6D5AEEDADE73A8C1E5BC90AC9134A8AC54B22C91960080EB9DC3FA35FDA4FC17F1EE1F8CDFB3E2DF7C4AF84371752F8FEE974F920F86BA8C31DB4FF00F08B788097954EBAE65430899022B4643BA3EF210C727F30DF0D3E23EB1F07FE23F87FC5BE1DBC3A77883C2FA95BEAFA65D7931CBF66BAB79565864D922B236D7453B594A9C608238AFB761FF83903F68CD4BC4DE05D57C44FE07F155D78075B975DB037BA29B7F3E7934FBDD3D965FB349102BE45FCC4050A772C64920156F3B1986A9524A50B6CCD612496A7ECE7FC1413C17F1EED7F60AF8DD2EB1F12BE10DFE911F8035D6BEB6B3F86BA8DA5CDC4034E9CC8914CFAECAB13B2E42BB4720524128C06D3FCB675EFFAD7EAC7C5AFF83A67C57F1DFF00669F881F0FBC4FF087C3C26F1CF86751F0F7F68E97AE4D6AB626EED9EDFCEF2648A52FB3CC2DB37AEEC01B875AFCA7FBC3EB4F2FA3529C5AA8BF2FD02A4937A0609FF1AFAB7FE08852F8220FF829EFC313F118F8517C1A3FB546A27C48601A60FF00894DEF95E6F9FF00BAFF005BE5EDDDFC7B71CE2BE51200E7A73D6BA9F831C7C4BD3BFEDAFF00E8A7AF6B0386FACE269E1B99C79E4A375BABBB5D79A3CACDB13F56C0D6C472A9724252B3D9D93767E4CFEA3A3D5BF62588FCB73FB2C2FD24D0456C783BE2DFEC8BF0F3C416FAB787FC4DFB38E87AADA6EF22F74FD4745B6B88772946DB223065CAB329C1E4123BD7F3A5457E8F3F0B6335CB3C6546BFAF33F12878A2E0D4A182A69AEDFF000C7F4BF73FB71FC06BC9ADE49BE307C22964B490CB033F8AF4E630B95642CA4CBC1DAECB91D988E84D4BFF000DE7F037FE8B3FC28FFC2BB4FF00FE3B5FCE6E99FB3AFC41D6BE1C3F8C6CFC0BE32BBF08C51C92BEB90E8B73269A891B157637013CB0158104EEE0820F4AC6F117C3BF107842DE59756D0B58D2E2B7BE974C95EEECA48163BB882B496EC59462540E8590FCC032E4722BCE8F84D974A4E11C53BAD3ECEE7A6FC5ACC9454DE1159F5F78FDFDD37F699F017867EDD0693FB48FECFD1D85CEA57BA842979736F3CD17DA6EA5B928CE9AA46ADB5A520108B90071573C1FFB4F7C32B4F8A165E23F10FED13F02B521A6E9779A6DBDB69BA95AD87FC7CCB69233BBC9A84FBB1F6450000BF7CF35FCEED15B7FC41EC1FF00D044BEE463FF00118B19FF0040F1FBD9FD35D87ED39F0ABE39B4FE12F0D7C52F87DAD6B5AEDACF6D6D67A67882CEF6EA4FDD3966486394B3ED40CC40ECA4F0066A793E07EACFFF0033069E3FEE14FF00FC7EBF0F3FE087DFF2943F861FF715FF00D34DED7F41B5F88F899E19E514331A747129D5F713BB94A3BCA4ADEEC92E9D4FD778038D71999E027894942D371B2D768C5DF55E6717F09BE13CDF0D6E753966D4A3D41B51D9F72D4C023C493487ABB672663E980075AED2A86B3E29D33C3B75A7C1A86A3636336AF73F62B08EE2E1226BD9F63C9E5441882EFB2391B6AE4ED4638C034697E29D335CD4F52B2B2D46C6F2F346996DF50B782E12496C6568D655495412518C6E8E036095753D0835E065795E1B2EC2C707838F2D38DECAEDDAEEEF56DBDDF7EA7D4E231152BD4756ABBC9FFC374F42FD429610477F25D2C312DCCD1A4524C10798E8858AA96EA429772076DEDEA6A6A2BBCC428A28A0028A28A008EEADC5DDB4913642C8A5091D70462B92FD9EFE09695FB35FC0CF097C3FD0AE350BBD1BC1BA55BE8F6535FC88F732C30A04569191514B90064AAA8CF6155741FDA93E1978A6F759B6D33E22F81351B8F0EDDC561AB456BAFDA4CFA5DC4B37D9E28670B213148F37EED55F059FE5009E2BBBA3A5FA075B05145140051451400514562DE7C48F0F69DE1DD5357B8D7B458349D0DE58F52BD92FA25B7D3DA238956690B6D8CA1FBC188DBDF147901B54552D07C4BA778AAC9EE74BBFB2D4ADE29E6B5796D6759912686468A58C9524074911D197AAB2B038208ABB4005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514520705CAE46E0324770280168A4570C48041DA7071D8D735F193E2DE8BF023E176B9E30F11DCFD8F44F0FDA3DE5DCDB7715451D00EEC4E1540E4B3003AD542129C9420AEDEC4CE71845CE6EC96E74D457E5A697FF05A8F8E7F1A75DD4B50F873F0FBE1D2F86B4E691D6C75ABF2757BA8A352EC540B9872DB064AC7149B7A65BBFDADFB00FEDCDA27EDDBF075FC41A7D9CBA46B1A54FF0062D674B95C48D633ED0C30F81BE36072AD819C10402A457D266FC219A65947DBE2E9DA3A27669B8B7B2924DB57E973E6F28E2FCAF33ADEC30952F2D5ABA69492DDC5B5ADBAD8FE45F77B679A17823E946DC1073BBD7349BB3FFD7AF48F581460FF00F5FA520E07F434E3D681F371C7D0D001BB9E7F1A08CD229C0FC297BFFF005A801302BA9F83031F12F4DE39FDEFFE8A7AE5DB93DFF9D7A7FEC65F067C4DFB40FED25E1BF07F83F4A935BF11EADF69367651C91C6D37976B34CF867655184473C91D3D6BD1C9EAC29E3E854A8D28A9C5B6F449292BB6FB1E4710529D5CAF134E9A6E4E9CD24B56DB8BB24BAB67A9515F4EFF00C39A7F698FFA259A97FE0CAC7FF8FD1FF0E69FDA63FE8966A5FF00832B1FFE3F5FBDFF00ACD93FFD05D2FF00C191FF0033F97FFD58CE7FE812AFFE0B9FF9189F15FE2E786C7EC85F087C3ABE1FF07F8835A8345D4A29F5196F6F4EA5A03BEAF76EA82386E920525195C09E1724383D08AF7DD575FF0083979F16B4DD1AEEFF00C12FE0B83E2E6BB7D6F61697D690E9E216D26CD6C9DB0AF0A5A3DD46886478DA1C2BEE0CA18578EFFC39A7F698FF00A259A97FE0CAC7FF008FD1FF000E69FDA63FE8966A5FF832B1FF00E3F5E057C4649536C7C16B51E9523BD497369EF69CBD2DEA7D0D0A39E5369BC04DD9416B4E5B460E1AFBB769DEEEEFCB63CD7F6C7D634DD73E3A5ECDA6786F44F0B20B4B58E7B4D235BD3357B3965585434CB369B145660BE0332411AAAB96E01C8AF2CAFA77FE1CD3FB4C7FD12CD4BFF06563FF00C7E8FF008734FED31FF44B352FFC1958FF00F1FAF630B9FE4D468C68AC5D2D15BF891FD64DFE2CF1B17906755EB4AB3C255BBFFA772FD2297E0AE697FC10FBFE5287F0C3FEE2BFFA69BDAFE836BF18FF00E095FF00F04D9F8DFF00B37FEDE7E04F1A78D3E1FEA5A3786B46FED0FB65E7DAADAE3C9F374EBA853E48A4773992441C29C672700135FB15FF000955B7FCF2D4BFF05D71FF00C457E19E2963B0D8BCD69D4C2D48CE2A9A578B4D5F9A7A5D75D51FBA785981C4E1329A94F154E5093A8DDA49C5DB961AD9DB43C53F6E9F865AFF00C51D6BE0BDAF87EFFC4BA2CB65E3E4BBBAD6343B382E6E34780691A9A19C8B88278150BBA465A58D97328030C54D7886AFF0B7C79F0BB54F8A31EA5AA7C5AF11786751F89BA35CF88B5DB0B296DFC45ABE8A342B4467B4FEC7B7B791D52F16DE290D94624F2A2981248735F6D7FC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF00115F9AC572B6D7577D7D60EDE9EE59F7B9FA6B95DA7FDDE5D37FB5AFAAE6D3B3499F03FC4CF0AFC65F147C18F0FB58DEFC67B3FEC8F09F8F754D1059DDEA76FA9DC343736CFE1C8F51008965BB3001886E732C98916457266537FE27F87FE307853E15F8CB40D2B51F89B0787C7C41D224B9D52E2DB5ED7B5583489F45B59AE8DA8B4B987529615D4C80C9673A98819D4008AD1D7DD3FF000955B7FCF2D4BFF05D71FF00C451FF000955B7FCF2D4BFF05D71FF00C4516E9BEDBFF8F9F5F5B28BEE9094B6F2E6DBFBCACADDB975E5ED739DFD9CB4DD4747F809E0FB5D5B5DD47C4FA8C1A45B24FAB6A1A5DC69777A81118C4B35B5C334F0C8463724A4C81B3BBE6CD76959BFF0955B7FCF2D4BFF0005D71FFC451FF0955B7FCF2D4BFF0005D71FFC4554E4E5272EE44528C5451A550DFC51CF63324CACF13C6CAEAA092CA472001CF4F4E6A9FF00C2556DFF003CB52FFC175C7FF1147FC2556DFF003CB52FFC175C7FF115128F345C5969D9DCF8335AF0D789BC4BFB397887E15782EC3E22EA7F0DBC397FE111E18D4351F04DFE81AE69089AEDB19ED02DCDBC46F12DA0844CB74B6E3620C4CF2B8690EC7C59F0FF008E7E1CE85E3AF03598F8B773E153E3EB68B41D7E5B9F15EBD7DA4D9BE8705CB157D3AEE1D46F2D9AF44D002D7622864972EC44612BEDBFF84AADBFE796A5FF0082EB8FFE228FF84AADBFE796A5FF0082EB8FFE228926E0E2DEFBBEBF635F55CBA37AEBADDDDB14ACFF0025D1696FF87FC2CAC97C59F0674EF8E1E2DF0EC7E21BF3F1020F1AE91F02F4C9749B2D466BBB2D367F14BAEA6921B9B7665825BA1FE8DBD26DDB7746CC322365F57FF8266E8BE22D2BE0B6A527887C59E31F134B797E92A41E25F0CEBBA25E692FF66844B00FED9B9B9B99D0B82FBD25308769163000DA3DF3FE12AB6FF9E5A97FE0BAE3FF0088A3FE12AB6FF9E5A97FE0BAE3FF0088AD5CEF29CADF17E1EF4A5FFB75BE4BD09924ED6E9FFC8C63FA5FFEDE97734A8ACDFF0084AADBFE796A5FF82EB8FF00E228FF0084AADBFE796A5FF82EB8FF00E22B319A55F2FF00C50F849E20BCFDA7E4F0859E93A8CDE01F891ABE9DE34D67518E06369613E982313DAC8FF754DD3DAE96027F1AFDB0E0E0D7D1DFF0955B7FCF2D4BFF0005D71FFC451FF0955B7FCF2D4BFF0005D71FFC450B49A9F6FC7AAF95D276D9D927A03D62E3DFF0F4F3B5D5FA5EEB5B33E0AF8F361F1A35BF0769360FE21F897E12D06E7C73E33FB6EB161E1DF106BBA8D9A8D425FEC62B6FA5DCC1786CFC83318C9325AFCB0078D94A63AEF88F7FF19FE1F7C59F1141672FC40D7743F036AB6FF1056EED2C2EE54F11DA4D1DA5BCFA2C28BBBCD2BFF135985AA67CB6367819C1AFB1FF00E12AB6FF009E5A97FE0BAE3FF88A3FE12AB6FF009E5A97FE0BAE3FF88A949C52517ADBF24ACFD6E93F34945DD5EF5392949B6B46DBFF00C09B6D69D2D26976BDD599CA7ECBFA0EBFE1CFD9FF00C29078AEF6FF0050F134D62B79AACB7B23492A5D4E4CD2C596E42C6F218D578DAA8AA000315DED66FF00C2556DFF003CB52FFC175C7FF1147FC2556DFF003CB52FFC175C7FF115A4DA726D2B2338DD249BB9A54566FF00C2556DFF003CB52FFC175C7FF1147FC2556DFF003CB52FFC175C7FF115251A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A54566FFC2556DFF3CB52FF00C175C7FF001147FC2556DFF3CB52FF00C175C7FF0011401A55C87C42F8737BAD6A516B3E1ED49345F10C31FD9FED0F179D05CC3927CB963C8DD8249539CA9F6241DDFF0084AADBFE796A5FF82EB8FF00E228FF0084AADBFE796A5FF82EB8FF00E22802B780FC0D6FE02D19ADE2926BAB9B890DC5E5DCE774D7931C6E91CFE00003800003815E43FF000539F827AD7ED11FB0AFC41F09787627B8D6EFAD60BAB3813EF5D3DADD4375E48F79040507BB8AF67FF84AADBFE796A5FF0082EB8FFE2283E29B523FD56A5FF82EB8FF00E22BA707899E1B110C4D3F8A0D497AA774736330D0C4E1E786A9F0CD38BF46ACCFE7CBF67BD7DBE187C34F89BAFA5D78734AF1368D691E99043AADE7D9F54B669E4314FF0066B7653BE4540CAF92A50366BF427FE0DE4F819E20F02FC2DF1EF8DF57B4B9B1D37C793D847A4A4E854DCC3682E0B5C807F85DAE4AA9EE22CF4C13F6478ABE02FC29F1DF8AD35ED73E1B785F5AD722219351BFF082DCDDA11D0895E02FC76E6BB8B6F10D8D9C0B1C56FA8471A0C2AAE9D70001FF007C57E93C57E254F38C0CF091A3C8EA38B93BDFE14AD15A6D757F9B3F36E14F0D6193E3A18B956E754D49455ADF137793F3B3B7C97A1FC5B93D6941C0EF4D5EFD734E1F28AF14FD083B77AF47FD9F7F67B6F8D926BFA8EA5AFE9FE10F087846CD6FB5DD72FD24992D55E411C30C50C60BCF712C8C16389719C33332468EEBE6E2BEADFD947E053FC40FD867E2941E27D7F42F877E1BF12EB9A35D78635DD7EE1EDED75BD6F4F17919D3D362B318FECDA8DC3C936DF2A1912DC48C81F70CEA4B96371AD4E0B58FD987C1BE38F879E22D7FE14FC42D4BC5D3F842D7FB4757D135FF000E2E83AA7D883AA49776CB1DD5DC33C519742E3CD495558BF96511D93C408E3E9E95F4D7C3BF87163FB16687E31F1678ABC63E05D4BC49A9786355F0D787BC3DE1AF11D9F8865BD9353B39B4F9AE6E26B1925820821B6B89E401E412B4A21023C6F74F9931B8FB5106DDF5BA1B01C67A75AFB63FE0DD518FF82C67C1EFFB8D7FE99350AF89D4E4FF00857DB1FF0006EB8DBFF058EF83DFF71AFF00D31EA15189FE0CFD1FE410F891FD4351456678CFC67A5FC3CF0B5F6B7ADDF5BE9BA569B119EE6E666C244A3F993C000724900024D7C71DC69D159DE11F14DA78DFC2DA76B3A7999AC755B68EEEDCCB0B42ED1BA86525180653823822B46800A28A8EEEE96C6D649A4CEC894BB6149381CF4140125151595EC5A8DAA4F03AC9148372B2F422A5A0028A28A0028A2B91F08FC77F08F8F3E20EB9E15D235DB1BED7FC398FB7D9C6F97873C1C1E8DB4FCADB49DAC406C1E2803AEAC5D2F5AD5B56D32DEEA3D3F4F11DCC4B2A86BE7C80C0119FDCF5E6B6ABE41FDA83FE0A517DFB2578E740F07D97812D3C4DE7785EC7597BB9F5F6D3F679D25C4223082D66CE3ECC4EEDC3EFE31C64FA79464D8CCD312B0980873CDA6ED74B6DF7691E4E779EE0728C2BC6E633E4A69A57B37ABDB48A6FF03EABFB5EB3FF003E1A67FE07BFFF0019A3ED7ACFFCF8699FF81EFF00FC66BE06BDFF0082E6EB3625437C21D3199FA2AF8C9F3FFA6FAFA83F612FDAF67FDB3FE16EB3E22B9F0CA78566D235B93476B44D48DFACBB6DADA712798618B19FB4636EDFE0CE4E78F6B38E05CF32AC37D7330A1C94EE95F9A0F57E4A4D9E0E47E21F0F6738BFA8E5B88E7A966EDCB35A2DF59452FC4F59FB5EB3FF003E1A67FE07BFFF0019A3ED7ACFFCF8699FF81EFF00FC66B4E8AF923ED0CCFB5EB3FF003E1A67FE07BFFF0019A3ED7ACFFCF8699FF81EFF00FC66BC0B58FF0082AFFC19F0E789B5FD23539FE27E977BE15D364D6758FB77C29F15DB43A658A09C9BB9657D38469037D9A709216D9218982162315EEDAF78FB4FF0F7872D35595354BAB3BE9ADE187EC1A5DCDFCA4CEEA91B18A08DDD532E0BC8CA1235DCCE555598004FF6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D78C7C35FF008280FC2BF8B5F18E5F01E8BACEB87C4297DA8E9709BEF0B6ADA769FA85DE9F23477B6F697F716D1DA5D4B0B23EE482576C46ED82AAC4007AA7DAF59FF9F0D33FF03DFF00F8CD1F6BD67FE7C34CFF00C0F7FF00E335E77E1AFDB63E1D78CFE2C3783B47D4F5BD57504BB974E6D4ACFC35A9CFE1F5BB8B7096D4EB0B6E74EFB423AB46D0FDA3CC5914C65438DB5EAF40199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D60FC53F89BA27C15F869E20F18789AF4E9DE1DF0B69D3EADA9DD88249FECD6D046D24B27971AB3BED4563B514B1C600278A00B7F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD79F7C04FDB43E1E7ED27E22BFD17C33A96B56FAFE9B691EA3368DE21F0DEA7E1BD50D9C8C552ED2D351B7B79E4B6670504C88D1EE05776E18AF54A00CCFB5EB3FF3E1A67FE07BFF00F19A3ED7ACFF00CF8699FF0081EFFF00C66B3BC1FF00177C3BE3DF1378B347D2B51173A8F81EFE3D335B88C32462C6E24B586ED1373A857CC1710BEE42CA37E09C82069F84FC5BA578F7C3361AD685A9E9FAD68DAAC0975657F61709736D790B8CAC91C884ABA10410CA4822801BF6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D14018B1EB5AB49A9CB6A34FD3FCC8624958FDB9F04397031FB9EBF21FD2A7FB5EB3FF3E1A67FE07BFF00F19A2D7FE472BFFF00AF2B6FFD0EE2A7F106BB6DE17D06F753BC6912CF4EB792EA768E2799D63452CC42202CC700E154127A004D0041F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD731F06BF694F067ED0177ABC1E13D5A5D467D04C4B7F1CBA7DCDA3DB1977EC044D1A139F2DFA6718E71915DD50053D0B537D5B4FF3648961904B2C4C8AFBC0292321C1C0C8F973D075A35DD4DF49D3FCD8E259A432C512A33EC04BC8A83270703E6CF43D2A0F097FC82A5FFAFDBBFF00D28928F16FFC82A2FF00AFDB4FFD288E800FB5EB3FF3E1A67FE07BFF00F19A3ED7ACFF00CF8699FF0081EFFF00C66B4E8A00CCFB5EB3FF003E1A67FE07BFFF0019A3ED7ACFFCF8699FF81EFF00FC66B9FD4BE3225B5E5E7D8BC3DE23D674ED365786F351B18A1682078FFD62857956694A743E4C6FF302A32CACA3ADD3B508357D3E0BAB59A3B8B6B98D658658D8324A8C32ACA470410410685AABAFEBFAE9DC1E8ECFFAFF0086EBD8A5F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD68C920890B310AAA32493800572BF0E3E367877E2C5C5C26873EA33AC11ACC935C695776905E44C4812DBCB346897119C7FAC859D70CA73865245ABB20D95D9B3F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD36FF00C6DA6699E30D37409EE766ADABDBDC5DDA41E5B9F36280C4256DC06D1B4CD1F048277719C1C41F11BE23E91F09FC2371AE6B93CF6FA6DB49144ED05A4D77233CB2A451AAC50ABC8ECD23A280AA4E5A8BE97FEBB7E7A06AF42CFDAF59FF009F0D33FF0003DFFF008CD1F6BD67FE7C34CFFC0F7FFE33597F0DFE30F87FE2C25F8D16EEE1AE74A9561BEB2BCB19EC2F6C99977A79B6F7089346194EE52C8030E4122BA7A00CCFB5EB3FF3E1A67FE07BFF00F19A3ED7ACFF00CF8699FF0081EFFF00C66AAE91F13741D6FC37A9EB10EA76E9A5E8D71776B7D75719B78AD5ED6478EE37B4814054647CB7DDC2E41239ADB8665B885648D95D1C06565390C0F420D01E5FD69B99DF6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D140199F6BD67FE7C34CFF00C0F7FF00E3347DAF59FF009F0D33FF0003DFFF008CD69D140199F6BD67FE7C34CFFC0F7FFE3347DAF59FF9F0D33FF03DFF00F8CD69D14019DA56AB7373A9DC5ADD5BC10490451CA0C539943072E3BA2E08D87F3AD1ACCB5FF91CAFFF00EBCADBFF0043B8AD3A00FE288927DA902EFF00EB4649FC4F7A5CF3D0E6BEE0F3CD2F065FE97A578BF4AB9D734DB8D6344B6BD865D42C20BBFB1CB7B6EAE0CB0A4DB1FCA6740543EC7DA4E76B6307B5FDA67F696D73F69BF1B5BDF5FDBD9E8BA1E8D6C34EF0F787B4D531E9BE1DB1524A5B5BA124E324B3BB12F23B33B966626BCDC1E39C7FF5E90F353CAAF718E39039C75A4031FF00D6A18E4E3B74A52727F1F4AA109BB07AFE7DABED7FF83755BFE371DF07FDFF00B6BFF4C9A857C518CF03F3AFB63FE0DD623FE1F1BF07BFEE35FF00A63D42B0C4FF00067E8FF22A1F123FA86AF95BFE0A59F097C6DE30B2F0D788F45D66E0785BC2D72B77AB6990E9916A0F0956CFDB85BC8425CF96BD6273800123AB63EA9A2BE38EE3C03E14FC31F8AFAFC9E1DF118FDA0A3F127866E9EDF5036E9E09B2B75D4ED49573189036F8F7A646E0372EECE322BDFE9B1C6B0C6AAAA155461540C003D053A800AE7F56D2F56B737173FF000908B6B652D26D3628DE5272719CE4E057414846450072DF0D349BEB34B9B99E66FB2DD36F8A2688464FFB7B470B9F415D551450079DFC74F82BAB7C4D9F4EBFF0EF8C758F066B5621ED5AE6D713453DACA57CE4685FE4F330A0A498DCACA3B5763E0CF0A5BF817C27A768D6925E4D6DA65BA5BC525D5C35C4CEAA300BBB1258FBFF004AD3A280391F8E3E0DF10FC41F86B7FA3F867C43FF0008B6A77FB223A9083CE92084B0F37CBF986D729BB6B763D307E61F1DFC2BFD8934F87F698F8B5A5782758BFF000B7887E1E3787E6D0356690CEC1E6B177B813AE71224CDCB8C632781B72A7EF2AE7FC3BF0BB42F0A78EFC45E25B0B1F235BF167D9BFB56E7CE91BED5F678CC70FC8CC5536A123E4033DF2680372D1258ED63599D259820123A26C576C7242E4E067B64E3D6BF283FE0AF7E29D3FC11FB40E81A9EA5750C102F80B44B758C36FB8959AE755605215CC8CA021DCEAA550B20620BA06FD63ACCF057FC89BA4FFD7943FF00A00AFA5E12E249E4598ACC210E7693566EDB9F29C69C2D0E21CB2596D4A8E9A6D3BA57DBCAE8FC08F027C50F0EF8D3C4D67682FCC773A8DC476D135D5B4B6B046CEC1577CD2AAC71A0279776555192C4004D7EA77FC119A0863FD9D7C5925B4D04F6F77E2A37513C32AC80AC9A569AE01C13B5C03864386460CAC159481F5E515F5BC63E2862788307F52A94142374F46DEDF23E2F81BC22C2F0D63FEBF4B10EA4ACD6B14B7F99E2BAC7843C6973FB6BD96AFA17F68E97E14874658BC4135F5CF9F63AB9DCFE4456D06ECC72C67716932A30DCA9CFEF3DAA8A2BF2D3F5F3E1DFDB97E12F8ABC5FE32FDACE4D27C37E21D463F127ECFF006BA2E91259E9D2CC353BF0FE20CDADB9552259C79D0FEED72DFBD8F8F986797F18FC2CF8B3F03BC41E27F0FF0084354F8D9ADE877D0FC37D5D2EAF752D4B52912F9FC46F16B6B6F29244109B28A26B8B48365BC51B12228A3720FE8551401F247EC0771AF597ED23F16F4ED497E26F896D56E9EF078BBC483C53A5594CF2DEDC94D3ADB4AD580B2416F1ED5175A5130CE810B245940FC6FEC83FB17FC40F19EB575AC78DBC410E8BE16F087C4EF1B788FC2DE1C8FC2D71A76A82F2EF50D4EDE0BEB9BE96E985C5B9B7BC9E58921B683779D13191C27CDF74D1401F2B7EC03F190FC2AF849E00F81FE21F007C49D03C75E0BD320F0F5F11E10D45F409CDAC215AFE2D6444DA7BC332AF9CA0DCF9F99363C6260C83EA9A28A00F15FD937C21E34F0D788BC7536B3FDA3A7F846FB599A5D034AD5AE7ED9A85B0DEDE74A660C71148F9648C96201CEEE72EEFF828DF86752F1AFF00C13FBE36E8FA369D7FAC6AFAA781759B4B2B1B1B67B9BABC99ECA6548A2890177766200550492400335ED145007C1DF14B55F885FB4A472F8E7E0B7863C71A06BFF0E3E13F88743D2751F12786EEBC3775A9EBB7B1D935B5A5BD9EA70C134AB1359F98D2C88B6FBE48555E422511789697A7F8E3C3DFB2A4B77378FBF687F197D8F5F83523E125F87FF15FC31A8EAB2FF674E8DA7B6AAD77A86AB6F1B4BE5C8678A592C639210A613E6EEAFD5EA2803F38FC23F0B3E206AFFB6EFC4E1E35F0FF00C57F0EFC23F19EBD6434F1E17D4357B5BE7D69FC35A4DBABDFDE58B24F269E816E211711CBE425CC5235C36442C9C47C01F015F7C31FD943F679F0D789F4EFDAAF47F86FA1F85F52B0F1759786D7C691EBD69E2B8E3B04B6422D7FE26634F118BF117D9FFE25BBF6E7FE59D7EA9D1401F949F14FC4FF001526F185CF85FC65AF7ED1771F12AD3E097876F342D2FC1573A97931F8B65B9D5D229F513A5A9B789898E2595EE88D3DC23F9BBC47115FD4DF0D25F47E1CD3D754689F5316D18BB68BEE34DB46F2BD38DD9C565587C25F0FE97F16354F1C41A7ECF146B3A5DAE8B797BE7C87CEB4B696E25823F2CB79636BDD4E77050C77E0920281D1D0078AEB1E10F1A5CFEDAF65ABE85FDA3A5F8521D1962F104D7D73E7D8EAE773F9115B41BB31CB19DC5A4CA8C372A73FBCF6AA28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F98BC7BE25F8F9F0D7C6BAA783B45B387C5F078C2EA49BC3DE29B88D634F0DC6CC4CB1DDA2AED3E529CC671F37180FF00EAD7E86F016857DE18F05697A76A7AACDAEEA3656B1C373A84D1AC6F7922A80D2155E064F6FCC93CD6BD1401996BFF002395FF00FD795B7FE87715C27ED9DFF0909FD96BC6DFF08B7DABFB6FFB35BCAFB367CFF2F72F9DE5E39DFE57998C739C639AEEED7FE472BFFF00AF2B6FFD0EE2B4E803E26D7B56F865E00F8643FE144F898278C3C7571A15A699A4E95748D36EB4B82C5A789479A81A396633198E1B033C673F6CD62E8FF0E3C3DE1DD7AE354D3F41D1AC753BBCF9F796F651453CF9E4EE7550CDF89ADAA00CCF097FC82A5FFAFDBBFF00D28928F16FFC82A2FF00AFDB4FFD288E8F097FC82A5FFAFDBBFF00D28928F16FFC82A2FF00AFDB4FFD288E8034EB3BC53E29B1F05E8736A3A8CDE45AC1804852CCEC480A88A3259D988555504B1200049AD1A82F34BB6D465B77B8B78277B497CE81A48C31864DA577A93F75B6B30C8E70C477A06ADD4F39F02C3E3DD17407B68B43D062B7BEBAB8BAB67BDD51C5C69D1CD33CA12689212B23A6FE892007EE9618F31BB8F0378521F0278334AD16DE49268349B48AD124931BE408A14138E3271DAB568A3D3FAB7F5F3EA2EB722BE4592C665787ED08C8C1A2C03E68C72BCF1CF4E78AF92F56BEF1B697F0BFC4FE1FF868BE3EFF0084434DD3AC5AC8EAFE1FBCB4D4F454FB62ADCD9598905BDCDDA2D9890AED632A950A939664D9F5CD14ADADFF00E19EFBF75AFF00C1D5DDDFFAFEBFAFC2DF15FC4D7F1C5B7C10B3D2B44D57E22EA974A354BCB1D661F0E78AED2EA1B8548BC8B036EF762E5B7B48EE9717D2CB00D853630E17BEF12687E3C957E28EB90CFE3AFB5A5EE956F696F05CDC285D30DAE9EFA8B585BE444D7040B90AC8A5D640C10876607E96A29F9FF5D3F34ACFBADF5BB6BAA7EBF8BBFE0F55D9B76D2C97CDBA87C29B0F89DF127E1E0D164F8A365E18B6D275E4B9BCBBBAD66C751495E4B031C725CDD95BC8C3323320DEBB84440DC9B94DAF179F13EB9FB05784E7D734FF00105FF8960FF847AEF54B75D3A79F516686FECE49DDA04432B38547660173C1E2BE88A284EC925D1A7F736FF5B7A240BCFF00AB9F31FC644F1878EECFC77E37F0469FE25D1E3BAD2749D1A07934CB9B6D4EFE186FA496F668ECD8C3740A41348883314CE7CCF28AE6391B0ED21D7F42D23C1F2AEB5F11FC6AB6FA9CF145A42E89E2CF0F1984935B61E5BA9649650B0FEF0817F234322C8EA1A30991F5C51443DC6ADB7F5FF05AD2E9B7609FBC9DF7FF00816FCB7E8CF8B352F85FE2DF10782FE2DE85AE697E354B6D61BC5127842DB497BEB5B6B9964BABB95BED8212BB9A5FDC987CE26192362AB96660FD078BED7534B0B586C97E3347A68F09429E0E5D3FFB69665D67CD9C4C2FF7FCE0EEFB2EDFED1FF47F2F763E5DF5F59D14A2AD151EC92FB9495FD75D1F4B14E5793979B7F7B8BB7A7BB67DD367C8FAAEB1E27D63E3878BEC62D4BE225CF8B34CF116871695169D25EFF6059A1B3D3E4BEF38C6BF661195695992E3AE7310123313F5C565685E0AD33C35AE6B3A9595B7937BE21B84BBD424F31DBED12A431C0AD82485C47122E1401F2E7A926B56AAFEEA5FD6C969F71095BEEB051451486145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500665AFFC8E57FF00F5E56DFF00A1DC569D665AFF00C8E57FFF005E56DFFA1DC569D007F14478381D293EE8EB4A0E451D3AFF003AFB83CF106067AF07B77A3EE8EBF8D753F03BC05A6FC53F8D5E0FF0C6AFE21B1F09691E23D6ECF4BBED76F027D9B458279D2292EA4DCE8BB22563236E741843965EA3D0DBF601F1D74FEDEF827F5FF85C9E10FF00E59D439C53B363B33C4F6E17BFAD2A900E457ACFC4AFD9B742F86DE27F1C69127C45F0DEA775E11F0A693ADDB49A6DC5B5FDAEB7A8DD1D2C5D6976F3DBDC490C8F6BF6EBBDD2C6F207FECD93E55DC7679283CF6C53524D5D00BBB71EB818E95F6BFF00C1BAFF00F298EF83DEBFF13A1FF943BFAF89CFCA7A57DB1FF06EB73FF058EF83FF00F71AFF00D326A159627F833F47F90E1F123FA86A28A2BE38EE0A28A2800A28A2800A28A2800A28A2800A28A2800AC983C19656D0A471B6A11C71A85555D42E005038000DFD2B5A8A00CCFF00844AD7FE7AEA7FF832B8FF00E2E8FF00844AD7FE7AEA7FF832B8FF00E2EB4E8A00CCFF00844AD7FE7AEA7FF832B8FF00E2E8FF00844AD7FE7AEA7FF832B8FF00E2EB4E8A00CCFF00844AD7FE7AEA7FF832B8FF00E2E8FF00844AD7FE7AEA7FF832B8FF00E2EB4EA366FF004951DB6B71F88A00A1FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D140199FF000895AFFCF5D4FF00F06571FF00C5D1FF000895AFFCF5D4FF00F06571FF00C5D69D1401923C1964B33481B5012328566FED0B8C903240277F4193F99A7FFC2256BFF3D753FF00C195C7FF00175A74500667FC2256BFF3D753FF00C195C7FF001747FC2256BFF3D753FF00C195C7FF00175A7450041A6E9B1693682080308C3337CCECE49662C492C4924924F27BD1A969B16AD68609C318CB2B7CAEC841560C082A4104100F07B54F4500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A74500667FC2256BFF003D753FFC195C7FF1747FC2256BFF003D753FFC195C7FF175A7450053D3342B7D2669648BCF324CAAAED2DC4931217240CBB1C0F98F4F5AB9451401FC5113B4F1C67D6902FA7FFAE9338A1BEEF5FD6BEE0F3CF60FF827D78934DF05FEDEFF0004758D62FECB49D234AF1FE837B7D7D7B32C16D67047A8C0F24B2C8E42A22AA92CCC4000124F15EF2DE2DFDB1F3FF27398FF00BB9CD0FF00F9735F287C0EF8B3A87C01F8D1E10F1DE8D0D95CEAFE0AD6ACB5EB186F519EDA59ED6749E359551958A168C060ACA48CE083CD7A1FFC3CAFF68D5FF9AFDF1ACFFDCF3A9FFF001FAE7A909395D25F3293D0FADBC55FB6978FFE1D5F7ED59A6E87AFF81BC623C51F057C1B6FE37D5EEEECF88E6BFB88F4BD1741BC16B7F6B77E4B4EB71AC5CBBCCCD3AB3DB6304E4D7E6E93C57AFF00C45FDB6BC6BF163C47E3CD63C40F65A9EADF123C25A478435BBEB933CD7171069CDA4BC773E63CACCD752B68F6CD2C8E58399672154B2ECF203F77FA8A7469F22D576FC9049DC31F2E2BED8FF8375C63FE0B1FF07BFEE35FFA64BFAF89FEF75F4CE6BED8FF008375F9FF0082C7FC1EFF00B8D7FE99350A313FC19FA3FC821F123FA86A28A2BE38EE0A28AA9AC6BB65E1DB3371A85E5AD8DB83832DC4AB1203F56205349B7642949455E5B16E8AA7A0F886C3C53A5A5EE997B69A8D9C8CE893DB4CB2C4CC8C51C0652412ACACA7D0A91DAAE50D34ECF708C949734760A28A290C28A28A0028A28A0028A28A0028A28A0028A28A002A36FF008FA4FF0071BF9AD4951B7FC7D27FB8DFCD68024A28A2800A28A2800A2BCBBE207C70D63C15A85C6CD2ECEE6CA290A79DBD814C1C7CC3B7D7A56047FB56DFB0C9D2EC87A9F31B8ED5F135FC42C968D5746A4DA92FEECBFC8F629E458C9C79E295BD51EE14578CC5FB4FDF49FF0030BB41FF006D1AAD45FB47DEC9FF0030EB5FFBEDAB0FF8897907FCFD7FF80CBFC8BFF57B1DFCBF8A3D728AF2C8BF680BC93FE61F6DFF007DB5598BE39DD483FE3C6DFF00EFB354BC48C85FFCBD7FF80CBFC89FEC0C6FF2FE28F4AA2B2BC1BE2093C4DA1ADD4B1A44CCECB85391806B56BECF0B8AA789A30C451778C926BD19E4D4A72A737096E828A28AE82028A28A0028A28A0028AF3DF89BF16357F046A330B4D3AD6F6D6000BB1760E9C0392076F7AE422FDABEFE45CFF65596319CF98DD3AD7C6E338F727C2D7961EB4DA945B5F0CB75A76D4F5A8E498BAB05520959F9A3DC68AF1787F6A1BE93FE61969F512355A8BF691BD93FE61D6BFF007F1AB93FE225E41FF3F5FF00E032FF00235FF57B1DFCBF8A3D7A8AF2B8BF682BC7FF00987DB7FDF6D5662F8EB7527FCB8DBFFDF66A9789190BDAABFF00C065FE44FF0060637F97F147A5D1583E02F16CBE2EB29E59618E2F29C2AEC6272319ADEAFB0C063A8E330F1C561DDE12D5743CBAD4674A6E9CF741451457599051451400514514014350F14699A45C79575A8D8DB4B8DDB25B8446C7AE09A83FE13CD0FF00E833A57FE05C7FE35CFD8E8F69AA7C4EF129B9B5B7B82B1DA0532C41F6FC8FD322B6BFE113D2BFE819A7FF00E03A7F85004DFF0009E687FF00419D2BFF0002E3FF001A3FE13CD0FF00E833A57FE05C7FE350FF00C227A57FD0334FFF00C074FF000A3FE113D2BFE819A7FF00E03A7F85004DFF0009E687FF00419D2BFF0002E3FF001A743E36D1AE25544D5F4C777215556E909627A003355FFE113D2BFE819A7FFE03A7F85735F163C19A4DD783C42DA759AA5C6A1610BEC8950956BC855864004641238F5A00F41A2B87F0F788AEBE1F6AB0689ADCEF716172E22D2F5394E4B9ED6F39FF009E9FDD6FE3FF007BAF714005145140051451401F9AFF00F058CF8EBE37F863FB4D68561E1AF18F8ABC3D632F862DEE24B6D3356B8B489E437776A5CAC6E01621546719C28F4AF93BFE1AEFE2C7FD14FF00887FF851DE7FF1CAFA1FFE0B89FF002761E1EFFB14ADBFF4B2F6BE35AFC3F88B155E399568C66D2BF767FA3DE1464B9755E11C054AB421293A6AEDC62DBD5F5B1E87FF000D77F163FE8A7FC43FFC28EF3FF8E51FF0D77F163FE8A7FC43FF00C28EF3FF008E579E515E2FD7711FF3F25F7B3F42FF0057F2BFFA06A7FF008047FC8F43FF0086BBF8B1FF00453FE21FFE14779FFC728FF86BBF8B1FF453FE21FF00E14779FF00C72BCF28A3EBB88FF9F92FBD87FABF95FF00D0353FFC023FE47A1FFC35DFC58FFA29FF0010FF00F0A3BCFF00E3947FC35DFC58FF00A29FF10FFF000A3BCFFE395E79451F5DC47FCFC97DEC3FD5FCAFFE81A9FF00E011FF0023D0FF00E1AEFE2C7FD14FF887FF00851DE7FF001CA3FE1AEFE2C7FD14FF00887FF851DE7FF1CAF3CA28FAEE23FE7E4BEF61FEAFE57FF40D4FFF00008FF91E87FF000D77F163FE8A7FC43FFC28EF3FF8E51FF0D77F163FE8A7FC43FF00C28EF3FF008E579E5147D7711FF3F25F7B0FF57F2BFF00A06A7FF8047FC8FD6BFF008239FC46F10FC4EFD9975DBFF12EBBACF886FA2F13DC5BC773A9DEC9772A462D2D1820691890A0B31C671963EB5F58D7C69FF043BFF934FF0010FF00D8DB73FF00A47655F65D7EE1C3B294B2DA3293BBB1FE70F8AF469D2E2EC7D3A51518AA8EC92B25A2E81451457B47E7A7CC3FB697FC1577E1C7EC67E2A8BC2F7516ADE2EF1ACEAADFD87A2C6B24B6DBC653CE724042C30428DCF820EDC104F8C8FF0082E7EAEC323F671F8A5FF7C3FF00F18AE43FE085DE08B2F8BBA77C48F8DDE21862D4BC71AFF8A2E2C7EDB3AEF7B44F2A1B893CB27EEEF6B9C1C7F0C6A3A57E85D7C7E0259A6654563615D5284FE18A829697D2EDF57E5A1FBCF13D1E0DE10CC27C3D89CB258DAF42CAAD59579D34EA593928420B4845BB26DB6ED73E23FF0087E76B1FF46E1F14BFEF87FF00E3147FC3F3B58FFA370F8A5FF7C3FF00F18AFB728AEDFECCCD7FE837FF0029C0F9FF00F5C782BFE89E5FF8555CF88FFE1F9DAC7FD1B87C52FF00BE1FFF008C51FF000FCED63FE8DC3E297FDF0FFF00C62BEDCA28FECCCD7FE837FF0029C03FD71E0AFF00A2797FE15573E2EF0C7FC17CBC25A778B2CAC3E217C33F881F0EECAFDC247A85EDBF9D147EACE9B51F68EFB15CFB57DD5E16F14E9BE37F0E58EB1A3DF5AEA7A56A502DCDA5DDB4A2486E2361957561C1041EB5E7DF18FE0D786BE3F7C3BD47C2DE2CD2ADF57D17538CC72C32AF287B3A375475EAACB820F4AF80BE1D7C46F1BFFC10FF00E3343E16F164FA978B3F678F155E30D335308649B42958963F28FBAE392F18E2400C8803074AE79E371B95D44F309FB4A32D39D4795C1FF792D395F7E8F73D4A1C3BC3DC63869C385E83C26614D36B0F2A8EA46BC12BBF65292525563BFB36DF32F8754D1FA9B4566783BC65A57C42F0AE9FAE6877F6BAAE91AAC0B7369776D2078AE236190CA47515A75F5519292E68EC7E2B529CE9CDD3A8AD25A34F469ADD3414514532028A28A0064F7096D1EF91D235E9B98E0543FDB369FF003F56DFF7F57FC69751FF00549FF5D17F9D1400DFEDAB3FF9FBB6FF00BFABFE347F6DD9FF00CFDDB7FDFD5FF1A6B7068A7601DFDB965FF3F76BFF007F57FC68FEDCB2FF009FBB5FFBFABFE34DA68FEB480B16B7F05F06F2668A6D870DB1C36D3D70715357360BDBEAB7934442CAB281CF471E5A707FCF15B9A6EA49A9C1B9786538743D50FA1A00B14514500145145001451450057D5355B6D0F4F96EEF6E20B4B5B75DF2CD3C8238E35F5663C01F5AE73FE17B7823FE872F0AFF00E0DADFFF008BAE6FF6CD8D66FD997C56ACA195A088329190419E3E0D6D7FC2A5F0AFFD0B3E1FFF00C1743FFC4D005AFF0085EDE08FFA1CBC2BFF00836B7FFE2E8FF85EDE08FF00A1CBC2BFF836B7FF00E2EAAFFC2A5F0AFF00D0B3E1FF00FC1743FF00C4D1FF000A97C2BFF42CF87FFF0005D0FF00F134016BFE17B7823FE872F0AFFE0DADFF00F8BA3FE17B7823FE872F0AFF00E0DADFFF008BAABFF0A97C2BFF0042CF87FF00F05D0FFF001347FC2A5F0AFF00D0B3E1FF00FC1743FF00C4D00747E1BF18693E32B579F48D534ED56189FCB792CEE527546C6704A9201C11C56957CAFA1FC26D57C33F193E2878BFE1D2DB59F88747F10DB5A4BA317F234ED7ACC68FA6C86D9D47CB1481E491A3980F959D836558D7BEFC1EF8C3A47C6BF097F6A696678648256B5BFB0BA4F2EEF4BB94FF00596F3A755753F8104104820900EAE8A28A0028A28A0028A28A0028A28A0028A2BC2FF6F0FDAC4FECBFF0CA13A688A5F136BACF069CB20DCB005037CEC3B85DCA00EECC3B035DB9765F5F1D8986130EAF393B2FEBB2DD91526A117296C8F5CF16FC41D07C036CB36BBADE91A2C4FF0075EFEF23B656FA1722A0F087C55F0C7C40765D07C47A0EB6C832C2C3508AE4AFD7631AFC65F17F8CF56F1FF882E355D6F51BBD5351BA6DD2DC5CC86476FC4F403B01C0ED55348D62EF40D4E1BDB1B9B8B2BCB6712433C1218E4898742AC3041FA57EC11F08A1EC7DEC4FBFFE1D2FF7DFE7F81E57F6ABBFC3A1FB89457CBFFF0004E5FDB32F3F681D0AEFC35E259565F13E8908992E7183A8DBE42976038DEA4A863DF729EB9AFA82BF24CDF2AC465B8B960F12BDE8FDCD746BC99EA52AB1A91E788515E79F177F6B3F869F017514B2F1878DFC39A05F3A875B4B9BC5171B4F46F2865C29F5C62B5FE13FC77F067C75D264BDF07789F44F125BC04099B4FBB498C04F40EA0EE427078603A573CB03898D1FAC4A9C943F9ACEDF7EC573C6FCB7D4EB28A28AE52828A28A0028A2BC77E2C7ED05E22F871A94ED0E89637DA647214F3C48E1A3E71F38EDF5E95E3E719EE132BA6AAE31B49F64DFE475E0F0357152E4A2B5F5B1EC5457CF2DFB63EB905845753787AD62B69F94999E408DDB86E9566CBF6C3BFBBE9A5587E1331AF9BFF889590ADEABFF00C065FE47A5FEAE63FF00957DE8F7DA2BC56DBF6A4BF9C7FC82ECC7FDB46ABF6FFB465ECDFF0030EB51FF00036A3FE225641FF3F5FF00E032FF00223FD5FC6AFB3F8A3D6E8AF32B7F8EF7737FCB8DBFFDF66BB9F07F884F89F428EEDA311331652A0E470715EB64FC5F95E695DE1B0736E495ED66B4D3BAF339715966230F0E7AAACBD4D4A28A2BE98F3C28A28A0028A28A002B9DD5BE2FF84F40D465B3BEF147876CAEE03B65827D4A18E48CFA3296047E35D15787FC14F01E87E23D77E225C6A1A36957D71FF0985EAF9B71691CAF811C3819604E2803D17FE17B7823FE872F0AFF00E0DADFFF008BA3FE17B7823FE872F0AFFE0DADFF00F8BAABFF000A97C2BFF42CF87FFF0005D0FF00F1347FC2A5F0AFFD0B3E1FFF00C1743FFC4D005AFF0085EDE08FFA1CBC2BFF00836B7FFE2E8FF85EDE08FF00A1CBC2BFF836B7FF00E2EAAFFC2A5F0AFF00D0B3E1FF00FC1743FF00C4D1FF000A97C2BFF42CF87FFF0005D0FF00F13401A9A3FC5CF0A7887528ACEC3C4FE1EBEBC9CE2382DF5186592438CF0AAC49E01E9E95D0D7CEDFB4DFC05F0B78BB59F869A4FF00655BE94BA878AA45375A5C6B6775032691A9CB1BC72A00CAC92471B8EDB90641AEB3E107C60D5FC33E2F8BE1F7C42962FF008490A3368BACAA08EDBC536E839651D23BA41FEB21FF0081A654FCA01EBB451450014514500145145001451515F5F43A659CB71712C704102192492460A91A8192493C00051BE881BB6AC96A1BFD46DF4AB579EEA786DA18C65A495C22A8F7278AF8BFF6A3FF0082B3D8F862EEE346F871041AADD464A49ABDCA936C87BF949C17FF0078E17D98735F13FC4DF8F5E2DF8C7A9B5DF897C41A96AD212595259888A3CFF72318551F402BF44C93C38CC319155712FD945F75797FE03A5BE6D3F23F26E22F1772BCBE6E860E2EBCD767687FE05ADFE49AF33F58BC51FB657C2DF074C63BEF1CF87F7A9C116F71F6920FFDB30D58D63FF0504F83BA84DB13C6F60AC4E3F796F3C63F368C0AFC8CFB551F6AAFB28785597A8DA75A6DFF00DBABF0B3FCCFCFA7E37E6AE57850A6979F337F7F32FC8FDB5F067C5FF0AFC455FF00890F88F44D5CE3252D2F6395D7EAA0E47E22BA3AFC2BB4D565B0B85960964865439578D8AB29F622BE81F805FF00052FF883F06AE21B7D4AF5BC59A2A901ADB5172D322FFB1372C0FF00BDB87B57839A785988A7173C05553FEEC959FC9EDF7D8FA7C97C6CC2D59AA799D074FF00BD17CCBE6AC9A5E9CCFC8FD53A2BCD3F670FDABBC23FB4F7878DD787EF365F40A0DDE9D7185B9B53EA57F8973D18647D0F15E975F9762B0B5B0D55D1AF17192DD33F69C16370F8CA31C4E166A7096CD6A828A28AC0EA0A28A2800A28AF923F6BCFDBF4E877175E1AF01DC235D2662BCD5D70CB11E8520EC5BD5FA0EDCF23D7C9723C5E6988FABE1637EEFA25DDBFE9BE87CEF1371460322C23C5E3E565D12F8A4FB25FD25D59EE7F1B7F6A4F06FC03B7235BD483EA057747A75A812DD3FA7CB9C283EAE4035F2A7C4FFF0082A6F89F599E487C2DA469FA1DB1CAACF75FE9573FEF63845FA156FAD7CCFAAEA13EAB7B2DCDCCD2DCDC4EE5E596572EF231E4924F249F5AA320C0AFD9301C0396E0A09D75ED67DDEDF28FF9DCFE55E27F1973DCC26E18297D5E9F451F8BE73DEFFE1E53D0BC4BFB61FC4FF12B9371E36D762C9FF9749FEC807E1105AC65FDA47E2203FF0023EF8CFF00F07773FF00C5D71B2734C66C0AEDA982C2C7DD8538AF923F2FADC419AD49F3D4C4D46FBB9C9FEA7AD785FF006D8F8A5E1975F27C63A9CE0638BC09740FD7CC5635ED5F0C3FE0A99ADDA4A9178AF40B2D4613806E34F636F32FB9462CAC7D815AF902DDB8AD2B1F9B15F239C65783945B74D2F456FC8F7F26E3FE22C04D3C3E2E76ED27CCBEE95D1FA9DF077F692F087C73B5CE85A9A9BC0BBA4B1B81E55D47EBF21FBC0772A48F7AEF2BF263C3F773E997B0DC5B4D2DBDC40C1E3962728F1B0E4104720D7D8DFB2E7EDB526AB2DBE81E35993CD7C476BAA9F9439E8166EC0FFB7F9FF7ABF27C74E8E1EAF23765E67F47703F8BF4B31947079BC553A8F4525F037E77F85FCDAF43EA1A28A2A4FDBC28A28A00FE28BA9F6FD690FCA7F4FAD7D47FB467EC49E15F843F1A358F0E69B7FE219ECB4FF27CA92EA785E56DF04721C958947573DBA015C437ECE1A1FF00CFD6ABCF1FEB23FF00E22BEE6AAF67395396E9DBEE3CBA15635A946B436924D7A3D4F13DC3141EA3BD7B60FD9C34423FE3EF55E7FE9AC7FF00C4507F66ED1319FB56ADFF007F13FF0088ACFDA235B1E260F614BD7FA8AF6BFF00866FD0DB8375AAFE12C7C7FE3947FC337686BFF2F3AAF3FF004D23FF00E228E74166789F047F5AFB5FFE0DD61B7FE0B21F07FF00EE35FF00A63D42BC4CFECDFA17FCFD6ABFF7F23FFE22BEA4FF00820A7C35B1F0B7FC1623E18B5BCB74DF63935654F3194E77685784E70A3FBE7F215CF8AA91F632F47F91505EF23FA4FA28A2BE48ED0AF863FE0A31FB57F8E7E177C459FC3569AAE89A5681ACD8B1B0BA860BFB4D5AD3848A6DCDF68489897726293CA743F30C168893F733A891482010460823AD79A3FEC7BF0DEF3C7BADF892F7C29A5EA9AA6BD6C2CA637D10B886DEDFCB28D0C113652147DD233EC00BB4AE589DD5F43C3598E0B038BFACE369FB48A5A474D5FABDBEE7DBA9F2FC5B9563F31C0FD532FABECA4DEB2D745E8B7F4BAEF7D0F0CFF825ACFF00152F7E1768A971178274DF85160D7A9A6A8B49DF5AD43371313865B830C51A4A5865A3DCC131B1721EB6BF6B0F027857E3BFEDC1F0B3E1E7C50B0D335FF87BAA786F5AD574FF000E6B0AB3691E21D72DE6B25459EDDD7CABA782D25B9963864DEA3F79308F740B227BFF00C1DF847A27C09F871A77853C390CD6FA2E922416D1CD3B4CE81E47958176259BE676EA49A3E2DFC16F077C7FF05CDE1BF1DF84BC33E35F0EDC48934BA5EBDA5C1A9594AE8772334332B212A79048C83D2B933FCC618ECCA78CA704A2E52695AD74F9926F7F795F9BFC496C7670D655532ECAA9606AD4729A8C5377BEAAD74B6F75DB96D6F85BEACF8FFE147C594FD96FF68293E1EFC31B4F0E8F847AA7C57B3F0843676F1B358785E59340BDBDD42C6C447208E0D9796D6A7CA55F2A37BB9D0207384C5D53FE0A4F7BA7F89E5F1BEA1E06F06F89E6F09E95F15E4B6B9D3AC9BFB55ED7C39AB59DB416D6D74CF21896E630A6E30ACAEF146C15426D3F4AF87BFE09CFF043C31E11D7BC316FF0DBC3B37827C46F0CB77E0EBC8DEF3C290BC4FE623DB68D333E9F68C64FDE335BC11977F9DCB3735DE7823F67EF01FC335D30786FC13E11F0F8D123BA8B4E1A6E8F6F69F604BA7492E961F2D07962678E36902E37B46A5B2545792AE96AF5B34BD5C1457C94AED793B74D7E823282947DDF753575B5D2737F8F346FFE0BF5D3E24FDBCBE37FC42F80FF000A3E017C49F1DDDF84BE255E5A7C488F58D3ACFC0DA05D69D6EB03F8675A215E496EEF1A78D0B177BA454C42ACE20246D3F4A7C5EF8EDE28F82BFB175BF89B50F1078535BF1EEA71D95969779A078764BCD2B58D4AFAE2386CE1B5B3935188BA4AF3451AB497F147F3798F2C499DBD8FC35FD8FF00E12FC18B58A0F07FC2EF875E1482DF53FEDA8A3D1BC376762B1DFF0092F07DAD4451A813F932491F983E7D8ECB9C122B46E7F66FF87779F07E6F87B2F80BC172F806E432CDE1A7D12D9B479434A6660D6853C93994990E57973BBAF344ECE3284766D3F45649A4F5D74F8B5E8DA7A9177CD0949DF963CAF4DDF34A49DBB7BDF0AF357D99F267C0AFDBE3E31FED13A1FC3CF07DBDB7807C07F12BC4D79E2D8754D5F5BD19F51D3201A0EA2964D6F169F69AA906EE613248C89A9CA90AC1390F30031EC3E02F8E5F11FE2AFED31E3AD134FD47C13A3F84FE115F5A693AEE9F73A05D5DEB7E269A6D361BE3736B22DF471D8DB9370B1C62486E8BB4137CCB8E3BBF11FEC63F07BC63F0AACBC09ABFC28F86BAAF8234DBAFB75A787AF3C31653E956B71871E7476AD118924C48E370507E76E7935A3ABFECBFF0D3C41F13340F1A5FFC3BF035EF8C7C296CB65A26BD71A0DAC9A9E8F02EFDB15B5C18CCB0A0F324C2A30037B71C9A2577B3B3EF6EBFCD6DB4DB93E17BBD50B4B35D35B7A5F457DF6FB5BF4D99F197ECDFFB7CFED55FB4AFECF37FF10749F84BA4C5A4789F4EB0D63C2B77FD9DA7DC47A7C12DE46B73198A1F113CFAABC368F249864D29D9ED993CADF20893D2FC09FB65F8F7C43F14BE164D77AE78607C2CF1AD859DB41E258FE1CEAB17FC255AD48F74B359223EA3E7682C9E4C5B5750B7995D99A3F384B84AF5CD4FFE09EFF00F5ABBF12CF79F03FE105DCFE3393CDF1049378374E91F5D7F385C6EBB261CCE7CE5593326EF9C06EA335B7A3FEC81F09BC3BE3DF0F78AB4FF0085DF0EEC7C51E10D3A3D2342D62DFC376715FE8B6491BC496B6B3AC62482158E47411C6CAA15D8018245545C6E9DB669F7D35D2FA27D2CEDBFBD2E6B242A976E6E3D53B793D2DE6969AEAFB4796ED9E8B4514548C28A28A002A36FF8FA4FF71BF9AD4951B7FC7D27FB8DFCD68024A28A2800A28A2803CB358731F88AF4824113B10476E4D73BF107C7D6FF00087C2B75E25B4F08EB5AF5F59A859ADFC3D044D7B342482ECB13B28948C03B465CE3815D06B3FF0021FBEFFAECDFFA11AAE4E057F3ED2CCF1182C4CEA50959F33E89F57AEBD7CCFBDA54A8C9C1D7873455AEAED5D75575AEA79F7C1CFDB5BE0D7ED037C74FD2B57D05B5E43E5CBA2EAB6A34BD5237073E5F917014BB0EFB188CD763ADEA1E07D1B516B7D42C358D36618059B4EBD100C9CF12AA984F27190C7D2A8FC46FD96FE1DFED2FA1795E39F07E89E22788F951DCDC5B85BB85703849D312A0FF0075857968FD867E217C088223F06FE2EEB7069B6C463C2BE351FDB3A44B18E90A498F3EDD3A7DC24D7E9541D6C6616189C4E1A15A3257D12E6F9C65A3F553F91D93C070EE22A3A780C64F0953F96B5E70F956A51BAFFB7A8A4BACF767AB69B75F0FBC477063D2FC69A549725828806A303B2927805387CF5183CFAF4ADDFF0085572183CCB5D4609C1E503478561DBE604FF2AABF03BE2059FED0FF00096D755BBD362B3BD5926D3F57D22E825D2E9D7D6F218A7B7607230B221C631B94AB77159B7FF0E7FE150FC40BAF14786F4DD3ECB4F7B085352D2B4CB510ADE45149334D388D000675F3A365FBCCCB1C89D5971AFF00AA19162A9AAEB0F1B3D7DDBC7F26BEE3E4F138ACC705889E12B49A9C1B8B4ECF55A6FADFD568CF4CF07C9378534016D2C06E191DD8790E3E619E3EF6DE7FCE6B6ADFC4704D75142CB3432CEEC91ABA643E14B755C81C03D483C74ACAB2BD8752B38AE2DE58E782741245246DB96452321811C10451FF0031DD2BFEBE5BFF00444B5F5583C352C350861E8FC31492F45B1E2D5A92A93739EECE968A28AE92028A28A0028A28A00F36F1C7FC8DF73F45FF00D04573FA7F8374E8B5A4BEB76934BD4119992E21019771041DC84107827A63AD741E38FF0091BEEBE8BFFA0AD6613815F80E2F173C36695AB43A5493FF00C99FCFE6B53EDA9535530F08BFE55F9147E2A68FE2CFF8436F3FB174BF0C6A7AC655ADAE678328C372EF1247824EE50C3E53DC57CB7E30FDAB7C7DF07EF9FF00E137F84DA6ADB42706EF4E92E2DA26C851D9E454CE7037018C138AFB47C1374F2C53C6C4954C1507B673FE15ABA8E936DABC1E5DD5BC3709E92206C57E9147051CE3090C6AB7BCBE192525A36B7B7E69B7D4F1962D60EA3A128DEDD5369FE67C4DE15FF82827823C43B5AE740D7F4EDCB906CEF22BC8D4F4E8CA8C4743D739247BD77BA07ED4FF000EF598F736BD7BA593C04BED38F0DB8A6D26377E7233900803DEBB7F8A9FB01FC3DF89CF24FF00D99FD977CE1B135A1D9827A9DBF749271CB03D07A57C9FFB4E7EC417DFB39E8B6BABC5ACC77FA64B39B6E7104A0B6E7E5829CFCAAC09C75DA6BC4C5709E161AE26846DDD47957FE496B7CECCF4E86630AAF9694A49F6BDFF00F4AB9F707C13F8CDE19BAB76B5B1D734AD466BB9018A3867DB23601046D9029CE41C0EFD6BD2A3F1541F279D15CDB798E91A6F40D9663803E42D8E4819381CF5AFCCDFD88F5179FE3AF85E0924793FD2564E24DC33963F9735FA39A9FF00ABB7FF00AFBB7FFD1C95F6D9053851C22C3528DA3076566DF9F56DF53C2CDA9F2D6536EFCCAFAE9E5FA1D4D14515ED9E605145140051457CD3E34FF828DD9F87BC537D6361E169751B6B399A15B99350F20CA5490484F2DB03238E738EC2A65351DCE4C5E3A8619295795AFEBFA1ED3A1FFC94CF13FF00B967FF00A03D7435F2558FFC142FEC5E26D4F51FF844377F68AC2BE5FF006AE3CBF2D48EBE4F39CFA0AD1FF8794FFD497FF957FF00ED151EDA1DCE2FF58301FF003F3F097F91F52515F2DFFC3CA7FEA4BFFCABFF00F68A3FE1E53FF525FF00E55FFF00B451EDA1DC5FEB0603FE7E7E12FF0023EA4AE77E27FF00C8B36FFF00615D37FF004BA0A67C23F89D67F183C0565AF58C72C115D6E56864FBD13AB156527A1E4707B822B57C4FE1E8BC53A3BD9CD2CF02B491CAB242C0491BC722C88C0904643283C835AA77D51EBD3A919C54E0EE9936B5A2DAF88F4A9ECAF604B9B5B85D9246E3861FE3E87B1AE77C3BE21BAF87DAAC1A26B73C9736170C23D335494F2E7B5BCE7FE7A7F75BF8C0FEF759FF00E15FDDFF00D0D3E24FFBEADBFF008CD55D6BE12FFC245A5CD657DE22F105CDADC2EC923736C430FF00BF3FAF6A0B3BBA2B9BF8437535E7C36D25EE2696E65F27634B2B6E77DAC54127B9C01CD74940828A28A00FCADFF82E27FC9D8787BFEC52B6FF00D2CBDAF8D6BECAFF0082E27FC9D8787BFEC52B6FFD2CBDAF8D6BF07E25FF0091A56F53FD31F08BFE48ECBFFEBDAFCD8514515E19FA38515D3FC1FF0083FE20F8EDF102C3C35E1AB092FF0054BF7DAAABC244BFC523B745451C926BD83F6D3FF8276789FF00640B3D3F546B81E20F0EDDC71C736A36F0945B4B923E68DD79C2939D8DDC707078AECA780C454A12C4C20DC23BBFEBF1EC7818CE28CAB0B98D2CA3115E31AF55371837ABB7E57E97F8ACED7B33E78A29D144D3CAA88ACEEE42AAA8C9627A002BEA897FE0929F10E3FD9A478DB6E75FC7DA8F86FCA3F6A169B73BB3FF003DBBF958CE38CEEF968C2603118AE6F61072E55776FEBF01E77C4F9564EE92CCEBC697B5972C6EF77FA2EEDE8B4BBD4F9568A7491B45215605594E0823041A6D719EF051451401FAA3FF00043BFF00934FF10FFD8DB73FFA47655F65D7C69FF043BFF934FF0010FF00D8DB73FF00A47655F65D7EF3C37FF22CA3FE13FCCDF177FE4B1CC3FEBE3FC90514515ED9F9C9F9CBFF0006F27FC996F89FFEC76BAFFD21B0AFBCABE0DFF83793FE4CB7C4FF00F63B5D7FE90D857DE55F39C23FF226C3FF0084FD67C76FF92FF34FFAFAFF002414D9A64B685A49195234059998E0281D4934EAF29FDBA6DAF6F3F62FF8AB1E9DE67DB1BC29A9797E5FDE3FE8D21207B9191F8D7BB89ABECA94AADAFCA9BB7A23F36CA702B1B8EA38372E5552718DFB7334AFF2BDCDEF84FF00B4AFC3FF008EDA86A169E0DF18F877C4B75A59FF004A874FBD49DE119C06201CEDCF018707D6BB8AFCAEFD96F5FD0ACFFE0A71FB3EDAF812DECF4EB2B8F85B670EB89631AC42E647D3AE2E1BCF0BF79F3E4312DC9655C9E057EA8D7939066B3C7D19CEA2578C9C74D9E89E9F7DBE47DC789DC134386730A1430D293856A51AA94D2538DE5385A56D378732D366974B8573BF15FE13F87BE387C3FD4BC2FE2AD2EDB58D0F568BCAB8B69D783DC329EAACA7055810548041045745457B5384671709ABA7BA3F3DC3E26AE1EAC6BD0938CE2D34D3B34D6A9A6B54D3D99F9C7F07BC51E31FF8230FED3BA3F8035ED427F117C02F889A898B48D42E1BF79A14EEC012DD90A965F300C2BA9F314060CB5FA895F9C9FF00070D201FB19F85A4C7EF13C6B6A15BBAE6C6FC9C1FC07E55FA375F359141E1B1788CBA0DBA74F91C53FB2A69DE3E89AD3B5CFD77C49C4ACE324CAB8AB1104B1589F6F4EB4A2ACAA4A83A6A351A5A29CA33B4DAD1B57B6A1451457D39F8E0514514015B52FF00571FFD745A0B6293543FB94FFAE8B4DA6004E68A28A0029A3A7E34ADD28CE3F0A00C49A6D9A95F0FFA6ABFFA2D2A0FB6C9637226848122F041E8E3D0FF009E2B46EFC3B6D7B72D2BF9E1DF05B64EE80E001D01C7402A13E10B33FF003F5FF81327FF00154580DAD23578B58B5F323E08E1D0FDE43E86AD560689A443A478853C9F37F7B6F26FDF2B3E70D1E3A93EA7F3ADFA401451450014515F3E7FC1447FE0A07A37FC13E7E16E99AEDFE8975E24D4B5CBC367A7E9D0DC0B6594AAEF77794AB6C5518E8AC4961C63244CE6A2B9A5B1CD8CC651C2519623112E58477676BFB64FFC9B4F8ABFEB8C5FFA3E3AEEABF263E327FC1C45FF000B6FE1A6ABE1DFF853FF00D9FF00DA6889F68FF84AFCDF2F6BABFDDFB1AE7EEE3A8EB5BBFF00112B7FD516FF00CBBFFF00B8AB9BEBD43F9BF067CC7FAFF90FFCFF00FF00C967FF00C89FA95457E5AFFC44ADFF00545BFF002EFF00FEE2A3FE2256FF00AA2DFF00977FFF007151F5EA1FCDF8317FAFF90FFCFF00FF00C967FF00C89FA95457C21FB147FC172346FDACBE3D697E03D4FC0375E11BAD777C7A7DDC7AC0D4629265467D920F222280852011BB9C02075AFBBEB7A7561515E0CFA0CAF37C266349D7C1CF9A29DB66B5F46933CEFE0BFF00C94DF8BBFF006355BFFE98F4AAA9F15BE156ADA3F8B7FE13EF00F93078B608963D434E91FCBB4F14DB2F48263D166519F2A6EAA7E56CA1205AD73F67BFB7F8C759D674CF1A78CFC3726BF3C7757B6DA6CD69E449324115B89009ADE4604C70C60E1B1F2E71C9A8BFE19FB56FFA2A9F12BFEFEE9BFF00C875A1E91D9FC1EF8C3A4FC6AF090D534CF3E096095AD6FEC2E93CBBBD2EE57FD65BCF1F54753F81182090413D5D7CEBE1AF83CDF077F6BAF0CEA9078A3C4FAC5D78C74FBDB4D57FB424B6D974B6D1A3C2CCB0C3186742EC0336480700E38AFA2A81051451400515C87ED03E3CBAF859F017C6FE27B148E4BDF0E6817FAA5BA48328D2416F24AA1BDB2A335F85BAE7EDD5F1975CD56E2F26F8A9F102396E5CC8EB6FAF5CDBC4A4FF007638DD5107B280057D7F0CF07E233A84EA529A8A8B4B5BEAD9C989C5C68B49ABDCFE8068AFE7BDFF006D6F8C23FE6AC7C4BFFC29EF7FF8ED4127EDB3F18C7FCD59F899FF008545F7FF001DAFAAFF00884D8BFF009FF1FB99CBFDAB0FE53FA17AFCDEFF0082BCEAB3DCFED13A35BBB37D96DB438FCA07A0769E6DE47E013F215F01C9FB6E7C645FF9AB5F133FF0A8BEFF00E3B5CA78DBE3DF8DBE225EC773E20F18F8A75CB88576472EA1AB4F72E8BD700BB92057D2F0A700E2329CC238DA956324935649DF5473E271D1AB4F9123DEC36696BE79F06FC4ED5B4CF135A6FBFBAB886495639239A56752A4E0F53D79AF7FB0BAFB6401877AFD52FAD8F30F7BFF00826DEA571A6FED87E16F20B08E75BA8A703A321B690F3EDB82FE42BEE9FF0082897ED2D77FB287EC9BE25F16698233AD858EC74C2E32B1DC4CC116423A1D80B3E0F07660F5AF9F7FE096FF00B375F699E2697C67AADB3DB930986CA39170CA8D82CE476CE001ED9F5AF5FF00F82ADFC10D43E3E7EC77AEE8FA4A19753B6922D42D6207FD6BC4DBB67D597701EE457F3FF1566397E378A68FB469D2838466FA3B49B97C95ECFD19EEE1A9D48615DB77768FC2EF11F89350F186BD77AA6AB7B75A96A57F2B4F737573299669DD8E4B331C924FA9AE9FF67FF8F9E24FD9A7E2A697E2EF0B5FCB65A8E9D286640E445791646F86551F7A3603041F623040238FBAB596C2EA48678DE19A2629246EA5591870410790456BFC39F87BAB7C56F1AE9DE1FD12D64BCD4B53996186351D3279663D940E49EC057F45E26387786946BDBD9DB5BEDCB6D7CAD63E762E5CD78EE7F46FF0B7C7F69F15BE19F87BC4F60196CBC45A6DBEA702B75549A259141F7C30ADEAE3BF67CF028F85FF0003BC25E1B56322681A4DB69C8C7AB2C512C60FE4B5D8D7F13D7F67ED65ECBE1BBB7A743ED237B6BB851451590C2BCA75F8D66D6F50475574695D5958643024F0457AB57956B3FF0021FBEFFAECDFFA11AFCEBC44FE0D0FF13FC8F7722F8E7E9FA99965A3C5A3D82DB5AC4AB6A991E4750016C9C67B7278AC7D5FE13F87BC460C9F624B790FFCB4B6FDD91F80F97F315D19381599AA6A2D617;
                //Read Image File into Image object.
                Image img = Image.FromFile(@"C:\Enunciado.jpg");

                //ImageConverter Class convert Image object to Byte array.
                Aux_Imagen = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
#else
                pb_Captura.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Aux_Imagen = ms.ToArray();
#endif
            }

            //Guarda la evaluación
            NEvaluacion.Insertar(Lbl_IDReportes.Text,
                ccEvaluado.NumeroCedula.ToString(),
                DateTime.Now,
                Aux_Imagen,
                Properties.Settings.Default.DescripcionEval,
                Properties.Settings.Default.Ciudad,
                Configuracion_obj.numeroPreguntas,
                Calificador_obj.numCorrectas,
                Calificador_obj.numContestadas,
                Calificador_obj.PuntajeGlobal,
                new TimeSpan(0, Properties.Settings.Default.MinEval, Properties.Settings.Default.SegEval));

            //Guarda las respuestas del usuario
            Calificador_obj.almacenarRespuestasUsuario(Lbl_IDReportes.Text);
#if TEST
            float aux;
            aux = Calificador_obj.PuntajeAspectosGenerales;
            aux = Calificador_obj.PuntajeComportamientoPeaton;
            aux = Calificador_obj.PuntajeRegimenSancionatorio;
            aux = Calificador_obj.PuntajeSenalesTransito;
#endif
        }

        private void btn_SigCuestionario_Click(object sender, EventArgs e)
        {
            this.tabc_Contenedor.TabPages.Remove(tp_Cuestionario);
            this.tabc_Contenedor.TabPages.Add(tp_Resultado);
        }
        #endregion

        #region Tab Resultados
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            //Conectar impresora
            if (!BXLAPI.ConnectPrinter("BIXOLON SRP-330II"))
            {
                MessageBox.Show("No se pudo conectar con la impresora");
                return;
            }

            int nPositionX = 0;
            int nPositionY = 0;
            int nTextHeight = 0;

            // Start Document
            if (BXLAPI.Start_Doc(string.Format("Certificado {0} {1}", ccEvaluado.Nombres.Trim(), ccEvaluado.Apellidos.Trim())))
            {
                // Start Page
                BXLAPI.Start_Page();

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintDeviceFont(nPositionX, nPositionY, "FontA2x2", 14, "SISTEMA DE EVALUACION DE CONOCIMIENTOS");

                nPositionX = 110;
                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintBitmap(nPositionX, nPositionY, ".\\Resources\\LogoKirvitMapaBits.bmp");

                nPositionX = 0;
                nPositionY += nTextHeight + nTextHeight / 2;
                nTextHeight = BXLAPI.PrintDeviceFont(nPositionX, nPositionY, "FontA1x1", 10, Properties.Settings.Default.NombreCampaña.Trim());//, false, 0, true, false);

                nPositionX = 110;
                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 12, Properties.Settings.Default.Empresa.Trim().ToUpper(), true, 0, true, false);

                nPositionX = 10;
                nPositionY += nTextHeight + nTextHeight / 2;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, "DATOS DEL EVALUADO", false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, "Cédula: " + ccEvaluado.NumeroCedula.ToString(), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, "Nombres: " + ccEvaluado.Nombres.Trim(), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, "Apellidos: " + ccEvaluado.Apellidos.Trim(), false, 0, true, false);

                nPositionY += nTextHeight + nTextHeight / 2;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, "Código Evaluación: " + Lbl_IDReportes.Text, false, 0, true, false);

                nPositionX = 30;
                nPositionY += nTextHeight + nTextHeight / 2;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Ciudad: {0}", Properties.Settings.Default.Ciudad), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Fecha: {0:MM/dd/yy H:mm}", DateTime.Now), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Patrocinado por: {0}", Properties.Settings.Default.Patrocinador), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Aspectos Generales: {0:00}", Calificador_obj.PuntajeAspectosGenerales), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Normas de comportamiento: {0:00}", Calificador_obj.PuntajeComportamientoPeaton), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Señales de tránsito: {0:00}", Calificador_obj.PuntajeSenalesTransito), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Régimen sancionatorio: {0:00}", Calificador_obj.PuntajeRegimenSancionatorio), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Calificación final: {0:00}", lbl_Calificacion.Text.Trim()), false, 0, true, false);

                BXLAPI.End_Page();	// End Page
                BXLAPI.End_Doc();	// End Document      
            }
        }
        private void btn_nuevaPrueba_Click(object sender, EventArgs e)
        {
            this.Close();
            F.AbrirFormPreguntasConDelay();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FPreguntas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Pide confirmacion antes de cerrar el form
            DialogResult rta;
            rta = MessageBox.Show("¿Realmente desea salir del cuestionario?", "Atención", MessageBoxButtons.YesNo);
            if (rta == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //Pone visible el menúStrip
                F.VisibilidadMenuStrip(true);
            }
        }
        private void btn_VerReporte_Click(object sender, EventArgs e)
        {
            this.Close();
            F.Mostrar_FReporteEvaluacionesObj();
            F.FReporteEvaluacionesObj.Actual_Report(ccEvaluado.NumeroCedula.ToString());
        }
    }
}
