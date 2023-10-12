using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class Activation
    {
        private IActivationFunction activationFunction;
        public Activation(IActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
        }

        public double CalculateOutput(double input)
        {
            return activationFunction.CalculateOutput(input);
        }
    }
}
