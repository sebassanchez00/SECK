using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
   public  class NResultadoFinal
    {

       public static string Insertar(string idresultado, string idreporte, int cantidadpreguntas, int respuestasfallidas, int preguntasrespondidas, int respuestascorrectas,string cedula)
       {
           DResultadoFinal Objs = new DResultadoFinal();
           
          
     

            Objs.IdResultado = idresultado;
            Objs.IdReporte = idreporte;
            Objs.CantidadPreguntas = cantidadpreguntas;
            Objs.RespuestasFallidas = respuestasfallidas;
            Objs.PreguntasRespondidas = preguntasrespondidas;
            Objs.RespuestasCorrectas = respuestascorrectas;
            Objs.Cedula = cedula;

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
