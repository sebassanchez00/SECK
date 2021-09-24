using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public  class DUsuarios
    {

        private string _Cedula;
        private string _Nombre;
        private string _Apellido;
        private string _TipoLicencia;
        private string _Empresa;
        private string _Genero;
        private byte[] _imagen;
        private string _textobuscar;



        public string Cedula
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


        public string TipoLicencia
        {

            get { return _TipoLicencia; }
            set { _TipoLicencia = value; }
        }


        public string Empresa
        {

            get { return _Empresa; }
            set { _Empresa = value; }
        }

        public string Genero
        {

            get { return _Genero; }
            set { _Genero = value; }
        }
      

        public byte[] Imagen
        {

            get { return _imagen; }
            set { _imagen = value; }
        }

        public string TextoBuscar
        {

            get { return _textobuscar; }
            set { _textobuscar = value; }
        }
      

        public DUsuarios()
      {


      }

        public DUsuarios(string cedula, string nombre, string apellidos,string tipolicencia,string empresa,string genero, byte[] imagen,string texto_buscar)
      {
          this.Cedula = cedula;
          this.Nombre = nombre;
          this.Apellidos = apellidos;
          this.TipoLicencia = tipolicencia;
          this.Empresa = empresa;
          this.Genero = genero;
          this.Imagen = imagen;
          this.TextoBuscar = texto_buscar;
      }



        public string insertar(DUsuarios usuarios)
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
              SqlCmd.CommandText = "SP_INSERTARUSUARIOS";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParCedula = new SqlParameter();
              ParCedula.ParameterName = "@CEDULAS";
              ParCedula.SqlDbType = SqlDbType.VarChar;
              ParCedula.Size = 50;
              ParCedula.Value = usuarios.Cedula;
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
              ParTipoLicencia.Value = usuarios.TipoLicencia;
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
              ParFoto.Value = usuarios.Imagen;
              SqlCmd.Parameters.Add(ParFoto);

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


        public string Editar(DUsuarios usuarios)
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
                ParCedula.Value = usuarios.Cedula;
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
                ParTipoLicencia.Value = usuarios.TipoLicencia;
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
                ParFoto.Value = usuarios.Imagen;
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

        public int BuscarRegistroUsuario(DUsuarios usuarios)
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
                SqlCmd.CommandText = "spbuscar_UsuarioCedula";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = usuarios.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);



                rpta = int.Parse(SqlCmd.ExecuteScalar().ToString());

                 
            }
             catch (Exception ex)
             {
                 rpta = 2;
             }
             finally
             {
                 if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
             }
             return rpta;
        }

        ArrayList numb;
        string[] numbe;
        public string[] MostrarUsuario(DUsuarios usuarios)
        {
           
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_UsuarioCedulas";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = usuarios.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);
                ArrayList al = new ArrayList();
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
            catch (Exception ex)
            {
                numbe = null;
            }
            return numbe;

        }


    }
}
