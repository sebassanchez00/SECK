using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NOpcionesRespuesta
    {
        /// <summary>
        /// Trae las opciones de la pregunta desde la tabla TME_OPCION_RESPUESTA
        /// </summary>
        /// <param name="ID">ID de la pregunta</param>
        /// <returns></returns>
        public static DataTable MostrarporId(short ID)
        {
            return new DOpcionesRespuesta().MostrarPorID(ID);
        }

        /// <summary>
        /// Consulta la respuesta de la pregunta que se consulta
        /// </summary>
        /// <param name="ID_Pregunta"></param>
        /// <returns></returns>
        public static string MostrarOpcionCorrecta(short ID_Pregunta)
        {
            DOpcionesRespuesta obj = new DOpcionesRespuesta();
            return obj.MostrarOpcionCorrecta(ID_Pregunta);
        }
    }
}

