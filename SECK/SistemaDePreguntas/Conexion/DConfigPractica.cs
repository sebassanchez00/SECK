using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DConfigPractica
    {

        private int _IdConfigPractica;
        private string _Instalacion;
        private string _ClienteEmpresa;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private string _Estado;

        private string _TextoBuscar;


        public int Id_ConfigPractica
        {


            get { return _IdConfigPractica; }
            set { _IdConfigPractica = value; }
        }

        public string Instalacion
        {


            get { return _Instalacion; }
            set { _Instalacion = value; }
        }



        public string ClienteEmpresa
        {

            get { return _ClienteEmpresa; }
            set { _ClienteEmpresa = value; }
        }

        public string Estado
        {

            get { return _Estado; }
            set { _Estado = value; }
        }


        public DateTime FechaInicio
        {

            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        public DateTime FechaFin
        {

            get { return _FechaFin; }
            set { _FechaFin = value; }
        }





        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DConfigPractica()
        {



        }
        public DConfigPractica(int IdConfigPractica ,string instalacion, string clienteempresa, DateTime fechainicio, DateTime fechafin,string estado)
      {
          this.Id_ConfigPractica= IdConfigPractica;
          this.Instalacion =instalacion;
          this.ClienteEmpresa = clienteempresa;
          this.FechaInicio= fechainicio;
          this.FechaFin = fechafin;
          this.Estado = estado;
      }


        public string Insertar(DConfigPractica ConfigPractica)
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
                SqlCmd.CommandText = "SP_INSERTAR_CONFIG_PRACTICA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

              




                SqlParameter ParInstalacion = new SqlParameter();
                ParInstalacion.ParameterName = "@INSTALACION";
                ParInstalacion.SqlDbType = SqlDbType.VarChar;
                ParInstalacion.Size = 50;
                ParInstalacion.Value = ConfigPractica.Instalacion;
                SqlCmd.Parameters.Add(ParInstalacion);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@CLIENTE_EMPRESA";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 50;
                ParCliente.Value = ConfigPractica.ClienteEmpresa;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FECHA_INICIO";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = ConfigPractica.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                SqlParameter ParFechafin = new SqlParameter();
                ParFechafin.ParameterName = "@FECHA_FIN";
                ParFechafin.SqlDbType = SqlDbType.Date;
                ParFechafin.Size = 50;
                ParFechafin.Value = ConfigPractica.FechaFin;
                SqlCmd.Parameters.Add(ParFechafin);



                SqlParameter ParEnunciado = new SqlParameter();
                ParEnunciado.ParameterName = "@ESTADO";
                ParEnunciado.SqlDbType = SqlDbType.VarChar;
                ParEnunciado.Size = 50;
                ParEnunciado.Value = ConfigPractica.Estado;
                SqlCmd.Parameters.Add(ParEnunciado);

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


        public string Editar(DConfigPractica ConfigPractica)
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
                SqlCmd.CommandText = "SP_UPDATE_CONFIG_PRACTICA";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParIdPregunta = new SqlParameter();
                ParIdPregunta.ParameterName = "@ID_CONFIG_PRACTICA";
                ParIdPregunta.SqlDbType = SqlDbType.Int;
                ParIdPregunta.Value = ConfigPractica.Id_ConfigPractica;
                SqlCmd.Parameters.Add(ParIdPregunta);

                SqlParameter ParInstalacion = new SqlParameter();
                ParInstalacion.ParameterName = "@INSTALACION";
                ParInstalacion.SqlDbType = SqlDbType.VarChar;
                ParInstalacion.Size = 50;
                ParInstalacion.Value = ConfigPractica.Instalacion;
                SqlCmd.Parameters.Add(ParInstalacion);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@CLIENTE_EMPRESA";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 50;
                ParCliente.Value = ConfigPractica.ClienteEmpresa;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@FECHA_INICIO";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Size = 50;
                ParFechaInicio.Value = ConfigPractica.FechaInicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                SqlParameter ParFechafin = new SqlParameter();
                ParFechafin.ParameterName = "@FECHA_FIN";
                ParFechafin.SqlDbType = SqlDbType.Date;
                ParFechafin.Size = 50;
                ParFechafin.Value = ConfigPractica.FechaFin;
                SqlCmd.Parameters.Add(ParFechafin);



                SqlParameter ParEnunciado = new SqlParameter();
                ParEnunciado.ParameterName = "@ESTADO";
                ParEnunciado.SqlDbType = SqlDbType.VarChar;
                ParEnunciado.Size = 50;
                ParEnunciado.Value = ConfigPractica.Estado;
                SqlCmd.Parameters.Add(ParEnunciado);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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

        public string Eliminar(DConfigPractica ConfigPractica)
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
                SqlCmd.CommandText = "SP_DELETE_CONFIG_PRACTICA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPregunta = new SqlParameter();
                ParIdPregunta.ParameterName = "@ID_CONFIG_PRACTICA";
                ParIdPregunta.SqlDbType = SqlDbType.Int;
                ParIdPregunta.Value = ConfigPractica.Id_ConfigPractica;
                SqlCmd.Parameters.Add(ParIdPregunta);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("CONFIG_PRACTICA");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrarconfigpracticas";
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

        string[] numb;
        /// <summary>
        /// Devuelve un arreglo string con los registros de tabla CONFIG_PRACTICA
        /// </summary>
        /// <param name="ConfigPractica"></param>
        /// <returns></returns>
        public string[] MostrarConfiguracionPractica(DConfigPractica ConfigPractica)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ConfiguracionPractica_FechaInicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = ConfigPractica.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataReader reader = SqlCmd.ExecuteReader();
                while (reader.Read())
                {               
                    numb = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        numb[i] = reader[i].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                numb = null;
            }
            return numb;
        }
    }
}
