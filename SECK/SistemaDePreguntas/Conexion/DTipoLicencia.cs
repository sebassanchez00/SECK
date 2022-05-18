using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DTipoLicencia
    {
        private int _id;
        private string _tipoLicencia;
        private string _descripcion;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string TipoLicencia
        {
            get { return _tipoLicencia; }
            set { _tipoLicencia = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DTipoLicencia()
        { }

        public DTipoLicencia(int id, string tipoLicencia, string descripcion)
        {
            this._id = id;
            this._tipoLicencia = tipoLicencia;
            this._descripcion = descripcion;
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
                SqlCmd.CommandText = "SP_MOSTRAR_TIPO_LICENCIA";
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

        public VoTipoLicencia MostrarPorID(short ID)
        {
            VoTipoLicencia resultado = null;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_TIPO_LICENCIA_POR_ID";
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
                    string aux2 = sdr.GetString(1);
                    string aux3 = sdr.GetString(2);
                    resultado = new VoTipoLicencia(aux1, aux2, aux3);
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
