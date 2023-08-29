using CodingChallenge.Data.Emuns;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;

namespace CodingChallenge.Data.Classes.Language
{
    public class LanguageManager
    {
        private Dictionary<Idioma, Dictionary<string, string>> translations;
        private Idioma currentIdioma;

        public LanguageManager(Idioma idioma)
        {
            currentIdioma = idioma;
            translations = LoadTranslations();
        }

        private Dictionary<Idioma, Dictionary<string, string>> LoadTranslations()
        {
            string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources");
            string jsonFilePath = Path.Combine(resourcesPath, "translations.json");

            var jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<Dictionary<Idioma, Dictionary<string, string>>>(jsonString);
        }

        public string GetTranslation(string key, params object[] args)
        {
            if (translations.ContainsKey(currentIdioma) && translations[currentIdioma].ContainsKey(key))
            {
                return string.Format(translations[currentIdioma][key], args);
            }
            return string.Empty;
        }

        public CultureInfo GetCultureInfo()
        {
            var cultureInfo = new CultureInfo("es-ES");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfo.NumberFormat.NumberGroupSeparator = ".";
            return cultureInfo;
        }
    }
}
