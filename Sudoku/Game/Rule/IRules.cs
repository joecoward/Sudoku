using Sudoku.Game.BoardSettings;

namespace Sudoku.Game.Rule
{
    public interface IRules
    {
        public bool IsValidSudoku(Cell[,] board);

        //public Cell[,] GenerateLevel(string dificulty);

    }
}
