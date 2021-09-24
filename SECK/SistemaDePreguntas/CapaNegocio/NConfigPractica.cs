using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NConfigPractica
    {

        public static string Insertar( string instalacion, string Clienteempresa, DateTime fechainicio, DateTime fechafin, string estado)
        {
            DConfigPractica Obj = new DConfigPractica();
           
            Obj.Instalacion = instalacion;
            Obj.ClienteEmpresa = Clienteempresa;
            Obj.FechaInicio = fechainicio;
            Obj.FechaFin = fechafin;
            Obj.Estado = estado;
         
            return Obj.Insertar(Obj);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idconfigpractica, string instalacion, string Clienteempresa, DateTime fechainicio, DateTime fechafin, string estado)
        {
            DConfigPractica Obj = new DConfigPractica();
            Obj.Id_ConfigPractica = idconfigpractica;
            Obj.Instalacion = instalacion;
            Obj.ClienteEmpresa = Clienteempresa;
            Obj.FechaInicio = fechainicio;
            Obj.FechaFin = fechafin;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }



        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    DPregunta Obj = new DPregunta();
        //    Obj.TextoBuscar = textobuscar;
        //    return Obj.BuscarNombre(Obj);
        //}

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idconfigpractica)
        {
            DConfigPractica Obj = new DConfigPractica();
            Obj.Id_ConfigPractica = idconfigpractica;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DConfigPractica().Mostrar();
        }
     
        /// <summary>
        /// Consulta tabla CONFIG_PRACTICA con las configuraciones que tiene la práctica
        /// </summary>
        /// <param name="Fechainicio"></param>
        /// <returns></returns>
        public static string [] MostrarConfiguracionesFecha(string Fechainicio)
        {
            DConfigPractica Obj = new DConfigPractica();
            Obj.TextoBuscar = Fechainicio;
            return Obj.MostrarConfiguracionPractica(Obj);
        }   
    }
}
