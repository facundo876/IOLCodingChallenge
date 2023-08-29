using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private decimal Lado { get; set; }

        public Cuadrado(decimal lado) 
        {
            this.Lado = lado;
        }

        public override decimal CalcularArea() => Lado * Lado;

        public override decimal CalcularPerimetro() => Lado * 4;
    }
}
