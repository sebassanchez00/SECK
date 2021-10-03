using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoTema
    {
        public short Id { get; set; }
        public short Id_Competencia { get; set; }
        public string Enunciado { get; set; }
        public bool IncluirEnEvaluacion { get; set; }

        public VoTema()
        {
        }

        public VoTema(short id, short id_Competencia, string enunciado, bool incluirEnEvaluacion)
        {
            Id = id;
            Id_Competencia = id_Competencia;
            Enunciado = enunciado;
            IncluirEnEvaluacion = incluirEnEvaluacion;
        }
    }
}
