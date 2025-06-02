using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasAppx
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CargarDatos();//Carga los datos al iniciar el formulario
        }

        private void CargarDatos()
        {
            try
            {
                string ruta = Path.GetFullPath("ventas0.db");//Obtiene la ruta completa del archivo de la DB
                MessageBox.Show("Cargando base de datos desde:\n " + ruta);

                string conexion = "Data Source=ventas0.db;Version=3;";//Cadena conexion DB
                using (SQLiteConnection connection = new SQLiteConnection(conexion))
                {
                    
                    connection.Open();
                    string query = "SELECT IdProd, CodigoProd, DescripcionProd, StockProd FROM ProdNoVendidos";//Consulta SQL
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);//Llena el dataTable con los datos de la consulta 
                        dataGridView1.AutoGenerateColumns = true;//Genera columnas automaticamente
                        //Linea para asignar la fuente de datos al DataGrid
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            
        }
    }
}
