using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace Sudoku.WPF.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private int _seconds = 0;
        private string _timeDisplay = "00:00";

        public string TimeDisplay
        {
            get => _timeDisplay;

            set
            {
                _timeDisplay = value;
                OnPropertyChanged(nameof(TimeDisplay));
            }
        }

        public TimerViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) =>
            {
                _seconds++;
                var t = TimeSpan.FromSeconds(_seconds);
                TimeDisplay = t.ToString(@"mm\:ss");
            };
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
