
using System.Globalization;
using System.Resources;
using Microsoft.Maui.Storage;

namespace AgendaApp.Utils
{
    public static class Traductor
    {
        private static readonly ResourceManager ResourceMgr = new ResourceManager("AgendaApp.Resources.Strings", typeof(Traductor).Assembly);

        public static string Get(string key)
        {
            string idioma = Preferences.Get("idioma", "es");
            CultureInfo culture = new CultureInfo(idioma);

            return ResourceMgr.GetString(key, culture) ?? $"[{key}]";
        }
    }
}
