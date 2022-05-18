using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Logica
{
    /// <summary>
    /// Representa un cuadro de diálogo para seleccionar un archivo
    /// </summary>
    class PCuadroDialogo
    {
        //string fileName_;
        //public string FileName
        //{
        //    get { return this.fileName_; }
        //    set { this.fileName_ = value; }
        //}

        /// <summary>
        /// Desppliega cuadro de dialogo y obtiene nombre de archivo
        /// </summary>
        public string leerNombreArchivo()
        {
            string resultado = string.Empty;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Title = "SELECCION ARCHIVO DE PREGUNTAS";
                ofd.Filter = "Archivo .csv | *.csv";
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                { resultado = ofd.FileName; }
                else { resultado = string.Empty; }
                return resultado;
            }
        }
    }
}
