using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NRegistroPreguntas
    {
        /// <summary>
        /// Inserta un registro en tabla TME_CUESTIONARIO
        /// </summary>
        /// <param name="ID_Evaluacion"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Respuesta_Del_Usuario"></param>
        /// <returns></returns>
        public static int Insertar(string ID_Evaluacion, string Pregunta, string Respuesta_Del_Usuario, bool Respondio_Correctamente, byte[] Imagen)
        {
            DRegistroPreguntas obj = new DRegistroPreguntas();
            obj.ID_Evaluacion = ID_Evaluacion;
            obj.Pregunta = Pregunta;
            obj.Respuesta_Del_Usuario = Respuesta_Del_Usuario;
            obj.Respondio_Correctamente = Respondio_Correctamente;
            obj.Imagen = Imagen;
            return obj.Insertar(obj);
        }

        /// <summary>
        /// Devuleve en un DataTable todas las preguntas y respuestas de una evaluación
        /// </summary>
        /// <param name="ID_Evaluacion"></param>
        public static DataTable Mostrar_Por_ID_Evaluacion(string ID_Evaluacion)
        {
            return new DRegistroPreguntas().Mostrar_Por_ID_Evaluacion(ID_Evaluacion);
        }
    }
}
