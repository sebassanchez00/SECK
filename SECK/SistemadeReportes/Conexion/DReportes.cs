using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public  class DReportes
    {

       private string _IdReporte;
       private string _cedulas;
       private DateTime _Fecha;
       private int _Des1;
       private int _Des2;
       private int _Des3;
       private int _Des4;
       private int _Des5;
       private int _Des6;
       private int _Des7;
       private int _Des8;
       private int  _Des9;
       private int _Des10;
       private int _Des11;

       private string _Instructor;

       private string _Obser1;
       private string _Obser2;
       private string _Obser3;
       private string _Obser4;
       private string _Obser5;
       private string _Obser6;
       private string _Obser7;
       private string _Obser8;
       private string _Obser9;
       private string _Obser10;
       private string _Obser11;
       private string _Observacion;


       public string Instructor
       {
           get { return _Instructor; }
           set { _Instructor=value;}

       }

       public string IdReporte
       {

            get { return _IdReporte; }
           set { _IdReporte = value; }
       }

       public string Cedula
       {


           get { return _cedulas; }
           set { _cedulas = value; }
       }


       public DateTime Fecha
       {

           get
           {
               return _Fecha;


           }
           set
           {
               _Fecha = value;
           }

       }

       public int Des1
       {
           get { return _Des1; }
           set { _Des1 = value; }
       }

       public int Des2
       {
           get { return _Des2; }
           set { _Des2 = value; }
       }

       public int Des3
       {
           get { return _Des3; }
           set { _Des3 = value; }
       }

       public int Des4
       {
           get { return _Des4; }
           set { _Des4 = value; }
       }

       public int Des5
       {
           get { return _Des5; }
           set { _Des5 = value; }
       }


       public int Des6
       {
           get { return _Des6; }
           set { _Des6 = value; }
       }


       public int Des7
       {
           get { return _Des7; }
           set { _Des7 = value; }
       }


       public int Des8
       {
           get { return _Des8; }
           set { _Des8= value; }
       }


       public int Des9
       {
           get { return _Des9; }
           set { _Des9 = value; }
       }


       public int Des10
       {
           get { return _Des10; }
           set { _Des10 = value; }
       }

       public int Des11
       {
           get { return _Des11; }
           set { _Des11 = value; }
       }

       public string Obser1
       {
           get { return _Obser1; }
           set { _Obser1 = value; }
       }

       public string Obser2
       {
           get { return _Obser2; }
           set { _Obser2 = value; }
       }


       public string Obser3
       {
           get { return _Obser3; }
           set { _Obser3 = value; }
       }


       public string Obser4
       {
           get { return _Obser4; }
           set { _Obser4 = value; }
       }


       public string Obser5
       {
           get { return _Obser5; }
           set { _Obser5 = value; }
       }


       public string Obser6
       {
           get { return _Obser6; }
           set { _Obser6 = value; }
       }


       public string Obser7
       {
           get { return _Obser7; }
           set { _Obser7 = value; }
       }


       public string Obser8
       {
           get { return _Obser8; }
           set { _Obser8 = value; }
       }


       public string Obser9
       {
           get { return _Obser9; }
           set { _Obser9 = value; }
       }


       public string Obser10
       {
           get { return _Obser10; }
           set { _Obser10 = value; }
       }


       public string Obser11
       {
           get { return _Obser11; }
           set { _Obser11 = value; }
       }


       public string Observacion
       {
           get { return _Observacion; }
           set { _Observacion = value; }
       }


       public DReportes()
       {



       }

       public DReportes(string idreporte,string cedula,DateTime fecha,int des1,int des2 , int des3, int des4, int des5, int des6, int des7,int des8 , int des9,int des10, int des11,string obser1,string obser2,string obser3,string obser4,string obser5,string obser6,string obser7,string obser8,string obser9,string obser10,string obser11,string observacion,string instructor)
       {
           this.IdReporte = idreporte;
           this.Cedula = cedula;
           this.Fecha = fecha;
           this.Des1 = des1;
           this.Des2 = des2;
           this.Des3 = des3;
           this.Des4 = des4;
           this.Des5 = des5;
           this.Des6 = des6;
           this.Des7 = des7;
           this.Des8 = des8;
           this.Des9 = des9;
           this.Des10 = des10;
           this.Des11 = des11;
           this.Obser1 = obser1;
           this.Obser2 = obser2;
           this.Obser3 = obser3;
           this.Obser4 = obser4;
           this.Obser5 = obser5;
           this.Obser6 = obser6;
           this.Obser7= obser7;
           this.Obser8 = obser8;
           this.Obser9 = obser9;
           this.Obser10 = obser10;
           this.Obser11 = obser11;
           this.Observacion = observacion;

           this.Instructor = instructor;


       }

       public string Insertar(DReportes Reportes)
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
               SqlCmd.CommandText = "SP_INSERTAR_REPORTES";
               SqlCmd.CommandType = CommandType.StoredProcedure;

            

               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = Reportes.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter PaRcedulas = new SqlParameter();
               PaRcedulas.ParameterName = "@CEDULAS";
               PaRcedulas.SqlDbType = SqlDbType.VarChar;
               PaRcedulas.Value = Reportes.Cedula;
               SqlCmd.Parameters.Add(PaRcedulas);

               SqlParameter ParFecha = new SqlParameter();
               ParFecha.ParameterName = "@FECHA";
               ParFecha.SqlDbType = SqlDbType.Date;
               ParFecha.Value = Reportes.Fecha;
               SqlCmd.Parameters.Add(ParFecha);

               SqlParameter ParDes1 = new SqlParameter();
               ParDes1.ParameterName = "@DES_1";
               ParDes1.SqlDbType = SqlDbType.Int;
               ParDes1.Value = Reportes.Des1;
               SqlCmd.Parameters.Add(ParDes1);


               SqlParameter ParDes2 = new SqlParameter();
               ParDes2.ParameterName = "@DES_2";
               ParDes2.SqlDbType = SqlDbType.Int;
               ParDes2.Value = Reportes.Des2;
               SqlCmd.Parameters.Add(ParDes2);

               SqlParameter ParDes3 = new SqlParameter();
               ParDes3.ParameterName = "@DES_3";
               ParDes3.SqlDbType = SqlDbType.Int;
               ParDes3.Value = Reportes.Des4;
               SqlCmd.Parameters.Add(ParDes3);


               SqlParameter ParDes4 = new SqlParameter();
               ParDes4.ParameterName = "@DES_4";
               ParDes4.SqlDbType = SqlDbType.Int;
               ParDes4.Value = Reportes.Des4;
               SqlCmd.Parameters.Add(ParDes4);

               SqlParameter ParDes5 = new SqlParameter();
               ParDes5.ParameterName = "@DES_5";
               ParDes5.SqlDbType = SqlDbType.Int;
               ParDes5.Value = Reportes.Des5;
               SqlCmd.Parameters.Add(ParDes5);

               SqlParameter ParDes6 = new SqlParameter();
               ParDes6.ParameterName = "@DES_6";
               ParDes6.SqlDbType = SqlDbType.Int;
               ParDes6.Value = Reportes.Des6;
               SqlCmd.Parameters.Add(ParDes6);

               SqlParameter ParDes7 = new SqlParameter();
               ParDes7.ParameterName = "@DES_7";
               ParDes7.SqlDbType = SqlDbType.Int;
               ParDes7.Value = Reportes.Des7;
               SqlCmd.Parameters.Add(ParDes7);

             

               SqlParameter ParDes8 = new SqlParameter();
               ParDes8.ParameterName = "@DES_8";
               ParDes8.SqlDbType = SqlDbType.Int;
               ParDes8.Value = Reportes.Des8;
               SqlCmd.Parameters.Add(ParDes8);

               SqlParameter ParDes9 = new SqlParameter();
               ParDes9.ParameterName = "@DES_9";
               ParDes9.SqlDbType = SqlDbType.Int;
               ParDes9.Value = Reportes.Des9;
               SqlCmd.Parameters.Add(ParDes9);

               SqlParameter ParDes10 = new SqlParameter();
               ParDes10.ParameterName = "@DES_10";
               ParDes10.SqlDbType = SqlDbType.Int;
               ParDes10.Value = Reportes.Des10;
               SqlCmd.Parameters.Add(ParDes10);

               SqlParameter ParDes11 = new SqlParameter();
               ParDes11.ParameterName = "@DES_11";
               ParDes11.SqlDbType = SqlDbType.Int;
               ParDes11.Value = Reportes.Des11;
               SqlCmd.Parameters.Add(ParDes11);

               SqlParameter Parobser1 = new SqlParameter();
               Parobser1.ParameterName = "@OBSER1";
               Parobser1.SqlDbType = SqlDbType.VarChar;
               Parobser1.Value = Reportes.Obser1;
               SqlCmd.Parameters.Add(Parobser1);

               SqlParameter Parobser2 = new SqlParameter();
               Parobser2.ParameterName = "@OBSER2";
               Parobser2.SqlDbType = SqlDbType.VarChar;
               Parobser2.Value = Reportes.Obser2;
               SqlCmd.Parameters.Add(Parobser2);

               SqlParameter Parobser3 = new SqlParameter();
               Parobser3.ParameterName = "@OBSER3";
               Parobser3.SqlDbType = SqlDbType.VarChar;
               Parobser3.Value = Reportes.Obser3;
               SqlCmd.Parameters.Add(Parobser3);

               SqlParameter Parobser4 = new SqlParameter();
               Parobser4.ParameterName = "@OBSER4";
               Parobser4.SqlDbType = SqlDbType.VarChar;
               Parobser4.Value = Reportes.Obser4;
               SqlCmd.Parameters.Add(Parobser4);


               SqlParameter Parobser5 = new SqlParameter();
               Parobser5.ParameterName = "@OBSER5";
               Parobser5.SqlDbType = SqlDbType.VarChar;
               Parobser5.Value = Reportes.Obser5;
               SqlCmd.Parameters.Add(Parobser5);


               SqlParameter Parobser6 = new SqlParameter();
               Parobser6.ParameterName = "@OBSER6";
               Parobser6.SqlDbType = SqlDbType.VarChar;
               Parobser6.Value = Reportes.Obser6;
               SqlCmd.Parameters.Add(Parobser6);


               SqlParameter Parobser7 = new SqlParameter();
               Parobser7.ParameterName = "@OBSER7";
               Parobser7.SqlDbType = SqlDbType.VarChar;
               Parobser7.Value = Reportes.Obser7;
               SqlCmd.Parameters.Add(Parobser7);


               SqlParameter Parobser8 = new SqlParameter();
               Parobser8.ParameterName = "@OBSER8";
               Parobser8.SqlDbType = SqlDbType.VarChar;
               Parobser8.Value = Reportes.Obser8;
               SqlCmd.Parameters.Add(Parobser8);


              

               SqlParameter Parobser9 = new SqlParameter();
               Parobser9.ParameterName = "@OBSER9";
               Parobser9.SqlDbType = SqlDbType.VarChar;
               Parobser9.Value = Reportes.Obser9;
               SqlCmd.Parameters.Add(Parobser9);


               SqlParameter Parobser10 = new SqlParameter();
               Parobser10.ParameterName = "@OBSER10";
               Parobser10.SqlDbType = SqlDbType.VarChar;
               Parobser10.Value = Reportes.Obser10;
               SqlCmd.Parameters.Add(Parobser10);


               SqlParameter Parobser11 = new SqlParameter();
               Parobser11.ParameterName = "@OBSER11";
               Parobser11.SqlDbType = SqlDbType.VarChar;
               Parobser11.Value = Reportes.Obser11;
               SqlCmd.Parameters.Add(Parobser11);

               SqlParameter Parobservacion = new SqlParameter();
               Parobservacion.ParameterName = "@OBS";
               Parobservacion.SqlDbType = SqlDbType.VarChar;
               Parobservacion.Value = Reportes.Observacion;
               SqlCmd.Parameters.Add(Parobservacion);




               SqlParameter ParInstructor = new SqlParameter();
               ParInstructor.ParameterName = "@INSTRUCTOR";
               ParInstructor.SqlDbType = SqlDbType.VarChar;
               ParInstructor.Value = Reportes.Instructor;
               SqlCmd.Parameters.Add(ParInstructor);

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


       public string Editar(DReportes Reportes)
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
               SqlCmd.CommandText = "SP_UPDATE_REPORTES";
               SqlCmd.CommandType = CommandType.StoredProcedure;



               SqlParameter ParIdReporte = new SqlParameter();
               ParIdReporte.ParameterName = "@ID_REPORTE";
               ParIdReporte.SqlDbType = SqlDbType.VarChar;
               ParIdReporte.Value = Reportes.IdReporte;
               SqlCmd.Parameters.Add(ParIdReporte);

               SqlParameter PaRcedulas = new SqlParameter();
               PaRcedulas.ParameterName = "@CEDULAS";
               PaRcedulas.SqlDbType = SqlDbType.VarChar;
               PaRcedulas.Value = Reportes.Cedula;
               SqlCmd.Parameters.Add(PaRcedulas);

               SqlParameter ParFecha = new SqlParameter();
               ParFecha.ParameterName = "@FECHA";
               ParFecha.SqlDbType = SqlDbType.Date;
               ParFecha.Value = Reportes.Fecha;
               SqlCmd.Parameters.Add(ParFecha);

               SqlParameter ParDes1 = new SqlParameter();
               ParDes1.ParameterName = "@DES_1";
               ParDes1.SqlDbType = SqlDbType.Int;
               ParDes1.Value = Reportes.Des1;
               SqlCmd.Parameters.Add(ParDes1);


               SqlParameter ParDes2 = new SqlParameter();
               ParDes2.ParameterName = "@DES_2";
               ParDes2.SqlDbType = SqlDbType.Int;
               ParDes2.Value = Reportes.Des2;
               SqlCmd.Parameters.Add(ParDes2);

               SqlParameter ParDes3 = new SqlParameter();
               ParDes3.ParameterName = "@DES_3";
               ParDes3.SqlDbType = SqlDbType.Int;
               ParDes3.Value = Reportes.Des4;
               SqlCmd.Parameters.Add(ParDes3);


               SqlParameter ParDes4 = new SqlParameter();
               ParDes4.ParameterName = "@DES_4";
               ParDes4.SqlDbType = SqlDbType.Int;
               ParDes4.Value = Reportes.Des4;
               SqlCmd.Parameters.Add(ParDes4);

               SqlParameter ParDes5 = new SqlParameter();
               ParDes5.ParameterName = "@DES_5";
               ParDes5.SqlDbType = SqlDbType.Int;
               ParDes5.Value = Reportes.Des5;
               SqlCmd.Parameters.Add(ParDes5);

               SqlParameter ParDes6 = new SqlParameter();
               ParDes6.ParameterName = "@DES_6";
               ParDes6.SqlDbType = SqlDbType.Int;
               ParDes6.Value = Reportes.Des6;
               SqlCmd.Parameters.Add(ParDes6);

               SqlParameter ParDes7 = new SqlParameter();
               ParDes7.ParameterName = "@DES_7";
               ParDes7.SqlDbType = SqlDbType.Int;
               ParDes7.Value = Reportes.Des7;
               SqlCmd.Parameters.Add(ParDes7);



               SqlParameter ParDes8 = new SqlParameter();
               ParDes8.ParameterName = "@DES_8";
               ParDes8.SqlDbType = SqlDbType.Int;
               ParDes8.Value = Reportes.Des8;
               SqlCmd.Parameters.Add(ParDes8);

               SqlParameter ParDes9 = new SqlParameter();
               ParDes9.ParameterName = "@DES_9";
               ParDes9.SqlDbType = SqlDbType.Int;
               ParDes9.Value = Reportes.Des9;
               SqlCmd.Parameters.Add(ParDes9);

               SqlParameter ParDes10 = new SqlParameter();
               ParDes10.ParameterName = "@DES_10";
               ParDes10.SqlDbType = SqlDbType.Int;
               ParDes10.Value = Reportes.Des10;
               SqlCmd.Parameters.Add(ParDes10);

               SqlParameter ParDes11 = new SqlParameter();
               ParDes11.ParameterName = "@DES_11";
               ParDes11.SqlDbType = SqlDbType.Int;
               ParDes11.Value = Reportes.Des11;
               SqlCmd.Parameters.Add(ParDes11);

               SqlParameter Parobser1 = new SqlParameter();
               Parobser1.ParameterName = "@OBSER1";
               Parobser1.SqlDbType = SqlDbType.VarChar;
               Parobser1.Value = Reportes.Obser1;
               SqlCmd.Parameters.Add(Parobser1);

               SqlParameter Parobser2 = new SqlParameter();
               Parobser2.ParameterName = "@OBSER2";
               Parobser2.SqlDbType = SqlDbType.VarChar;
               Parobser2.Value = Reportes.Obser2;
               SqlCmd.Parameters.Add(Parobser2);

               SqlParameter Parobser3 = new SqlParameter();
               Parobser3.ParameterName = "@OBSER3";
               Parobser3.SqlDbType = SqlDbType.VarChar;
               Parobser3.Value = Reportes.Obser3;
               SqlCmd.Parameters.Add(Parobser3);

               SqlParameter Parobser4 = new SqlParameter();
               Parobser4.ParameterName = "@OBSER4";
               Parobser4.SqlDbType = SqlDbType.VarChar;
               Parobser4.Value = Reportes.Obser4;
               SqlCmd.Parameters.Add(Parobser4);


               SqlParameter Parobser5 = new SqlParameter();
               Parobser5.ParameterName = "@OBSER5";
               Parobser5.SqlDbType = SqlDbType.VarChar;
               Parobser5.Value = Reportes.Obser5;
               SqlCmd.Parameters.Add(Parobser5);


               SqlParameter Parobser6 = new SqlParameter();
               Parobser6.ParameterName = "@OBSER6";
               Parobser6.SqlDbType = SqlDbType.VarChar;
               Parobser6.Value = Reportes.Obser6;
               SqlCmd.Parameters.Add(Parobser6);


               SqlParameter Parobser7 = new SqlParameter();
               Parobser7.ParameterName = "@OBSER7";
               Parobser7.SqlDbType = SqlDbType.VarChar;
               Parobser7.Value = Reportes.Obser7;
               SqlCmd.Parameters.Add(Parobser7);


               SqlParameter Parobser8 = new SqlParameter();
               Parobser8.ParameterName = "@OBSER8";
               Parobser8.SqlDbType = SqlDbType.VarChar;
               Parobser8.Value = Reportes.Obser8;
               SqlCmd.Parameters.Add(Parobser8);




               SqlParameter Parobser9 = new SqlParameter();
               Parobser9.ParameterName = "@OBSER9";
               Parobser9.SqlDbType = SqlDbType.VarChar;
               Parobser9.Value = Reportes.Obser9;
               SqlCmd.Parameters.Add(Parobser9);


               SqlParameter Parobser10 = new SqlParameter();
               Parobser10.ParameterName = "@OBSER10";
               Parobser10.SqlDbType = SqlDbType.VarChar;
               Parobser10.Value = Reportes.Obser10;
               SqlCmd.Parameters.Add(Parobser10);


               SqlParameter Parobser11 = new SqlParameter();
               Parobser11.ParameterName = "@OBSER11";
               Parobser11.SqlDbType = SqlDbType.VarChar;
               Parobser11.Value = Reportes.Obser11;
               SqlCmd.Parameters.Add(Parobser11);

               SqlParameter Parobservacion = new SqlParameter();
               Parobservacion.ParameterName = "@OBS";
               Parobservacion.SqlDbType = SqlDbType.VarChar;
               Parobservacion.Value = Reportes.Observacion;
               SqlCmd.Parameters.Add(Parobservacion);




               SqlParameter ParInstructor = new SqlParameter();
               ParInstructor.ParameterName = "@INSTRUCTOR";
               ParInstructor.SqlDbType = SqlDbType.VarChar;
               ParInstructor.Value = Reportes.Instructor;
               SqlCmd.Parameters.Add(ParInstructor);

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

       public int BuscarRegistroReportes(DReportes Reportes)
       {
           int rpta = 0;
           SqlConnection SqlCon = new SqlConnection();

           try
           {

               SqlCon.ConnectionString = Conexion.Cn;
               SqlCon.Open();
               //Establecer el Comando
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "spMostrarCantidadRegistrosReportes";
               SqlCmd.CommandType = CommandType.StoredProcedure;


               SqlParameter ParTextoBuscar = new SqlParameter();
               ParTextoBuscar.ParameterName = "@textobuscar";
               ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
               ParTextoBuscar.Size = 50;
               ParTextoBuscar.Value = Reportes.Cedula;
               SqlCmd.Parameters.Add(ParTextoBuscar);



               rpta = int.Parse(SqlCmd.ExecuteScalar().ToString());


           }
           catch (Exception ex)
           {
               rpta = 2;
           }
           finally
           {
               if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
           }
           return rpta;
       }



       public DataSet BuscarReporte(DReportes Reportes)
       {
           DataTable DtResultado = new DataTable("V_Reporte");
           SqlConnection SqlCon = new SqlConnection();
           DataSet ds = new DataSet();
           try
           {
               SqlCon.ConnectionString = Conexion.Cn;
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.Connection = SqlCon;
               SqlCmd.CommandText = "spmostrar_ConsultarVistaReportes";
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlParameter ParTextoBuscar = new SqlParameter();
               ParTextoBuscar.ParameterName = "@textobuscar";
               ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
             
               ParTextoBuscar.Value = Reportes.IdReporte;
               SqlCmd.Parameters.Add(ParTextoBuscar);

               SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
               SqlDat.Fill(ds,"V_Reporte");

           }
           catch (Exception ex)
           {
               ds = null;
           }
           return ds;

       }











    }
}
