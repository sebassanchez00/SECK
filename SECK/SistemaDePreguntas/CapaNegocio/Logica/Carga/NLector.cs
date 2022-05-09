using CapaDatos;
using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica.Carga
{
    public abstract class NLector
    {
        #region Campos
        string ruta_;
        List<string> lPreguntasSinFormato_;
        List<Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>> lPreguntasTupla_; //Agrupa una pregunta con su tipo de licencia aplicable
        int numColumnas_;
        int posTipoLicencia_;
        int posTema_;
        char[] delimitador_;

        //Acceso a Datos
        DTema DTema_obj;
        DTipoLicencia DTipoLicencia_obj;
        DPregunta DPregunta_obj;
        DLicenciaAplicablePreguntas DLicenciaAplicablePreguntas_obj;
        #endregion

        #region Accesores
        protected string Path
        {
            get { return this.ruta_; }
            set { this.ruta_ = value; }
        }

        protected List<string> LPreguntasSinFormato
        {
            get { return this.lPreguntasSinFormato_; }
            set { this.lPreguntasSinFormato_ = value; }
        }

        protected List<Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>> LPreguntasTupla
        {
            get { return this.lPreguntasTupla_; }
            set { this.lPreguntasTupla_ = value; }
        }

        protected char[] Delimitador
        {
            get { return this.delimitador_; }
            set { this.delimitador_ = value; }
        }

        #endregion

        #region Constructor
        protected NLector(string Path, int NumeroColumnas, int PosicionTpoLicencia, int PosicionTema)
        {
            this.ruta_ = Path;
            this.lPreguntasSinFormato_ = new List<string>();
            this.lPreguntasTupla_ = new List<Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>>();
            this.numColumnas_ = NumeroColumnas;
            this.posTipoLicencia_ = PosicionTpoLicencia;
            this.posTema_ = PosicionTema;
            this.delimitador_ = new char[] { ';' };
            this.DTema_obj = new DTema();
            this.DTipoLicencia_obj = new DTipoLicencia();
            this.DPregunta_obj = new DPregunta();
            this.DLicenciaAplicablePreguntas_obj = new DLicenciaAplicablePreguntas();
        }
        #endregion

        #region Métodos

        protected void cargarPreguntasEnListaString()
        {
            //Nota: La existencia del archivo debe estar ya validada
            using (StreamReader SR = new StreamReader(this.ruta_, System.Text.Encoding.Default))
            {
                SR.ReadLine(); //Descarta la primera fila del archivo, la de los títulos
                while (!SR.EndOfStream)
                {
                    this.lPreguntasSinFormato_.Add(SR.ReadLine());
                }
            }
        }

        protected abstract void cargarPreguntasEnListaTupla();

        protected void cargarPreguntasEnBD()
        {
            foreach (var p in this.LPreguntasTupla)
            {
                short idInsertada = DPregunta_obj.Insertar(p.Item1); //Inserta pregunta y opciones
                p.Item2.ID_Pregunta = idInsertada;
                DLicenciaAplicablePreguntas_obj.Insertar(p.Item2); //Inserta LicenciaAplicablePpregunta
            }
        }

        protected void validarColumnasEIDs()
        {
            int i = 0;
            foreach (string item in this.lPreguntasSinFormato_)
            {
                string[] registro = item.Split(this.delimitador_, StringSplitOptions.RemoveEmptyEntries);

                //Validación número de columnas
                int l = registro.Length;
                if (l != this.numColumnas_)
                {
                    String mensaje = $"El registro con índice {i.ToString()} tiene(n) {l.ToString()} columna(s), se esperaba(n) {this.numColumnas_.ToString()} columna(s). Asegurese que el archivo .csv está separado por ';' entre registros";
                    throw new Exception(mensaje);
                }

                //Valida que ID_Tema del .CSV es numérico 
                short IDTemaEnCSV;
                if (!Int16.TryParse(registro[this.posTema_], out IDTemaEnCSV))
                {
                    String mensaje = $"El registro con índice {i.ToString()} tiene un ID_TEMA no numérico";
                    throw new Exception(mensaje);
                }

                //Valida que ID_Tema exista en BD. 
                if (DTema_obj.MostrarPorID(IDTemaEnCSV) == null)  //(*) Validar que si haga la comparación para null
                {
                    String mensaje = $"El registro con índice {i.ToString()} tiene un ID_TEMA que no existe en base de datos";
                    throw new Exception(mensaje);
                }

                //Valida que ID_TipoLicencia del .CSV es numérico 
                short IDTipoLicenciaEnCSV;
                if (!Int16.TryParse(registro[this.posTipoLicencia_], out IDTipoLicenciaEnCSV))
                {
                    String mensaje = $"El registro con índice {i.ToString()} tiene un ID_TIPO_LICENCIA_APLICABLE que no es numérico";
                    throw new Exception(mensaje);
                }

                //Valida que ID_TipoLicencia exista en BD. 
                if (DTipoLicencia_obj.MostrarPorID(IDTipoLicenciaEnCSV) == null)  //(*) Validar que si haga la comparación para null
                {
                    String mensaje = $"El registro con índice {i.ToString()} tiene un ID_TIPO_LICENCIA_APLICABLE que no existe en base de datos";
                    throw new Exception(mensaje);
                }

                i++;
            }
        }

        protected abstract void validarOpciones();

        void validarUnaSolaRespuesta()
        {
            int contadorOpcionesCorrectas = 0;
            int indicePregunta = 0;
            foreach (var l in this.lPreguntasTupla_) //Recorre cada pregunta
            {
                VoPreguntaYOpciones preguntaRecuperada = l.Item1;

                foreach (var m in preguntaRecuperada.Opciones) //Recorre cada opción
                {
                    if (m.Es_Correcta)
                        contadorOpcionesCorrectas++;
                }

                if (contadorOpcionesCorrectas != 1)
                {
                    String mensaje = $"El registro con índice {indicePregunta.ToString()} tiene 0 o más respuestas correctas";
                    throw new Exception(mensaje);
                }

                contadorOpcionesCorrectas = 0;
                indicePregunta++;
            }
        }

        public void Leer()
        {
            cargarPreguntasEnListaString(); //Primero se carga en esta lista de strings para hacer más fácil la validación
            validarColumnasEIDs();          //Valida que los ID existan y sean válidos. También que el registro leído tenga datos suficientes.
            validarOpciones();              //Valida que existan opciones y que tengan formato correcto. Se delega a los hijos
            cargarPreguntasEnListaTupla();  //Se carga una lista de tuplas. Así se hace más fácil cargar en BD y hacer otras validaciones. Se delega a los hijos
            validarUnaSolaRespuesta();      //Valida que solo se tenga una respuesta.
            validarOpciones();              //Valida que las opciones sean válidas
            cargarPreguntasEnBD();          //Finalmente guarda en la base de datos
        }

        #endregion
    }
}
