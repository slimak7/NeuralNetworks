using NeuralNetworks.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ViewModel
{
    public abstract class BaseViewModel<M> : INotifyPropertyChanged where M : IBaseView
    {
        private string title;
        protected M View;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected BaseViewModel(string title, M view)
        {
            Title = title;
            View = view;
        }


        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string name = null)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
