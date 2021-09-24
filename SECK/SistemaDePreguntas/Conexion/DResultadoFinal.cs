using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DResultadoFinal
    {

        private string _Idresultado;
        private string _Id_Reporte;
        private int _CantidadPreguntas;
        private int _RespuestasFallidas;
        private int _PreguntasRespondidas;
        private int _RespuestasCorrectas;
        private string _Cedula;
        private int _Calificacion;

        public int Calificacion
        {

            get { return _Calificacion; }
            set { _Calificacion = value; }

        }


        public string IdResultado
        {
            get { return _Idresultado; }
            set { _Idresultado = value; }
        }

        public string IdReporte
        {
            get { return _Id_Reporte; }
            set { _Id_Reporte = value; }
        }

        public int CantidadPreguntas
        {

            get { return _CantidadPreguntas; }
            set { _CantidadPreguntas = value; }

        }

        public int RespuestasFallidas
        {

            get { return _RespuestasFallidas; }
            set { _RespuestasFallidas = value; }
        }
        public int PreguntasRespondidas
        {
            get { return _PreguntasRespondidas; }
            set { _PreguntasRespondidas = value; }
        }

        public int RespuestasCorrectas
        {
            get { return _RespuestasCorrectas; }
            set { _RespuestasCorrectas = value; }
        }

        public string Cedula
        {

            get { return _Cedula; }
            set { _Cedula = value; }
        }
        public DResultadoFinal()
        {


        }
        public DResultadoFinal(string idresultado, string idreporte, int cantidadpreguntas, int respuestasfallidas, int preguntasrespondidas, int respuestascorrectas,string cedula,int calificacion)
        {

            this.IdResultado = idresultado;
            this.IdReporte = idreporte;
            this.CantidadPreguntas = cantidadpreguntas;
            this.RespuestasFallidas = respuestasfallidas;
            this.PreguntasRespondidas = preguntasrespondidas;
            this.RespuestasCorrectas = respuestascorrectas;
            this.Cedula = cedula;
            this.Calificacion = calificacion;
        }

        /// <summary>
        /// Inserta registro en tabla RESULTADO_FINAL, retorna string con resultado de la consulta
        /// </summary>
        /// <param name="resultadofinal"></param>
        /// <returns></returns>
        public string Insertar(DResultadoFinal resultadofinal)
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
                SqlCmd.CommandText = "SP_INSERTAR_RESULTADO_FINAL";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdResultado = new SqlParameter();
                ParIdResultado.ParameterName = "@IDRESULTADO";
                ParIdResultado.SqlDbType = SqlDbType.VarChar;
                ParIdResultado.Value = resultadofinal.IdResultado;
                SqlCmd.Parameters.Add(ParIdResultado);

                SqlParameter ParIdReporte = new SqlParameter();
                ParIdReporte.ParameterName = "@ID_REPORTE";
                ParIdReporte.SqlDbType = SqlDbType.VarChar;
                ParIdReporte.Value = resultadofinal.IdReporte;
                SqlCmd.Parameters.Add(ParIdReporte);

                SqlParameter ParCantidadPreguntas = new SqlParameter();
                ParCantidadPreguntas.ParameterName = "@CANTIDADPREGUNTAS";
                ParCantidadPreguntas.SqlDbType = SqlDbType.Int;
                ParCantidadPreguntas.Value = resultadofinal.CantidadPreguntas;
                SqlCmd.Parameters.Add(ParCantidadPreguntas);

                SqlParameter ParRespuestasfallidas = new SqlParameter();
                ParRespuestasfallidas.ParameterName = "@RESPUESTASFALLIDAS";
                ParRespuestasfallidas.SqlDbType = SqlDbType.Int;
                ParRespuestasfallidas.Value = resultadofinal.RespuestasFallidas;
                SqlCmd.Parameters.Add(ParRespuestasfallidas);

                SqlParameter ParPreguntasRespondidas = new SqlParameter();
                ParPreguntasRespondidas.ParameterName = "@PREGUNTASRESPONDIDAS";
                ParPreguntasRespondidas.SqlDbType = SqlDbType.Int;
                ParPreguntasRespondidas.Value = resultadofinal.PreguntasRespondidas;
                SqlCmd.Parameters.Add(ParPreguntasRespondidas);

                SqlParameter ParRespuestasCorrectas = new SqlParameter();
                ParRespuestasCorrectas.ParameterName = "@RESPUESTASCORRECTAS";
                ParRespuestasCorrectas.SqlDbType = SqlDbType.Int;
                ParRespuestasCorrectas.Value = resultadofinal.RespuestasCorrectas;
                SqlCmd.Parameters.Add(ParRespuestasCorrectas);

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@CEDULAS";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Value = resultadofinal.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                SqlParameter ParCalificacion = new SqlParameter();
                ParCalificacion.ParameterName = "@CALIFICACION";
                ParCalificacion.SqlDbType = SqlDbType.Int;
                ParCalificacion.Value = resultadofinal.Calificacion;
                SqlCmd.Parameters.Add(ParCalificacion);

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

        public DataTable BuscarReportes(DResultadoFinal resultadofinal)
        {
            DataTable DtResultado = new DataTable("RESULTADO_FINAL");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ResultadoFinal";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = resultadofinal.Cedula;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
