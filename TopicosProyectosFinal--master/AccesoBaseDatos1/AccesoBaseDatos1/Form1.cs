using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crmf;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string Servidor = "Mia\\SQLEXPRESS"; // SQL por defecto
        private string Basedatos = "ESCOLAR"; //nombre de la BD de sql por defecto
        private string UsuarioId = "sa";  // usuario de sql por defecto
        private string Password = "12345";  // contraseña de sql por defecto

        //Aqui definimos que cadena de conexion usar con respecto a la casilla seleccionada
        private string CadenaConexion()
        {
            //la variable donde se guarda la cadena de conexion
            string strConn = "";

            //si se elige Sql entra a este if
            if (chkSQLServer.Checked)
            {
                // Para SQL 
                strConn = $"Server={Servidor};" +
                          $"Database={Basedatos};" +
                          $"User Id={UsuarioId};" +
                          $"Password={Password}";
            }
            //caso contrario que se elija mysql, entra a este
            else if (chkMySQL.Checked)
            {
                // Para MySQL
                strConn = $"Server=localhost;" +     
                          $"Database=ESCOLAR;" +  //BD
                          $"User Id=root;" +      // Usuario de MySQL
                          $"Password= ;" +        // No hay contraseña
                          $"Port=3306";           // Puerto por defecto
            }

            return strConn;
        }


        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = CadenaConexion();

                if (chkSQLServer.Checked)
                {
                    // SQL Server
                    using (SqlConnection conn = new SqlConnection(strConn))//hacemos uso de 'using' para liberar los recursos adecuadamente+
                    {                                                      //+es decir, se cierra automaticamente al salir de este bloque
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(ConsultaSQL, conn);
                        cmd.ExecuteNonQuery(); 
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // MySQL
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(ConsultaSQL, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Refrescar después de ejecutar
                llenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llenarGrid()
        {
            try
            {
                string strConn = CadenaConexion();

                if (chkSQLServer.Checked)
                {
                    // SQL
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "select * from Alumnos";
                        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // MySQL
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "select * from Alumnos";
                        MySqlDataAdapter adp = new MySqlDataAdapter(sqlQuery, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }

                dgvAlumnos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = CadenaConexion();

                if (chkSQLServer.Checked)
                {
                    // SQL 
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("CREATE DATABASE ESCOLAR", conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Usar MySQL
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("CREATE DATABASE ESCOLAR", conn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreaTabla_Click_1(object sender, EventArgs e)
        {
            string consultaSQL;

            if (chkSQLServer.Checked)
            {       //crea una tabla si esta no existe es SQL
                consultaSQL =
                    "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Alumnos' AND xtype='U') " +
                    "CREATE TABLE Alumnos (" +
                    "NoControl varchar(10), " +
                    "nombre varchar(50), " +
                    "carrera int" +
                    ")";
            }
            else if (chkMySQL.Checked)
            {       //crea una tabla si esta no existe en MySQL
                consultaSQL =
                    "CREATE TABLE IF NOT EXISTS Alumnos (" +
                    "NoControl VARCHAR(10), " +
                    "nombre VARCHAR(50), " +
                    "carrera INT" +
                    ")"; 
            }
            else
            {
                MessageBox.Show("Selecciona una base de datos.");
                return;
            }

            // Llamar al método EjecutaComando con la consulta construida
            EjecutaComando(consultaSQL);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 ||
                    txtNombre.Text.Trim().Length == 0 ||
                    txtCarrera.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                if (!int.TryParse(txtCarrera.Text.Trim(), out int carrera))
                {
                    MessageBox.Show("El campo Carrera debe ser en número.");
                    return;
                }

                string strConn = CadenaConexion();

                if (chkSQLServer.Checked)
                {
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        //inserta los registros a la tabla
                        string query = "INSERT INTO Alumnos (NoControl, nombre, carrera) VALUES (@NoControl, @Nombre, @Carrera)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Carrera", carrera);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Refrescar con los nuevos datos
                    llenarGrid();
                }
                else if (chkMySQL.Checked)
                {
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();

                        string query = "INSERT INTO Alumnos (NoControl, nombre, carrera) VALUES (@NoControl, @Nombre, @Carrera)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Carrera", carrera);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Refrescar con los nuevos datos
                    llenarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkSQLServer.Checked = true;
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            try
            {   //verificamos que el campo NoControl no este vacio
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("El campo 'NoControl' es obligatorio.");
                    return;
                }

                string strConn = CadenaConexion();
                string noControl = txtNoControl.Text.Trim();

                if (chkSQLServer.Checked)
                {
                    // SQL
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        //Borramos especificamente el registro que coincida con el NoControl
                        string query = "DELETE FROM Alumnos WHERE NoControl = @NoControl";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // evitar inyecciones SQL, lo cual ayuda a la seguridad
                            //tambien se solucionan las advertencias
                            cmd.Parameters.AddWithValue("@NoControl", noControl);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // MySQL
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "DELETE FROM Alumnos WHERE NoControl = @NoControl";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // evitar inyecciones MySQL
                            cmd.Parameters.AddWithValue("@NoControl", noControl);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Refrescar después de eliminar 
                llenarGrid();
                MessageBox.Show("Registro eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
        }


        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("El campo 'NoControl' es obligatorio.");
                    return;
                }

                string strConn = CadenaConexion();
                string noControl = txtNoControl.Text.Trim();

                if (chkSQLServer.Checked)
                {
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "SELECT * FROM Alumnos WHERE NoControl=@NoControl";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", noControl);

                            //ExecuteReader para obtener los resultados
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {   //reader.HasRows es una propiedad que indica si la consulta devolvió filas
                                if (reader.HasRows)
                                {
                                    // Si existen filas, puede continuar
                                    while (reader.Read())
                                    {
                                        // Muestra los valores en los campos correspondientes
                                        txtNombre.Text = reader["nombre"].ToString();
                                        txtCarrera.Text = reader["carrera"].ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron registros con ese NoControl.");
                                }
                            }
                        }
                    }
                }
                else if (chkMySQL.Checked) 
                {
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "SELECT * FROM Alumnos WHERE NoControl=@NoControl";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", noControl);

                            //ExecuteReader para obtener los resultados
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Si existen filas, puede continuar
                                    while (reader.Read())
                                    {
                                        // Muestra los valores en los campos correspondientes
                                        txtNombre.Text = reader["nombre"].ToString();
                                        txtCarrera.Text = reader["carrera"].ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron registros con ese NoControl.");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al buscar el registro: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("El campo 'NoControl' es obligatorio.");
                    return;
                }

                string strConn = CadenaConexion();
                string noControl = txtNoControl.Text.Trim();

                if (chkSQLServer.Checked)
                {
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "UPDATE Alumnos SET nombre=@Nombre, carrera=@Carrera WHERE NoControl=@NoControl";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", noControl); // el NoControl a buscar
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim()); // el nuevo nombre
                            cmd.Parameters.AddWithValue("@Carrera", int.Parse(txtCarrera.Text.Trim())); // la nueva carrera

                            cmd.ExecuteNonQuery(); // Ejecuta la consulta para actualizar el registro
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "UPDATE Alumnos SET nombre=@Nombre, carrera=@Carrera WHERE NoControl=@NoControl";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", noControl); // el NoControl a buscar
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim()); // el nuevo nombre
                            cmd.Parameters.AddWithValue("@Carrera", int.Parse(txtCarrera.Text.Trim())); // la nueva carrera

                            cmd.ExecuteNonQuery(); // Ejecuta la consulta para actualizar el registro
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }

        }

        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = CadenaConexion();

                if (chkSQLServer.Checked)
                {
                    using (SqlConnection conn = new SqlConnection(strConn)) // Usa SqlConnection para SQL Server
                    {
                        conn.Open();

                        string query = "DELETE FROM Alumnos";  // Este comando eliminará todos los registros

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery(); // Ejecuta el comando DELETE
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();

                        string query = "DELETE FROM Alumnos";  // Eliminará todos los registros

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery(); // Ejecuta el comando DELETE 
                        }
                    }
                }
                llenarGrid();
                MessageBox.Show("Registro eliminado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar la tabla "+ ex.Message);
            }
        }
    }
}
