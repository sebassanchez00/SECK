using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NPregunta
    {
        /// <summary>
        /// Inserta pregunta en tabla TME_Pregunta. 
        /// </summary>
        /// <param name="id_Tipo_Pregunta"></param>
        /// <param name="Enunciado"></param>
        /// <param name="opcion1"></param>
        /// <param name="opcion2"></param>
        /// <param name="opcion3"></param>
        /// <param name="opcion4"></param>
        /// <param name="opcion5"></param>
        /// <param name="enunciado"></param>
        /// <returns></returns>
        public static string Insertar(int tema, int id_Tipo_Pregunta, string Enunciado, byte[] imagen, string opcion1, bool EsCorrecta1, string opcion2, bool EsCorrecta2, string opcion3, bool EsCorrecta3, string opcion4, bool EsCorrecta4)
        {
            DPregunta Obj = new DPregunta();
            Obj.Tema = tema;
            Obj.Id_TipoPregunta = id_Tipo_Pregunta;
            Obj.Enunciado = Enunciado;
            Obj.Imagen = imagen;
            Obj.Opcion1 = opcion1;
            Obj.EsCorrectaOp1 = EsCorrecta1;
            Obj.Opcion2 = opcion2;
            Obj.EsCorrectaOp2 = EsCorrecta2;
            Obj.Opcion3 = opcion3;
            Obj.EsCorrectaOp3 = EsCorrecta3;
            Obj.Opcion4 = opcion4;
            Obj.EsCorrectaOp4 = EsCorrecta4;
            return Obj.Insertar(Obj);
        }

        /// <summary>
        /// Actualizar registro de la tabla PREGUNTAS
        /// </summary>
        /// <param name="idpregunta"></param>
        /// <param name="id_Tipo_Pregunta"></param>
        /// <param name="respuesta"></param>
        /// <param name="opcion1"></param>
        /// <param name="opcion2"></param>
        /// <param name="opcion3"></param>
        /// <param name="opcion4"></param>
        /// <param name="opcion5"></param>
        /// <param name="enunciado"></param>
        /// <returns></returns>
        public static string Editar(int idpregunta, int id_Tipo_Pregunta, string respuesta, string opcion1, string opcion2, string opcion3, string opcion4, string opcion5, string enunciado)
        {
            DPregunta Obj = new DPregunta();
            Obj.Id_Pregunta = idpregunta;
            Obj.Id_TipoPregunta = id_Tipo_Pregunta;
            Obj.Opcion1 = opcion1;
            Obj.Opcion2 = opcion2;
            Obj.Opcion3 = opcion3;
            Obj.Opcion4 = opcion4;
            Obj.Enunciado = enunciado;
            //Obj.Respuesta = respuesta;
            return Obj.Editar(Obj);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPregunta Obj = new DPregunta();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        /// <summary>
        /// Elimina pregunta de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <param name="idpregunta"></param>
        /// <returns></returns>
        public static string EliminarSelMulPorID(short idpregunta)
        {
            DPregunta Obj = new DPregunta();
            return Obj.EliminarSelMulPorID(idpregunta);
        }

        /// <summary>
        /// Elimina preguntas abierta numerica de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <returns></returns>
        public static string EliminarAbNum()
        {
            return new DPregunta().EliminarAbNum();
        }

        /// <summary>
        /// Elimina preguntas seleccion múltiple de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <returns></returns>
        public static string EliminarSelMul()
        {
            return new DPregunta().EliminarSelMul();
        }

        /// <summary>
        /// Elimina preguntas selección múltiple con imagne de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <returns></returns>
        public static string EliminarSelMulImg()
        {
            return new DPregunta().EliminarSelMulImg();
        }

        /// <summary>
        /// Elimina preguntas verdadero falso de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <returns></returns>
        public static string EliminarVF()
        {
            return new DPregunta().EliminarVF();
        }

        /// <summary>
        /// Trae las preguntas de selección múltiple de la tabla TME_PREGUNTAS con FK formateadas.
        /// </summary>
        /// <returns></returns>
        public static DataTable MostrarSelMul()
        {
            return new DPregunta().MostrarSelMul();
        }

        /// <summary>
        /// Selecciona preguntas de tabla TME_PREGUNTAS
        /// </summary>
        /// <returns></returns>
        public static ArrayList LlevarPreguntasPorTema(short ID_TEMA)
        {
            DPregunta Obj = new DPregunta();
            return Obj.LlevarPreguntasPorTema(ID_TEMA);
        }

        /// <summary>
        /// Selecciona pregunta por ID desde tabla TME_PREGUNTAS. Tienen sus FK formateadas
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static ArrayList LLevarIdPreguntas(int ID)
        {
            DPregunta Obj = new DPregunta();
            Obj.Id_Pregunta = ID;
            return Obj.LlevarIdPregunta(Obj);
        }

        /// <summary>
        /// Selecciona todas las preguntas TME_PREGUNTAS
        /// </summary>
        /// <returns></returns>
        public static ArrayList LLevarPreguntasEvaluacion()
        {
            return new DPregunta().LlevarPreguntasEvaluacion();
        }
    }
}

