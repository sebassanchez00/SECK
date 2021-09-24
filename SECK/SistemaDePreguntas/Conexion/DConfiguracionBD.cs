using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DConfiguracionBD
    {
        public DConfiguracionBD()
        { }

        /// <summary>
        /// Inserta los datos básicos en las tablas [TU_GENERO], [TU_TIPO_LICENCIA], [TME_TIPO_PREGUNTA]
        /// </summary>
        /// <returns></returns>
        public static string InsertarDatosBasicos()
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
                SqlCmd.CommandText = "SP_INSERTAR_DATOS_BASICOS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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
    }
}
