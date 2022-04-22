using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DResultadoPorTema
    {
        public DResultadoPorTema()
        {        }

        /// <summary>
        /// Inserta un registro en la tabla TR_RESULTADO_POR_TEMA
        /// </summary>
        /// <param name="Par">Value Object con los datos a guardar</param>
        /// <returns></returns>
        public string Insertar(VoResultadoPorTema Par)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_RESULTADO_POR_TEMA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDEval = new SqlParameter();
                ParIDEval.ParameterName = "@ID_EVALUACION";
                ParIDEval.SqlDbType = SqlDbType.VarChar;
                ParIDEval.Size = 50;
                ParIDEval.Value = Par.ID_Evaluacion;
                SqlCmd.Parameters.Add(ParIDEval);

                SqlParameter ParIDTema = new SqlParameter();
                ParIDTema.ParameterName = "@ID_TEMA";
                ParIDTema.SqlDbType = SqlDbType.SmallInt;
                ParIDTema.Value = Par.ID_Tema;
                SqlCmd.Parameters.Add(ParIDTema);

                SqlParameter ParEnunciado = new SqlParameter();
                ParEnunciado.ParameterName = "@ENUNCIADO_TEMA";
                ParEnunciado.SqlDbType = SqlDbType.VarChar;
                ParEnunciado.Size = -1;
                ParEnunciado.Value = Par.Enunciado_Tema;
                SqlCmd.Parameters.Add(ParEnunciado);

                SqlParameter ParPuntaje = new SqlParameter();
                ParPuntaje.ParameterName = "@PUNTAJE";
                ParPuntaje.SqlDbType = SqlDbType.Float;
                ParPuntaje.Value = Par.Puntaje;
                SqlCmd.Parameters.Add(ParPuntaje);

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
