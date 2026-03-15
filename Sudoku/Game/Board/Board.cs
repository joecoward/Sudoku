
namespace Sudoku.Game.BoardSettings
{
    public class Board : BoardConfiguration,  IBoard
    {

        public Board(Random random) : base(random)
        { }

        public void WriteBoard()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write(Field[i, j].value + " ");
                }
                Console.WriteLine();
            }
        }
        public Cell[,] GetBoard()
        {
            return Field;
        }
        public void UpdateBoard(int indexRow, int indexColumn, char value , bool isLocked =false)
        {
            Field[indexRow, indexColumn] = new Cell(value,isLocked);
        }

        public bool IsGameEnd()
        {
            for (int r = 0; r < Row; r++)
            {
                for (int c = 0; c < Column; c++)
                {
                    if (Field[r, c].value == '.')
                        return false;
                }
            }
            return true;
        }

        public void GenerateLevel(int locked,int dif)
        {
            Difficulty(locked, dif);
        }

    }
}
