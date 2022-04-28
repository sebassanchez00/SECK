using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Enums
{
        public enum TipoPreg
        {
            SelMul = 1,
            AbiertaNumerica = 2,
            VerdaderoFalso = 3,
            SelMulImg = 4
        }

        public enum Genero
        {
            M = 1,
            F = 2
        }

        public enum TipoLicencia
        {
            A1 = 1,
            A2 = 2,
            B1 = 3,
            B2 = 4,
            B3 = 5,
            C1 = 6,
            C2 = 7,
            C3 = 8,
            SinLicencia = 9
        }

        public enum Tema
        {
            Aspectos_Generales = 1,
            Regimen_Sancionatorio = 2,
            Comportamiento_Peaton = 3,
            Senales_Transito = 4
        }

    [Flags]
        public enum EnumMultiple_TipoLicencia
        {
            //Tipo de enumaracion que puede tener varios elementos agrupados. (En este caso el elemento "Todas"). Necesita valores tipo booleano
            A1 = 0b_0000_0000,
            A2 = 0b_0000_0001,
            B1 = 0b_0000_0010,
            B2 = 0b_0000_0100,
            B3 = 0b_0000_1000,
            C1 = 0b_0001_0000,
            C2 = 0b_0010_0000,
            C3 = 0b_0100_0000,
            SinLicencia = 0b_1000_0000,
            Todas = A1 | A2 | B1 | B2 | B3 | C1 | C2 | C3
        }

}
