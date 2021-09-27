using CapaDatos.Vo;
using CapaDatos;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Logica
{
    /// <summary>
    /// Representa un cuestionario. Está compuesto por listas de preguntas divididas por temas
    /// </summary>
    class NModeloCuestionario
    {
        int NumPreguntasNecesarias;
        int NumPreguntasTemaAspectosGenerales;
        int NumPreguntasTemaComportamientoPeaton;
        int NumPreguntasTemaSeñalesTransito;
        int NumPreguntasTemaRegimenSancionatorio;

        //ArrayList LPreguntasSeleccionadas;
        List<VoPregunta> L_TodasLasPreguntas;
        List<VoPregunta> L_PreguntasAspectosGenerales;
        List<VoPregunta> L_PreguntasComportamientoPeaton;
        List<VoPregunta> L_PreguntasSeñalesTransito;
        List<VoPregunta> L_PreguntasTemaRegimenSancionatorio;

        List<VoPregunta> L_ResultadoAspectosGenerales { get; set; }
        List<VoPregunta> L_ResultadoComportamientoPeaton { get; set; }
        List<VoPregunta> L_ResultadoSeñalesTransito { get; set; }
        List<VoPregunta> L_ResultadoRegimenSancionatorio { get; set; }

        //Acceso a datos
        DPregunta DPregunta_obj;

        NModeloCuestionario()
        {
            DPregunta_obj = new DPregunta();

            NumPreguntasNecesarias = 10;
            NumPreguntasTemaAspectosGenerales = (NumPreguntasNecesarias * 20) / 100;
            NumPreguntasTemaComportamientoPeaton = (NumPreguntasNecesarias * 30) / 100;
            NumPreguntasTemaSeñalesTransito = (NumPreguntasNecesarias * 20) / 100;
            NumPreguntasTemaRegimenSancionatorio = (NumPreguntasNecesarias * 30) / 100;
            //Validar que los porcentajes sumen el total de preguntas.

            L_TodasLasPreguntas = DPregunta_obj.LlevarPreguntasEvaluacionVo();
            L_PreguntasAspectosGenerales    = (List<VoPregunta>)L_TodasLasPreguntas.Where(n => n.ID_Tema == 1);
            L_PreguntasComportamientoPeaton = (List<VoPregunta>)L_TodasLasPreguntas.Where(n => n.ID_Tema == 3);
            L_PreguntasSeñalesTransito      = (List<VoPregunta>)L_TodasLasPreguntas.Where(n => n.ID_Tema == 4);
            L_PreguntasTemaRegimenSancionatorio = (List<VoPregunta>)L_TodasLasPreguntas.Where(n => n.ID_Tema == 2);

            L_ResultadoAspectosGenerales = SeleccionarItemsAleatorios(NumPreguntasTemaAspectosGenerales, L_PreguntasAspectosGenerales, "Aspectos generales del tránsito, autoridades, licencias de conducción y mecánica básica");
            L_ResultadoComportamientoPeaton = SeleccionarItemsAleatorios(NumPreguntasTemaComportamientoPeaton, L_PreguntasComportamientoPeaton, "Normas de comportamiento de peatones, biciusuarios, conductores y pasajeros.");
            L_ResultadoSeñalesTransito = SeleccionarItemsAleatorios(NumPreguntasTemaSeñalesTransito, L_PreguntasSeñalesTransito, "Señales de tránsito y uso de la infraestructura vial.");
            L_ResultadoRegimenSancionatorio = SeleccionarItemsAleatorios(NumPreguntasTemaRegimenSancionatorio, L_PreguntasTemaRegimenSancionatorio, "Infracciones, sanciones, procedimiento y competencia para su imposición.");
        }

        /// <summary>
        /// Construye una lista aleatoria a partir de la lista suministrada
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="listaFuente"></param>
        /// <param name="tipoPregunta"></param>
        /// <returns></returns>
        List<VoPregunta> SeleccionarItemsAleatorios(int cantidad, List<VoPregunta> listaFuente, string tipoPregunta)
        {
            List<VoPregunta> L_resultado = new List<VoPregunta>();
            Random rnd = new Random();
            if (listaFuente.Count < cantidad)
            { 
                throw new Exception("La base de datos no tiene suficientes preguntas de tipo " + tipoPregunta + ". Son necesarias" + cantidad.ToString() + " preguntas");
            }
                
            for(int i = 1; i<=cantidad; i++)
            {
                int RandomIndex = rnd.Next(0, listaFuente.Count-1);
                VoPregunta seleccion = listaFuente[RandomIndex];

                //Validar que no se repita la pregunta seleccionada
                //¡Probar bien esta parte!
                if(L_resultado.Contains(seleccion))
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
    }
}
