using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private decimal Lado;
        public TrianguloEquilatero(decimal lado) 
        { 
            this.Lado = lado;
        }

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        public override decimal CalcularPerimetro() => Lado * 3;
    }
}
