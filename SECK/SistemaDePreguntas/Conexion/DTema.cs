using CapaDatos.Vo;
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
        private int _Id;
        private int _Id_Competencia;
        private string _Enunciado;
        private bool _Incluir_En_Evaluacion;
        private string _TextoBuscar;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int Id_Competencia
        {
            get { return _Id_Competencia; }
            set { _Id_Competencia = value; }
        }

        public string Enunciado
        {
            get { return _Enunciado; }
            set { _Enunciado = value; }
        }

        public bool Incluir_En_Evaluacion
        {
            get { return _Incluir_En_Evaluacion; }
            set { _Incluir_En_Evaluacion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DTema()
        { }

        public DTema(int Id, int IdCompetencia, string Enunciado, bool IncluirEnEvaluacion, string textobuscar)
        {
            this._Id = Id;
            this._Id_Competencia = IdCompetencia;
            this._Enunciado = Enunciado;
            this._Incluir_En_Evaluacion = IncluirEnEvaluacion;
            this._TextoBuscar = textobuscar;
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
                ParNombreTema.Value = Tema.Enunciado;
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
                SqlCmd.CommandText = "SP_ACTUALIZAR_TEMA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTema = new SqlParameter();
                ParIdTema.ParameterName = "@ID";
                ParIdTema.SqlDbType = SqlDbType.Int;
                ParIdTema.Value = Tema.Id;
                SqlCmd.Parameters.Add(ParIdTema);

                SqlParameter ParIdCompetencia= new SqlParameter();
                ParIdCompetencia.ParameterName = "@ID_COMPETENCIA";
                ParIdCompetencia.SqlDbType = SqlDbType.Int;
                ParIdCompetencia.Value = Tema.Id_Competencia;
                SqlCmd.Parameters.Add(ParIdCompetencia);

                SqlParameter ParNombreTema = new SqlParameter();
                ParNombreTema.ParameterName = "@ENUNCIADO";
                ParNombreTema.SqlDbType = SqlDbType.VarChar;
                ParNombreTema.Size = -1;
                ParNombreTema.Value = Tema.Enunciado;
                SqlCmd.Parameters.Add(ParNombreTema);

                SqlParameter ParIncluirEnEvaluacion = new SqlParameter();
                ParIncluirEnEvaluacion.ParameterName = "@INCLUIR_EN_EVALUACION";
                ParIncluirEnEvaluacion.SqlDbType = SqlDbType.Bit;
                ParIncluirEnEvaluacion.Value = Tema.Incluir_En_Evaluacion;
                SqlCmd.Parameters.Add(ParIncluirEnEvaluacion);

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
                ParIdTema.Value = Tema.Id;
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
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_TEMA";
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
    
        public VoTema MostrarPorID(short ID)
        {
            VoTema resultado = null;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_TEMA_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID";
                ParID.SqlDbType = SqlDbType.SmallInt;
                ParID.Value = ID;
                SqlCmd.Parameters.Add(ParID);

                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    short aux1 = sdr.GetInt16(0);
                    short aux2 = sdr.GetInt16(1);
                    string aux3 = sdr.GetString(2);
                    bool aux4 = sdr.GetBoolean(3);
                    resultado = new VoTema(aux1, aux2, aux3, aux4);
                }
            }
            catch (Exception ex)
            {
                resultado = null;
            }
            return resultado;
        }
    }
}
