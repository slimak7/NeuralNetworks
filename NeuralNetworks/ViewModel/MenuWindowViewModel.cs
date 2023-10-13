﻿using GalaSoft.MvvmLight.Command;
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
        public ICommand SelectLayerCommand { get; set; }
        public ICommand DeleteLayerCommand { get; set; }

        public ObservableCollection<BaseLayer> Layers { get; set; }
        public BaseLayer SelectedLayer { get => selectedLayer; 
            set
            {
                SetProperty(ref selectedLayer, value);

                if (SelectedLayer?.GetLayerType() == LayerOptions.LayerType.Neuron)
                {
                    SelectedActivationLayer = null;
                    SelectedNeuronLayer = selectedLayer as NeuronLayer;
                }
                else if (SelectedLayer!= null)
                {
                    SelectedNeuronLayer = null;
                    SelectedActivationLayer = selectedLayer as ActivationLayer;
                }

                IsDeleteEnabled = SelectedLayer != null;
            }
        }
        public NeuronLayer SelectedNeuronLayer { get => selectedNeuronLayer; set => SetProperty(ref selectedNeuronLayer, value); }
        public ActivationLayer SelectedActivationLayer { get => selectedActivationLayer; set => SetProperty(ref selectedActivationLayer, value); }
        public bool IsDeleteEnabled { get => isDeleteEnabled; set => SetProperty(ref isDeleteEnabled, value); }

        private bool isDeleteEnabled;
        private ActivationLayer selectedActivationLayer;
        private NeuronLayer selectedNeuronLayer;
        private BaseLayer selectedLayer;
        private int neuronLayerNumber = 1;
        private int activationLayerNumber = 1;

        public MenuWindowViewModel(string title, MenuWindow view) : base(title, view)
        {
            Layers = new ObservableCollection<BaseLayer>();
            CreateNewNeuronLayerCommand = new RelayCommand(CreateNewNeuronLayer);
            CreateNewActivationLayerCommand = new RelayCommand(CreateNewActivationLayer);
            SelectLayerCommand = new RelayCommand(SelectLayer);
            DeleteLayerCommand = new RelayCommand(DeleteLayer);
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

        private void SelectLayer()
        {
            
        }

        private void DeleteLayer()
        {
            if (SelectedLayer != null)
            {
                Layers.Remove(SelectedLayer);
                SelectedLayer = null;           
            }
        }
    }
}
