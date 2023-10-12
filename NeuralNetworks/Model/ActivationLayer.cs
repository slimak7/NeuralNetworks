using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class ActivationLayer : BaseLayer
    {
        private IActivationFunction activationFunction;

        public ActivationLayer(IActivationFunction activationFunction, string name) : base(name)
        {
            ActivationFunction = activationFunction;
        }

        public IActivationFunction ActivationFunction { get => activationFunction; set => activationFunction = value; }

        public override List<double> CalculateOutput(List<double> input)
        {
            List<double> output = new List<double>();

            foreach (var inputItem in input)
            {
                output.Add(ActivationFunction.CalculateOutput(inputItem));
            }

            return output;
        }

        public override LayerOptions.LayerType GetLayerType()
        {
            return LayerOptions.LayerType.Activation;
        }
    }
}
