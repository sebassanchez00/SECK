using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocio;
//using OKTAL.SCANeR_API_NET;
//using OKTAL.SCANeR_API_NET.HighLevel.Network.IUser;
using SistemadeReportes;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public int des_01;
        public int des_02;
        public int des_03;
        public int des_04;
        public int des_05;
        public int des_06;
        public int des_07;
        public int des_08;
        public int des_09;
        public int des_010;
        public int des_011;

        int CantidadEvento1 = 0;
        int CantidadEvento2 = 0;
        int CantidadEvento3 = 0;
        int CantidadEvento4 = 0;
        int CantidadEvento5 = 0;
        int CantidadEvento6 = 0;
        int CantidadEvento7 = 0;
        int CantidadEvento8 = 0;
        int CantidadEvento9 = 0;
        int CantidadEvento10 = 0;

        int CantidadEvento11 = 0;
        int CantidadEvento12 = 0;
        int CantidadEvento13 = 0;
        int CantidadEvento14 = 0;
        int CantidadEvento15 = 0;
        int CantidadEvento16 = 0;
        int CantidadEvento17 = 0;
        int CantidadEvento18 = 0;


        //FormularioReporte FormReporte;

        public string Reportes;


        bool UltimoEventoFueColision = false;

        #region Declaraciones SCANeR

        //private APIProcessState _state;
        //private SWIGTYPE_p_DataInterface _exportChannel;

        //private SWIGTYPE_p_DataInterface cabToModel;
        //private SWIGTYPE_p_DataInterface modelToCab;
        //private SWIGTYPE_p_DataInterface cabToSteering;
        //private SWIGTYPE_p_DataInterface steeringToCab;
    
        private Thread _inicioSimulacion;
        private int _frameNbIn;

        bool ContinuarProceso = true;

        #endregion

        #region Declaracion Variables TX RX

        private float _val105;
        private float _val111;
        private float _val113;
        private float _val114;
        private float _val115;
        private float _val116;
        private float _val117;

        private float _val200;
        private float _val201;
        private float _val202;
        private float _val203;
        private string _horaEvento;
        private float _val300;
        private float _val301;
        private float _val302;
        private float _val303;
        private float _val304;
        private float _val305;
        private float _val306;
        private float _val307;
        private float _val308;
        private float _val309;
        private float _val310;
        private float _val311;
        private float _val312;
        private float _val313;
        private float _val314;
        private float _val315;

        private float _val1024;
        private float _val1025;
        private float _val1050;

        private bool _evento101;
        private bool _evento102;
        private bool _evento103;
        private bool _evento104;
        private bool _evento105;
        private bool _evento106;
        private bool _evento107;
        private bool _evento108;
        private bool _evento109;
        private bool _evento110;
        private bool _evento111;
        private bool _evento112;
        private bool _evento113;
        private bool _evento114;
        private bool _evento115;
        private bool _evento116;
        private bool _evento117;
        private bool _evento118;
        private bool _evento119;
        private bool _evento121;

        private double _ocu101;
        private double _ocu102;
        private double _ocu103;
        private double _ocu104;
        private double _ocu105;
        private double _ocu106;
        private double _ocu107;
        private double _ocu108;
        private double _ocu109;
        private double _ocu110;
        private double _ocu111;
        private double _ocu112;
        private double _ocu113;
        private double _ocu114;
        private double _ocu115;
        private double _ocu116;
        private double _ocu117;
        private double _ocu118;
        private double _ocu119;
        private double _ocu121;
        private bool CerrarProceso = true;
        #endregion

        public Form1()
        {
           
            InitializeComponent();
            #region Inicializacion SCANeR no tocar
            try
            {
                //Configuracion2 = "CONFIG_ESLOG";
                //scenario2 = Scenario;

               
                des_01 = 2;
                des_02 = 2;
                des_03 = 2;
                des_04 = 2;
                des_05 = 2;
                des_06 = 2;
                des_07 = 2;
                des_08 = 2;
                des_09 = 2;
                des_010 = 2;
                des_011 = 2;


                 //LogUsuario.Items.Add("Conectando con API de SCANeR...");







                //SCANeR_API.Process_InitParams("SISTEMADEREPORTES", "KIRVITSIM", 100);

                //_state = APIProcessState.PS_DAEMON;
                //_exportChannel = SCANeR_API.Com_declareOutputData("Network/IUser/ExportChannel", 0);









                //cabToModel = SCANeR_API.Com_declareOutputData("Shm/ModelCabin/CabToModel");
                //modelToCab = SCANeR_API.Com_declareInputData("Shm/ModelCabin/ModelToCab");
                //cabToSteering = SCANeR_API.Com_declareOutputData("Shm/ModelCabin/CabToSteering", 0);
                // steeringToCab = SCANeR_API.Com_declareInputData("Shm/ModelCabin/SteeringToCab", 0);


                //LogUsuario.Items.Add("Conexión con API exitosa");



                //_inicioSimulacion = new Thread(ProcesoGeneral);

                //BanderitaFalla.Visible = false;


            }

            catch
            {
                //BanderitaFalla.Visible = true;
                //LogUsuario.Items.Add("No se pudo conectar con API de SCANeR. No está abierto, o no está instalado.");
            }

            #endregion

        }


        //private void ProcesoGeneral()
        //{
        //    while (CerrarProceso)
        //    {

        //        try
        //        {
        //            SCANeR_API.Com_updateInputs(UpdateType.UT_AllData);
        //            SCANeR_API.Process_Run();
        //            _state = SCANeR_API.Process_GetState();
        //            SCANeR_API.Process_Wait();
        //            int frameNb = 0;


        //            _horaEvento = DateTime.Now.ToString("HH:mm:ss tt");

        //            BanderitaFalla.Visible = false;



        //            if (_state == APIProcessState.PS_RUNNING)
        //            {


        //                frameNb++;

        //                #region TxRx Canales

        //                //Canal 105 colision
        //                ExportChannel.Input(105, out _frameNbIn, out _val105);
        //                Import105.Text = _val105.ToString();

        //                //Canal 111 colision
        //                ExportChannel.Input(111, out _frameNbIn, out _val111);
        //                Import111.Text = _val111.ToString();


        //                //Canal 113  chancla en pendiente
        //                ExportChannel.Input(113, out _frameNbIn, out _val113);
        //                Import113.Text = _val113.ToString();

        //                //Canal 114 se salio de la via
        //                ExportChannel.Input(114, out _frameNbIn, out _val114);
        //                Import114.Text = _val114.ToString();

        //                //Canal 115 distancia recorrida
        //                ExportChannel.Input(115, out _frameNbIn, out _val115);
        //                Import_DistReco.Text = _val115.ToString();

        //                //Canal 116 consumo l/s
        //                ExportChannel.Input(116, out _frameNbIn, out _val116);
        //                Import_Consumo.Text = _val116.ToString();

        //                //Canal 117 co2
        //                ExportChannel.Input(117, out _frameNbIn, out _val117);
        //                Import_Co2.Text = _val117.ToString();


        //                //Canal 200
        //                ExportChannel.Input(200, out _frameNbIn, out _val200);
        //                CajaValorLluvia.Text = _val200.ToString();

        //                //Canal 201
        //                ExportChannel.Input(201, out _frameNbIn, out _val201);
        //                CajaValorAgarre.Text = _val201.ToString();

        //                //Canal 202
        //                ExportChannel.Input(202, out _frameNbIn, out _val202);
        //                CajaValorVisibilidad.Text = _val202.ToString();

        //                //Canal 203
        //                ExportChannel.Input(203, out _frameNbIn, out _val203);
        //                CajaValorHoraDia.Text = _val203.ToString();


        //                //Canal 300
        //                ExportChannel.Input(300, out _frameNbIn, out _val300);
        //                StatusAcelerador.Text = _val300.ToString();

        //                //Canal 301
        //                ExportChannel.Input(301, out _frameNbIn, out _val301);
        //                StatusFreno.Text = _val301.ToString();

        //                //Canal 302
        //                ExportChannel.Input(302, out _frameNbIn, out _val302);
        //                StatusClutch.Text = _val302.ToString();

        //                //Canal 303
        //                ExportChannel.Input(303, out _frameNbIn, out _val303);
        //                Import_CambioActual.Text = _val303.ToString();


        //                ////Canal 304
        //                //ExportChannel.Input(304, out _frameNbIn, out _val304);
        //                //Import_CambioActual.Text = _val303.ToString();


        //                //Canal 305
        //                ExportChannel.Input(305, out _frameNbIn, out _val305);
        //                Import_PosicionEncendido.Text = _val305.ToString();

        //                //Canal 306
        //                ExportChannel.Input(306, out _frameNbIn, out _val306);
        //                Import_EstadoMotor.Text = _val306.ToString();

        //                //Canal 307
        //                ExportChannel.Input(307, out _frameNbIn, out _val307);
        //                Import_FrenoMano.Text = _val307.ToString();

        //                //Canal 308
        //                ExportChannel.Input(308, out _frameNbIn, out _val308);
        //                Import_Cinturon.Text = _val308.ToString();



        //                //Canal 1024
        //                ExportChannel.Input(1024, out _frameNbIn, out _val1024);
        //                Import_RPM.Text = _val1024.ToString();


        //                //Canal 1025
        //                ExportChannel.Input(1025, out _frameNbIn, out _val1025);
        //                Import_Velocimetro.Text = _val1025.ToString();

        //                //Canal 1050
        //                ExportChannel.Input(1050, out _frameNbIn, out _val1050);
        //                Import_EstadoFaros.Text = _val1050.ToString();



        //                #endregion



        //                SCANeR_API.Com_updateOutputs(UpdateType.UT_AllData);
        //            }
        //            if (_state == APIProcessState.PS_DEAD)
        //            {
        //                CerrarProceso = false;



        //                this.Hide();
        //                this.Dispose();

        //                Application.ExitThread();
        //                Application.Exit();

        //            }
        //        }

        //        catch
        //        {
        //            //BanderitaFalla.Visible = true;
        //            //if (_state == APIProcessState.PS_DEAD)
        //            //{
        //            //    CerrarProceso = false;



        //            //    Application.ExitThread();
        //            //    Application.Exit();

        //            //}
        //        }



        //        TextoStatusSim.Text= _state == APIProcessState.PS_RUNNING ? ("Estado de la simulación: Ejecutandose") : ("Estado de la simulación: Detenida");
        //        //Console.WriteLine(stato);
        //    }
        //}

        string estado;
        //private void ProcesoGeneral()
        //{
        //    while (CerrarProceso)
        //    {

        //        try
        //        {
        //            //SCANeR_API.Com_updateInputs(UpdateType.UT_AllData);
        //            //SCANeR_API.Process_Run();
        //            //_state = SCANeR_API.Process_GetState();
        //            //SCANeR_API.Process_Wait();
        //            int frameNb = 0;


        //            _horaEvento = DateTime.Now.ToString("HH:mm:ss tt");

        //            BanderitaFalla.Visible = false;



        //            if (_state == APIProcessState.PS_RUNNING)
        //            {


        //                frameNb++;


        //                //Canal 105 colision
        //                ExportChannel.Input(105, out _frameNbIn, out _val105);
        //                Import105.Text = _val105.ToString();

        //                //Canal 111 colision
        //                ExportChannel.Input(111, out _frameNbIn, out _val111);
        //                Import111.Text = _val111.ToString();


        //                //Canal 113  chancla en pendiente
        //                ExportChannel.Input(113, out _frameNbIn, out _val113);
        //                Import113.Text = _val113.ToString();

        //                //Canal 114 se salio de la via
        //                ExportChannel.Input(114, out _frameNbIn, out _val114);
        //                Import114.Text = _val114.ToString();


        //                ExportChannel.Output(200, frameNb, float.Parse(CajaValorLluvia.Text));
        //                ExportChannel.Output(201, frameNb, float.Parse(CajaValorAgarre.Text));
        //                ExportChannel.Output(202, frameNb, float.Parse(CajaValorVisibilidad.Text));
        //                ExportChannel.Output(203, frameNb, float.Parse(CajaValorHoraDia.Text));


        //                //Canal 300 aceleredar
        //                ExportChannel.Input(300, out _frameNbIn, out _val300);
        //                StatusAcelerador.Text = _val300.ToString();

        //                //Canal 301 freno
        //                ExportChannel.Input(301, out _frameNbIn, out _val301);
        //                StatusFreno.Text = _val301.ToString();

        //                //Canal 302  embrague
        //                ExportChannel.Input(302, out _frameNbIn, out _val302);
        //                StatusClutch.Text = _val302.ToString();

        //                ////Canal 303
        //                //ExportChannel.Input(303, out _frameNbIn, out _val303);
        //                //StatusAcelerador.Text = _val303.ToString();

        //                ////Canal 304
        //                //ExportChannel.Input(304, out _frameNbIn, out _val304);
        //                //StatusFreno.Text = _val304.ToString();

        //                ////Canal 305
        //                //ExportChannel.Input(305, out _frameNbIn, out _val305);
        //                //StatusClutch.Text = _val305.ToString();

        //                //Canal 306
        //                ExportChannel.Input(1025, out _frameNbIn, out _val306);
        //                Import_Velocimetro.Text = _val306.ToString();



        //                //Canal 307
        //                ExportChannel.Input(1024, out _frameNbIn, out _val307);
        //                Import_RPM.Text = _val307.ToString();
        //                //ExportChannel.Output(1024, frameNb, float.Parse(Import_RPM.Text));



        //                //Canal 308
        //                ExportChannel.Input(308, out _frameNbIn, out _val308);
        //                Import_CambioActual.Text = _val308.ToString();

        //                //Canal 309
        //                ExportChannel.Input(309, out _frameNbIn, out _val309);
        //                Import_CambioGearbox.Text = _val309.ToString();

        //                //Canal 310
        //                ExportChannel.Input(310, out _frameNbIn, out _val310);
        //                Import_PosicionEncendido.Text = _val310.ToString();

        //                //Canal 311
        //                ExportChannel.Input(311, out _frameNbIn, out _val311);
        //                Import_EstadoMotor.Text = _val311.ToString();

        //                //Canal 312
        //                ExportChannel.Input(312, out _frameNbIn, out _val312);
        //                Import_FrenoMano.Text = _val312.ToString();

        //                //Canal 313
        //                ExportChannel.Input(313, out _frameNbIn, out _val313);
        //                Import_EstadoFaros.Text = _val313.ToString();

        //                //Canal 314
        //                ExportChannel.Input(314, out _frameNbIn, out _val314);
        //                StatusDireccion.Text = _val314.ToString();

        //                //Canal 315
        //                ExportChannel.Input(315, out _frameNbIn, out _val315);
        //                Import_Direccionales.Text = _val315.ToString();



        //                SCANeR_API.Com_updateOutputs(UpdateType.UT_AllData);
        //            }
        //            if (_state == APIProcessState.PS_DEAD)
        //            {
        //                CerrarProceso = false;



        //                this.Hide();
        //                this.Dispose();

        //                Application.ExitThread();
        //                Application.Exit();

        //            }
        //        }

        //        catch
        //        {
        //            //BanderitaFalla.Visible = true;
        //            if (_state == APIProcessState.PS_DEAD)
        //            {
        //                CerrarProceso = false;



        //                Application.ExitThread();
        //                Application.Exit();

        //            }
        //        }



        //        //TextoStatusSim.Text 
        //      estado= _state == APIProcessState.PS_RUNNING ? ("Estado de la simulación: Ejecutandose") : ("Estado de la simulación: Detenida");
        //      TextoStatusSim.Text = _state == APIProcessState.PS_RUNNING ? ("Estado de la simulación: Ejecutandose") : ("Estado de la simulación: Detenida");
        //    }
        //}










        string ConstruccionEscenario = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NResultadoFinal.BuscarReportesPorId(this.txtCedula.Text);
            //this.OcultarColumnas();
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void BtnModAprendizaje_Click(object sender, EventArgs e)
        {
        


            CmbPractica.Items.Clear();
            CmbPractica.Items.Add("Seleccionar un Tipo de Practica");
            CmbPractica.Items.Add("Aceleración Vs Frenado");
            CmbPractica.Items.Add("Conducción Trafico Alto y Semaforizacion");
            CmbPractica.Items.Add("Prueba de Reflejos");
            CmbPractica.Items.Add("Variables del Vehiculo en Ciudad");
            CmbPractica.Items.Add("Variables del Vehiculo en Rural");
            CmbPractica.Items.Add("Variables del Vehiculo en Patio de Maniobras");
            CmbPractica.Items.Add("Variables del Vehiculo en Zona Costera");

            CmbPractica.Items.Add("Cambios de Horario");
             CmbPractica.Items.Add("Cambios de Clima");
        


            tabControl1.SelectTab(2);
            LblModulo.Text = "Modulo Aprendizaje";
        }

        private void BtnModPracticaLibre_Click(object sender, EventArgs e)
        {
           
         

            CmbPractica.Items.Clear();
            CmbPractica.Items.Add("Seleccionar un Tipo de Practica");
            CmbPractica.Items.Add("Practica Libre en Ciudad");
            CmbPractica.Items.Add("Practica Libre en Carretera");
            CmbPractica.Items.Add("Practica Libre en Patio de Maniobras");
            CmbPractica.Items.Add("Practica Libre en Zona Costera");


        


            tabControl1.SelectTab(2);
            LblModulo.Text = "Modulo Practica Libre";
        }

        private void BtnModEvaluacion_Click(object sender, EventArgs e)
        {
            CmbPractica.Items.Clear();
            CmbPractica.Items.Add("Seleccionar un Tipo de Practica");
            CmbPractica.Items.Add("Evaluacion en Ciudad");
            CmbPractica.Items.Add("Evaluacion en Carretera");
            CmbPractica.Items.Add("Evaluacion en Patio de Maniobras");
            CmbPractica.Items.Add("Evaluacion en Zona Costera");

            tabControl1.SelectTab(2);

            LblModulo.Text = "Modulo Evaluación";
        }
        string Auto;
        string AutoElegido;
        private void cmbVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Auto = cmbVehiculos.SelectedItem.ToString();


            switch (Auto)
            {
                case "Automovil":
                    AutoElegido = "Auto";
                    ConfigEscenario.Text = AutoElegido;
                    break;
                case "Camion 4.5 Tn ":
                    AutoElegido = "Camion";
                    ConfigEscenario.Text = AutoElegido;
                    break;
                case "Camioneta 4x4":
                    AutoElegido = "Pickup";
                    ConfigEscenario.Text = AutoElegido;
                    break;


            }
            ConstruccionEscenario = AutoElegido + "_" + EscenarioElegido + "_" + PracticaElegida;
            ConfigEscenario.Text = ConstruccionEscenario;


        }
        string Practica;
        string PracticaElegida;
        private void CmbPractica_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CmbPractica.Items.Add("Aceleración Vs Frenado");
            //CmbPractica.Items.Add("Conducción Trafico Alto y Semaforizacion");
            //CmbPractica.Items.Add("Prueba de Reflejos");
            //CmbPractica.Items.Add("Prueba de Reflejos");
            //CmbPractica.Items.Add(" Variables del Vehiculo");
            Practica = CmbPractica.SelectedItem.ToString();

            switch (Practica)
            {
                case "Aceleración Vs Frenado":
                    PracticaElegida = "Frenos";
                    EscenarioElegido = "Scan";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                case "Conducción Trafico Alto y Semaforizacion":
                    PracticaElegida = "SemaforoTrafico";
                    EscenarioElegido = "Scan";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                case "Prueba de Reflejos":
                    PracticaElegida = "Reflejos";
                    EscenarioElegido = "Scan";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                case "Variables del Vehiculo en Ciudad":
                    PracticaElegida = "Variables";
                    EscenarioElegido = "Ciudad";
                    ConfigEscenario.Text = PracticaElegida;
                    break;



                     case "Variables del Vehiculo en Rural":
                    EscenarioElegido = "Rural";
                    PracticaElegida = "Variables";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Variables del Vehiculo en Patio de Maniobras":
                    EscenarioElegido = "Patio";
                    PracticaElegida = "Variables";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Variables del Vehiculo en Zona Costera":
                    EscenarioElegido = "Riviera";
                    PracticaElegida = "Variables";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Cambios de Horario":
                    EscenarioElegido = "Scan";
                    PracticaElegida = "CambioHorario";
                    ConfigEscenario.Text = PracticaElegida;
                    break;

                     case "Cambios de Clima":
                    EscenarioElegido = "Scan";
                    PracticaElegida = "CambioClima";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Practica Libre en Ciudad":
                    EscenarioElegido = "Ciudad";
                    PracticaElegida = "Eventos";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Practica Libre en Carretera":
                     EscenarioElegido = "Rural";
                    PracticaElegida = "Eventos";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Practica Libre en Patio de Maniobras":
                    EscenarioElegido = "Patio";
                    PracticaElegida = "Eventos";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Practica Libre en Zona Costera":
                    EscenarioElegido = "Riviera";
                    PracticaElegida = "Eventos";
                    ConfigEscenario.Text = PracticaElegida;
                    break;

                     case "Evaluacion en Zona Costera":
                    EscenarioElegido = "Riviera";
                    PracticaElegida = "Evaluacion";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Evaluacion en Patio de Maniobras":
                    EscenarioElegido = "Patio";
                    PracticaElegida = "Evaluacion";
                    ConfigEscenario.Text = PracticaElegida;
                    break;
                     case "Evaluacion en Carretera":
                    EscenarioElegido = "Rural";
                    PracticaElegida = "Evaluacion";
                    ConfigEscenario.Text = PracticaElegida;
                    break;

                     case "Evaluacion en Ciudad":
                    EscenarioElegido = "Ciudad";
                    PracticaElegida = "Evaluacion";
                    ConfigEscenario.Text = PracticaElegida;
                    break;



            }
            ConstruccionEscenario = AutoElegido + "_" + EscenarioElegido + "_" + PracticaElegida;
            ConfigEscenario.Text = ConstruccionEscenario;
        }
        string Escenario;
        string EscenarioElegido;

        

        private void ConfigEscenario_Click(object sender, EventArgs e)
        {

        }

        private void BtnCargarEscenario_Click(object sender, EventArgs e)
        {
            //SCANeR_API.Simulation_InitParams("KIRVITSIM", 0);

            ////SCANeR_API.Simulation_StartProcess("PRRK", 0);

            //SCANeR_API.Simulation_LoadScenario(0, ConfigEscenario.Text);
        }

        private void BotonErgoSi_Click(object sender, EventArgs e)
        {
            CajaErgo.Text = @"1";
            des_01 = 1;

            label15.ForeColor = Color.Green;
        }

        private void BotonErgoNo_Click(object sender, EventArgs e)
        {
            CajaDistancia.Text = @"0";
            des_02 = 0;
            label16.ForeColor = Color.Red;
        }

        private void BotonDistSi_Click(object sender, EventArgs e)
        {
            CajaDistancia.Text = @"1";
            des_02 = 1;
            label16.ForeColor = Color.Green;
        }

        private void BotonDistNo_Click(object sender, EventArgs e)
        {
            CajaDistancia.Text = @"0";
            des_02 = 0;
            label16.ForeColor = Color.Red;
        }

        private void BotonManosSi_Click(object sender, EventArgs e)
        {
            CajaManosVol.Text = @"1";
            des_03 = 1;
            label17.ForeColor = Color.Green;
        }

        private void BotonManosNo_Click(object sender, EventArgs e)
        {
            CajaManosVol.Text = @"0";
            des_03 = 0;
            label17.ForeColor = Color.Red;
        }

        private void BotonAdelSi_Click(object sender, EventArgs e)
        {
            CajaAdelant.Text = @"1";
            des_04 = 1;
            label18.ForeColor = Color.Green;
        }

        private void BotonAdelNo_Click(object sender, EventArgs e)
        {
            CajaAdelant.Text = @"0";
            des_04 = 0;
            label18.ForeColor = Color.Red;
        }

        private void BotonLumiSi_Click(object sender, EventArgs e)
        {
            CajaDispLum.Text = @"1";
            des_05 = 1;
            label19.ForeColor = Color.Green;
        }

        private void BotonLumiNo_Click(object sender, EventArgs e)
        {
            CajaDispLum.Text = @"0";
            des_05 = 0;
            label19.ForeColor = Color.Red;
        }

        private void BotonRecoSi_Click(object sender, EventArgs e)
        {
            CajaRecoPanel.Text = @"1";
            des_06 = 1;
            label20.ForeColor = Color.Green;
        }

        private void BotonRecoNo_Click(object sender, EventArgs e)
        {
            CajaRecoPanel.Text = @"0";
            des_06 = 0;
            label20.ForeColor = Color.Red;
        }

        private void BotonManiSi_Click(object sender, EventArgs e)
        {
            CajaManioSegu.Text = @"1";
            des_07 = 1;
            label21.ForeColor = Color.Green;
        }

        private void BotonManiNo_Click(object sender, EventArgs e)
        {
            CajaManioSegu.Text = @"0";
            des_07 = 0;
            label21.ForeColor = Color.Red;
        }

        private void BotonDistracSi_Click(object sender, EventArgs e)
        {
            CajaDistrac.Text = @"1";
            des_08 = 1;
            label22.ForeColor = Color.Green;
        }

        private void BotonDistracNo_Click(object sender, EventArgs e)
        {
            CajaDistrac.Text = @"0";
            des_08 = 0;
            label22.ForeColor = Color.Red;
        }

        private void BotonSeñaSi_Click(object sender, EventArgs e)
        {
            CajaSeñales.Text = @"1";
            des_09 = 1;
            label23.ForeColor = Color.Green;
        }

        private void BotonSeñaNo_Click(object sender, EventArgs e)
        {
            CajaSeñales.Text = @"0";
            des_09 = 0;
            label23.ForeColor = Color.Red;
        }

        private void BotonPanelSi_Click(object sender, EventArgs e)
        {
            CajaAno.Text = @"1";
            des_010 = 1;
            label24.ForeColor = Color.Green;
        }

        private void BotonPanelNo_Click(object sender, EventArgs e)
        {
            CajaAno.Text = @"0";
            des_010 = 0;
            label24.ForeColor = Color.Red;
        }

        private void BotonAgreSi_Click(object sender, EventArgs e)
        {
            CajaAgres.Text = @"1";
            des_011 = 1;
            label25.ForeColor = Color.Green;
        }

        private void BotonAgreNo_Click(object sender, EventArgs e)
        {
            CajaAgres.Text = @"0";
            des_011 = 0;
            label25.ForeColor = Color.Red;
        }

        private void BotonAñadirEvaluacionInstructor_Click(object sender, EventArgs e)
        {
            CuadroEvaluacionAdicional.Dock = DockStyle.Fill;
            CuadroEvaluacionAdicional.Visible = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void ActualizarReporte()
        {
            // obser1 = CantidadEvento1;// frenado brusco
            //obser2 = CantidadEvento2;// intento mover el vehiculo con una marcha de masiado alta
            //cnReportes.obser3 = CantidadEvento6;// Exceso de rpm
            //cnReportes.obser4 = CantidadEvento7;// Aceleró en vacío con el motor arrancado
            //cnReportes.obser5 = CantidadEvento9;// No accionó el embrague al darle arranque al vehiculo
            //cnReportes.obser6 = CantidadEvento12;//Exceso de velocidad
            //cnReportes.obser7 = CantidadEvento17;//se intento mover con el freno de seg activado
            //cnReportes.obser8 = CantidadEvento18;// dio arranque con marcha puesta
            //cnReportes.obser9 = CantidadEvento10;//colision
            //cnReportes.obser10 = CantidadEvento3;// olvido poner freno de seguriodad estando detenido el vehiculo
            //cnReportes.obser11 = CantidadEvento5;// olvido poner las luces en condiciones de baja visibilidad

            NReportes.Editar(Reporte.Text, txtCedula.Text, DateTime.Now, des_01, des_02, des_03, des_04, des_05, des_06, des_07, des_08, des_09, des_010, des_011, CantidadEvento1.ToString(), CantidadEvento2.ToString(), CantidadEvento6.ToString(), CantidadEvento7.ToString(), CantidadEvento9.ToString(), CantidadEvento12.ToString(), CantidadEvento17.ToString(), CantidadEvento18.ToString(), CantidadEvento10.ToString(), CantidadEvento3.ToString(), CantidadEvento5.ToString(), CajaComentariosInstructor.Text.ToString(), "Carlos Veloza");

        }

        private void Reloj_5Segundos_Tick(object sender, EventArgs e)
        {

            switch (estado)
            {
                case @"Estado de la simulación: Ejecutandose":




                    //EVENTO 1 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //Frenada muy brusca

                    double a = Convert.ToDouble(StatusFreno.Text);
                    double b = Convert.ToDouble(Import_Velocimetro.Text);


                    if (a > 300 && b > 10)
                    {
                        string Eventoactual1 = (_horaEvento + ": Se efectuó un frenado brusco.");

                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

                        CantidadEvento1++;
                        UltimoEventoFueColision = false;

                     
                    }

                    //EVENTO 2 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //Intento parar el carro con marcha muy alta

                    if (Convert.ToDouble(StatusFreno.Text) > 300 && Convert.ToDouble(Import_CambioActual.Text) >= 4)
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Se ha intentado frenar el vehiculo teniendo una marcha demasiado alta engranada.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

                        CantidadEvento2++;
                        UltimoEventoFueColision = false;

                    }


                    //EVENTO 6 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //Exceso rpm

                    double c = Convert.ToDouble(Import_RPM.Text);

                    if (c > 4000.0)
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Exceso de RPMs.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento6++;
                        UltimoEventoFueColision = false;

                    }

                    //EVENTO 7 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //Acelero en vacio
                    if (Convert.ToDouble(StatusAcelerador.Text) > 0 && Import_CambioActual.Text == "0")
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Aceleró en vacío con el motor arrancado.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento7++;
                        UltimoEventoFueColision = false;

                 
                    }

                 
                    //EVENTO 9 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //No acciono embrague al dar arranque

                    if (Import_PosicionEncendido.Text == "3" && StatusClutch.Text == "0")
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Habito no aconsejable: No accionó el embrague al darle arranque al vehiculo.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento9++;
                        UltimoEventoFueColision = false;
                    }
                    

               
                    //EVENTO 12 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-

                    //exceso de velocidad

                    double d = Convert.ToDouble(Import_Velocimetro.Text);

                    if (d > 80.0)
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Exceso de velocidad por encima del limite legal.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento12++;
                        UltimoEventoFueColision = false;
                    }

           
                
                    //EVENTO 17 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-

                    //intento mover carro con freno de seguridad
                    if (Convert.ToDouble(StatusAcelerador.Text) > 0 && Convert.ToDouble(Import_FrenoMano.Text) > 0)
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Intentó mover el vehiculo con el freno de seguridad activado.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento17++;
                        UltimoEventoFueColision = false;
                    }

                    //EVENTO 18 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //dio arranque con marcha puesta

                    if (Import_PosicionEncendido.Text == "3" && Import_CambioActual.Text != "0")
                    {
                        ListaEventos.Items.Add(_horaEvento + ": Habito no aconsejable: Arranca el carro con una marcha puesta.");
                        ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
                        CantidadEvento18++;
                        UltimoEventoFueColision = false;
                    }

                    //EVENTO 3 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-
                    //Olvido poner freno de mano

                    if ((Convert.ToDouble(Import_Velocimetro.Text) < 1) && Import_FrenoMano.Text == "0")
                    {
                        ContadorOlvidoFrenoMano.Text = Convert.ToString(Convert.ToDouble(ContadorOlvidoFrenoMano.Text) + 1);


                    }
                    else
                    {
                        ContadorOlvidoFrenoMano.Text = @"0";

                    }



                    //EVENTO 5 x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-

                    if (Convert.ToDouble(CajaValorVisibilidad.Text) < 10000 && Import_EstadoFaros.Text == "0")
                    {
                        ContadorOlvidoLuces.Text = Convert.ToString(Convert.ToDouble(ContadorOlvidoLuces.Text) + 1);

                    }





                    break;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Reporte.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IDRESULTADO"].Value);

            //Reportes = Reporte.Text;


            //FormReporte = new FormularioReporte();
            //FormReporte.idreporte = this.Reporte.Text;
            //FormReporte.Show();









        }

        private void BtnSiguienteModulos_Click(object sender, EventArgs e)
        {
          
            if (Reporte.Text == string.Empty || txtCedula.Text==string.Empty){


                MessageBox.Show("El usuario debe elegir un reporte para iniciar");

            }
            else
            {
                tabControl1.SelectTab(1);

            }


        }

        private void BtnCargarEscenario_Click_1(object sender, EventArgs e)
        {

            // SCANeR_API.Simulation_InitParams("KIRVITSIM", 0);

            // //SCANeR_API.Simulation_StartProcess("SISTEMADEREPORTES", 0);

            //SCANeR_API.Simulation_LoadScenario(0, ConfigEscenario.Text);

            tabControl1.SelectTab(3);
        }

      
        string Totaleventos;
        private void BotonGuardarReporte_Click(object sender, EventArgs e)
        {

            if (TextoStatusSim.Text == "Estado de la simulación: Detenida")
            {

                string Total = "";

                //Hacer resumen de lo que paso

                if (CantidadEvento1 > 0)
                {



                    Total = Totaleventos = "Total frenadas bruscas: " + CantidadEvento1 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }

                if (CantidadEvento2 > 0)
                {

                    Total = Totaleventos = Totaleventos + "Se ha intentado frenar el vehiculo teniendo una marcha demasiado alta engranada: " + CantidadEvento2 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }


                if (CantidadEvento3 > 0)
                {

                    Total = Totaleventos = Totaleventos + "Olvido poner freno de mano: " + CantidadEvento3 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }

                if (CantidadEvento5 > 0)
                {

                    Total = Totaleventos = Totaleventos + "freno:" + CantidadEvento2 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }

                if (CantidadEvento6 > 0)
                {

                    Total = Totaleventos = Totaleventos + "Exceso de RPMs: " + CantidadEvento6 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }

                if (CantidadEvento7 > 0)
                {

                    Total = Totaleventos = Totaleventos + "Aceleró en vacío con el motor arrancado: " + CantidadEvento7 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }

                if (CantidadEvento9 > 0)
                {

                    Total = Totaleventos = Totaleventos + "No accionó el embrague al darle arranque al vehiculo: " + CantidadEvento9 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }
                if (CantidadEvento10 > 0)
                {

                    Total = Totaleventos = Totaleventos + "colisiones contra peaton o vehiculo: " + CantidadEvento10 + System.Environment.NewLine + " " + System.Environment.NewLine;
                }

                if (CantidadEvento12 > 0)
                {

                    Total = Totaleventos = Totaleventos + "Exceso de velocidad por encima del limite legal: " + CantidadEvento12 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }




                if (CantidadEvento17 > 0)
                {

                    Total = Totaleventos = Totaleventos + "intento mover carro con freno de seguridad: " + CantidadEvento17 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }


                if (CantidadEvento18 > 0)
                {

                    Total = Totaleventos = Totaleventos + "dio arranque con marcha puesta: " + CantidadEvento18 + System.Environment.NewLine + " " + System.Environment.NewLine;


                }


                ActualizarReporte();
                //FormReporte = new FormularioReporte();
                //FormReporte.idreporte = Reportes;
                //FormReporte.Show();


            }
            else
            {

                MessageBox.Show("No se puede generar reporte mientras esta activada la practica");


            }

          
        }

        private void ContadorOlvidoLuces_Validated(object sender, EventArgs e)
        {

        }

        private void ContadorOlvidoLuces_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void SumarEvento10()
        {



            UltimoEventoFueColision = true;

            ListaEventos.Items.Add(_horaEvento + ": Colisión contra un vehiculo o petaton.");
            ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

            CantidadEvento10++;
        }
       
        private void SumarEvento13()
        {
            ListaEventos.Items.Add(_horaEvento + ": Mantuvo el acelerador pisado al circular en pendiente descendente.");
            ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

            CantidadEvento13++;
            UltimoEventoFueColision = false;

            //se salio
            //ListaEventos.Items.Add(_horaEvento + ": El vehiculo se volcó y / ó se salió de la vía.");
            //ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!BanderitaFalla.Visible)
            {
                //probar programa sin scanner
                //_inicioSimulacion.Start();
            }
        }

        private void ScrollLluviaYagarre_Scroll(object sender, EventArgs e)
        {
            if (ScrollLluviaYagarre.Value == 0)
            {
                CajaValorLluvia.Text = (@"0.0");
                CajaValorAgarre.Text = (@"1.0");
            }

            if (ScrollLluviaYagarre.Value == 1)
            {
                CajaValorLluvia.Text = (@"0.12");
                CajaValorAgarre.Text = (@"1.0");
            }

            if (ScrollLluviaYagarre.Value == 2)
            {
                CajaValorLluvia.Text = (@"0.15");
                CajaValorAgarre.Text = (@"0.75");
            }

            if (ScrollLluviaYagarre.Value == 3)
            {
                CajaValorLluvia.Text = (@"0.25");
                CajaValorAgarre.Text = (@"0.75");
            }

            if (ScrollLluviaYagarre.Value == 4)
            {
                CajaValorLluvia.Text = (@"0.3");
                CajaValorAgarre.Text = (@"0.6");
            }
            if (ScrollLluviaYagarre.Value == 5)
            {
                CajaValorLluvia.Text = (@"0.4");
                CajaValorAgarre.Text = (@"0.6");
            }
            if (ScrollLluviaYagarre.Value == 6)
            {
                CajaValorLluvia.Text = (@"0.75");
                CajaValorAgarre.Text = (@"0.45");
            }
            if (ScrollLluviaYagarre.Value == 7)
            {
                CajaValorLluvia.Text = (@"1.0");
                CajaValorAgarre.Text = (@"0.45");
            }
        }

        private void ScrollSelectorNeblina_Scroll(object sender, EventArgs e)
        {
            if (ScrollSelectorNeblina.Value == 0)
            {
                CajaValorVisibilidad.Text = Convert.ToString(10000);
            }

            if (ScrollSelectorNeblina.Value == 1)
            {
                CajaValorVisibilidad.Text = Convert.ToString(5000);
            }

            if (ScrollSelectorNeblina.Value == 2)
            {
                CajaValorVisibilidad.Text = Convert.ToString(4000);
            }

            if (ScrollSelectorNeblina.Value == 3)
            {
                CajaValorVisibilidad.Text = Convert.ToString(3000);
            }

            if (ScrollSelectorNeblina.Value == 4)
            {
                CajaValorVisibilidad.Text = Convert.ToString(2000);
            }

            if (ScrollSelectorNeblina.Value == 5)
            {
                CajaValorVisibilidad.Text = Convert.ToString(1000);
            }

            if (ScrollSelectorNeblina.Value == 6)
            {
                CajaValorVisibilidad.Text = Convert.ToString(900);
            }

            if (ScrollSelectorNeblina.Value == 7)
            {
                CajaValorVisibilidad.Text = Convert.ToString(800);
            }

            if (ScrollSelectorNeblina.Value == 8)
            {
                CajaValorVisibilidad.Text = Convert.ToString(700);
            }

            if (ScrollSelectorNeblina.Value == 9)
            {
                CajaValorVisibilidad.Text = Convert.ToString(600);
            }

            if (ScrollSelectorNeblina.Value == 10)
            {
                CajaValorVisibilidad.Text = Convert.ToString(500);
            }

            if (ScrollSelectorNeblina.Value == 11)
            {
                CajaValorVisibilidad.Text = Convert.ToString(400);
            }

            if (ScrollSelectorNeblina.Value == 12)
            {
                CajaValorVisibilidad.Text = Convert.ToString(300);
            }

            if (ScrollSelectorNeblina.Value == 13)
            {
                CajaValorVisibilidad.Text = Convert.ToString(200);
            }

            if (ScrollSelectorNeblina.Value == 14)
            {
                CajaValorVisibilidad.Text = Convert.ToString(100);
            }

            if (ScrollSelectorNeblina.Value == 15)
            {
                CajaValorVisibilidad.Text = Convert.ToString(0);
            }
        }

        private void ScrollHoradelDia_Scroll(object sender, EventArgs e)
        {
            CajaValorHoraDia.Text = Convert.ToString(ScrollHoradelDia.Value);
            //ListaEventos.Items.Add(_horaEvento + ": Instructor seleccionó nueva hora del día: " + ScrollHoradelDia.Value +
            //                       ":00");
            ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void BotonAñadirInfoInst_Click(object sender, EventArgs e)
        {
            CuadroEvaluacionAdicional.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarProceso = false;


            this.Hide();
            this.Dispose();

            Application.ExitThread();
            Application.Exit();
        }

        private void ContadorOlvidoFrenoMano_TextChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToDouble(ContadorOlvidoFrenoMano.Text) >= 20)
            {
                ContadorOlvidoFrenoMano.Text = @"0";

                ListaEventos.Items.Add(_horaEvento + ": Habito no aconsejable:  Se ha detenido el vehiculo por largo tiempo sin activar el freno de seguridad.");
                ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

                CantidadEvento3++;

            }
        }

        private void ContadorOlvidoLuces_TextChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToDouble(ContadorOlvidoLuces.Text) >= 5)
            {
                ContadorOlvidoLuces.Text = @"0";

                ListaEventos.Items.Add(_horaEvento + ": No se encendieron las luces en condiciones de baja visibilidad.");
                ListaEventos.SelectedIndex = ListaEventos.Items.Count - 1;

                CantidadEvento5++;

            }
        }

        private void Import105_TextChanged_1(object sender, EventArgs e)
        {
            if (UltimoEventoFueColision == false)
            {
                SumarEvento10();
                UltimoEventoFueColision = true;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BotonVolverARegistro_Click(object sender, EventArgs e)
        {
            if (TextoStatusSim.Text == "Estado de la simulación: Detenida")
            {
                LimpiarCampos();
                tabControl1.SelectTab(2);
            }
            else
            {

                MessageBox.Show("No se puede cambiar de Conductor con una practica Iniciada");
            }

          
        }

        private void LimpiarCampos()
        {

            txtCedula.Text = string.Empty;
            lblIdreporte.Text = string.Empty;
            LblModulo.Text = string.Empty;
            ConfigEscenario.Text = string.Empty;
            ListaEventos.Text = string.Empty;

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void CuadroEvaluacionAdicional_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void ListaEventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void BotonRevisarReportesAnteriores_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CajaValorLluvia_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaValorHoraDia_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaValorAgarre_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaValorVisibilidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_Consumo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_DistReco_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_Co2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_Velocimetro_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_CambioGearbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_PosicionEncendido_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_EstadoMotor_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_FrenoMano_TextChanged(object sender, EventArgs e)
        {

        }

        private void Import_EstadoFaros_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Import_RPM_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }
    }
}
