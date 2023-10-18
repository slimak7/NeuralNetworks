using NeuralNetworks.Model;
using NeuralNetworks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NeuralNetworks.View.Windows
{
    /// <summary>
    /// Interaction logic for NetworkTraining.xaml
    /// </summary>
    public partial class NetworkTrainingWindow : Window, IBaseView
    {
        private NetworkTrainingViewModel networkTrainingViewModel;
        public NetworkTrainingWindow(List<BaseLayer> layers)
        {
            networkTrainingViewModel = new NetworkTrainingViewModel("Train neural network", this, layers);
            DataContext = networkTrainingViewModel;

            InitializeComponent();
        }

        public void EnableStartTrainingButton(bool enableTrainingButton)
        {
            StartTrainingButton.IsEnabled = enableTrainingButton;
        }
    }
}
