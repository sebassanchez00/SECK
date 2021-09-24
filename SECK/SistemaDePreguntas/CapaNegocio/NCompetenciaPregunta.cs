using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
 public   class NCompetenciaPregunta
    {

        public static string Insertar(int competencia,int pregunta)
        {
            DCompetenciaPregunta Obj = new DCompetenciaPregunta();

            Obj.IdCompetencia = competencia;
             Obj.IdPregunta = pregunta;


            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int id, int idcompetencia,int idpregunta)
        {
            DCompetenciaPregunta Obj = new DCompetenciaPregunta();
            Obj.Id = id;

            Obj.IdCompetencia = idcompetencia;
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
            DCompetenciaPregunta Obj = new DCompetenciaPregunta();
            Obj.Id = id;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCompetenciaPregunta().Mostrar();
        }




    }
}
