using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public class DTema
    {

        private int _Id_Tema;
        private string _NombreTema;
        private string _TextoBuscar;

        public int Id_Tema
        {


            get { return _Id_Tema; }
            set { _Id_Tema = value; }
        }


        public string NombreTema
        {

            get { return _NombreTema; }
            set { _NombreTema = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

          public DTema()
      {


      }

      public DTema(int IdTema, string NombreTema, string textobuscar)
      {
          this.Id_Tema = Id_Tema;
          this.NombreTema = NombreTema;
          this.TextoBuscar = textobuscar;
      }


      public string Insertar(DTema Tema)
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
              SqlCmd.CommandText = "SP_INSERTAR_TEMA";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParNombreTema = new SqlParameter();
              ParNombreTema.ParameterName = "@NOMBRE_TEMA";
              ParNombreTema.SqlDbType = SqlDbType.VarChar;
              ParNombreTema.Size = 50;
              ParNombreTema.Value = Tema.NombreTema;
              SqlCmd.Parameters.Add(ParNombreTema);


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

      public string Editar(DTema Tema)
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
              SqlCmd.CommandText = "SP_UPDATE_TEMA";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParIdTema = new SqlParameter();
              ParIdTema.ParameterName = "@ID_TEMA";
              ParIdTema.SqlDbType = SqlDbType.Int;
              ParIdTema.Value = Tema.Id_Tema;
              SqlCmd.Parameters.Add(ParIdTema);


              SqlParameter ParNombreTema = new SqlParameter();
              ParNombreTema.ParameterName = "@NOMBRE_TEMA";
              ParNombreTema.SqlDbType = SqlDbType.VarChar;
              ParNombreTema.Value = Tema.NombreTema;
              SqlCmd.Parameters.Add(ParNombreTema);




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

      public string Eliminar(DTema Tema)
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
              SqlCmd.CommandText = "SP_DELETE_TEMA";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParIdTema = new SqlParameter();
              ParIdTema.ParameterName = "@ID_TEMA";
              ParIdTema.SqlDbType = SqlDbType.Int;
              ParIdTema.Value = Tema.Id_Tema;
              SqlCmd.Parameters.Add(ParIdTema);


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

      public DataTable Mostrar()
      {
          DataTable DtResultado = new DataTable("TEMA");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_Temas";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
              SqlDat.Fill(DtResultado);

          }
          catch (Exception ex)
          {
              DtResultado = null;
          }
          return DtResultado;

      }


      public DataTable BuscarNombre(DTema Tema)
      {
          DataTable DtResultado = new DataTable("TEMA");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spbuscar_Tema_nombre";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParTextoBuscar = new SqlParameter();
              ParTextoBuscar.ParameterName = "@textobuscar";
              ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
              ParTextoBuscar.Size = 50;
              ParTextoBuscar.Value = Tema.TextoBuscar;
              SqlCmd.Parameters.Add(ParTextoBuscar);

              SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
              SqlDat.Fill(DtResultado);
           
          }
          catch (Exception ex)
          {
              DtResultado = null;
          }
          return DtResultado;

      }


    }
}
