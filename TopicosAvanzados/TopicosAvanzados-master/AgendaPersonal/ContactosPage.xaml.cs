using System.Collections.ObjectModel;

namespace AgendaPersonal;

public partial class ContactosPage : ContentPage
{
    public ObservableCollection<Contacto> Contactos { get; set; }

    public ContactosPage()
    {
        InitializeComponent();
        Contactos = new ObservableCollection<Contacto>
        {
            new Contacto { Nombre = "Ana", Telefono = "1234567890", Correo = "ana@mail.com" },
            new Contacto { Nombre = "Luis", Telefono = "0987654321", Correo = "luis@mail.com" }
        };
        BindingContext = this;
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contactoSeleccionado)
        {
            await Shell.Current.GoToAsync(nameof(DetalleContactoPage), true, new Dictionary<string, object>
            {
                { "Contacto", contactoSeleccionado }
            });
        }
        ((CollectionView)sender).SelectedItem = null;
    }
}

public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; } // Para DetalleContactoPage
}