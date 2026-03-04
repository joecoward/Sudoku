

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

        private int _countMistakes = 0;


        public void Start(string difficulty)
        {
            Difficulty(difficulty);

            while (!_isGameOver)
            {
                
                Console.WriteLine("Mistakes Coount := "+_countMistakes);
                Console.WriteLine("----------------------");
                _board.WriteBoard();
                Console.WriteLine("----------------------");

                Console.WriteLine();

                Console.Write("Enter row:=");
                if (!int.TryParse(Console.ReadLine(), out int indexRow))
                    Console.WriteLine("Its not a number");

                Console.Write("Enter column:=");
                if (!int.TryParse(Console.ReadLine(), out int indexColumn))
                    Console.WriteLine("Its not a number");

                Console.Write("Enter value:=");
                if (!char.TryParse(Console.ReadLine(), out char value))
                    Console.WriteLine("Its not a number");

                Console.WriteLine();

                Console.Clear();

                _board.UpdateBoard(indexRow-1, indexColumn-1, value);
                if (!_rules.IsValidSudoku(_board.GetBoard()))
                {
                    _countMistakes++;
                    Console.WriteLine("try again");
                }
                
            }

        }

        private void Difficulty(string difficulty)
        {

            var dif = 0;
            var locked = 35;
            if (difficulty == "Normal")
            {
                dif = 1;
                locked = 30;
            }
            if (difficulty == "Hard")
            {
                dif = 2;
                locked = 25;
            }

            var board = _board.GetBoard();

            var deleted = 0;

            var empty = -1;

            while (deleted != 81 - locked/* || empty != dif*/)
            {
                var randomCell = _random.Next(0, 81);

                var Celli = randomCell % 9;
                var Cellj = randomCell / 9;

                if (board[Celli, Cellj].value != '.')
                {
                    board[Celli, Cellj].value = '.';
                    deleted++;
                }
                else
                    continue;

            }

        }


    }
}
