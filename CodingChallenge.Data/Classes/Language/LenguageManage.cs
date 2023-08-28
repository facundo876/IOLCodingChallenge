using CodingChallenge.Data.Emuns;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CodingChallenge.Data.Classes.Language
{
    public class LanguageManager
    {
        private Dictionary<Idioma, Dictionary<string, string>> translations;

        public LanguageManager()
        {
            translations = LoadTranslations();
        }

        private Dictionary<Idioma, Dictionary<string, string>> LoadTranslations()
        {
            var jsonString = File.ReadAllText("translations.json");
            return JsonSerializer.Deserialize<Dictionary<Idioma, Dictionary<string, string>>>(jsonString);
        }

        public string GetTranslation(Idioma idioma, string key, params object[] args)
        {
            if (translations.ContainsKey(idioma) && translations[idioma].ContainsKey(key))
            {
                return string.Format(translations[idioma][key], args);
            }
            return string.Empty;
        }
    }
}
