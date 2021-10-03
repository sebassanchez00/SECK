using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoCompetencia
    {
        public short ID { get; set; }
        public string Enunciado { get; set; }

        public VoCompetencia() { }

        public VoCompetencia(short iD, string enunciado)
        {
            ID = iD;
            Enunciado = enunciado;
        }
    }
}
