using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class DifficultyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _levelOfDiff;

        public string LevelOfDifficulty
        {
            get
            {
                return _levelOfDiff;
            }
            set
            {
                _levelOfDiff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LevelOfDifficulty)));
            }
            
        }
    }
}
