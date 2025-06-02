namespace AgendaPersonal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void IrListaContactos(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ContactosPage));
        }

        private async void IrCrearContacto(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CrearContactoPage));
        }

        private async void IrConfiguracion(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ConfiguracionPage));
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
            {
                Preferences.Remove("UsuarioActual");
                SecureStorage.RemoveAll();
                await Shell.Current.GoToAsync("/login");
            }
        }
    }
}
