using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using NeuralNetworks.Helpers;
using NeuralNetworks.Managers;
using NeuralNetworks.Model;
using NeuralNetworks.View.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NeuralNetworks.ViewModel
{
    class NetworkTrainingViewModel : BaseViewModel<NetworkTrainingWindow>
    {
        public ICommand LoadTrainingDataCommand { get; set; }
        public ICommand StartTrainingCommand { get; set; }
        public int NumberOfRounds { get => numberOfRounds; set => SetProperty(ref numberOfRounds, value); }

        private int numberOfRounds;
        private ActivationLayer activationLayer;
        private List<NeuronLayer> neuronLayers;
        private List<TrainingDataSet> trainingDataSet;
        private TrainingManager trainingManager;

        public NetworkTrainingViewModel(string title, NetworkTrainingWindow view, List<BaseLayer> layers) : base(title, view)
        {
            if (layers != null && layers.Any())
            {
                activationLayer = layers[0] as ActivationLayer;

                neuronLayers = layers.GetRange(1, layers.Count - 1).Select(x => x as NeuronLayer).ToList();
            }

            LoadTrainingDataCommand = new RelayCommand(LoadTrainingData);
            StartTrainingCommand = new RelayCommand(StartTraining);

            NumberOfRounds = 5000;
        }

        private void LoadTrainingData()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = "text files|*.txt";

            var result = dialog.ShowDialog();

            if (result ?? false)
            {
                var text = File.ReadAllText(dialog.FileName);

                trainingDataSet = TrainingDataLoader.GetData(text);
            }
            
        }

        private void StartTraining()
        {
            trainingManager = 
                new TrainingManager(neuronLayers, activationLayer, NumberOfRounds,
                trainingDataSet, UpdateProcessStatus);

            trainingManager.Run();

            View.EnableStartTrainingButton(false);
        }

        private void UpdateProcessStatus(int roundNumber, bool completed)
        {
            if (completed)
            {
                Application.Current.Dispatcher.Invoke(() => View.EnableStartTrainingButton(true));             
            }
        }
    }
}
