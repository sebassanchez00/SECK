using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    class VoConductor
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short TipoLicencia { get; set; }
        public string CodigoLicencia { get; set; }
        public string Empresa { get; set; }
        public short Genero { get; set; }
        public byte[] Huella { get; set; }
        public byte[] Fotografia { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public VoConductor()
        { }

        public VoConductor(string cedula, string nombre, string apellido, short tipoLicencia, string codigoLicencia, string empresa, short genero, byte[] huella, byte[] fotografia, DateTime fechaNacimiento)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            TipoLicencia = tipoLicencia;
            CodigoLicencia = codigoLicencia;
            Empresa = empresa;
            Genero = genero;
            Huella = huella;
            Fotografia = fotografia;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
