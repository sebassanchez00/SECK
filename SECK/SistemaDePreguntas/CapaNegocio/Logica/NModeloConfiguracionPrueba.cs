using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica
{
    /// <summary>
    /// Representa clase que almacena las configuraciones de la prueba
    /// </summary>
    public class NModeloConfiguracionPrueba
    {
        //Cedula ccEvaluado;
        //pb_logoPresentacion.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);       => Esto debería incluise en la clase
        //pb_logoUsuario.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);            => Esto debería incluise en la clase
        //pb_logoBionetria.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);          => Esto debería incluise en la clase
        //pb_logoCuestionario.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);       => Esto debería incluise en la clase
        //pb_logoResultado.Image = Image.FromFile(Properties.Settings.Default.RutaLogo);          => Esto debería incluise en la clase
        public EnumTipoLicencia LicenciaPorDefecto { get; set; }    //Deberia solo ser get
        public EnumTipoLicencia LicenciaDelEvaluado { get; set; }   //Deberia solo ser get
    public int numeroPreguntas { get; set; }

        public NModeloConfiguracionPrueba()
        {

        }

    }
}
