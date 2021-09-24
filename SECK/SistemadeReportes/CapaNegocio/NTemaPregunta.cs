using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
   public class NTemaPregunta
    {

        public static string Insertar(int Tema, int pregunta)
        {
            DTemaPregunta Obj = new DTemaPregunta();

            Obj.IdTema = Tema;
            Obj.IdPregunta = pregunta;

            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int íd, int idTema, int idpregunta)
        {
            DTemaPregunta Obj = new DTemaPregunta();
            Obj.Id = íd;

            Obj.IdTema = idTema;
            Obj.IdPregunta = idpregunta;

            return Obj.Editar(Obj);
        }



        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    DCompetenciaPregunta Obj = new DCompetenciaPregunta();
        //    Obj.TextoBuscar = textobuscar;
        //    //return Obj.BuscarNombre(Obj);
        //}

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int id)
        {
            DTemaPregunta Obj = new DTemaPregunta();
            Obj.Id = id;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTemaPregunta().Mostrar();
        }




    }
}
