using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoOpcionRespuesta
    {
        public short ID { get; set; }
        public short ID_Pregunta { get; set; }
        public string Enunciado { get; set; }
        public bool Es_Correcta { get; set; }

        public VoOpcionRespuesta() { }

        public VoOpcionRespuesta(short iD, short iD_Pregunta, string enunciado, bool es_Correcta)
        {
            this.ID = iD;
            this.ID_Pregunta = iD_Pregunta;
            this.Enunciado = enunciado;
            this.Es_Correcta = es_Correcta;
        }
    }
}
