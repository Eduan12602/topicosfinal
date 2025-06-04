using Topicos;
using Galeria;
using Biblia;
namespace MenuGlobal

    
{
    public partial class MenuGob : Form
    {
        public MenuGob()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm agenda= new MainForm();    
            agenda.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu galeria = new Menu();
            galeria.Show();
        }
    }
}
