using CapaDatos.Vo;
using CapaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica.Carga
{
    /// <summary>
    /// Coordina el cargue de preguntas
    /// </summary>
    public class NManejadorCargaPreguntas
    {
        string path_;
        TipoPreg tipoPregunta_;
        List<VoPreguntaYOpciones> LPreguntas_;

        public NManejadorCargaPreguntas(string path, TipoPreg TipoPregunta)
        {
            this.path_ = path;
            this.tipoPregunta_ = TipoPregunta;
            LPreguntas_ = new List<VoPreguntaYOpciones>();
        }

        void cargarPreguntasEnLista()
        {
           /* using (StreamReader SR = new StreamReader(this.path_, System.Text.Encoding.Default))
            {
                SR.ReadLine(); //Descarta la primera fila del archivo, la de los títulos
                switch (this.tipoPregunta_)
                {
                    #region Pregunta abierta numérica
                    case TipoPreg.AbiertaNumerica:

                        

                    #endregion

                    #region Pregunta Seleeción múltiple
                    case TipoPreg.SelMul:

                        while (!SR.EndOfStream)
                        {
                            VoPreguntaYOpciones AuxPregunta = new VoPreguntaYOpciones();
                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 9)
                            {
                                // (*) MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                //return null;
                            }
                            if (!((valores[2] == "1" || valores[2] == "0") && (valores[4] == "1" || valores[4] == "0") && (valores[6] == "1" || valores[6] == "0") && (valores[8] == "1" || valores[8] == "0")))
                            {
                                // (*) MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                //return null;
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
                                // (*) MessageBox.Show("Debe existir una y solo una respuesta correcta en columnas 'Es_Correcto'. En la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                // return null;
                            }

                            AuxPregunta.Id_Tema = Convert.ToInt16(valores[10]);
                            AuxPregunta.Id_TipoPregunta = (int)TipoPreg.SelMul;
                            AuxPregunta.Enunciado = valores[0];
                            AuxPregunta.Imagen = null;

                            AuxPregunta.Opciones.Add(new VoOpcionRespuesta
                            {
                                Enunciado = valores[1],
                                Es_Correcta = Convert.ToBoolean(valores[2])                    
                            });
                            AuxPregunta.Opciones.Add(new VoOpcionRespuesta
                            {
                                Enunciado = valores[3],
                                Es_Correcta = Convert.ToBoolean(valores[4])
                            });
                            AuxPregunta.Opciones.Add(new VoOpcionRespuesta
                            {
                                Enunciado = valores[5],
                                Es_Correcta = Convert.ToBoolean(valores[6])
                            });
                            AuxPregunta.Opciones.Add(new VoOpcionRespuesta
                            {
                                Enunciado = valores[7],
                                Es_Correcta = Convert.ToBoolean(valores[8])
                            });
                        }
                        break;
                    #endregion

                    #region Pregunta Seleeción múltiple con imagen
                    case TipoPreg.SelMulImg:

                        while (!SR.EndOfStream)
                        {
                            VoPreguntaYOpciones AuxPregunta = new VoPreguntaYOpciones();
                            byte[] Aux_Imagen;

                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 10)
                            {
                                // (*) MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                // return null;
                            }
                            if (!((valores[2] == "1" || valores[2] == "0") && (valores[4] == "1" || valores[4] == "0") && (valores[6] == "1" || valores[6] == "0") && (valores[8] == "1" || valores[8] == "0")))
                            {
                                // (*) MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                // return null;
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
                                // (*) MessageBox.Show("Debe existir una y solo una respuesta correcta en columnas 'Es_Correcto'. En la pregunta: " + valores[0], "Formato de archivo incorrecto");
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
                                // (*) MessageBox.Show("No se encontró la imagen '" + valores[9] + "' asociada a la pregunta: '" + valores[0] + "'", "No existe la imagen");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)TipoPreg.SelMulImg;
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
                    case TipoPreg.VerdaderoFalso:

                        while (!SR.EndOfStream)
                        {
                            DPregunta AuxPregunta = new DPregunta();

                            string[] valores = SR.ReadLine().Split(';'); //Lee línea y corta subcadenas separadas por ';'

                            //Validar formato de archivo .CSV
                            if (valores.Length != 3)
                            {
                                // (*) MessageBox.Show("Archivo no tiene la cantidad correcta de datos en la pregunta: " + valores[0], "Faltan o sobran datos");
                                return null;
                            }
                            if (!((valores[1] == "1" || valores[1] == "0") && (valores[2] == "1" || valores[2] == "0")))
                            {
                                // (*) MessageBox.Show("Columnas 'Es_Correcto' tienen valores diferentes a 0 y 1 en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }
                            if (valores[1] == valores[2])
                            {
                                // (*) MessageBox.Show("Las respuesta no pueden ser ambas correctas o ambas incorrectas en la pregunta: " + valores[0], "Formato de archivo incorrecto");
                                return null;
                            }

                            AuxPregunta.Tema = Tema;
                            AuxPregunta.Id_TipoPregunta = (int)TipoPreg.VerdaderoFalso;
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
                        // (*) MessageBox.Show("No existe ese tipo de pregunta");
                        throw new Exception(message: "No existe ese tipo de pregunta");
                        return null;
                }

                SR.Close();
                SR.Dispose();
                return LPreguntas;
            }*/
        }

        void cargarPreguntasEnBD()
        {

        }

        void validarArchivoSeparadoPorComas()
        {

        }

        void validarExistenTemas()
        {

        }

        void validarColumnasCorrectas()
        {

        }

        void validarExistenTiposLicencia()
        {

        }

        void validarExistenOpciones()
        {

        }

        void validarResolucion()
        {

        }
    }
}
