using Sudoku.Dal.Conc;
using Sudoku.Dal.Interfa;
using Sudoku.Game;
using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using Sudoku.WPF.Services.Abs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public GameEngine Engine { get; }


        public MistakeCounterViewModel Mistakes { get; }
        public TimerViewModel Timer { get; }
        public DifficultyViewModel LevelOfDifficulty { get; }


        public IDialogService DialogService { get; }

        public IGameDal gameDal;


        private  bool IsGameOver = false;

        public MainViewModel(GameEngine engine, IDialogService dialogService , IGameDal gameDal)
        {

            Engine = engine;
            this.gameDal = gameDal;

            DialogService = dialogService;
            Mistakes = new MistakeCounterViewModel();
            Timer = new TimerViewModel();
            LevelOfDifficulty = new DifficultyViewModel();
        }

        public bool CheckGameOver()
        {
            if(Mistakes.MistakeCounter>=5)
            {
                Timer.StopTimer();
                IsGameOver = true;
                //var entity = new Sudoku.Models.Game
                //{
                //    UserId = 1,
                //    Time = Timer.TimeDisplay,
                //    Difficulty = Engine.GameDifficulty.GetDifficulty(),
                //    Mistakes = Mistakes.MistakeCounter,
                //    Finished = IsGameOver
                //};
                //gameDal.Create(entity);
                DialogService.ShowMessage("You lose");
                return true;
            }
            if(Engine.Board.IsGameEnd() && Engine.Rules.IsValidSudoku(Engine.Board.GetBoard()))
            {
                Timer.StopTimer();
                //var entity = new Sudoku.Models.Game
                //{
                //    UserId = 1,
                //    Time = Timer.TimeDisplay,
                //    Difficulty = Engine.GameDifficulty.GetDifficulty(),
                //    Mistakes = Mistakes.MistakeCounter,
                //    Finished = IsGameOver
                //};
                //gameDal.Create(entity);
                DialogService.ShowMessage("You win");
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
