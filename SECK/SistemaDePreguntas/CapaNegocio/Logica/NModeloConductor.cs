using CapaDatos;
using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CapaNegocio.Logica
{
    /// <summary>
    /// Representa un conductor evaluado.
    /// </summary>
    public class NModeloConductor
    {
        public VoConductor VoConductor_obj { get; set; }
        //int _num;
        //string _nombres;
        //string _apellidos;
        //DateTime? _fechaNacimiento;
        //Enums.Genero? _genero;

        //string _nom1;
        //string _nom2;
        //string _ap1;
        //string _ap2;

        int _ltotal;
        //int _inum;
        //int _lnum;
        //int _inom1;
        //int _lnom1;
        //int _inom2;
        //int _lnom2;
        //int _iap1;
        //int _lap1;
        //int _iap2;
        //int _lap2;
        //int _ifechaNacimiento;
        //int _lfechaNacimiento;
        //int _igenero;
        //int _lgenero;

        //public int NumeroCedula
        //{
        //    get { return _num; }
        //    set { _num = value; }
        //}
        //public string Nombres
        //{
        //    get { return _nombres; }
        //    set { _nombres = value; }
        //}
        //public string Apellidos
        //{
        //    get { return _apellidos; }
        //    set { _apellidos = value; }
        //}
        //public DateTime? FechaNacimiento
        //{
        //    get { return _fechaNacimiento; }
        //    set { _fechaNacimiento = value; }
        //}
        //public Enums.Genero? Genero
        //{
        //    get { return _genero; }
        //    set { _genero = value; }
        //}

        public NModeloConductor()
        {
            this._ltotal = 66;
            this.VoConductor_obj = new VoConductor();
        }

        /// <summary>
        /// Limpia los campos de la clase
        /// </summary>
        public void Limpiar()
        {
            VoConductor_obj.Cedula = string.Empty;
            VoConductor_obj.Nombre = string.Empty;
            VoConductor_obj.Apellido = string.Empty;
            VoConductor_obj.TipoLicencia = null;
            VoConductor_obj.CodigoLicencia = string.Empty;
            VoConductor_obj.Empresa = string.Empty;
            VoConductor_obj.Genero = 0;
            VoConductor_obj.Huella = null;
            VoConductor_obj.Fotografia = null;
            VoConductor_obj.FechaNacimiento = null;
        }

        /// <summary>
        /// Llena los campos del conductor con datos desde la BD. Toma la cédula como parámetro
        /// </summary>
        public void AsignaCamposDesdeBD(string cedula)
        {
            this.Limpiar();
            DConductor DConductor_obj = new DConductor();
            this.VoConductor_obj = DConductor_obj.MostrarUsuario_VoConductor(cedula);
        }

        /// <summary>
        /// Extrae número cédula, nombres, apellidos, género y fecha de nacimiento desde un string entregado por lector de barras.
        /// </summary>
        /// <param name="Lectura"></param>
        /// <returns></returns>
        public string AsignaCamposDesdeStream(string Lectura)
        {
            string[] datos = Lectura.Split(',');
            string aux_num = datos[0];
            aux_num = aux_num.Substring(1, 10);
            string aux_ap1 = datos[3];
            string aux_ap2 = datos[4];
            string aux_nom1 = datos[1];
            string aux_nom2 = datos[2];
            string aux_genero = datos[5];

            this.VoConductor_obj.Cedula = aux_num;
            this.VoConductor_obj.Apellido = aux_ap1.Trim() + " " + aux_ap2.Trim();
            this.VoConductor_obj.Nombre = aux_nom1.Trim() + " " + aux_nom2.Trim();
            //this.VoConductor_obj.Genero = aux_genero == "M" ? (short)Enums.Genero.M : (short)Enums.Genero.F;
            this.VoConductor_obj.Genero = aux_genero == "M" ? (short)1 : (short)2;
            //this._num = int.Parse(aux_num);
            //this._ap1 = aux_ap1;
            //this._ap2 = aux_ap2;
            //this._nom1 = aux_nom1;
            //this._nom2 = aux_nom2;
            //this._nombres = _nom1.Trim() + " " + _nom2.Trim();
            //this._apellidos = _ap1.Trim() + " " + _ap2.Trim();

            //string aux_ano = datos[6];
            //string aux_mes = datos[7];
            //string aux_dia = datos[8];

            //this._genero = aux_genero == "M" ? Enums.Genero.M : Enums.Genero.F;
            return null;
        }
    }
}
