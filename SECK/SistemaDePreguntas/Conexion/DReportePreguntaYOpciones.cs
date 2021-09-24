using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DReportePreguntaYOpciones
    {
        private int _ordenPregunta;
        private string _enunciadoOpcion;
        private bool _esOpcionCorrecta;
        private string _enunciadoPregunta;
        private string _respuestaUsuario;
        private bool _respondioCorrectamente;
        private byte[] _imagen;

        public int Orden_Pregunta
        {
            get { return _ordenPregunta; }
            set { _ordenPregunta = value; }
        }

        public string EnunciadoOpcion
        {
            get { return _enunciadoOpcion; }
            set { _enunciadoOpcion = value; }
        }

        public bool EsOpcionCorrecta
        {
            get { return _esOpcionCorrecta; }
            set { _esOpcionCorrecta = value; }
        }

        public string EnunciadoPregunta
        {
            get { return _enunciadoPregunta; }
            set { _enunciadoPregunta = value; }
        }

        public string RespuestaUsuario
        {
            get { return _respuestaUsuario; }
            set { _respuestaUsuario = value; }
        }

        public bool RespondioCorrectamente
        {
            get { return _respondioCorrectamente; }
            set { _respondioCorrectamente = value; }
        }

        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public DReportePreguntaYOpciones()
        {

        }

        public DReportePreguntaYOpciones(int OrdenPregunta, string EnunciadoPregunta, bool EsOpcionCorrecta, string RespuestaUsuario, string EnunciadoOpcion, bool RespondioCorrectamente, byte[] Imagen)
        {
            this._ordenPregunta = OrdenPregunta;
            this._enunciadoPregunta = EnunciadoPregunta;
            this._esOpcionCorrecta = EsOpcionCorrecta;
            this._respuestaUsuario = RespuestaUsuario;
            this._enunciadoOpcion = EnunciadoOpcion;
            this._respondioCorrectamente = RespondioCorrectamente;
            this._imagen = Imagen;
        }

        /// <summary>
        /// Devuelve los registros  de opciones de respuesta y la pregunta desde las tablas TR_PREGUNTAS y TR_OPCIONES_RESPUESTA para una evaluación.
        /// </summary>
        /// <param name="Evaluacion"> ID de la evaluación  </param>
        /// <returns></returns>
        public DataTable Mostrar(string Evaluacion)
        {
            DataTable DtResultado = new DataTable("PREGUNTAS");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_REPORTE_PREGUNTA_Y_OPCIONES";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@ID_EVALUACION";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Evaluacion;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
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
    }
}