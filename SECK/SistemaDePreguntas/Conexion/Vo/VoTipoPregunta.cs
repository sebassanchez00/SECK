using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoTipoPregunta
    {
        public short Id { get; set; }
        public string Enunciado { get; set; }

        public VoTipoPregunta()
        {
        }

        public VoTipoPregunta(short id, string enunciado)
        {
            Id = id;
            Enunciado = enunciado;
        }
    }
}
