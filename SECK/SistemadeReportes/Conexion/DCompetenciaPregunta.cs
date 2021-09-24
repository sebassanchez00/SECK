using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DCompetenciaPregunta
    {


        private int _Id;
        private int _Id_Competencia;
        private int _Id_Pregunta;
        private string _TextoBuscar;

        public int Id
        {


            get { return _Id; }
            set { _Id = value; }
        }


        public int IdCompetencia
        {

            get { return _Id_Competencia; }
            set { _Id_Competencia = value; }
        }

        public int IdPregunta
        {

            get { return _Id_Pregunta; }
            set { _Id_Pregunta = value; }
        }


        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public DCompetenciaPregunta()
      {


      }




        public DCompetenciaPregunta(int Id, int Id_Competencia, int Id_Pregunta, string textobuscar)
      {
          this.Id= Id;
          this.IdCompetencia = Id_Competencia;
          this.IdPregunta = Id_Pregunta;
          this.TextoBuscar = textobuscar;
      }

        public string Insertar(DCompetenciaPregunta Competenciapregunta)
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
                SqlCmd.CommandText = "SP_INSERTAR_COMPETENCIAPREGUNTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@ID_COMPETENCIA";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = Competenciapregunta.IdCompetencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                SqlParameter ParIdPregunta= new SqlParameter();
                ParIdPregunta.ParameterName = "@ID_PREGUNTA";
                ParIdPregunta.SqlDbType = SqlDbType.Int;
                ParIdPregunta.Value = Competenciapregunta.IdPregunta;
                SqlCmd.Parameters.Add(ParIdPregunta);

              


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

        public string Editar(DCompetenciaPregunta Competenciapregunta)
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
                SqlCmd.CommandText = "SP_UPDATE_COMPETENCIAPREGUNTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Competenciapregunta.Id;
                SqlCmd.Parameters.Add(ParId);


                SqlParameter ParIdCompetencia = new SqlParameter();
                ParIdCompetencia.ParameterName = "@ID_COMPETENCIA";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = Competenciapregunta.IdCompetencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                SqlParameter ParIdPregunta = new SqlParameter();
                ParIdPregunta.ParameterName = "@ID_PREGUNTA";
                ParIdPregunta.SqlDbType = SqlDbType.Int;
                ParIdPregunta.Value = Competenciapregunta.IdPregunta;
                SqlCmd.Parameters.Add(ParIdPregunta);



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


        public string Eliminar(DCompetenciaPregunta Competenciapregunta)
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
                SqlCmd.CommandText = "SP_DELETE_COMPETENCIAPREGUNTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Competenciapregunta.Id;
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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("PREGUNTAS");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_CompetenciaPregunta";
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




    }
}
