using CapaDatos;
using CapaDatos.Vo;
using CapaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica.Carga
{
    public class NLectorAbiertaNumerica : NLector
    {
        const int POS_ENU_PREGUNTA = 0;
        const int POS_RESPUESTA = 1;

        public NLectorAbiertaNumerica(string Path) : base(
            Path: Path,
            NumeroColumnas: 4,
            PosicionTpoLicencia: 2,
            PosicionTema: 3)
        { }

        protected override void cargarPreguntasEnListaTupla()
        {
            foreach (string item in base.LPreguntasSinFormato)
            {
                VoPreguntaYOpciones pregunta = new VoPreguntaYOpciones();
                VoLicenciaAplicablePreguntas lap = new VoLicenciaAplicablePreguntas();

                string[] datosCrudos = item.Split(base.Delimitador, StringSplitOptions.RemoveEmptyEntries);

                pregunta.Enunciado = datosCrudos[POS_ENU_PREGUNTA];
                pregunta.Id_Tema = Convert.ToInt16(datosCrudos[base.PosicionTema]);
                pregunta.Id_TipoPregunta = (int)TipoPreg.AbiertaNumerica;
                pregunta.Imagen = null;
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = true, Enunciado = datosCrudos[POS_RESPUESTA] });
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                lap.ID_Tipo_Licencia = Convert.ToInt16(datosCrudos[base.PosicionTipoLicencia]);

                var TuplaParaAgregar = new Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>(pregunta, lap);
                base.LPreguntasTupla.Add(TuplaParaAgregar);
            }
        }

        protected override void validarOpciones()
        {
            int indicePregunta = 2;
            foreach (var l in base.LPreguntasSinFormato) //Recorre cada pregunta
            {
                string[] registro = l.Split(base.Delimitador, StringSplitOptions.RemoveEmptyEntries);

                if (!int.TryParse(registro[POS_RESPUESTA], out int aux))
                {
                    String mensaje = $"La respuesta del registro con índice {indicePregunta.ToString()} no es un número entero";
                    throw new Exception(mensaje);
                }
                indicePregunta++;
            }
        }
    }
}



