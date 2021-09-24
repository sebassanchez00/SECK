using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEvaluacion
    {
        /// <summary>
        /// Inserta un registro en tabla TME_EVALUACION
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ID_Conductor"></param>
        /// <param name="Fecha_Hora_Prueba"></param>
        /// <param name="Descripcion_Evaluacion"></param>
        /// <param name="ID_Ciudad"></param>
        /// <returns></returns>
        public static string Insertar(string ID, string ID_Conductor, DateTime Fecha_Hora_Prueba, byte[] Foto, string Descripcion_Evaluacion, string ID_Ciudad, int numPreguntas, int NumCorrectas, int NumContestadas, float Puntaje, TimeSpan TiempoPrueba)
        {
            DEvaluacion obj = new DEvaluacion();
            obj.ID = ID;
            obj.ID_Conductor = ID_Conductor;
            obj.Fecha_Hora_Prueba = Fecha_Hora_Prueba;
            obj.Foto = Foto;
            obj.Descripcion_Evaluacion = Descripcion_Evaluacion;
            obj.ID_Ciudad = ID_Ciudad;
            obj.Num_Preguntas = numPreguntas;
            obj.Num_Correctas = NumCorrectas;
            obj.Num_Contestadas = NumContestadas;
            obj.Puntaje = Puntaje;
            obj.Tiempo_Prueba = TiempoPrueba;

            return obj.Insertar(obj);
        }

        /// <summary>
        /// Muestra cantidad de evaluaciones que tienen un conductor
        /// </summary>
        /// <param name="ID_Conductor"></param>
        /// <returns></returns>
        public static int BuscarEvaluaciones(string ID_Conductor)
        {
            DEvaluacion obj = new DEvaluacion();
            return obj.BuscarEvaluaciones(ID_Conductor);
        }

        /// <summary>
        /// Trae los registros desde TME_EVALUACION en un datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable Mostrar()
        {
            return new DEvaluacion().Mostrar();
        }

        /// <summary>
        /// Muestra todas las evaluaciones que tienen un conductor
        /// </summary>
        /// <param name="ID_Conductor"></param>
        /// <returns></returns>
        public static DataTable MostrarPorIDConductor(string ID_Conductor)
        {
            return new DEvaluacion().MostrarPorIDConductor(ID_Conductor);
        }

        /// <summary>
        /// Muestra la evaluaciones segun el ID
        /// </summary>
        /// <param name="ID_Conductor"></param>
        /// <returns></returns>
        public static DataTable MostrarPorIDEval(string IDEval)
        {
            return new DEvaluacion().MostrarPorIDEval(IDEval);
        }
    }
}
