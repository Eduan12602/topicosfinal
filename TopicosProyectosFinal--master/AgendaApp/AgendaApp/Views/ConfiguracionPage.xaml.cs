
using AgendaApp.Utils;
using System.Globalization;

using System;

using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace AgendaApp.Views
{
    public partial class ConfiguracionPage : ContentPage
    {
        public ConfiguracionPage()
        {
            InitializeComponent();

            // Asegúrate que devuelven valores válidos
            string idioma = ConfiguracionApp.ObtenerIdioma();
            idiomaPicker.SelectedItem = idioma == "en" ? "en" : "es";

            temaSwitch.IsToggled = ConfiguracionApp.ObtenerTema();

            AplicarIdioma(idioma);
        }

        private void OnTemaToggled(object sender, ToggledEventArgs e)
        {
            ConfiguracionApp.GuardarTema(e.Value);
            Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
            MostrarMensajeGuardado();
        }

        private void OnIdiomaChanged(object sender, EventArgs e)
        {
            if (idiomaPicker.SelectedItem is string idiomaSeleccionado)
            {
                ConfiguracionApp.GuardarIdioma(idiomaSeleccionado);
                AplicarIdioma(idiomaSeleccionado);
                MostrarMensajeGuardado();
            }
        }

        private void AplicarIdioma(string idioma)
        {
            try
            {
                var cultura = new CultureInfo(idioma);
                Thread.CurrentThread.CurrentUICulture = cultura;
                Thread.CurrentThread.CurrentCulture = cultura;
            }
            catch (CultureNotFoundException)
            {
                // Idioma inválido, no aplicar
            }
        }

        private async void MostrarMensajeGuardado()
        {
            lblEstado.IsVisible = true;
            await Task.Delay(2000);
            lblEstado.IsVisible = false;
        }
    }
}
