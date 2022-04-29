using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoRegistroPreguntas
    {
        public string Id_Evaluacion { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaDelUsuario { get; set; }
        public bool RespondioCorrectamente { get; set; }
        public byte[] Imagen { get; set; }

        public VoRegistroPreguntas()
        {
        }

        public VoRegistroPreguntas(string id_Evaluacion, string pregunta, string respuestaDelUsuario, bool respondioCorrectamente, byte[] imagen)
        {
            Id_Evaluacion = id_Evaluacion;
            Pregunta = pregunta;
            RespuestaDelUsuario = respuestaDelUsuario;
            RespondioCorrectamente = respondioCorrectamente;
            Imagen = imagen;
        }
    }
}
