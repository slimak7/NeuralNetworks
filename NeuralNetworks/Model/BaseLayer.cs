using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public abstract class BaseLayer
    {
        public string Name { get; set; }

        protected BaseLayer(string name)
        {
            Name = name;
        }

        public abstract List<double> CalculateOutput(List<double> input);
        public abstract LayerOptions.LayerType GetLayerType();
    }
}
