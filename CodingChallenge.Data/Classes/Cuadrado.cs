using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado) : base(new Dictionary<string, decimal> { { "Lado", lado } }) { }


        public override decimal CalcularArea() => Medidas["Lado"] * Medidas["Lado"];
        public override decimal CalcularPerimetro() => Medidas["Lado"] * 4;
    }
}
