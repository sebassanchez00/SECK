using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
   public  class NReportes
    {

       public static string Insertar(string idreporte, string cedula, DateTime fecha, int des1, int des2, int des3, int des4, int des5, int des6, int des7, int des8, int des9, int des10, int des11, string obser1, string obser2, string obser3, string obser4, string obser5, string obser6, string obser7, string obser8, string obser9, string obser10, string obser11, string observacion,string instructor)
       {
           DReportes Obj = new DReportes();
           Obj.IdReporte=idreporte;
           Obj.Cedula=cedula;
           Obj.Fecha=fecha;
           Obj.Des1=des1;
           Obj.Des2 = des2;
           Obj.Des3 = des3;
           Obj.Des4 = des4;
           Obj.Des5 = des5;
           Obj.Des6 = des6;
           Obj.Des7 = des7;
           Obj.Des8 = des8;
           Obj.Des9 = des9;
           Obj.Des10 = des10;

           Obj.Des11 = des1;

           Obj.Obser1=obser1;
           Obj.Obser2 = obser2;
           Obj.Obser3 = obser3;
           Obj.Obser4 = obser4;

           Obj.Obser5 = obser5;
           Obj.Obser6 = obser6;
           Obj.Obser7 = obser7;
           Obj.Obser8 = obser8;
           Obj.Obser9 = obser9;
           Obj.Obser10 = obser10;
           Obj.Obser11 = obser11;
           Obj.Observacion = observacion;
           Obj.Instructor = instructor;

           return Obj.Insertar(Obj);
       }



       public static string Editar(string idreporte, string cedula, DateTime fecha, int des1, int des2, int des3, int des4, int des5, int des6, int des7, int des8, int des9, int des10, int des11, string obser1, string obser2, string obser3, string obser4, string obser5, string obser6, string obser7, string obser8, string obser9, string obser10, string obser11, string observacion, string instructor)
       {
           DReportes Obj = new DReportes();
           Obj.IdReporte = idreporte;
           Obj.Cedula = cedula;
           Obj.Fecha = fecha;
           Obj.Des1 = des1;
           Obj.Des2 = des2;
           Obj.Des3 = des3;
           Obj.Des4 = des4;
           Obj.Des5 = des5;
           Obj.Des6 = des6;
           Obj.Des7 = des7;
           Obj.Des8 = des8;
           Obj.Des9 = des9;
           Obj.Des10 = des10;

           Obj.Des11 = des1;

           Obj.Obser1 = obser1;
           Obj.Obser2 = obser2;
           Obj.Obser3 = obser3;
           Obj.Obser4 = obser4;

           Obj.Obser5 = obser5;
           Obj.Obser6 = obser6;
           Obj.Obser7 = obser7;
           Obj.Obser8 = obser8;
           Obj.Obser9 = obser9;
           Obj.Obser10 = obser10;
           Obj.Obser11 = obser11;
           Obj.Observacion = observacion;
           Obj.Instructor = instructor;

           return Obj.Editar(Obj);
       }







       public static int ConsultarReportes(string textobucar)
       {
           DReportes Obj = new DReportes();
           Obj.Cedula = textobucar;

           return Obj.BuscarRegistroReportes(Obj);

       }

       public static DataSet GenerarReporte(string textobucar)
       {
           DReportes Obj = new DReportes();
           Obj.IdReporte = textobucar;

           return Obj.BuscarReporte(Obj);

       }





    }
}
