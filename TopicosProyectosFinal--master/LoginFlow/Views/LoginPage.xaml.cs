namespace LoginFlow.Views;

public partial class LoginPage : ContentPage
{
    // Usuario y contraseña predefinidos
    private const string USUARIO_PREDEFINIDO = "admin";
    private const string CONTRASENA_PREDEFINIDA = "1234";

    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("Register");
    }

    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("Recover");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            await DisplayAlert("Login fallido", "Usuario o contraseña incorrectos", "Intentar de nuevo");
        }
    }

    bool IsCredentialCorrect(string username, string password)
    {
        return username == USUARIO_PREDEFINIDO && password == CONTRASENA_PREDEFINIDA;
    }
}
