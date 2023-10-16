using NeuralNetworks.Model;
using NeuralNetworks.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ViewModel
{
    class NetworkTrainingViewModel : BaseViewModel<NetworkTrainingWindow>
    {
        
        private ActivationLayer activationLayer;
        private List<NeuronLayer> neuronLayers;
        public NetworkTrainingViewModel(string title, NetworkTrainingWindow view, List<BaseLayer> layers) : base(title, view)
        {
            if (layers != null && layers.Any())
            {
                activationLayer = layers[0] as ActivationLayer;

                neuronLayers = layers.GetRange(1, layers.Count - 1).Select(x => x as NeuronLayer).ToList();
            }
        }
    }
}
