using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblia;

namespace ProbarBiblioteca
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //se crean instancias para para llamar a los metodos
        RFC rfc = new RFC();
       Validar validar = new Validar();

        private void button1_Click(object sender, EventArgs e)
        {
            //asignamos el valor de laa textBox a una variable
            string rfcInput = textBox1.Text;
          

            // Verificar si el RFC es válido (suponiendo que RFC tiene un método para validar)
            bool esValido = RFC.PruebaRFC(rfcInput);

            // Mostrar un mensaje según el resultado
            if (esValido)
            {

                MessageBox.Show("El RFC es valido");
            }
            else
            {
                MessageBox.Show("El RFC no es valido.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //asignamos el valor de laa textBox a una variable
            string texto =textBox2.Text;

            //asignamos a las variables booleanas el resultado de los metodos
            bool soloNumeros = Validar.Numeros(texto);
            bool soloLetras = Validar.Letras(texto);

            //mostramos resultado segun el valor
            if (soloNumeros) {
                MessageBox.Show("Son solo numeros");
            }
            else if (soloLetras)
            {
                MessageBox.Show("Son solo letras");
            }
            else {
                MessageBox.Show("Tiene de ambos caracteres");
            }

        }
    }
        }
    

