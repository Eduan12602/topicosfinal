
using LoginFlow.Modelos;
using LoginFlow.Datos;
using LoginFlow.Utils;

namespace LoginFlow.Views;

public partial class AgendaPage : ContentPage
{
    private ContactoDatabase db = new ContactoDatabase();

    public AgendaPage()
    {
        InitializeComponent();
        //this.db = db;

        titleLabel.Text = Traductor.Get("TituloAgenda");
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        contactosView.ItemsSource = await db.ObtenerContactosAsync();
    }

    private async void OnAgregarContactoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContactoPage());
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto seleccionado)
        {
            await Navigation.PushAsync(new ContactoPage(seleccionado));
        }
    }

    private async void OnEliminarContacto(object sender, EventArgs e)
    {
        if (((SwipeItem)sender).BindingContext is Contacto contacto)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {contacto.Nombre}?", "Sí", "No");
            if (confirm)
            {
                
                await db.EliminarContactoAsync(contacto);
                contactosView.ItemsSource = await db.ObtenerContactosAsync();
            }
        }
    }

    private async void OnConfiguracionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfiguracionPage());
    }
}