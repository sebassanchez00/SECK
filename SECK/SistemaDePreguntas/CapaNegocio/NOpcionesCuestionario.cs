using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NORegistroOpcionesPreguntas
    {
        /// <summary>
        /// Inserta una opcion respuesta de la evaluacion que se creó y retorna el id de la fila insertada
        /// </summary>
        /// <param name="ID_Pregunta"></param>
        /// <returns></returns>
        public static int Insertar(int ID_Cuestionario, string Texto_Opcion, bool Es_Correcta)
        {
            DORegistroOpcionesPreguntas obj = new DORegistroOpcionesPreguntas();
            obj.ID_Cuestionario = ID_Cuestionario;
            obj.Texto_Opcion = Texto_Opcion;
            obj.Es_Correcta = Es_Correcta;

            return obj.Insertar(obj);
        }

        public static DataTable MostrarEvaluacionConOpciones(string ID_Evaluacion)
        {
            return new DORegistroOpcionesPreguntas().MostrarEvaluacionConOpciones(ID_Evaluacion);        
        }
    }
}

