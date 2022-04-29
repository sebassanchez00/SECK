using CapaDatos.Vo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DConductor
    {
        private string _Cedula;
        private string _Nombre;
        private string _Apellido;
        private int _TipoLicencia;
        private string _codigoLicencia;
        private string _Empresa;
        private int _Genero;
        private byte[] _huella;
        private byte[] _fotografia;
        private DateTime _fechaNacimiento;
        private string _textobuscar;

        public string Cedulas
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellidos
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public int Tipo_Licencia
        {
            get { return _TipoLicencia; }
            set { _TipoLicencia = value; }
        }

        public string Codigo_Licencia
        {
            get { return _codigoLicencia; }
            set { _codigoLicencia = value; }
        }

        public string Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }

        public int Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public byte[] Huella
        {
            get { return _huella; }
            set { _huella = value; }
        }

        public byte[] Fotografia
        {
            get { return _fotografia; }
            set { _fotografia = value; }
        }

        public DateTime Fecha_Nacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string TextoBuscar
        {
            get { return _textobuscar; }
            set { _textobuscar = value; }
        }

        public DConductor()
        { }

        public DConductor(string cedula, string nombre, string apellidos, int tipolicencia, string CodigoLicencia, string empresa, int genero, byte[] Huella, byte[] imagen, DateTime FechaNacimiento, string texto_buscar)
        {
            this.Cedulas = cedula;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Tipo_Licencia = tipolicencia;
            this.Codigo_Licencia = CodigoLicencia;
            this.Empresa = empresa;
            this.Genero = genero;
            this.Huella = Huella;
            this.Fotografia = imagen;
            this.Fecha_Nacimiento = FechaNacimiento;
            this.TextoBuscar = texto_buscar;
        }

        public string insertar(DConductor ObjUsuario)
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
                SqlCmd.CommandText = "SP_INSERTAR_CONDUCTOR";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@CEDULAS";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 15;
                ParCedula.Value = ObjUsuario.Cedulas;
                SqlCmd.Parameters.Add(ParCedula);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@NOMBRE";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 45;
                ParNombres.Value = ObjUsuario.Nombre;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@APELLIDOS";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 45;
                ParApellidos.Value = ObjUsuario.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParTipoLicencia = new SqlParameter();
                ParTipoLicencia.ParameterName = "@TIPO_LICENCIA";
                ParTipoLicencia.SqlDbType = SqlDbType.SmallInt;
                ParTipoLicencia.Value = ObjUsuario.Tipo_Licencia;
                SqlCmd.Parameters.Add(ParTipoLicencia);

                SqlParameter ParCodLic = new SqlParameter();
                ParCodLic.ParameterName = "@CODIGO_LICENCIA";
                ParCodLic.SqlDbType = SqlDbType.VarChar;
                ParCodLic.Size = 45;
                ParCodLic.Value = ObjUsuario.Codigo_Licencia;
                SqlCmd.Parameters.Add(ParCodLic);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@EMPRESA";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 45;
                ParEmpresa.Value = ObjUsuario.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@GENERO";
                ParGenero.SqlDbType = SqlDbType.SmallInt;
                ParGenero.Value = ObjUsuario.Genero;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter ParHuella = new SqlParameter();
                ParHuella.ParameterName = "@HUELLA";
                ParHuella.SqlDbType = SqlDbType.VarBinary;
                ParHuella.Size = -1;
                ParHuella.Value = ObjUsuario.Huella;
                SqlCmd.Parameters.Add(ParHuella);

                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@FOTOGRAFIA";
                ParFoto.SqlDbType = SqlDbType.VarBinary;
                ParFoto.Size = -1;
                ParFoto.Value = ObjUsuario.Fotografia;
                SqlCmd.Parameters.Add(ParFoto);

                SqlParameter ParFechaNac = new SqlParameter();
                ParFechaNac.ParameterName = "@FECHA_NACIMIENTO";
                ParFechaNac.SqlDbType = SqlDbType.DateTime;
                ParFechaNac.Value = ObjUsuario.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFechaNac);
                
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

        public string Editar(DConductor usuarios)
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
                SqlCmd.CommandText = "SP_UPDATE_USUARIO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@CEDULAS";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 50;
                ParCedula.Value = usuarios.Cedulas;
                SqlCmd.Parameters.Add(ParCedula);

                SqlParameter ParNombres = new SqlParameter();
                ParNombres.ParameterName = "@NOMBRE";
                ParNombres.SqlDbType = SqlDbType.VarChar;
                ParNombres.Size = 50;
                ParNombres.Value = usuarios.Nombre;
                SqlCmd.Parameters.Add(ParNombres);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@APELLIDOS";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = usuarios.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParTipoLicencia = new SqlParameter();
                ParTipoLicencia.ParameterName = "@TIPO_LICENCIA";
                ParTipoLicencia.SqlDbType = SqlDbType.VarChar;
                ParTipoLicencia.Size = 50;
                ParTipoLicencia.Value = usuarios.Tipo_Licencia;
                SqlCmd.Parameters.Add(ParTipoLicencia);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@EMPRESA";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = usuarios.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@GENERO";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 50;
                ParGenero.Value = usuarios.Genero;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@FOTOGRAFIA";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Size = 2000;
                ParFoto.Value = usuarios.Fotografia;
                SqlCmd.Parameters.Add(ParGenero);

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

        /// <summary>
        /// Devuleve el número de registros de la tabla TU_CONDUCTOR
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public int ConductorExiste(DConductor usuarios)
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
                SqlCmd.CommandText = "SP_MOSTRAR_CONDUCTOR_EXISTE";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@CEDULA";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = usuarios.TextoBuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);
                rpta = int.Parse(SqlCmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                rpta = -1;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        /// <summary>
        /// Retorna un array de strings con los conductores que coinciden con el ID
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public string[] MostrarUsuario_str(DConductor usuarios)
        {
            string[] numbe = null;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CONDUCTOR_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@CEDULA";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 15;
                ParTextoBuscar.Value = usuarios.TextoBuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    numbe = new string[sdr.FieldCount];
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        numbe[i] = sdr[i].ToString();
                    }
                }
            }
            catch (Exception)
            {
                numbe = null;
            }
            return numbe;
        }

        /// <summary>
        /// Retorna un Datatable con el usuario, si hay error retorna null
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public DataTable MostrarUsuario_dt(DConductor usuarios)
        {
            DataTable dt = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CONDUCTOR_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@CEDULA";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 15;
                ParTextoBuscar.Value = usuarios.TextoBuscar;

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

        /// <summary>
        /// Retorna todos los conductores desde la tabla TU_CONDUCTOR
        /// </summary>
        /// <returns></returns>
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CONDUCTOR_TODOS";
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

        /// <summary>
        /// Retorna un VoConductor que coinciden con la cédula
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public VoConductor MostrarUsuario_VoConductor(string cedula)
        {
            VoConductor resultado = null ;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_CONDUCTOR_POR_ID_SIN_FORMATO";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@CEDULA";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 15;
                ParTextoBuscar.Value = cedula;

                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataReader sdr = SqlCmd.ExecuteReader();

                while (sdr.Read())
                {
                    string aux1 = sdr.GetString(0);
                    string aux2 = sdr.GetString(1);
                    string aux3 = sdr.GetString(2);
                    short aux4 = sdr.GetInt16(3);
                    string aux5 = sdr.GetString(4);
                    string aux6 = sdr.GetString(5);
                    short aux7 = sdr.GetInt16(6);
                    byte[] auxByteHuella = sdr.GetValue(7) is DBNull ? null : (byte[])sdr.GetValue(7);
                    byte[] auxByteFoto = sdr.GetValue(8) is DBNull ? null : (byte[])sdr.GetValue(8);
                    DateTime aux8 = sdr.GetDateTime(9);

                    resultado = new VoConductor(aux1 ,aux2 ,aux3 , aux4, aux5 ,aux6 ,aux7 ,auxByteHuella,auxByteFoto,aux8);
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
