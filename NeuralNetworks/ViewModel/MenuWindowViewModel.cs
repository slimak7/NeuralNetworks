using GalaSoft.MvvmLight.Command;
using NeuralNetworks.Model;
using NeuralNetworks.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NeuralNetworks.ViewModel
{
    public class MenuWindowViewModel : BaseViewModel<MenuWindow>
    {
        public ICommand CreateNewNeuronLayerCommand { get; set; }
        public ICommand CreateNewActivationLayerCommand { get;set; }

        public ObservableCollection<BaseLayer> Layers { get; set; }

        private int neuronLayerNumber = 1;
        private int activationLayerNumber = 1;

        public MenuWindowViewModel(string title, MenuWindow view) : base(title, view)
        {
            Layers = new ObservableCollection<BaseLayer>();
            CreateNewNeuronLayerCommand = new RelayCommand(CreateNewNeuronLayer);
            CreateNewActivationLayerCommand = new RelayCommand(CreateNewActivationLayer);
        }

        private void CreateNewNeuronLayer()
        {
            Layers.Add(new NeuronLayer(new List<Neuron>(), "Neuron layer " + neuronLayerNumber));
            neuronLayerNumber++;
        }

        private void CreateNewActivationLayer()
        {
            Layers.Add(new ActivationLayer(new SigmoidFunction(), "Activation layer " + activationLayerNumber));
            activationLayerNumber++;
        }
    }
}
