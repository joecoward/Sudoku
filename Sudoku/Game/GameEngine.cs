

using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;

namespace Sudoku.Game
{
    public class GameEngine
    {
        public Random Random { get; }

        public IBoard Board { get; }

        public IRules Rules { get; }

        public GameDifficulty GameDifficulty { get; }


        public GameEngine(IBoard board,IRules rules,Random random , GameDifficulty gameDifficulty)
        {
            GameDifficulty = gameDifficulty;
            Random = random;
            Board = board;
            Rules = rules;
        }

        public void Difficulty(string level)
        {
            var dif = GameDifficulty.SetDifficulty(level);
            Board.GenerateLevel(dif[1], dif[0]);
        }

    }
}
