using CapaDatos.Vo;
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
        /// Consulta la respuesta como string, de la pregunta que se consulta
        /// </summary>
        /// <param name="ID_Pregunta">ID de la pregunta a consultar</param>
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

        public List<VoOpcionRespuesta> MostrarOpcionesPorID(short ID_Pregunta)
        {
            List<VoOpcionRespuesta> resultado = null;// new List<VoOpcionRespuesta>();
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
                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    short aux1 = sdr.GetInt16(0);
                    short aux2 = sdr.GetInt16(1);
                    string aux3 = sdr.GetString(2);
                    bool aux4 = sdr.GetBoolean(3);
                    resultado.Add(new VoOpcionRespuesta(aux1, aux2, aux3, aux4));
                }
            }
            catch (Exception)
            {
                resultado = null;
            }
            return resultado;
        }
    }
}
