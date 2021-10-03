using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DTipoPregunta
    {
        public DTipoPregunta() { }

        public VoTipoPregunta MostrarPorID(short Id)
        {
            VoTipoPregunta resultado = new VoTipoPregunta();
            using (SqlConnection SqlCon = new SqlConnection())
            {
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCon.Open();
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "SP_MOSTRAR_TIPOPREGUNTA_POR_ID";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParId = new SqlParameter();
                    ParId.ParameterName = "@ID";
                    ParId.SqlDbType = SqlDbType.SmallInt;
                   //ParId.Size = 50;
                    ParId.Value = Id;
                    SqlCmd.Parameters.Add(ParId);

                    SqlDataReader sdr = SqlCmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        object[] values = new object[sdr.FieldCount];
                        sdr.GetValues(values);
                        resultado.Id = (short)values[0];
                        resultado.Enunciado = (string)values[1];
                    }
                }
                catch (Exception ex)
                {
                    resultado = null;
                    //throw new Exception();
                }
            }
            return resultado;
        }
    }
}
