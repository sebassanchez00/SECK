using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DEvaluacion
    {
        private string _ID;
        private string _ID_Conductor;
        private DateTime _Fecha_Hora_Prueba;
        private byte[] _Foto;
        //private _Huella;
        private string _Descripcion_Evaluacion;
        private string _ID_Ciudad;
        private int _Num_Preguntas;
        private int _Num_Correctas;
        private int _Num_Contestadas;
        private float _Puntaje;
        private TimeSpan _Tiempo_Prueba;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ID_Conductor
        {
            get { return _ID_Conductor; }
            set { _ID_Conductor = value; }
        }
        public DateTime Fecha_Hora_Prueba
        {
            get { return _Fecha_Hora_Prueba; }
            set { _Fecha_Hora_Prueba = value; }
        }
        public byte[] Foto
        {
            get { return _Foto; }
            set { _Foto = value; }
        }
        public string Descripcion_Evaluacion
        {
            get { return _Descripcion_Evaluacion; }
            set { _Descripcion_Evaluacion = value; }
        }
        public string ID_Ciudad
        {
            get { return _ID_Ciudad; }
            set { _ID_Ciudad = value; }
        }
        public int Num_Preguntas
        {
            get { return _Num_Preguntas; }
            set { _Num_Preguntas = value; }
        }
        public int Num_Correctas
        {
            get { return _Num_Correctas; }
            set { _Num_Correctas = value; }
        }
        public int Num_Contestadas
        {
            get { return _Num_Contestadas; }
            set { _Num_Contestadas = value; }
        }
        public float Puntaje
        {
            get { return _Puntaje; }
            set { _Puntaje = value; }
        }
        public TimeSpan Tiempo_Prueba
        {
            get { return _Tiempo_Prueba; }
            set { _Tiempo_Prueba = value; }
        }

        public DEvaluacion()
        { }

        public DEvaluacion(string ID, string ID_Conductor, DateTime Fecha_Hora_Prueba, byte[] Foto, string Descripcion_Evaluacion, string ID_Ciudad, int Num_Preguntas, int NumCorrectas, int NumContestadas, float Puntaje, TimeSpan TiempoPrueba)
        {
            this._ID = ID;
            this._ID_Conductor = ID_Conductor;
            this._Fecha_Hora_Prueba = Fecha_Hora_Prueba;
            this._Foto = Foto;
            this._Descripcion_Evaluacion = Descripcion_Evaluacion;
            this._ID_Ciudad = ID_Ciudad;
            this._Num_Preguntas = Num_Preguntas;
            this._Num_Correctas = NumCorrectas;
            this._Num_Contestadas = NumContestadas;
            this._Puntaje = Puntaje;
            this._Tiempo_Prueba = TiempoPrueba;
        }

        public string Insertar(DEvaluacion EvalPar)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_EVALUACION";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID";
                ParID.SqlDbType = SqlDbType.VarChar;
                ParID.Size = 50;
                ParID.Value = EvalPar.ID;
                SqlCmd.Parameters.Add(ParID);

                SqlParameter ParIDCond = new SqlParameter();
                ParIDCond.ParameterName = "@ID_CONDUCTOR";
                ParIDCond.SqlDbType = SqlDbType.VarChar;
                ParIDCond.Size = 15;
                ParIDCond.Value = EvalPar.ID_Conductor;
                SqlCmd.Parameters.Add(ParIDCond);

                SqlParameter ParFechaHora = new SqlParameter();
                ParFechaHora.ParameterName = "@FECHA_HORA";
                ParFechaHora.SqlDbType = SqlDbType.DateTime;
                ParFechaHora.Value = EvalPar.Fecha_Hora_Prueba;
                SqlCmd.Parameters.Add(ParFechaHora);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@IMAGEN";
                ParImagen.SqlDbType = SqlDbType.VarBinary;
                ParImagen.Size = -1; //MAX
                ParImagen.Value = EvalPar.Foto;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParResUsuario = new SqlParameter();
                ParResUsuario.ParameterName = "@DESCRIPCION_EVALUACION";
                ParResUsuario.SqlDbType = SqlDbType.VarChar;
                ParResUsuario.Size = 500;
                ParResUsuario.Value = EvalPar.Descripcion_Evaluacion;
                SqlCmd.Parameters.Add(ParResUsuario);

                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@ID_CIUDAD";
                ParCiudad.SqlDbType = SqlDbType.VarChar;
                ParCiudad.Size = 50;
                ParCiudad.Value = EvalPar.ID_Ciudad;
                SqlCmd.Parameters.Add(ParCiudad);

                SqlParameter ParNumPreguntas = new SqlParameter();
                ParNumPreguntas.ParameterName = "@NUM_PREGUNTAS";
                ParNumPreguntas.SqlDbType = SqlDbType.Int;
                ParNumPreguntas.Value = EvalPar.Num_Preguntas;
                SqlCmd.Parameters.Add(ParNumPreguntas);

                SqlParameter ParNumCorrectas = new SqlParameter();
                ParNumCorrectas.ParameterName = "@NUM_CORRECTAS";
                ParNumCorrectas.SqlDbType = SqlDbType.Int;
                ParNumCorrectas.Value = EvalPar.Num_Correctas;
                SqlCmd.Parameters.Add(ParNumCorrectas);

                SqlParameter ParNumContestadas = new SqlParameter();
                ParNumContestadas.ParameterName = "@NUM_CONTESTADAS";
                ParNumContestadas.SqlDbType = SqlDbType.Int;
                ParNumContestadas.Value = EvalPar.Num_Contestadas;
                SqlCmd.Parameters.Add(ParNumContestadas);

                SqlParameter ParPuntaje = new SqlParameter();
                ParPuntaje.ParameterName = "@PUNTAJE";
                ParPuntaje.SqlDbType = SqlDbType.Float;
                ParPuntaje.Value = EvalPar.Puntaje;
                SqlCmd.Parameters.Add(ParPuntaje);

                SqlParameter ParTiempoPrueba = new SqlParameter();
                ParTiempoPrueba.ParameterName = "@TIEMPO_PRUEBA";
                ParTiempoPrueba.SqlDbType = SqlDbType.Time;
                ParTiempoPrueba.Value = EvalPar.Tiempo_Prueba;
                SqlCmd.Parameters.Add(ParTiempoPrueba);

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

        /// <summary>
        /// Muestra cantidad de evaluaciones que tienen un conductor
        /// </summary>
        /// <param name="EvalPar"></param>
        /// <returns></returns>
        public int BuscarEvaluaciones(string ID_Conductor)
        {
            int rpta = 0;
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_EVALUACION_CANTIDAD";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDCond = new SqlParameter();
                ParIDCond.ParameterName = "@ID_CONDUCTOR";
                ParIDCond.SqlDbType = SqlDbType.VarChar;
                ParIDCond.Size = 15;
                ParIDCond.Value = ID_Conductor;
                SqlCmd.Parameters.Add(ParIDCond);

                rpta = int.Parse(SqlCmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                rpta = 2;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        /// <summary>
        /// Muestra la evaluaciones segun el ID
        /// </summary>
        /// <param name="ID_Conductor"></param>
        /// <returns></returns>
        public DataTable MostrarPorIDEval(string ID_Evaluacion)
        {
            DataTable DtResultado = new DataTable("TME_EVALUACION");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_EVALUACION_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID";
                ParID.SqlDbType = SqlDbType.VarChar;
                ParID.Size = 50;
                ParID.Value = ID_Evaluacion;
                SqlCmd.Parameters.Add(ParID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        /// <summary>
        /// Muestra todas las evaluaciones que tienen un conductor
        /// </summary>
        /// <param name="ID_Conductor"></param>
        /// <returns></returns>
        public DataTable MostrarPorIDConductor(string ID_Conductor)
        {
            DataTable DtResultado = new DataTable("TME_EVALUACION");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_EVALUACIONES_POR_ID_CONDUCTOR";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID_CONDUCTOR";
                ParID.SqlDbType = SqlDbType.VarChar;
                ParID.Size = 15;
                ParID.Value = ID_Conductor;
                SqlCmd.Parameters.Add(ParID);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        /// <summary>
        /// Trae los registros desde TME_EVALUACION en un datatable
        /// </summary>
        /// <returns></returns>
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("TME_EVALUACION");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_EVALUACIONES_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
