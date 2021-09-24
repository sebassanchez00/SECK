using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NResultadoFinal
    {
        /// <summary>
        /// Inserta regitro en tabal RESULTADO_FINAL
        /// </summary>
        /// <param name="idresultado"></param>
        /// <param name="idreporte"></param>
        /// <param name="cantidadpreguntas"></param>
        /// <param name="respuestasfallidas"></param>
        /// <param name="preguntasrespondidas"></param>
        /// <param name="respuestascorrectas"></param>
        /// <param name="cedula"></param>
        /// <param name="calificacion"></param>
        /// <returns></returns>
        public static string Insertar(string idresultado, string idreporte, int cantidadpreguntas, int respuestasfallidas, int preguntasrespondidas, int respuestascorrectas, string cedula, int calificacion)
        {
            DResultadoFinal Objs = new DResultadoFinal();
            Objs.IdResultado = idresultado;
            Objs.IdReporte = idreporte;
            Objs.CantidadPreguntas = cantidadpreguntas;
            Objs.RespuestasFallidas = respuestasfallidas;
            Objs.PreguntasRespondidas = preguntasrespondidas;
            Objs.RespuestasCorrectas = respuestascorrectas;
            Objs.Cedula = cedula;
            Objs.Calificacion = calificacion;
            return Objs.Insertar(Objs);
        }

        public static DataTable BuscarReportesPorId(string textobuscar)
        {
            DResultadoFinal Objs = new DResultadoFinal();
            Objs.Cedula = textobuscar;
            return Objs.BuscarReportes(Objs);
        }
    }
}
