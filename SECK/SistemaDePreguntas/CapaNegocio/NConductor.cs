using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NConductor
    {
        public static string Insertar(string cedula, string nombre, string apellidos, int tipolicencia, string CodigoLicencia, string empresa, int genero,  byte[] Huella, byte[] imagen, DateTime FechaNacimiento)
        {
            DConductor Obj = new DConductor();
            Obj.Cedulas = cedula;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Tipo_Licencia = tipolicencia;
            Obj.Codigo_Licencia = CodigoLicencia;
            Obj.Empresa = empresa;
            Obj.Genero = genero;
            Obj.Huella = Huella;
            Obj.Fotografia = imagen;
            Obj.Fecha_Nacimiento = FechaNacimiento;
            return Obj.insertar(Obj);
        }

        public static string Editar(string cedula, string nombre, string apellidos, int tipolicencia, string empresa, int genero, byte[] imagen)
        {
            DConductor Obj = new DConductor();
            Obj.Cedulas = cedula;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Tipo_Licencia = tipolicencia;
            Obj.Empresa = empresa;
            Obj.Genero = genero;
            Obj.Fotografia = imagen;
            return Obj.Editar(Obj);
        }

        /// <summary>
        /// Devuelve el número de registros de la tabla TU_CONDUCTOR
        /// </summary>
        /// <param name="textobucar">La cédula</param>
        /// <returns></returns>
        public static int ConductorExiste(string textobucar)
        {
            DConductor Obj = new DConductor();
            Obj.TextoBuscar = textobucar;
            return Obj.ConductorExiste(Obj);
        }

        /// <summary>
        /// Busca usuario en tabla usuarios
        /// </summary>
        /// <param name="textobucar"></param>
        /// <returns></returns>
        public static string[] MostrarDatos_str(string textobucar)
        {
            DConductor Obj = new DConductor();
            Obj.TextoBuscar = textobucar;
            return Obj.MostrarUsuario_str(Obj);
        }

        /// <summary>
        /// Busca usuario en tabla usuarios
        /// </summary>
        /// <param name="textobuscar"></param>
        /// <returns></returns>
        public static DataTable MostrarDatos_dt(string textobuscar)
        {
            DConductor Obj = new DConductor();
            Obj.TextoBuscar = textobuscar;
            return Obj.MostrarUsuario_dt(Obj);
        }

        /// <summary>
        /// Retorna todos los conductores desde la tabla TU_CONDUCTOR
        /// </summary>
        /// <returns></returns>
        public static DataTable Mostrar()
        {
            return new DConductor().Mostrar();
        }
    }
}
