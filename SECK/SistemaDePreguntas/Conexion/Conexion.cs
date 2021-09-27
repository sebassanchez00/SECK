#define TEST
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Conexion
    {
#if TEST
        public static string Cn = @"Data Source=DESKTOP-RSK4ANF\DESARROLLO;Initial Catalog = BD_Entrenador; Integrated Security = True";
#else
        public static string Cn = Properties.Settings.Default.cn;   
#endif

        /// <summary>
        /// Evalua si existe conexoón con la base de datos. Valida el string de conexión.
        /// </summary>
        /// <returns></returns>
        public static bool TestCon()
        {
            try
            {
                using (SqlConnection con_obj = new SqlConnection(Conexion.Cn))
                {
                    con_obj.Open();
                    return true;
                }            
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Mensaje {0}", e.Message));
                return false;
            }   
        }

        /// <summary>
        /// Guarda un nuevo string de conexion
        /// </summary>
        /// <param name="str"></param>
        public static void EscribirConString()
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            str.IntegratedSecurity = true; //Autenticación Windows
            str.PersistSecurityInfo = false; //Recordar y enviar contraseña (Aquí no usamos contraseña)
            str.InitialCatalog = "BD_Entrenador"; //Nombre de la base de datos
            str.DataSource = "SERVIDOR-CEAK\\SQLEXPRESS"; // System.Environment.MachineName ; //  + "\\" + "SQLEXPRESS" ; //Nombre de la maquina donde esta la base de datos

            Properties.Settings.Default.cn = str.ConnectionString;
            Properties.Settings.Default.Save(); 
        }
    }
}
