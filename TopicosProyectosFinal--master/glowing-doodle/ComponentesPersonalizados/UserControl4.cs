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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string rfcCorregido = RFCValidator.CorregirRFC(textBox1.Text);
            textBox1.Text = rfcCorregido;
            textBox1.SelectionStart = textBox1.Text.Length; // Mantiene el cursor al final

            if (!RFCValidator.EsRFCValido(rfcCorregido))
            {
                textBox1.BackColor = Color.LightCoral; // Rojo si el RFC es inválido
            }
            else
            {
                textBox1.BackColor = Color.White; // Blanco si el RFC es válido
            }
        }
    }
    public static class RFCValidator
    {
        /// <summary>
        /// Verifica si el RFC ingresado es válido según el formato oficial en México.
        /// </summary>
        public static bool EsRFCValido(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc))
                return false;

            string patronRFC = @"^[A-ZÑ&]{3,4}[0-9]{6}[A-Z0-9]{2,3}$";
            return Regex.IsMatch(rfc, patronRFC, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Corrige errores comunes en la captura del RFC (convierte a mayúsculas y elimina espacios).
        /// </summary>
        public static string CorregirRFC(string rfc)
        {
            if (string.IsNullOrWhiteSpace(rfc))
                return string.Empty;

            return rfc.ToUpper().Trim();
        }
    }
}

