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
        ArrayList AL_Respuestas_Usuario;
        ArrayList AL_Respuesta_Correcta;
        Cedula ccEvaluado;
        int NumPreguntasConfiguradas;

        TimeSpan TSpanTime;
        Timer timer = new Timer();

        FPrincipal F;
        SpeechSynthesizer _synthesizer;

        public FPreguntas()
        {
            InitializeComponent();
            AL_Respuestas_Usuario = new ArrayList();
            AL_Respuesta_Correcta = new ArrayList();
            ccEvaluado = new Cedula();
        }

        private void FPreguntas_Load(object sender, EventArgs e)
        {
            NumPreguntasConfiguradas = Properties.Settings.Default.NumPreguntas;
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
            NumPreguntasConfiguradas.ToString(),
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

                if (iPregunta + 1 == NumPreguntasConfiguradas)
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
                Cuestionario_obj = new NModeloCuestionario();
                Calificador_obj = new NModeloCalificador();
                //Al tiempo de crear el cuestionario, crea el calificador con la misma lista
                Calificador_obj.alimentarDesdeListaVoPregunta(Cuestionario_obj.L_TodasLasPreguntasAleatorias);
            }
            catch(Exception ex)
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
                    data = Cuestionario_obj.ImagenPreguntaDesdeIndice(auxID);  // Carga imagen desde BD al PictureBox
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
            lbl_ProgresoTest.Text = string.Format("{0:00}/{1:00}", indice + 1, NumPreguntasConfiguradas);
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
                        Calificador_obj.agregarRespuesta((short)iPregunta,auxRB.Text);
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
            lbl_Calificacion.Text = string.Format("{0:00}/10 ", Calificador_obj.Puntaje.ToString());
            lbl_campana.Text = Properties.Settings.Default.NombreCampaña;
            lbl_nombres.Text = ccEvaluado.Nombres;
            lbl_apellidos.Text = ccEvaluado.Apellidos;
            lbl_codEval.Text = Lbl_IDReportes.Text;

            byte[] Aux_Imagen;
            using (MemoryStream ms = new MemoryStream())
            {
#if TEST
                Aux_Imagen = null;
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
                NumPreguntasConfiguradas,
                Calificador_obj.numCorrectas,
                Calificador_obj.numContestadas,
                Calificador_obj.Puntaje, 
                new TimeSpan(0, Properties.Settings.Default.MinEval, Properties.Settings.Default.SegEval));

            //Guarda las respuestas del usuario
            Calificador_obj.almacenarRespuestasUsuario(Lbl_IDReportes.Text);
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

                //nPositionY += nTextHeight + nTextHeight;
                //nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 15, "****************************************", false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("El puntaje de su prueba es: {0:00}", lbl_Calificacion.Text.Trim()), false, 0, true, false);

                nPositionX = 30;
                nPositionY += nTextHeight + nTextHeight / 2;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Ciudad: {0}", Properties.Settings.Default.Ciudad), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Fecha: {0:MM/dd/yy H:mm}", DateTime.Now), false, 0, true, false);

                nPositionY += nTextHeight;
                nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 10, string.Format("Patrocinado por: {0}", Properties.Settings.Default.Patrocinador), false, 0, true, false);

                //nPositionY += nTextHeight;
                //nTextHeight = BXLAPI.PrintTrueFont(nPositionX, nPositionY, "Arial", 15, "****************************************", false, 0, true, false);

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
