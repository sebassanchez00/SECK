﻿using CapaDatos;
using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica.Carga
{
    public abstract class Lector
    {
        string path_;
        List<string> lPreguntasSinFormato_;
        List<Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>> lPreguntasTupla_; //Agrupa una pregunta con su tipo de licencia aplicable
        int numColumnas_;
        int posTipoLicencia_;
        int posTema_;
        char[] delimitador_;

        //Acceso a Datos
        DTema DTema_obj;
        DTipoLicencia DTipoLicencia_obj;

        #region Accesores
        protected string Path
        {
            get { return this.path_; }
            set { this.path_ = value; }
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

        protected Lector(string Path, int NumeroColumnas, int PosicionTpoLicencia, int PosicionTema)
        {
            this.path_ = Path;
            this.lPreguntasSinFormato_ = new List<string>();
            this.lPreguntasTupla_ = new List<Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>>();
            this.numColumnas_ = NumeroColumnas;
            this.posTipoLicencia_ = PosicionTpoLicencia;
            this.posTema_ = PosicionTema;
            this.delimitador_ = new char[] { ';' };
            this.DTema_obj = new DTema();
            this.DTipoLicencia_obj = new DTipoLicencia();

            cargarPreguntasEnListaString(); //Primero se carga en esta lista de strings para hacer más fácil la validación
            validarColumnasEIDs();
            validarExistenOpciones();
            cargarPreguntasEnListaTupla(); //Se carga una lista de tuplas. Así se hace más fácil cargar en BD y hacer otras validaciones
            validarUnaSolaRespuesta();
        }

        protected void cargarPreguntasEnListaString()
        {
            using (StreamReader SR = new StreamReader(this.path_, System.Text.Encoding.Default))
            {
                while (!SR.EndOfStream)
                {
                    this.lPreguntasSinFormato_.Add(SR.ReadLine());
                }
            }
        }

        protected abstract void cargarPreguntasEnListaTupla();

        protected abstract void cargarPreguntasEnBD();

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

        protected abstract void validarExistenOpciones();

        void validarUnaSolaRespuesta()
        {
            int contadorOpcionesCorrectas = 0;
            int indicePregunta = 0;
            foreach(var l in this.lPreguntasTupla_) //Recorre cada pregunta
            {
                VoPreguntaYOpciones preguntaRecuperada = l.Item1;
                
                foreach(var m in preguntaRecuperada.Opciones) //Recorre cada opción
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
    }
}
