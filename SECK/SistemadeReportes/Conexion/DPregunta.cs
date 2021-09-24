using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public   class DPregunta
    {

        private int _Id_Pregunta;
      private int _Id_TipoPregunta;
      private string _Enunciado; private string _Respuesta;
       private string _Opcion1;
      private string _Opcion2;
      private string _Opcion3;
      private string _Opcion4;
      private string _Opcion5;
      private int _Puntaje;
        private string _TextoBuscar;

        public int Id_Pregunta
        {


            get { return _Id_Pregunta; }
            set { _Id_Pregunta = value; }
        }

        public int Id_TipoPregunta
        {


            get { return _Id_TipoPregunta; }
            set { _Id_TipoPregunta = value; }
        }



        public string Enunciado
        {

            get { return _Enunciado; }
            set { _Enunciado = value; }
        }



        public string Respuesta
        {

            get { return _Respuesta; }
            set { _Respuesta = value; }
        }


         public string Opcion1
        {

            get { return _Opcion1; }
            set { _Opcion1 = value; }
        }

        public string Opcion2
        {

            get { return _Opcion2; }
            set { _Opcion2 = value; }
        }


        public string Opcion3
        {

            get { return _Opcion3; }
            set { _Opcion3 = value; }
        }

        public string Opcion4
        {

            get { return _Opcion4; }
            set { _Opcion4 = value; }
        }


        public string Opcion5
        {

            get { return _Opcion5; }
            set { _Opcion5 = value; }
        }

       public int Puntaje
        {

            get { return _Puntaje; }
            set { _Puntaje = value; }
        }


        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

          public DPregunta()
      {


      }

      public DPregunta(int Id_Pregunta,int Id_TipoPregunta, string Enunciado,string respuesta, string Opcion1,string Opcion2,string Opcion3,string Opcion4,string Opcion5,int puntaje)
      {
          this.Id_Pregunta= Id_Pregunta;
          this.Enunciado = Enunciado;
          this.Id_TipoPregunta = Id_TipoPregunta;
          this.Opcion1= Opcion1;
          this.Opcion2= Opcion2;
          this.Opcion3= Opcion3;
          this.Opcion4= Opcion4;
          this.Opcion5= Opcion5;
          this.Puntaje=puntaje;
          this.Respuesta = respuesta;
      }


      public string Insertar(DPregunta Pregunta)
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
              SqlCmd.CommandText = "SP_INSERTAR_PREGUNTAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTipoPregunta= new SqlParameter();
              ParIdTipoPregunta.ParameterName = "@ID_TIPO_PREGUNTA";
              ParIdTipoPregunta.SqlDbType = SqlDbType.Int;
              ParIdTipoPregunta.Value = Pregunta.Id_TipoPregunta;
              SqlCmd.Parameters.Add(ParIdTipoPregunta);

            


              SqlParameter ParOpcion1 = new SqlParameter();
              ParOpcion1.ParameterName = "@OPCION1";
              ParOpcion1.SqlDbType = SqlDbType.VarChar;
              ParOpcion1.Size = 50;
              ParOpcion1.Value = Pregunta.Opcion1;
              SqlCmd.Parameters.Add(ParOpcion1);

                SqlParameter ParOpcion2 = new SqlParameter();
              ParOpcion2.ParameterName = "@OPCION2";
              ParOpcion2.SqlDbType = SqlDbType.VarChar;
              ParOpcion2.Size = 50;
              ParOpcion2.Value = Pregunta.Opcion2;
              SqlCmd.Parameters.Add(ParOpcion2);

               SqlParameter ParOpcion3 = new SqlParameter();
              ParOpcion3.ParameterName = "@OPCION3";
              ParOpcion3.SqlDbType = SqlDbType.VarChar;
              ParOpcion3.Size = 50;
              ParOpcion3.Value = Pregunta.Opcion3;
              SqlCmd.Parameters.Add(ParOpcion3);


               SqlParameter ParOpcion4 = new SqlParameter();
              ParOpcion4.ParameterName = "@OPCION4";
              ParOpcion4.SqlDbType = SqlDbType.VarChar;
              ParOpcion4.Size = 50;
              ParOpcion4.Value = Pregunta.Opcion4;
              SqlCmd.Parameters.Add(ParOpcion4);


               SqlParameter ParOpcion5 = new SqlParameter();
              ParOpcion5.ParameterName = "@OPCION5";
              ParOpcion5.SqlDbType = SqlDbType.VarChar;
              ParOpcion5.Size = 50;
              ParOpcion5.Value = Pregunta.Opcion5;
              SqlCmd.Parameters.Add(ParOpcion5);


              SqlParameter ParRespuesta = new SqlParameter();
              ParRespuesta.ParameterName = "@RESPUESTa";
              ParRespuesta.SqlDbType = SqlDbType.VarChar;
              ParRespuesta.Size = 50;
              ParRespuesta.Value = Pregunta.Respuesta;
              SqlCmd.Parameters.Add(ParRespuesta);



                    SqlParameter ParPuntaje= new SqlParameter();
              ParPuntaje.ParameterName = "@PUNTAJE";
              ParPuntaje.SqlDbType = SqlDbType.Int;
              ParPuntaje.Value = Pregunta.Puntaje;
              SqlCmd.Parameters.Add(ParPuntaje);




                SqlParameter ParEnunciado = new SqlParameter();
              ParEnunciado.ParameterName = "@ENUNCIADO";
              ParEnunciado.SqlDbType = SqlDbType.VarChar;
              ParEnunciado.Size = 50;
              ParEnunciado.Value = Pregunta.Enunciado;
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

      public string Editar(DPregunta Pregunta)
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
              SqlCmd.CommandText = "SP_UPDATE_PREGUNTAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlParameter ParIdPregunta = new SqlParameter();
              ParIdPregunta.ParameterName = "@ID_PREGUNTA";
              ParIdPregunta.SqlDbType = SqlDbType.Int;
              ParIdPregunta.Value = Pregunta.Id_Pregunta;
              SqlCmd.Parameters.Add(ParIdPregunta);


                SqlParameter ParIdTipoPregunta= new SqlParameter();
              ParIdTipoPregunta.ParameterName = "@ID_TIPO_PREGUNTA";
              ParIdTipoPregunta.SqlDbType = SqlDbType.Int;
              ParIdTipoPregunta.Value = Pregunta.Id_TipoPregunta;
              SqlCmd.Parameters.Add(ParIdTipoPregunta);

            


              SqlParameter ParOpcion1 = new SqlParameter();
              ParOpcion1.ParameterName = "@OPCION1";
              ParOpcion1.SqlDbType = SqlDbType.VarChar;
              ParOpcion1.Size = 50;
              ParOpcion1.Value = Pregunta.Opcion1;
              SqlCmd.Parameters.Add(ParOpcion1);

                SqlParameter ParOpcion2 = new SqlParameter();
              ParOpcion2.ParameterName = "@OPCION2";
              ParOpcion2.SqlDbType = SqlDbType.VarChar;
              ParOpcion2.Size = 50;
              ParOpcion2.Value = Pregunta.Opcion2;
              SqlCmd.Parameters.Add(ParOpcion2);

               SqlParameter ParOpcion3 = new SqlParameter();
              ParOpcion3.ParameterName = "@OPCION3";
              ParOpcion3.SqlDbType = SqlDbType.VarChar;
              ParOpcion3.Size = 50;
              ParOpcion3.Value = Pregunta.Opcion3;
              SqlCmd.Parameters.Add(ParOpcion3);


               SqlParameter ParOpcion4 = new SqlParameter();
              ParOpcion4.ParameterName = "@OPCION4";
              ParOpcion4.SqlDbType = SqlDbType.VarChar;
              ParOpcion4.Size = 50;
              ParOpcion4.Value = Pregunta.Opcion4;
              SqlCmd.Parameters.Add(ParOpcion4);


               SqlParameter ParOpcion5 = new SqlParameter();
              ParOpcion5.ParameterName = "@OPCION5";
              ParOpcion5.SqlDbType = SqlDbType.VarChar;
              ParOpcion5.Size = 50;
              ParOpcion5.Value = Pregunta.Opcion5;
              SqlCmd.Parameters.Add(ParOpcion5);


              SqlParameter ParRespuesta = new SqlParameter();
              ParRespuesta.ParameterName = "@RESPUESTa";
              ParRespuesta.SqlDbType = SqlDbType.VarChar;
              ParRespuesta.Size = 50;
              ParRespuesta.Value = Pregunta.Respuesta;
              SqlCmd.Parameters.Add(ParRespuesta);



                    SqlParameter ParPuntaje= new SqlParameter();
              ParPuntaje.ParameterName = "@PUNTAJE";
              ParPuntaje.SqlDbType = SqlDbType.Int;
              ParPuntaje.Value = Pregunta.Puntaje;
              SqlCmd.Parameters.Add(ParPuntaje);




                SqlParameter ParEnunciado = new SqlParameter();
              ParEnunciado.ParameterName = "@ENUNCIADO";
              ParEnunciado.SqlDbType = SqlDbType.VarChar;
              ParEnunciado.Size = 50;
              ParEnunciado.Value = Pregunta.Enunciado;
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

      public string Eliminar(DPregunta Pregunta)
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
              SqlCmd.CommandText = "SP_DELETE_PREGUNTAS";
              SqlCmd.CommandType = CommandType.StoredProcedure;

             SqlParameter ParIdPregunta = new SqlParameter();
             ParIdPregunta.ParameterName = "@ID_PREGUNTA";
             ParIdPregunta.SqlDbType = SqlDbType.Int;
             ParIdPregunta.Value = Pregunta.Id_Pregunta;
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
          DataTable DtResultado = new DataTable("PREGUNTAS");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_Preguntas";
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

      // por ahora no ahy por filtro
      public DataTable BuscarNombre(DPregunta preguntas)
      {
          DataTable DtResultado = new DataTable("PREGUNTAS");
          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_Preguntas";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParTextoBuscar = new SqlParameter();
              ParTextoBuscar.ParameterName = "@textobuscar";
              ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
              ParTextoBuscar.Size = 50;
              ParTextoBuscar.Value = preguntas.TextoBuscar;
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


      ArrayList al = new ArrayList();
      public ArrayList LlevarPreguntas()
      {

          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCon.Open();
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_Preguntas";
              SqlCmd.CommandType = CommandType.StoredProcedure;



              SqlDataReader sdr = SqlCmd.ExecuteReader();
              while (sdr.Read())
              {
                  object[] values = new object[sdr.FieldCount];
                  sdr.GetValues(values);
                  al.Add(values);
              }
          }
          catch (Exception ex)
          {
              al = null;
          }
          return al;





      }


      ArrayList ali = new ArrayList();
      public ArrayList LlevarIdPregunta(DPregunta preguntas)
      {

          SqlConnection SqlCon = new SqlConnection();
          try
          {
              SqlCon.ConnectionString = Conexion.Cn;
              SqlCon.Open();
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.Connection = SqlCon;
              SqlCmd.CommandText = "spmostrar_PreguntasPorId";
              SqlCmd.CommandType = CommandType.StoredProcedure;

              SqlParameter ParTextoBuscar = new SqlParameter();
              ParTextoBuscar.ParameterName = "@textobuscar";
              ParTextoBuscar.SqlDbType = SqlDbType.Int;
              ParTextoBuscar.Size = 50;
              ParTextoBuscar.Value = preguntas.Id_Pregunta;
              SqlCmd.Parameters.Add(ParTextoBuscar);

              SqlDataReader sdr = SqlCmd.ExecuteReader();
              while (sdr.Read())
              {
                  object[] values = new object[sdr.FieldCount];
                  sdr.GetValues(values);
                  ali.Add(values);
              }
          }
          catch (Exception ex)
          {
              ali = null;
          }
          return ali;





      }

    }




    }

