using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class Utilidades
    {
        /// <summary>
        /// Lee las preguntas desde un archivo .csv y les asigna tema. Dependiendo del tipo de pregunta, contruye el obj DPregunta. Retorna null si hay un error
        /// </summary>
        /// <param name="FileName">Ruta del archivo</param>
        /// <param name="Tema">Tema que se asociara a la pregunta</param>
        /// <param name="TipoPregunta">Tipo de pregunta, deacuerdo al tipo se construye el objeto DPregunta</param>
        /// <returns></returns>
        public static List<DPregunta> LeerArchivo(string FileName, int Tema, Enums.TipoPreg TipoPregunta)
        {
            List<DPregunta> LPreguntas = new List<DPregunta>();
            using (StreamReader SR = new StreamReader(FileName, System.Text.Encoding.Default))
            {
                SR.ReadLine(); //Descarta la primera fila del archivo, la de los títulos
                switch (TipoPregunta)
                {
                    #region Pregunta abierta numérica
                    case Enums.TipoPreg.AbiertaNumerica:

                        while (!SR.EndOfStream)
                        {
                            DPregunta AuxPregunta = new DPregunta();
                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 2)
                            {
                                MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                return null;
                            }
                            double auxDouble = 0;
                            if (!double.TryParse(valores[1], out  auxDouble))
                            {
                                MessageBox.Show("Valor de columna 'RESPUESTA' debe ser un número entero, sin decimales en la pregunta: " + valores[0], "Archivo con formato incorrecto");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)Enums.TipoPreg.AbiertaNumerica;
                            AuxPregunta.Enunciado = valores[0];
                            AuxPregunta.Opcion1 = valores[1];

                            LPreguntas.Add(AuxPregunta);
                        }
                        break;

                    #endregion

                    #region Pregunta Seleeción múltiple
                    case Enums.TipoPreg.SelMul:

                        while (!SR.EndOfStream)
                        {
                            DPregunta AuxPregunta = new DPregunta();
                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 9)
                            {
                                MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                return null;
                            }
                            if (!((valores[2] == "1" || valores[2] == "0") && (valores[4] == "1" || valores[4] == "0") && (valores[6] == "1" || valores[6] == "0") && (valores[8] == "1" || valores[8] == "0")))
                            {
                                MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }

                            int j = 0;
                            if (valores[2] == "1")
                                j++;
                            if (valores[4] == "1")
                                j++;
                            if (valores[6] == "1")
                                j++;
                            if (valores[8] == "1")
                                j++;
                            if (j != 1)
                            {
                                MessageBox.Show("Debe existir una y solo una respuesta correcta en columnas 'Es_Correcto'. En la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)Enums.TipoPreg.SelMul;
                            AuxPregunta.Enunciado = valores[0];
                            AuxPregunta.Opcion1 = valores[1];
                            AuxPregunta.EsCorrectaOp1 = valores[2] == "1" ? true : false;
                            AuxPregunta.Opcion2 = valores[3];
                            AuxPregunta.EsCorrectaOp2 = valores[4] == "1" ? true : false;
                            AuxPregunta.Opcion3 = valores[5];
                            AuxPregunta.EsCorrectaOp3 = valores[6] == "1" ? true : false;
                            AuxPregunta.Opcion4 = valores[7];
                            AuxPregunta.EsCorrectaOp4 = valores[8] == "1" ? true : false;
                            AuxPregunta.Imagen = null;

                            LPreguntas.Add(AuxPregunta);
                        }
                        break;
                    #endregion

                    #region Pregunta Seleeción múltiple con imagen
                    case Enums.TipoPreg.SelMulImg:

                        while (!SR.EndOfStream)
                        {
                            DPregunta AuxPregunta = new DPregunta();
                            byte[] Aux_Imagen;

                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 10)
                            {
                                MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                return null;
                            }
                            if (!((valores[2] == "1" || valores[2] == "0") && (valores[4] == "1" || valores[4] == "0") && (valores[6] == "1" || valores[6] == "0") && (valores[8] == "1" || valores[8] == "0")))
                            {
                                MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }
                            int j = 0;
                            if (valores[2] == "1")
                                j++;
                            if (valores[4] == "1")
                                j++;
                            if (valores[6] == "1")
                                j++;
                            if (valores[8] == "1")
                                j++;
                            if (j != 1)
                            {
                                MessageBox.Show("Debe existir una y solo una respuesta correcta en columnas 'Es_Correcto'. En la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }

                            if (File.Exists(Path.GetDirectoryName(FileName) + @"\" + valores[9]))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Image img = Image.FromFile(Path.GetDirectoryName(FileName) + @"\" + valores[9]);
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    Aux_Imagen = ms.ToArray();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la imagen '" + valores[9] + "' asociada a la pregunta: '" + valores[0] + "'", "No existe la imagen");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)Enums.TipoPreg.SelMulImg;
                            AuxPregunta.Enunciado = valores[0];
                            AuxPregunta.Opcion1 = valores[1];
                            AuxPregunta.EsCorrectaOp1 = valores[2] == "1" ? true : false;
                            AuxPregunta.Opcion2 = valores[3];
                            AuxPregunta.EsCorrectaOp2 = valores[4] == "1" ? true : false;
                            AuxPregunta.Opcion3 = valores[5];
                            AuxPregunta.EsCorrectaOp3 = valores[6] == "1" ? true : false;
                            AuxPregunta.Opcion4 = valores[7];
                            AuxPregunta.EsCorrectaOp4 = valores[8] == "1" ? true : false;
                            AuxPregunta.Imagen = Aux_Imagen;

                            LPreguntas.Add(AuxPregunta);
                        }
                        break;
                    #endregion

                    #region Pregunta verdadero falso
                    case Enums.TipoPreg.VerdaderoFalso:

                        while (!SR.EndOfStream)
                        {
                            DPregunta AuxPregunta = new DPregunta();

                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 3)
                            {
                                MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                return null;
                            }
                            if (!((valores[1] == "1" || valores[1] == "0") && (valores[2] == "1" || valores[2] == "0")))
                            {
                                MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }
                            if (valores[1] == valores[2])
                            {
                                MessageBox.Show("Las respuesta no pueden ser ambas correctas o ambas incorrectas en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)Enums.TipoPreg.VerdaderoFalso;
                            AuxPregunta.Enunciado = valores[0];
                            AuxPregunta.Opcion1 = "Verdadero";
                            AuxPregunta.EsCorrectaOp1 = valores[1] == "1" ? true : false;
                            AuxPregunta.Opcion2 = "Falso";
                            AuxPregunta.EsCorrectaOp2 = valores[2] == "1" ? true : false;

                            LPreguntas.Add(AuxPregunta);
                        }

                        break;
                    #endregion

                    default:
                        MessageBox.Show("No existe ese tipo de pregunta");
                        return null;
                }

                SR.Close();
                SR.Dispose();
                return LPreguntas;
            }
        }

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