/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Classes.Language;
using CodingChallenge.Data.Emuns;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        protected FormaGeometrica(){ }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();

        public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma) 
        {
            var languageManager = new LanguageManager(idioma);
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{languageManager.GetTranslation("emptyListHeader")}</h1>");
            }
            else
            {
                sb.Append($"<h1>{languageManager.GetTranslation("reportHeader")}</h1>");

                var statistics = CalculateStatistics(formas);
                sb.Append(FormatFormStatistics(statistics, languageManager));
                sb.Append(FormatTotalStatistics(statistics, languageManager));

            }

            return sb.ToString();
        }


        private static Dictionary<Type, FormStatistics> CalculateStatistics(List<FormaGeometrica> formas)
        {
            var statistics = new Dictionary<Type, FormStatistics>();

            foreach (var forma in formas)
            {
                var tipo = forma.GetType();
                if (!statistics.ContainsKey(tipo))
                {
                    statistics[tipo] = new FormStatistics();
                }

                statistics[tipo].IncrementCounts(forma.CalcularArea(), forma.CalcularPerimetro());
            }

            return statistics;
        }

        private static string FormatFormStatistics(Dictionary<Type, FormStatistics> statistics, LanguageManager languageManager)
        {
            var sb = new StringBuilder();

            foreach (var kvp in statistics)
            {
                var tipoForma = kvp.Key;
                sb.Append(kvp.Value.FormatFormStatistics(tipoForma, languageManager));
            }

            return sb.ToString();
        }

        private static string FormatTotalStatistics(Dictionary<Type, FormStatistics> statistics, LanguageManager languageManager)
        {
            var FormCounts = statistics.Values.Sum(stat => stat.FormCount);
            var totalPerimeter = statistics.Values.Sum(stat => stat.PerimetroTotal);
            var totalArea = statistics.Values.Sum(stat => stat.AreaTotal);

            var shapesLabel = languageManager.GetTranslation("shapesLabel");
            var perimeterLabel = languageManager.GetTranslation("perimeterLabel");
            var areaLabel = languageManager.GetTranslation("areaLabel");

            var cultureInfo = languageManager.GetCultureInfo();

            return $"TOTAL:<br/>{FormCounts} {shapesLabel} {perimeterLabel} {totalPerimeter.ToString("#.##", cultureInfo)} {areaLabel} {totalArea.ToString("#.##", cultureInfo)}";
        }
    }
}
