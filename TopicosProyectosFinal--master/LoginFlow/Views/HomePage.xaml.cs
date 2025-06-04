using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace LoginFlow.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        var usuario = Preferences.Get("UsuarioActual", "Invitado");

        lblNombre.Text = $"Bienvenido, {usuario}";
    }

    private async void OnExploreTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Redirigiendo", "Vas a ser enviado a Youtube", "bye");
        await Browser.OpenAsync("https://www.youtube.com/", BrowserLaunchMode.SystemPreferred);
    }
}
