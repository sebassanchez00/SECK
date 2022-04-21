using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoResultadoPorTema
    {
        public string ID_Evaluacion { get; set; }
        public short ID_Tema { get; set; }
        public string Enunciado_Tema { get; set; }
        public float Puntaje { get; set; }

        public VoResultadoPorTema()
        { }

        public VoResultadoPorTema(string iD_Evaluacion, short iD_Tema, string enunciado_Tema, float puntaje)
        {
            this.ID_Evaluacion = iD_Evaluacion;
            this.ID_Tema = iD_Tema;
            this.Enunciado_Tema = enunciado_Tema;
            this.Puntaje = puntaje;
        }
    }
}
