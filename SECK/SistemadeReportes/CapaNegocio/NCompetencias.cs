using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
  public   class NCompetencias
    {

        //Método Insertar que llama al método Insertar de la clase ??
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            DCompetencias Obj = new DCompetencias();

            Obj.NombreCompetencia = nombre;


            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idcompetencia, string nombrecompetencia)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.Id_Competencia = idcompetencia;

            Obj.NombreCompetencia = nombrecompetencia;

            return Obj.Editar(Obj);
        }



        public static DataTable BuscarNombre(string textobuscar)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idTema)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.Id_Competencia = idTema;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCompetencias().Mostrar();
        }




    }
}
