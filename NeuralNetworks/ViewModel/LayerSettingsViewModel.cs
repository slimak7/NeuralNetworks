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
    public class LayerSettingsViewModel : BaseViewModel<LayerSettingsWindow>
    {
        public NeuronLayer NeuronLayer { get => neuronLayer; set => SetProperty(ref neuronLayer, value); }
        public ActivationLayer ActivationLayer { get => activationLayer; set => SetProperty(ref activationLayer, value); }
        public BaseLayer BaseLayer { get => baseLayer; set => SetProperty(ref baseLayer, value); }

        public ObservableCollection<Neuron> Neurons { get; set; }
        public bool ShowNeuronsOptions { get => showNeuronsOptions; set => SetProperty(ref showNeuronsOptions, value); }
        public bool ShowActivationOptions { get => showActivationOptions; set => SetProperty(ref showActivationOptions, value); }
        public Neuron SelectedNeuron { get => selectedNeuron;
            set
            {
                SetProperty(ref selectedNeuron, value);
                View.EnableDeleteButton(selectedNeuron != null);
            }
        }
        public bool IsDeleteEnabled { get => isDeleteEnabled; set => SetProperty(ref isDeleteEnabled, value); }
        public ICommand AddNewNeuronCommand { get; set; }
        public ICommand DeleteNeuronCommand { get; set; }
        public ICommand SaveAndCloseCommand { get; set; }
        public int SelectedFunctionIndex { get => selectedFunctionIndex;
            set
            {
                SetProperty(ref selectedFunctionIndex, value);

                if (ActivationLayer != null)
                {
                    IActivationFunction function;

                    switch (value)
                    {
                        case 0:
                            function = new SigmoidFunction();
                            break;
                        default:
                            function = new SigmoidFunction();
                            break;
                    }

                    ActivationLayer.ActivationFunction = function;
                }
            }
        }

        public string[] ActivationFunctionsOptions
        {
            get => activationFunctionsOptions;
            set => SetProperty(ref activationFunctionsOptions, value);
        }

        private string[] activationFunctionsOptions = new string[] { "Sigmoid" };
        private int selectedFunctionIndex;
        private Neuron selectedNeuron;
        private bool showNeuronsOptions;
        private bool showActivationOptions;
        private BaseLayer baseLayer;
        private NeuronLayer neuronLayer;
        private ActivationLayer activationLayer;
        private bool isDeleteEnabled;

        public LayerSettingsViewModel(string title, LayerSettingsWindow view, BaseLayer selectedLayer) : base(title, view)
        {
            BaseLayer = selectedLayer;

            if (selectedLayer.GetLayerType() == LayerOptions.LayerType.Neuron)
            {
                NeuronLayer = BaseLayer as NeuronLayer;
                ShowNeuronsOptions = true;
                ShowActivationOptions = false;

                Neurons = new ObservableCollection<Neuron>();
                  
                foreach (var neuron in NeuronLayer.Neurons)
                {
                    Neurons.Add(new Neuron(neuron.Weights, neuron.HasBias));
                }
               
            }
            else
            {
                ActivationLayer = BaseLayer as ActivationLayer;
                ShowNeuronsOptions = false;
                ShowActivationOptions = true;

                if (ActivationLayer.ActivationFunction is SigmoidFunction)
                {
                    SelectedFunctionIndex = 0;
                }
            }

            AddNewNeuronCommand = new RelayCommand(AddNewNeuron);
            DeleteNeuronCommand = new RelayCommand(DeleteNeuron);
            SaveAndCloseCommand = new RelayCommand(SaveAndClose);
          
        }

        private void AddNewNeuron()
        {
            Neurons.Add(new Neuron(new List<double>(), true));
        }

        private void DeleteNeuron()
        {
            if (SelectedNeuron != null)
            {
                var index = Neurons.IndexOf(SelectedNeuron);
                Neurons.Remove(SelectedNeuron);
                if (Neurons.Any())
                {
                    SelectedNeuron = Neurons[index + 1 >= Neurons.Count ? Neurons.Count - 1 : index];
                }
                else
                {
                    SelectedNeuron = null;
                }

            }
        }

        private void SaveAndClose()
        {
            if (BaseLayer.GetLayerType() == LayerOptions.LayerType.Neuron)
            {
                NeuronLayer.Neurons.Clear();

                if (Neurons.Any())
                {
                    NeuronLayer.Neurons.AddRange(Neurons);
                }
            }

            View.Close();
        }
    }
}
