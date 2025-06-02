using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dina1 // Define el espacio de nombres de la aplicación.
{
    public partial class Form1 : Form // Clase principal que hereda de Form para crear una ventana de formulario.
    {
        // Definición de las variables que almacenarán los controles de la interfaz.
        private Label lblTitulo, lblnombre, lbltelefono, lblcorreo;
        private TextBox txtNombre, txtTelefono, txtCorreo;
        private Button btnAgregar, btnEliminar, btnLimpiar;
        private ListBox lstContactos;
        private MenuStrip menuStrip;
        private ToolStripMenuItem salirToolStripMenuItem, acercaDeToolStripMenuItem;

        public Form1() // Constructor de la clase Form1.
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            InitializeCustomComponents(); // Llama a la función que inicializa los componentes personalizados.
        }

        private void InitializeCustomComponents() // Método para inicializar los controles personalizados del formulario.
        {
            // Inicialización de las etiquetas (Labels) con su texto y posición.
            lblTitulo = new Label { Text = "Gestion de Contacto", AutoSize = true, Location = new System.Drawing.Point(350, 30) };
            lblcorreo = new Label { Text = "Correo: ", AutoSize = true, Location = new System.Drawing.Point(300, 110) };
            lblnombre = new Label { Text = "Nombre: ", AutoSize = true, Location = new System.Drawing.Point(300, 50) };
            lbltelefono = new Label { Text = "Telefono: ", AutoSize = true, Location = new System.Drawing.Point(300, 80) };

            // Inicialización de los cuadros de texto (TextBox) para ingresar datos.
            txtNombre = new TextBox { Location = new System.Drawing.Point(350, 50), Width = 200 };
            txtTelefono = new TextBox { Location = new System.Drawing.Point(350, 80), Width = 200 };
            txtCorreo = new TextBox { Location = new System.Drawing.Point(350, 110), Width = 200 };

            // Inicialización de los botones (Button) con su texto y ubicación.
            btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(20, 140) };
            btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(100, 140) };
            btnLimpiar = new Button { Text = "Limpiar", Location = new System.Drawing.Point(180, 140) };

            // Inicialización de la lista (ListBox) para mostrar los contactos.
            lstContactos = new ListBox { Location = new System.Drawing.Point(20, 180), Size = new System.Drawing.Size(240, 100) };

            // Inicialización del menú (MenuStrip) y los elementos del menú.
            menuStrip = new MenuStrip();
            salirToolStripMenuItem = new ToolStripMenuItem("Salir"); // Elemento de menú "Salir"
            acercaDeToolStripMenuItem = new ToolStripMenuItem("Acerca de"); // Elemento de menú "Acerca de"
            menuStrip.Items.Add(salirToolStripMenuItem); // Agregar el ítem "Salir" al menú.
            menuStrip.Items.Add(acercaDeToolStripMenuItem); // Agregar el ítem "Acerca de" al menú.

            // Añadir los controles al formulario para que se muestren en la ventana.
            this.Controls.Add(lbltelefono);
            this.Controls.Add(lblnombre);
            this.Controls.Add(lblcorreo);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(txtNombre);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(txtCorreo);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEliminar);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(lstContactos);
            this.Controls.Add(menuStrip);

            // Asignar los manejadores de eventos (event handlers) a los botones y elementos del menú.
            btnAgregar.Click += btnAgregar_Click; // Manejador de clic para el botón "Agregar".
            btnEliminar.Click += btnEliminar_Click; // Manejador de clic para el botón "Eliminar".
            btnLimpiar.Click += btnLimpiar_Click; // Manejador de clic para el botón "Limpiar".
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click; // Manejador de clic para el menú "Salir".
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click; // Manejador de clic para el menú "Acerca de".
        }

        private void btnAgregar_Click(object sender, EventArgs e) // Manejador de clic para el botón "Agregar".
        {
            // Verifica si alguno de los campos está vacío y muestra un mensaje de error si es el caso.
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina la ejecución si los campos están vacíos.
            }

            // Crea una cadena con los datos del contacto y la agrega a la lista de contactos.
            string contacto = $"{txtNombre.Text} - {txtTelefono.Text} - {txtCorreo.Text}";
            lstContactos.Items.Add(contacto);
            MessageBox.Show("Contacto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje de éxito.
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Manejador de clic para el botón "Eliminar".
        {
            // Verifica si se ha seleccionado un contacto en la lista. Si no, muestra un mensaje de error.
            if (lstContactos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina la ejecución si no se ha seleccionado ningún contacto.
            }

            // Elimina el contacto seleccionado de la lista.
            lstContactos.Items.RemoveAt(lstContactos.SelectedIndex);
            MessageBox.Show("Contacto eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje de eliminación exitosa.
        }

        private void btnLimpiar_Click(object sender, EventArgs e) // Manejador de clic para el botón "Limpiar".
        {
            // Limpia los cuadros de texto de los campos de entrada.
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) // Manejador de clic para el menú "Salir".
        {
            Application.Exit(); // Cierra la aplicación.
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e) // Manejador de clic para el menú "Acerca de".
        {
            // Muestra un mensaje con información sobre la aplicación.
            MessageBox.Show("Aplicación de Gestión de Contactos - dina1\nDesarrollado en C#", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    


private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
