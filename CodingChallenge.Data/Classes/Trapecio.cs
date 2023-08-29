using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoA, decimal ladoB) 
            : base(new Dictionary<string, decimal>
                {
                    { "BaseMayor", baseMayor },
                    { "BaseMenor", baseMenor },
                    { "Altura", altura },
                    { "LadoA", ladoA },
                    { "LadoB", ladoB }
                })
        { }

        public override decimal CalcularArea() => (Medidas["BaseMayor"] + Medidas["BaseMenor"]) * Medidas["Altura"] / 2;
        public override decimal CalcularPerimetro() => Medidas["BaseMayor"] + Medidas["BaseMenor"] + Medidas["LadoA"] + Medidas["LadoB"];
    }
}
