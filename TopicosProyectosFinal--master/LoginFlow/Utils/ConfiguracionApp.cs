
using Microsoft.Maui.Storage;

namespace LoginFlow.Utils;

public static class ConfiguracionApp
{
    public static void GuardarTema(bool esOscuro)
    {
        Preferences.Set("temaOscuro", esOscuro);
    }

    public static bool ObtenerTema()
    {
        return Preferences.Get("temaOscuro", false);
    }

    public static void GuardarIdioma(string idioma)
    {
        Preferences.Set("idioma", idioma);
    }

    public static string ObtenerIdioma()
    {
        return Preferences.Get("idioma", "es");
    }
}
