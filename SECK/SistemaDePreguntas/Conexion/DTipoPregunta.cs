using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DTipoPregunta
    {

      private int _Id_TipoPregunta;
      private string _TipoPregunta;
      private string _TextoBuscar;   

      public int Id_TipoPregunta
      {


          get { return _Id_TipoPregunta; }
          set { _Id_TipoPregunta = value; }
      }


      public string TipoPregunta
      {

          get { return _TipoPregunta; }
          set{ _TipoPregunta = value;}
          }

      public string TextoBuscar
      {
          get { return _TextoBuscar; }
          set { _TextoBuscar = value; }
      }

      public DTipoPregunta()
      {


      }

      public DTipoPregunta(int IdTipoPregunta, string TipoPregunta, string textobuscar)
      {
          this.Id_TipoPregunta = Id_TipoPregunta;
          this.TipoPregunta = TipoPregunta;
          this.TextoBuscar = textobuscar;
      }

      public string Insertar(DTipoPregunta TipoPregunta)
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
              SqlCmd.CommandText = "SP_INSERTAR_TIPO_PREGUNTA";
              SqlCmd.CommandType = CommandType.StoredProcedure;

       

              SqlParameter ParNombreTipoPregunta = new SqlParameter();
              ParNombreTipoPregunta.ParameterName = "@NOMBRE_TIPO_PREGUNTA";
              ParNombreTipoPregunta.SqlDbType = SqlDbType.VarChar;
              ParNombreTipoPregunta.Size = 50;
              ParNombreTipoPregunta.Value = TipoPregunta.TipoPregunta;
              SqlCmd.Parameters.Add(ParNombreTipoPregunta);


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

      public string Editar(DTipoPregunta TipoPregunta)
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
              SqlCmd.CommandText = "SP_UPDATE_TIPO_PREGUNTA";
              SqlCmd.CommandType = CommandType.StoredProcedure;

           

                  SqlParameter ParIdTipoPregunta = new SqlParameter();
                  ParIdTipoPregunta.ParameterName = "  @ID_TIPO_PREGUNTA";
                ParIdTipoPregunta.SqlDbType = SqlDbType.Int;
                ParIdTipoPregunta.Value = TipoPregunta.Id_TipoPregunta;
                SqlCmd.Parameters.Add(ParIdTipoPregunta);


              SqlParameter ParNombreTipoPregunta = new SqlParameter();
              ParNombreTipoPregunta.ParameterName = "@NOMBRE_TIPO_PREGUNTA";
              ParNombreTipoPregunta.SqlDbType = SqlDbType.VarChar;
              ParNombreTipoPregunta.Value = TipoPregunta.TipoPregunta;
              SqlCmd.Parameters.Add(ParNombreTipoPregunta);

             


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


      public string Eliminar(DTipoPregunta TipoPregunta)
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
              SqlCmd.CommandText = "SP_DELETE_TIPO_PREGUNTA";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParIdTema = new SqlParameter();
              ParIdTema.ParameterName = "@ID_TEMA";
              ParIdTema.SqlDbType = SqlDbType.Int;
              ParIdTema.Value = TipoPregunta.Id_TipoPregunta;
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
          DataTable DtResultado = new DataTable("TIPOPREGUNTA");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_TipoPregunta";
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


      public DataTable BuscarNombre(DTipoPregunta TipoPregunta)
        {
            DataTable DtResultado = new DataTable("TIPOPREGUNTA");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_TipoPregunta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TipoPregunta.TextoBuscar;
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
