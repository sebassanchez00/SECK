using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
  public  class NRespuestasEvaluacion
    {


      public static string Insertar(string RespuestaEval, string IdEValConstruida, string IdReporte, string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9, string r10, string r11, string r12, string r13, string r14, string r15, string r16, string r17, string r18, string r19, string r20, string r21, string r22, string r23, string r24, string r25, string r26, string r27, string r28, string r29, string r30, int puntafinal)
        {
            DRespuestasEvaluacion Obj = new DRespuestasEvaluacion();
            Obj.IdRespuesta_eval = IdEValConstruida;
            Obj.IdEval_Construida = IdEValConstruida;
            Obj.IdReporte = IdReporte;
            Obj.R1 = r1;
            Obj.R2 =r2;
            Obj.R3 = r3;
            Obj.R4 = r4;
            Obj.R5 = r5;
            Obj.R6 = r6;
            Obj.R7 = r7;
            Obj.R8 = r8;
            Obj.R9 = r9;
            Obj.R10 = r10;
            Obj.R11 = r11;
            Obj.R12 = r12;
            Obj.R13 = r13;
            Obj.R14 = r14;
            Obj.R15 = r15;
            Obj.R16 = r16;
            Obj.R17 = r17;
            Obj.R18 = r18;
            Obj.R19 = r19;
            Obj.R20 = r20;
            Obj.R21 = r21;
            Obj.R22 = r22;
            Obj.R23 = r23;
            Obj.R24 = r24;
            Obj.R25 = r25;
            Obj.R26 = r26;
            Obj.R27 = r27;
            Obj.R28 = r28;
            Obj.R29 = r29;
            Obj.R30 = r30;
            Obj.Puntafinal = puntafinal;


            return Obj.Insertar(Obj);
        }

      public static string Editar(string RespuestaEval, string IdEValConstruida, string IdReporte, string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9, string r10, string r11, string r12, string r13, string r14, string r15, string r16, string r17, string r18, string r19, string r20, string r21, string r22, string r23, string r24, string r25, string r26, string r27, string r28, string r29, string r30, int puntafinal)
        {
          

            DRespuestasEvaluacion Obj = new DRespuestasEvaluacion();
            Obj.IdRespuesta_eval = IdEValConstruida;
            Obj.IdEval_Construida = IdEValConstruida;
            Obj.IdReporte = IdReporte;
            Obj.R1 = r1;
            Obj.R2 = r2;
            Obj.R3 = r3;
            Obj.R4 = r4;
            Obj.R5 = r5;
            Obj.R6 = r6;
            Obj.R7 = r7;
            Obj.R8 = r8;
            Obj.R9 = r9;
            Obj.R10 = r10;
            Obj.R11 = r11;
            Obj.R12 = r12;
            Obj.R13 = r13;
            Obj.R14 = r14;
            Obj.R15 = r15;
            Obj.R16 = r16;
            Obj.R17 = r17;
            Obj.R18 = r18;
            Obj.R19 = r19;
            Obj.R20 = r20;
            Obj.R21 = r21;
            Obj.R22 = r22;
            Obj.R23 = r23;
            Obj.R24 = r24;
            Obj.R25 = r25;
            Obj.R26 = r26;
            Obj.R27 = r27;
            Obj.R28 = r28;
            Obj.R29 = r29;
            Obj.R30 = r30;
            Obj.Puntafinal = puntafinal;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(string idrespuestaeval)
        {
            DRespuestasEvaluacion Obj = new DRespuestasEvaluacion();
            Obj.IdRespuesta_eval = idrespuestaeval;
            return Obj.Eliminar(Obj);
        }












    }
}
