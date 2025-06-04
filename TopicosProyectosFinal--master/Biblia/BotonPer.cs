using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblia
{
    public partial class BotonPer : UserControl
    {
        public BotonPer()
        {
            InitializeComponent();
            Boton1.MouseEnter += Boton1_OnMouseEnter;
            Boton1.MouseLeave += Boton1_MouseLeave;
            Boton1.DoubleClick += Boton1_DoubleClick;
        }

        private void Boton1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Doble clic");
          
        }

        private void Boton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        } 

        private void Boton1_OnMouseEnter(object sender, EventArgs e)
        {
            Boton1.BackColor = Color.Blue;
        }
        private void Boton1_MouseLeave(object sender, EventArgs e)
        {
            Boton1.BackColor = SystemColors.Control;
        }
       
    }
}
