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
    public abstract class BaseViewModel<M> : INotifyPropertyChanged where M : BaseView
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

        public void OnPropertyChanged([CallerMemberName] string name = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void SetProperty<T>(ref T property, T value)
        {
            property = value;
            OnPropertyChanged();
        }

    }
}
