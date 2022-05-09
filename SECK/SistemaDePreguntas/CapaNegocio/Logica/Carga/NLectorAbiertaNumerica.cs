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
        DPregunta DPregunta_obj;
        DLicenciaAplicablePreguntas DLicenciaAplicablePreguntas_obj;
        const int POS_RESPUESTA = 1;

        public NLectorAbiertaNumerica(string Path) : base(
            Path: Path,
            NumeroColumnas: 4,
            PosicionTpoLicencia: 2,
            PosicionTema: 3)
        {
            DPregunta_obj = new DPregunta();
            DLicenciaAplicablePreguntas_obj = new DLicenciaAplicablePreguntas();
        }

        protected override void cargarPreguntasEnBD()
        {
            foreach (var p in base.LPreguntasTupla)
            {
                short idInsertada = DPregunta_obj.Insertar(p.Item1); //Inserta pregunta y opciones
                p.Item2.ID_Pregunta = idInsertada;                  
                DLicenciaAplicablePreguntas_obj.Insertar(p.Item2); //Inserta LicenciaAplicablePpregunta
            }
        }

        protected override void cargarPreguntasEnListaTupla()
        {
            foreach (string item in base.LPreguntasSinFormato)
            {
                VoPreguntaYOpciones pregunta = new VoPreguntaYOpciones();
                VoLicenciaAplicablePreguntas lap = new VoLicenciaAplicablePreguntas();

                string[] datosCrudos = item.Split(base.Delimitador, StringSplitOptions.RemoveEmptyEntries);

                pregunta.Enunciado = datosCrudos[0];
                pregunta.Id_Tema = Convert.ToInt16(datosCrudos[3]);
                pregunta.Id_TipoPregunta = (int)TipoPreg.AbiertaNumerica;
                pregunta.Imagen = null;
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = true, Enunciado = datosCrudos[1] }); 
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = false, Enunciado = string.Empty });  // Se ignoran
                lap.ID_Tipo_Licencia = Convert.ToInt16(datosCrudos[2]);

                var TuplaParaAgregar = new Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>(pregunta, lap);
                base.LPreguntasTupla.Add(TuplaParaAgregar);
            }
        }

        protected override void validarOpciones()
        {
            int indicePregunta = 0;
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



