 using Sudoku.Game.BoardSettings;

namespace Sudoku.Game.Rule
{
    public class Rules : IRules
    {
        public bool IsValidSudoku(Cell[,] board)
        {
            var row = new Dictionary<char, int>();
            var column = new Dictionary<char, int>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!row.ContainsKey(board[i,j].value))
                    {
                        if (board[i,j].value != '.')
                            row.Add(board[i,j].value, 1);
                    }
                    else
                        return false;

                    if (!column.ContainsKey(board[j,i].value))
                    {
                        if (board[j,i].value != '.')
                        {
                            column.Add(board[j,i].value, 1);
                        }
                    }
                    else
                        return false;
                }
                row.Clear();
                column.Clear();
            }

            var subBox = new Dictionary<char, int>();
            var x = 0;
            var y = 0;
            var k = 0;

            while (x < 9 && y < 9)
            {
                if (y % 3 == 2)
                {
                    if (x % 3 != 2)
                    {
                        if (board[x,y].value != '.')
                        {
                            if (!subBox.ContainsKey(board[x,y].value))
                            {
                                subBox.Add(board[x,y].value, 1);
                            }
                            else
                                return false;
                        }
                    }
                    x++;
                    y = k;
                }
                else
                {
                    if (board[x,y].value != '.')
                    {

                        if (!subBox.ContainsKey(board[x,y].value))
                        {
                            subBox[board[x,y].value] = 1;
                        }
                        else
                            return false;
                    }
                    y++;

                }
                if (y % 3 == 2 && x % 3 == 2)
                {
                    if (board[x,y].value != '.')
                    {
                        if (!subBox.ContainsKey(board[x,y].value))
                        {
                            subBox[board[x,y].value] = 1;
                        }
                        else
                            return false;
                    }

                    subBox.Clear();
                }

                if (x == 9)
                {
                    k += 3;
                    y = k;
                    x = 0;
                }

            }
            return true;
        }



    }
}
