using NeuralNetworks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class Neuron
    {
        private List<double> weights;
        private bool hasBias;

        public List<double> Weights { get => weights; set => weights = value; }
        public bool HasBias { get => hasBias; set => hasBias = value; }

        public double this[int index]
        {
            get
            {
                return Weights[index];
            }
            set
            {
                Weights[index] = value;
            }          
        }

        public Neuron(List<double> weights, bool hasBias)
        {
            Weights = weights;
            HasBias = hasBias;            
        }

        public double CalculateOutput(List<double> input)
        {
            if ((!HasBias && input.Count != Weights.Count) || (hasBias && input.Count + 1 != Weights.Count))
            {
                throw new InvalidInputException("Number of input elements does not match weights number");
            }

            double result = 0;

                     
            for (int i = 0; i < input.Count; i++)
            {
                result += input[i] * Weights[i];
            }

            if (HasBias)
            {
                result += Weights.Last();
            }

            return result;
            
        }
    }
}
