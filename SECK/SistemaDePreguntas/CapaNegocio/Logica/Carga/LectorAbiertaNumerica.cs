using CapaDatos.Vo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica.Carga
{
    public class LectorAbiertaNumerica : Lector
    {// (*) MessageBox.Show("Valor de columna 'RESPUESTA' debe ser un número entero, sin decimales en la pregunta: " + valores[0], "Archivo con formato incorrecto");

        public LectorAbiertaNumerica(string Path) : base(Path: Path,NumeroColumnas: 4,PosicionTpoLicencia: 2,PosicionTema: 3)
        {
        }

        protected override void cargarPreguntasEnBD()
        {
            throw new NotImplementedException();
        }

        protected override void cargarPreguntasEnListaTupla()
        {
            foreach (string item in base.LPreguntasSinFormato)
            {
                VoPreguntaYOpciones pregunta = new VoPreguntaYOpciones();
                VoOpcionRespuesta opcion = new VoOpcionRespuesta();
                VoLicenciaAplicablePreguntas lap = new VoLicenciaAplicablePreguntas();

                string[] datosCrudos = item.Split(base.Delimitador, StringSplitOptions.RemoveEmptyEntries);

                pregunta.Enunciado = datosCrudos[0];
                pregunta.Id_Tema = Convert.ToInt16(datosCrudos[3]);
                opcion.Enunciado = datosCrudos[1];
                pregunta.Opciones.Add(opcion);
                lap.ID_Tipo_Licencia = Convert.ToInt16(datosCrudos[2]);

                var TuplaParaAgregar = new Tuple<VoPreguntaYOpciones, VoLicenciaAplicablePreguntas>(pregunta, lap);
                base.LPreguntasTupla.Add(TuplaParaAgregar);
            }
        }

        protected override void validarExistenOpciones()
        {
            //Este tipo de pregunta no tiene opciones
        }
    }
}



