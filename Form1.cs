using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasAppx
{
    public partial class Form1 : Form
    {
        private SQLHelper sqlHelper;

        public Form1()
        {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            //dataGridView1.AutoGenerateColumns = true; //Columnas se generan automaticamente
            //dataGridView1.Columns.Clear();//Limpia las columnas antes de cargarlas 
            //dataGridView1.DataSource = sqlHelper.ObtenerProductos(); //Carga los productos al arrancar la app
            CargarDatos();//Aquí se cargan los datos al arrancar la appp
            CargarProductos();//Carga los productos al arrancar la app
        }

        private void CargarProductos()
        {
            try
            {
                var dt = sqlHelper.ObtenerProductos();
                MessageBox.Show($"Filas obtenidas: {dt.Rows.Count}");
                //dataGridView1.DataSource = dt;

                //dataGridView1.DataSource = sqlHelper.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                int stock = int.Parse(txtStock.Text.Trim());

                sqlHelper.InsertarVenta(codigo, descripcion, stock);
                MessageBox.Show("Venta insertada correctamente. ");

                CargarProductos();//Recarga los productos despues de insertar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la venta:" + ex.Message);
            }
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            try
            {
                DataTable productos = sqlHelper.ObtenerProductos();
                //dataGridView1.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void butVerGrid_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();//Crea instancia en formulario Form2
            form.ShowDialog();//Muestra formulario Form2
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 vistaGrid = new Form2();//Crea instancia en formulario 2
            vistaGrid.ShowDialog();//Muestra el formulario 2
            //MessageBox.Show("Boton 1 clicado");
;        }
    }
}