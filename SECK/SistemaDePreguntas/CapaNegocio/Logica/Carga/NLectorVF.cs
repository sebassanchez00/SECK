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
    public class NLectorVF : NLector
    {
        const int POS_ENU_PREGUNTA = 0;
        const int POS_RESPUESTA_VERDADERO_ES_CORRECTO = 1;
        const int POS_RESPUESTA_FALSO_ES_CORRECTO = 2;

        public NLectorVF(string Path) : base(
            Path: Path,
            NumeroColumnas: 5,
            PosicionTpoLicencia: 3,
            PosicionTema: 4)
        { }

        protected override void cargarPreguntasEnListaTupla()
        {
            foreach (string item in base.LPreguntasSinFormato)
            {
                VoPreguntaYOpciones pregunta = new VoPreguntaYOpciones();
                VoLicenciaAplicablePreguntas lap = new VoLicenciaAplicablePreguntas();

                string[] datosCrudos = item.Split(base.Delimitador, StringSplitOptions.RemoveEmptyEntries);
                bool auxVerdaderaCorrecta = datosCrudos[POS_RESPUESTA_VERDADERO_ES_CORRECTO] == "1";
                bool auxFalsoCorrecta = datosCrudos[POS_RESPUESTA_FALSO_ES_CORRECTO] == "1";

                pregunta.Enunciado = datosCrudos[POS_ENU_PREGUNTA];
                pregunta.Id_Tema = Convert.ToInt16(datosCrudos[base.PosicionTema]);
                pregunta.Id_TipoPregunta = (int)TipoPreg.VerdaderoFalso;
                pregunta.Imagen = null;
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = auxVerdaderaCorrecta, Enunciado = "Verdadero" });
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = auxFalsoCorrecta, Enunciado = "Falso" });
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
                int contador = 0;

                if (!(registro[POS_RESPUESTA_VERDADERO_ES_CORRECTO] == "1" || registro[POS_RESPUESTA_VERDADERO_ES_CORRECTO] == "0"))
                {
                    String mensaje = $"El valor de columna VERDADERO_ES_CORRECTO del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_VERDADERO_ES_CORRECTO] == "1" ? ++contador : contador;

                if (!(registro[POS_RESPUESTA_FALSO_ES_CORRECTO] == "1" || registro[POS_RESPUESTA_FALSO_ES_CORRECTO] == "0"))
                {
                    String mensaje = $"El valor de columna FALSO_ES_CORRECTO del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_FALSO_ES_CORRECTO] == "1" ? ++contador : contador;

                if (contador == 0 || contador >= 2)
                {
                    String mensaje = $"La pregunta con índice {indicePregunta.ToString()} no tiene o tiene más de una respuesta correcta";
                    throw new Exception(mensaje);
                }

                indicePregunta++;
            }
        }
    }
}



