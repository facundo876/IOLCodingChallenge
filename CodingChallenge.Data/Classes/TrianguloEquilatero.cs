using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {

        public TrianguloEquilatero(decimal lado) : base(new Dictionary<string, decimal> { { "Lado", lado } }) { }

        //public override decimal CalcularArea()
        //{
        //    return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        //}

        //public override decimal CalcularPerimetro()
        //{
        //    return _lado * 3;
        //}

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * Medidas["Lado"] * Medidas["Lado"];
        public override decimal CalcularPerimetro() => Medidas["Lado"] * 3;
    }
}
