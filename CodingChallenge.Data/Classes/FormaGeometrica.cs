/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public abstract string NombreSingular { get; }
        public abstract string NombrePlural { get; }

        protected readonly decimal _lado;

        protected FormaGeometrica(decimal lado)
        {
            _lado = lado;
        }

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();

        public string Imprimir(List<FormaGeometrica> formas, Idioma idioma) 
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(idioma == Idioma.Castellano
                    ? $"<h1>Lista vacía de {NombrePlural}!</h1>"
                    : $"<h1>Empty list of {NombrePlural}!</h1>");
            }
            else
            {
                sb.Append(idioma == Idioma.Castellano
                    ? $"<h1>Reporte de {NombrePlural}</h1>"
                    : $"<h1>{NombrePlural} report</h1>");

                var contadorFormas = new Dictionary<Type, int>();
                var areaTotal = new Dictionary<Type, decimal>();
                var perimetroTotal = new Dictionary<Type, decimal>();

                foreach (var forma in formas)
                {
                    var tipo = forma.GetType();
                    if (!contadorFormas.ContainsKey(tipo))
                    {
                        contadorFormas[tipo] = 0;
                        areaTotal[tipo] = 0m;
                        perimetroTotal[tipo] = 0m;
                    }

                    contadorFormas[tipo]++;
                    areaTotal[tipo] += forma.CalcularArea();
                    perimetroTotal[tipo] += forma.CalcularPerimetro();
                }

                foreach (var kvp in contadorFormas)
                {
                    var tipoForma = kvp.Key;
                    sb.Append(ObtenerLinea(kvp.Value, areaTotal[tipoForma], perimetroTotal[tipoForma], tipoForma, idioma));
                }

                sb.Append($"TOTAL:<br/>");
                sb.Append($"{formas.Count} {(idioma == Idioma.Castellano ? NombrePlural : "shapes")} ");
                sb.Append($"{(idioma == Idioma.Castellano ? "Perimetro " : "Perimeter ")}{perimetroTotal.Values.Sum():#.##} ");
                sb.Append($"Area {areaTotal.Values.Sum():#.##}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Type tipo, Idioma idioma)
        {
            if (cantidad > 0)
            {
                var nombre = idioma == Idioma.Castellano ? (string)tipo.GetProperty("NombreSingular").GetValue(null) : (string)tipo.GetProperty("NombrePlural").GetValue(null);
                var areaTexto = idioma == Idioma.Castellano ? "Área" : "Area";
                var perimetroTexto = idioma == Idioma.Castellano ? "Perímetro" : "Perimeter";

                return $"{cantidad} {nombre} | {areaTexto} {area:#.##} | {perimetroTexto} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
    }
}
