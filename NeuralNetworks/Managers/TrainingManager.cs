using NeuralNetworks.Helpers;
using NeuralNetworks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeuralNetworks.Managers
{
    public class TrainingManager
    {
        private List<NeuronLayer> neuronLayers;
        private ActivationLayer activationLayer;
        private int numberOfRounds;
        private List<TrainingDataSet> trainingDataSet;
        private Action<int, bool> reportProgressCallback;
        private double mean = 5;
        private double stdDev = 3;
        private Thread trainingThread;

        
        public TrainingManager(List<NeuronLayer> neuronLayers, ActivationLayer activationLayer, int numberOfRounds, List<TrainingDataSet> trainingDataSet, Action<int, bool> reportProgressCallback)
        {
          
            this.neuronLayers = neuronLayers;
            this.activationLayer = activationLayer;
            this.numberOfRounds = numberOfRounds;
            this.trainingDataSet = trainingDataSet;
            this.reportProgressCallback = reportProgressCallback;
        }

        public void Run()
        {
            trainingThread = new Thread(new ThreadStart(RunTraining));
            trainingThread.Start();
        }
     

        private void InitializeLayers()
        {
            for (int i = 0; i < neuronLayers.Count; i++)
            {
                var numberOfWeights = i == 0 ? trainingDataSet[0].Input.Length : neuronLayers[i - 1].Neurons.Count;

                for (int j = 0; j < neuronLayers[i].Neurons.Count; j++)
                {
                    var weights = numberOfWeights;
                    if (neuronLayers[i][j].HasBias)
                    {
                        weights++;
                    }

                    neuronLayers[i][j].Weights.Clear();

                    for (int k = 0; k < weights; k++)
                    {
                        neuronLayers[i][j].Weights.Add(NormalDistributionRandomGenerator.GetRandom(mean, stdDev));
                    }
                }
            }
        }

        private void RunTraining()
        {
            InitializeLayers();

            reportProgressCallback(0, true);
        }
    }
}
