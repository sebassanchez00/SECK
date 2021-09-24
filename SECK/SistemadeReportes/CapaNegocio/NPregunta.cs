using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
  public   class NPregunta
    {

        //Método Insertar que llama al método Insertar de la clase ??
        //de la CapaDatos
        public static string Insertar(int id_Tipo_Pregunta,string respuesta,string opcion1,string opcion2,string opcion3, string opcion4 , string opcion5,string enunciado)
        {
            DPregunta Obj = new DPregunta();

            Obj.Id_TipoPregunta = id_Tipo_Pregunta;
            Obj.Opcion1 =opcion1;
            Obj.Opcion2=opcion2;
            Obj.Opcion3=opcion3;
            Obj.Opcion4=opcion4;
            Obj.Opcion5=opcion5;
            Obj.Enunciado =enunciado;
            Obj.Respuesta = respuesta;

            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idpregunta ,int id_Tipo_Pregunta,string respuesta,string opcion1,string opcion2,string opcion3, string opcion4 , string opcion5,string enunciado)
        {
              DPregunta Obj = new DPregunta();
            Obj.Id_Pregunta = idpregunta;
            Obj.Id_TipoPregunta = id_Tipo_Pregunta;
            Obj.Opcion1 =opcion1;
            Obj.Opcion2=opcion2;
            Obj.Opcion3=opcion3;
            Obj.Opcion4=opcion4;
            Obj.Opcion5=opcion5;
            Obj.Enunciado =enunciado;
            Obj.Respuesta = respuesta;
            return Obj.Editar(Obj);
        }



        public static DataTable BuscarNombre(string textobuscar)
        {
            DPregunta Obj = new DPregunta();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idpregunta)
        {
            DPregunta Obj = new DPregunta();
            Obj.Id_Pregunta= idpregunta;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DPregunta().Mostrar();
        }

        public static ArrayList LLevarPreguntas()
        {

            DPregunta Obj = new DPregunta();
            return Obj.LlevarPreguntas();


        }


        public static ArrayList LLevarIdPreguntas(int ID)
        {

            DPregunta Obj = new DPregunta();
            Obj.Id_Pregunta = ID;
            return Obj.LlevarIdPregunta(Obj);


        }
    }











    }

