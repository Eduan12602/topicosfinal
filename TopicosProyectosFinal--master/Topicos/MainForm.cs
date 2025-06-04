using System.Drawing.Text;
using System.Windows.Forms;
using Galeria;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Topicos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<object> Contacto = new List<object>();

            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Correo = textBox3.Text;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(Correo))
            {
                if (Nombre.All(char.IsLetter))
                {
                    if (Numero.All(char.IsDigit))
                    {
                        MessageBox.Show("Se ha agregado un contacto.");
                        string contacto = $" {Nombre}, {Numero}, {Correo}";
                        Directorio.Items.Add(contacto);
                    }
                    else
                    {
                        MessageBox.Show("El Numero solo debe contener numeros.");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre solo debe contener letras.");
                }
            }
            else
            {
                MessageBox.Show("Falta algo de ingresar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directorio.SelectedItem != null)
            {
                string itemSeleccionado = Directorio.SelectedItem.ToString();

                Directorio.Items.Remove(itemSeleccionado);
                MessageBox.Show("Se ha eliminado el contacto." + itemSeleccionado);
            }
            else
            {

                MessageBox.Show("No se ha seleccionado ningún contacto.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas borrar todo?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Directorio.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa sirve para agendar contactos detro utilizando una lista,\n" +
                "la cual almacenara los nombres, celulares y correos");
        }

        private void galeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
