
//using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CapaPresentacion
{
    public class Cedula
    {
        int _num;
        string _nombres;
        string _apellidos;
        DateTime? _fechaNacimiento;
        Enums.Genero? _genero;

        string _nom1;
        string _nom2;
        string _ap1;
        string _ap2;

        int _ltotal;
        int _inum;
        int _lnum;
        int _inom1;
        int _lnom1;
        int _inom2;
        int _lnom2;
        int _iap1;
        int _lap1;
        int _iap2;
        int _lap2;
        int _ifechaNacimiento;
        int _lfechaNacimiento;
        int _igenero;
        int _lgenero;

        public int NumeroCedula
        {
            get { return _num; }
            set { _num = value; }
        }
        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        public DateTime? FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public Enums.Genero? Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public Cedula()
        {
            _ltotal = 66;
            
                   }
      
        /// <summary>
        /// Extrae número cédula, nombres, apellidos, género y fecha de nacimiento desde un string formateado según lector de barras.
        /// </summary>
        /// <param name="Lectura"></param>
        /// <returns></returns>
        public string AsignaCamposDesdeStream(string Lectura)
        {
           //if (string.IsNullOrEmpty(Lectura))
           //    return "No se leyó ningún dato o el dato tiene un formato incorrecto";

            //if (Lectura.Length < _ltotal)
                //return string.Format("Error en la cantidad de datos de la cadena. Se leyeron {0} caracteres, se necesitan al menos {1} caracteres", Lectura.Length, _ltotal);
            string[] datos = Lectura.Split(',');
            string aux_num = datos[0];
            aux_num = aux_num.Substring(1, 10);
            string aux_ap1 = datos[3];
            string aux_ap2 = datos[4];
            string aux_nom1 = datos[1];
            string aux_nom2 = datos[2];
            string aux_genero = datos[5];

            
            this._num = int.Parse(aux_num);
            this._ap1 = aux_ap1;
            this._ap2 = aux_ap2;
            this._nom1 = aux_nom1;
            this._nom2 = aux_nom2;
            this._nombres = _nom1.Trim() + " " + _nom2.Trim();
            this._apellidos = _ap1.Trim() + " " + _ap2.Trim();

            string aux_ano = datos[6];
            string aux_mes = datos[7];
            string aux_dia = datos[8];




            this._genero = aux_genero == "M" ? Enums.Genero.M : Enums.Genero.F;
            return null;
        }

        /// <summary>
        /// Limpia los campos num, nom1,nom2, ap1,ap2, nombres, apellidos, fechaNacimiento y genero
        /// </summary>
        public void Limpiar()
        {
            _num = 0;
            _nom1 = string.Empty;
            _nom2 = string.Empty;
            _ap1 = string.Empty;
            _ap2 = string.Empty;
            _nombres = string.Empty;
            _apellidos = string.Empty;
            _fechaNacimiento = null;
            _genero = null;
        }
    }
}
