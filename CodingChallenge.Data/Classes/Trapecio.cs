using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private decimal BaseMayor { get; set; }
        private decimal BaseMenor { get; set; }
        private decimal Altura { get; set; }
        private decimal LadoA { get; set; }
        private decimal LadoB { get; set; }


        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoA, decimal ladoB)
        { 
            this.BaseMayor = baseMayor;
            this.BaseMenor = baseMenor;
            this.Altura = altura;
            this.LadoA = ladoA;
            this.LadoB = ladoB;
        }

        public override decimal CalcularArea() => (BaseMayor + BaseMenor) * Altura / 2;
        public override decimal CalcularPerimetro() => BaseMayor + BaseMenor + LadoA + LadoB;
    }
}
