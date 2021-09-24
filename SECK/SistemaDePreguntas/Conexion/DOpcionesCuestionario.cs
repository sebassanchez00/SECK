using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DORegistroOpcionesPreguntas
    {
        private int _ID;
        private int _ID_Cuestionario;
        private string _Texto_Opcion;
        private bool _Es_Correcta;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int ID_Cuestionario
        {
            get { return _ID_Cuestionario; }
            set { _ID_Cuestionario = value; }
        }
        public string Texto_Opcion
        {
            get { return _Texto_Opcion; }
            set { _Texto_Opcion = value; }
        }
        public bool Es_Correcta
        {
            get { return _Es_Correcta; }
            set { _Es_Correcta = value; }
        }

        public DORegistroOpcionesPreguntas()
        { }
        public DORegistroOpcionesPreguntas(int ID, int ID_Cuestionario, string Texto_Opcion, bool Es_Correcta)
        {
            this._ID = ID;
            this._ID_Cuestionario = ID_Cuestionario;
            this._Texto_Opcion = Texto_Opcion;
            this._Es_Correcta = Es_Correcta;
        }

        public int Insertar(DORegistroOpcionesPreguntas Par)
        {
            int ID_AutoIncrementado = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_REGISTRO_OPCIONES_RESPUESTA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDCues = new SqlParameter();
                ParIDCues.ParameterName = "@ID_CUESTIONARIO";
                ParIDCues.SqlDbType = SqlDbType.Int;
                ParIDCues.Value = Par.ID_Cuestionario;
                SqlCmd.Parameters.Add(ParIDCues);

                SqlParameter ParTextoOpcion = new SqlParameter();
                ParTextoOpcion.ParameterName = "@ENUNCIADO";
                ParTextoOpcion.SqlDbType = SqlDbType.VarChar;
                ParTextoOpcion.Size = -1;
                ParTextoOpcion.Value = Par.Texto_Opcion;
                SqlCmd.Parameters.Add(ParTextoOpcion);

                SqlParameter ParEsCorrecta = new SqlParameter();
                ParEsCorrecta.ParameterName = "@ES_CORRECTA";
                ParEsCorrecta.SqlDbType = SqlDbType.Bit;
                ParEsCorrecta.Value = Par.Es_Correcta;
                SqlCmd.Parameters.Add(ParEsCorrecta);

                ID_AutoIncrementado = (int)SqlCmd.ExecuteScalar();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return ID_AutoIncrementado;
        }

        public DataTable MostrarEvaluacionConOpciones(string ID_Evaluacion)
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_REGISTRO_OPCIONES_PREGUNTAS_POR_EVALUACION";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDEval = new SqlParameter();
                ParIDEval.ParameterName = "@ID_Evaluacion";
                ParIDEval.SqlDbType = SqlDbType.VarChar;
                ParIDEval.Size = 50;
                ParIDEval.Value = ID_Evaluacion;
                SqlCmd.Parameters.Add(ParIDEval);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

                //DtResultado = InsertarFilaSeparacion(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        DataTable InsertarFilaSeparacion(DataTable dt)
        {
            int aux_ID_CUESTIONARIO_ant = (int)dt.Rows[0]["ID_CUESTIONARIO"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int aux_ID_CUESTIONARIO_desp = (int)dt.Rows[i]["ID_CUESTIONARIO"];
                if (aux_ID_CUESTIONARIO_ant != aux_ID_CUESTIONARIO_desp)
                {
                    aux_ID_CUESTIONARIO_ant = (int)dt.Rows[i]["ID_CUESTIONARIO"];
                    DataRow dr = dt.NewRow();
                    dt.Rows.InsertAt(dr,i);
                }
            }
            return dt;
        }
    }
}