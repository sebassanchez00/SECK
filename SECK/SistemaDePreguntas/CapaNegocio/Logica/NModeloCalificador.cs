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
        float puntajeGlobal_;
        float puntajeAspectosGenerales_;
        float puntajeComportamientoPeaton_;
        float puntajeSenalesTransito_;
        float puntajeRegimenSancionatorio_;

        List<VoPregunta> L_PreguntasAspectosGenerales;
        List<VoPregunta> L_PreguntasComportamientoPeaton;
        List<VoPregunta> L_PreguntasSeñalesTransito;
        List<VoPregunta> L_PreguntasTemaRegimenSancionatorio;

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
        public float PuntajeGlobal
        {
            get
            {
                this.puntajeGlobal_ = calcularPuntajeGlobal();
                return this.puntajeGlobal_;
            }
        }
        public float PuntajeAspectosGenerales
        {
            get
            {
                this.puntajeAspectosGenerales_ = calcularPuntajePorTema(Tema.Aspectos_Generales);
                return this.puntajeAspectosGenerales_;
            }
        }
        public float PuntajeComportamientoPeaton
        {
            get
            {
                this.puntajeComportamientoPeaton_ = calcularPuntajePorTema(Tema.Comportamiento_Peaton);
                return this.puntajeComportamientoPeaton_;
            }
        }
        public float PuntajeSenalesTransito
        {
            get
            {
                this.puntajeSenalesTransito_ = calcularPuntajePorTema(Tema.Senales_Transito);
                return this.puntajeSenalesTransito_;
            }
        }
        public float PuntajeRegimenSancionatorio
        {
            get
            {
                this.puntajeRegimenSancionatorio_ = calcularPuntajePorTema(Tema.Regimen_Sancionatorio);
                return puntajeRegimenSancionatorio_;
            }
        }

        //Acceso a datos
        DOpcionesRespuesta DOpcionesRespuesta_obj;
        DORegistroOpcionesPreguntas ORegistroOpcionesPreguntas_obj;
        DPregunta DPregunta_obj;
        DRegistroPreguntas DRegistroPreguntas_obj;
        DResultadoPorTema DResultadoPorTema_obj;
        DTema DTema_obj;

        public NModeloCalificador()
        {
            L_Respuestas = new List<ModeloRespuesta>();
            DOpcionesRespuesta_obj = new DOpcionesRespuesta();
            ORegistroOpcionesPreguntas_obj = new DORegistroOpcionesPreguntas();
            DPregunta_obj = new DPregunta();
            DRegistroPreguntas_obj = new DRegistroPreguntas();
            DResultadoPorTema_obj = new DResultadoPorTema();
            DTema_obj = new DTema();

            this.numContestadas_ = 0;
            this.numCorrectas_ = 0;
            this.numTotalPreguntas_ = 0;
            this.puntajeGlobal_ = 0.0F;
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
                        IDTema = p.Id_Tema,
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
        public float calcularPuntajeGlobal()
        {
            calcularRespuestasCorrectas();
            float res = (this.numCorrectas_ * 10) / (this.numTotalPreguntas_);
            return res;
        }

        public float calcularPuntajePorTema(Tema ID_Tema)
        {
            var L_AG = L_Respuestas.Where(x => x.IDTema == (short)ID_Tema).ToList();
            int i = 0;
            int puntos = 0;

            foreach (ModeloRespuesta MR in L_AG)
            {
                i++;
                if (MR.EsCorrecta)
                { puntos++; }
            }

            i = i == 0 ? 1 : i;
            float res = (puntos / i) * 10;
            return res;
        }

        /// <summary>
        /// Almacena las respuestas de usuario en BD incluyendo los enunciados y el puntaje
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
                    Id_Evaluacion = IdEvaluacion,
                    Pregunta = (string)Pregunta[3],
                    RespuestaDelUsuario = Respuesta.respuestaEscogida,
                    RespondioCorrectamente = Respuesta.EsCorrecta,
                    Imagen = (byte[])Pregunta[4]
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

            alamcenaResultadosPorTema(IdEvaluacion);
        }

        /// <summary>
        /// Almacena los puntajes que se tuvieron en la prueba por cada tema evaluado. Toma los resultados desde los campos de la clase.
        /// </summary>
        public void alamcenaResultadosPorTema(string IdEvaluacion)
        {
            VoTema Vo_Aspectos_Generales = DTema_obj.MostrarPorID((short)Tema.Aspectos_Generales);
            VoTema Vo_Comportamiento_Peaton = DTema_obj.MostrarPorID((short)Tema.Comportamiento_Peaton);
            VoTema Vo_Regimen_Sancionatorio = DTema_obj.MostrarPorID((short)Tema.Regimen_Sancionatorio);
            VoTema Vo_Senales_Transito = DTema_obj.MostrarPorID((short)Tema.Senales_Transito);

            DResultadoPorTema_obj.Insertar(
                new VoResultadoPorTema
                {
                    ID_Evaluacion = IdEvaluacion,
                    ID_Tema = Vo_Aspectos_Generales.Id,
                    Enunciado_Tema = Vo_Aspectos_Generales.Enunciado,
                    Puntaje = this.PuntajeAspectosGenerales
                });

            DResultadoPorTema_obj.Insertar(
                new VoResultadoPorTema
                {
                    ID_Evaluacion = IdEvaluacion,
                    ID_Tema = Vo_Comportamiento_Peaton.Id,
                    Enunciado_Tema = Vo_Comportamiento_Peaton.Enunciado,
                    Puntaje = this.PuntajeComportamientoPeaton
                });

            DResultadoPorTema_obj.Insertar(
                new VoResultadoPorTema
                {
                    ID_Evaluacion = IdEvaluacion,
                    ID_Tema = Vo_Regimen_Sancionatorio.Id,
                    Enunciado_Tema = Vo_Regimen_Sancionatorio.Enunciado,
                    Puntaje = this.PuntajeRegimenSancionatorio
                });

            DResultadoPorTema_obj.Insertar(
                new VoResultadoPorTema
                {
                    ID_Evaluacion = IdEvaluacion,
                    ID_Tema = Vo_Senales_Transito.Id,
                    Enunciado_Tema = Vo_Senales_Transito.Enunciado,
                    Puntaje = this.PuntajeSenalesTransito
                });
        }

        /// <summary>
        /// Clase auxiliar con informacion de la respuesta
        /// </summary>
        public class ModeloRespuesta
        {
            public short IdDePregunta { get; set; }
            public short IDTema { get; set; }
            public string respuestaCorrecta { get; set; }
            public string respuestaEscogida { get; set; }
            public bool EsCorrecta { get; set; }
        }

        public enum Tema
        {
            Aspectos_Generales = 1,
            Regimen_Sancionatorio = 2,
            Comportamiento_Peaton = 3,
            Senales_Transito = 4
        }
    }
}
