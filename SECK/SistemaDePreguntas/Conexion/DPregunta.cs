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
    public class DPregunta
    {
        private int _Id_Pregunta;
        private int _Tema;
        private int _Id_TipoPregunta;
        private string _Enunciado;
        private byte[] _Imagen;
        private string _Opcion1;
        private bool _EsCorrectaOp1;
        private string _Opcion2;
        private bool _EsCorrectaOp2;
        private string _Opcion3;
        private bool _EsCorrectaOp3;
        private string _Opcion4;
        private bool _EsCorrectaOp4;
        private int _Puntaje;
        private string _TextoBuscar;

        public int Id_Pregunta
        {
            get { return _Id_Pregunta; }
            set { _Id_Pregunta = value; }
        }

        public int Tema
        {
            get { return _Tema; }
            set { _Tema = value; }
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

        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string Opcion1
        {
            get { return _Opcion1; }
            set { _Opcion1 = value; }
        }

        public bool EsCorrectaOp1
        {
            get { return _EsCorrectaOp1; }
            set { _EsCorrectaOp1 = value; }
        }

        public string Opcion2
        {
            get { return _Opcion2; }
            set { _Opcion2 = value; }
        }

        public bool EsCorrectaOp2
        {
            get { return _EsCorrectaOp2; }
            set { _EsCorrectaOp2 = value; }
        }

        public string Opcion3
        {
            get { return _Opcion3; }
            set { _Opcion3 = value; }
        }

        public bool EsCorrectaOp3
        {
            get { return _EsCorrectaOp3; }
            set { _EsCorrectaOp3 = value; }
        }

        public string Opcion4
        {
            get { return _Opcion4; }
            set { _Opcion4 = value; }
        }

        public bool EsCorrectaOp4
        {
            get { return _EsCorrectaOp4; }
            set { _EsCorrectaOp4 = value; }
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

        public DPregunta(int Id_Pregunta, int Tema, int Id_TipoPregunta, string Enunciado, byte[] Imagen, string Opcion1, bool EsCorrectaOp1, string Opcion2, bool EsCorrectaOp2, string Opcion3, bool EsCorrectaOp3, string Opcion4, bool EsCorrectaOp4, int puntaje)
        {
            this.Id_Pregunta = Id_Pregunta;
            this.Tema = Tema;
            this.Id_TipoPregunta = Id_TipoPregunta;
            this.Enunciado = Enunciado;
            this.Imagen = Imagen;
            this.Opcion1 = Opcion1;
            this.EsCorrectaOp1 = EsCorrectaOp1;
            this.Opcion2 = Opcion2;
            this.EsCorrectaOp2 = EsCorrectaOp2;
            this.Opcion3 = Opcion3;
            this.EsCorrectaOp3 = EsCorrectaOp3;
            this.Opcion4 = Opcion4;
            this.EsCorrectaOp4 = EsCorrectaOp4;
            this.Puntaje = puntaje;
        }

        /// <summary>
        /// Inserta pregunta en tabla TME_Pregunta. Tiene los parámetros @ID_TEMA @TIPO_PREGUNTA @ENUNCIADO @IMAGEN @ENUNCIADO_OP1 @ES_CORRECTA_OP1 @ENUNCIADO_OP2 @ES_CORRECTA_OP2 @ENUNCIADO_OP3 @ES_CORRECTA_OP3 @ENUNCIADO_OP4 @ES_CORRECTA_OP4. Para pregunta de SELECCIÓN MÚLTIPLE se ignora parámetro @IMAGEN. Para pregunta ABIERTA NUMÉRICA se ignoran @IMAGEN y las opcines con sus respuestas. Se inserta 1 sola opcion correcta. Para pregunta VERDADERO FALSO se ignoran @IMAGE y las opcines con sus respuestas, se insertan dos opciones, el usuario del SP debe poner verdadero y falso en los enunciados. Para pregunta de SELECCIÓN MÚLTIPLE CON IMAGEN se usan todos los parámetros
        /// </summary>
        /// <param name="Pregunta"></param>
        /// <returns></returns>
        public string Insertar(DPregunta Pregunta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_PREGUNTAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTema = new SqlParameter();
                ParIdTema.ParameterName = "@ID_TEMA";
                ParIdTema.SqlDbType = SqlDbType.SmallInt;
                ParIdTema.Value = Pregunta.Tema;
                SqlCmd.Parameters.Add(ParIdTema);

                SqlParameter ParIdTipoPregunta = new SqlParameter();
                ParIdTipoPregunta.ParameterName = "@TIPO_PREGUNTA ";
                ParIdTipoPregunta.SqlDbType = SqlDbType.SmallInt;
                ParIdTipoPregunta.Value = Pregunta.Id_TipoPregunta;
                SqlCmd.Parameters.Add(ParIdTipoPregunta);

                SqlParameter ParEnunciado = new SqlParameter();
                ParEnunciado.ParameterName = "@ENUNCIADO";
                ParEnunciado.SqlDbType = SqlDbType.VarChar;
                ParEnunciado.Size = -1; //MAX
                ParEnunciado.Value = Pregunta.Enunciado;
                SqlCmd.Parameters.Add(ParEnunciado);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@IMAGEN";
                ParImagen.SqlDbType = SqlDbType.VarBinary;
                ParImagen.Size = -1; //MAX
                ParImagen.Value = Pregunta.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParOpcion1 = new SqlParameter();
                ParOpcion1.ParameterName = "@ENUNCIADO_OP1";
                ParOpcion1.SqlDbType = SqlDbType.VarChar;
                ParOpcion1.Size = -1;
                ParOpcion1.Value = Pregunta.Opcion1;
                SqlCmd.Parameters.Add(ParOpcion1);

                SqlParameter ParEsCorrectaOp1 = new SqlParameter();
                ParEsCorrectaOp1.ParameterName = "@ES_CORRECTA_OP1";
                ParEsCorrectaOp1.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp1.Value = Pregunta.EsCorrectaOp1;
                SqlCmd.Parameters.Add(ParEsCorrectaOp1);

                SqlParameter ParOpcion2 = new SqlParameter();
                ParOpcion2.ParameterName = "@ENUNCIADO_OP2";
                ParOpcion2.SqlDbType = SqlDbType.VarChar;
                ParOpcion2.Size = -1;
                ParOpcion2.Value = Pregunta.Opcion2;
                SqlCmd.Parameters.Add(ParOpcion2);

                SqlParameter ParEsCorrectaOp2 = new SqlParameter();
                ParEsCorrectaOp2.ParameterName = "@ES_CORRECTA_OP2";
                ParEsCorrectaOp2.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp2.Value = Pregunta.EsCorrectaOp2;
                SqlCmd.Parameters.Add(ParEsCorrectaOp2);

                SqlParameter ParOpcion3 = new SqlParameter();
                ParOpcion3.ParameterName = "@ENUNCIADO_OP3";
                ParOpcion3.SqlDbType = SqlDbType.VarChar;
                ParOpcion3.Size = -1;
                ParOpcion3.Value = Pregunta.Opcion3;
                SqlCmd.Parameters.Add(ParOpcion3);

                SqlParameter ParEsCorrectaOp3 = new SqlParameter();
                ParEsCorrectaOp3.ParameterName = "@ES_CORRECTA_OP3";
                ParEsCorrectaOp3.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp3.Value = Pregunta.EsCorrectaOp3;
                SqlCmd.Parameters.Add(ParEsCorrectaOp3);

                SqlParameter ParOpcion4 = new SqlParameter();
                ParOpcion4.ParameterName = "@ENUNCIADO_OP4";
                ParOpcion4.SqlDbType = SqlDbType.VarChar;
                ParOpcion4.Size = -1;
                ParOpcion4.Value = Pregunta.Opcion4;
                SqlCmd.Parameters.Add(ParOpcion4);

                SqlParameter ParEsCorrectaOp4 = new SqlParameter();
                ParEsCorrectaOp4.ParameterName = "@ES_CORRECTA_OP4";
                ParEsCorrectaOp4.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp4.Value = Pregunta.EsCorrectaOp4;
                SqlCmd.Parameters.Add(ParEsCorrectaOp4);

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

        /// <summary>
        /// Inserta pregunta en tabla TME_Pregunta. Tiene los parámetros @ID_TEMA @TIPO_PREGUNTA @ENUNCIADO @IMAGEN @ENUNCIADO_OP1 @ES_CORRECTA_OP1 @ENUNCIADO_OP2 @ES_CORRECTA_OP2 @ENUNCIADO_OP3 @ES_CORRECTA_OP3 @ENUNCIADO_OP4 @ES_CORRECTA_OP4. Para pregunta de SELECCIÓN MÚLTIPLE se ignora parámetro @IMAGEN. Para pregunta ABIERTA NUMÉRICA se ignoran @IMAGEN y las opcines con sus respuestas. Se inserta 1 sola opcion correcta. Para pregunta VERDADERO FALSO se ignoran @IMAGE y las opcines con sus respuestas, se insertan dos opciones, el usuario del SP debe poner verdadero y falso en los enunciados. Para pregunta de SELECCIÓN MÚLTIPLE CON IMAGEN se usan todos los parámetros
        /// </summary>
        /// <param name="Pregunta"></param>
        /// <returns></returns>
        public short Insertar(VoPreguntaYOpciones Pregunta)
        {
            short id=0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_INSERTAR_PREGUNTAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTema = new SqlParameter();
                ParIdTema.ParameterName = "@ID_TEMA";
                ParIdTema.SqlDbType = SqlDbType.SmallInt;
                ParIdTema.Value = Pregunta.Id_Tema;
                SqlCmd.Parameters.Add(ParIdTema);

                SqlParameter ParIdTipoPregunta = new SqlParameter();
                ParIdTipoPregunta.ParameterName = "@TIPO_PREGUNTA ";
                ParIdTipoPregunta.SqlDbType = SqlDbType.SmallInt;
                ParIdTipoPregunta.Value = Pregunta.Id_TipoPregunta;
                SqlCmd.Parameters.Add(ParIdTipoPregunta);

                SqlParameter ParEnunciado = new SqlParameter();
                ParEnunciado.ParameterName = "@ENUNCIADO";
                ParEnunciado.SqlDbType = SqlDbType.VarChar;
                ParEnunciado.Size = -1; //MAX
                ParEnunciado.Value = Pregunta.Enunciado;
                SqlCmd.Parameters.Add(ParEnunciado);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@IMAGEN";
                ParImagen.SqlDbType = SqlDbType.VarBinary;
                ParImagen.Size = -1; //MAX
                ParImagen.Value = Pregunta.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParOpcion1 = new SqlParameter();
                ParOpcion1.ParameterName = "@ENUNCIADO_OP1";
                ParOpcion1.SqlDbType = SqlDbType.VarChar;
                ParOpcion1.Size = -1;
                ParOpcion1.Value = Pregunta.Opciones[0].Enunciado;
                SqlCmd.Parameters.Add(ParOpcion1);

                SqlParameter ParEsCorrectaOp1 = new SqlParameter();
                ParEsCorrectaOp1.ParameterName = "@ES_CORRECTA_OP1";
                ParEsCorrectaOp1.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp1.Value = Pregunta.Opciones[0].Es_Correcta;
                SqlCmd.Parameters.Add(ParEsCorrectaOp1);

                SqlParameter ParOpcion2 = new SqlParameter();
                ParOpcion2.ParameterName = "@ENUNCIADO_OP2";
                ParOpcion2.SqlDbType = SqlDbType.VarChar;
                ParOpcion2.Size = -1;
                ParOpcion2.Value = Pregunta.Opciones[1].Enunciado;
                SqlCmd.Parameters.Add(ParOpcion2);

                SqlParameter ParEsCorrectaOp2 = new SqlParameter();
                ParEsCorrectaOp2.ParameterName = "@ES_CORRECTA_OP2";
                ParEsCorrectaOp2.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp2.Value = Pregunta.Opciones[1].Es_Correcta;
                SqlCmd.Parameters.Add(ParEsCorrectaOp2);

                SqlParameter ParOpcion3 = new SqlParameter();
                ParOpcion3.ParameterName = "@ENUNCIADO_OP3";
                ParOpcion3.SqlDbType = SqlDbType.VarChar;
                ParOpcion3.Size = -1;
                ParOpcion3.Value = Pregunta.Opciones[2].Enunciado;
                SqlCmd.Parameters.Add(ParOpcion3);

                SqlParameter ParEsCorrectaOp3 = new SqlParameter();
                ParEsCorrectaOp3.ParameterName = "@ES_CORRECTA_OP3";
                ParEsCorrectaOp3.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp3.Value = Pregunta.Opciones[2].Es_Correcta;
                SqlCmd.Parameters.Add(ParEsCorrectaOp3);

                SqlParameter ParOpcion4 = new SqlParameter();
                ParOpcion4.ParameterName = "@ENUNCIADO_OP4";
                ParOpcion4.SqlDbType = SqlDbType.VarChar;
                ParOpcion4.Size = -1;
                ParOpcion4.Value = Pregunta.Opciones[3].Enunciado;
                SqlCmd.Parameters.Add(ParOpcion4);

                SqlParameter ParEsCorrectaOp4 = new SqlParameter();
                ParEsCorrectaOp4.ParameterName = "@ES_CORRECTA_OP4";
                ParEsCorrectaOp4.SqlDbType = SqlDbType.Bit;
                ParEsCorrectaOp4.Value = Pregunta.Opciones[3].Es_Correcta;
                SqlCmd.Parameters.Add(ParEsCorrectaOp4);

                //Ejecutamos nuestro comando
                id =  (short)SqlCmd.ExecuteScalar(); //(*) se debe validar cuando no pueda hacer el unboxing o no hace el insert
                            }
            catch (Exception ex)
            {
                // (*) Poner la excepción
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return id; //(*) evitar que se retorne 0
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

                SqlParameter ParIdTipoPregunta = new SqlParameter();
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

                //SqlParameter ParRespuesta = new SqlParameter();
                //ParRespuesta.ParameterName = "@RESPUESTa";
                //ParRespuesta.SqlDbType = SqlDbType.VarChar;
                //ParRespuesta.Size = 50;
                //ParRespuesta.Value = Pregunta.Respuesta;
                //SqlCmd.Parameters.Add(ParRespuesta);

                SqlParameter ParPuntaje = new SqlParameter();
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

        /// <summary>
        /// Elimina pregunta de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string EliminarSelMulPorID(short ID)
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
                SqlCmd.CommandText = "SP_DELETE_PREGUNTAS_SEL_MUL";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPregunta = new SqlParameter();
                ParIdPregunta.ParameterName = "@ID_PREGUNTA";
                ParIdPregunta.SqlDbType = SqlDbType.SmallInt;
                ParIdPregunta.Value = ID;
                SqlCmd.Parameters.Add(ParIdPregunta);

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

        /// <summary>
        /// Elimina preguntas abierta numérica de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA 
        /// </summary>
        /// <returns></returns>
        public string EliminarAbNum()
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
                SqlCmd.CommandText = "SP_DELETE_PREGUNTAS_AB_NUM_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Elimina preguntas seleccion múltiple con imagen de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA 
        /// </summary>
        /// <returns></returns>
        public string EliminarSelMulImg()
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
                SqlCmd.CommandText = "SP_DELETE_PREGUNTAS_SEL_MUL_IMG_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Elimina preguntas seleccion múltiple de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA 
        /// </summary>
        /// <returns></returns>
        public string EliminarSelMul()
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
                SqlCmd.CommandText = "SP_DELETE_PREGUNTAS_SEL_MUL_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Elimina preguntas verdadero falso de tabla TME_PREGUNTAS y sus opciones en TME_OPCION_RESPUESTA 
        /// </summary>
        /// <returns></returns>
        public string EliminarVF()
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
                SqlCmd.CommandText = "SP_DELETE_PREGUNTAS_VF_TODAS";
                SqlCmd.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Trae las preguntas de selección múltiple de la tabla TME_PREGUNTAS con FK formateadas. Retorna null si hay falla
        /// </summary>
        /// <returns></returns>
        public DataTable MostrarSelMul()
        {
            DataTable DtResultado = new DataTable("PREGUNTAS");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_SEL_MUL";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                ///SSS
                DtResultado = null;
            }
            return DtResultado;
        }

        // No esta implementado el SP con parametro @textobuscar
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
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        /// <summary>
        /// Selecciona preguntas de tabla TME_PREGUNTAS. Retorna null si hay falla
        /// </summary>
        /// <returns></returns>
        public ArrayList LlevarPreguntasPorTema(short ID_Tema)
        {
            ArrayList al = new ArrayList();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_POR_TEMA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTema = new SqlParameter();
                ParTema.ParameterName = "@ID_TEMA";
                ParTema.SqlDbType = SqlDbType.SmallInt;
                ParTema.Value = ID_Tema;

                SqlCmd.Parameters.Add(ParTema);

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    object[] values = new object[sdr.FieldCount];
                    sdr.GetValues(values);
                    al.Add(values);
                }
            }
            catch (Exception)
            {
                al = null;
            }
            return al;
        }

        /// <summary>
        /// Selecciona pregunta por ID desde tabla TME_PREGUNTAS. Tienen sus FK formateadas
        /// </summary>
        /// <param name="preguntas"></param>
        /// <returns></returns>
        public ArrayList LlevarIdPregunta(DPregunta preguntas)
        {
            ArrayList ali = new ArrayList();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID_PREGUNTA";
                ParId.SqlDbType = SqlDbType.SmallInt;
                ParId.Value = preguntas.Id_Pregunta;
                SqlCmd.Parameters.Add(ParId);

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    object[] values = new object[sdr.FieldCount];
                    sdr.GetValues(values);
                    ali.Add(values);
                }
            }
            catch (Exception)
            {
                ali = null;
            }
            return ali;
        }

        /// <summary>
        /// Selecciona pregunta por ID desde tabla TME_PREGUNTAS. Tienen sus FK formateadas
        /// </summary>
        /// <param name="IdPreguntas"></param>
        /// <returns></returns>
        public object[] LlevarIdPregunta(short IdPreguntas)
        {
            object[] rta = null;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_POR_ID";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ID_PREGUNTA";
                ParId.SqlDbType = SqlDbType.SmallInt;
                ParId.Value = IdPreguntas;
                SqlCmd.Parameters.Add(ParId);

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    rta = new object[sdr.FieldCount];
                    rta[0] = sdr.GetInt16(0);
                    rta[1] = sdr.GetString(1);
                    rta[2] = sdr.GetString(2);
                    rta[3] = sdr.GetString(3);
                    byte[] auxByte;
                    auxByte = sdr.GetValue(4) is DBNull ? null : (byte[])sdr.GetValue(4);
                }
            }
            catch (Exception ex)
            {
                rta = null;
            }
            return rta;
        }

        /// <summary>
        ///  Selecciona todas las preguntas desde tabla
        /// </summary>
        /// <returns></returns>
        public ArrayList LlevarPreguntasEvaluacion()
        {
            ArrayList ali = new ArrayList();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_EVALUACION";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    object[] values = new object[sdr.FieldCount];
                    sdr.GetValues(values);
                    ali.Add(values);
                }
            }
            catch (Exception)
            {
                ali = null;
            }
            return ali;
        }

        /// <summary>
        ///  Selecciona todas las preguntas desde tabla TME_PREGUNTAS y devuelve lista de Vo
        /// </summary>
        /// <returns></returns>
        public List<VoPregunta> LlevarPreguntasEvaluacionVo()
        {
            List<VoPregunta> Lista = new List<VoPregunta>();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SP_MOSTRAR_PREGUNTAS_EVALUACION";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    //object[] values = new object[sdr.FieldCount];
                    //sdr.GetValues(values);
                    //Valida si tiene DBnull, en caso de que sí asigna null normal al campo.
                    byte[] auxByte;
                    auxByte = sdr.GetValue(4) is DBNull ? null : (byte[])sdr.GetValue(4);

                    Lista.Add(
                        new VoPregunta(
                            sdr.GetInt16(0),
                            sdr.GetInt16(1),
                            sdr.GetInt16(2),
                            sdr.GetString(3),
                            auxByte)
                        );
                }
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }
    }
}

