using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Helpers
{
    public static class NormalDistributionRandomGenerator
    {
        private static readonly Random rand = new Random();
        public static double GetRandom(double mean, double stdDev)
        {          
            double u1 = 1.0 - rand.NextDouble(); 
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); 
            double randNormal = mean + stdDev * randStdNormal;
            return randNormal;
        }
    }
}
