

using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;

namespace Sudoku.Game
{
    public class GameEngine
    {
        private Random _random = new Random();

        private IBoard _board = new Board();

        private IRules _rules = new Rules();

        private bool _isGameOver = false;

        public int _countMistakes = 0;


        public bool Start(string difficulty ,int indexRow,int indexColumn,char value)
        {
            GameDifficulty _gameDifficulty = new GameDifficulty(_board);

            _gameDifficulty.Difficulty(difficulty);

            while (!_isGameOver)
            {
                
                //Console.WriteLine("Mistakes Coount := "+_countMistakes);
                //Console.WriteLine("----------------------");
                //_board.WriteBoard();
                //Console.WriteLine("----------------------");

                //Console.WriteLine();

                //Console.Write("Enter row:=");
                //if (!int.TryParse(Console.ReadLine(), out int indexRow))
                //    Console.WriteLine("Its not a number");

                //Console.Write("Enter column:=");
                //if (!int.TryParse(Console.ReadLine(), out int indexColumn))
                //    Console.WriteLine("Its not a number");

                //Console.Write("Enter value:=");
                //if (!char.TryParse(Console.ReadLine(), out char value))
                //    Console.WriteLine("Its not a number");

                //Console.WriteLine();

                //Console.Clear();

                _board.UpdateBoard(indexRow-1, indexColumn-1, value);
                if (!_rules.IsValidSudoku(_board.GetBoard()))
                {
                    _countMistakes++;
                    //Console.WriteLine("try again");
                }
               
            }
            return true;

        }

        


    }
}
