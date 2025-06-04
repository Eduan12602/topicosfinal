using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblia
{
    public partial class CajaTextP: UserControl
    {
        public CajaTextP()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione algo en la lista.");
                textBox1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool letraValida = false;
            //Rrecorremos los ítems seleccionados en el CheckedListBox
            foreach (var item in checkedListBox1.CheckedItems)
            {

                // Si se selecciona "Letras", solo permitimos letras 
                if (item.ToString() == "Letras")
                {
                    if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                    {
                             letraValida = true;
                    }
                    else
                    {
                        e.Handled = true; // Bloquea la tecla si no es una letra
                        textBox1.BackColor = Color.Red;
                    }                    
                }
                //  Si se selecciona "Numeros", solo permitimos números  
                else if (item.ToString() == "Numeros")
                {
                    if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                    {
                       letraValida = true;
                    }
                    else
                    {
                        e.Handled = true; // Bloquea la tecla si no es una letra
                        textBox1.BackColor = Color.Red;
                    }

                }
                //  Si se selecciona "Ambos", permitimos letras y números 
                else if (item.ToString() == "Ambos")
                {
                    if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                    {
                          letraValida = true;
                    }
                }
                
            }
            //regresa al color original
            if (letraValida)
            {
                textBox1.BackColor = SystemColors.Control;
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
