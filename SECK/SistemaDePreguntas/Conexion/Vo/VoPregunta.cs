using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoPregunta
    {
        public short Id { get; set; }
        public short Id_Tema { get; set; }
        public short Id_TipoPregunta  { get; set; }
        public string Enunciado { get; set; }
        public byte[] Imagen { get; set; }

        public VoPregunta() { }

        public VoPregunta(short id, short id_Tema, short id_TipoPregunta, string enunciado, byte[] imagen)
        {
            Id = id;
            Id_Tema = id_Tema;
            Id_TipoPregunta = id_TipoPregunta;
            Enunciado = enunciado;
            Imagen = imagen;
        }
    }
}
