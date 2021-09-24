using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
   public  class NEvaluacionContruida
    {

       public static string Insertar(string IdEValConstruida, string IdReporte, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, int p18, int p19, int p20, int p21, int p22, int p23, int p24, int p25, int p26, int p27, int p28, int p29, int p30)
       {
           DEvaluacionConstruida Obj = new DEvaluacionConstruida();

           Obj.IdEvalConstruida = IdEValConstruida;
           Obj.IdReporte = IdReporte;
           Obj.P1 = p1;
           Obj.P2 = p2;
           Obj.P3 = p3;
           Obj.P4 = p4;
           Obj.P5 = p5;
           Obj.P6 = p6;
           Obj.P7 = p7;
           Obj.P8 = p8;
           Obj.P9 = p9;
           Obj.P10 = p10;
           Obj.P11 = p11;
           Obj.P12 = p12;
           Obj.P13 = p13;
           Obj.P14 = p14;
           Obj.P15 = p15;
           Obj.P16 = p16;
           Obj.P17 = p17;
           Obj.P18 = p18;
           Obj.P19 = p19;
           Obj.P20 = p20;
           Obj.P21 = p21;
           Obj.P22 = p22;
           Obj.P23 = p23;
           Obj.P24 = p24;
           Obj.P25 = p25;
           Obj.P26 = p26;
           Obj.P27 = p27;
           Obj.P28 = p28;
           Obj.P29 = p29;
           Obj.P30 = p30;
         


           return Obj.Insertar(Obj);
       }

       public static string Editar(string IdEValConstruida, string IdReporte, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, int p18, int p19, int p20, int p21, int p22, int p23, int p24, int p25, int p26, int p27, int p28, int p29, int p30, string textobuscar)
       {
           DEvaluacionConstruida Obj = new DEvaluacionConstruida();

           Obj.IdEvalConstruida = IdEValConstruida;
           Obj.IdReporte = IdReporte;
           Obj.P1 = p1;
           Obj.P2 = p2;
           Obj.P3 = p3;
           Obj.P4 = p4;
           Obj.P5 = p5;
           Obj.P6 = p6;
           Obj.P7 = p7;
           Obj.P8 = p8;
           Obj.P9 = p9;
           Obj.P10 = p10;
           Obj.P11 = p11;
           Obj.P12 = p12;
           Obj.P13 = p13;
           Obj.P14 = p14;
           Obj.P15 = p15;
           Obj.P16 = p16;
           Obj.P17 = p17;
           Obj.P18 = p18;
           Obj.P19 = p19;
           Obj.P20 = p20;
           Obj.P21 = p21;
           Obj.P22 = p22;
           Obj.P23 = p23;
           Obj.P24 = p24;
           Obj.P25 = p25;
           Obj.P26 = p26;
           Obj.P27 = p27;
           Obj.P28 = p28;
           Obj.P29 = p29;
           Obj.P30 = p30;
         
           return Obj.Editar(Obj);
       }

       public static string Eliminar(string idEvalConstruida)
       {
           DEvaluacionConstruida Obj = new DEvaluacionConstruida();
           Obj.IdEvalConstruida= idEvalConstruida;
           return Obj.Eliminar(Obj);
       }

       public static ArrayList LLevarEvaluacionConstruida(string ID)
       {

           DEvaluacionConstruida Obj = new DEvaluacionConstruida();
           Obj.Textobuscar = ID;
           return Obj.TraerEvaluacionConstruida(Obj);


       }
    }
}
