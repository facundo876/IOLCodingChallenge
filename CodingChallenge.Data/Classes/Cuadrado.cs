using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado) 
            : base(lado) 
        { }

        public override decimal CalcularArea() => _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 4;
    }
}
