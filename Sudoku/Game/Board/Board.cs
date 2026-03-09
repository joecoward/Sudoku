
namespace Sudoku.Game.BoardSettings
{
    public class Board : BoardConfiguration,  IBoard
    {
        public Board()
        {
        }

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

    }
}
