using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DOpcionesRespuesta
    {
        private short _ID;
        private short _ID_Pregunta;
        private string _Enunciado;
        private bool _EsCorrecto;

        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public short ID_Pregunta
        {
            get { return _ID_Pregunta; }
            set { _ID_Pregunta = value; }
        }
        public string Enunciado
        {
            get { return _Enunciado; }
            set { _Enunciado = value; }
        }
        public bool EsCorrecto
        {
            get { return _EsCorrecto; }
            set { _EsCorrecto = value; }
        }

        public DOpcionesRespuesta()
        { }
        public DOpcionesRespuesta(short ID, short ID_Pregunta, string Enunciado, bool EsCorrecto)
        {
            this._ID = ID;
            this._ID_Pregunta = ID_Pregunta;
            this._Enunciado = Enunciado;
            this._EsCorrecto = EsCorrecto;
        }

        /// <summary>
        /// Trae las opciones de la pregunta desde la tabla TME_OPCION_RESPUESTA. Retorna Null si hay falla
        /// </summary>
        /// <param name="ID">ID de la pregunta </param>
        /// <returns></returns>
        public DataTable MostrarPorID(short ID)
        {
            DataTable dt = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_OPCIONES_PREGUNTA_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID_PREGUNTA";
                ParId.SqlDbType = SqlDbType.SmallInt;
                ParId.Value = ID;

                SqlCmd.Parameters.Add(ParId);

                SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
    
        /// <summary>
        /// Consulta la respuesta de la pregunta que se consulta
        /// </summary>
        /// <param name="ID_Pregunta"></param>
        /// <returns></returns>
        public string MostrarOpcionCorrecta(short ID_Pregunta)
        {
            string rpta;
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_OPCIONES_PREGUNTA_LA_CORRECTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDPregunta = new SqlParameter();
                ParIDPregunta.ParameterName = "@ID_PREGUNTA";
                ParIDPregunta.SqlDbType = SqlDbType.SmallInt;
                ParIDPregunta.Value = ID_Pregunta;
                SqlCmd.Parameters.Add(ParIDPregunta);

                rpta = SqlCmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                rpta = "Error";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
    }
}
