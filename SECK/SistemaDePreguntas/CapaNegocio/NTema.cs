using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NTema
    {
        //Método Insertar que llama al método Insertar de la clase ??
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            DTema Obj = new DTema();
            Obj.Enunciado = nombre;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int id, int idCompetencia, string Enunciado , bool IncluirEnEvaluacion)
        {
            DTema Obj = new DTema();
            Obj.Id = id;
            Obj.Id_Competencia = idCompetencia;
            Obj.Enunciado = Enunciado;
            Obj.Incluir_En_Evaluacion = IncluirEnEvaluacion;
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
            Obj.Id = idTema;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTema().Mostrar();
        }
    }
}
