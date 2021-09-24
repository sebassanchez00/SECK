using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DEvaluacionConstruida
    {
      private string _IdEValConstruida;
        private string _IdReporte;
        private int _Pr1;
        private int _Pr2;
        private int _Pr3;
        private int _Pr4;
        private int _Pr5;
        private int _Pr6;
        private int _Pr7;
        private int _Pr8;
        private int _Pr9;
        private int _Pr10;
        private int _Pr11;
        private int _Pr12;
        private int _Pr13;
        private int _Pr14;

        private int _Pr15;
        private int _Pr16;
        private int _Pr17;
        private int _Pr18;
        private int _Pr19;
        private int _Pr20;
        private int _Pr21;

        private int _Pr22;
        private int _Pr23;
        private int _Pr24;
        private int _Pr25;
        private int _Pr26;
        private int _Pr27;
        private int _Pr28;
        private int _Pr29;
        private int _Pr30;
     
        public string IdEvalConstruida
        {


            get { return _IdEValConstruida; }
            set { _IdEValConstruida = value; }
        }

        public string IdReporte
        {


            get { return _IdReporte; }
            set { _IdReporte = value; }
        }



        public int P1
        {


            get { return _Pr1; }
            set { _Pr1 = value; }
        }

        public int P2
        {


            get { return _Pr2; }
            set { _Pr2 = value; }
        }

        public int P3
        {


            get { return _Pr3; }
            set { _Pr3 = value; }
        }


        public int P4
        {


            get { return _Pr4; }
            set { _Pr4 = value; }
        }

        public int P5
        {


            get { return _Pr5; }
            set { _Pr5 = value; }
        }

        public int P6
        {


            get { return _Pr6; }
            set { _Pr6= value; }
        }

        public int P7
        {


            get { return _Pr7; }
            set { _Pr7 = value; }
        }

        public int P8
        {


            get { return _Pr8; }
            set { _Pr8 = value; }
        }


        public int P9
        {


            get { return _Pr9; }
            set { _Pr9 = value; }
        }


        public int P10
        {


            get { return _Pr10; }
            set { _Pr10 = value; }
        }


        public int P11
        {


            get { return _Pr11; }
            set { _Pr11 = value; }
        }

        public int P12
        {


            get { return _Pr12; }
            set { _Pr12 = value; }
        }

        public int P13
        {


            get { return _Pr13; }
            set { _Pr13 = value; }
        }


        public int P14
        {


            get { return _Pr14; }
            set { _Pr14 = value; }
        }

        public int P15
        {


            get { return _Pr15; }
            set { _Pr15 = value; }
        }

        public int P16
        {


            get { return _Pr16; }
            set { _Pr16 = value; }
        }


        public int P17
        {


            get { return _Pr17; }
            set { _Pr17 = value; }
        }


        public int P18
        {


            get { return _Pr18; }
            set { _Pr18 = value; }
        }


        public int P19
        {


            get { return _Pr19; }
            set { _Pr19 = value; }
        }


        public int P20
        {


            get { return _Pr20; }
            set { _Pr20 = value; }
        }


        public int P21
        {


            get { return _Pr21; }
            set { _Pr21 = value; }
        }


        public int P22
        {


            get { return _Pr22; }
            set { _Pr22 = value; }
        }


        public int P23
        {


            get { return _Pr23; }
            set { _Pr23 = value; }
        }


        public int P24
        {


            get { return _Pr24; }
            set { _Pr24 = value; }
        }


        public int P25
        {


            get { return _Pr25; }
            set { _Pr25 = value; }
        }


        public int P26
        {


            get { return _Pr26; }
            set { _Pr26 = value; }
        }

        public int P27
        {


            get { return _Pr27; }
            set { _Pr27 = value; }
        }


        public int P28
        {


            get { return _Pr28; }
            set { _Pr28 = value; }
        }


        public int P29
        {


            get { return _Pr29; }
            set { _Pr29 = value; }
        }


        public int P30
        {


            get { return _Pr30; }
            set { _Pr30 = value; }
        }

        private string _TextoBuscar;
        public string  Textobuscar
        {


            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }








      





       public DEvaluacionConstruida()
      {


      }




       public DEvaluacionConstruida(string IdEValConstruida, string IdReporte, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9, int p10, int p11, int p12, int p13, int p14, int p15, int p16, int p17, int p18, int p19, int p20, int p21, int p22, int p23, int p24, int p25, int p26, int p27, int p28, int p29, int p30, string textobuscar)
      {
          this.IdEvalConstruida= IdEvalConstruida;
          this.IdReporte= IdReporte;
          this.P1 = p1;
          this.P2 = p2;
          this.P3 = p3;
          this.P4 = p4;
          this.P5 = p5;
          this.P6 = p6;
          this.P7 = p7;
          this.P8 = p8;
          this.P9 = p9;
          this.P10 = p10;
          this.P11 = p11;
          this.P12 = p12;
          this.P13 = p13;
          this.P14 = p14;
          this.P15 = p15;
          this.P16 = p16;
          this.P17 = p17;
          this.P18 = p18;
          this.P19 = p19;
          this.P20 = p20;
          this.P21 = p21;
          this.P22 = p22;
          this.P23 = p23;
          this.P24 = p24;
          this.P25 = p25;
          this.P26 = p26;
          this.P27 = p27;
          this.P28 = p28;
          this.P29 = p29;
          this.P30 = p30;
          this.Textobuscar = textobuscar;
      }

       public string Insertar(DEvaluacionConstruida EvaluacionConstruida)
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
               SqlCmd.CommandText = "SP_INSERTAR_EVALUACION_CONSTRUIDA";
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlParameter ParIdEvalconstruida = new SqlParameter();
               ParIdEvalconstruida.ParameterName = "@ID_EVAL_CONSTRUIDA";
               ParIdEvalconstruida.SqlDbType = SqlDbType.VarChar;
               ParIdEvalconstruida.Value = EvaluacionConstruida.IdEvalConstruida;
               SqlCmd.Parameters.Add(ParIdEvalconstruida);

               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = EvaluacionConstruida.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter ParP1 = new SqlParameter();
               ParP1.ParameterName = "@P1";
               ParP1.SqlDbType = SqlDbType.Int;
               ParP1.Value = EvaluacionConstruida.P1;
               SqlCmd.Parameters.Add(ParP1);

               SqlParameter ParP2 = new SqlParameter();
               ParP2.ParameterName = "@P2";
               ParP2.SqlDbType = SqlDbType.Int;
               ParP2.Value = EvaluacionConstruida.P2;
               SqlCmd.Parameters.Add(ParP2);

               SqlParameter ParP3 = new SqlParameter();
               ParP3.ParameterName = "@P3";
               ParP3.SqlDbType = SqlDbType.Int;
               ParP3.Value = EvaluacionConstruida.P3;
               SqlCmd.Parameters.Add(ParP3);

               SqlParameter ParP4 = new SqlParameter();
               ParP4.ParameterName = "@P4";
               ParP4.SqlDbType = SqlDbType.Int;
               ParP4.Value = EvaluacionConstruida.P4;
               SqlCmd.Parameters.Add(ParP4);

               SqlParameter ParP5 = new SqlParameter();
               ParP5.ParameterName = "@P5";
               ParP5.SqlDbType = SqlDbType.Int;
               ParP5.Value = EvaluacionConstruida.P5;
               SqlCmd.Parameters.Add(ParP5);

               SqlParameter ParP6 = new SqlParameter();
               ParP6.ParameterName = "@P6";
               ParP6.SqlDbType = SqlDbType.Int;
               ParP6.Value = EvaluacionConstruida.P6;
               SqlCmd.Parameters.Add(ParP6);

               SqlParameter ParP7 = new SqlParameter();
               ParP7.ParameterName = "@P7";
               ParP7.SqlDbType = SqlDbType.Int;
               ParP7.Value = EvaluacionConstruida.P7;
               SqlCmd.Parameters.Add(ParP7);

               SqlParameter ParP8 = new SqlParameter();
               ParP8.ParameterName = "@P8";
               ParP8.SqlDbType = SqlDbType.Int;
               ParP8.Value = EvaluacionConstruida.P8;
               SqlCmd.Parameters.Add(ParP8);

               SqlParameter ParP9 = new SqlParameter();
               ParP9.ParameterName = "@P9";
               ParP9.SqlDbType = SqlDbType.Int;
               ParP9.Value = EvaluacionConstruida.P9;
               SqlCmd.Parameters.Add(ParP9);

               SqlParameter ParP10 = new SqlParameter();
               ParP10.ParameterName = "@P10";
               ParP10.SqlDbType = SqlDbType.Int;
               ParP10.Value = EvaluacionConstruida.P10;
               SqlCmd.Parameters.Add(ParP10);

               SqlParameter ParP11 = new SqlParameter();
               ParP11.ParameterName = "@P11";
               ParP11.SqlDbType = SqlDbType.Int;
               ParP11.Value = EvaluacionConstruida.P11;
               SqlCmd.Parameters.Add(ParP11);

               SqlParameter ParP12 = new SqlParameter();
               ParP12.ParameterName = "@P12";
               ParP12.SqlDbType = SqlDbType.Int;
               ParP12.Value = EvaluacionConstruida.P12;
               SqlCmd.Parameters.Add(ParP12);

               SqlParameter ParP13 = new SqlParameter();
               ParP13.ParameterName = "@P13";
               ParP13.SqlDbType = SqlDbType.Int;
               ParP13.Value = EvaluacionConstruida.P13;
               SqlCmd.Parameters.Add(ParP13);

               SqlParameter ParP14 = new SqlParameter();
               ParP14.ParameterName = "@P14";
               ParP14.SqlDbType = SqlDbType.Int;
               ParP14.Value = EvaluacionConstruida.P14;
               SqlCmd.Parameters.Add(ParP14);

               SqlParameter ParP15 = new SqlParameter();
               ParP15.ParameterName = "@P15";
               ParP15.SqlDbType = SqlDbType.Int;
               ParP15.Value = EvaluacionConstruida.P15;
               SqlCmd.Parameters.Add(ParP15);

               SqlParameter ParP16 = new SqlParameter();
               ParP16.ParameterName = "@P16";
               ParP16.SqlDbType = SqlDbType.Int;
               ParP16.Value = EvaluacionConstruida.P16;
               SqlCmd.Parameters.Add(ParP16);

               SqlParameter ParP17 = new SqlParameter();
               ParP17.ParameterName = "@P17";
               ParP17.SqlDbType = SqlDbType.Int;
               ParP17.Value = EvaluacionConstruida.P17;
               SqlCmd.Parameters.Add(ParP17);

               SqlParameter ParP18 = new SqlParameter();
               ParP18.ParameterName = "@P18";
               ParP18.SqlDbType = SqlDbType.Int;
               ParP18.Value = EvaluacionConstruida.P18;
               SqlCmd.Parameters.Add(ParP18);

               SqlParameter ParP19 = new SqlParameter();
               ParP19.ParameterName = "@P19";
               ParP19.SqlDbType = SqlDbType.Int;
               ParP19.Value = EvaluacionConstruida.P19;
               SqlCmd.Parameters.Add(ParP19);

               SqlParameter ParP20 = new SqlParameter();
               ParP20.ParameterName = "@P20";
               ParP20.SqlDbType = SqlDbType.Int;
               ParP20.Value = EvaluacionConstruida.P20;
               SqlCmd.Parameters.Add(ParP20);

               SqlParameter ParP21 = new SqlParameter();
               ParP21.ParameterName = "@P21";
               ParP21.SqlDbType = SqlDbType.Int;
               ParP21.Value = EvaluacionConstruida.P21;
               SqlCmd.Parameters.Add(ParP21);

               SqlParameter ParP22 = new SqlParameter();
               ParP22.ParameterName = "@P22";
               ParP22.SqlDbType = SqlDbType.Int;
               ParP22.Value = EvaluacionConstruida.P22;
               SqlCmd.Parameters.Add(ParP22);

               SqlParameter ParP23 = new SqlParameter();
               ParP23.ParameterName = "@P23";
               ParP23.SqlDbType = SqlDbType.Int;
               ParP23.Value = EvaluacionConstruida.P23;
               SqlCmd.Parameters.Add(ParP23);

               SqlParameter ParP24 = new SqlParameter();
               ParP24.ParameterName = "@P24";
               ParP24.SqlDbType = SqlDbType.Int;
               ParP24.Value = EvaluacionConstruida.P24;
               SqlCmd.Parameters.Add(ParP24);

               SqlParameter ParP25 = new SqlParameter();
               ParP25.ParameterName = "@P25";
               ParP25.SqlDbType = SqlDbType.Int;
               ParP25.Value = EvaluacionConstruida.P25;
               SqlCmd.Parameters.Add(ParP25);

               SqlParameter ParP26 = new SqlParameter();
               ParP26.ParameterName = "@P26";
               ParP26.SqlDbType = SqlDbType.Int;
               ParP26.Value = EvaluacionConstruida.P26;
               SqlCmd.Parameters.Add(ParP26);

               SqlParameter ParP27 = new SqlParameter();
               ParP27.ParameterName = "@P27";
               ParP27.SqlDbType = SqlDbType.Int;
               ParP27.Value = EvaluacionConstruida.P27;
               SqlCmd.Parameters.Add(ParP27);

               SqlParameter ParP28 = new SqlParameter();
               ParP28.ParameterName = "@P28";
               ParP28.SqlDbType = SqlDbType.Int;
               ParP28.Value = EvaluacionConstruida.P28;
               SqlCmd.Parameters.Add(ParP28);

               SqlParameter ParP29 = new SqlParameter();
               ParP29.ParameterName = "@P29";
               ParP29.SqlDbType = SqlDbType.Int;
               ParP29.Value = EvaluacionConstruida.P29;
               SqlCmd.Parameters.Add(ParP29);

               SqlParameter ParP30 = new SqlParameter();
               ParP30.ParameterName = "@P30";
               ParP30.SqlDbType = SqlDbType.Int;
               ParP30.Value = EvaluacionConstruida.P30;
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

       public string Editar(DEvaluacionConstruida EvaluacionConstruida)
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
               SqlCmd.CommandText = "SP_UPDATE_EVALUACION_CONSTRUIDA";
               SqlCmd.CommandType = CommandType.StoredProcedure;



               SqlParameter ParIdEvalconstruida = new SqlParameter();
               ParIdEvalconstruida.ParameterName = "@ID_EVAL_CONSTRUIDA";
               ParIdEvalconstruida.SqlDbType = SqlDbType.VarChar;
               ParIdEvalconstruida.Value = EvaluacionConstruida.IdEvalConstruida;
               SqlCmd.Parameters.Add(ParIdEvalconstruida);

               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = EvaluacionConstruida.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter ParP1 = new SqlParameter();
               ParP1.ParameterName = "@P1";
               ParP1.SqlDbType = SqlDbType.Int;
               ParP1.Value = EvaluacionConstruida.P1;
               SqlCmd.Parameters.Add(ParP1);

               SqlParameter ParP2 = new SqlParameter();
               ParP2.ParameterName = "@P2";
               ParP2.SqlDbType = SqlDbType.Int;
               ParP2.Value = EvaluacionConstruida.P2;
               SqlCmd.Parameters.Add(ParP2);

               SqlParameter ParP3 = new SqlParameter();
               ParP3.ParameterName = "@P3";
               ParP3.SqlDbType = SqlDbType.Int;
               ParP3.Value = EvaluacionConstruida.P3;
               SqlCmd.Parameters.Add(ParP3);

               SqlParameter ParP4 = new SqlParameter();
               ParP4.ParameterName = "@P4";
               ParP4.SqlDbType = SqlDbType.Int;
               ParP4.Value = EvaluacionConstruida.P4;
               SqlCmd.Parameters.Add(ParP4);


               SqlParameter ParP5 = new SqlParameter();
               ParP5.ParameterName = "@P5";
               ParP5.SqlDbType = SqlDbType.Int;
               ParP5.Value = EvaluacionConstruida.P5;
               SqlCmd.Parameters.Add(ParP5);


               SqlParameter ParP6 = new SqlParameter();
               ParP6.ParameterName = "@P6";
               ParP6.SqlDbType = SqlDbType.Int;
               ParP6.Value = EvaluacionConstruida.P6;
               SqlCmd.Parameters.Add(ParP6);


               SqlParameter ParP7 = new SqlParameter();
               ParP7.ParameterName = "@P7";
               ParP7.SqlDbType = SqlDbType.Int;
               ParP7.Value = EvaluacionConstruida.P7;
               SqlCmd.Parameters.Add(ParP7);


               SqlParameter ParP8 = new SqlParameter();
               ParP8.ParameterName = "@P8";
               ParP8.SqlDbType = SqlDbType.Int;
               ParP8.Value = EvaluacionConstruida.P8;
               SqlCmd.Parameters.Add(ParP8);


               SqlParameter ParP9 = new SqlParameter();
               ParP9.ParameterName = "@P9";
               ParP9.SqlDbType = SqlDbType.Int;
               ParP9.Value = EvaluacionConstruida.P9;
               SqlCmd.Parameters.Add(ParP9);


               SqlParameter ParP10 = new SqlParameter();
               ParP10.ParameterName = "@P10";
               ParP10.SqlDbType = SqlDbType.Int;
               ParP10.Value = EvaluacionConstruida.P10;
               SqlCmd.Parameters.Add(ParP10);


               SqlParameter ParP11 = new SqlParameter();
               ParP11.ParameterName = "@P11";
               ParP11.SqlDbType = SqlDbType.Int;
               ParP11.Value = EvaluacionConstruida.P11;
               SqlCmd.Parameters.Add(ParP11);


               SqlParameter ParP12 = new SqlParameter();
               ParP12.ParameterName = "@P12";
               ParP12.SqlDbType = SqlDbType.Int;
               ParP12.Value = EvaluacionConstruida.P12;
               SqlCmd.Parameters.Add(ParP12);


               SqlParameter ParP13 = new SqlParameter();
               ParP13.ParameterName = "@P13";
               ParP13.SqlDbType = SqlDbType.Int;
               ParP13.Value = EvaluacionConstruida.P13;
               SqlCmd.Parameters.Add(ParP13);


               SqlParameter ParP14 = new SqlParameter();
               ParP14.ParameterName = "@P14";
               ParP14.SqlDbType = SqlDbType.Int;
               ParP14.Value = EvaluacionConstruida.P14;
               SqlCmd.Parameters.Add(ParP14);


               SqlParameter ParP15 = new SqlParameter();
               ParP15.ParameterName = "@P15";
               ParP15.SqlDbType = SqlDbType.Int;
               ParP15.Value = EvaluacionConstruida.P15;
               SqlCmd.Parameters.Add(ParP15);


               SqlParameter ParP16 = new SqlParameter();
               ParP16.ParameterName = "@P16";
               ParP16.SqlDbType = SqlDbType.Int;
               ParP16.Value = EvaluacionConstruida.P16;
               SqlCmd.Parameters.Add(ParP16);


               SqlParameter ParP17 = new SqlParameter();
               ParP17.ParameterName = "@P17";
               ParP17.SqlDbType = SqlDbType.Int;
               ParP17.Value = EvaluacionConstruida.P17;
               SqlCmd.Parameters.Add(ParP17);


               SqlParameter ParP18 = new SqlParameter();
               ParP18.ParameterName = "@P18";
               ParP18.SqlDbType = SqlDbType.Int;
               ParP18.Value = EvaluacionConstruida.P18;
               SqlCmd.Parameters.Add(ParP18);


               SqlParameter ParP19 = new SqlParameter();
               ParP19.ParameterName = "@P19";
               ParP19.SqlDbType = SqlDbType.Int;
               ParP19.Value = EvaluacionConstruida.P19;
               SqlCmd.Parameters.Add(ParP19);


               SqlParameter ParP20 = new SqlParameter();
               ParP20.ParameterName = "@P20";
               ParP20.SqlDbType = SqlDbType.Int;
               ParP20.Value = EvaluacionConstruida.P20;
               SqlCmd.Parameters.Add(ParP20);


               SqlParameter ParP21 = new SqlParameter();
               ParP21.ParameterName = "@P21";
               ParP21.SqlDbType = SqlDbType.Int;
               ParP21.Value = EvaluacionConstruida.P21;
               SqlCmd.Parameters.Add(ParP21);


               SqlParameter ParP22 = new SqlParameter();
               ParP22.ParameterName = "@P22";
               ParP22.SqlDbType = SqlDbType.Int;
               ParP22.Value = EvaluacionConstruida.P22;
               SqlCmd.Parameters.Add(ParP22);


               SqlParameter ParP23 = new SqlParameter();
               ParP23.ParameterName = "@P23";
               ParP23.SqlDbType = SqlDbType.Int;
               ParP23.Value = EvaluacionConstruida.P23;
               SqlCmd.Parameters.Add(ParP23);


               SqlParameter ParP24 = new SqlParameter();
               ParP24.ParameterName = "@P24";
               ParP24.SqlDbType = SqlDbType.Int;
               ParP24.Value = EvaluacionConstruida.P24;
               SqlCmd.Parameters.Add(ParP24);


               SqlParameter ParP25 = new SqlParameter();
               ParP25.ParameterName = "@P25";
               ParP25.SqlDbType = SqlDbType.Int;
               ParP25.Value = EvaluacionConstruida.P25;
               SqlCmd.Parameters.Add(ParP25);


               SqlParameter ParP26 = new SqlParameter();
               ParP26.ParameterName = "@P26";
               ParP26.SqlDbType = SqlDbType.Int;
               ParP26.Value = EvaluacionConstruida.P26;
               SqlCmd.Parameters.Add(ParP26);

               SqlParameter ParP27 = new SqlParameter();
               ParP27.ParameterName = "@P27";
               ParP27.SqlDbType = SqlDbType.Int;
               ParP27.Value = EvaluacionConstruida.P27;
               SqlCmd.Parameters.Add(ParP27);


               SqlParameter ParP28 = new SqlParameter();
               ParP28.ParameterName = "@P28";
               ParP28.SqlDbType = SqlDbType.Int;
               ParP28.Value = EvaluacionConstruida.P28;
               SqlCmd.Parameters.Add(ParP28);


               SqlParameter ParP29 = new SqlParameter();
               ParP29.ParameterName = "@P29";
               ParP29.SqlDbType = SqlDbType.Int;
               ParP29.Value = EvaluacionConstruida.P29;
               SqlCmd.Parameters.Add(ParP29);



               SqlParameter ParP30 = new SqlParameter();
               ParP30.ParameterName = "@P30";
               ParP30.SqlDbType = SqlDbType.Int;
               ParP30.Value = EvaluacionConstruida.P30;
               SqlCmd.Parameters.Add(ParP30);




               //Ejecutamos nuestro comando

               rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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


       public string Eliminar(DEvaluacionConstruida EvaluacionConstruida)
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
               SqlCmd.CommandText = "SP_DELETE_EVALUACION_CONSTRUIDA";
               SqlCmd.CommandType = CommandType.StoredProcedure;


               SqlParameter ParId = new SqlParameter();
               ParId.ParameterName = "@ID_EVAL_CONSTRUIDA";
               ParId.SqlDbType = SqlDbType.VarChar;
               ParId.Value = EvaluacionConstruida.IdEvalConstruida;
               SqlCmd.Parameters.Add(ParId);


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

       ArrayList ali = new ArrayList();
       public ArrayList TraerEvaluacionConstruida(DEvaluacionConstruida EvaluacionConstruida)
       {
           SqlConnection SqlCon = new SqlConnection();
           try
           {
               SqlCon.ConnectionString = Conexion.Cn;
               SqlCon.Open();
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "spmostrar_EvaluacionConstruidaPorID";
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlParameter ParTextoBuscar = new SqlParameter();
               ParTextoBuscar.ParameterName = "@textobuscar";
               ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
               ParTextoBuscar.Size = 50;
               ParTextoBuscar.Value = EvaluacionConstruida.Textobuscar;
               SqlCmd.Parameters.Add(ParTextoBuscar);

               SqlDataReader sdr = SqlCmd.ExecuteReader();
               while (sdr.Read())
               {
                   object[] values = new object[sdr.FieldCount];
                   sdr.GetValues(values);
                   ali.Add(values);
               }
           }
           catch (Exception)
           {
               ali = null;
           }
           return ali;
       }     
    }
}
