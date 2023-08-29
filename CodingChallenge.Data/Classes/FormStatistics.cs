using CodingChallenge.Data.Classes.Language;
using CodingChallenge.Data.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class FormStatistics
    {

        public int FormCount { get; private set; }
        public decimal AreaTotal { get; private set; }
        public decimal PerimetroTotal { get; private set; }

        public void IncrementCounts(decimal area, decimal perimeter)
        {
            FormCount++;
            AreaTotal += area;
            PerimetroTotal += perimeter;
        }

        public string FormatFormStatistics(Type tipoForma, LanguageManager languageManager)
        {
            var formaName = FormCount > 1 
                ? languageManager.GetTranslation($"{tipoForma.Name}Plural")
                : languageManager.GetTranslation(tipoForma.Name);

            var perimeterLabel = languageManager.GetTranslation("perimeterLabel");
            var areaLabel = languageManager.GetTranslation("areaLabel");

            var cultureInfo = languageManager.GetCultureInfo();

            return $"{FormCount} {formaName} | {areaLabel} {AreaTotal.ToString("#.##", cultureInfo)} | {perimeterLabel} {PerimetroTotal.ToString("#.##", cultureInfo)} <br/>";
        }
    }
}
