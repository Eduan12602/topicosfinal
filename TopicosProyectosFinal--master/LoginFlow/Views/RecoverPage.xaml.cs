namespace LoginFlow.Views
{
    public partial class RecoverPage : ContentPage
    {
        public RecoverPage()
        {
            InitializeComponent();
        }

        private async void OnRecoveryClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Error", "Por favor ingresa un correo electrónico.", "OK");
                return;
            }

            // Aquí deberías hacer la lógica de recuperación, como enviar un correo de recuperación
            // Este es solo un ejemplo simulado
            await DisplayAlert("Recuperación", "Se ha enviado un correo con instrucciones para recuperar tu contraseña.", "OK");

            // Después de mostrar el mensaje, puedes redirigir a la página de inicio de sesión
            await Shell.Current.GoToAsync("login");
        }
    }
}
