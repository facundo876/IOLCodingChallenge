using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal radio) 
            : base(radio) 
        { }

        public override decimal CalcularArea() => (decimal)Math.PI * (_lado / 2) * (_lado / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * _lado;
    }
}
