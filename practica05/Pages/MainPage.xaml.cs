using System;
using practica05.Pages; // <-- Importa tu carpeta Pages

namespace practica05.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void IrListaContactos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage1());
        }

        private async void IrCrearContacto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearContactoPage());
        }

        private async void IrConfiguracion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfiguracionPage());
        }
    }
}
