using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DCompetencias
    {
         private int _Id_Competencia;
        private string _NombreCompetencia;
        private string _TextoBuscar;

        public int Id_Competencia
        {


            get { return _Id_Competencia; }
            set { _Id_Competencia = value; }
        }


        public string NombreCompetencia
        {

            get { return _NombreCompetencia; }
            set { _NombreCompetencia = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

          public DCompetencias()
      {


      }

      public DCompetencias(int IdCompetencia, string NombreCompetencia, string textobuscar)
      {
          this.Id_Competencia= Id_Competencia;
          this.NombreCompetencia = NombreCompetencia;
          this.TextoBuscar = textobuscar;
      }


      public string Insertar(DCompetencias Competencia)
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
              SqlCmd.CommandText = "SP_INSERTAR_COMPETENCIAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParNombreCompetencia = new SqlParameter();
              ParNombreCompetencia.ParameterName = "@NOMBRE_COMPETENCIA";
              ParNombreCompetencia.SqlDbType = SqlDbType.VarChar;
              ParNombreCompetencia.Size = 50;
              ParNombreCompetencia.Value = Competencia.NombreCompetencia;
              SqlCmd.Parameters.Add(ParNombreCompetencia);


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

      public string Editar(DCompetencias Competencia)
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
              SqlCmd.CommandText = "SP_UPDATE_COMPETENCIAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParIdCompetencia = new SqlParameter();
              ParIdCompetencia.ParameterName = "@ID_COMPETENCIA";
              ParIdCompetencia.SqlDbType = SqlDbType.Int;
              ParIdCompetencia.Value = Competencia.Id_Competencia;
              SqlCmd.Parameters.Add(ParIdCompetencia);


                SqlParameter ParNombreCompetencia = new SqlParameter();
              ParNombreCompetencia.ParameterName = "@NOMBRE_COMPETENCIA";
              ParNombreCompetencia.SqlDbType = SqlDbType.VarChar;
              ParNombreCompetencia.Size = 50;
              ParNombreCompetencia.Value = Competencia.NombreCompetencia;
              SqlCmd.Parameters.Add(ParNombreCompetencia);




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

      public string Eliminar(DCompetencias Competencia)
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
              SqlCmd.CommandText = "SP_DELETE_COMPETENCIAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;

             SqlParameter ParIdCompetencia = new SqlParameter();
              ParIdCompetencia.ParameterName = "@ID_COMPETENCIA";
              ParIdCompetencia.SqlDbType = SqlDbType.Int;
              ParIdCompetencia.Value = Competencia.Id_Competencia;
              SqlCmd.Parameters.Add(ParIdCompetencia);


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
          DataTable DtResultado = new DataTable("COMPETENCIAS");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_Competencias";
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


      public DataTable BuscarNombre(DCompetencias competencia)
      {
          DataTable DtResultado = new DataTable("COMPETENCIAS");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spbuscar_Competencia_nombre";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParTextoBuscar = new SqlParameter();
              ParTextoBuscar.ParameterName = "@textobuscar";
              ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
              ParTextoBuscar.Size = 50;
              ParTextoBuscar.Value = competencia.TextoBuscar;
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

