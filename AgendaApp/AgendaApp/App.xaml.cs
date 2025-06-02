#if __ANDROID__
using Android.Content.Res;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;
using AgendaApp.Utils;
namespace AgendaApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderLine", (handler, view) =>
        {
#if __ANDROID__
            //(handler.PlatformView as Android.Views.View).SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.To_Android());
#endif
        });
       

    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Aplicar tema guardado al iniciar
        bool esOscuro = ConfiguracionApp.ObtenerTema();
        UserAppTheme = esOscuro ? AppTheme.Dark : AppTheme.Light;

        return new Window(new AppShell());



    }
}