using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class NConfiguracionBD
    {
        /// <summary>
        /// Inserta los datos básicos en las tablas [TU_GENERO], [TU_TIPO_LICENCIA], [TME_TIPO_PREGUNTA]
        /// </summary>
        public static void InsertarDatosBasicos()
        {
            DConfiguracionBD.InsertarDatosBasicos();
        }
    }
}
