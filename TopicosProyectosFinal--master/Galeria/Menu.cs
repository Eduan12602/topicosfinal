using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;



namespace Galeria
{

    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            panelImagenes = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(panelImagenes);
        }

        private string selectedFolder = "";
        private FlowLayoutPanel panelImagenes;


        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = folderDialog.SelectedPath;
                    CargarImagenes(selectedFolder);
                }
            }
        }

        private void Mostrar(String Rutaimg, String MSJ)
        {
            ImagenForm ventanaImagen = new ImagenForm(Rutaimg);
            ventanaImagen.Show();
        }

        private void CargarImagenes(string folderPath)
        {
            panelImagenes.Controls.Clear();
            string[] archivosImagen = Directory.GetFiles(folderPath, "*.jpg");
            archivosImagen = archivosImagen.Concat(Directory.GetFiles(folderPath, "*.jpeg")).ToArray();
            archivosImagen = archivosImagen.Concat(Directory.GetFiles(folderPath, "*.png")).ToArray();
            archivosImagen = archivosImagen.Concat(Directory.GetFiles(folderPath, "*.bmp")).ToArray();
            archivosImagen = archivosImagen.Concat(Directory.GetFiles(folderPath, "*.gif")).ToArray();

            foreach (string archivo in archivosImagen)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(archivo),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 100,
                    Height = 100,
                    Margin = new Padding(5)
                };
                pictureBox.Click += (s, e) => Mostrar(archivo, "Imagen seleccionada");
                panelImagenes.Controls.Add(pictureBox);
            }

        }


        public class ImagenForm : Form
        {
            public ImagenForm(string rutaImagen)
            {
                this.Text = "Imagen (" + rutaImagen + ") Mostrada";
                this.Size = new Size(600, 400);

                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(rutaImagen),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill
                };

                this.Controls.Add(pictureBox);
            }
        }

       
    }
}
