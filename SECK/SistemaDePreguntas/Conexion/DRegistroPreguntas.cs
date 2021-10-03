using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DRegistroPreguntas
    {
        private int _ID;
        private string _ID_Evaluacion;
        private string _Pregunta;
        private string _Respuesta_Del_Usuario;
        private bool _Respondio_Correctamente;
        private byte[] _Imagen;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ID_Evaluacion
        {
            get { return _ID_Evaluacion; }
            set { _ID_Evaluacion = value; }
        }
        public string Pregunta
        {
            get { return _Pregunta; }
            set { _Pregunta = value; }
        }
        public string Respuesta_Del_Usuario
        {
            get { return _Respuesta_Del_Usuario; }
            set { _Respuesta_Del_Usuario = value; }
        }
        public bool Respondio_Correctamente
        {
            get { return _Respondio_Correctamente; }
            set { _Respondio_Correctamente = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public DRegistroPreguntas()
        { }
        public DRegistroPreguntas(int ID, string ID_Evaluacion, string ID_Pregunta, string Respuesta_Del_Usuario, bool Respondio_Correctamente, byte[] Imagen)
        {
            this._ID = ID;
            this._ID_Evaluacion = ID_Evaluacion;
            this._Pregunta = ID_Pregunta;
            this._Respuesta_Del_Usuario = Respuesta_Del_Usuario;
            this._Respondio_Correctamente = Respondio_Correctamente;
            this._Imagen = Imagen;
        }

        /// <summary>
        /// Inserta registro en tabla TME_CUESTIONARIO y devuelve ID de la fila insertada
        /// </summary>
        /// <param name="CuestionarioPar"></param>
        /// <returns></returns>
        public int Insertar(DRegistroPreguntas CuestionarioPar)
        {
            int ID_AutoIncrementado = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_REGISTRO_PREGUNTAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDEval = new SqlParameter();
                ParIDEval.ParameterName = "@ID_EVALUACION";
                ParIDEval.SqlDbType = SqlDbType.VarChar;
                ParIDEval.Size = 50;
                ParIDEval.Value = CuestionarioPar.ID_Evaluacion;
                SqlCmd.Parameters.Add(ParIDEval);

                SqlParameter ParIDPreg = new SqlParameter();
                ParIDPreg.ParameterName = "@PREGUNTA";
                ParIDPreg.SqlDbType = SqlDbType.VarChar;
                ParIDPreg.Size = -1;
                ParIDPreg.Value = CuestionarioPar.Pregunta;
                SqlCmd.Parameters.Add(ParIDPreg);

                SqlParameter ParResUsuario = new SqlParameter();
                ParResUsuario.ParameterName = "@RESPUESTA_DEL_USUARIO";
                ParResUsuario.SqlDbType = SqlDbType.VarChar;
                ParResUsuario.Size = -1;
                ParResUsuario.Value = CuestionarioPar.Respuesta_Del_Usuario;
                SqlCmd.Parameters.Add(ParResUsuario);

                SqlParameter ParResCorr = new SqlParameter();
                ParResCorr.ParameterName = "@RESPONDIO_CORRECTAMENTE";
                ParResCorr.SqlDbType = SqlDbType.Bit;
                ParResCorr.Value = CuestionarioPar.Respondio_Correctamente;
                SqlCmd.Parameters.Add(ParResCorr);

                SqlParameter ParImg = new SqlParameter();
                ParImg.ParameterName = "@IMAGEN";
                ParImg.SqlDbType = SqlDbType.VarBinary;
                ParImg.Size = -1;
                ParImg.Value = CuestionarioPar.Imagen;
                SqlCmd.Parameters.Add(ParImg);

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

        /// <summary>
        /// Inserta registro en tabla TME_CUESTIONARIO y devuelve ID de la fila insertada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insertar(VoRegistroPreguntas obj)
        {
            int ID_AutoIncrementado = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_REGISTRO_PREGUNTAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDEval = new SqlParameter();
                ParIDEval.ParameterName = "@ID_EVALUACION";
                ParIDEval.SqlDbType = SqlDbType.VarChar;
                ParIDEval.Size = 50;
                ParIDEval.Value = obj.id_Evaluacion;
                SqlCmd.Parameters.Add(ParIDEval);

                SqlParameter ParIDPreg = new SqlParameter();
                ParIDPreg.ParameterName = "@PREGUNTA";
                ParIDPreg.SqlDbType = SqlDbType.VarChar;
                ParIDPreg.Size = -1;
                ParIDPreg.Value = obj.pregunta;
                SqlCmd.Parameters.Add(ParIDPreg);

                SqlParameter ParResUsuario = new SqlParameter();
                ParResUsuario.ParameterName = "@RESPUESTA_DEL_USUARIO";
                ParResUsuario.SqlDbType = SqlDbType.VarChar;
                ParResUsuario.Size = -1;
                ParResUsuario.Value = obj.respuestaDelUsuario;
                SqlCmd.Parameters.Add(ParResUsuario);

                SqlParameter ParResCorr = new SqlParameter();
                ParResCorr.ParameterName = "@RESPONDIO_CORRECTAMENTE";
                ParResCorr.SqlDbType = SqlDbType.Bit;
                ParResCorr.Value = obj.respondioCorrectamente;
                SqlCmd.Parameters.Add(ParResCorr);

                SqlParameter ParImg = new SqlParameter();
                ParImg.ParameterName = "@IMAGEN";
                ParImg.SqlDbType = SqlDbType.VarBinary;
                ParImg.Size = -1;
                ParImg.Value = obj.imagen;
                SqlCmd.Parameters.Add(ParImg);

                ID_AutoIncrementado = (int)SqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return ID_AutoIncrementado;
        }

        /// <summary>
        /// Devuleve en un DataTable todas las preguntas y respuestas de una evaluación
        /// </summary>
        /// <param name="ID_Eval"></param>
        /// <returns></returns>
        public DataTable Mostrar_Por_ID_Evaluacion(string ID_Eval)
        {
            DataTable dt = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_REGISTRO_PREGUNTA_POR_ID_EVALUACION";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@ID_EVALUACION";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = ID_Eval;

                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sdr = new SqlDataAdapter(SqlCmd);
                sdr.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
    }
}
