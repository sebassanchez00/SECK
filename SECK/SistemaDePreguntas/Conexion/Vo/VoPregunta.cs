using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoPregunta
    {
        public int ID { get; set; }
        public int ID_Tema { get; set; }
        public int ID_TipoPregunta { get; set; }
        public string Enunciado { get; set; }
        public Byte[] Imagen { get; set; }

        public VoPregunta(int iD, int iD_Tema, int iD_TipoPregunta, string enunciado, byte[] imagen)
        {
            ID = iD;
            ID_Tema = iD_Tema;
            ID_TipoPregunta = iD_TipoPregunta;
            Enunciado = enunciado;
            Imagen = imagen;
        }
    }
}
