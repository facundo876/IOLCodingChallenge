using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private decimal Radio { get; set; }

        public Circulo(decimal radio) 
        {
            this.Radio = radio;
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (Radio / 2) * (Radio / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * Radio;
    }
}
