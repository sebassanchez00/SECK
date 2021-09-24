using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DGenero
    {
        private int _id_Genero;
        private string _enunciado;

        public int Id_Genero
        {
            get { return _id_Genero; }
            set { _id_Genero = value; }
        }

        public string Enunciado
        {
            get { return _enunciado; }
            set { _enunciado = value; }
        }

        public DGenero()
        { }

        public DGenero(int id_Genero, string enunciado)
        {
            this._id_Genero = id_Genero;
            this._enunciado = enunciado;
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
                SqlCmd.CommandText = "SP_MOSTRAR_GENERO";
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
