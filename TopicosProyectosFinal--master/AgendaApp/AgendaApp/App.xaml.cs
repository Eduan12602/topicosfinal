using AgendaApp.Utils;

namespace AgendaApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Quitar subrayado en Entry (opcional Android)
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderLine", (handler, view) =>
        {
#if __ANDROID__
            // Puedes usar esto si deseas modificar el fondo o quitar subrayado en Android
            // handler.PlatformView.Background = null;
#endif
        });
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Aplicar tema claro/oscuro guardado
        bool esOscuro = ConfiguracionApp.ObtenerTema();
        UserAppTheme = esOscuro ? AppTheme.Dark : AppTheme.Light;

        return new Window(new AppShell());
    }
}
