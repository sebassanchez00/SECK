using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoLicenciaAplicablePreguntas
    {
        public short ID_Pregunta { get; set; }
        public short ID_Tipo_Licencia { get; set; }

        public VoLicenciaAplicablePreguntas()
        { }

        public VoLicenciaAplicablePreguntas(short iD_Pregunta, short iD_Tipo_Licencia)
        {
            this.ID_Pregunta = iD_Pregunta;
            this.ID_Tipo_Licencia = iD_Tipo_Licencia;
        }
    }
}
