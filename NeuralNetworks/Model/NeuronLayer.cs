using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class NeuronLayer : BaseLayer
    {
        private List<Neuron> neurons;

        public List<Neuron> Neurons { get => neurons; set => neurons = value; }

        public NeuronLayer(List<Neuron> neurons, string name) : base(name)
        {
            Neurons = neurons;
        }

        public Neuron this[int index]
        {
            get { return neurons[index]; }
        } 

        public override List<double> CalculateOutput(List<double> input)
        {
            List<double> output = new List<double>();

            foreach (Neuron neuron in neurons)
            {
                output.Add(neuron.CalculateOutput(input));
            }

            return output;
        }

        public override LayerOptions.LayerType GetLayerType()
        {
            return LayerOptions.LayerType.Neuron;
        }
    }
}
