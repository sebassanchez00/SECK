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
    public class NLectorSeleccionMultiple : NLector
    {
        const int POS_ENU_PREGUNTA = 0;
        const int POS_ENU_OP1 = 1;
        const int POS_ENU_OP2 = 3;
        const int POS_ENU_OP3 = 5;
        const int POS_ENU_OP4 = 7;
        const int POS_RESPUESTA_OP1 = 2;
        const int POS_RESPUESTA_OP2 = 4;
        const int POS_RESPUESTA_OP3 = 6;
        const int POS_RESPUESTA_OP4 = 8;

        public NLectorSeleccionMultiple(string Path) : base(
            Path: Path,
            NumeroColumnas: 11,
            PosicionTpoLicencia: 9,
            PosicionTema: 10)
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
                pregunta.Id_TipoPregunta = (int)TipoPreg.SelMul;
                pregunta.Imagen = null;
                bool Aux_Es_Correcta1 = datosCrudos[POS_RESPUESTA_OP1] == "1";
                bool Aux_Es_Correcta2 = datosCrudos[POS_RESPUESTA_OP2] == "1";
                bool Aux_Es_Correcta3 = datosCrudos[POS_RESPUESTA_OP3] == "1";
                bool Aux_Es_Correcta4 = datosCrudos[POS_RESPUESTA_OP4] == "1";
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = Aux_Es_Correcta1, Enunciado = datosCrudos[POS_ENU_OP1] });
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = Aux_Es_Correcta2, Enunciado = datosCrudos[POS_ENU_OP2] });
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = Aux_Es_Correcta3, Enunciado = datosCrudos[POS_ENU_OP3] });
                pregunta.Opciones.Add(new VoOpcionRespuesta { Es_Correcta = Aux_Es_Correcta4, Enunciado = datosCrudos[POS_ENU_OP4] });
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

                if (!(registro[POS_RESPUESTA_OP1] == "1" || registro[POS_RESPUESTA_OP1] == "0"))
                {
                    String mensaje = $"El valor de columna ES CORRECTA1 del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_OP1] == "1" ? ++contador : contador;

                if (!(registro[POS_RESPUESTA_OP2] == "1" || registro[POS_RESPUESTA_OP2] == "0"))
                {
                    String mensaje = $"El valor de columna ES CORRECTA2 del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_OP2] == "1" ? ++contador : contador;

                if (!(registro[POS_RESPUESTA_OP3] == "1" || registro[POS_RESPUESTA_OP3] == "0"))
                {
                    String mensaje = $"El valor de columna ES CORRECTA3 del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_OP3] == "1" ? ++contador : contador;

                if (!(registro[POS_RESPUESTA_OP4] == "1" || registro[POS_RESPUESTA_OP4] == "0"))
                {
                    String mensaje = $"El valor de columna ES CORRECTA4 del registro con índice {indicePregunta.ToString()} no es un booleano";
                    throw new Exception(mensaje);
                }
                contador = registro[POS_RESPUESTA_OP4] == "1" ? ++contador : contador;

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



