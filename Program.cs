using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VentasAppx
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Verificar data directory de la app
            //string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString() ?? "NO DEFINIDO";
            //MessageBox.Show("Ruta del archivo ventas0.db:\n" + dataDirectory);
            string rutaDb = System.IO.Path.Combine(Application.StartupPath, "ventas0.db");
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);//Apunta al directorio de la aplicacion

            Application.Run(new Form1());
        }

    }
    
        
}

