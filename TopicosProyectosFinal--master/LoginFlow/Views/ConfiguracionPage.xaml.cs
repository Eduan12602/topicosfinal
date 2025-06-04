using LoginFlow.Utils;
using System.Globalization;

namespace LoginFlow.Views;

public partial class ConfiguracionPage : ContentPage
{
    public ConfiguracionPage()
    {
        InitializeComponent();

        temaSwitch.IsToggled = ConfiguracionApp.ObtenerTema();
        idiomaPicker.SelectedItem = ConfiguracionApp.ObtenerIdioma();
    }

    private void OnTemaToggled(object sender, ToggledEventArgs e)
    {
        ConfiguracionApp.GuardarTema(e.Value);
        
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;

        lblEstado.IsVisible = true;
    }

    private void OnIdiomaChanged(object sender, EventArgs e)
    {
        string? idiomaSeleccionado = idiomaPicker.SelectedItem.ToString();
        
        if (idiomaSeleccionado != null)
            ConfiguracionApp.GuardarIdioma(idiomaSeleccionado);

        // Aplicar cultura al hilo actual
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(idiomaSeleccionado);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(idiomaSeleccionado);

        // Actualizar UI con nuevos textos
        ActualizarTextos();
        lblEstado.IsVisible = true;
    }

    private void ActualizarTextos()
    {
        return;

        //this.Title = Traductor.Get("Configuracion");
        //lblEstado.Text = Traductor.Get("CamposRequeridos"); // ejemplo de recarga
        // Aquí podrías actualizar otros elementos visibles de la página si se desea
    }
}
