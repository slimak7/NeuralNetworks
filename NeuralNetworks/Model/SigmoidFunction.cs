using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class SigmoidFunction : IActivationFunction
    {
        public double CalculateOutput(double value)
        {
            return (Math.Exp(value))/(1 + Math.Exp(value));
        }
    }
}
