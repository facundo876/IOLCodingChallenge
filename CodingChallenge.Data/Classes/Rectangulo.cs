using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        private decimal _base { get; set; }
        private decimal _altura { get; set; }

        public Rectangulo(decimal baseRectangulo, decimal alturaRectangulo) 
        {
            _base = baseRectangulo;
            _altura = alturaRectangulo;
        }

        public override decimal CalcularArea() => _base * _altura;
        public override decimal CalcularPerimetro() => 2 * (_base + _altura);
    }
}
