using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentesPersonalizados
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!InputValidator.EsSoloLetras(textBox1.Text))
            {
                textBox1.BackColor = Color.LightCoral;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

        }
    }
    public static class InputValidator
    {
        /// <summary>
        /// Verifica si el texto contiene solo números.
        /// </summary>
        /// <param name="texto">Cadena a validar</param>
        /// <returns>True si solo contiene números, False en caso contrario</returns>
        public static bool EsSoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, "^[0-9]+$");
        }

        /// <summary>
        /// Verifica si el texto contiene solo letras (sin números ni caracteres especiales).
        /// </summary>
        /// <param name="texto">Cadena a validar</param>
        /// <returns>True si solo contiene letras, False en caso contrario</returns>
        public static bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, "^[A-Za-zÁÉÍÓÚÑáéíóúñ]+$");
        }
    }
}

