using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModel
    {
        public IBoard Board { get; }
        public IRules Rules { get; }
        public GameDifficulty Difficulty { get; }

        public MistakeCounterViewModel Mistakes { get; }

        public TimerViewModel Timer { get; }

        public MainViewModel(IBoard board, IRules rules, GameDifficulty difficulty, MistakeCounterViewModel counter, TimerViewModel timer)
        {
            Board = board;
            Rules = rules;
            Difficulty = difficulty;
            Difficulty.Difficulty("");

            Mistakes = counter;
            Timer = timer;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
