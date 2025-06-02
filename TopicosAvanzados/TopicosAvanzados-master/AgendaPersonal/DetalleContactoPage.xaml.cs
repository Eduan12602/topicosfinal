using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgendaPersonal;

[QueryProperty(nameof(Contacto), "Contacto")]
public partial class DetalleContactoPage : ContentPage, INotifyPropertyChanged
{
    private Contacto _contacto;
    public Contacto Contacto
    {
        get => _contacto;
        set
        {
            _contacto = value;
            OnPropertyChanged();
            ActualizarUI();
        }
    }

    public DetalleContactoPage()
    {
        InitializeComponent();
    }

    private void ActualizarUI()
    {
        if (Contacto != null)
        {
            NombreLabel.Text = Contacto.Nombre;
            TelefonoLabel.Text = Contacto.Telefono;
            CorreoLabel.Text = Contacto.Correo;
            DireccionLabel.Text = Contacto.Direccion;
        }
    }

    public new event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
