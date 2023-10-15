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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MenuWindow : Window, IBaseView
    {
        private MenuWindowViewModel MenuWindowViewModel;
        public MenuWindow()
        {
            MenuWindowViewModel = new MenuWindowViewModel("Welcome to Neural Networks!", this);
            DataContext = MenuWindowViewModel;

            InitializeComponent();

            EnableDeleteSettingsButton(false);
        }

        public void EnableDeleteSettingsButton(bool enable)
        {
            DeleteLayerButton.IsEnabled = enable;
            LayerSettingsButton.IsEnabled = enable;
        }

        public void OpenLayerSettingsWindow(BaseLayer selectedLayer)
        {
            LayerSettingsWindow layerSettingsWindow = new LayerSettingsWindow(selectedLayer);
            layerSettingsWindow.ShowDialog();
        }
    }
}
