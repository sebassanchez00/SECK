using CapaDatos.Vo;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica
{
    /// <summary>
    /// Representa clase que califica un cuestionario
    /// </summary>
    public class NModeloCalificador
    {
        List<ModeloRespuesta> L_Respuestas;
        int numContestadas_;
        int numCorrectas_;
        int numIncorrectas_;
        int numTotalPreguntas_;
        float puntaje_;

        public int numContestadas
        {
            get { return numContestadas_; }
        }
        public int numCorrectas
        {
            get
            {
                calcularRespuestasCorrectas();
                return numCorrectas_;
            }
        }
        public int numIncorrectas
        {
            get
            {
                numIncorrectas_ = this.numContestadas_ - this.numCorrectas;
                return numIncorrectas_;
            }
        }
        public int numTotalPreguntas
        {
            get { return numTotalPreguntas_; }
        }
        public float Puntaje
        {
            get
            {
                calcularPuntaje();
                return puntaje_;
            }
        }

        //Acceso a datos
        DOpcionesRespuesta DOpcionesRespuesta_obj;
        DPregunta DPregunta_obj;
        DRegistroPreguntas DRegistroPreguntas_obj;
        DORegistroOpcionesPreguntas ORegistroOpcionesPreguntas_obj;

        public NModeloCalificador()
        {
            L_Respuestas = new List<ModeloRespuesta>();
            DOpcionesRespuesta_obj = new DOpcionesRespuesta();
            DPregunta_obj = new DPregunta();
            DRegistroPreguntas_obj = new DRegistroPreguntas();
            ORegistroOpcionesPreguntas_obj = new DORegistroOpcionesPreguntas();
            this.numContestadas_ = 0;
            this.numCorrectas_ = 0;
            this.numTotalPreguntas_ = 0;
            this.puntaje_ = 0.0F;
        }

        /// <summary>
        /// Agrega el texto de la respuesta en la lista
        /// </summary>
        /// <param name="Indice">ID de la pregunta a la cual se le añade respuesta</param>
        /// <param name="respuesta"></param>
        public void agregarRespuesta(short Indice, string respuesta)
        {
            //short auxID = L_Respuestas[Indice].IdDePregunta;
            //ModeloRespuesta auxMR = L_Respuestas.Find(rta => rta.IdDePregunta == auxID);
            ModeloRespuesta auxMR = L_Respuestas[Indice];
            auxMR.respuestaEscogida = respuesta;
            this.numContestadas_++;
        }

        /// <summary>
        /// Crea lista de respuestas desde una lista de VoPregunta
        /// </summary>
        /// <param name="Lista">Lista que contiene las VoPreguntas</param>
        public void alimentarDesdeListaVoPregunta(List<VoPregunta> Lista)
        {
            foreach (VoPregunta p in Lista)
            {
                string auxRtaCorrecta = DOpcionesRespuesta_obj.MostrarOpcionCorrecta(p.Id);
                this.L_Respuestas.Add(
                    new ModeloRespuesta()
                    {
                        IdDePregunta = p.Id,
                        respuestaCorrecta = auxRtaCorrecta,
                        respuestaEscogida = string.Empty,
                        EsCorrecta = false
                    }
                    );
            }
            this.numTotalPreguntas_ = L_Respuestas.Count;
        }

        /// <summary>
        /// Retorna el número de preguntas que se respondieron
        /// </summary>
        /// <returns></returns>
        public int numeroPreguntasContestadas()
        {
            this.numContestadas_ = 0;
            foreach (ModeloRespuesta r in L_Respuestas)
            {
                if (r.respuestaEscogida != string.Empty)
                    this.numContestadas_++;
            }
            return this.numContestadas_;
        }

        /// <summary>
        /// Califica las respuestas
        /// </summary>
        void calcularRespuestasCorrectas()
        {
            //Calcula las respuestas correctas
            this.numCorrectas_ = 0;
            foreach (ModeloRespuesta m in L_Respuestas)
            {
                if (m.respuestaCorrecta == m.respuestaEscogida)
                {
                    m.EsCorrecta = true;
                    this.numCorrectas_++;
                }
                else
                {
                    m.EsCorrecta = false;
                }
            }
        }

        /// <summary>
        /// Calula el puntaje según respuestas dadas.
        /// </summary>
        /// <returns></returns>
        public double calcularPuntaje()
        {
            calcularRespuestasCorrectas();
            this.puntaje_ = (this.numCorrectas_ * 10) / (this.numTotalPreguntas_);
            return puntaje_;
        }

        /// <summary>
        /// Almacena las respuestas de usuairo incluyendo los encunciados y el puntaje
        /// </summary>
        /// <param name="IdEvaluacion">El ID que debe tener el registro de respuestas</param>
        public void almacenarRespuestasUsuario(string IdEvaluacion)
        {
            for (int m = 0; m < this.numContestadas_; m++)
            {
                short auxID = L_Respuestas[m].IdDePregunta;                                                //ID de la pregunta
                object[] Pregunta = DPregunta_obj.LlevarIdPregunta(auxID);                                 //Lee pregunta con el ID desde BD
                ModeloRespuesta Respuesta = this.L_Respuestas[m];                                          //Recupera la respuesta del usuario

                int id_Cuestionario = DRegistroPreguntas_obj.Insertar(new VoRegistroPreguntas()
                {
                    id_Evaluacion = IdEvaluacion,
                    pregunta = (string)Pregunta[3],
                    respuestaDelUsuario = Respuesta.respuestaEscogida,
                    respondioCorrectamente = Respuesta.EsCorrecta,
                    imagen = (byte[])Pregunta[4]
                }
                    );

                //Guarda las opciones que tuvo el usuario                                
                DataTable auxdt = DOpcionesRespuesta_obj.MostrarPorID(auxID);
                foreach (DataRow dr in auxdt.Rows)
                {
                    string Aux_Enunc_Opcion = dr["Enunciado"].ToString();
                    bool Aux_Es_Correcta = (bool)dr["Es_Correcta"];
                    NORegistroOpcionesPreguntas.Insertar(id_Cuestionario, Aux_Enunc_Opcion, Aux_Es_Correcta);
                }
            }
        }

        public class ModeloRespuesta
        {
            public short IdDePregunta { get; set; }
            public string respuestaCorrecta { get; set; }
            public string respuestaEscogida { get; set; }
            public bool EsCorrecta { get; set; }
        }
    }
}
