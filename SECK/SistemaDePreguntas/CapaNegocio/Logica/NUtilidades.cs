using CapaDatos;
using CapaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
//using System.Windows.Forms;

namespace CapaNegocio.Logica
{
    public class NUtilidades
    {
        /// <summary>
        /// Calcula un digito de verificacion usando algortimo Módulo10 o algoritmo de Luhn.
        /// </summary>
        /// <param name="fuente"></param>
        /// <returns></returns>
        public static long Digito_Verificación(long fuente)
        {
            long resultado = -1;

            List<long> L_Sumandos = new List<long>();
            double Tamaño = fuente.ToString().Length;

            for (double i = 0; i < Tamaño; i++)
            {
                long digito = fuente % 10;
                fuente = fuente / 10;

                if (i % 2 == 0)
                {
                    //Si digito está en posición par
                    L_Sumandos.Add(digito * 2);
                }
                else
                {
                    //Si digito está en posición impar
                    L_Sumandos.Add(digito * 1);
                }
            }

            long sumatoria = 0;
            foreach (long elemento in L_Sumandos)
            {
                sumatoria += sumarDigitos(elemento);
            }

            resultado = 10 - (sumatoria % 10);
            return resultado;
        }

        /// <summary>
        /// Suma los dos digitos menos significativos
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        private static long sumarDigitos(long par)
        {
            long d1 = par % 10;
            par = par / 10;
            long d2 = par % 10;
            return d1 + d2;
        }
    }
}