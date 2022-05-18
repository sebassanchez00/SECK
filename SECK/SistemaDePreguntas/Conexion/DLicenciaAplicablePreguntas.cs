using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DLicenciaAplicablePreguntas
    {
        public DLicenciaAplicablePreguntas()
        { }

        /// <summary>
        /// Inserta un elemento VoLicenciaAplicablePreguntas en la tabla TME_LICENCIA_APLICABLE_PREGUNTAS
        /// </summary>
        /// <param name="Par">Elemento VoLicenciaAplicablePreguntas a insertar</param>
        public void Insertar(VoLicenciaAplicablePreguntas Par)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_LICENCIA_APLICABLE_PREGUNTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDEval = new SqlParameter();
                ParIDEval.ParameterName = "@ID_PREGUNTA";
                ParIDEval.SqlDbType = SqlDbType.SmallInt;
                ParIDEval.Value = Par.ID_Pregunta;
                SqlCmd.Parameters.Add(ParIDEval);

                SqlParameter ParIDTema = new SqlParameter();
                ParIDTema.ParameterName = "@ID_LICENCIA";
                ParIDTema.SqlDbType = SqlDbType.SmallInt;
                ParIDTema.Value = Par.ID_Tipo_Licencia;
                SqlCmd.Parameters.Add(ParIDTema);

                string rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        /// <summary>
        /// Retorna lista de VoLicenciaAplicablePreguntas que coinciden con ID_Licencia
        /// </summary>
        /// <param name="IDPregunta">Id del tipo licencia que se consulta</param>
        /// <returns></returns>
        public List<VoLicenciaAplicablePreguntas> Mostrar_PorIDTipoLicencia(short IDLicencia)
        {
            List<VoLicenciaAplicablePreguntas> resultado = new List<VoLicenciaAplicablePreguntas>();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open(); 

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_POR_TIPO_LICENCIA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDBuscar = new SqlParameter();
                ParIDBuscar.ParameterName = "@ID_TIPO_LICENCIA";
                ParIDBuscar.SqlDbType = SqlDbType.SmallInt;
                ParIDBuscar.Value = IDLicencia;
                SqlCmd.Parameters.Add(ParIDBuscar);

                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    short aux1 = sdr.GetInt16(1);
                    short aux2 = sdr.GetInt16(2);
                    resultado.Add(
                        new VoLicenciaAplicablePreguntas(aux1, aux2)
                        );
                }
            }
            catch (Exception ex)
            {
                resultado = null;
            }
            return resultado;
        }

        /// <summary>
        /// Devuleve todos los registros de tabla TME_LICENCIA_APLICABLE_PREGUNTAS
        /// </summary>
        /// <returns></returns>
        public List<VoLicenciaAplicablePreguntas> Mostrar_Todas()
        {
            List<VoLicenciaAplicablePreguntas> resultado = new List<VoLicenciaAplicablePreguntas>();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_RELACION_TIPO_LICENCIA_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    short aux1 = sdr.GetInt16(0);
                    short aux2 = sdr.GetInt16(1);
                    resultado.Add(
                        new VoLicenciaAplicablePreguntas(aux1, aux2)
                        );
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
