using Microsoft.Maui.Storage;

namespace AgendaApp.Utils;

public static class ConfiguracionApp
{
    private const string TEMA_KEY = "temaOscuro";
    private const string IDIOMA_KEY = "idioma";
    private const bool DEFAULT_TEMA = false; // Claro
    private const string DEFAULT_IDIOMA = "es";

    public static void GuardarTema(bool esOscuro) =>
        Preferences.Set(TEMA_KEY, esOscuro);

    public static bool ObtenerTema() =>
        Preferences.Get(TEMA_KEY, DEFAULT_TEMA);

    public static void GuardarIdioma(string idioma) =>
        Preferences.Set(IDIOMA_KEY, idioma);

    public static string ObtenerIdioma() =>
        Preferences.Get(IDIOMA_KEY, DEFAULT_IDIOMA);
}
