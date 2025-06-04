using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentesPersonalizados
{
    public partial class UserControl1: UserControl
    {
        private Button customButton;

        public UserControl1()
        {
            InitializeComponent();
            customButton = new Button
            {
                Text = "Custom Button",
                Location = new Point(10, 10),
                Size = new Size(100, 40)
            };
            customButton.MouseEnter += (s, e) => customButton.BackColor = Color.LightBlue;
            customButton.MouseLeave += (s, e) => customButton.BackColor = SystemColors.Control;
            customButton.DoubleClick += CustomDoubleClick;
            Controls.Add(customButton);
        }

        private void CustomDoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            OnDoubleClick(EventArgs.Empty);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
