using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public class TrainingDataSet
    {
        public double[] Input { get; set; }
        public double[] Output { get; set; }

        public TrainingDataSet(double[] input, double[] output)
        {
            Input = input;
            Output = output;
        }
    }
}
