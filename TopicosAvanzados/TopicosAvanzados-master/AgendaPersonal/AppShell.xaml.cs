namespace AgendaPersonal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {



            InitializeComponent();
            Routing.RegisterRoute(nameof(CrearContactoPage), typeof(CrearContactoPage));
            Routing.RegisterRoute(nameof(DetalleContactoPage), typeof(DetalleContactoPage));
            Routing.RegisterRoute(nameof(ContactosPage), typeof(ContactosPage));
            Routing.RegisterRoute(nameof(ConfiguracionPage), typeof(ConfiguracionPage));
            Routing.RegisterRoute("home", typeof(MainPage));
            Routing.RegisterRoute("login", typeof(LoginPage)); 




        }
    }
}