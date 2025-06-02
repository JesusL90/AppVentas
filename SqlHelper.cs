using System;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Data;

public class SQLHelper
{
    private string dbFile = "ventas0.db";//Nombre del archivo de la DB
    private string connectionString;//Cadena de conexion a la DB

    public SQLHelper()
    {
        connectionString = ConfigurationManager.ConnectionStrings["ventas0.db"].ConnectionString;//Cadena de conexion a la DB
        //crearBaseDeDatosSiNoExiste();//Esta funcion crea la base de datos si no existe
    }

    public void crearBaseDeDatosSiNoExiste()
    {
        /*if (!File.Exists(dbFile))//Verifica si el archivo de la DB existe
        {
            SQLiteConnection.CreateFile(dbFile);//Si no existe, lo crea
        }

        using (SQLiteConnection conn = new SQLiteConnection(connectionString))//Abre conexion a DB
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS ventas0 (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Codigo TEXT NOT NULL UNIQUE,
                Descripcion TEXT,
                Stock INTEGER DEFAULT 0
                );";
            cmd.ExecuteNonQuery();
        }*/
    }

    //Ejemplo de metodo para insertar una venta 
    public void InsertarVenta(string codigo, string descripcion, int stock)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ventas0.db"].ConnectionString;
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO ProdNoVendidos (CodigoProd, DescripcionProd, StockProd) VALUES (@codigo, @descripcion, @stock)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@codigo", codigo);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@stock", stock);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    //Aquí puedes agregar más metodos para actualizar, eliminar o consultar datos de la DB
    public DataTable ObtenerProductos()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ventas0.db"].ConnectionString;
        using (var connection = new SQLiteConnection(connectionString))
        {

            connection.Open();
            string query = "SELECT * FROM ProdNoVendidos";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt; //Devuelve una DataTable con los productos
        }
    }
}