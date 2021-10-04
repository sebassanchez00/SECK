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

        EnumTipoLicencia LicenciaPorDefecto_;
        EnumTipoLicencia LicenciaDelEvaluado_;

        public EnumTipoLicencia LicenciaPorDefecto  //Deberia solo ser get
        {
            get { return LicenciaPorDefecto_; }
            set { LicenciaPorDefecto_ = value; }
        }

        public EnumTipoLicencia LicenciaDelEvaluado //Deberia solo ser get
        {
            get { return LicenciaDelEvaluado_; }
            set { LicenciaDelEvaluado_ = value; }
        }   //Deberia solo ser get

        public int numeroPreguntas { get; set; }

        public NModeloConfiguracionPrueba(int nPreguntas)
        {
            this.numeroPreguntas = nPreguntas;
            this.LicenciaPorDefecto = EnumTipoLicencia.SinLicencia;
            this.LicenciaDelEvaluado = EnumTipoLicencia.SinLicencia;
        }

        /// <summary>
        /// Asigna la propiedad (enumeración) LicenciaPorDefecto_ dependiendo del entero ingresado
        /// </summary>
        /// <param name="licenciaPorDefecto"></param>
        public void setLicenciaPorDefectoDeseInt(int licenciaPorDefecto)
        {
            switch (licenciaPorDefecto)
            {
                case 1:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.A1;
                    break;
                case 2:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.A2;
                    break;
                case 3:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.B1;
                    break;
                case 4:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.B2;
                    break;
                case 5:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.B3;
                    break;
                case 6:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.C1;
                    break;
                case 7:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.C2;
                    break;
                case 8:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.C3;
                    break;
                case 9:
                    this.LicenciaPorDefecto_ = EnumTipoLicencia.SinLicencia;
                    break;
            }
        }

    }
}
