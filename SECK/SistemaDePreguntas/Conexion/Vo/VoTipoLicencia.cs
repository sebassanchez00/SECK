using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos.Vo
{
    public class VoTipoLicencia
    {
        public short Id { get; set; }
        public string TipoLicencia { get; set; }
        public string Descripciòn { get; set; }

        public VoTipoLicencia()    {     }

        public VoTipoLicencia(short id, string tipoLicencia, string descripciòn)
        {
            this.Id = id;
            this.TipoLicencia = tipoLicencia;
            this.Descripciòn = descripciòn;
        }
    }
}
