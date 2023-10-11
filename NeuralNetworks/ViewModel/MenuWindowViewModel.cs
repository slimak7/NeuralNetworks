using NeuralNetworks.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ViewModel
{
    public class MenuWindowViewModel : BaseViewModel<MenuWindow>
    {
        public MenuWindowViewModel(string title, MenuWindow view) : base(title, view)
        {
        }
    }
}
