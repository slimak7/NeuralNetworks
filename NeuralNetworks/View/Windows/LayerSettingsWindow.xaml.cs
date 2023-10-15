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
    /// Interaction logic for LayerSettingsWindow.xaml
    /// </summary>
    public partial class LayerSettingsWindow : Window, IBaseView
    {
        private LayerSettingsViewModel layerSettingsViewModel;
        public LayerSettingsWindow(BaseLayer selectedLayer)
        {
            layerSettingsViewModel = new LayerSettingsViewModel("Set up the layer", this, selectedLayer);
            DataContext = layerSettingsViewModel;

            InitializeComponent();

            EnableDeleteButton(false);
        }

        public void EnableDeleteButton(bool enabled)
        {
            DeleteNeuronButton.IsEnabled = enabled;
        }

    }
}
