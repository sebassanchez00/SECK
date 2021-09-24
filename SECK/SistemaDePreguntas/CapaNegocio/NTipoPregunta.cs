using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;
namespace CapaNegocio
{
    public class NTipoPregunta
    {

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            DTipoPregunta Obj = new DTipoPregunta();
        
            Obj.TipoPregunta = nombre;
         

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idtipopregunta,  string nombreTipoPregunta)
        {
            DTipoPregunta Obj = new DTipoPregunta();
            Obj.Id_TipoPregunta = idtipopregunta;
            
            Obj.TipoPregunta = nombreTipoPregunta;
           
            return Obj.Editar(Obj);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DTipoPregunta Obj = new DTipoPregunta();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }



        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            DTipoPregunta Obj = new DTipoPregunta();
            Obj.Id_TipoPregunta = idarticulo;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DTipoPregunta().Mostrar();
        }

    }
}
