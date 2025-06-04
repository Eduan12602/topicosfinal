using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentesPersonalizados
{
    public partial class UserControl2 : UserControl
    {



        public UserControl2()
        {
            InitializeComponent(); // textBox1 ya es inicializado aquí

            // Solo asignamos eventos, sin volver a inicializar textBox1
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play(); // Sonido de advertencia
            }
        }
    }
}



