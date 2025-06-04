namespace LoginFlow.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        try
        {
            string nombre = NombreEntry.Text?.Trim();
            string correo = CorreoEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            Preferences.Set("usuario_nombre", nombre);
            Preferences.Set("usuario_correo", correo);
            Preferences.Set("usuario_password", password);

            ResultadoLabel.Text = "Usuario registrado correctamente.";
            ResultadoLabel.IsVisible = true;

            await Task.Delay(1500);
            await Shell.Current.GoToAsync(".."); // Regresa al login
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ha ocurrido un error: {ex.Message}", "OK");
        }
    }
}
