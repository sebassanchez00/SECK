using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NTipoLicencia
    {
        /// <summary>
        /// Trae todos los elementos de la tabla TU_TIPO_LICENCIA en un DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable Mostrar()
        {
            return new DTipoLicencia().Mostrar();
        }
    }
}
