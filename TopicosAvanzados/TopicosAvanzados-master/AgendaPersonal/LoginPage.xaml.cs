namespace AgendaPersonal;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        Label Reg = (sender as Label);
        var Msg = Reg.FormattedText.Spans[1].Text;
        //var customerName = (sender as Label).Text;
        DisplayAlert("Recuperar Password", $"Name : {Msg}", "ok");
    }
    private void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        Label Reg = (sender as Label);
        var Msg = Reg.FormattedText.Spans[0].Text;
        //var customerName = (sender as Label).Text;
        DisplayAlert("Registrar Usuario", $"Name : {Msg}", "ok");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("//home");
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Login failed", "Username or password if invalid", "Try again");
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "admin" && Password.Text == "1234";
    }
}