using CapaDatos;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class NConexion
    {
        /// <summary>
        /// Evalua si existe conexoón con la base de datos. Valida el string de conexión.
        /// </summary>
        /// <returns></returns>
        public static bool TestCon()
        {
            return Conexion.TestCon();
        }

        /// <summary>
        /// Guarda un nuevo string de conexion
        /// </summary>
        public static void EscribirConString()
        {
            Conexion.EscribirConString();
        }
    }
}
