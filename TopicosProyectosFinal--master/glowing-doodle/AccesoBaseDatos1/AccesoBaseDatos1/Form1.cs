using MySqlConnector;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string Servidor = "LAPTOP-H1P4789P\\SQLEXPRESS";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "EDUAN1";

        private string ServidorMySQL = "localhost"; // Cambiar por el servidor MySQL
        private string BasedatosMySQL = "ESCOLAR";
        private string UsuarioMySQL = "EDUAN"; // Usuario de MySQL
        private string PasswordMySQL = "EDUAN1"; // Contraseña de MySQL

        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = "";

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database=master;User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(ConsultaSQL, conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Conexión MySQL
                    strConn = $"Server={ServidorMySQL};Database={BasedatosMySQL};User={UsuarioMySQL};Password={PasswordMySQL}";
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(ConsultaSQL, conn);
                        cmd.ExecuteNonQuery();
                    }
                }

                llenarGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void llenarGrid()
        {
            try
            {
                string strConn = "";
                DataTable dt = new DataTable();

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM dbo.Alumnos", conn);
                        adp.Fill(dt);
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Conexión MySQL
                    strConn = $"Server={ServidorMySQL};Database={BasedatosMySQL};User={UsuarioMySQL};Password={PasswordMySQL}";
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM Alumnos", conn);
                        adp.Fill(dt);
                    }
                }

                dgvAlumnos.DataSource = dt;
                dgvAlumnos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
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
                string strConn = "";

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database=master;User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("CREATE DATABASE ESCOLAR", conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Conexión MySQL
                    strConn = $"Server={ServidorMySQL};Database=master;User={UsuarioMySQL};Password={PasswordMySQL}";
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("CREATE DATABASE ESCOLAR", conn);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Base de datos creada correctamente.");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtCarrera.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Todos los campos deben ser llenados.");
                    return;
                }

                string strConn = "";

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO dbo.Alumnos (NoControl, nombre, carrera) " +
                                             "VALUES (@NoControl, @Nombre, @Carrera)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Carrera", Convert.ToInt32(txtCarrera.Text.Trim()));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Conexión MySQL
                    strConn = $"Server={ServidorMySQL};Database={BasedatosMySQL};User={UsuarioMySQL};Password={PasswordMySQL}";
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO Alumnos (NoControl, nombre, carrera) " +
                                             "VALUES (@NoControl, @Nombre, @Carrera)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@Carrera", Convert.ToInt32(txtCarrera.Text.Trim()));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                llenarGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
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

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no se hizo clic en el encabezado
            {
                DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];
                txtNoControl.Text = fila.Cells["NoControl"].Value?.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value?.ToString();
                txtCarrera.Text = fila.Cells["carrera"].Value?.ToString();
            }
        }

        private void btnCrearBD_Click_1(object sender, EventArgs e)
        {
            string connectionString = $"Server=LAPTOP-H1P4789P\\SQLEXPRESS; " +
                    "Database=master;" +
                    "User Id= sa;" +
                    "Password=EDUAN1";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT database_id FROM sys.databases WHERE name = 'ESCOLAR';";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object databaseId = cmd.ExecuteScalar();
                        if (databaseId == null)
                        {
                            cmd.CommandText = "CREATE DATABASE ESCOLAR";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("La base de datos 'ESCOLAR' fue creada exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("La base de datos 'ESCOLAR' ya existe.");
                        }
                    }
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("SQL Error: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema: " + Ex.Message);
            }
        }

        private void btnCreaTabla_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-H1P4789P\\SQLEXPRESS;" +
                              "Database=ESCOLAR;" +
                              "User Id=sa;" +
                              "Password=EDUAN1;" +
                              "TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkTable = @"
                IF NOT EXISTS (
                    SELECT * FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_NAME = 'Alumnos'
                )
                BEGIN
                    CREATE TABLE Alumnos (
                        NoControl VARCHAR(10) PRIMARY KEY,
                        nombre VARCHAR(50),
                        carrera INT
                    )
                END";

                    using (SqlCommand cmd = new SqlCommand(checkTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("La tabla 'Alumnos' fue creada exitosamente (si no existía).");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string strConn = "";

            try
            {
                if (txtNoControl.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtCarrera.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Todos los campos deben estar llenos para actualizar.");
                    return;
                }

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Alumnos SET nombre = @nombre, carrera = @carrera WHERE NoControl = @nocontrol";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@nocontrol", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@carrera", Convert.ToInt32(txtCarrera.Text.Trim()));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else if (chkMySQL.Checked)
                {
                    // Conexión MySQL
                    strConn = $"Server={ServidorMySQL};Database={BasedatosMySQL};User={UsuarioMySQL};Password={PasswordMySQL}";
                    using (MySqlConnection conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Alumnos SET nombre = @nombre, carrera = @carrera WHERE NoControl = @nocontrol";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@nocontrol", txtNoControl.Text.Trim());
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@carrera", Convert.ToInt32(txtCarrera.Text.Trim()));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                llenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string strConn = "";

            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingresa el NoControl del alumno que deseas eliminar.");
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este registro?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    if (chkSQLServer.Checked)
                    {
                        // Conexión SQL Server
                        strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Alumnos WHERE NoControl = @nocontrol";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@nocontrol", txtNoControl.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (chkMySQL.Checked)
                    {
                        // Conexión MySQL
                        strConn = $"Server={ServidorMySQL};Database={BasedatosMySQL};User={UsuarioMySQL};Password={PasswordMySQL}";
                        using (MySqlConnection conn = new MySqlConnection(strConn))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Alumnos WHERE NoControl = @nocontrol";
                            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@nocontrol", txtNoControl.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    llenarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strConn = "";

            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingresa el NoControl del alumno que deseas buscar.");
                    return;
                }

                if (chkSQLServer.Checked)
                {
                    // Conexión SQL Server
                    strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string query = "SELECT * FROM Alumnos WHERE NoControl = @nocontrol";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nocontrol", txtNoControl.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dgvAlumnos.DataSource = dt;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún alumno con ese NoControl.");
                                dgvAlumnos.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { ex.Message);
            }
        }




        private void chkSQLServer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMySQL_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    

