using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NReportePreguntaYOpciones
    {
        /// <summary>
        /// Devuelve los registros  de opciones de respuesta y la pregunta desde las tablas TR_PREGUNTAS y TR_OPCIONES_RESPUESTA para una evaluación.
        /// </summary>
        /// <param name="IDEvaluacion"></param>
        /// <returns></returns>
        public static DataTable Mostrar(string IDEvaluacion)
        {
            return new DReportePreguntaYOpciones().Mostrar(IDEvaluacion);
        }
    }
}