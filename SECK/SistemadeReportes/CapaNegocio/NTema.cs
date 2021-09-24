using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
public    class NTema
    {

        //Método Insertar que llama al método Insertar de la clase ??
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            DTema Obj = new DTema();

            Obj.NombreTema = nombre;


            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idtema, string nombreTema)
        {
            DTema Obj = new DTema();
            Obj.Id_Tema = idtema;

            Obj.NombreTema = nombreTema;

            return Obj.Editar(Obj);
        }



        public static DataTable BuscarNombre(string textobuscar)
        {
            DTema Obj = new DTema();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idTema)
        {
            DTema Obj = new DTema();
            Obj.Id_Tema = idTema;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTema().Mostrar();
        }



    }
}
