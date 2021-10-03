using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DRespuestasEvaluacion
    {
        private string _IdRespuestaeval;
        private string _IdReporte;
        private string _IdevalConstruida;
        private string _r1;
        private string _r2;
        private string _r3;
        private string _r4;
        private string _r5;
        private string _r6;
        private string _r7;
        private string _r8;
        private string _r9;
        private string _r10;
        private string _r11;
        private string _r12;
        private string _r13;
        private string _r14;

        private string _r15;
        private string _r16;
        private string _r17;
        private string _r18;
        private string _r19;
        private string _r20;
        private string _r21;

        private string _r22;
        private string _r23;
        private string _r24;
        private string _r25;
        private string _r26;
        private string _r27;
        private string _r28;
        private string _r29;
        private string _r30;


        private int _puntajefinal;



        public string IdRespuesta_eval
        {


            get { return _IdRespuestaeval; }
            set { _IdRespuestaeval = value; }
        }


        public string IdEval_Construida
        {


            get { return _IdevalConstruida; }
            set { _IdevalConstruida = value; }
        }

        public string IdReporte
        {


            get { return _IdReporte; }
            set { _IdReporte = value; }
        }



        public string R1
        {


            get { return _r1; }
            set { _r1 = value; }
        }

        public string R2
        {


            get { return _r2; }
            set { _r2 = value; }
        }

        public string R3
        {


            get { return _r3; }
            set { _r3 = value; }
        }


        public string R4
        {


            get { return _r4; }
            set { _r4 = value; }
        }

        public string R5
        {


            get { return _r5; }
            set { _r5 = value; }
        }

        public string R6
        {


            get { return _r6; }
            set { _r6= value; }
        }

        public string R7
        {


            get { return _r7; }
            set { _r7 = value; }
        }

        public string R8
        {


            get { return _r8; }
            set { _r8 = value; }
        }


        public string R9
        {


            get { return _r9; }
            set { _r9 = value; }
        }


        public string R10
        {


            get { return _r10; }
            set { _r10 = value; }
        }


        public string R11
        {


            get { return _r11; }
            set { _r11 = value; }
        }

        public string R12
        {


            get { return _r12; }
            set { _r12 = value; }
        }

        public string R13
        {


            get { return _r13; }
            set { _r13 = value; }
        }


        public string R14
        {


            get { return _r14; }
            set { _r14 = value; }
        }

        public string R15
        {


            get { return _r15; }
            set { _r15 = value; }
        }

        public string R16
        {


            get { return _r16; }
            set { _r16 = value; }
        }


        public string R17
        {


            get { return _r17; }
            set { _r17 = value; }
        }


        public string R18
        {


            get { return _r18; }
            set { _r18 = value; }
        }


        public string R19
        {


            get { return _r19; }
            set { _r19 = value; }
        }


        public string R20
        {


            get { return _r20; }
            set { _r20 = value; }
        }


        public string R21
        {


            get { return _r21; }
            set { _r21 = value; }
        }


        public string R22
        {


            get { return _r22; }
            set { _r22 = value; }
        }


        public string R23
        {


            get { return _r23; }
            set { _r23 = value; }
        }


        public string R24
        {


            get { return _r24; }
            set { _r24 = value; }
        }


        public string R25
        {


            get { return _r25; }
            set { _r25 = value; }
        }


        public string R26
        {


            get { return _r26; }
            set { _r26 = value; }
        }

        public string R27
        {


            get { return _r27; }
            set { _r27 = value; }
        }


        public string R28
        {


            get { return _r28; }
            set { _r28 = value; }
        }


        public string R29
        {


            get { return _r29; }
            set { _r29 = value; }
        }


        public string R30
        {


            get { return _r30; }
            set { _r30 = value; }
        }
        public int Puntafinal
        {
            get { return _puntajefinal; }
            set { _puntajefinal = value; }
        }

        public string  Textobuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        private string _TextoBuscar;

       public DRespuestasEvaluacion()
      {


      }




       public DRespuestasEvaluacion(string RespuestaEval, string IdEValConstruida, string IdReporte, string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9, string r10, string r11, string r12, string r13, string r14, string r15, string r16, string r17, string r18, string r19, string r20, string r21, string r22, string r23, string r24, string r25, string r26, string r27, string r28, string r29, string r30, int puntafinal, string textobuscar)
      {
          this.IdRespuesta_eval = RespuestaEval;
          this.IdEval_Construida= IdEValConstruida;
          this.IdReporte= IdReporte;
          this.R1 = r1;
          this.R2 = r2;
          this.R3 = r3;
          this.R4 = r4;
          this.R5 = r5;
          this.R6 = r6;
          this.R7 = r7;
          this.R8 = r8;
          this.R9 = r9;
          this.R10 = r10;
          this.R11 = r11;
          this.R12 = r12;
          this.R13 = r13;
          this.R14 = r14;
          this.R15 = r15;
          this.R16 = r16;
          this.R17 = r17;
          this.R18 = r18;
          this.R19 = r19;
          this.R20 = r20;
          this.R21 = r21;
          this.R22 = r22;
          this.R23 = r23;
          this.R24 = r24;
          this.R25 = r25;
          this.R26 = r26;
          this.R27 = r27;
          this.R28 = r28;
          this.R29 = r29;
          this.R30 = r30;
          this.Puntafinal = puntafinal;

          this.Textobuscar = textobuscar;
      }

      /// <summary>
      /// Inserta registro en RESPUESTAS_EVALUACION. Devuelve string con informacion del resultado
      /// </summary>
      /// <param name="RespuestasEvaluacion"></param>
      /// <returns></returns>
       public string Insertar(DRespuestasEvaluacion RespuestasEvaluacion)
       {
           string rpta = "";
           SqlConnection SqlCon = new SqlConnection();
           try
           {
               //Código
               SqlCon.ConnectionString = Conexion.Cn;
               SqlCon.Open();
               //Establecer el Comando
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "SP_INSERTAR_RESPUESTA_EVALUACION";
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlParameter ParIdRespuestaEval = new SqlParameter();
               ParIdRespuestaEval.ParameterName = "@ID_RESPUESTA_EVAL";
               ParIdRespuestaEval.SqlDbType = SqlDbType.VarChar;
               ParIdRespuestaEval.Value = RespuestasEvaluacion.IdRespuesta_eval;
               SqlCmd.Parameters.Add(ParIdRespuestaEval);

               SqlParameter ParIdEvalconstruida = new SqlParameter();
               ParIdEvalconstruida.ParameterName = "@ID_EVAL_CONSTRUIDA";
               ParIdEvalconstruida.SqlDbType = SqlDbType.VarChar;
               ParIdEvalconstruida.Value = RespuestasEvaluacion.IdEval_Construida;
               SqlCmd.Parameters.Add(ParIdEvalconstruida);

               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = RespuestasEvaluacion.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter ParP1 = new SqlParameter();
               ParP1.ParameterName = "@R1";
               ParP1.SqlDbType = SqlDbType.VarChar;
               ParP1.Value = RespuestasEvaluacion.R1;
               SqlCmd.Parameters.Add(ParP1);

               SqlParameter ParP2 = new SqlParameter();
               ParP2.ParameterName = "@R2";
               ParP2.SqlDbType = SqlDbType.VarChar;
               ParP2.Value = RespuestasEvaluacion.R2;
               SqlCmd.Parameters.Add(ParP2);

               SqlParameter ParP3 = new SqlParameter();
               ParP3.ParameterName = "@R3";
               ParP3.SqlDbType = SqlDbType.VarChar;
               ParP3.Value = RespuestasEvaluacion.R3;
               SqlCmd.Parameters.Add(ParP3);

               SqlParameter ParP4 = new SqlParameter();
               ParP4.ParameterName = "@R4";
               ParP4.SqlDbType = SqlDbType.VarChar;
               ParP4.Value = RespuestasEvaluacion.R4;
               SqlCmd.Parameters.Add(ParP4);

               SqlParameter ParP5 = new SqlParameter();
               ParP5.ParameterName = "@R5";
               ParP5.SqlDbType = SqlDbType.VarChar;
               ParP5.Value = RespuestasEvaluacion.R5;
               SqlCmd.Parameters.Add(ParP5);

               SqlParameter ParP6 = new SqlParameter();
               ParP6.ParameterName = "@R6";
               ParP6.SqlDbType = SqlDbType.VarChar;
               ParP6.Value = RespuestasEvaluacion.R6;
               SqlCmd.Parameters.Add(ParP6);

               SqlParameter ParP7 = new SqlParameter();
               ParP7.ParameterName = "@R7";
               ParP7.SqlDbType = SqlDbType.VarChar;
               ParP7.Value = RespuestasEvaluacion.R7;
               SqlCmd.Parameters.Add(ParP7);

               SqlParameter ParP8 = new SqlParameter();
               ParP8.ParameterName = "@R8";
               ParP8.SqlDbType = SqlDbType.VarChar;
               ParP8.Value = RespuestasEvaluacion.R8;
               SqlCmd.Parameters.Add(ParP8);

               SqlParameter ParP9 = new SqlParameter();
               ParP9.ParameterName = "@R9";
               ParP9.SqlDbType = SqlDbType.VarChar;
               ParP9.Value = RespuestasEvaluacion.R9;
               SqlCmd.Parameters.Add(ParP9);

               SqlParameter ParP10 = new SqlParameter();
               ParP10.ParameterName = "@R10";
               ParP10.SqlDbType = SqlDbType.VarChar;
               ParP10.Value = RespuestasEvaluacion.R10;
               SqlCmd.Parameters.Add(ParP10);

               SqlParameter ParP11 = new SqlParameter();
               ParP11.ParameterName = "@R11";
               ParP11.SqlDbType = SqlDbType.VarChar;
               ParP11.Value = RespuestasEvaluacion.R11;
               SqlCmd.Parameters.Add(ParP11);

               SqlParameter ParP12 = new SqlParameter();
               ParP12.ParameterName = "@R12";
               ParP12.SqlDbType = SqlDbType.VarChar;
               ParP12.Value = RespuestasEvaluacion.R12;
               SqlCmd.Parameters.Add(ParP12);

               SqlParameter ParP13 = new SqlParameter();
               ParP13.ParameterName = "@R13";
               ParP13.SqlDbType = SqlDbType.VarChar;
               ParP13.Value = RespuestasEvaluacion.R13;
               SqlCmd.Parameters.Add(ParP13);

               SqlParameter ParP14 = new SqlParameter();
               ParP14.ParameterName = "@R14";
               ParP14.SqlDbType = SqlDbType.VarChar;
               ParP14.Value = RespuestasEvaluacion.R14;
               SqlCmd.Parameters.Add(ParP14);

               SqlParameter ParP15 = new SqlParameter();
               ParP15.ParameterName = "@R15";
               ParP15.SqlDbType = SqlDbType.VarChar;
               ParP15.Value = RespuestasEvaluacion.R15;
               SqlCmd.Parameters.Add(ParP15);

               SqlParameter ParP16 = new SqlParameter();
               ParP16.ParameterName = "@R16";
               ParP16.SqlDbType = SqlDbType.VarChar;
               ParP16.Value = RespuestasEvaluacion.R16;
               SqlCmd.Parameters.Add(ParP16);

               SqlParameter ParP17 = new SqlParameter();
               ParP17.ParameterName = "@R17";
               ParP17.SqlDbType = SqlDbType.VarChar;
               ParP17.Value = RespuestasEvaluacion.R17;
               SqlCmd.Parameters.Add(ParP17);

               SqlParameter ParP18 = new SqlParameter();
               ParP18.ParameterName = "@R18";
               ParP18.SqlDbType = SqlDbType.VarChar;
               ParP18.Value = RespuestasEvaluacion.R18;
               SqlCmd.Parameters.Add(ParP18);

               SqlParameter ParP19 = new SqlParameter();
               ParP19.ParameterName = "@R19";
               ParP19.SqlDbType = SqlDbType.VarChar;
               ParP19.Value = RespuestasEvaluacion.R19;
               SqlCmd.Parameters.Add(ParP19);

               SqlParameter ParP20 = new SqlParameter();
               ParP20.ParameterName = "@R20";
               ParP20.SqlDbType = SqlDbType.VarChar;
               ParP20.Value = RespuestasEvaluacion.R20;
               SqlCmd.Parameters.Add(ParP20);

               SqlParameter ParP21 = new SqlParameter();
               ParP21.ParameterName = "@R21";
               ParP21.SqlDbType = SqlDbType.VarChar;
               ParP21.Value = RespuestasEvaluacion.R21;
               SqlCmd.Parameters.Add(ParP21);

               SqlParameter ParP22 = new SqlParameter();
               ParP22.ParameterName = "@R22";
               ParP22.SqlDbType = SqlDbType.VarChar;
               ParP22.Value = RespuestasEvaluacion.R22;
               SqlCmd.Parameters.Add(ParP22);

               SqlParameter ParP23 = new SqlParameter();
               ParP23.ParameterName = "@R23";
               ParP23.SqlDbType = SqlDbType.VarChar;
               ParP23.Value = RespuestasEvaluacion.R23;
               SqlCmd.Parameters.Add(ParP23);

               SqlParameter ParP24 = new SqlParameter();
               ParP24.ParameterName = "@R24";
               ParP24.SqlDbType = SqlDbType.VarChar;
               ParP24.Value = RespuestasEvaluacion.R24;
               SqlCmd.Parameters.Add(ParP24);

               SqlParameter ParP25 = new SqlParameter();
               ParP25.ParameterName = "@R25";
               ParP25.SqlDbType = SqlDbType.VarChar;
               ParP25.Value = RespuestasEvaluacion.R25;
               SqlCmd.Parameters.Add(ParP25);

               SqlParameter ParP26 = new SqlParameter();
               ParP26.ParameterName = "@R26";
               ParP26.SqlDbType = SqlDbType.VarChar;
               ParP26.Value = RespuestasEvaluacion.R26;
               SqlCmd.Parameters.Add(ParP26);

               SqlParameter ParP27 = new SqlParameter();
               ParP27.ParameterName = "@R27";
               ParP27.SqlDbType = SqlDbType.VarChar;
               ParP27.Value = RespuestasEvaluacion.R27;
               SqlCmd.Parameters.Add(ParP27);

               SqlParameter ParP28 = new SqlParameter();
               ParP28.ParameterName = "@R28";
               ParP28.SqlDbType = SqlDbType.VarChar;
               ParP28.Value = RespuestasEvaluacion.R28;
               SqlCmd.Parameters.Add(ParP28);

               SqlParameter ParP29 = new SqlParameter();
               ParP29.ParameterName = "@R29";
               ParP29.SqlDbType = SqlDbType.VarChar;
               ParP29.Value = RespuestasEvaluacion.R29;
               SqlCmd.Parameters.Add(ParP29);

               SqlParameter ParP30 = new SqlParameter();
               ParP30.ParameterName = "@R30";
               ParP30.SqlDbType = SqlDbType.VarChar;
               ParP30.Value = RespuestasEvaluacion.R30;
               SqlCmd.Parameters.Add(ParP30);

               SqlParameter ParPuntajefinal = new SqlParameter();
               ParPuntajefinal.ParameterName = "@PUNTAJEFINAL";
               ParPuntajefinal.SqlDbType = SqlDbType.Int;
               ParPuntajefinal.Value = RespuestasEvaluacion.Puntafinal;
               SqlCmd.Parameters.Add(ParPuntajefinal);
               //Ejecutamos nuestro comando
               rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
           }
           catch (Exception ex)
           {
               rpta = ex.Message;
           }
           finally
           {
               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
           }
           return rpta;
       }

       public string Editar(DRespuestasEvaluacion RespuestasEvaluacion)
       {

           string rpta = "";
           SqlConnection SqlCon = new SqlConnection();
           try
           {
               //Código
               SqlCon.ConnectionString = Conexion.Cn;
               SqlCon.Open();
               //Establecer el Comando
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "SP_UPDATE_RESPUESTAS_EVALUACION";
               SqlCmd.CommandType = CommandType.StoredProcedure;


               SqlParameter ParIdRespuestaEval = new SqlParameter();
               ParIdRespuestaEval.ParameterName = "@ID_RESPUESTA_EVAL";
               ParIdRespuestaEval.SqlDbType = SqlDbType.VarChar;
               ParIdRespuestaEval.Value = RespuestasEvaluacion.IdRespuesta_eval;
               SqlCmd.Parameters.Add(ParIdRespuestaEval);

               SqlParameter ParIdEvalconstruida = new SqlParameter();
               ParIdEvalconstruida.ParameterName = "@ID_EVAL_CONSTRUIDA";
               ParIdEvalconstruida.SqlDbType = SqlDbType.VarChar;
               ParIdEvalconstruida.Value = RespuestasEvaluacion.IdEval_Construida;
               SqlCmd.Parameters.Add(ParIdEvalconstruida);

               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = RespuestasEvaluacion.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter ParP1 = new SqlParameter();
               ParP1.ParameterName = "@R1";
               ParP1.SqlDbType = SqlDbType.VarChar;
               ParP1.Value = RespuestasEvaluacion.R1;
               SqlCmd.Parameters.Add(ParP1);

               SqlParameter ParP2 = new SqlParameter();
               ParP2.ParameterName = "@R2";
               ParP2.SqlDbType = SqlDbType.VarChar;
               ParP2.Value = RespuestasEvaluacion.R2;
               SqlCmd.Parameters.Add(ParP2);

               SqlParameter ParP3 = new SqlParameter();
               ParP3.ParameterName = "@R3";
               ParP3.SqlDbType = SqlDbType.VarChar;
               ParP3.Value = RespuestasEvaluacion.R3;
               SqlCmd.Parameters.Add(ParP3);

               SqlParameter ParP4 = new SqlParameter();
               ParP4.ParameterName = "@R4";
               ParP4.SqlDbType = SqlDbType.VarChar;
               ParP4.Value = RespuestasEvaluacion.R4;
               SqlCmd.Parameters.Add(ParP4);


               SqlParameter ParP5 = new SqlParameter();
               ParP5.ParameterName = "@R5";
               ParP5.SqlDbType = SqlDbType.VarChar;
               ParP5.Value = RespuestasEvaluacion.R5;
               SqlCmd.Parameters.Add(ParP5);


               SqlParameter ParP6 = new SqlParameter();
               ParP6.ParameterName = "@R6";
               ParP6.SqlDbType = SqlDbType.VarChar;
               ParP6.Value = RespuestasEvaluacion.R6;
               SqlCmd.Parameters.Add(ParP6);


               SqlParameter ParP7 = new SqlParameter();
               ParP7.ParameterName = "@R7";
               ParP7.SqlDbType = SqlDbType.VarChar;
               ParP7.Value = RespuestasEvaluacion.R7;
               SqlCmd.Parameters.Add(ParP7);


               SqlParameter ParP8 = new SqlParameter();
               ParP8.ParameterName = "@R8";
               ParP8.SqlDbType = SqlDbType.VarChar;
               ParP8.Value = RespuestasEvaluacion.R8;
               SqlCmd.Parameters.Add(ParP8);


               SqlParameter ParP9 = new SqlParameter();
               ParP9.ParameterName = "@R9";
               ParP9.SqlDbType = SqlDbType.VarChar;
               ParP9.Value = RespuestasEvaluacion.R9;
               SqlCmd.Parameters.Add(ParP9);


               SqlParameter ParP10 = new SqlParameter();
               ParP10.ParameterName = "@R10";
               ParP10.SqlDbType = SqlDbType.VarChar;
               ParP10.Value = RespuestasEvaluacion.R10;
               SqlCmd.Parameters.Add(ParP10);


               SqlParameter ParP11 = new SqlParameter();
               ParP11.ParameterName = "@R11";
               ParP11.SqlDbType = SqlDbType.VarChar;
               ParP11.Value = RespuestasEvaluacion.R11;
               SqlCmd.Parameters.Add(ParP11);


               SqlParameter ParP12 = new SqlParameter();
               ParP12.ParameterName = "@R12";
               ParP12.SqlDbType = SqlDbType.VarChar;
               ParP12.Value = RespuestasEvaluacion.R12;
               SqlCmd.Parameters.Add(ParP12);


               SqlParameter ParP13 = new SqlParameter();
               ParP13.ParameterName = "@R13";
               ParP13.SqlDbType = SqlDbType.VarChar;
               ParP13.Value = RespuestasEvaluacion.R13;
               SqlCmd.Parameters.Add(ParP13);


               SqlParameter ParP14 = new SqlParameter();
               ParP14.ParameterName = "@R14";
               ParP14.SqlDbType = SqlDbType.VarChar;
               ParP14.Value = RespuestasEvaluacion.R14;
               SqlCmd.Parameters.Add(ParP14);


               SqlParameter ParP15 = new SqlParameter();
               ParP15.ParameterName = "@R15";
               ParP15.SqlDbType = SqlDbType.VarChar;
               ParP15.Value = RespuestasEvaluacion.R15;
               SqlCmd.Parameters.Add(ParP15);


               SqlParameter ParP16 = new SqlParameter();
               ParP16.ParameterName = "@R16";
               ParP16.SqlDbType = SqlDbType.VarChar;
               ParP16.Value = RespuestasEvaluacion.R16;
               SqlCmd.Parameters.Add(ParP16);


               SqlParameter ParP17 = new SqlParameter();
               ParP17.ParameterName = "@R17";
               ParP17.SqlDbType = SqlDbType.VarChar;
               ParP17.Value = RespuestasEvaluacion.R17;
               SqlCmd.Parameters.Add(ParP17);


               SqlParameter ParP18 = new SqlParameter();
               ParP18.ParameterName = "@R18";
               ParP18.SqlDbType = SqlDbType.VarChar;
               ParP18.Value = RespuestasEvaluacion.R18;
               SqlCmd.Parameters.Add(ParP18);


               SqlParameter ParP19 = new SqlParameter();
               ParP19.ParameterName = "@R19";
               ParP19.SqlDbType = SqlDbType.VarChar;
               ParP19.Value = RespuestasEvaluacion.R19;
               SqlCmd.Parameters.Add(ParP19);


               SqlParameter ParP20 = new SqlParameter();
               ParP20.ParameterName = "@R20";
               ParP20.SqlDbType = SqlDbType.VarChar;
               ParP20.Value = RespuestasEvaluacion.R20;
               SqlCmd.Parameters.Add(ParP20);


               SqlParameter ParP21 = new SqlParameter();
               ParP21.ParameterName = "@R21";
               ParP21.SqlDbType = SqlDbType.VarChar;
               ParP21.Value = RespuestasEvaluacion.R21;
               SqlCmd.Parameters.Add(ParP21);


               SqlParameter ParP22 = new SqlParameter();
               ParP22.ParameterName = "@R22";
               ParP22.SqlDbType = SqlDbType.VarChar;
               ParP22.Value = RespuestasEvaluacion.R22;
               SqlCmd.Parameters.Add(ParP22);


               SqlParameter ParP23 = new SqlParameter();
               ParP23.ParameterName = "@R23";
               ParP23.SqlDbType = SqlDbType.VarChar;
               ParP23.Value = RespuestasEvaluacion.R23;
               SqlCmd.Parameters.Add(ParP23);


               SqlParameter ParP24 = new SqlParameter();
               ParP24.ParameterName = "@R24";
               ParP24.SqlDbType = SqlDbType.VarChar;
               ParP24.Value = RespuestasEvaluacion.R24;
               SqlCmd.Parameters.Add(ParP24);


               SqlParameter ParP25 = new SqlParameter();
               ParP25.ParameterName = "@R25";
               ParP25.SqlDbType = SqlDbType.VarChar;
               ParP25.Value = RespuestasEvaluacion.R25;
               SqlCmd.Parameters.Add(ParP25);


               SqlParameter ParP26 = new SqlParameter();
               ParP26.ParameterName = "@R26";
               ParP26.SqlDbType = SqlDbType.VarChar;
               ParP26.Value = RespuestasEvaluacion.R26;
               SqlCmd.Parameters.Add(ParP26);

               SqlParameter ParP27 = new SqlParameter();
               ParP27.ParameterName = "@R27";
               ParP27.SqlDbType = SqlDbType.VarChar;
               ParP27.Value = RespuestasEvaluacion.R27;
               SqlCmd.Parameters.Add(ParP27);


               SqlParameter ParP28 = new SqlParameter();
               ParP28.ParameterName = "@R28";
               ParP28.SqlDbType = SqlDbType.VarChar;
               ParP28.Value = RespuestasEvaluacion.R28;
               SqlCmd.Parameters.Add(ParP28);


               SqlParameter ParP29 = new SqlParameter();
               ParP29.ParameterName = "@R29";
               ParP29.SqlDbType = SqlDbType.VarChar;
               ParP29.Value = RespuestasEvaluacion.R29;
               SqlCmd.Parameters.Add(ParP29);



               SqlParameter ParP30 = new SqlParameter();
               ParP30.ParameterName = "@R30";
               ParP30.SqlDbType = SqlDbType.VarChar;
               ParP30.Value = RespuestasEvaluacion.R30;
               SqlCmd.Parameters.Add(ParP30);



               SqlParameter ParPuntajefinal = new SqlParameter();
               ParPuntajefinal.ParameterName = "@PUNTAJEFINAL";
               ParPuntajefinal.SqlDbType = SqlDbType.Int;
               ParPuntajefinal.Value = RespuestasEvaluacion.Puntafinal;
               SqlCmd.Parameters.Add(ParP30);





               //Ejecutamos nuestro comando

               rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


           }
           catch (Exception ex)
           {
               rpta = ex.Message;
           }
           finally
           {
               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
           }
           return rpta;

       }


       public string Eliminar(DRespuestasEvaluacion RespuestasEvaluacion)
       {
           string rpta = "";
           SqlConnection SqlCon = new SqlConnection();
           try
           {
               //Código
               SqlCon.ConnectionString = Conexion.Cn;
               SqlCon.Open();
               //Establecer el Comando
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "SP_DELETE_RESPUESTAS_EVALUACION";
               SqlCmd.CommandType = CommandType.StoredProcedure;


               SqlParameter ParIdRespuestaEval = new SqlParameter();
               ParIdRespuestaEval.ParameterName = "@ID_RESPUESTA_EVAL";
               ParIdRespuestaEval.SqlDbType = SqlDbType.Int;
               ParIdRespuestaEval.Value = RespuestasEvaluacion.IdRespuesta_eval;
               SqlCmd.Parameters.Add(ParIdRespuestaEval);

               //Ejecutamos nuestro comando

               rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


           }
           catch (Exception ex)
           {
               rpta = ex.Message;
           }
           finally
           {
               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
           }
           return rpta;
       }



    }
}
