using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoRegistroPreguntas
    {
        public string id_Evaluacion { get; set; }
        public string pregunta { get; set; }
        public string respuestaDelUsuario { get; set; }
        public bool respondioCorrectamente { get; set; }
        public byte[] imagen { get; set; }

        public VoRegistroPreguntas()
        {
        }
    }
}
