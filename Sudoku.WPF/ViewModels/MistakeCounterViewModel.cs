using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class MistakeCounterViewModel : INotifyPropertyChanged
    {
        private int _counter = 0;


        public int MistakeCounter
        {
            get => _counter;

            set
            {
                _counter = value;
                OnPropertyChanged(nameof(MistakeCounter));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string count) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(count));
    }
}
