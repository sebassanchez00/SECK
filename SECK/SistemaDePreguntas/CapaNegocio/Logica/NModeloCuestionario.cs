using CapaDatos.Vo;
using CapaDatos;
using CapaNegocio;
using CapaNegocio.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica
{
    /// <summary>
    /// Representa y expone un cuestionario. Está compuesto por listas de preguntas divididas por temas
    /// </summary>
    public class NModeloCuestionario
    {
        int NumPreguntasNecesarias;
        int NumPreguntasTemaAspectosGenerales;
        int NumPreguntasTemaComportamientoPeaton;
        int NumPreguntasTemaSeñalesTransito;
        int NumPreguntasTemaRegimenSancionatorio;
        TipoLicencia tipoLicencia;

        List<VoPregunta> L_TodasLasPreguntas;
        List<VoPregunta> L_PreguntasAspectosGenerales;
        List<VoPregunta> L_PreguntasComportamientoPeaton;
        List<VoPregunta> L_PreguntasSeñalesTransito;
        List<VoPregunta> L_PreguntasTemaRegimenSancionatorio;

        public List<VoPregunta> L_ResultadoAspectosGenerales { get; set; }
        public List<VoPregunta> L_ResultadoComportamientoPeaton { get; set; }
        public List<VoPregunta> L_ResultadoSeñalesTransito { get; set; }
        public List<VoPregunta> L_ResultadoRegimenSancionatorio { get; set; }
        public List<VoPregunta> L_TodasLasPreguntasAleatorias { get; set; }

        //Acceso a datos
        DPregunta DPregunta_obj;
        DTipoPregunta DTipoPregunta_obj;
        DLicenciaAplicablePreguntas DLicenciaAplicablePreguntas_obj;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config">Clase configuraciones de la prueba</param>
        public NModeloCuestionario(NModeloConfiguracionPrueba config, TipoLicencia TipoLicenciaConductor)
        {
            DPregunta_obj = new DPregunta();
            DTipoPregunta_obj = new DTipoPregunta();
            DLicenciaAplicablePreguntas_obj = new DLicenciaAplicablePreguntas();
            this.tipoLicencia = TipoLicenciaConductor;

            CalcularNumeroPreguntas(config);

            L_ResultadoAspectosGenerales = new List<VoPregunta>();
            L_ResultadoComportamientoPeaton = new List<VoPregunta>();
            L_ResultadoSeñalesTransito = new List<VoPregunta>();
            L_ResultadoRegimenSancionatorio = new List<VoPregunta>();
            L_TodasLasPreguntasAleatorias = new List<VoPregunta>();

            L_TodasLasPreguntas = DPregunta_obj.LlevarPreguntasEvaluacionVo();
            L_TodasLasPreguntas = filtrarPorLicencia(L_TodasLasPreguntas,TipoLicenciaConductor);

            L_PreguntasAspectosGenerales = L_TodasLasPreguntas.Where(n => n.Id_Tema == 1).ToList();
            L_PreguntasComportamientoPeaton = L_TodasLasPreguntas.Where(n => n.Id_Tema == 3).ToList();
            L_PreguntasSeñalesTransito = L_TodasLasPreguntas.Where(n => n.Id_Tema == 4).ToList();
            L_PreguntasTemaRegimenSancionatorio = L_TodasLasPreguntas.Where(n => n.Id_Tema == 2).ToList();

            L_ResultadoAspectosGenerales = SeleccionarItemsAleatorios(NumPreguntasTemaAspectosGenerales, L_PreguntasAspectosGenerales, "Aspectos generales del tránsito, autoridades, licencias de conducción y mecánica básica");
            L_ResultadoComportamientoPeaton = SeleccionarItemsAleatorios(NumPreguntasTemaComportamientoPeaton, L_PreguntasComportamientoPeaton, "Normas de comportamiento de peatones, biciusuarios, conductores y pasajeros.");
            L_ResultadoSeñalesTransito = SeleccionarItemsAleatorios(NumPreguntasTemaSeñalesTransito, L_PreguntasSeñalesTransito, "Señales de tránsito y uso de la infraestructura vial.");
            L_ResultadoRegimenSancionatorio = SeleccionarItemsAleatorios(NumPreguntasTemaRegimenSancionatorio, L_PreguntasTemaRegimenSancionatorio, "Infracciones, sanciones, procedimiento y competencia para su imposición.");

            L_TodasLasPreguntasAleatorias.AddRange(L_ResultadoAspectosGenerales);
            L_TodasLasPreguntasAleatorias.AddRange(L_ResultadoComportamientoPeaton);
            L_TodasLasPreguntasAleatorias.AddRange(L_ResultadoSeñalesTransito);
            L_TodasLasPreguntasAleatorias.AddRange(L_ResultadoRegimenSancionatorio);
        }

        /// <summary>
        /// Toma un listado de preguntas y devuelve las preguntas que aplican según tipo de licencia del conductor
        /// </summary>
        List<VoPregunta> filtrarPorLicencia(List<VoPregunta> ListaPreguntas, TipoLicencia LicenciaConductor)
        {
            List<VoPregunta> Resultado = new List<VoPregunta>();
            //Todos los registros de LicenciaAplicablePreguntas. LicenciaAplicablePreguntas son relaciones Pregunta-TipoLicencia 
            List<VoLicenciaAplicablePreguntas> L_IDPreguntaPorLicencia = DLicenciaAplicablePreguntas_obj.Mostrar_Todas();

            foreach (VoPregunta i in ListaPreguntas)
            {
                short idPregunta = i.Id;
                //Obtiene todos los tipos de licencia de la pregunta
                List<VoLicenciaAplicablePreguntas> L_RelacionesPreguntaTipoLicencia = L_IDPreguntaPorLicencia.Where(n => n.ID_Pregunta == idPregunta).ToList();

                bool exitLoop = false;
                //Se evalúa si se escoge la pregunta para cada tipo de licencia de la pregunta 
                foreach (VoLicenciaAplicablePreguntas x in L_RelacionesPreguntaTipoLicencia)
                {
                    TipoLicencia tipoLicenciaDeLaPregunta = (TipoLicencia)x.ID_Tipo_Licencia;
                    switch (LicenciaConductor)
                    {
                        case (TipoLicencia.C3):
                            Resultado.Add(i);
                            exitLoop = true;
                            break;
                        case (TipoLicencia.C2):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B3 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.C1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.C2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.C1):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B3 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.C1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.B3):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B3 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.B2):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.B1):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.B1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.A2):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.A2 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.A1):
                            if (
                                tipoLicenciaDeLaPregunta == TipoLicencia.A1 ||
                                tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                        case (TipoLicencia.SinLicencia):
                            if (tipoLicenciaDeLaPregunta == TipoLicencia.SinLicencia)
                            {
                                Resultado.Add(i);
                                exitLoop = true;
                            }
                            break;
                    }
                    if (exitLoop) break;
                }
            }
            return Resultado;
        }

        /// <summary>
        /// Calcula la cantidad de preguntas por cada tema para cumplir la distribución 20%, 20%, 30%, 30%
        /// </summary>
        /// <param name="config">Clase configuracion prueba que tiene la cantidad de preguntas.</param>
        void CalcularNumeroPreguntas(NModeloConfiguracionPrueba config)
        {
            NumPreguntasNecesarias = config.numeroPreguntas;

            int NumResiduo = NumPreguntasNecesarias % 10;
            int NumeroEnMultiplos10 = NumPreguntasNecesarias - NumResiduo;

            NumPreguntasTemaAspectosGenerales = (NumeroEnMultiplos10 * 20) / 100;
            NumPreguntasTemaSeñalesTransito = (NumeroEnMultiplos10 * 20) / 100;
            NumPreguntasTemaComportamientoPeaton = (NumeroEnMultiplos10 * 30) / 100;
            NumPreguntasTemaRegimenSancionatorio = (NumeroEnMultiplos10 * 30) / 100;

            //Añade cuncho
            if (NumResiduo == 9)
                NumPreguntasTemaRegimenSancionatorio++;
            if (NumResiduo >= 8)
                NumPreguntasTemaAspectosGenerales++;
            if (NumResiduo >= 7)
                NumPreguntasTemaSeñalesTransito++;
            if (NumResiduo >= 6)
                NumPreguntasTemaComportamientoPeaton++;
            if (NumResiduo >= 5)
                NumPreguntasTemaRegimenSancionatorio++;
            if (NumResiduo >= 4)
                NumPreguntasTemaAspectosGenerales++;
            if (NumResiduo >= 3)
                NumPreguntasTemaSeñalesTransito++;
            if (NumResiduo >= 2)
                NumPreguntasTemaComportamientoPeaton++;
            if (NumResiduo >= 1)
                NumPreguntasTemaRegimenSancionatorio++;
        }

        /// <summary>
        /// Construye una lista aleatoria a partir de la lista suministrada
        /// </summary>
        /// <param name="cantidad">Cantidad elementos a crear</param>
        /// <param name="listaFuente">Lista desde donde se seleccionan elementos</param>
        /// <param name="textoTemaPregunta">Texto tema de la pregunta para incluir en mensaje de falla</param>
        /// <returns></returns>
        List<VoPregunta> SeleccionarItemsAleatorios(int cantidad, List<VoPregunta> listaFuente, string textoTemaPregunta)
        {
            List<VoPregunta> L_resultado = new List<VoPregunta>();
            Random rnd = new Random();
            if (listaFuente.Count < cantidad)
            {
                throw new Exception("La base de datos no tiene suficientes preguntas de tipo " + textoTemaPregunta + ". Son necesarias" + cantidad.ToString() + " preguntas");
            }

            for (int i = 1; i <= cantidad; i++)
            {
                int RandomIndex = rnd.Next(0, listaFuente.Count - 1);
                VoPregunta seleccion = listaFuente[RandomIndex];

                //Validar que no se repita la pregunta seleccionada
                //¡Probar bien esta parte!
                if (L_resultado.Contains(seleccion))
                {
                    i--;
                }
                else
                {
                    L_resultado.Add(seleccion);
                }
            }
            return L_resultado;
        }

        /// <summary>
        /// Retorna el enunciado de la pregunta aleatoria según ubicación en la lista L_TodasLasPreguntasAleatorias
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string EnunciadoPreguntaDesdeIndice(int i)
        {
            return L_TodasLasPreguntasAleatorias[i].Enunciado;
        }

        /// <summary>
        /// Retorna enunciado del tipo de pregunta según ubicación en la lista L_TodasLasPreguntasAleatorias
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string EnunciadoTipoPreguntaDesdeIndice(int i)
        {
            short idTipoPregunta = L_TodasLasPreguntasAleatorias[i].Id_TipoPregunta;
            VoTipoPregunta auxTipoPregunta = DTipoPregunta_obj.MostrarPorID(idTipoPregunta);
            return auxTipoPregunta.Enunciado;
        }

        /// <summary>
        /// Retorna el Id de la pregunta aleatoria según ubicación en la lista L_TodasLasPreguntasAleatorias
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public short IdPreguntaDesdeIndice(int i)
        {
            return L_TodasLasPreguntasAleatorias[i].Id;
        }

        /// <summary>
        /// Retorna la imagen de la pregunta aleatoria según ubicación en la lista L_TodasLasPreguntasAleatorias
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte[] ImagenPreguntaDesdeIndice(int i)
        {
            //VoPregunta vo = L_TodasLasPreguntas.FirstOrDefault(v => v.Id == (short)i);
            //return vo.Imagen;
            return L_TodasLasPreguntasAleatorias[i].Imagen;
        }
    }
}
